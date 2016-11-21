using MongoDB.Bson;

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
        ///     获得BsonDocument
        /// </summary>
        /// <returns></returns>
        public BsonDocument GetBsonDoc()
        {
            BsonDocument ResourceContent = null;
            switch (Type)
            {
                case ResourceType.DataBase:
                    ResourceContent = new BsonDocument("db", DataBaseName);
                    ResourceContent = new BsonDocument("collection", CollectionName);
                    break;
                case ResourceType.Cluster:
                    ResourceContent = new BsonDocument("cluster", BsonBoolean.True);
                    break;
                case ResourceType.Any:
                    ResourceContent = new BsonDocument("anyResource",BsonBoolean.True);
                    break;
            }
            BsonDocument Resource = new BsonDocument("resource", ResourceContent);
            return Resource;
        }

        /// <summary>
        ///     获得资源的JsCode形式
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