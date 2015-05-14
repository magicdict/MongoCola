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
        /// </summary>
        /// <returns></returns>
        public static SortByBuilder GetSort(List<DataFilter.QueryFieldItem> fieldItemLst)
        {
            var sort = new SortByBuilder();
            var ascendingList = new List<string>();
            var descendingList = new List<string>();

            foreach (var item in fieldItemLst)
            {
                switch (item.SortType)
                {
                    case DataFilter.SortType.NoSort:
                        break;
                    case DataFilter.SortType.Ascending:
                        ascendingList.Add(item.ColName);
                        break;
                    case DataFilter.SortType.Descending:
                        descendingList.Add(item.ColName);
                        break;
                }
            }
            sort.Ascending(ascendingList.ToArray());
            sort.Descending(descendingList.ToArray());
            return sort;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static IMongoQuery GetQuery(List<DataFilter.QueryConditionInputItem> queryCompareList)
        {
            //
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
                if (joinMark == ConstMgr.EndMarkAndT)
                {
                    rtnQuery =
                        Query.And(i == 0
                            ? new[] {GetGroupQuery(conditiongrpList[i]), GetGroupQuery(conditiongrpList[i + 1])}
                            : new[] {rtnQuery, GetGroupQuery(conditiongrpList[i + 1])});
                }

                if (joinMark == ConstMgr.EndMarkOrT)
                {
                    rtnQuery =
                        Query.Or(i == 0
                            ? new[] {GetGroupQuery(conditiongrpList[i]), GetGroupQuery(conditiongrpList[i + 1])}
                            : new[] {rtnQuery, GetGroupQuery(conditiongrpList[i + 1])});
                }
            }
            return rtnQuery;
        }

        /// <summary>
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

        public static List<BsonDocument> SearchText(string key, int limit, string language = "")
        {
            //检索文法： 
            //[Before2.6]http://docs.mongodb.org/manual/reference/command/text/#text-search-languages
            //[After2.6]http://docs.mongodb.org/manual/reference/operator/query/text/#op._S_text
            //检索关键字
            IMongoQuery textSearchOption = null;
            //语言
            if (string.IsNullOrEmpty(language))
            {
                textSearchOption = Query.Text(key);
            }
            else
            {
                textSearchOption = Query.Text(key, language);
            }
            var result = RuntimeMongoDbContext.GetCurrentCollection().FindAs<BsonDocument>(textSearchOption);
            var resultDocumentList = result.SetLimit(limit).ToList();
            return resultDocumentList;
        }

        /// <summary>
        ///     Is Exist by Key
        /// </summary>
        /// <param name="mongoCol">Collection</param>
        /// <param name="keyValue">KeyValue</param>
        /// <returns></returns>
        public static bool IsExistByKey(string keyValue)
        {
            var mongoCol = MongoHelper.GetCurrentJsCollection(RuntimeMongoDbContext.GetCurrentDataBase());
            return mongoCol.FindAs<BsonDocument>(Query.EQ(ConstMgr.KeyId, keyValue)).Count() > 0;
        }
    }
}