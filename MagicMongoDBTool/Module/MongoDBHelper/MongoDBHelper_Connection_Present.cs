using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MongoDB.Driver;
using System.Linq;
using MongoDB.Bson;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        #region"展示数据库结构"
        /// <summary>
        /// get current Server Information
        /// </summary>
        /// <returns></returns>
        public static String GetCurrentSvrInfo()
        {
            String rtnSvrInfo = String.Empty;
            MongoServer mongosvr = SystemManager.GetCurrentService();
            rtnSvrInfo = "IsArbiter：" + mongosvr.Instance.IsArbiter.ToString() + System.Environment.NewLine;
            rtnSvrInfo += "IsPrimary：" + mongosvr.Instance.IsPrimary.ToString() + System.Environment.NewLine;
            rtnSvrInfo += "IsSecondary：" + mongosvr.Instance.IsSecondary.ToString() + System.Environment.NewLine;
            rtnSvrInfo += "Address：" + mongosvr.Instance.Address.ToString() + System.Environment.NewLine;
            if (mongosvr.Instance.BuildInfo != null)
            {
                //Before mongo2.0.2 BuildInfo will be null without auth
                rtnSvrInfo += "VersionString：" + mongosvr.Instance.BuildInfo.VersionString + System.Environment.NewLine;
                rtnSvrInfo += "SysInfo：" + mongosvr.Instance.BuildInfo.SysInfo + System.Environment.NewLine;
            }
            return rtnSvrInfo;
        }
        /// <summary>
        /// 将Mongodb的服务器在树形控件中展示
        /// </summary>
        /// <param name="trvMongoDB"></param>
        public static void FillMongoServerToTreeView(TreeView trvMongoDB)
        {
            trvMongoDB.Nodes.Clear();
            _mongoStatusLst.Clear();
            foreach (String mongoSvrKey in _mongoSrvLst.Keys)
            {
                MongoServer mongoSvr = _mongoSrvLst[mongoSvrKey];
                TreeNode mongoSvrNode = new TreeNode();
                try
                {
                    //ReplSetName只能使用在虚拟的Replset服务器，Sharding体系等无效。虽然一个Sharding可以看做一个ReplSet
                    String strReplset = String.Empty;
                    if (SystemManager.IsUseDefaultLanguage())
                    {
                        strReplset = "ReplsetName";
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
                    List<String> databaseNameList = new List<String>();
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
                    _mongoStatusLst.Add(mongoSvrKey, true);
                }
                catch (MongoAuthenticationException ex)
                {
                    //需要验证的数据服务器，没有Admin权限无法获得数据库列表
                    if (!SystemManager.IsUseDefaultLanguage())
                    {
                        mongoSvrNode.Text += "[" + SystemManager.mStringResource.GetText(StringResource.TextType.Exception_AuthenticationException) + "]";
                        MyMessageBox.ShowMessage(SystemManager.mStringResource.GetText(StringResource.TextType.Exception_AuthenticationException),
                                                 SystemManager.mStringResource.GetText(StringResource.TextType.Exception_AuthenticationException_Note), ex.ToString(), true);
                    }
                    else
                    {
                        mongoSvrNode.Text += "[MongoAuthenticationException]";
                        MyMessageBox.ShowMessage("MongoAuthenticationException:", "Please check UserName and Password", ex.ToString(), true);
                    }
                    mongoSvrNode.Tag = SERVICE_TAG_EXCEPTION + ":" + mongoSvrKey;
                    trvMongoDB.Nodes.Add(mongoSvrNode);
                    _mongoStatusLst.Add(mongoSvrKey, false);
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
                                                 SystemManager.mStringResource.GetText(StringResource.TextType.Exception_NotConnected_Note), ex.ToString(), true);
                    }
                    else
                    {
                        mongoSvrNode.Text += "[Exception]";
                        MyMessageBox.ShowMessage("Exception", "Mongo Server may not Startup or Auth Mode is not correct", ex.ToString(), true);
                    }
                    mongoSvrNode.Tag = SERVICE_TAG_EXCEPTION + ":" + mongoSvrKey;
                    trvMongoDB.Nodes.Add(mongoSvrNode);
                    _mongoStatusLst.Add(mongoSvrKey, false);
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
        private static TreeNode FillDataBaseInfoToTreeNode(String strDBName, MongoServer mongoSvr, String mongoSvrKey)
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

            TreeNode UserNode = new TreeNode("User", (int)GetSystemIcon.MainTreeImageType.UserIcon, (int)GetSystemIcon.MainTreeImageType.UserIcon);
            UserNode.Tag = USER_LIST_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + COLLECTION_NAME_USER;
            mongoDBNode.Nodes.Add(UserNode);

            TreeNode JsNode = new TreeNode("JavaScript", (int)GetSystemIcon.MainTreeImageType.JavaScriptList, (int)GetSystemIcon.MainTreeImageType.JavaScriptList);
            JsNode.Tag = JAVASCRIPT_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + COLLECTION_NAME_JAVASCRIPT;
            mongoDBNode.Nodes.Add(JsNode);

            TreeNode GFSNode = new TreeNode("Grid File System", (int)GetSystemIcon.MainTreeImageType.GFS, (int)GetSystemIcon.MainTreeImageType.GFS);
            GFSNode.Tag = GRID_FILE_SYSTEM_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + COLLECTION_NAME_GFS_FILES;
            mongoDBNode.Nodes.Add(GFSNode);

            TreeNode mongoSysColListNode = new TreeNode("Collections(System)", (int)GetSystemIcon.MainTreeImageType.SystemCol, (int)GetSystemIcon.MainTreeImageType.SystemCol);
            mongoSysColListNode.Tag = SYSTEM_COLLECTION_LIST_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name;
            mongoDBNode.Nodes.Add(mongoSysColListNode);

            TreeNode mongoColListNode = new TreeNode("Collections(General)", (int)GetSystemIcon.MainTreeImageType.CollectionList, (int)GetSystemIcon.MainTreeImageType.CollectionList);
            mongoColListNode.Tag = COLLECTION_LIST_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name;
            List<String> colNameList = mongoDB.GetCollectionNames().ToList<String>();
            foreach (String strColName in colNameList)
            {
                switch (strColName)
                {
                    case COLLECTION_NAME_GFS_CHUNKS:
                    case COLLECTION_NAME_GFS_FILES:
                    case COLLECTION_NAME_USER:
                        //system.users,fs,system.js这几个系统级别的Collection不需要放入
                        break;
                    case COLLECTION_NAME_JAVASCRIPT:
                        foreach (BsonDocument t in mongoDB.GetCollection(COLLECTION_NAME_JAVASCRIPT).FindAll())
                        {
                            TreeNode js = new TreeNode(t.GetValue("_id").ToString());
                            js.ImageIndex = (int)GetSystemIcon.MainTreeImageType.JsDoc;
                            js.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.JsDoc;
                            js.Tag = JAVASCRIPT_DOC_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + COLLECTION_NAME_JAVASCRIPT + "/" + t.GetValue("_id").ToString();
                            JsNode.Nodes.Add(js);
                        }
                        break;
                    default:
                        TreeNode mongoColNode = new TreeNode();
                        try
                        {
                            mongoColNode = FillCollectionInfoToTreeNode(strColName, mongoDB, mongoSvrKey);
                        }
                        catch (Exception)
                        {
                            mongoColNode = new TreeNode(strColName + "[exception]");
                            mongoColNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Err;
                            mongoColNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Err;
                        }

                        if (IsSystemCollection(mongoDB.Name, strColName))
                        {
                            mongoSysColListNode.Nodes.Add(mongoColNode);

                        }
                        else
                        {
                            mongoColListNode.Nodes.Add(mongoColNode);
                        }
                        break;
                }
            }
            mongoDBNode.Nodes.Add(mongoColListNode);


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
        private static TreeNode FillCollectionInfoToTreeNode(String strColName, MongoDatabase mongoDB, String mongoSvrKey)
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
            switch (strColName)
            {
                case COLLECTION_NAME_GFS_FILES:
                    mongoColNode.Tag = GRID_FILE_SYSTEM_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + strColName;
                    break;
                case COLLECTION_NAME_USER:
                    mongoColNode.Tag = USER_LIST_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + strColName;
                    break;
                default:
                    mongoColNode.Tag = COLLECTION_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + strColName;
                    break;
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
                    mongoIndex.Nodes.Add(String.Empty, SystemManager.mStringResource.GetText(StringResource.TextType.Index_Keys) + ":" + indexDoc.Key.ToString(), (int)GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, SystemManager.mStringResource.GetText(StringResource.TextType.Index_RepeatDel) + ":" + indexDoc.DroppedDups.ToString(), (int)GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, SystemManager.mStringResource.GetText(StringResource.TextType.Index_Background) + ":" + indexDoc.IsBackground.ToString(), (int)GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, SystemManager.mStringResource.GetText(StringResource.TextType.Index_Sparse) + ":" + indexDoc.IsSparse.ToString(), (int)GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, SystemManager.mStringResource.GetText(StringResource.TextType.Index_Unify) + ":" + indexDoc.IsUnique.ToString(), (int)GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, SystemManager.mStringResource.GetText(StringResource.TextType.Index_NameSpace) + ":" + indexDoc.Namespace.ToString(), (int)GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, SystemManager.mStringResource.GetText(StringResource.TextType.Index_Version) + ":" + indexDoc.Version.ToString(), (int)GetSystemIcon.MainTreeImageType.KeyInfo);

                }
                else
                {
                    mongoIndex.Text = "IndexName:" + indexDoc.Name;
                    mongoIndex.Nodes.Add(String.Empty, "Keys:" + indexDoc.Key.ToString(), (int)GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, "DroppedDups :" + indexDoc.DroppedDups.ToString(), (int)GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, "IsBackground:" + indexDoc.IsBackground.ToString(), (int)GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, "IsSparse:" + indexDoc.IsSparse.ToString(), (int)GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, "IsUnique:" + indexDoc.IsUnique.ToString(), (int)GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, "NameSpace:" + indexDoc.Namespace.ToString(), (int)GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, "Version:" + indexDoc.Version.ToString(), (int)GetSystemIcon.MainTreeImageType.KeyInfo);
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

            mongoColNode.ToolTipText = strColName + System.Environment.NewLine;
            mongoColNode.ToolTipText += "IsCapped:" + mongoCol.GetStats().IsCapped.ToString();

            if (strColName == COLLECTION_NAME_USER)
            {
                mongoColNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.UserIcon;
                mongoColNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.UserIcon;
            }
            else
            {
                mongoColNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Collection;
                mongoColNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Collection;
            }
            //End Data
            return mongoColNode;
        }
        #endregion
    }
}
