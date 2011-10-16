using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public struct QueryCompareItem
        {
            public CompareEnum comp;
            public String Value;
            public BsonType type;
        }
        public struct QueryFieldItem
        {
            public String ColName;
            public Boolean IsShow;
            public Boolean IsSort;
            public List<QueryCompareItem> QueryList;
        }
        public static List<QueryFieldItem> QueryFieldList = new List<QueryFieldItem>();

        public static IMongoQuery GetQuery()
        {
            List<IMongoQuery> querylst = new List<IMongoQuery>();
            foreach (var field in QueryFieldList)
            {
                foreach (var item in field.QueryList)
                {
                    IMongoQuery query;
                    BsonValue queryvalue;
                    switch (item.type)
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
                    switch (item.comp)
                    {
                        case CompareEnum.EQ:
                            query = Query.EQ(field.ColName, queryvalue);
                            break;
                        case CompareEnum.GT:
                            query = Query.GT(field.ColName, queryvalue);
                            break;
                        case CompareEnum.GTE:
                            query = Query.GTE(field.ColName, queryvalue);
                            break;
                        case CompareEnum.LT:
                            query = Query.LT(field.ColName, queryvalue);
                            break;
                        case CompareEnum.LTE:
                            query = Query.LTE(field.ColName, queryvalue);
                            break;
                        case CompareEnum.NE:
                            query = Query.NE(field.ColName, queryvalue);
                            break;
                        default:
                            query = Query.EQ(field.ColName, queryvalue);
                            break;
                    }
                    querylst.Add(query);
                }

            }
            return Query.Or(querylst.ToArray());
        }
    }
}

