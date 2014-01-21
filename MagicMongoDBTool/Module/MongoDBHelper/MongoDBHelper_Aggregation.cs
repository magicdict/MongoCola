namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        /// <summary>
        ///     group aggregation function
        /// </summary>
        /// <returns></returns>
        public static string[] getGroupfunction()
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
        public static string[] getComparisonfunction()
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