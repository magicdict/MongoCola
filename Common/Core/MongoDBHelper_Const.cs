using System;

namespace MongoCola.Module
{
    public static partial class MongoDbHelper
    {

        /// <summary>
        ///     通用的ActionDone事件
        /// </summary>
        public static EventHandler<ActionDoneEventArgs> ActionDone;

        /// <summary>
        ///     OnActionDone
        /// </summary>
        /// <param name="e"></param>
        public static void OnActionDone(ActionDoneEventArgs e)
        {
            e.Raise(null, ref ActionDone);
        }

        #region"各种节点的Tag前缀"

        /// <summary>
        ///     普通连接
        /// </summary>
        public const String CONNECTION_TAG = "MongoConnection";

        /// <summary>
        ///     Sharding连接
        /// </summary>
        public const String CONNECTION_CLUSTER_TAG = "MongoClusterConnection";

        /// <summary>
        ///     Replset连接
        /// </summary>
        public const String CONNECTION_REPLSET_TAG = "MongoReplsetConnection";

        /// <summary>
        ///     异常
        /// </summary>
        public const String CONNECTION_EXCEPTION_TAG = "MongoConnectionWithException";

        /// <summary>
        ///     普通服务器Tag
        /// </summary>
        public const String SERVER_TAG = "MongoServer";

        /// <summary>
        ///     Replset Member
        /// </summary>
        public const String SERVER_REPLSET_MEMBER_TAG = "MongoReplsetMemberServer";

        /// <summary>
        ///     该服务器只允许操作其下的某个数据库
        /// </summary>
        public const String SINGLE_DB_SERVER_TAG = "MongoSingleDBServer";

        /// <summary>
        ///     数据库
        /// </summary>
        public const String DATABASE_TAG = "MongoDatabase";

        /// <summary>
        ///     单数据库模式的数据库
        /// </summary>
        public const String SINGLE_DATABASE_TAG = "SingleMongoDatabase";

        /// <summary>
        ///     数据集
        /// </summary>
        public const String COLLECTION_TAG = "MongoCollection";

        /// <summary>
        ///     数据集
        /// </summary>
        public const String COLLECTION_LIST_TAG = "MongoCollectionList";

        /// <summary>
        ///     数据集
        /// </summary>
        public const String SYSTEM_COLLECTION_LIST_TAG = "MongoSystemCollectionList";

        /// <summary>
        ///     BSonDoc
        /// </summary>
        public const String DOCUMENT_TAG = "MongoDocument";

        /// <summary>
        ///     JavaScript
        /// </summary>
        public const String JAVASCRIPT_TAG = "MongoJavascript";

        /// <summary>
        ///     JavaScriptDoc
        /// </summary>
        public const String JAVASCRIPT_DOC_TAG = "MongoJavascriptDocument";

        /// <summary>
        ///     GFS
        /// </summary>
        public const String GRID_FILE_SYSTEM_TAG = "MongoGFS";

        /// <summary>
        ///     用户列表
        /// </summary>
        public const String USER_LIST_TAG = "MongoUserList";

        /// <summary>
        ///     用户
        /// </summary>
        public const String USER_TAG = "MongoUser";

        /// <summary>
        ///     索引集
        /// </summary>
        public const String INDEXES_TAG = "MongoIndexes";

        /// <summary>
        ///     索引
        /// </summary>
        public const String INDEX_TAG = "MongoIndex";

        //The process field identifies which kind of MongoDB instance is running. Possible values are:mongos,mongod
        /// <summary>
        ///     MongoS
        /// </summary>
        public const String ServerStatus_PROCESS_MONGOS = "mongos";

        /// <summary>
        ///     MongoD
        /// </summary>
        public const String ServerStatus_PROCESS_MONGOD = "mongod";

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
        public const String KEY_ID = "_id";

        /// <summary>
        /// </summary>
        public const String DATABASE_NAME_CONFIG = "config";

        /// <summary>
        ///     ADMIN
        /// </summary>
        public const String DATABASE_NAME_ADMIN = "admin";

        /// <summary>
        ///     ADMIN
        /// </summary>
        public const String DATABASE_NAME_LOCAL = "local";

        /// <summary>
        ///     系统索引
        /// </summary>
        public const String COLLECTION_NAME_SYSTEM_INDEXES = "system.indexes";

        /// <summary>
        ///     系统副本
        /// </summary>
        public const String COLLECTION_NAME_SYSTEM_REPLSET = "system.replset";

        /// <summary>
        ///     系统副本
        /// </summary>
        public const String COLLECTION_NAME_SYSTEM_PROFILE = "system.profile";

        /// <summary>
        ///     minvalid数据集名称
        /// </summary>
        public const String COLLECTION_NAME_REPLSET_MINVALID = "replset.minvalid";

        /// <summary>
        ///     操作日志数据集名称
        /// </summary>
        public const String COLLECTION_NAME_OPERATION_LOG = "oplog.rs";

        /// <summary>
        ///     GFS块数据集名称
        /// </summary>
        public const String COLLECTION_NAME_GFS_CHUNKS = "fs.chunks";

        /// <summary>
        ///     GFS数据集名称
        /// </summary>
        public const String COLLECTION_NAME_GFS_FILES = "fs.files";

        /// <summary>
        ///     用户数据集名称
        /// </summary>
        public const String COLLECTION_NAME_USER = "system.users";

        /// <summary>
        ///     角色数据集名称
        /// </summary>
        public const String COLLECTION_NAME_ROLE = "system.roles";

        /// <summary>
        ///     Js数据集名称
        /// </summary>
        public const String COLLECTION_NAME_JAVASCRIPT = "system.js";

        #endregion

        #region"其他"

        /// <summary>
        ///     查询条件构成控件用常量
        /// </summary>
        public const String EndMark_AND = " AND ";

        public const String EndMark_OR = " OR ";
        public const String EndMark_AND_T = ") AND ";
        public const String EndMark_OR_T = ") OR ";
        public const String EndMark_T = ")";

        /// <summary>
        ///     在标识元素路径时候，这个后缀表示当期元素只是数组的开始标志
        /// </summary>
        public const String Array_Mark = "[ARRAY]";

        /// <summary>
        ///     在标识元素路径时候，这个后缀表示当期元素只是文档的开始标志
        /// </summary>
        public const String Document_Mark = "[DOCUMENT]";

        /// <summary>
        ///     Excel文件选择过滤器
        /// </summary>
        public const String ExcelFilter = "Excel File(*.xls)|*.xls|*.*(All Files)|*.*";

        /// <summary>
        ///     XML文件选择过滤器
        /// </summary>
        public const String XmlFilter = "Xml File(*.xml)|*.xml|*.*(All Files)|*.*";

        /// <summary>
        ///     Txt文件选择过滤器
        /// </summary>
        public const String TxtFilter = "Plan Text File(*.txt)|*.txt|*.*(All Files)|*.*";

        /// <summary>
        ///     js文件选择过滤器
        /// </summary>
        public const String JsFilter = "javascript File(*.js)|*.js|*.*(All Files)|*.*";

        /// <summary>
        ///     LOG文件选择过滤器
        /// </summary>
        public const String LogFilter = "Log File(*.log)|*.log|*.*(All Files)|*.*";

        /// <summary>
        ///     MDB文件选择过滤器
        /// </summary>
        public const String MdbFilter = "Access File(*.mdb)|*.mdb|*.*(All Files)|*.*";

        /// <summary>
        ///     Conf文件选择过滤器
        /// </summary>
        public const String ConfFilter = "Config File(*.conf)|*.conf|*.*(All Files)|*.*";

        /// <summary>
        ///     TempFileFolder
        /// </summary>
        public const String TempFileFolder = "TempFile";

        #endregion
    }
}