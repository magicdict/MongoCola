using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MagicMongoDBTool.Module;
using Common.Security;
namespace MagicMongoDBTool.Module
{
    public static partial class UIHelper
    {
        #region"展示数据库结构 Winform"

        /// <summary>
        ///     将Mongodb的服务器在树形控件中展示
        /// </summary>
        /// <param name="trvMongoDB"></param>
        public static void FillConnectionToTreeView(TreeView trvMongoDB)
        {
            trvMongoDB.Nodes.Clear();
            foreach (String mongoConnKey in MongoDbHelper._mongoConnSvrLst.Keys)
            {
                MongoServer mongoSrv = MongoDbHelper._mongoConnSvrLst[mongoConnKey];
                var ConnectionNode = new TreeNode();
                var UserList = new EachDatabaseUser();
                try
                {
                    //ReplSetName只能使用在虚拟的Replset服务器，Sharding体系等无效。虽然一个Sharding可以看做一个ReplSet
                    ConfigHelper.MongoConnectionConfig config =
                        SystemManager.ConfigHelperInstance.ConnectionList[mongoConnKey];
                    ConnectionNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Connection;
                    ConnectionNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Connection;
                    //ReplSet服务器需要Connect才能连接。可能因为这个是虚拟的服务器，没有Mongod实体。
                    //不过现在改为全部显示的打开连接
                    mongoSrv.Connect();
                    //mongoSvr.ReplicaSetName只有在连接后才有效，但是也可以使用Config.ReplsetName
                    ConnectionNode.Text = mongoConnKey;
                    ConnectionNode.Nodes.Add(GetInstanceNode(mongoConnKey, ref config, mongoSrv, null, mongoSrv,
                        UserList));
                    if (mongoSrv.ReplicaSetName != null)
                    {
                        ConnectionNode.Tag = MongoDbHelper.CONNECTION_REPLSET_TAG + ":" + config.ConnectionName;
                        var ServerListNode = new TreeNode("Servers")
                        {
                            SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers,
                            ImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers
                        };
                        foreach (MongoServerInstance ServerInstace in mongoSrv.Instances)
                        {
                            ServerListNode.Nodes.Add(GetInstanceNode(mongoConnKey, ref config, mongoSrv, ServerInstace,
                                null, UserList));
                        }
                        ConnectionNode.Nodes.Add(ServerListNode);
                        config.ServerRole = ConfigHelper.SvrRoleType.ReplsetSvr;
                    }
                    else
                    {
                        BsonDocument ServerStatusDoc = CommandHelper.ExecuteMongoSvrCommand(CommandHelper.serverStatus_Command, mongoSrv).Response;
                        //ServerStatus可能没有权限打开
                        if (ServerStatusDoc.Contains("process") &&
                            ServerStatusDoc.GetElement("process").Value == MongoDbHelper.ServerStatus_PROCESS_MONGOS)
                        {
                            //Shard的时候，必须将所有服务器的ReadPreferred设成可读
                            config.ServerRole = ConfigHelper.SvrRoleType.ShardSvr;
                            ConnectionNode.Tag = MongoDbHelper.CONNECTION_CLUSTER_TAG + ":" + config.ConnectionName;
                            var ShardListNode = new TreeNode("Shards")
                            {
                                SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers,
                                ImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers
                            };
                            foreach (var lst in MongoDbHelper.GetShardInfo(mongoSrv, "host"))
                            {
                                var ShardNode = new TreeNode
                                {
                                    Text = lst.Key,
                                    SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers,
                                    ImageIndex = (int) GetSystemIcon.MainTreeImageType.Servers
                                };
                                String strHostList = lst.Value;
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
                                    MongoServer ReplsetMember = new MongoClient(tinySetting).GetServer();
                                    ShardNode.Nodes.Add(GetInstanceNode(mongoConnKey, ref config, mongoSrv,
                                        ReplsetMember.Instance, null, UserList));
                                }
                                ShardListNode.Nodes.Add(ShardNode);
                            }
                            ConnectionNode.Nodes.Add(ShardListNode);
                        }
                        else
                        {
                            //Server Status mongod
                            //Master - Slave 的判断
                            BsonElement replElement;
                            ServerStatusDoc.TryGetElement("repl", out replElement);
                            if (replElement == null)
                            {
                                config.ServerRole = ConfigHelper.SvrRoleType.DataSvr;
                            }
                            else
                            {
                                config.ServerRole = replElement.Value.AsBsonDocument.GetElement("ismaster").Value ==
                                                    BsonBoolean.True
                                    ? ConfigHelper.SvrRoleType.MasterSvr
                                    : ConfigHelper.SvrRoleType.SlaveSvr;
                            }
                            ConnectionNode.Tag = MongoDbHelper.CONNECTION_TAG + ":" + config.ConnectionName;
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
                    if (MongoDbHelper._mongoUserLst.ContainsKey(mongoConnKey))
                    {
                        MongoDbHelper._mongoUserLst[mongoConnKey] = UserList;
                    }
                    else
                    {
                        MongoDbHelper._mongoUserLst.Add(mongoConnKey, UserList);
                    }
                }
                catch (MongoAuthenticationException ex)
                {
                    //需要验证的数据服务器，没有Admin权限无法获得数据库列表
                    if (!SystemManager.IsUseDefaultLanguage)
                    {
                        ConnectionNode.Text += "[" +
                                               SystemManager.MStringResource.GetText(
                                                   StringResource.TextType.Exception_AuthenticationException) + "]";
                        SystemManager.ExceptionDeal(ex,
                            SystemManager.MStringResource.GetText(
                                StringResource.TextType.Exception_AuthenticationException),
                            SystemManager.MStringResource.GetText(
                                StringResource.TextType.Exception_AuthenticationException_Note));
                    }
                    else
                    {
                        ConnectionNode.Text += "[MongoAuthenticationException]";
                        SystemManager.ExceptionDeal(ex, "MongoAuthenticationException:",
                            "Please check UserName and Password");
                    }
                    ConnectionNode.Tag = MongoDbHelper.CONNECTION_EXCEPTION_TAG + ":" + mongoConnKey;
                    trvMongoDB.Nodes.Add(ConnectionNode);
                }
                catch (MongoCommandException ex)
                {
                    //listDatabase命令错误，本质是用户名称错误
                    if (ex.CommandResult.Response["errmsg"] == "unauthorized")
                    {
                        if (!SystemManager.IsUseDefaultLanguage)
                        {
                            ConnectionNode.Text += "[" +
                                                   SystemManager.MStringResource.GetText(
                                                       StringResource.TextType.Exception_AuthenticationException) + "]";
                            SystemManager.ExceptionDeal(ex,
                                SystemManager.MStringResource.GetText(
                                    StringResource.TextType.Exception_AuthenticationException),
                                SystemManager.MStringResource.GetText(
                                    StringResource.TextType.Exception_AuthenticationException_Note));
                        }
                        else
                        {
                            ConnectionNode.Text += "[MongoAuthenticationException]";
                            SystemManager.ExceptionDeal(ex, "MongoAuthenticationException:",
                                "Please check UserName and Password");
                        }
                    }
                    else
                    {
                        if (!SystemManager.IsUseDefaultLanguage)
                        {
                            ConnectionNode.Text += "[" +
                                                   SystemManager.MStringResource.GetText(
                                                       StringResource.TextType.Exception_NotConnected) + "]";
                            SystemManager.ExceptionDeal(ex,
                                SystemManager.MStringResource.GetText(StringResource.TextType.Exception_NotConnected),
                                "Unknown Exception");
                        }
                        else
                        {
                            ConnectionNode.Text += "[Exception]";
                            SystemManager.ExceptionDeal(ex, "Not Connected", "Unknown Exception");
                        }
                    }
                    ConnectionNode.Tag = MongoDbHelper.CONNECTION_EXCEPTION_TAG + ":" + mongoConnKey;
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
                        ConnectionNode.Text += "[" +
                                               SystemManager.MStringResource.GetText(
                                                   StringResource.TextType.Exception_NotConnected) + "]";
                        SystemManager.ExceptionDeal(ex,
                            SystemManager.MStringResource.GetText(StringResource.TextType.Exception_NotConnected),
                            SystemManager.MStringResource.GetText(StringResource.TextType.Exception_NotConnected_Note));
                    }
                    else
                    {
                        ConnectionNode.Text += "[Exception]";
                        SystemManager.ExceptionDeal(ex, "Not Connected",
                            "Mongo Server may not Startup or Auth Mode is not correct");
                    }
                    ConnectionNode.Tag = MongoDbHelper.CONNECTION_EXCEPTION_TAG + ":" + mongoConnKey;
                    trvMongoDB.Nodes.Add(ConnectionNode);
                }
                catch (Exception ex)
                {
                    if (!SystemManager.IsUseDefaultLanguage)
                    {
                        ConnectionNode.Text += "[" +
                                               SystemManager.MStringResource.GetText(
                                                   StringResource.TextType.Exception_NotConnected) + "]";
                        SystemManager.ExceptionDeal(ex,
                            SystemManager.MStringResource.GetText(StringResource.TextType.Exception_NotConnected),
                            "Unknown Exception");
                    }
                    else
                    {
                        ConnectionNode.Text += "[Exception]";
                        SystemManager.ExceptionDeal(ex, "Not Connected", "Unknown Exception");
                    }
                    ConnectionNode.Tag = MongoDbHelper.CONNECTION_EXCEPTION_TAG + ":" + mongoConnKey;
                    trvMongoDB.Nodes.Add(ConnectionNode);
                }
            }
        }

        /// <summary>
        ///     获取实例节点
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
            bool isReplsetMasterServer = mMasterServerInstace == null;
            //无论如何，都改为主要服务器读优先
            var svrInstanceNode = new TreeNode();
            String connSvrKey;
            connSvrKey = isReplsetMasterServer
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
            List<string> databaseNameList;
            if (!String.IsNullOrEmpty(config.DataBaseName))
            {
                //单数据库模式
                TreeNode mongoSingleDbNode;
                mongoSingleDbNode = isReplsetMasterServer
                    ? FillDataBaseInfoToTreeNode(config.DataBaseName, mServer,
                        mongoConnKey + "/" + mongoConnKey)
                    : FillDataBaseInfoToTreeNode(config.DataBaseName, mServer,
                        mongoConnKey + "/" + mMasterServerInstace.Address);
                mongoSingleDbNode.Tag = MongoDbHelper.SINGLE_DATABASE_TAG + ":" + connSvrKey + "/" + config.DataBaseName;
                mongoSingleDbNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Database;
                mongoSingleDbNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Database;
                svrInstanceNode.Nodes.Add(mongoSingleDbNode);
                svrInstanceNode.Tag = MongoDbHelper.SINGLE_DB_SERVER_TAG + ":" + connSvrKey;
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
                if (isReplsetMasterServer)
                {
                    instantSrv = mServer;
                    databaseNameList = mServer.GetDatabaseNames().ToList();
                }
                else
                {
                    MongoClientSettings setting = MongoDbHelper.CreateMongoClientSettingsByConfig(ref config);
                    setting.ConnectionMode = ConnectionMode.Direct;
                    //When Replset Case,Application need to read admin DB information
                    //if Primary,there will be exception
                    setting.ReadPreference = ReadPreference.PrimaryPreferred;
                    setting.Server = mMasterServerInstace.Address;
                    instantSrv = new MongoClient(setting).GetServer();
                    databaseNameList = instantSrv.GetDatabaseNames().ToList();
                }
                foreach (String strDbName in databaseNameList)
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
                        SystemManager.ExceptionDeal(ex, strDbName + "Exception", strDbName + "Exception");
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
                    svrInstanceNode.Tag = MongoDbHelper.SERVER_TAG + ":" + mongoConnKey + "/" + mongoConnKey;
                }
                else
                {
                    if (mongoConn.ReplicaSetName != null)
                    {
                        svrInstanceNode.Tag = MongoDbHelper.SERVER_REPLSET_MEMBER_TAG + ":" + mongoConnKey + "/" +
                                              mMasterServerInstace.Address.ToString().Replace(":", "@");
                    }
                }
            }
            if (MongoDbHelper._mongoInstanceLst.ContainsKey(connSvrKey))
            {
                MongoDbHelper._mongoInstanceLst.Remove(connSvrKey);
            }
            if (!isReplsetMasterServer)
            {
                MongoDbHelper._mongoInstanceLst.Add(connSvrKey, mMasterServerInstace);
            }
            return svrInstanceNode;
        }

        #endregion
    }
}