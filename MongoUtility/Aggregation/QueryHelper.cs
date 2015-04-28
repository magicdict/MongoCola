using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoUtility.Basic;

namespace MongoUtility.Aggregation
{
    public static class QueryHelper
    {
        /// <summary>
        ///     �������ֶ�����
        /// </summary>
        /// <returns></returns>
        public static string[] GetOutputFields(List<DataFilter.QueryFieldItem> FieldItemLst)
        {
            var outputFieldLst = new List<string>();
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
        ///     �������
        /// </summary>
        /// <returns></returns>
        public static SortByBuilder GetSort(List<DataFilter.QueryFieldItem> FieldItemLst)
        {
            var sort = new SortByBuilder();
            var ascendingList = new List<string>();
            var descendingList = new List<string>();
            //_id�������ֵ���ʽ�������Բ�Ҫ����_id!!
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
        ///     ����������
        /// </summary>
        /// <returns></returns>
        public static IMongoQuery GetQuery(List<DataFilter.QueryConditionInputItem> QueryCompareList)
        {
            //������������������
            var conditiongrpList = new List<List<DataFilter.QueryConditionInputItem>>();
            List<DataFilter.QueryConditionInputItem> currGrp = null;
            for (var i = 0; i < QueryCompareList.Count; i++)
            {
                if (i == 0 || QueryCompareList[i].StartMark == ConstMgr.StartMark_T ||
                              QueryCompareList[i - 1].EndMark.StartsWith(ConstMgr.EndMark_T))
                {
                    var newGroup = new List<DataFilter.QueryConditionInputItem>();
                    conditiongrpList.Add(newGroup);
                    currGrp = newGroup;
                    currGrp.Add(QueryCompareList[i]);
                }
                else
                {
                    currGrp.Add(QueryCompareList[i]);
                }
            }
            //��ÿ�������ܽ�Ϊ1��IMongoQuery��1�����ӷ���
            IMongoQuery rtnQuery = null;
            if (conditiongrpList.Count == 1)
            {
                return GetGroupQuery(conditiongrpList[0]);
            }
            for (var i = 0; i < conditiongrpList.Count - 1; i++)
            {
                var joinMark = conditiongrpList[i][conditiongrpList[i].Count() - 1].EndMark;
                if (joinMark == ConstMgr.EndMark_AND_T)
                {
                    rtnQuery =
                        Query.And(i == 0
                            ? new[] {GetGroupQuery(conditiongrpList[i]), GetGroupQuery(conditiongrpList[i + 1])}
                            : new[] {rtnQuery, GetGroupQuery(conditiongrpList[i + 1])});
                }

                if (joinMark == ConstMgr.EndMark_OR_T)
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
        ///     ��ÿ������ϲ�Ϊһ��IMongoQuery
        /// </summary>
        /// <param name="conditionGroup"></param>
        /// <returns></returns>
        private static IMongoQuery GetGroupQuery(List<DataFilter.QueryConditionInputItem> conditionGroup)
        {
            var rtnQuery = Query.Or(GetQuery(conditionGroup[0]));
            for (var i = 1; i < conditionGroup.Count; i++)
            {
                if (conditionGroup[i - 1].EndMark == ConstMgr.EndMark_AND)
                {
                    rtnQuery = Query.And(rtnQuery, GetQuery(conditionGroup[i]));
                }
                if (conditionGroup[i - 1].EndMark == ConstMgr.EndMark_OR)
                {
                    rtnQuery = Query.Or(rtnQuery, GetQuery(conditionGroup[i]));
                }
            }
            return rtnQuery;
        }

        /// <summary>
        ///     ��And��Or����������������ת��Ϊһ��IMongoQuery
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static IMongoQuery GetQuery(DataFilter.QueryConditionInputItem item)
        {
            IMongoQuery query;
            var queryvalue = item.Value.GetBsonValue();
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
            return query;
        }

        /// <summary>
        ///     Is Exist by Key
        /// </summary>
        /// <param name="mongoCol">Collection</param>
        /// <param name="KeyValue">KeyValue</param>
        /// <returns></returns>
        public static bool IsExistByKey(MongoCollection mongoCol, BsonValue KeyValue)
        {
            return mongoCol.FindAs<BsonDocument>(Query.EQ(ConstMgr.KEY_ID, KeyValue)).Count() > 0;
        }
    }
}