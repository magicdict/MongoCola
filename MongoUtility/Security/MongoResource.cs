using MongoDB.Bson;

namespace MongoUtility.Security
{
    /// <summary>
    ///     资源
    /// </summary>
    /// <see cref="http://docs.mongodb.org/manual/reference/resource-document/#resource-document" />
    public class MongoResource
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
        public BsonElement GetBsonDoc()
        {
            BsonDocument ResourceContent = null;
            switch (Type)
            {
                case ResourceType.DataBase:
                    ResourceContent = new BsonDocument("db", DataBaseName)
                    {
                        { "collection", CollectionName }
                    };
                    break;
                case ResourceType.Cluster:
                    ResourceContent = new BsonDocument("cluster", BsonBoolean.True);
                    break;
                case ResourceType.Any:
                    ResourceContent = new BsonDocument("anyResource",BsonBoolean.True);
                    break;
            }
            BsonElement Resource = new BsonElement("resource", ResourceContent);
            return Resource;
        }
    }
}