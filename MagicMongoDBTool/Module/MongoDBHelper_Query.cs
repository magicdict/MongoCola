using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelpler
    {
        /// <summary>
        /// 比较符号
        /// </summary>
        public enum CompareEnum
        {
            /// <summary>
            /// 等于
            /// </summary>
            EQ,
            /// <summary>
            /// 大于
            /// </summary>
            GT,
            /// <summary>
            /// 大于等于
            /// </summary>
            GTE,
            /// <summary>
            /// 小于
            /// </summary>
            LT,
            /// <summary>
            /// 小于等于
            /// </summary>
            LTE,
            /// <summary>
            /// 不等于
            /// </summary>
            NE

        }
        /// <summary>
        /// 排序类型
        /// </summary>
        public enum SortType
        {
            /// <summary>
            /// 不排序
            /// </summary>
            NoSort,
            /// <summary>
            /// 升序
            /// </summary>
            Ascending,
            /// <summary>
            /// 降序
            /// </summary>
            Descending
        }
        /// <summary>
        /// 字段信息
        /// </summary>
        public struct QueryFieldItem
        {
            /// <summary>
            /// 字段名称
            /// </summary>
            public string ColName;
            /// <summary>
            /// 是否表示
            /// </summary>
            public bool IsShow;
            /// <summary>
            /// 排序类型
            /// </summary>
            public SortType sortType;
        }
        /// <summary>
        /// 清除过滤器
        /// </summary>
        public static void ClearFilter()
        {
            MongoDBHelpler.SkipCnt = 0;
            QueryFieldList.Clear();
            QueryCompareList.Clear();
        }
        /// <summary>
        /// 是否使用过滤器
        /// </summary>
        public static bool IsUseFilter = false;
        /// <summary>
        /// 输出项目配置
        /// </summary>
        public static List<QueryFieldItem> QueryFieldList = new List<QueryFieldItem>();
        /// <summary>
        /// 获得输出字段名称
        /// </summary>
        /// <returns></returns>
        public static String[] GetOutputFields()
        {
            List<String> outputFieldLst = new List<string>();
            foreach (var item in QueryFieldList)
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
        public static SortByBuilder GetSort()
        {
            var sort = new SortByBuilder();
            List<string> ascendingList = new List<string>();
            List<string> descendingList = new List<string>();
            //_id将以文字的形式排序，所以不要排序_id!!
            foreach (var item in QueryFieldList)
            {
                switch (item.sortType)
                {
                    case SortType.NoSort:
                        break;
                    case SortType.Ascending:
                        ascendingList.Add(item.ColName);
                        break;
                    case SortType.Descending:
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
        /// 比较条件[输入]
        /// </summary>
        public struct QueryConditionInputItem
        {
            public string StartMark;
            public string ColName;
            public CompareEnum Comp;
            public string Value;
            public BsonType Type;
            public string EndMark;
        }
        /// <summary>
        /// 输出条件配置
        /// </summary>
        public static List<QueryConditionInputItem> QueryCompareList = new List<QueryConditionInputItem>();
        /// <summary>
        /// 检索过滤器
        /// </summary>
        /// <returns></returns>
        public static IMongoQuery GetQuery()
        {
            //遍历所有条件，分组
            List<List<QueryConditionInputItem>> conditiongrpList = new List<List<QueryConditionInputItem>>();
            List<QueryConditionInputItem> currGrp = null;
            for (int i = 0; i < QueryCompareList.Count; i++)
            {
                if (i == 0 || QueryCompareList[i].StartMark == "(" || QueryCompareList[i - 1].EndMark.StartsWith(")"))
                {
                    List<QueryConditionInputItem> newGroup = new List<QueryConditionInputItem>();
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
                if (joinMark == ") AND ")
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

                if (joinMark == ") OR ")
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
        private static IMongoQuery GetGroupQuery(List<QueryConditionInputItem> conditionGroup)
        {
            List<QueryConditionInputItem> orGrp = new List<QueryConditionInputItem>();
            List<QueryConditionInputItem> andGrp = new List<QueryConditionInputItem>();
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
                    if (conditionGroup[i - 1].EndMark == " AND ")
                    {
                        andGrp.Add(conditionGroup[i]);
                    }
                    if (conditionGroup[i - 1].EndMark == " OR ")
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
        private static IMongoQuery GetGroup(List<QueryConditionInputItem> oprGrp, string strOPR)
        {
            List<IMongoQuery> queryLst = new List<IMongoQuery>();
            foreach (var item in oprGrp)
            {
                IMongoQuery query;
                BsonValue queryvalue;
                switch (item.Type)
                {
                    case BsonType.Boolean:
                        queryvalue = (BsonBoolean)item.Value;
                        break;
                    case BsonType.DateTime:
                        queryvalue = (BsonDateTime)item.Value;
                        break;
                    case BsonType.Int32:
                        queryvalue = (BsonInt32)Convert.ToInt32(item.Value);
                        break;
                    case BsonType.String:
                        queryvalue = (BsonString)item.Value;
                        break;
                    default:
                        queryvalue = (BsonString)item.Value;
                        break;
                }
                switch (item.Comp)
                {
                    case CompareEnum.EQ:
                        query = Query.EQ(item.ColName, queryvalue);
                        break;
                    case CompareEnum.GT:
                        query = Query.GT(item.ColName, queryvalue);
                        break;
                    case CompareEnum.GTE:
                        query = Query.GTE(item.ColName, queryvalue);
                        break;
                    case CompareEnum.LT:
                        query = Query.LT(item.ColName, queryvalue);
                        break;
                    case CompareEnum.LTE:
                        query = Query.LTE(item.ColName, queryvalue);
                        break;
                    case CompareEnum.NE:
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

