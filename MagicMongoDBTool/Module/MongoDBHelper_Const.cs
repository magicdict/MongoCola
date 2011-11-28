
using System;
namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
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
        /// <summary>
        /// 数据库
        /// </summary>
        public const string DATABASE_TAG = "MongoDatabase";
        /// <summary>
        /// 单数据库模式的数据库
        /// </summary>
        public const string SINGLE_DATABASE_TAG = "SingleMongoDatabase";
        /// <summary>
        /// 数据集
        /// </summary>
        public const string COLLECTION_TAG = "MongoCollection";
        /// <summary>
        /// BSonDoc
        /// </summary>
        public const string DOCUMENT_TAG = "MongoDocument";
        /// <summary>
        /// GFS
        /// </summary>
        public const string GRID_FILE_SYSTEM_TAG = "MongoGFS";
        /// <summary>
        /// 用户列表
        /// </summary>
        public const string USER_LIST_TAG = "MongoUserList";
        /// <summary>
        /// 用户
        /// </summary>
        public const string USER_TAG = "MongoUser";
        /// <summary>
        /// 索引集
        /// </summary>
        public const string INDEXES_TAG = "MongoIndexes";
        /// <summary>
        /// 索引
        /// </summary>
        public const string INDEX_TAG = "MongoIndex";
        /// <summary>
        /// 路径阶层[考虑到以后可能阶层会变换]
        /// </summary>
        enum PathLv : int
        {
            /// <summary>
            /// 服务器
            /// </summary>
            ServerLV = 0,
            /// <summary>
            /// 数据库
            /// </summary>
            DatabaseLV = 1,
            /// <summary>
            /// 数据集
            /// </summary>
            CollectionLV = 2
        }

        #region"系统数据集名称常量"
        /// <summary>
        /// ADMIN
        /// </summary>
        public const string DATABASE_NAME_ADMIN = "admin";
        /// <summary>
        /// 系统索引
        /// </summary>
        public const string COLLECTION_NAME_SYSTEM_INDEXES = "system.indexes";
        /// <summary>
        /// 系统副本
        /// </summary>
        public const string COLLECTION_NAME_SYSTEM_REPLSET = "system.replset";
        /// <summary>
        /// minvalid
        /// </summary>
        public const string COLLECTION_NAME_REPLSET_MINVALID = "replset.minvalid";
        /// <summary>
        /// 操作日志
        /// </summary>
        public const string COLLECTION_NAME_OPERATION_LOG = "oplog.rs";
        /// <summary>
        /// GFS的块
        /// </summary>
        public const string COLLECTION_NAME_GFS_CHUNKS = "fs.chunks";
        /// <summary>
        /// GFS
        /// </summary>
        public const string COLLECTION_NAME_GFS_FILES = "fs.files";
        /// <summary>
        /// 用户
        /// </summary>
        public const string COLLECTION_NAME_USER = "system.users";
        /// <summary>
        /// Js
        /// </summary>
        public const string COLLECTION_NAME_JAVASCRIPT = "system.js";
        #endregion


            public const String EndMark_AND = " AND ";
            public const String EndMark_OR = " OR ";
            public const String EndMark_AND_T = ") AND ";
            public const String EndMark_OR_T = ") OR ";
            public const String EndMark_T = ")";

    }
}
