namespace MongoUtility.Security
{
    /// <summary>
    ///     资源
    /// </summary>
    /// <see cref="http://docs.mongodb.org/manual/reference/resource-document/#resource-document" />
    public class Resource
    {
        /// <summary>
        ///     资源类型
        /// </summary>
        public enum ResourceType
        {
            /// <summary>
            ///     Database and/or Collection Resource
            /// </summary>
            DataBase,

            /// <summary>
            ///     Cluster Resource
            /// </summary>
            Cluster,

            /// <summary>
            ///     any Resource
            /// </summary>
            Any
        }

        /// <summary>
        ///     数据集名称
        /// </summary>
        public string CollectionName;

        /// <summary>
        ///     数据库名称
        /// </summary>
        public string DataBaseName;

        /// <summary>
        /// </summary>
        public ResourceType Type;

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public string GetJsCode()
        {
            var result = string.Empty;
            switch (Type)
            {
                case ResourceType.DataBase:
                    result = " resource: {  db: '" + DataBaseName + "', collection: '" + CollectionName + "' } ";
                    break;
                case ResourceType.Cluster:
                    result = " resource: { cluster : true } ";
                    break;
                case ResourceType.Any:
                    result = " resource: { anyResource: true } ";
                    break;
            }
            return result;
        }
    }
}