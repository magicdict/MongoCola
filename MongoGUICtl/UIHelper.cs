using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using MongoUtility.Security;
using ResourceLib.Utility;
using Utility = Common.Logic.Utility;

namespace MongoGUICtl
{
    public static partial class UIHelper
    {
        #region"展示数据库结构 Winform"

        /// <summary>
        ///     将数据放入TreeView里进行展示
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="trvData" />
        /// <param name="dataList"></param>
        public static void FillDataToTreeView(string collectionName, ctlTreeViewColumns trvData, BsonDocument dataList)
        {
            var DocList = new List<BsonDocument>();
            DocList.Add(dataList);
            FillDataToTreeView(collectionName, trvData, DocList, 0);
        }

        /// <summary>
        ///     将数据放入TreeView里进行展示
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="trvData"></param>
        /// <param name="dataList"></param>
        /// <param name="mSkip"></param>
        public static void FillDataToTreeView(string collectionName, ctlTreeViewColumns trvData,
            List<BsonDocument> dataList, int mSkip)
        {
            trvData.DatatreeView.BeginUpdate();
            trvData.DatatreeView.Nodes.Clear();
            var SkipCnt = mSkip;
            var Count = 1;
            foreach (var item in dataList)
            {
                var dataNode = new TreeNode(collectionName + "[" + (SkipCnt + Count) + "]");
                //这里保存真实的主Key数据，删除的时候使用
                switch (collectionName)
                {
                    case ConstMgr.COLLECTION_NAME_GFS_FILES:
                        dataNode.Tag = item.GetElement(1).Value;
                        break;
                    case ConstMgr.COLLECTION_NAME_USER:
                        dataNode.Tag = item.GetElement(1).Value;
                        break;
                    //case COLLECTION_NAME_ROLE:
                    //    dataNode.Tag = item.GetElement(1).Value;
                    //    break;
                    default:
                        //SelectDocId属性的设置,
                        //2012/03/19 不一定id是在第一位
                        //这里是为了操作顶层节点的删除，修改用的，所以必须要放item.GetElement(0).Value;
                        BsonElement id;
                        item.TryGetElement(ConstMgr.KEY_ID, out id);
                        dataNode.Tag = (id.Value != null) ? id.Value : item.GetElement(0).Value;
                        break;
                }
                AddBsonDocToTreeNode(dataNode, item);
                trvData.DatatreeView.Nodes.Add(dataNode);
                Count++;
            }
            trvData.DatatreeView.EndUpdate();
        }

        /// <summary>
        ///     将数据放入TreeNode里进行展示
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="doc"></param>
        public static void AddBsonDocToTreeNode(TreeNode treeNode, BsonDocument doc)
        {
            foreach (var item in doc.Elements)
            {
                if (item.Value.IsBsonDocument)
                {
                    var newItem = new TreeNode(item.Name);
                    AddBsonDocToTreeNode(newItem, item.Value.ToBsonDocument());
                    newItem.Tag = item;
                    treeNode.Nodes.Add(newItem);
                }
                else
                {
                    if (item.Value.IsBsonArray)
                    {
                        //虽然TreeNode的Text属性带有Array_Mark，表示的时候则会屏蔽掉，
                        //必须要加上，不然FullPath会出现错误
                        var newItem = new TreeNode(item.Name + ConstMgr.Array_Mark);
                        AddBsonArrayToTreeNode(item.Name, newItem, item.Value.AsBsonArray);
                        newItem.Tag = item;
                        treeNode.Nodes.Add(newItem);
                    }
                    else
                    {
                        var ElementNode = new TreeNode(item.Name);
                        ElementNode.Tag = item;
                        treeNode.Nodes.Add(ElementNode);
                    }
                }
            }
        }

        /// <summary>
        ///     将BsonArray放入树形控件
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="item"></param>
        public static void AddBsonArrayToTreeNode(string ArrayName, TreeNode newItem, BsonArray item)
        {
            var Count = 1;
            foreach (var SubItem in item)
            {
                if (SubItem.IsBsonDocument)
                {
                    var newSubItem = new TreeNode(ArrayName + "[" + Count + "]");
                    AddBsonDocToTreeNode(newSubItem, SubItem.ToBsonDocument());
                    newSubItem.Tag = SubItem;
                    newItem.Nodes.Add(newSubItem);
                }
                else
                {
                    if (SubItem.IsBsonArray)
                    {
                        var newSubItem = new TreeNode(ConstMgr.Array_Mark);
                        AddBsonArrayToTreeNode(ArrayName, newSubItem, SubItem.AsBsonArray);
                        newSubItem.Tag = SubItem;
                        newItem.Nodes.Add(newSubItem);
                    }
                    else
                    {
                        var newSubItem = new TreeNode(ArrayName + "[" + Count + "]") {Tag = SubItem};
                        newItem.Nodes.Add(newSubItem);
                    }
                }
                Count++;
            }
        }

        /// <summary>
        ///     After Legacy
        ///     获取将Mongodb的服务器在树形控件中展示的TreeNodes
        /// </summary>
        /// <param name="_mongoConnClientLst"></param>
        /// <param name="_mongoConConfigLst"></param>
        /// <returns></returns>
        public static List<TreeNode> GetConnectionNodes(Dictionary<String, MongoClient> _mongoConnClientLst,
            Dictionary<String, MongoConnectionConfig> _mongoConConfigLst)
        {
            var ConnectionNodes = new List<TreeNode>();
            foreach (var mongoConnKey in _mongoConnClientLst.Keys)
            {
                var mongoSrv = _mongoConnClientLst[mongoConnKey];
                var ConnectionNode = new TreeNode();
                var UserList = new EachDatabaseUser();
                try
                {
                    //ReplSetName只能使用在虚拟的Replset服务器，Sharding体系等无效。虽然一个Sharding可以看做一个ReplSet
                    var config = _mongoConConfigLst[mongoConnKey];
                    ConnectionNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Connection;
                    ConnectionNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Connection;
                    //ReplSet服务器需要Connect才能连接。可能因为这个是虚拟的服务器，没有Mongod实体。
                    //不过现在改为全部显示的打开连接
                    ConnectionNode.Text = mongoConnKey;
                    //形成树型菜单的方法
                    //ConnectionNode.Nodes.Add();
                    config.ServerRole = MongoConnectionConfig.SvrRoleType.DataSvr;
                    ConnectionNode.Tag = ConstMgr.CONNECTION_TAG + ":" + config.ConnectionName;
                    //设定是否可用
                    config.Health = true;
                    _mongoConConfigLst[mongoConnKey] = config;
                    switch (config.ServerRole)
                    {
                        case MongoConnectionConfig.SvrRoleType.DataSvr:
                            ConnectionNode.Text = "[Data]  " + ConnectionNode.Text;
                            break;
                        case MongoConnectionConfig.SvrRoleType.ShardSvr:
                            ConnectionNode.Text = "[Cluster]  " + ConnectionNode.Text;
                            break;
                        case MongoConnectionConfig.SvrRoleType.ReplsetSvr:
                            ConnectionNode.Text = "[Replset]  " + ConnectionNode.Text;
                            break;
                        case MongoConnectionConfig.SvrRoleType.MasterSvr:
                            ConnectionNode.Text = "[Master]  " + ConnectionNode.Text;
                            break;
                        case MongoConnectionConfig.SvrRoleType.SlaveSvr:
                            ConnectionNode.Text = "[Slave]  " + ConnectionNode.Text;
                            break;
                    }
                    ConnectionNodes.Add(ConnectionNode);
                    if (RuntimeMongoDBContext._mongoUserLst.ContainsKey(mongoConnKey))
                    {
                        RuntimeMongoDBContext._mongoUserLst[mongoConnKey] = UserList;
                    }
                    else
                    {
                        RuntimeMongoDBContext._mongoUserLst.Add(mongoConnKey, UserList);
                    }
                }
                catch (MongoAuthenticationException ex)
                {
                    AuthenticationExceptionHandler(ex, ConnectionNodes, ConnectionNode, mongoConnKey);
                }
                catch (MongoCommandException ex)
                {
                    MongoCommandExceptionHandle(ex, ConnectionNodes, ConnectionNode, mongoConnKey);
                }
                catch (MongoConnectionException ex)
                {
                    MongoConnectionExceptionHandle(ex, ConnectionNodes, ConnectionNode, mongoConnKey);
                }
                catch (Exception ex)
                {
                    ExceptionHandle(ex, ConnectionNodes, ConnectionNode, mongoConnKey);
                }
            }
            return ConnectionNodes;
        }


        /// <summary>
        ///     Legacy
        ///     获取将Mongodb的服务器在树形控件中展示的TreeNodes
        /// </summary>
        /// <param name="_mongoConnSvrLst"></param>
        /// <param name="_mongoConConfigLst"></param>
        /// <returns></returns>
        public static List<TreeNode> GetConnectionNodes(Dictionary<String, MongoServer> _mongoConnSvrLst,
            Dictionary<String, MongoConnectionConfig> _mongoConConfigLst)
        {
            var ConnectionNodes = new List<TreeNode>();
            foreach (var mongoConnKey in _mongoConnSvrLst.Keys)
            {
                var mongoSrv = _mongoConnSvrLst[mongoConnKey];
                var ConnectionNode = new TreeNode();
                var UserList = new EachDatabaseUser();
                var isConnected = false;
                try
                {
                    //ReplSetName只能使用在虚拟的Replset服务器，Sharding体系等无效。虽然一个Sharding可以看做一个ReplSet
                    var config = _mongoConConfigLst[mongoConnKey];
                    ConnectionNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Connection;
                    ConnectionNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Connection;
                    //ReplSet服务器需要Connect才能连接。可能因为这个是虚拟的服务器，没有Mongod实体。
                    //不过现在改为全部显示的打开连接
                    mongoSrv.Connect();
                    isConnected = true;
                    //mongoSvr.ReplicaSetName只有在连接后才有效，但是也可以使用Config.ReplsetName
                    ConnectionNode.Text = mongoConnKey;
                    //形成树型菜单
                    var SingleConnection = GetInstanceNode(mongoConnKey, ref config, mongoSrv, null, mongoSrv, UserList);
                    ConnectionNode.Nodes.Add(SingleConnection);
                    if (mongoSrv.ReplicaSetName != null)
                    {
                        config = FillReplset(mongoConnKey, mongoSrv, ConnectionNode, UserList, config);
                    }
                    else
                    {
                        var ServerStatusDoc =
                            CommandHelper.ExecuteMongoSvrCommand(CommandHelper.serverStatus_Command, mongoSrv).Response;
                        //ServerStatus可能没有权限打开
                        if (ServerStatusDoc.Contains("process") &&
                            ServerStatusDoc.GetElement("process").Value == ConstMgr.ServerStatus_PROCESS_MONGOS)
                        {
                            config = FillShards(mongoConnKey, mongoSrv, ConnectionNode, UserList, config);
                        }
                        else
                        {
                            FillNormal(ConnectionNode, config, ServerStatusDoc);
                        }
                    }
                    //设定是否可用
                    config.Health = true;
                    //设定版本
                    if (mongoSrv.BuildInfo != null)
                    {
                        config.MongoDBVersion = mongoSrv.BuildInfo.Version;
                    }
                    _mongoConConfigLst[mongoConnKey] = config;
                    switch (config.ServerRole)
                    {
                        case MongoConnectionConfig.SvrRoleType.DataSvr:
                            ConnectionNode.Text = "[Data]  " + ConnectionNode.Text;
                            break;
                        case MongoConnectionConfig.SvrRoleType.ShardSvr:
                            ConnectionNode.Text = "[Cluster]  " + ConnectionNode.Text;
                            break;
                        case MongoConnectionConfig.SvrRoleType.ReplsetSvr:
                            ConnectionNode.Text = "[Replset]  " + ConnectionNode.Text;
                            break;
                        case MongoConnectionConfig.SvrRoleType.MasterSvr:
                            ConnectionNode.Text = "[Master]  " + ConnectionNode.Text;
                            break;
                        case MongoConnectionConfig.SvrRoleType.SlaveSvr:
                            ConnectionNode.Text = "[Slave]  " + ConnectionNode.Text;
                            break;
                    }
                    ConnectionNodes.Add(ConnectionNode);
                    if (RuntimeMongoDBContext._mongoUserLst.ContainsKey(mongoConnKey))
                    {
                        RuntimeMongoDBContext._mongoUserLst[mongoConnKey] = UserList;
                    }
                    else
                    {
                        RuntimeMongoDBContext._mongoUserLst.Add(mongoConnKey, UserList);
                    }
                }
                catch (MongoAuthenticationException ex)
                {
                    AuthenticationExceptionHandler(ex, ConnectionNodes, ConnectionNode, mongoConnKey);
                    ConnectionNodes = null;
                }
                catch (MongoCommandException ex)
                {
                    MongoCommandExceptionHandle(ex, ConnectionNodes, ConnectionNode, mongoConnKey);
                    ConnectionNodes = null;
                }
                catch (MongoConnectionException ex)
                {
                    MongoConnectionExceptionHandle(ex, ConnectionNodes, ConnectionNode, mongoConnKey);
                    ConnectionNodes = null;
                }
                catch (Exception ex)
                {
                    ExceptionHandle(ex, ConnectionNodes, ConnectionNode, mongoConnKey);
                    ConnectionNodes = null;
                }
                finally
                {
                    if (isConnected)
                        mongoSrv.Disconnect();
                }
            }
            return ConnectionNodes;
        }

        private static void FillNormal(TreeNode ConnectionNode, MongoConnectionConfig config,
            BsonDocument ServerStatusDoc)
        {
            //Server Status mongod
            //Master - Slave 的判断
            BsonElement replElement;
            ServerStatusDoc.TryGetElement("repl", out replElement);
            //CSHARP-1066: Change BsonElement from a class to a struct. 
            //if (replElement == null)
            if (replElement.Value == null)
            {
                config.ServerRole = MongoConnectionConfig.SvrRoleType.DataSvr;
            }
            else
            {
                config.ServerRole = replElement.Value.AsBsonDocument.GetElement("ismaster").Value ==
                                    BsonBoolean.True
                    ? MongoConnectionConfig.SvrRoleType.MasterSvr
                    : MongoConnectionConfig.SvrRoleType.SlaveSvr;
            }
            ConnectionNode.Tag = ConstMgr.CONNECTION_TAG + ":" + config.ConnectionName;
        }

        private static MongoConnectionConfig FillShards(string mongoConnKey, MongoServer mongoSrv,
            TreeNode ConnectionNode, EachDatabaseUser UserList, MongoConnectionConfig config)
        {
            //Shard的时候，必须将所有服务器的ReadPreferred设成可读
            config.ServerRole = MongoConnectionConfig.SvrRoleType.ShardSvr;
            ConnectionNode.Tag = ConstMgr.CONNECTION_CLUSTER_TAG + ":" + config.ConnectionName;
            var ShardListNode = new TreeNode("Shards")
            {
                SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers,
                ImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers
            };
            foreach (var lst in OperationHelper.GetShardInfo(mongoSrv, "host"))
            {
                var ShardNode = new TreeNode
                {
                    Text = lst.Key,
                    SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers,
                    ImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers
                };
                var strHostList = lst.Value;
                var strAddress = strHostList.Split("/".ToCharArray());
                String strAddresslst;
                if (strAddress.Length == 2)
                {
                    //#1  replset/host:port,host:port
                    ShardNode.Text += "[Replset:" + strAddress[0] + "]";
                    strAddresslst = strAddress[1];
                }
                else
                {
                    //#2  host:port,host:port
                    strAddresslst = strHostList;
                }
                foreach (var item in strAddresslst.Split(",".ToCharArray()))
                {
                    var tinySetting = new MongoClientSettings
                    {
                        ConnectionMode = ConnectionMode.Direct,
                        ReadPreference = ReadPreference.PrimaryPreferred,
                        ReplicaSetName = strAddress[0]
                    };
                    //防止无法读取Sharding状态。Sharding可能是一个Slaver
                    MongoServerAddress SecondaryAddr;
                    if (item.Split(":".ToCharArray()).Length == 2)
                    {
                        SecondaryAddr = new MongoServerAddress(item.Split(":".ToCharArray())[0],
                            Convert.ToInt32(item.Split(":".ToCharArray())[1]));
                    }
                    else
                    {
                        SecondaryAddr = new MongoServerAddress(item.Split(":".ToCharArray())[0]);
                    }
                    tinySetting.Server = SecondaryAddr;
                    var ReplsetMember = new MongoClient(tinySetting).GetServer();
                    ShardNode.Nodes.Add(GetInstanceNode(mongoConnKey, ref config, mongoSrv,
                        ReplsetMember.Instance, null, UserList));
                }
                ShardListNode.Nodes.Add(ShardNode);
            }
            ConnectionNode.Nodes.Add(ShardListNode);
            return config;
        }

        private static MongoConnectionConfig FillReplset(string mongoConnKey, MongoServer mongoSrv,
            TreeNode ConnectionNode, EachDatabaseUser UserList, MongoConnectionConfig config)
        {
            ConnectionNode.Tag = ConstMgr.CONNECTION_REPLSET_TAG + ":" + config.ConnectionName;
            var ServerListNode = new TreeNode("Servers")
            {
                SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers,
                ImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers
            };
            foreach (var ServerInstace in mongoSrv.Instances)
            {
                ServerListNode.Nodes.Add(GetInstanceNode(mongoConnKey, ref config, mongoSrv, ServerInstace,
                    null, UserList));
            }
            ConnectionNode.Nodes.Add(ServerListNode);
            config.ServerRole = MongoConnectionConfig.SvrRoleType.ReplsetSvr;
            return config;
        }

        private static void AuthenticationExceptionHandler(MongoAuthenticationException ex,
            List<TreeNode> trvMongoDB,
            TreeNode ConnectionNode,
            string mongoConnKey)
        {
            //需要验证的数据服务器，没有Admin权限无法获得数据库列表
            if (!configuration.guiConfig.IsUseDefaultLanguage)
            {
                ConnectionNode.Text += "[" +
                                       configuration.guiConfig.MStringResource.GetText(
                                           StringResource.TextType.Exception_AuthenticationException) + "]";
                Utility.ExceptionDeal(ex,
                    configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Exception_AuthenticationException),
                    configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Exception_AuthenticationException_Note));
            }
            else
            {
                ConnectionNode.Text += "[MongoAuthenticationException]";
                Utility.ExceptionDeal(ex, "MongoAuthenticationException:", "Please check UserName and Password");
            }
            ConnectionNode.Tag = ConstMgr.CONNECTION_EXCEPTION_TAG + ":" + mongoConnKey;
            trvMongoDB.Add(ConnectionNode);
        }

        private static string MongoCommandExceptionHandle(MongoCommandException ex,
            List<TreeNode> trvMongoDB,
            TreeNode ConnectionNode,
            string mongoConnKey)
        {
            //listDatabase命令错误，本质是用户名称错误
            if (ex.Result["errmsg"] == "unauthorized")
            {
                if (!configuration.guiConfig.IsUseDefaultLanguage)
                {
                    ConnectionNode.Text += "[" +
                                           configuration.guiConfig.MStringResource.GetText(
                                               StringResource.TextType.Exception_AuthenticationException) + "]";
                    Utility.ExceptionDeal(ex,
                        configuration.guiConfig.MStringResource.GetText(
                            StringResource.TextType.Exception_AuthenticationException),
                        configuration.guiConfig.MStringResource.GetText(
                            StringResource.TextType.Exception_AuthenticationException_Note));
                }
                else
                {
                    ConnectionNode.Text += "[MongoCommandExceptionHandle]";
                    Utility.ExceptionDeal(ex, "MongoCommandExceptionHandle:", "Please check UserName and Password");
                }
            }
            else
            {
                if (!configuration.guiConfig.IsUseDefaultLanguage)
                {
                    ConnectionNode.Text += "[" +
                                           configuration.guiConfig.MStringResource.GetText(
                                               StringResource.TextType.Exception_NotConnected) + "]";
                    Utility.ExceptionDeal(ex,
                        configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Exception_NotConnected),
                        "Unknown Exception");
                }
                else
                {
                    ConnectionNode.Text += "[Exception]";
                    Utility.ExceptionDeal(ex, "Not Connected", "Unknown Exception");
                }
            }
            ConnectionNode.Tag = ConstMgr.CONNECTION_EXCEPTION_TAG + ":" + mongoConnKey;
            trvMongoDB.Add(ConnectionNode);
            return mongoConnKey;
        }

        private static string MongoConnectionExceptionHandle(MongoConnectionException ex,
            List<TreeNode> trvMongoDB,
            TreeNode ConnectionNode, string mongoConnKey)
        {
            //暂时不处理任何异常，简单跳过
            //无法连接的理由：
            //1.服务器没有启动
            //2.认证模式不正确
            if (!configuration.guiConfig.IsUseDefaultLanguage)
            {
                ConnectionNode.Text += "[" +
                                       configuration.guiConfig.MStringResource.GetText(
                                           StringResource.TextType.Exception_NotConnected) + "]";
                Utility.ExceptionDeal(ex,
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Exception_NotConnected),
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Exception_NotConnected_Note));
            }
            else
            {
                ConnectionNode.Text += "[Exception]";
                Utility.ExceptionDeal(ex, "Not Connected", "Mongo Server may not Startup or Auth Mode is not correct");
            }
            ConnectionNode.Tag = ConstMgr.CONNECTION_EXCEPTION_TAG + ":" + mongoConnKey;
            trvMongoDB.Add(ConnectionNode);
            return mongoConnKey;
        }

        private static void ExceptionHandle(Exception ex,
            List<TreeNode> trvMongoDB,
            TreeNode ConnectionNode, string mongoConnKey)
        {
            if (!configuration.guiConfig.IsUseDefaultLanguage)
            {
                ConnectionNode.Text += "[" +
                                       configuration.guiConfig.MStringResource.GetText(
                                           StringResource.TextType.Exception_NotConnected) + "]";
                Utility.ExceptionDeal(ex,
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Exception_NotConnected),
                    "Unknown Exception");
            }
            else
            {
                ConnectionNode.Text += "[Exception]";
                Utility.ExceptionDeal(ex, "Not Connected", "Unknown Exception");
            }
            ConnectionNode.Tag = ConstMgr.CONNECTION_EXCEPTION_TAG + ":" + mongoConnKey;
            trvMongoDB.Add(ConnectionNode);
        }

        /// <summary>
        ///     获取实例节点
        ///     这里将形成左侧的树型目录
        /// </summary>
        /// <param name="mongoConnKey"></param>
        /// <param name="config">由于是结构体，必须ref</param>
        /// <param name="mongoConn"></param>
        /// <param name="mMasterServerInstace"></param>
        /// <param name="mServer"></param>
        /// <param name="UserList"></param>
        /// <returns></returns>
        private static TreeNode GetInstanceNode(String mongoConnKey,
            ref MongoConnectionConfig config,
            MongoServer mongoConn,
            MongoServerInstance mMasterServerInstace,
            MongoServer mServer,
            EachDatabaseUser UserList)
        {
            var isReplsetMasterServer = mMasterServerInstace == null;
            //无论如何，都改为主要服务器读优先
            var svrInstanceNode = new TreeNode();
            var connSvrKey = isReplsetMasterServer
                ? mongoConnKey + "/" + mongoConnKey
                : mongoConnKey + "/" + mMasterServerInstace.Address.ToString().Replace(":", "@");
            svrInstanceNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.WebServer;
            svrInstanceNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.WebServer;
            svrInstanceNode.Text = isReplsetMasterServer ? "Connection" : "Server[" + mMasterServerInstace.Address + "]";
            if (!String.IsNullOrEmpty(config.UserName) & (!String.IsNullOrEmpty(config.Password)))
            {
                //是否是认证模式，应该取决于服务器！
                config.AuthMode = true;
            }
            //获取ReadOnly
            config.IsReadOnly = false;
            if (!String.IsNullOrEmpty(config.DataBaseName))
            {
                //单数据库模式
                var mongoSingleDbNode = isReplsetMasterServer
                    ? FillDataBaseInfoToTreeNode(config.DataBaseName, mServer,
                        mongoConnKey + "/" + mongoConnKey)
                    : FillDataBaseInfoToTreeNode(config.DataBaseName, mServer,
                        mongoConnKey + "/" + mMasterServerInstace.Address);
                mongoSingleDbNode.Tag = ConstMgr.SINGLE_DATABASE_TAG + ":" + connSvrKey + "/" + config.DataBaseName;
                mongoSingleDbNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Database;
                mongoSingleDbNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Database;
                svrInstanceNode.Nodes.Add(mongoSingleDbNode);
                svrInstanceNode.Tag = ConstMgr.SINGLE_DB_SERVER_TAG + ":" + connSvrKey;
                //获取User信息
                if (config.AuthMode)
                {
                    try
                    {
                        //尝试添加用户信息
                        UserList.AddUser(mongoConn.GetDatabase(config.DataBaseName), config.UserName);
                    }
                    catch
                    {
                        //可能出现没有权限的问题，这里就认为无法取得权限
                    }
                }
            }
            else
            {
                MongoServer instantSrv;
                List<string> databaseNameList;
                if (isReplsetMasterServer)
                {
                    instantSrv = mServer;
                    databaseNameList = mServer.GetDatabaseNames().ToList();
                }
                else
                {
                    var setting = RuntimeMongoDBContext.CreateMongoClientSettingsByConfig(ref config);
                    setting.ConnectionMode = ConnectionMode.Direct;
                    //When Replset Case,Application need to read admin DB information
                    //if Primary,there will be exception
                    setting.ReadPreference = ReadPreference.PrimaryPreferred;
                    setting.Server = mMasterServerInstace.Address;
                    instantSrv = new MongoClient(setting).GetServer();
                    databaseNameList = instantSrv.GetDatabaseNames().ToList();
                }
                foreach (var strDbName in databaseNameList)
                {
                    TreeNode mongoDbNode;
                    try
                    {
                        mongoDbNode = FillDataBaseInfoToTreeNode(strDbName, instantSrv, connSvrKey);
                        mongoDbNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Database;
                        mongoDbNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Database;
                        svrInstanceNode.Nodes.Add(mongoDbNode);
                        if (config.AuthMode)
                        {
                            try
                            {
                                //尝试添加用户信息
                                UserList.AddUser(mongoConn.GetDatabase(strDbName), config.UserName);
                            }
                            catch
                            {
                                //可能出现没有权限的问题，这里就认为无法取得权限
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Utility.ExceptionDeal(ex, strDbName + "Exception", strDbName + "Exception");
                        mongoDbNode = new TreeNode(strDbName + " (Exception)")
                        {
                            ImageIndex = (int) GetSystemIcon.MainTreeImageType.Database,
                            SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Database
                        };
                        svrInstanceNode.Nodes.Add(mongoDbNode);
                    }
                }
                if (isReplsetMasterServer)
                {
                    svrInstanceNode.Tag = ConstMgr.SERVER_TAG + ":" + mongoConnKey + "/" + mongoConnKey;
                }
                else
                {
                    if (mongoConn.ReplicaSetName != null)
                    {
                        svrInstanceNode.Tag = ConstMgr.SERVER_REPLSET_MEMBER_TAG + ":" + mongoConnKey + "/" +
                                              mMasterServerInstace.Address.ToString().Replace(":", "@");
                    }
                }
            }
//			if (MongoDbHelper._mongoInstanceLst.ContainsKey(connSvrKey)) {
//				MongoDbHelper._mongoInstanceLst.Remove(connSvrKey);
//			}
//			if (!isReplsetMasterServer) {
//				MongoDbHelper._mongoInstanceLst.Add(connSvrKey, mMasterServerInstace);
//			}
            return svrInstanceNode;
        }

        #endregion
    }
}