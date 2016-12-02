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
        ///     数据集列表
        /// </summary>
        public const string CollectionListTag = "MongoCollectionList";

        /// <summary>
        ///     视图列表
        /// </summary>
        public const string ViewListTag = "MongoViewList";

        /// <summary>
        ///     数据集
        /// </summary>
        public const string SystemCollectionListTag = "MongoSystemCollectionList";

        /// <summary>
        ///     文档
        /// </summary>
        public const string DocumentTag = "MongoDocument";

        /// <summary>
        ///     视图
        /// </summary>
        public const string ViewTag = "MongoView";

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
        ///     角色列表
        /// </summary>
        public const string RoleListTag = "MongoRoleList";

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
        /// <summary>
        ///     Web Mongod Default Port
        /// </summary>
        public const int WebMongodDefaultPort = 28017;
        /// <summary>
        ///     Shard Default Port
        /// </summary>
        public const int ShardDefaultPort = 27018;
        /// <summary>
        ///     Config Default Port
        /// </summary>
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
        ///     用户数据集名称
        /// </summary>
        public const string CollectionNameUsers = "system.users";

        /// <summary>
        ///     角色数据集名称
        /// </summary>
        public const string CollectionNameRoles = "system.roles";

        /// <summary>
        ///     Js数据集名称
        /// </summary>
        public const string CollectionNameJavascript = "system.js";

        /// <summary>
        ///     视图数据集名称
        /// </summary>
        public const string CollectionNameSystemViews = "system.views";

        /// <summary>
        ///     版本数据集名称
        /// </summary>
        public const string CollectionNameVersion = "system.version";


        /// <summary>
        ///     minvalid数据集名称
        /// </summary>
        public const string CollectionNameReplsetMinvalid = "replset.minvalid";

        /// <summary>
        ///     election数据集名称
        /// </summary>
        public const string CollectionNameReplsetElection = "replset.election";

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

        #endregion

        #region"其他"

        public const string CSharp = "C#";

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

        /// <summary>
        ///     SCRAM_SHA_1
        /// </summary>
        public const string SCRAM_SHA_1 = "SCRAM-SHA-1";
        /// <summary>
        ///     MONGODB_CR
        /// </summary>
        public const string MONGODB_CR = "MONGODB-CR";
        /// <summary>
        ///     MONGODB_X509
        /// </summary>
        public const string MONGODB_X509 = "MONGODB-X509";

        /// <summary>
        ///     LDAP
        /// </summary>
        public const string LDAP = "LDAP";

        /// <summary>
        ///     Kerberos
        /// </summary>
        public const string Kerberos = "Kerberos";

        #endregion
    }
}