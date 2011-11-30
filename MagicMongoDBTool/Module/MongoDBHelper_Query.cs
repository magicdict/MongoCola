using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
  
        /// <summary>
        /// 是否使用过滤器
        /// </summary>
        public static bool IsUseFilter = false;
        /// <summary>
        /// 获得输出字段名称
        /// </summary>
        /// <returns></returns>
        public static String[] GetOutputFields(List<DataFilter.QueryFieldItem> FieldItemLst)
        {
            List<String> outputFieldLst = new List<string>();
            foreach (var item in FieldItemLst)
            {
                if (item.IsShow)
                {
                    outputFieldLst.Add(item.ColName);
                }
            }
            return outputFieldLst.ToArray();
        }
        /// <summary>
        /// 获得排序
        /// </summary>
        /// <returns></returns>
        public static SortByBuilder GetSort(List<DataFilter.QueryFieldItem> FieldItemLst)
        {
            var sort = new SortByBuilder();
            List<string> ascendingList = new List<string>();
            List<string> descendingList = new List<string>();
            //_id将以文字的形式排序，所以不要排序_id!!
            foreach (var item in FieldItemLst)
            {
                switch (item.sortType)
                {
                    case DataFilter.SortType.NoSort:
                        break;
                    case DataFilter.SortType.Ascending:
                        ascendingList.Add(item.ColName);
                        break;
                    case DataFilter.SortType.Descending:
                        descendingList.Add(item.ColName);
                        break;
                    default:
                        break;
                }
            }
            sort.Ascending(ascendingList.ToArray());
            sort.Descending(descendingList.ToArray());
            return sort;
        }
        /// <summary>
        /// 检索过滤器
        /// </summary>
        /// <returns></returns>
        public static IMongoQuery GetQuery(List<DataFilter.QueryConditionInputItem> QueryCompareList)
        {
            //遍历所有条件，分组
            List<List<DataFilter.QueryConditionInputItem>> conditiongrpList = new List<List<DataFilter.QueryConditionInputItem>>();
            List<DataFilter.QueryConditionInputItem> currGrp = null;
            for (int i = 0; i < QueryCompareList.Count; i++)
            {
                if (i == 0 || QueryCompareList[i].StartMark == "(" || QueryCompareList[i - 1].EndMark.StartsWith(")"))
                {
                    List<DataFilter.QueryConditionInputItem> newGroup = new List<DataFilter.QueryConditionInputItem>();
                    conditiongrpList.Add(newGroup);
                    currGrp = newGroup;
                    currGrp.Add(QueryCompareList[i]);
                }
                else
                {
                    currGrp.Add(QueryCompareList[i]);
                }
            }
            //将每个分组总结为1个IMongoQuery和1个连接符号
            IMongoQuery rtnQuery = null;
            if (conditiongrpList.Count == 1)
            {
                return GetGroupQuery(conditiongrpList[0]);
            }
            for (int i = 0; i < conditiongrpList.Count - 1; i++)
            {
                string joinMark = conditiongrpList[i][conditiongrpList[i].Count() - 1].EndMark;
                if (joinMark == EndMark_AND_T)
                {
                    if (i == 0)
                    {
                        rtnQuery = Query.And(new IMongoQuery[] { GetGroupQuery(conditiongrpList[i]), GetGroupQuery(conditiongrpList[i + 1]) });
                    }
                    else
                    {
                        rtnQuery = Query.And(new IMongoQuery[] { rtnQuery, GetGroupQuery(conditiongrpList[i + 1]) });
                    }
                }

                if (joinMark == EndMark_OR_T)
                {
                    if (i == 0)
                    {
                        rtnQuery = Query.Or(new IMongoQuery[] { GetGroupQuery(conditiongrpList[i]), GetGroupQuery(conditiongrpList[i + 1]) });
                    }
                    else
                    {
                        rtnQuery = Query.Or(new IMongoQuery[] { rtnQuery, GetGroupQuery(conditiongrpList[i + 1]) });
                    }
                }
            }
            return rtnQuery;
        }
        /// <summary>
        /// 将每个分组合并为一个IMongoQuery
        /// </summary>
        /// <param name="conditionGroup"></param>
        /// <returns></returns>
        private static IMongoQuery GetGroupQuery(List<DataFilter.QueryConditionInputItem> conditionGroup)
        {
            List<DataFilter.QueryConditionInputItem> orGrp = new List<DataFilter.QueryConditionInputItem>();
            List<DataFilter.QueryConditionInputItem> andGrp = new List<DataFilter.QueryConditionInputItem>();
            for (int i = 0; i < conditionGroup.Count; i++)
            {
                if (i == 0)
                {
                    //第一条强制放入OrGroup
                    andGrp.Add(conditionGroup[i]);
                }
                else
                {
                    //第二条到最终条，参考上一条
                    if (conditionGroup[i - 1].EndMark == EndMark_AND)
                    {
                        andGrp.Add(conditionGroup[i]);
                    }
                    if (conditionGroup[i - 1].EndMark == EndMark_OR)
                    {
                        orGrp.Add(conditionGroup[i]);
                    }
                }
            }
            //将OR条件转化为一个IMongoQuery
            IMongoQuery orResult = GetGroup(orGrp, "OR");
            //将AND条件转化为一个IMongoQuery
            IMongoQuery andResult = GetGroup(andGrp, "AND");
            //将AND和OR条件合并
            return Query.And(new IMongoQuery[] { orResult, andResult });
        }
        /// <summary>
        /// 将And和Or组里面的最基本条件转化为一个IMongoQuery
        /// </summary>
        /// <param name="oprGrp"></param>
        /// <param name="strOPR"></param>
        /// <returns></returns>
        private static IMongoQuery GetGroup(List<DataFilter.QueryConditionInputItem> oprGrp, string strOPR)
        {
            List<IMongoQuery> queryLst = new List<IMongoQuery>();
            foreach (var item in oprGrp)
            {
                IMongoQuery query;
                BsonValue queryvalue = item.Value.GetBsonValue();
                switch (item.Compare)
                {
                    case DataFilter.CompareEnum.EQ:
                        query = Query.EQ(item.ColName, queryvalue);
                        break;
                    case DataFilter.CompareEnum.GT:
                        query = Query.GT(item.ColName, queryvalue);
                        break;
                    case DataFilter.CompareEnum.GTE:
                        query = Query.GTE(item.ColName, queryvalue);
                        break;
                    case DataFilter.CompareEnum.LT:
                        query = Query.LT(item.ColName, queryvalue);
                        break;
                    case DataFilter.CompareEnum.LTE:
                        query = Query.LTE(item.ColName, queryvalue);
                        break;
                    case DataFilter.CompareEnum.NE:
                        query = Query.NE(item.ColName, queryvalue);
                        break;
                    default:
                        query = Query.EQ(item.ColName, queryvalue);
                        break;
                }
                queryLst.Add(query);
            }
            if (strOPR == "OR")
            {
                return Query.Or(queryLst.ToArray());
            }
            else
            {
                return Query.And(queryLst.ToArray());
            }
        }
        /// <summary>
        /// 是否存在某个数据
        /// </summary>
        /// <param name="Field"></param>
        /// <param name="mongoCol"></param>
        /// <returns></returns>
        public static Boolean IsExistByField(MongoCollection mongoCol, BsonValue strKey, string Field = "_id")
        {
            return mongoCol.FindAs<BsonDocument>(Query.EQ(Field, strKey)).Count() > 0;
        }
    }
}

