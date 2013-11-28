using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        #region"展示数据库结构 Winform"
        /// <summary>
        /// 将Mongodb的服务器在树形控件中展示
        /// </summary>
        /// <param name="trvMongoDB"></param>
        public static void FillConnectionToTreeView(TreeView trvMongoDB)
        {
            trvMongoDB.Nodes.Clear();
            foreach (String mongoConnKey in _mongoConnSvrLst.Keys)
            {
                MongoServer mongoSrv = _mongoConnSvrLst[mongoConnKey];
                TreeNode ConnectionNode = new TreeNode();
                EachDatabaseUser UserList = new EachDatabaseUser();
                try
                {
                    //ReplSetName只能使用在虚拟的Replset服务器，Sharding体系等无效。虽然一个Sharding可以看做一个ReplSet
                    ConfigHelper.MongoConnectionConfig config = SystemManager.ConfigHelperInstance.ConnectionList[mongoConnKey];
                    ConnectionNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Connection;
                    ConnectionNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Connection;
                    //ReplSet服务器需要Connect才能连接。可能因为这个是虚拟的服务器，没有Mongod实体。
                    //不过现在改为全部显示的打开连接
                    mongoSrv.Connect();
                    ///mongoSvr.ReplicaSetName只有在连接后才有效，但是也可以使用Config.ReplsetName
                    ConnectionNode.Text = mongoConnKey;
                    ConnectionNode.Nodes.Add(GetInstanceNode(mongoConnKey, ref config, mongoSrv, null, mongoSrv, UserList));
                    if (mongoSrv.ReplicaSetName != null)
                    {
                        ConnectionNode.Tag = CONNECTION_REPLSET_TAG + ":" + config.ConnectionName;
                        TreeNode ServerListNode = new TreeNode("Servers");
                        ServerListNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Servers;
                        ServerListNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Servers;
                        foreach (MongoServerInstance ServerInstace in mongoSrv.Instances)
                        {
                            ServerListNode.Nodes.Add(GetInstanceNode(mongoConnKey, ref config, mongoSrv, ServerInstace, null, UserList));
                        }
                        ConnectionNode.Nodes.Add(ServerListNode);
                        config.ServerRole = ConfigHelper.SvrRoleType.ReplsetSvr;
                    }
                    else
                    {
                        BsonDocument ServerStatusDoc = ExecuteMongoSvrCommand(serverStatus_Command, mongoSrv).Response;
                        //ServerStatus可能没有权限打开
                        if (ServerStatusDoc.Contains("process") && ServerStatusDoc.GetElement("process").Value == ServerStatus_PROCESS_MONGOS)
                        {
                            //Shard的时候，必须将所有服务器的ReadPreferred设成可读
                            config.ServerRole = ConfigHelper.SvrRoleType.ShardSvr;
                            ConnectionNode.Tag = CONNECTION_CLUSTER_TAG + ":" + config.ConnectionName;
                            TreeNode ShardListNode = new TreeNode("Shards");
                            ShardListNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Servers;
                            ShardListNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Servers;
                            foreach (var lst in GetShardInfo(mongoSrv, "host"))
                            {
                                TreeNode ShardNode = new TreeNode();
                                ShardNode.Text = lst.Key;
                                ShardNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Servers;
                                ShardNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Servers;
                                String strHostList = lst.Value.ToString();
                                String[] strAddress = strHostList.Split("/".ToCharArray());
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
                                foreach (String item in strAddresslst.Split(",".ToCharArray()))
                                {
                                    MongoClientSettings tinySetting = new MongoClientSettings();
                                    tinySetting.ConnectionMode = ConnectionMode.Direct;
                                    //防止无法读取Sharding状态。Sharding可能是一个Slaver
                                    tinySetting.ReadPreference = ReadPreference.PrimaryPreferred;
                                    tinySetting.ReplicaSetName = strAddress[0];
                                    MongoServerAddress SecondaryAddr;
                                    if (item.Split(":".ToCharArray()).Length == 2)
                                    {
                                        SecondaryAddr = new MongoServerAddress(item.Split(":".ToCharArray())[0], Convert.ToInt32(item.Split(":".ToCharArray())[1]));
                                    }
                                    else
                                    {
                                        SecondaryAddr = new MongoServerAddress(item.Split(":".ToCharArray())[0]);
                                    }
                                    tinySetting.Server = SecondaryAddr;
                                    MongoServer ReplsetMember = new MongoClient(tinySetting).GetServer();
                                    ShardNode.Nodes.Add(GetInstanceNode(mongoConnKey, ref config, mongoSrv, ReplsetMember.Instance, null, UserList));
                                }
                                ShardListNode.Nodes.Add(ShardNode);
                            }
                            ConnectionNode.Nodes.Add(ShardListNode);
                        }
                        else
                        {
                            ///Server Status mongod
                            ///Master - Slave 的判断
                            BsonElement replElement;
                            ServerStatusDoc.TryGetElement("repl", out replElement);
                            if (replElement == null)
                            {
                                config.ServerRole = ConfigHelper.SvrRoleType.DataSvr;
                            }
                            else
                            {
                                if (replElement.Value.AsBsonDocument.GetElement("ismaster").Value == BsonBoolean.True)
                                {
                                    config.ServerRole = ConfigHelper.SvrRoleType.MasterSvr;
                                }
                                else
                                {
                                    //ismaster 的值不一定是True和False...
                                    config.ServerRole = ConfigHelper.SvrRoleType.SlaveSvr;
                                }
                            }
                            ConnectionNode.Tag = CONNECTION_TAG + ":" + config.ConnectionName;
                        }
                    }
                    //设定是否可用
                    config.Health = true;
                    //设定版本
                    if (mongoSrv.BuildInfo != null)
                    {
                        config.MongoDBVersion = mongoSrv.BuildInfo.Version;
                    }
                    SystemManager.ConfigHelperInstance.ConnectionList[mongoConnKey] = config;
                    switch (config.ServerRole)
                    {
                        case ConfigHelper.SvrRoleType.DataSvr:
                            ConnectionNode.Text = "[Data]  " + ConnectionNode.Text;
                            break;
                        case ConfigHelper.SvrRoleType.ShardSvr:
                            ConnectionNode.Text = "[Cluster]  " + ConnectionNode.Text;
                            break;
                        case ConfigHelper.SvrRoleType.ReplsetSvr:
                            ConnectionNode.Text = "[Replset]  " + ConnectionNode.Text;
                            break;
                        case ConfigHelper.SvrRoleType.MasterSvr:
                            ConnectionNode.Text = "[Master]  " + ConnectionNode.Text;
                            break;
                        case ConfigHelper.SvrRoleType.SlaveSvr:
                            ConnectionNode.Text = "[Slave]  " + ConnectionNode.Text;
                            break;
                        default:
                            break;
                    }
                    trvMongoDB.Nodes.Add(ConnectionNode);
                    if (_mongoUserLst.ContainsKey(mongoConnKey))
                    {
                        _mongoUserLst[mongoConnKey] = UserList;
                    }
                    else
                    {
                        _mongoUserLst.Add(mongoConnKey, UserList);
                    }
                }
                catch (MongoAuthenticationException ex)
                {
                    //需要验证的数据服务器，没有Admin权限无法获得数据库列表
                    if (!SystemManager.IsUseDefaultLanguage)
                    {
                        ConnectionNode.Text += "[" + SystemManager.mStringResource.GetText(StringResource.TextType.Exception_AuthenticationException) + "]";
                        SystemManager.ExceptionDeal(ex, SystemManager.mStringResource.GetText(StringResource.TextType.Exception_AuthenticationException),
                                                       SystemManager.mStringResource.GetText(StringResource.TextType.Exception_AuthenticationException_Note));
                    }
                    else
                    {
                        ConnectionNode.Text += "[MongoAuthenticationException]";
                        SystemManager.ExceptionDeal(ex, "MongoAuthenticationException:", "Please check UserName and Password");
                    }
                    ConnectionNode.Tag = CONNECTION_EXCEPTION_TAG + ":" + mongoConnKey;
                    trvMongoDB.Nodes.Add(ConnectionNode);
                }
                catch (MongoCommandException ex)
                {
                    //listDatabase命令错误，本质是用户名称错误
                    if (ex.CommandResult.Response["errmsg"] == "unauthorized")
                    {
                        if (!SystemManager.IsUseDefaultLanguage)
                        {
                            ConnectionNode.Text += "[" + SystemManager.mStringResource.GetText(StringResource.TextType.Exception_AuthenticationException) + "]";
                            SystemManager.ExceptionDeal(ex, SystemManager.mStringResource.GetText(StringResource.TextType.Exception_AuthenticationException),
                                                           SystemManager.mStringResource.GetText(StringResource.TextType.Exception_AuthenticationException_Note));
                        }
                        else
                        {
                            ConnectionNode.Text += "[MongoAuthenticationException]";
                            SystemManager.ExceptionDeal(ex, "MongoAuthenticationException:", "Please check UserName and Password");
                        }
                    }
                    else
                    {
                        if (!SystemManager.IsUseDefaultLanguage)
                        {
                            ConnectionNode.Text += "[" + SystemManager.mStringResource.GetText(StringResource.TextType.Exception_NotConnected) + "]";
                            SystemManager.ExceptionDeal(ex, SystemManager.mStringResource.GetText(StringResource.TextType.Exception_NotConnected),
                                                            "Unknown Exception");
                        }
                        else
                        {
                            ConnectionNode.Text += "[Exception]";
                            SystemManager.ExceptionDeal(ex, "Not Connected", "Unknown Exception");
                        }
                    }
                    ConnectionNode.Tag = CONNECTION_EXCEPTION_TAG + ":" + mongoConnKey;
                    trvMongoDB.Nodes.Add(ConnectionNode);
                }
                catch (MongoConnectionException ex)
                {
                    //暂时不处理任何异常，简单跳过
                    //无法连接的理由：
                    //1.服务器没有启动
                    //2.认证模式不正确
                    if (!SystemManager.IsUseDefaultLanguage)
                    {
                        ConnectionNode.Text += "[" + SystemManager.mStringResource.GetText(StringResource.TextType.Exception_NotConnected) + "]";
                        SystemManager.ExceptionDeal(ex, SystemManager.mStringResource.GetText(StringResource.TextType.Exception_NotConnected),
                                                       SystemManager.mStringResource.GetText(StringResource.TextType.Exception_NotConnected_Note));
                    }
                    else
                    {
                        ConnectionNode.Text += "[Exception]";
                        SystemManager.ExceptionDeal(ex, "Not Connected", "Mongo Server may not Startup or Auth Mode is not correct");
                    }
                    ConnectionNode.Tag = CONNECTION_EXCEPTION_TAG + ":" + mongoConnKey;
                    trvMongoDB.Nodes.Add(ConnectionNode);
                }
                catch (Exception ex)
                {
                    if (!SystemManager.IsUseDefaultLanguage)
                    {
                        ConnectionNode.Text += "[" + SystemManager.mStringResource.GetText(StringResource.TextType.Exception_NotConnected) + "]";
                        SystemManager.ExceptionDeal(ex, SystemManager.mStringResource.GetText(StringResource.TextType.Exception_NotConnected),
                                                        "Unknown Exception");
                    }
                    else
                    {
                        ConnectionNode.Text += "[Exception]";
                        SystemManager.ExceptionDeal(ex, "Not Connected", "Unknown Exception");
                    }
                    ConnectionNode.Tag = CONNECTION_EXCEPTION_TAG + ":" + mongoConnKey;
                    trvMongoDB.Nodes.Add(ConnectionNode);
                }
            }
        }
        /// <summary>
        /// 获取实例节点
        /// </summary>
        /// <param name="mongoConnKey"></param>
        /// <param name="config">由于是结构体，必须ref</param>
        /// <param name="mongoConn"></param>
        /// <param name="mMasterServerInstace"></param>
        /// <param name="mServer"></param>
        /// <param name="UserList"></param>
        /// <returns></returns>
        private static TreeNode GetInstanceNode(String mongoConnKey,
                                                ref ConfigHelper.MongoConnectionConfig config,
                                                MongoServer mongoConn,
                                                MongoServerInstance mMasterServerInstace,
                                                MongoServer mServer,
                                                EachDatabaseUser UserList)
        {
            Boolean isReplsetMasterServer = false;
            //无论如何，都改为主要服务器读优先
            if (mMasterServerInstace == null)
            {
                isReplsetMasterServer = true;
            }
            TreeNode SvrInstanceNode = new TreeNode();
            String ConnSvrKey;
            if (isReplsetMasterServer)
            {
                ConnSvrKey = mongoConnKey + "/" + mongoConnKey;
            }
            else
            {
                ConnSvrKey = mongoConnKey + "/" + mMasterServerInstace.Address.ToString().Replace(":", "@");
            }
            SvrInstanceNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.WebServer;
            SvrInstanceNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.WebServer;
            if (isReplsetMasterServer)
            {
                SvrInstanceNode.Text = "Connection";
            }
            else
            {
                SvrInstanceNode.Text = "Server[" + mMasterServerInstace.Address.ToString() + "]";
            }
            if ((!String.IsNullOrEmpty(config.UserName)) & (!String.IsNullOrEmpty(config.Password)))
            {
                //是否是认证模式，应该取决于服务器！
                config.AuthMode = true;
            }
            //获取ReadOnly
            config.IsReadOnly = false;
            List<String> databaseNameList = new List<String>();
            if (!String.IsNullOrEmpty(config.DataBaseName))
            {
                //单数据库模式
                TreeNode mongoSingleDBNode;
                if (isReplsetMasterServer)
                {
                    mongoSingleDBNode = FillDataBaseInfoToTreeNode(config.DataBaseName, mServer, mongoConnKey + "/" + mongoConnKey);
                }
                else
                {
                    mongoSingleDBNode = FillDataBaseInfoToTreeNode(config.DataBaseName, mServer, mongoConnKey + "/" + mMasterServerInstace.Address.ToString());
                }
                mongoSingleDBNode.Tag = SINGLE_DATABASE_TAG + ":" + ConnSvrKey + "/" + config.DataBaseName;
                mongoSingleDBNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
                mongoSingleDBNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
                SvrInstanceNode.Nodes.Add(mongoSingleDBNode);
                SvrInstanceNode.Tag = SINGLE_DB_SERVER_TAG + ":" + ConnSvrKey;
                ///获取User信息
                if (config.AuthMode)
                {
                    try
                    {
                        ///尝试添加用户信息
                        UserList.AddUser(mongoConn.GetDatabase(config.DataBaseName), config.UserName);
                    }
                    catch (Exception)
                    {
                        //可能出现没有权限的问题，这里就认为无法取得权限
                    }
                }
            }
            else
            {
                MongoServer InstantSrv;
                if (isReplsetMasterServer)
                {
                    InstantSrv = mServer;
                    databaseNameList = mServer.GetDatabaseNames().ToList<String>();
                }
                else
                {
                    MongoClientSettings setting = CreateMongoClientSettingsByConfig(ref config);
                    setting.ConnectionMode = ConnectionMode.Direct;
                    //When Replset Case,Application need to read admin DB information
                    //if Primary,there will be exception
                    setting.ReadPreference = ReadPreference.PrimaryPreferred;
                    setting.Server = mMasterServerInstace.Address;
                    InstantSrv = new MongoClient(setting).GetServer();
                    databaseNameList = InstantSrv.GetDatabaseNames().ToList<String>();
                }
                foreach (String strDBName in databaseNameList)
                {
                    TreeNode mongoDBNode;
                    try
                    {
                        mongoDBNode = FillDataBaseInfoToTreeNode(strDBName, InstantSrv, ConnSvrKey);
                        mongoDBNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
                        mongoDBNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
                        SvrInstanceNode.Nodes.Add(mongoDBNode);
                        if (config.AuthMode)
                        {
                            try
                            {
                                ///尝试添加用户信息
                                UserList.AddUser(mongoConn.GetDatabase(strDBName), config.UserName);
                            }
                            catch (Exception)
                            {
                                //可能出现没有权限的问题，这里就认为无法取得权限
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        SystemManager.ExceptionDeal(ex, strDBName + "Exception", strDBName + "Exception");
                        mongoDBNode = new TreeNode(strDBName + " (Exception)");
                        mongoDBNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
                        mongoDBNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
                        SvrInstanceNode.Nodes.Add(mongoDBNode);
                    }
                }
                if (isReplsetMasterServer)
                {
                    SvrInstanceNode.Tag = SERVER_TAG + ":" + mongoConnKey + "/" + mongoConnKey;
                }
                else
                {
                    if (mongoConn.ReplicaSetName != null)
                    {
                        SvrInstanceNode.Tag = SERVER_REPLSET_MEMBER_TAG + ":" + mongoConnKey + "/" + mMasterServerInstace.Address.ToString().Replace(":", "@");
                    }
                }
            }
            if (_mongoInstanceLst.ContainsKey(ConnSvrKey))
            {
                _mongoInstanceLst.Remove(ConnSvrKey);
            }
            if (!isReplsetMasterServer)
            {
                _mongoInstanceLst.Add(ConnSvrKey, mMasterServerInstace);
            }
            return SvrInstanceNode;
        }
        /// <summary>
        /// 获得一个表示数据库结构的节点
        /// </summary>
        /// <param name="strDBName"></param>
        /// <param name="mongoSvr"></param>
        /// <param name="mongoSvrKey"></param>
        /// <returns></returns>
        #endregion
    }
}
