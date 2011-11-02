
namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelpler
    {
        //各种节点的Tag前缀
        /// <summary>
        /// 普通服务器Tag
        /// </summary>
        public const string SERVICE_TAG = "MongoService";
        /// <summary>
        /// 该服务器只允许操作其下的某个数据库
        /// </summary>
        public const string SINGLE_DB_SERVICE_TAG = "MongoSingleDBService";

        public const string DATABASE_TAG = "MongoDatabase";
        public const string SINGLE_DATABASE_TAG = "SingleMongoDatabase";


        public const string COLLECTION_TAG = "MongoCollection";
        public const string DOCUMENT_TAG = "MongoDocument";
        public const string GRID_FILE_SYSTEM_TAG = "MongoGFS";
        public const string USER_LIST_TAG = "MongoUserList";
        public const string USER_TAG = "MongoUser";


        /// <summary>
        /// 路径阶层[考虑到以后可能阶层会变换]
        /// </summary>
        enum PathLv : int
        {
            ServerLV = 0,
            DatabaseLV = 1,
            CollectionLV = 2
        }

        #region"系统数据集名称常量"
        public const string COLLECTION_NAME_SYSTEM_INDEXES = "system.indexes";
        public const string COLLECTION_NAME_SYSTEM_REPLSET = "system.replset";
        public const string COLLECTION_NAME_REPLSET_MINVALID = "replset.minvalid";
        public const string COLLECTION_NAME_OPERATION_LOG = "oplog.rs";
        public const string COLLECTION_NAME_GFS_CHUNKS = "fs.chunks";
        public const string COLLECTION_NAME_GFS_FILES = "fs.files";
        public const string COLLECTION_NAME_USER = "system.users";
        public const string COLLECTION_NAME_JAVASCRIPT = "system.js";
        #endregion
    }
}
