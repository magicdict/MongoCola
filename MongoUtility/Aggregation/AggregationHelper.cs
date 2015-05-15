using MongoDB.Bson;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using System;
using System.Collections.Generic;
namespace MongoUtility.Aggregation
{
    public static class AggregationHelper
    {

        public static string Distinct(string strKey, List<DataFilter.QueryConditionInputItem> DistinctConditionList)
        {
            var strResult = string.Empty;
            var resultArray =
                (BsonArray)
                    RuntimeMongoDbContext.GetCurrentCollection()
                        .Distinct(strKey, QueryHelper.GetQuery(DistinctConditionList));
            var resultList = new List<BsonValue>();
            foreach (var item in resultArray)
            {
                resultList.Add(item);
            }
            resultList.Sort();
            //防止错误的条件造成的海量数据
            var count = 0;
            foreach (var item in resultList)
            {
                if (count == 1000)
                {
                    strResult = "Too many result,Display first 1000 records" + Environment.NewLine + strResult;
                    break;
                }
                strResult += item.ToJson(MongoHelper.JsonWriterSettings) + Environment.NewLine;
                count++;
            }
            strResult = "Distinct Count: " + resultList.Count + Environment.NewLine + Environment.NewLine + strResult;
            return strResult;
        }

        /// <summary>
        ///     group aggregation function
        /// </summary>
        /// <returns></returns>
        public static string[] GetGroupfunction()
        {
            return new[]
            {
                "$addToSet",
                "$first",
                "$last",
                "$max",
                "$min",
                "$avg",
                "$push",
                "$sum"
            };
        }

        /// <summary>
        ///     group aggregation function
        /// </summary>
        /// <returns></returns>
        public static string[] GetComparisonfunction()
        {
            return new[]
            {
                "$all",
                "$gt",
                "$gte",
                "$in",
                "$lt",
                "$lte",
                "$ne",
                "$nin"
            };
        }
    }
}