using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Core;
using ResourceLib.Method;

namespace MongoGUICtl.ClientTree
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
            trvData.ContentData = dataList;
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
                        dataNode.Tag = id.Value != null ? id.Value : item.GetElement(0).Value;
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
        /// <param name="arrayName"></param>
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
        ///     获取将Mongodb的服务器在树形控件中展示的TreeNodes
        /// </summary>
        /// <returns></returns>
        public static List<TreeNode> GetConnectionNodes()
        {
            var mongoConnClientLst = RuntimeMongoDbContext.MongoConnClientLst;
            var mongoConConfigLst = MongoConnectionConfig.MongoConfig.ConnectionList;
            var connectionNodes = new List<TreeNode>();
            foreach (var mongoConnKey in mongoConnClientLst.Keys)
            {
                var mongoClient = mongoConnClientLst[mongoConnKey];
                var connectionNode = new TreeNode();
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
                    var singleConnection = GetInstanceNode(mongoConnKey, ref config, mongoClient);
                    connectionNode.Nodes.Add(singleConnection);
                    config.ServerRole = MongoConnectionConfig.SvrRoleType.DataSvr;
                    connectionNode.Tag = TagInfo.CreateTagInfo(config.ConnectionName);
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

        private static void AuthenticationExceptionHandler(MongoAuthenticationException ex,
            List<TreeNode> trvMongoDb,
            TreeNode connectionNode,
            string mongoConnKey)
        {
            //需要验证的数据服务器，没有Admin权限无法获得数据库列表
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                connectionNode.Text += "[" +
                                       GuiConfig.GetText(
                                           TextType.ExceptionAuthenticationException) + "]";
                Utility.ExceptionDeal(ex,
                    GuiConfig.GetText(
                        TextType.ExceptionAuthenticationException),
                    GuiConfig.GetText(
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
                                           GuiConfig.GetText(
                                               TextType.ExceptionAuthenticationException) + "]";
                    Utility.ExceptionDeal(ex,
                        GuiConfig.GetText(
                            TextType.ExceptionAuthenticationException),
                        GuiConfig.GetText(
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
                                           GuiConfig.GetText(
                                               TextType.ExceptionNotConnected) + "]";
                    Utility.ExceptionDeal(ex,
                        GuiConfig.GetText(TextType.ExceptionNotConnected),
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
                                       GuiConfig.GetText(
                                           TextType.ExceptionNotConnected) + "]";
                Utility.ExceptionDeal(ex,
                    GuiConfig.GetText(TextType.ExceptionNotConnected),
                    GuiConfig.GetText(TextType.ExceptionNotConnectedNote));
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
                                       GuiConfig.GetText(
                                           TextType.ExceptionNotConnected) + "]";
                Utility.ExceptionDeal(ex,
                    GuiConfig.GetText(TextType.ExceptionNotConnected),
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
        /// <param name="userList"></param>
        /// <returns></returns>
        private static TreeNode GetInstanceNode(string mongoConnKey, ref MongoConnectionConfig config,
            MongoClient mongoClient)
        {
            //无论如何，都改为主要服务器读优先
            var svrInstanceNode = new TreeNode();
            var connSvrKey = mongoConnKey + "/" + mongoConnKey;
            svrInstanceNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.WebServer;
            svrInstanceNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.WebServer;
            svrInstanceNode.Text = "Server";
            if (!string.IsNullOrEmpty(config.UserName) & !string.IsNullOrEmpty(config.Password))
            {
                //是否是认证模式，应该取决于服务器！
                config.AuthMode = true;
            }
            //获取ReadOnly
            config.IsReadOnly = false;
            if (!string.IsNullOrEmpty(config.DataBaseName))
            {
                //单数据库模式
                var mongoSingleDbNode = FillDataBaseInfoToTreeNode(config.DataBaseName,
                    mongoConnKey + "/" + mongoConnKey, null);
                mongoSingleDbNode.Tag = ConstMgr.SingleDatabaseTag + ":" + connSvrKey + "/" + config.DataBaseName;
                mongoSingleDbNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Database;
                mongoSingleDbNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Database;
                svrInstanceNode.Nodes.Add(mongoSingleDbNode);
                svrInstanceNode.Tag = ConstMgr.SingleDbServerTag + ":" + connSvrKey;
            }
            else
            {
                var setting = RuntimeMongoDbContext.CreateMongoClientSettingsByConfig(ref config);
                var client = new MongoClient(setting);
                var databaseNameList = GetConnectionInfo.GetDatabaseList(client);
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
            }
            svrInstanceNode.Tag = ConstMgr.ServerTag + ":" + mongoConnKey + "/" + mongoConnKey;
            return svrInstanceNode;
        }

        #endregion
    }
}