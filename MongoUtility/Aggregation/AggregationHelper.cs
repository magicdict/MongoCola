namespace MongoUtility.Aggregation
{
    public static class AggregationFunc
    {
        /// <summary>
        ///     PipelineStages
        /// </summary>
        /// <returns></returns>
        public static string[] PipelineStages()
        {
            return new[]{
                "$project",
                "$match",
                "$redact",
                "$limit",
                "$skip",
                "$unwind",
                "$group",
                "$sample",
                "$sort",
                "$geoNear",
                "$lookup",
                "$out",
                "$indexStats",
                "$sortByCount",
                "$addFields"
            };
        }

        /// <summary>
        ///     Group function
        ///     https://docs.mongodb.com/master/reference/operator/aggregation-group/
        /// </summary>
        /// <returns></returns>
        public static string[] GetGroupfunction()
        {
            return new[]
            {
                "$sum",
                "$avg",
                "$first",
                "$last",
                "$max",
                "$min",
                "$push",
                "$addToSet",
                "$stdDevPop",
                "$stdDevSamp"
            };
        }

        /// <summary>
        ///     Comparison function
        ///     https://docs.mongodb.com/master/reference/operator/aggregation-comparison/
        /// </summary>
        /// <returns></returns>
        public static string[] GetComparisonfunction()
        {
            return new[]
            {
                "$cmp",
                "$eq",
                "$gt",
                "$gte",
                "$lt",
                "$lte",
                "$ne"
            };
        }
    }
}