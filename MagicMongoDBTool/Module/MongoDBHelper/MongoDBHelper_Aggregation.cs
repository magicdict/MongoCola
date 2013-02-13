using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        /// <summary>
        /// group aggregation function
        /// </summary>
        /// <returns></returns>
        static public string[] getGroupfunction()
        {
            return new string[]{
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
        /// group aggregation function
        /// </summary>
        /// <returns></returns>
        static public string[] getComparisonfunction()
        {
            return new string[]{
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
