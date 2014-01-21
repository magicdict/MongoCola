namespace MagicMongoDBTool.Module
{
    public static partial class MongoDbHelper
    {
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