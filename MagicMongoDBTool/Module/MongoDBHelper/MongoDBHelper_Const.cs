
using System;
namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        //各种节点的Tag前缀

        /// <summary>
        /// 普通连接
        /// </summary>
        public const String CONNECTION_TAG = "MongoConnection";
        /// <summary>
        /// Sharding连接
        /// </summary>
        public const String CONNECTION_SHARDING_TAG = "MongoShardingConnection";
        /// <summary>
        /// Replset连接
        /// </summary>
        public const String CONNECTION_REPLSET_TAG = "MongoReplsetConnection";
        /// <summary>
        /// 异常
        /// </summary>
        public const String CONNECTION_EXCEPTION_TAG = "MongoConnectionWithException";
        /// <summary>
        /// 普通服务器Tag
        /// </summary>
        public const String SERVICE_TAG = "MongoService";
        /// <summary>
        /// 该服务器只允许操作其下的某个数据库
        /// </summary>
        public const String SINGLE_DB_SERVICE_TAG = "MongoSingleDBService";
        /// <summary>
        /// 数据库
        /// </summary>
        public const String DATABASE_TAG = "MongoDatabase";
        /// <summary>
        /// 单数据库模式的数据库
        /// </summary>
        public const String SINGLE_DATABASE_TAG = "SingleMongoDatabase";
        /// <summary>
        /// 数据集
        /// </summary>
        public const String COLLECTION_TAG = "MongoCollection";
        /// <summary>
        /// 数据集
        /// </summary>
        public const String COLLECTION_LIST_TAG = "MongoCollectionList";
        /// <summary>
        /// 数据集
        /// </summary>
        public const String SYSTEM_COLLECTION_LIST_TAG = "MongoSystemCollectionList";
        /// <summary>
        /// BSonDoc
        /// </summary>
        public const String DOCUMENT_TAG = "MongoDocument";
        /// <summary>
        /// JavaScript
        /// </summary>
        public const String JAVASCRIPT_TAG = "MongoJavascript";
        /// <summary>
        /// JavaScriptDoc
        /// </summary>
        public const String JAVASCRIPT_DOC_TAG = "MongoJavascriptDocument";
        /// <summary>
        /// GFS
        /// </summary>
        public const String GRID_FILE_SYSTEM_TAG = "MongoGFS";
        /// <summary>
        /// 用户列表
        /// </summary>
        public const String USER_LIST_TAG = "MongoUserList";
        /// <summary>
        /// 用户
        /// </summary>
        public const String USER_TAG = "MongoUser";
        /// <summary>
        /// 索引集
        /// </summary>
        public const String INDEXES_TAG = "MongoIndexes";
        /// <summary>
        /// 索引
        /// </summary>
        public const String INDEX_TAG = "MongoIndex";

        /// <summary>
        /// 
        /// </summary>
        public const String CONFIG_DBNAME_TAG = "config";
        /// <summary>
        /// 路径阶层[考虑到以后可能阶层会变换]
        /// </summary>
        public enum PathLv : int
        {
            /// <summary>
            /// 连接
            /// </summary>
            ConnectionLV =0,
            /// <summary>
            /// 服务器
            /// </summary>
            ServerLV = 1,
            /// <summary>
            /// 数据库
            /// </summary>
            DatabaseLV = 2,
            /// <summary>
            /// 数据集
            /// </summary>
            CollectionLV = 3
        }

        #region"系统数据集名称常量"
        /// <summary>
        /// Default Port
        /// </summary>
        public const int DEFAULT_PORT = 27017;
        /// <summary>
        /// ADMIN
        /// </summary>
        public const String DATABASE_NAME_ADMIN = "admin";
        /// <summary>
        /// ADMIN
        /// </summary>
        public const String DATABASE_NAME_LOCAL = "local";
        /// <summary>
        /// 系统索引
        /// </summary>
        public const String COLLECTION_NAME_SYSTEM_INDEXES = "system.indexes";
        /// <summary>
        /// 系统副本
        /// </summary>
        public const String COLLECTION_NAME_SYSTEM_REPLSET = "system.replset";
        /// <summary>
        /// 系统副本
        /// </summary>
        public const String COLLECTION_NAME_SYSTEM_PROFILE = "system.profile";
        /// <summary>
        /// minvalid数据集名称
        /// </summary>
        public const String COLLECTION_NAME_REPLSET_MINVALID = "replset.minvalid";
        /// <summary>
        /// 操作日志数据集名称
        /// </summary>
        public const String COLLECTION_NAME_OPERATION_LOG = "oplog.rs";
        /// <summary>
        /// GFS块数据集名称
        /// </summary>
        public const String COLLECTION_NAME_GFS_CHUNKS = "fs.chunks";
        /// <summary>
        /// GFS数据集名称
        /// </summary>
        public const String COLLECTION_NAME_GFS_FILES = "fs.files";
        /// <summary>
        /// 用户数据集名称
        /// </summary>
        public const String COLLECTION_NAME_USER = "system.users";
        /// <summary>
        /// Js数据集名称
        /// </summary>
        public const String COLLECTION_NAME_JAVASCRIPT = "system.js";
        #endregion

        /// <summary>
        /// 查询条件构成控件用常量
        /// </summary>
        public const String EndMark_AND = " AND ";
        public const String EndMark_OR = " OR ";
        public const String EndMark_AND_T = ") AND ";
        public const String EndMark_OR_T = ") OR ";
        public const String EndMark_T = ")";

        /// <summary>
        /// 在标识元素路径时候，这个后缀表示当期元素只是数组的开始标志
        /// </summary>
        public const String Array_Mark = "[ARRAY]";
        public const String Document_Mark = "[DOCUMENT]";
        /// <summary>
        /// XML文件选择过滤器
        /// </summary>
        public const String XmlFilter = "*.xml(Xml File)|*.xml";
        /// <summary>
        /// Txt文件选择过滤器
        /// </summary>
        public const String TxtFilter = "*.txt(Plan File)|*.txt";
        /// <summary>
        /// LOG文件选择过滤器
        /// </summary>
        public const String LogFilter = "*.log(Log File)|*.log";
        /// <summary>
        /// MDB文件选择过滤器
        /// </summary>
        public const String MdbFilter = "*.mdb(Access File)|*.mdb";

        /// <summary>
        /// TempFileFolder
        /// </summary>
        public const String TempFileFolder = "TempFile";
    }
}
