namespace MongoUtility.Basic
{
    public static class ConstMgr
    {
        #region"各种节点的Tag前缀"

        /// <summary>
        ///     普通连接
        /// </summary>
        public const string CONNECTION_TAG = "MongoConnection";

        /// <summary>
        ///     Sharding连接
        /// </summary>
        public const string CONNECTION_CLUSTER_TAG = "MongoClusterConnection";

        /// <summary>
        ///     Replset连接
        /// </summary>
        public const string CONNECTION_REPLSET_TAG = "MongoReplsetConnection";

        /// <summary>
        ///     异常
        /// </summary>
        public const string CONNECTION_EXCEPTION_TAG = "MongoConnectionWithException";

        /// <summary>
        ///     普通服务器Tag
        /// </summary>
        public const string SERVER_TAG = "MongoServer";

        /// <summary>
        ///     Replset Member
        /// </summary>
        public const string SERVER_REPLSET_MEMBER_TAG = "MongoReplsetMemberServer";

        /// <summary>
        ///     该服务器只允许操作其下的某个数据库
        /// </summary>
        public const string SINGLE_DB_SERVER_TAG = "MongoSingleDBServer";

        /// <summary>
        ///     数据库
        /// </summary>
        public const string DATABASE_TAG = "MongoDatabase";

        /// <summary>
        ///     单数据库模式的数据库
        /// </summary>
        public const string SINGLE_DATABASE_TAG = "SingleMongoDatabase";

        /// <summary>
        ///     数据集
        /// </summary>
        public const string COLLECTION_TAG = "MongoCollection";

        /// <summary>
        ///     数据集
        /// </summary>
        public const string COLLECTION_LIST_TAG = "MongoCollectionList";

        /// <summary>
        ///     数据集
        /// </summary>
        public const string SYSTEM_COLLECTION_LIST_TAG = "MongoSystemCollectionList";

        /// <summary>
        ///     BSonDoc
        /// </summary>
        public const string DOCUMENT_TAG = "MongoDocument";

        /// <summary>
        ///     JavaScript
        /// </summary>
        public const string JAVASCRIPT_TAG = "MongoJavascript";

        /// <summary>
        ///     JavaScriptDoc
        /// </summary>
        public const string JAVASCRIPT_DOC_TAG = "MongoJavascriptDocument";

        /// <summary>
        ///     GFS
        /// </summary>
        public const string GRID_FILE_SYSTEM_TAG = "MongoGFS";

        /// <summary>
        ///     用户列表
        /// </summary>
        public const string USER_LIST_TAG = "MongoUserList";

        /// <summary>
        ///     用户
        /// </summary>
        public const string USER_TAG = "MongoUser";

        /// <summary>
        ///     索引集
        /// </summary>
        public const string INDEXES_TAG = "MongoIndexes";

        /// <summary>
        ///     索引
        /// </summary>
        public const string INDEX_TAG = "MongoIndex";

        //The process field identifies which kind of MongoDB instance is running. Possible values are:mongos,mongod
        /// <summary>
        ///     MongoS
        /// </summary>
        public const string ServerStatus_PROCESS_MONGOS = "mongos";

        /// <summary>
        ///     MongoD
        /// </summary>
        public const string ServerStatus_PROCESS_MONGOD = "mongod";

        #endregion

        #region"系统数据集名称常量"

        /// <summary>
        ///     Default Port(Mongod)
        /// </summary>
        public const int MONGOD_DEFAULT_PORT = 27017;

        public const int WEB_MONGOD_DEFAULT_PORT = 28017;

        public const int SHARD_DEFAULT_PORT = 27018;

        public const int CONFIG_DEFAULT_PORT = 27019;

        /// <summary>
        ///     主键
        /// </summary>
        public const string KEY_ID = "_id";

        /// <summary>
        /// </summary>
        public const string DATABASE_NAME_CONFIG = "config";

        /// <summary>
        ///     ADMIN
        /// </summary>
        public const string DATABASE_NAME_ADMIN = "admin";

        /// <summary>
        ///     ADMIN
        /// </summary>
        public const string DATABASE_NAME_LOCAL = "local";

        /// <summary>
        ///     系统索引
        /// </summary>
        public const string COLLECTION_NAME_SYSTEM_INDEXES = "system.indexes";

        /// <summary>
        ///     系统副本
        /// </summary>
        public const string COLLECTION_NAME_SYSTEM_REPLSET = "system.replset";

        /// <summary>
        ///     系统副本
        /// </summary>
        public const string COLLECTION_NAME_SYSTEM_PROFILE = "system.profile";

        /// <summary>
        ///     minvalid数据集名称
        /// </summary>
        public const string COLLECTION_NAME_REPLSET_MINVALID = "replset.minvalid";

        /// <summary>
        ///     操作日志数据集名称
        /// </summary>
        public const string COLLECTION_NAME_OPERATION_LOG = "oplog.rs";

        /// <summary>
        ///     GFS块数据集名称
        /// </summary>
        public const string COLLECTION_NAME_GFS_CHUNKS = "fs.chunks";

        /// <summary>
        ///     GFS数据集名称
        /// </summary>
        public const string COLLECTION_NAME_GFS_FILES = "fs.files";

        /// <summary>
        ///     用户数据集名称
        /// </summary>
        public const string COLLECTION_NAME_USER = "system.users";

        /// <summary>
        ///     角色数据集名称
        /// </summary>
        public const string COLLECTION_NAME_ROLE = "system.roles";

        /// <summary>
        ///     Js数据集名称
        /// </summary>
        public const string COLLECTION_NAME_JAVASCRIPT = "system.js";

        #endregion

        #region"其他"

        /// <summary>
        ///     查询条件构成控件用常量
        /// </summary>
        public const string StartMark_T = "(";
        public const string EndMark_AND = " AND ";
        public const string EndMark_OR = " OR ";
        public const string EndMark_AND_T = ") AND ";
        public const string EndMark_OR_T = ") OR ";
        public const string EndMark_T = ")";

        /// <summary>
        ///     在标识元素路径时候，这个后缀表示当期元素只是数组的开始标志
        /// </summary>
        public const string Array_Mark = "[ARRAY]";

        /// <summary>
        ///     在标识元素路径时候，这个后缀表示当期元素只是文档的开始标志
        /// </summary>
        public const string Document_Mark = "[DOCUMENT]";

        #endregion
    }
}