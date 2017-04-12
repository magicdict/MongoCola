using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.ToolKit;

namespace MongoUtility.Aggregation
{
    public static class QueryHelper
    {
        /// <summary>
        ///     获得输出列表
        /// </summary>
        /// <returns></returns>
        public static string[] GetOutputFields(List<DataFilter.QueryFieldItem> fieldItemLst)
        {
            var outputFieldLst = new List<string>();
            foreach (var item in fieldItemLst)
            {
                if (item.IsShow)
                {
                    outputFieldLst.Add(item.ColName);
                }
            }
            return outputFieldLst.ToArray();
        }

        /// <summary>
        ///     获得当前数据集包含记录数
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static long GetCurrentCollectionCount(DataFilter query)
        {
            if (query == null)
            {
                return RuntimeMongoDbContext.GetCurrentCollection().Count();
            }
            var mQuery = GetQuery(query.QueryConditionList);
            return RuntimeMongoDbContext.GetCurrentCollection().Count(mQuery);
        }

        /// <summary>
        ///     获得排序
        /// </summary>
        /// <returns></returns>
        public static SortByBuilder GetSort(List<DataFilter.QueryFieldItem> fieldItemLst)
        {
            var sort = new SortByBuilder();
            //排序
            fieldItemLst.Sort((x, y) => { return x.SortOrder - y.SortOrder; });
            foreach (var item in fieldItemLst)
            {
                if (item.SortOrder == 0) continue;
                switch (item.SortType)
                {
                    case DataFilter.SortType.NoSort:
                        break;
                    case DataFilter.SortType.Ascending:
                        sort.Ascending(item.ColName);
                        break;
                    case DataFilter.SortType.Descending:
                        sort.Descending(item.ColName);
                        break;
                }
            }
            return sort;
        }

        /// <summary>
        ///     获得查询
        /// </summary>
        /// <returns></returns>
        public static IMongoQuery GetQuery(List<DataFilter.QueryConditionInputItem> queryCompareList)
        {
            var conditiongrpList = new List<List<DataFilter.QueryConditionInputItem>>();
            List<DataFilter.QueryConditionInputItem> currGrp = null;
            for (var i = 0; i < queryCompareList.Count; i++)
            {
                if (i == 0 || queryCompareList[i].StartMark == ConstMgr.StartMarkT ||
                    queryCompareList[i - 1].EndMark.StartsWith(ConstMgr.EndMarkT))
                {
                    var newGroup = new List<DataFilter.QueryConditionInputItem>();
                    conditiongrpList.Add(newGroup);
                    currGrp = newGroup;
                    currGrp.Add(queryCompareList[i]);
                }
                else
                {
                    if (currGrp != null) currGrp.Add(queryCompareList[i]);
                }
            }
            //
            IMongoQuery rtnQuery = null;
            if (conditiongrpList.Count == 1)
            {
                return GetGroupQuery(conditiongrpList[0]);
            }
            for (var i = 0; i < conditiongrpList.Count - 1; i++)
            {
                var joinMark = conditiongrpList[i][conditiongrpList[i].Count() - 1].EndMark;
                if (joinMark == ConstMgr.EndMarkAndT || joinMark == ConstMgr.EndMarkAnd)
                {
                    rtnQuery =
                        Query.And(i == 0
                            ? new[] { GetGroupQuery(conditiongrpList[i]), GetGroupQuery(conditiongrpList[i + 1]) }
                            : new[] { rtnQuery, GetGroupQuery(conditiongrpList[i + 1]) });
                }

                if (joinMark == ConstMgr.EndMarkOrT || joinMark == ConstMgr.EndMarkOr)
                {
                    rtnQuery =
                        Query.Or(i == 0
                            ? new[] { GetGroupQuery(conditiongrpList[i]), GetGroupQuery(conditiongrpList[i + 1]) }
                            : new[] { rtnQuery, GetGroupQuery(conditiongrpList[i + 1]) });
                }
            }
            return rtnQuery;
        }

        /// <summary>
        ///     获得条件
        /// </summary>
        /// <param name="conditionGroup"></param>
        /// <returns></returns>
        private static IMongoQuery GetGroupQuery(List<DataFilter.QueryConditionInputItem> conditionGroup)
        {
            var rtnQuery = Query.Or(GetQuery(conditionGroup[0]));
            for (var i = 1; i < conditionGroup.Count; i++)
            {
                if (conditionGroup[i - 1].EndMark == ConstMgr.EndMarkAnd)
                {
                    rtnQuery = Query.And(rtnQuery, GetQuery(conditionGroup[i]));
                }
                if (conditionGroup[i - 1].EndMark == ConstMgr.EndMarkOr)
                {
                    rtnQuery = Query.Or(rtnQuery, GetQuery(conditionGroup[i]));
                }
            }
            return rtnQuery;
        }

        /// <summary>
        ///     获得查询
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static IMongoQuery GetQuery(DataFilter.QueryConditionInputItem item)
        {
            IMongoQuery query;
            var queryvalue = item.Value.GetBsonValue();
            switch (item.Compare)
            {
                case DataFilter.CompareEnum.Eq:
                    query = Query.EQ(item.ColName, queryvalue);
                    break;
                case DataFilter.CompareEnum.Gt:
                    query = Query.GT(item.ColName, queryvalue);
                    break;
                case DataFilter.CompareEnum.Gte:
                    query = Query.GTE(item.ColName, queryvalue);
                    break;
                case DataFilter.CompareEnum.Lt:
                    query = Query.LT(item.ColName, queryvalue);
                    break;
                case DataFilter.CompareEnum.Lte:
                    query = Query.LTE(item.ColName, queryvalue);
                    break;
                case DataFilter.CompareEnum.Ne:
                    query = Query.NE(item.ColName, queryvalue);
                    break;
                default:
                    query = Query.EQ(item.ColName, queryvalue);
                    break;
            }
            return query;
        }

        /// <summary>
        ///     全文检索
        /// </summary>
        /// <param name="key"></param>
        /// <param name="caseSensitive"></param>
        /// <param name="diacriticSensitive"></param>
        /// <param name="limit"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static List<BsonDocument> SearchText(string key, bool caseSensitive, bool diacriticSensitive, int limit,
            string language = "")
        {
            //检索文法： 
            //[Before2.6]http://docs.mongodb.org/manual/reference/command/text/#text-search-languages
            //[After 2.6]http://docs.mongodb.org/manual/reference/operator/query/text/#op._S_text
            //[From  3.2]https://docs.mongodb.org/master/reference/operator/query/text/
            //{
            //  $text:
            //    {
            //      $search: < string >,
            //      $language: < string >,
            //      $caseSensitive: < boolean >,
            //      $diacriticSensitive: < boolean >
            //    }
            //}
            //检索关键字
            var textSearchOption = new TextSearchOptions()
            {
                CaseSensitive = caseSensitive,
                DiacriticSensitive = diacriticSensitive
            };
            //语言
            if (string.IsNullOrEmpty(language))
            {
                textSearchOption.Language = language;
            }
            var textSearchQuery = Query.Text(key, textSearchOption);
            var result = RuntimeMongoDbContext.GetCurrentCollection().FindAs<BsonDocument>(textSearchQuery);
            var resultDocumentList = result.SetLimit(limit).ToList();
            return resultDocumentList;
        }

        /// <summary>
        ///     Is Exist by Key
        /// </summary>
        /// <param name="keyValue">KeyValue</param>
        /// <returns></returns>
        public static bool IsExistByKey(string keyValue)
        {
            var mongoCol = MongoHelper.GetCurrentJsCollection(RuntimeMongoDbContext.GetCurrentDataBase());
            return mongoCol.FindAs<BsonDocument>(Query.EQ(ConstMgr.KeyId, keyValue)).Any();
        }
    }
}