using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using System.Windows.Forms;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        #region"服务器管理"
        /// <summary>
        /// 管理中服务器列表
        /// </summary>
        public static Dictionary<string, MongoServer> _mongoSrvLst = new Dictionary<string, MongoServer>();
        /// <summary>
        /// 增加管理服务器
        /// </summary>
        /// <param name="configLst"></param>
        /// <returns></returns>
        public static void AddServer(List<ConfigHelper.MongoConnectionConfig> configLst)
        {
            foreach (ConfigHelper.MongoConnectionConfig config in configLst)
            {
                try
                {
                    if (_mongoSrvLst.ContainsKey(config.ConnectionName))
                    {
                        _mongoSrvLst.Remove(config.ConnectionName);
                    }
                    MongoServerSettings mongoSvrSetting = new MongoServerSettings();
                    if (String.IsNullOrEmpty(config.ConnectionString))
                    {
                        mongoSvrSetting.ConnectionMode = ConnectionMode.Direct;
                        //当一个服务器作为从属服务器，副本组中的备用服务器，这里一定要设置为SlaveOK
                        mongoSvrSetting.SlaveOk = config.IsSlaveOk;
                        //安全模式
                        mongoSvrSetting.SafeMode = new SafeMode(config.IsSafeMode);
                        //Replset时候可以不用设置吗？                    
                        mongoSvrSetting.Server = new MongoServerAddress(config.Host, config.Port);
                        //MapReduce的时候将消耗大量时间。不过这里需要平衡一下，太长容易造成并发问题
                        if (config.TimeOut != 0)
                        {
                            mongoSvrSetting.SocketTimeout = new TimeSpan(0, 0, config.TimeOut);
                        }
                        if (!(String.IsNullOrEmpty(config.UserName) | String.IsNullOrEmpty(config.Password)))
                        {
                            //认证的设定:注意，这里的密码是明文
                            mongoSvrSetting.DefaultCredentials = new MongoCredentials(config.UserName, config.Password, config.LoginAsAdmin);
                        }
                        if (config.ServerType == ConfigHelper.SvrType.ReplsetSvr)
                        {
                            //ReplsetName不是固有属性,可以设置，不过必须保持与配置文件的一致
                            mongoSvrSetting.ReplicaSetName = config.ReplSetName;
                            mongoSvrSetting.ConnectionMode = ConnectionMode.ReplicaSet;
                            //添加Replset服务器，注意，这里可能需要事先初始化副本
                            List<MongoServerAddress> ReplsetSvrList = new List<MongoServerAddress>();
                            foreach (String item in config.ReplsetList)
                            {
                                //如果这里的服务器在启动的时候没有--Replset参数，将会出错，当然作为单体的服务器，启动是没有任何问题的
                                MongoServerAddress ReplSrv = new MongoServerAddress(
                                                SystemManager.ConfigHelperInstance.ConnectionList[item].Host,
                                                SystemManager.ConfigHelperInstance.ConnectionList[item].Port);
                                ReplsetSvrList.Add(ReplSrv);
                            }
                            mongoSvrSetting.Servers = ReplsetSvrList;
                        }
                    }
                    else
                    {
                        //使用MongoConnectionString建立连接
                        mongoSvrSetting = MongoUrl.Create(config.ConnectionString).ToServerSettings();
                    }
                    MongoServer masterMongoSvr = new MongoServer(mongoSvrSetting);
                    _mongoSrvLst.Add(config.ConnectionName, masterMongoSvr);
                }
                catch (Exception ex)
                {
                    MyMessageBox.ShowMessage("Exception", "Can't Connect to Server：" + config.ConnectionName, ex.ToString(), true);
                }
            }
        }
        /// <summary>
        /// 使用字符串连接来填充
        /// </summary>
        /// <remarks>http://www.mongodb.org/display/DOCS/Connections</remarks>
        /// <param name="connectionString"></param>
        /// <param name="config"></param>
        public static Boolean FillConfigWithConnectionString(ConfigHelper.MongoConnectionConfig config)
        {
            String connectionString = config.ConnectionString;
            //mongodb://[username:password@]host1[:port1][,host2[:port2],...[,hostN[:portN]]][/[database][?options]]
            try
            {
                MongoUrl mongourl = MongoUrl.Create(connectionString);
                config.DataBaseName = mongourl.DatabaseName;
                if (mongourl.DefaultCredentials != null)
                {
                    config.UserName = mongourl.DefaultCredentials.Username;
                    config.Password = mongourl.DefaultCredentials.Password;
                    config.LoginAsAdmin = mongourl.DefaultCredentials.Admin;
                }
                config.Host = mongourl.Server.Host;
                config.Port = mongourl.Server.Port;
                config.IsSlaveOk = mongourl.SlaveOk;
                config.IsSafeMode = mongourl.SafeMode.Enabled;
                config.ReplSetName = mongourl.ReplicaSetName;
                config.TimeOut = (int)mongourl.SocketTimeout.TotalSeconds;
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        #endregion

        #region"展示数据库结构"
        /// <summary>
        /// get current Server Information
        /// </summary>
        /// <returns></returns>
        public static String GetCurrentSvrInfo()
        {
            String rtnSvrInfo = String.Empty;
            MongoServer mongosvr = SystemManager.GetCurrentService();
            rtnSvrInfo = "IsArbiter：" + mongosvr.Instance.IsArbiter.ToString() + "\r\n";
            rtnSvrInfo += "IsPrimary：" + mongosvr.Instance.IsPrimary.ToString() + "\r\n";
            rtnSvrInfo += "IsSecondary：" + mongosvr.Instance.IsSecondary.ToString() + "\r\n";
            rtnSvrInfo += "Address：" + mongosvr.Instance.Address.ToString() + "\r\n";
            if (mongosvr.Instance.BuildInfo != null)
            {
                //Before mongo2.0.2 BuildInfo will be null without auth
                rtnSvrInfo += "VersionString：" + mongosvr.Instance.BuildInfo.VersionString + "\r\n";
                rtnSvrInfo += "SysInfo：" + mongosvr.Instance.BuildInfo.SysInfo + "\r\n";
            }
            return rtnSvrInfo;
        }
        /// <summary>
        /// 将Mongodb的服务器在树形控件中展示
        /// </summary>
        /// <param name="trvMongoDB"></param>
        public static void FillMongoServiceToTreeView(TreeView trvMongoDB)
        {
            trvMongoDB.Nodes.Clear();
            foreach (string mongoSvrKey in _mongoSrvLst.Keys)
            {
                MongoServer mongoSvr = _mongoSrvLst[mongoSvrKey];
                TreeNode mongoSvrNode = new TreeNode();
                try
                {
                    //ReplSetName只能使用在虚拟的Replset服务器，Sharding体系等无效。虽然一个Sharding可以看做一个ReplSet
                    String strReplset = String.Empty;
                    if (SystemManager.IsUseDefaultLanguage())
                    {
                        strReplset = "副本名称";
                    }
                    else
                    {
                        strReplset = SystemManager.mStringResource.GetText(StringResource.TextType.ShardingConfig_ReplsetName);
                    }
                    mongoSvrNode.Text = mongoSvr.ReplicaSetName != null ?
                                                        strReplset + "：" + mongoSvr.ReplicaSetName :
                                                        (mongoSvrKey + " [" + mongoSvr.Settings.Server.Host + ":" + mongoSvr.Settings.Server.Port + "]");
                    mongoSvrNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.WebServer;
                    mongoSvrNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.WebServer;
                    //ReplSet服务器需要Connect才能连接。可能因为这个是虚拟的服务器，没有Mongod实体。
                    //不过现在改为全部显示的打开连接
                    mongoSvr.Connect();

                    ConfigHelper.MongoConnectionConfig config = SystemManager.ConfigHelperInstance.ConnectionList[mongoSvrKey];
                    if ((!String.IsNullOrEmpty(config.UserName)) & (!String.IsNullOrEmpty(config.Password)))
                    {
                        config.AuthMode = true;
                    }
                    //获取ReadOnly
                    config.IsReadOnly = false;
                    List<string> databaseNameList = new List<string>();
                    if (!String.IsNullOrEmpty(config.DataBaseName))
                    {
                        //单数据库模式
                        TreeNode mongoSingleDBNode = FillDataBaseInfoToTreeNode(config.DataBaseName, mongoSvr, mongoSvrKey);
                        mongoSingleDBNode.Tag = SINGLE_DATABASE_TAG + ":" + mongoSvrKey + "/" + config.DataBaseName;
                        mongoSingleDBNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
                        mongoSingleDBNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
                        mongoSvrNode.Nodes.Add(mongoSingleDBNode);
                        mongoSvrNode.Tag = SINGLE_DB_SERVICE_TAG + ":" + mongoSvrKey;
                        if (config.AuthMode)
                        {
                            config.IsReadOnly = mongoSvr.GetDatabase(config.DataBaseName).FindUser(config.UserName).IsReadOnly;
                        }
                    }
                    else
                    {
                        databaseNameList = mongoSvr.GetDatabaseNames().ToList<String>();
                        foreach (String strDBName in databaseNameList)
                        {
                            TreeNode mongoDBNode;
                            try
                            {
                                mongoDBNode = FillDataBaseInfoToTreeNode(strDBName, mongoSvr, mongoSvrKey);
                                mongoDBNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
                                mongoDBNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
                                mongoSvrNode.Nodes.Add(mongoDBNode);
                                if (strDBName == MongoDBHelper.DATABASE_NAME_ADMIN)
                                {
                                    if (config.AuthMode)
                                    {
                                        config.IsReadOnly = mongoSvr.GetDatabase(strDBName).FindUser(config.UserName).IsReadOnly;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                mongoDBNode = new TreeNode(strDBName + " (Exception)");
                                mongoDBNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
                                mongoDBNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
                                mongoSvrNode.Nodes.Add(mongoDBNode);
                            }
                        }
                        mongoSvrNode.Tag = SERVICE_TAG + ":" + mongoSvrKey;
                    }
                    SystemManager.ConfigHelperInstance.ConnectionList[mongoSvrKey] = config;
                    trvMongoDB.Nodes.Add(mongoSvrNode);
                }
                catch (MongoAuthenticationException ex)
                {
                    //需要验证的数据服务器，没有Admin权限无法获得数据库列表
                    if (!SystemManager.IsUseDefaultLanguage())
                    {
                        mongoSvrNode.Text += "[" + SystemManager.mStringResource.GetText(StringResource.TextType.Exception_AuthenticationException) + "]";
                        MyMessageBox.ShowMessage(SystemManager.mStringResource.GetText(StringResource.TextType.Exception_AuthenticationException),
                            "请检查用户名和密码", ex.ToString(), true);
                    }
                    else
                    {
                        mongoSvrNode.Text += "[MongoAuthenticationException]";
                        MyMessageBox.ShowMessage("MongoAuthenticationException:", "Please check UserName and Password", ex.ToString(), true);
                    }
                    mongoSvrNode.Tag = SERVICE_TAG_EXCEPTION + ":" + mongoSvrKey;
                    trvMongoDB.Nodes.Add(mongoSvrNode);
                }
                catch (Exception ex)
                {
                    //暂时不处理任何异常，简单跳过
                    //无法连接的理由：
                    //1.服务器没有启动
                    //2.认证模式不正确
                    if (!SystemManager.IsUseDefaultLanguage())
                    {
                        mongoSvrNode.Text += "[" + SystemManager.mStringResource.GetText(StringResource.TextType.Exception_NotConnected) + "]";
                        MyMessageBox.ShowMessage(SystemManager.mStringResource.GetText(StringResource.TextType.Exception_NotConnected),
                            "服务器没有启动 或者 认证模式不正确", ex.ToString(), true);
                    }
                    else
                    {
                        mongoSvrNode.Text += "[Exception]";
                        MyMessageBox.ShowMessage("Exception", "Mongo Server isn't Startup or Auth Mode is not correct", ex.ToString(), true);
                    }
                    mongoSvrNode.Tag = SERVICE_TAG_EXCEPTION + ":" + mongoSvrKey;
                    trvMongoDB.Nodes.Add(mongoSvrNode);
                }
            }
        }
        /// <summary>
        /// 获得一个表示数据库结构的节点
        /// </summary>
        /// <param name="strDBName"></param>
        /// <param name="mongoSvr"></param>
        /// <param name="mongoSvrKey"></param>
        /// <returns></returns>
        private static TreeNode FillDataBaseInfoToTreeNode(string strDBName, MongoServer mongoSvr, string mongoSvrKey)
        {
            String strShowDBName = strDBName;
            if (!SystemManager.IsUseDefaultLanguage())
            {
                if (SystemManager.mStringResource.LanguageType == "Chinese")
                {
                    switch (strDBName)
                    {
                        case "admin":
                            strShowDBName = "管理员权限(admin)";
                            break;
                        case "local":
                            strShowDBName = "本地(local)";
                            break;
                        case "config":
                            strShowDBName = "配置(config)";
                            break;
                        default:
                            break;
                    }
                }
            }
            TreeNode mongoDBNode = new TreeNode(strShowDBName);
            mongoDBNode.Tag = DATABASE_TAG + ":" + mongoSvrKey + "/" + strDBName;
            MongoDatabase mongoDB = mongoSvr.GetDatabase(strDBName);

            List<String> colNameList = mongoDB.GetCollectionNames().ToList<String>();
            foreach (String strColName in colNameList)
            {
                TreeNode mongoColNode = new TreeNode();
                try
                {
                    mongoColNode = FillCollectionInfoToTreeNode(strColName, mongoDB, mongoSvrKey);
                    mongoColNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Collection;
                    mongoColNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Collection;

                }
                catch (Exception)
                {
                    mongoColNode = new TreeNode(strColName + "[exception]");
                    mongoColNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Err;
                    mongoColNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Err;
                }
                mongoDBNode.Nodes.Add(mongoColNode);
            }
            mongoDBNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
            mongoDBNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
            return mongoDBNode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strShowColName"></param>
        /// <param name="mongoDB"></param>
        /// <param name="mongoSvrKey"></param>
        /// <returns></returns>
        private static TreeNode FillCollectionInfoToTreeNode(string strColName, MongoDatabase mongoDB, string mongoSvrKey)
        {
            String strShowColName = strColName;
            if (!SystemManager.IsUseDefaultLanguage())
            {
                if (SystemManager.mStringResource.LanguageType == "Chinese")
                {
                    switch (strShowColName)
                    {
                        case "chunks":
                            if (mongoDB.Name == "config")
                            {
                                strShowColName = "数据块(" + strShowColName + ")";
                            }
                            break;
                        case "collections":
                            if (mongoDB.Name == "config")
                            {
                                strShowColName = "数据集(" + strShowColName + ")";
                            }
                            break;
                        case "changelog":
                            if (mongoDB.Name == "config")
                            {
                                strShowColName = "变更日志(" + strShowColName + ")";
                            }
                            break;
                        case "databases":
                            if (mongoDB.Name == "config")
                            {
                                strShowColName = "数据库(" + strShowColName + ")";
                            }
                            break;
                        case "lockpings":
                            if (mongoDB.Name == "config")
                            {
                                strShowColName = "数据锁(" + strShowColName + ")";
                            }
                            break;
                        case "locks":
                            if (mongoDB.Name == "config")
                            {
                                strShowColName = "数据锁(" + strShowColName + ")";
                            }
                            break;
                        case "mongos":
                            if (mongoDB.Name == "config")
                            {
                                strShowColName = "路由服务器(" + strShowColName + ")";
                            }
                            break;
                        case "settings":
                            if (mongoDB.Name == "config")
                            {
                                strShowColName = "配置(" + strShowColName + ")";
                            }
                            break;
                        case "shards":
                            if (mongoDB.Name == "config")
                            {
                                strShowColName = "分片(" + strShowColName + ")";
                            }
                            break;
                        case "version":
                            if (mongoDB.Name == "config")
                            {
                                strShowColName = "版本(" + strShowColName + ")";
                            }
                            break;
                        case "me":
                            if (mongoDB.Name == "local")
                            {
                                strShowColName = "副本组[从属机信息](" + strShowColName + ")";
                            }
                            break;
                        case "sources":
                            if (mongoDB.Name == "local")
                            {
                                strShowColName = "主机地址(" + strShowColName + ")";
                            }
                            break;
                        case "slaves":
                            if (mongoDB.Name == "local")
                            {
                                strShowColName = "副本组[主机信息](" + strShowColName + ")";
                            }
                            break;
                        case COLLECTION_NAME_GFS_CHUNKS:
                            strShowColName = "数据块(" + strShowColName + ")";
                            break;
                        case COLLECTION_NAME_GFS_FILES:
                            strShowColName = "文件系统(" + strShowColName + ")";
                            break;
                        case COLLECTION_NAME_OPERATION_LOG:
                            strShowColName = "操作结果(" + strShowColName + ")";
                            break;
                        case COLLECTION_NAME_SYSTEM_INDEXES:
                            strShowColName = "索引(" + strShowColName + ")";
                            break;
                        case COLLECTION_NAME_JAVASCRIPT:
                            strShowColName = "存储Javascript(" + strShowColName + ")";
                            break;
                        case COLLECTION_NAME_SYSTEM_REPLSET:
                            strShowColName = "副本组(" + strShowColName + ")";
                            break;
                        case COLLECTION_NAME_REPLSET_MINVALID:
                            strShowColName = "初始化同步(" + strShowColName + ")";
                            break;
                        case COLLECTION_NAME_USER:
                            strShowColName = "用户列表(" + strShowColName + ")";
                            break;
                        default:
                            break;
                    }
                }
            }
            TreeNode mongoColNode;
            mongoColNode = new TreeNode(strShowColName);
            if (strColName == COLLECTION_NAME_GFS_FILES)
            {
                mongoColNode.Tag = GRID_FILE_SYSTEM_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + strColName;
            }
            else
            {
                mongoColNode.Tag = COLLECTION_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + strColName;
            }
            MongoCollection mongoCol = mongoDB.GetCollection(strColName);

            //Start ListIndex
            TreeNode mongoIndexes = new TreeNode("Indexes");
            GetIndexesResult indexList = mongoCol.GetIndexes();
            foreach (IndexInfo indexDoc in indexList.ToList<IndexInfo>())
            {
                TreeNode mongoIndex = new TreeNode();
                if (!SystemManager.IsUseDefaultLanguage())
                {
                    mongoIndex.Text = (SystemManager.mStringResource.GetText(StringResource.TextType.Index_Name) + ":" + indexDoc.Name);
                    mongoIndex.Nodes.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Index_Keys) + ":" + indexDoc.Key.ToString());
                    mongoIndex.Nodes.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Index_RepeatDel) + ":" + indexDoc.DroppedDups.ToString());
                    mongoIndex.Nodes.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Index_Background) + ":" + indexDoc.IsBackground.ToString());
                    mongoIndex.Nodes.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Index_Sparse) + ":" + indexDoc.IsSparse.ToString());
                    mongoIndex.Nodes.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Index_Unify) + ":" + indexDoc.IsUnique.ToString());
                    mongoIndex.Nodes.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Index_NameSpace) + ":" + indexDoc.Namespace.ToString());
                    mongoIndex.Nodes.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Index_Version) + ":" + indexDoc.Version.ToString());

                }
                else
                {
                    mongoIndex.Text = "IndexName:" + indexDoc.Name;
                    mongoIndex.Nodes.Add("Keys:" + indexDoc.Key.ToString());
                    mongoIndex.Nodes.Add("DroppedDups :" + indexDoc.DroppedDups.ToString());
                    mongoIndex.Nodes.Add("IsBackground:" + indexDoc.IsBackground.ToString());
                    mongoIndex.Nodes.Add("IsSparse:" + indexDoc.IsSparse.ToString());
                    mongoIndex.Nodes.Add("IsUnique:" + indexDoc.IsUnique.ToString());
                    mongoIndex.Nodes.Add("NameSpace:" + indexDoc.Namespace.ToString());
                    mongoIndex.Nodes.Add("Version:" + indexDoc.Version.ToString());
                }
                mongoIndex.ImageIndex = (int)GetSystemIcon.MainTreeImageType.DBKey;
                mongoIndex.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.DBKey;
                mongoIndex.Tag = INDEX_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + strColName + "/" + indexDoc.Name;
                mongoIndexes.Nodes.Add(mongoIndex);
            }
            mongoIndexes.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Keys;
            mongoIndexes.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Keys;
            mongoIndexes.Tag = INDEXES_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + strColName;
            mongoColNode.Nodes.Add(mongoIndexes);
            //End ListIndex

            //Start Data
            TreeNode mongoData = new TreeNode("Data");
            mongoData.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Document;
            mongoData.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Document;
            mongoData.Tag = DOCUMENT_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + strColName;

            mongoColNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Collection;
            mongoColNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Collection;
            mongoColNode.Nodes.Add(mongoData);
            //End Data
            return mongoColNode;
        }
        #endregion
    }
}
