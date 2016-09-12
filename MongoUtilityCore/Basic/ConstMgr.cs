namespace MongoUtility.Basic
{
    public static class ConstMgr
    {
        #region"各种节点的Tag前缀"

        /// <summary>
        ///     普通连接
        /// </summary>
        public const string ConnectionTag = "MongoConnection";

        /// <summary>
        ///     Sharding连接
        /// </summary>
        public const string ConnectionClusterTag = "MongoClusterConnection";

        /// <summary>
        ///     Replset连接
        /// </summary>
        public const string ConnectionReplsetTag = "MongoReplsetConnection";

        /// <summary>
        ///     异常
        /// </summary>
        public const string ConnectionExceptionTag = "MongoConnectionWithException";

        /// <summary>
        ///     普通服务器Tag
        /// </summary>
        public const string ServerTag = "MongoServer";

        /// <summary>
        ///     Replset Member
        /// </summary>
        public const string ServerReplsetMemberTag = "MongoReplsetMemberServer";

        /// <summary>
        ///     该服务器只允许操作其下的某个数据库
        /// </summary>
        public const string SingleDbServerTag = "MongoSingleDBServer";

        /// <summary>
        ///     数据库
        /// </summary>
        public const string DatabaseTag = "MongoDatabase";

        /// <summary>
        ///     单数据库模式的数据库
        /// </summary>
        public const string SingleDatabaseTag = "SingleMongoDatabase";

        /// <summary>
        ///     数据集
        /// </summary>
        public const string CollectionTag = "MongoCollection";

        /// <summary>
        ///     数据集
        /// </summary>
        public const string CollectionListTag = "MongoCollectionList";

        /// <summary>
        ///     数据集
        /// </summary>
        public const string SystemCollectionListTag = "MongoSystemCollectionList";

        /// <summary>
        ///     BSonDoc
        /// </summary>
        public const string DocumentTag = "MongoDocument";

        /// <summary>
        ///     JavaScript
        /// </summary>
        public const string JavascriptTag = "MongoJavascript";

        /// <summary>
        ///     JavaScriptDoc
        /// </summary>
        public const string JavascriptDocTag = "MongoJavascriptDocument";

        /// <summary>
        ///     GFS
        /// </summary>
        public const string GridFileSystemTag = "MongoGFS";

        /// <summary>
        ///     用户列表
        /// </summary>
        public const string UserListTag = "MongoUserList";

        /// <summary>
        ///     用户
        /// </summary>
        public const string UserTag = "MongoUser";

        /// <summary>
        ///     索引集
        /// </summary>
        public const string IndexesTag = "MongoIndexes";

        /// <summary>
        ///     索引
        /// </summary>
        public const string IndexTag = "MongoIndex";

        //The process field identifies which kind of MongoDB instance is running. Possible values are:mongos,mongod
        /// <summary>
        ///     MongoS
        /// </summary>
        public const string ServerStatusProcessMongos = "mongos";

        /// <summary>
        ///     MongoD
        /// </summary>
        public const string ServerStatusProcessMongod = "mongod";

        #endregion

        #region"系统数据集名称常量"

        /// <summary>
        ///     Default Port(Mongod)
        /// </summary>
        public const int MongodDefaultPort = 27017;

        public const int WebMongodDefaultPort = 28017;

        public const int ShardDefaultPort = 27018;

        public const int ConfigDefaultPort = 27019;

        /// <summary>
        ///     主键
        /// </summary>
        public const string KeyId = "_id";

        /// <summary>
        /// </summary>
        public const string DatabaseNameConfig = "config";

        /// <summary>
        ///     ADMIN
        /// </summary>
        public const string DatabaseNameAdmin = "admin";

        /// <summary>
        ///     ADMIN
        /// </summary>
        public const string DatabaseNameLocal = "local";

        /// <summary>
        ///     系统索引
        /// </summary>
        public const string CollectionNameSystemIndexes = "system.indexes";

        /// <summary>
        ///     系统副本
        /// </summary>
        public const string CollectionNameSystemReplset = "system.replset";

        /// <summary>
        ///     系统副本
        /// </summary>
        public const string CollectionNameSystemProfile = "system.profile";

        /// <summary>
        ///     minvalid数据集名称
        /// </summary>
        public const string CollectionNameReplsetMinvalid = "replset.minvalid";

        /// <summary>
        ///     操作日志数据集名称
        /// </summary>
        public const string CollectionNameOperationLog = "oplog.rs";

        /// <summary>
        ///     GFS块数据集名称
        /// </summary>
        public const string CollectionNameGfsChunks = "fs.chunks";

        /// <summary>
        ///     GFS数据集名称
        /// </summary>
        public const string CollectionNameGfsFiles = "fs.files";

        /// <summary>
        ///     用户数据集名称
        /// </summary>
        public const string CollectionNameUser = "system.users";

        /// <summary>
        ///     角色数据集名称
        /// </summary>
        public const string CollectionNameRole = "system.roles";

        /// <summary>
        ///     Js数据集名称
        /// </summary>
        public const string CollectionNameJavascript = "system.js";

        #endregion

        #region"其他"

        /// <summary>
        ///     查询条件构成控件用常量
        /// </summary>
        public const string StartMarkT = "(";

        public const string EndMarkAnd = " AND ";
        public const string EndMarkOr = " OR ";
        public const string EndMarkAndT = ") AND ";
        public const string EndMarkOrT = ") OR ";
        public const string EndMarkT = ")";

        /// <summary>
        ///     在标识元素路径时候，这个后缀表示当期元素只是数组的开始标志
        /// </summary>
        public const string ArrayMark = "[ARRAY]";

        /// <summary>
        ///     在标识元素路径时候，这个后缀表示当期元素只是文档的开始标志
        /// </summary>
        public const string DocumentMark = "[DOCUMENT]";

        #endregion

        #region authentication mechanisms
        public const string SCRAM_SHA_1 = "SCRAM-SHA-1";
        public const string MONGODB_CR = "MONGODB-CR";
        public const string MONGODB_X509 = "MONGODB-X509";
        #endregion
    }
}