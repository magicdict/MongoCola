using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using MongoUtility.Security;
using ResourceLib.Method;

namespace MongoGUICtl
{
    public static partial class UiHelper
    {
        #region"展示数据库结构 Winform"

        /// <summary>
        ///     将数据放入TreeView里进行展示
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="trvData" />
        /// <param name="dataList"></param>
        public static void FillDataToTreeView(string collectionName, CtlTreeViewColumns trvData, BsonDocument dataList)
        {
            var docList = new List<BsonDocument>();
            docList.Add(dataList);
            FillDataToTreeView(collectionName, trvData, docList, 0);
        }

        /// <summary>
        ///     将数据放入TreeView里进行展示
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="trvData"></param>
        /// <param name="dataList"></param>
        /// <param name="mSkip"></param>
        public static void FillDataToTreeView(string collectionName, CtlTreeViewColumns trvData,
            List<BsonDocument> dataList, int mSkip)
        {
            trvData.DatatreeView.BeginUpdate();
            trvData.DatatreeView.Nodes.Clear();
            var skipCnt = mSkip;
            var count = 1;
            foreach (var item in dataList)
            {
                var dataNode = new TreeNode(collectionName + "[" + (skipCnt + count) + "]");
                //这里保存真实的主Key数据，删除的时候使用
                switch (collectionName)
                {
                    case ConstMgr.CollectionNameGfsFiles:
                        dataNode.Tag = item.GetElement(1).Value;
                        break;
                    case ConstMgr.CollectionNameUser:
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
                        item.TryGetElement(ConstMgr.KeyId, out id);
                        dataNode.Tag = (id.Value != null) ? id.Value : item.GetElement(0).Value;
                        break;
                }
                AddBsonDocToTreeNode(dataNode, item);
                trvData.DatatreeView.Nodes.Add(dataNode);
                count++;
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
                        var newItem = new TreeNode(item.Name + ConstMgr.ArrayMark);
                        AddBsonArrayToTreeNode(item.Name, newItem, item.Value.AsBsonArray);
                        newItem.Tag = item;
                        treeNode.Nodes.Add(newItem);
                    }
                    else
                    {
                        var elementNode = new TreeNode(item.Name);
                        elementNode.Tag = item;
                        treeNode.Nodes.Add(elementNode);
                    }
                }
            }
        }

        /// <summary>
        ///     将BsonArray放入树形控件
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="item"></param>
        public static void AddBsonArrayToTreeNode(string arrayName, TreeNode newItem, BsonArray item)
        {
            var count = 1;
            foreach (var subItem in item)
            {
                if (subItem.IsBsonDocument)
                {
                    var newSubItem = new TreeNode(arrayName + "[" + count + "]");
                    AddBsonDocToTreeNode(newSubItem, subItem.ToBsonDocument());
                    newSubItem.Tag = subItem;
                    newItem.Nodes.Add(newSubItem);
                }
                else
                {
                    if (subItem.IsBsonArray)
                    {
                        var newSubItem = new TreeNode(ConstMgr.ArrayMark);
                        AddBsonArrayToTreeNode(arrayName, newSubItem, subItem.AsBsonArray);
                        newSubItem.Tag = subItem;
                        newItem.Nodes.Add(newSubItem);
                    }
                    else
                    {
                        var newSubItem = new TreeNode(arrayName + "[" + count + "]") {Tag = subItem};
                        newItem.Nodes.Add(newSubItem);
                    }
                }
                count++;
            }
        }

        /// <summary>
        ///     After Legacy
        ///     获取将Mongodb的服务器在树形控件中展示的TreeNodes
        /// </summary>
        /// <param name="mongoConnClientLst"></param>
        /// <param name="mongoConConfigLst"></param>
        /// <returns></returns>
        public static List<TreeNode> GetConnectionNodes(Dictionary<string, MongoClient> mongoConnClientLst,
            Dictionary<string, MongoConnectionConfig> mongoConConfigLst)
        {
            var connectionNodes = new List<TreeNode>();
            foreach (var mongoConnKey in mongoConnClientLst.Keys)
            {
                var mongoSrv = mongoConnClientLst[mongoConnKey];
                var connectionNode = new TreeNode();
                var userList = new EachDatabaseUser();
                try
                {
                    //ReplSetName只能使用在虚拟的Replset服务器，Sharding体系等无效。虽然一个Sharding可以看做一个ReplSet
                    var config = mongoConConfigLst[mongoConnKey];
                    connectionNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Connection;
                    connectionNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Connection;
                    //ReplSet服务器需要Connect才能连接。可能因为这个是虚拟的服务器，没有Mongod实体。
                    //不过现在改为全部显示的打开连接
                    connectionNode.Text = mongoConnKey;
                    //形成树型菜单的方法
                    //ConnectionNode.Nodes.Add();
                    config.ServerRole = MongoConnectionConfig.SvrRoleType.DataSvr;
                    connectionNode.Tag = ConstMgr.ConnectionTag + ":" + config.ConnectionName;
                    //设定是否可用
                    config.Health = true;
                    mongoConConfigLst[mongoConnKey] = config;
                    switch (config.ServerRole)
                    {
                        case MongoConnectionConfig.SvrRoleType.DataSvr:
                            connectionNode.Text = "[Data]  " + connectionNode.Text;
                            break;
                        case MongoConnectionConfig.SvrRoleType.ShardSvr:
                            connectionNode.Text = "[Cluster]  " + connectionNode.Text;
                            break;
                        case MongoConnectionConfig.SvrRoleType.ReplsetSvr:
                            connectionNode.Text = "[Replset]  " + connectionNode.Text;
                            break;
                        case MongoConnectionConfig.SvrRoleType.MasterSvr:
                            connectionNode.Text = "[Master]  " + connectionNode.Text;
                            break;
                        case MongoConnectionConfig.SvrRoleType.SlaveSvr:
                            connectionNode.Text = "[Slave]  " + connectionNode.Text;
                            break;
                    }
                    connectionNodes.Add(connectionNode);
                    if (RuntimeMongoDbContext.MongoUserLst.ContainsKey(mongoConnKey))
                    {
                        RuntimeMongoDbContext.MongoUserLst[mongoConnKey] = userList;
                    }
                    else
                    {
                        RuntimeMongoDbContext.MongoUserLst.Add(mongoConnKey, userList);
                    }
                }
                catch (MongoAuthenticationException ex)
                {
                    AuthenticationExceptionHandler(ex, connectionNodes, connectionNode, mongoConnKey);
                }
                catch (MongoCommandException ex)
                {
                    MongoCommandExceptionHandle(ex, connectionNodes, connectionNode, mongoConnKey);
                }
                catch (MongoConnectionException ex)
                {
                    MongoConnectionExceptionHandle(ex, connectionNodes, connectionNode, mongoConnKey);
                }
                catch (Exception ex)
                {
                    ExceptionHandle(ex, connectionNodes, connectionNode, mongoConnKey);
                }
            }
            return connectionNodes;
        }


        /// <summary>
        ///     Legacy
        ///     获取将Mongodb的服务器在树形控件中展示的TreeNodes
        /// </summary>
        /// <param name="mongoConnSvrLst"></param>
        /// <param name="mongoConConfigLst"></param>
        /// <returns></returns>
        public static List<TreeNode> GetConnectionNodes(Dictionary<string, MongoServer> mongoConnSvrLst,
            Dictionary<string, MongoConnectionConfig> mongoConConfigLst)
        {
            var connectionNodes = new List<TreeNode>();
            foreach (var mongoConnKey in mongoConnSvrLst.Keys)
            {
                var mongoSrv = mongoConnSvrLst[mongoConnKey];
                var connectionNode = new TreeNode();
                var userList = new EachDatabaseUser();
                var isConnected = false;
                try
                {
                    //ReplSetName只能使用在虚拟的Replset服务器，Sharding体系等无效。虽然一个Sharding可以看做一个ReplSet
                    var config = mongoConConfigLst[mongoConnKey];
                    connectionNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Connection;
                    connectionNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Connection;
                    //ReplSet服务器需要Connect才能连接。可能因为这个是虚拟的服务器，没有Mongod实体。
                    //不过现在改为全部显示的打开连接
                    mongoSrv.Connect();
                    isConnected = true;
                    //mongoSvr.ReplicaSetName只有在连接后才有效，但是也可以使用Config.ReplsetName
                    connectionNode.Text = mongoConnKey;
                    //形成树型菜单
                    var singleConnection = GetInstanceNode(mongoConnKey, ref config, mongoSrv, null, mongoSrv, userList);
                    connectionNode.Nodes.Add(singleConnection);
                    if (mongoSrv.ReplicaSetName != null)
                    {
                        config = FillReplset(mongoConnKey, mongoSrv, connectionNode, userList, config);
                    }
                    else
                    {
                        var serverStatusDoc =
                            CommandHelper.ExecuteMongoSvrCommand(CommandHelper.ServerStatusCommand, mongoSrv).Response;
                        //ServerStatus可能没有权限打开
                        if (serverStatusDoc.Contains("process") &&
                            serverStatusDoc.GetElement("process").Value == ConstMgr.ServerStatusProcessMongos)
                        {
                            config = FillShards(mongoConnKey, mongoSrv, connectionNode, userList, config);
                        }
                        else
                        {
                            FillNormal(connectionNode, config, serverStatusDoc);
                        }
                    }
                    //设定是否可用
                    config.Health = true;
                    //设定版本
                    if (mongoSrv.BuildInfo != null)
                    {
                        config.MongoDbVersion = mongoSrv.BuildInfo.Version;
                    }
                    mongoConConfigLst[mongoConnKey] = config;
                    switch (config.ServerRole)
                    {
                        case MongoConnectionConfig.SvrRoleType.DataSvr:
                            connectionNode.Text = "[Data]  " + connectionNode.Text;
                            break;
                        case MongoConnectionConfig.SvrRoleType.ShardSvr:
                            connectionNode.Text = "[Cluster]  " + connectionNode.Text;
                            break;
                        case MongoConnectionConfig.SvrRoleType.ReplsetSvr:
                            connectionNode.Text = "[Replset]  " + connectionNode.Text;
                            break;
                        case MongoConnectionConfig.SvrRoleType.MasterSvr:
                            connectionNode.Text = "[Master]  " + connectionNode.Text;
                            break;
                        case MongoConnectionConfig.SvrRoleType.SlaveSvr:
                            connectionNode.Text = "[Slave]  " + connectionNode.Text;
                            break;
                    }
                    connectionNodes.Add(connectionNode);
                    if (RuntimeMongoDbContext.MongoUserLst.ContainsKey(mongoConnKey))
                    {
                        RuntimeMongoDbContext.MongoUserLst[mongoConnKey] = userList;
                    }
                    else
                    {
                        RuntimeMongoDbContext.MongoUserLst.Add(mongoConnKey, userList);
                    }
                }
                catch (MongoAuthenticationException ex)
                {
                    AuthenticationExceptionHandler(ex, connectionNodes, connectionNode, mongoConnKey);
                    connectionNodes = null;
                }
                catch (MongoCommandException ex)
                {
                    MongoCommandExceptionHandle(ex, connectionNodes, connectionNode, mongoConnKey);
                    connectionNodes = null;
                }
                catch (MongoConnectionException ex)
                {
                    MongoConnectionExceptionHandle(ex, connectionNodes, connectionNode, mongoConnKey);
                    connectionNodes = null;
                }
                catch (Exception ex)
                {
                    ExceptionHandle(ex, connectionNodes, connectionNode, mongoConnKey);
                    connectionNodes = null;
                }
                finally
                {
                    if (isConnected)
                        mongoSrv.Disconnect();
                }
            }
            return connectionNodes;
        }

        private static void FillNormal(TreeNode connectionNode, MongoConnectionConfig config,
            BsonDocument serverStatusDoc)
        {
            //Server Status mongod
            //Master - Slave 的判断
            BsonElement replElement;
            serverStatusDoc.TryGetElement("repl", out replElement);
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
            connectionNode.Tag = ConstMgr.ConnectionTag + ":" + config.ConnectionName;
        }

        private static MongoConnectionConfig FillShards(string mongoConnKey, MongoServer mongoSrv,
            TreeNode connectionNode, EachDatabaseUser userList, MongoConnectionConfig config)
        {
            //Shard的时候，必须将所有服务器的ReadPreferred设成可读
            config.ServerRole = MongoConnectionConfig.SvrRoleType.ShardSvr;
            connectionNode.Tag = ConstMgr.ConnectionClusterTag + ":" + config.ConnectionName;
            var shardListNode = new TreeNode("Shards")
            {
                SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers,
                ImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers
            };
            foreach (var lst in OperationHelper.GetShardInfo(mongoSrv, "host"))
            {
                var shardNode = new TreeNode
                {
                    Text = lst.Key,
                    SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers,
                    ImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers
                };
                var strHostList = lst.Value;
                var strAddress = strHostList.Split("/".ToCharArray());
                string strAddresslst;
                if (strAddress.Length == 2)
                {
                    //#1  replset/host:port,host:port
                    shardNode.Text += "[Replset:" + strAddress[0] + "]";
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
                    MongoServerAddress secondaryAddr;
                    if (item.Split(":".ToCharArray()).Length == 2)
                    {
                        secondaryAddr = new MongoServerAddress(item.Split(":".ToCharArray())[0],
                            Convert.ToInt32(item.Split(":".ToCharArray())[1]));
                    }
                    else
                    {
                        secondaryAddr = new MongoServerAddress(item.Split(":".ToCharArray())[0]);
                    }
                    tinySetting.Server = secondaryAddr;
                    var replsetMember = new MongoClient(tinySetting).GetServer();
                    shardNode.Nodes.Add(GetInstanceNode(mongoConnKey, ref config, mongoSrv,
                        replsetMember.Instance, null, userList));
                }
                shardListNode.Nodes.Add(shardNode);
            }
            connectionNode.Nodes.Add(shardListNode);
            return config;
        }

        private static MongoConnectionConfig FillReplset(string mongoConnKey, MongoServer mongoSrv,
            TreeNode connectionNode, EachDatabaseUser userList, MongoConnectionConfig config)
        {
            connectionNode.Tag = ConstMgr.ConnectionReplsetTag + ":" + config.ConnectionName;
            var serverListNode = new TreeNode("Servers")
            {
                SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers,
                ImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers
            };
            foreach (var serverInstace in mongoSrv.Instances)
            {
                serverListNode.Nodes.Add(GetInstanceNode(mongoConnKey, ref config, mongoSrv, serverInstace,
                    null, userList));
            }
            connectionNode.Nodes.Add(serverListNode);
            config.ServerRole = MongoConnectionConfig.SvrRoleType.ReplsetSvr;
            return config;
        }

        private static void AuthenticationExceptionHandler(MongoAuthenticationException ex,
            List<TreeNode> trvMongoDb,
            TreeNode connectionNode,
            string mongoConnKey)
        {
            //需要验证的数据服务器，没有Admin权限无法获得数据库列表
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                connectionNode.Text += "[" +
                                       GuiConfig.MStringResource.GetText(
                                           TextType.ExceptionAuthenticationException) + "]";
                Utility.ExceptionDeal(ex,
                    GuiConfig.MStringResource.GetText(
                        TextType.ExceptionAuthenticationException),
                    GuiConfig.MStringResource.GetText(
                        TextType.ExceptionAuthenticationExceptionNote));
            }
            else
            {
                connectionNode.Text += "[MongoAuthenticationException]";
                Utility.ExceptionDeal(ex, "MongoAuthenticationException:", "Please check UserName and Password");
            }
            connectionNode.Tag = ConstMgr.ConnectionExceptionTag + ":" + mongoConnKey;
            trvMongoDb.Add(connectionNode);
        }

        private static string MongoCommandExceptionHandle(MongoCommandException ex,
            List<TreeNode> trvMongoDb,
            TreeNode connectionNode,
            string mongoConnKey)
        {
            //listDatabase命令错误，本质是用户名称错误
            if (ex.Result["errmsg"] == "unauthorized")
            {
                if (!GuiConfig.IsUseDefaultLanguage)
                {
                    connectionNode.Text += "[" +
                                           GuiConfig.MStringResource.GetText(
                                               TextType.ExceptionAuthenticationException) + "]";
                    Utility.ExceptionDeal(ex,
                        GuiConfig.MStringResource.GetText(
                            TextType.ExceptionAuthenticationException),
                        GuiConfig.MStringResource.GetText(
                            TextType.ExceptionAuthenticationExceptionNote));
                }
                else
                {
                    connectionNode.Text += "[MongoCommandExceptionHandle]";
                    Utility.ExceptionDeal(ex, "MongoCommandExceptionHandle:", "Please check UserName and Password");
                }
            }
            else
            {
                if (!GuiConfig.IsUseDefaultLanguage)
                {
                    connectionNode.Text += "[" +
                                           GuiConfig.MStringResource.GetText(
                                               TextType.ExceptionNotConnected) + "]";
                    Utility.ExceptionDeal(ex,
                        GuiConfig.MStringResource.GetText(TextType.ExceptionNotConnected),
                        "Unknown Exception");
                }
                else
                {
                    connectionNode.Text += "[Exception]";
                    Utility.ExceptionDeal(ex, "Not Connected", "Unknown Exception");
                }
            }
            connectionNode.Tag = ConstMgr.ConnectionExceptionTag + ":" + mongoConnKey;
            trvMongoDb.Add(connectionNode);
            return mongoConnKey;
        }

        private static string MongoConnectionExceptionHandle(MongoConnectionException ex,
            List<TreeNode> trvMongoDb,
            TreeNode connectionNode, string mongoConnKey)
        {
            //暂时不处理任何异常，简单跳过
            //无法连接的理由：
            //1.服务器没有启动
            //2.认证模式不正确
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                connectionNode.Text += "[" +
                                       GuiConfig.MStringResource.GetText(
                                           TextType.ExceptionNotConnected) + "]";
                Utility.ExceptionDeal(ex,
                    GuiConfig.MStringResource.GetText(TextType.ExceptionNotConnected),
                    GuiConfig.MStringResource.GetText(TextType.ExceptionNotConnectedNote));
            }
            else
            {
                connectionNode.Text += "[Exception]";
                Utility.ExceptionDeal(ex, "Not Connected", "Mongo Server may not Startup or Auth Mode is not correct");
            }
            connectionNode.Tag = ConstMgr.ConnectionExceptionTag + ":" + mongoConnKey;
            trvMongoDb.Add(connectionNode);
            return mongoConnKey;
        }

        private static void ExceptionHandle(Exception ex,
            List<TreeNode> trvMongoDb,
            TreeNode connectionNode, string mongoConnKey)
        {
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                connectionNode.Text += "[" +
                                       GuiConfig.MStringResource.GetText(
                                           TextType.ExceptionNotConnected) + "]";
                Utility.ExceptionDeal(ex,
                    GuiConfig.MStringResource.GetText(TextType.ExceptionNotConnected),
                    "Unknown Exception");
            }
            else
            {
                connectionNode.Text += "[Exception]";
                Utility.ExceptionDeal(ex, "Not Connected", "Unknown Exception");
            }
            connectionNode.Tag = ConstMgr.ConnectionExceptionTag + ":" + mongoConnKey;
            trvMongoDb.Add(connectionNode);
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
        /// <param name="userList"></param>
        /// <returns></returns>
        private static TreeNode GetInstanceNode(string mongoConnKey,
            ref MongoConnectionConfig config,
            MongoServer mongoConn,
            MongoServerInstance mMasterServerInstace,
            MongoServer mServer,
            EachDatabaseUser userList)
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
            if (!string.IsNullOrEmpty(config.UserName) & (!string.IsNullOrEmpty(config.Password)))
            {
                //是否是认证模式，应该取决于服务器！
                config.AuthMode = true;
            }
            //获取ReadOnly
            config.IsReadOnly = false;
            if (!string.IsNullOrEmpty(config.DataBaseName))
            {
                //单数据库模式
                var mongoSingleDbNode = isReplsetMasterServer
                    ? FillDataBaseInfoToTreeNode(config.DataBaseName, mongoConnKey + "/" + mongoConnKey, null)
                    : FillDataBaseInfoToTreeNode(config.DataBaseName, mongoConnKey + "/" + mMasterServerInstace.Address,
                        null);
                mongoSingleDbNode.Tag = ConstMgr.SingleDatabaseTag + ":" + connSvrKey + "/" + config.DataBaseName;
                mongoSingleDbNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Database;
                mongoSingleDbNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Database;
                svrInstanceNode.Nodes.Add(mongoSingleDbNode);
                svrInstanceNode.Tag = ConstMgr.SingleDbServerTag + ":" + connSvrKey;
                //获取User信息
                if (config.AuthMode)
                {
                    try
                    {
                        //尝试添加用户信息
                        userList.AddUser(mongoConn.GetDatabase(config.DataBaseName), config.UserName);
                    }
                    catch
                    {
                        //可能出现没有权限的问题，这里就认为无法取得权限
                    }
                }
            }
            else
            {
                List<BsonDocument> databaseNameList;
                var setting = RuntimeMongoDbContext.CreateMongoClientSettingsByConfig(ref config);
                var client = new MongoClient(setting);
                //if (isReplsetMasterServer)
                //{
                //    MongoServer instantSrv;
                //    instantSrv = mServer;
                //    //databaseNameList = mServer.GetDatabaseNames().ToList();
                //}
                //else
                //{
                //var setting = RuntimeMongoDBContext.CreateMongoClientSettingsByConfig(ref config);
                //setting.ConnectionMode = ConnectionMode.Direct;
                //When Replset Case,Application need to read admin DB information
                //if Primary,there will be exception
                //setting.ReadPreference = ReadPreference.PrimaryPreferred;
                //setting.Server = mMasterServerInstace.Address;
                databaseNameList = GetConnectionInfo.GetDatabaseList(client);
                //}
                foreach (var strDbName in databaseNameList)
                {
                    TreeNode mongoDbNode;
                    try
                    {
                        var dbName = strDbName.GetElement("name").Value.ToString();
                        mongoDbNode = FillDataBaseInfoToTreeNode(dbName, connSvrKey, client);
                        mongoDbNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Database;
                        mongoDbNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Database;
                        svrInstanceNode.Nodes.Add(mongoDbNode);
                        if (config.AuthMode)
                        {
                            try
                            {
                                //尝试添加用户信息
                                userList.AddUser(mongoConn.GetDatabase(dbName), config.UserName);
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
                    svrInstanceNode.Tag = ConstMgr.ServerTag + ":" + mongoConnKey + "/" + mongoConnKey;
                }
                else
                {
                    if (mongoConn.ReplicaSetName != null)
                    {
                        svrInstanceNode.Tag = ConstMgr.ServerReplsetMemberTag + ":" + mongoConnKey + "/" +
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