using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelpler
    {
        #region"服务器管理"
        /// <summary>
        /// 管理中服务器列表
        /// </summary>
        private static Dictionary<string, MongoServer> _mongoSrvLst = new Dictionary<string, MongoServer>();
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
                    mongoSvrSetting.ConnectionMode = ConnectionMode.Direct;
                    //当一个服务器作为从属服务器，副本组中的备用服务器，这里一定要设置为SlaveOK
                    mongoSvrSetting.SlaveOk = config.IsSlaveOk;
                    //安全模式
                    mongoSvrSetting.SafeMode = new SafeMode(config.IsSafeMode);
                    //Replset时候可以不用设置吗？                    
                    mongoSvrSetting.Server = new MongoServerAddress(config.IpAddr, config.Port);
                    //MapReduce的时候将消耗大量时间。不过这里需要平衡一下，太长容易造成并发问题
                    mongoSvrSetting.SocketTimeout = new TimeSpan(0, 10, 0);
                    if ((config.UserName != string.Empty) & (config.Password != string.Empty))
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
                                            SystemManager.ConfigHelperInstance.ConnectionList[item].IpAddr,
                                            SystemManager.ConfigHelperInstance.ConnectionList[item].Port);
                            ReplsetSvrList.Add(ReplSrv);
                        }
                        mongoSvrSetting.Servers = ReplsetSvrList;
                    }
                    MongoServer masterMongoSvr = new MongoServer(mongoSvrSetting);
                    _mongoSrvLst.Add(config.ConnectionName, masterMongoSvr);
                    if (config.ServerType == ConfigHelper.SvrType.ReplsetSvr)
                    {
                        //ReplSet服务器需要Connect才能连接。可能因为这个是虚拟的服务器，没有Mongod实体。
                        if (masterMongoSvr.State == MongoServerState.Disconnected)
                        {
                            masterMongoSvr.Connect();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法链接到服务器：" + config.ConnectionName + ex.ToString());
                }
            }
        }
        #endregion

        #region"展示数据"
        /// <summary>
        /// 获得当前服务器信息
        /// </summary>
        /// <returns></returns>
        public static String GetCurrentSvrInfo()
        {
            String rtnSvrInfo = String.Empty;
            MongoServer mongosvr = SystemManager.GetCurrentService();
            rtnSvrInfo = "仲裁服务器：" + mongosvr.Instance.IsArbiter.ToString() + "\r\n";
            rtnSvrInfo += "副本主服务器：" + mongosvr.Instance.IsPrimary.ToString() + "\r\n";
            rtnSvrInfo += "副本次服务器：" + mongosvr.Instance.IsSecondary.ToString() + "\r\n";
            rtnSvrInfo += "服务器地址：" + mongosvr.Instance.Address.ToString() + "\r\n";
            rtnSvrInfo += "服务器版本：" + mongosvr.Instance.BuildInfo.VersionString + "\r\n";
            rtnSvrInfo += "系统信息：" + mongosvr.Instance.BuildInfo.SysInfo + "\r\n";
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
                //ReplSetName只能使用在虚拟的Replset服务器，Sharding体系等无效。虽然一个Sharding可以看做一个ReplSet
                TreeNode mongoSvrNode = new TreeNode(mongoSvr.ReplicaSetName != null ? "副本名称：" + mongoSvr.ReplicaSetName :
                                                    (mongoSvrKey + " [" + mongoSvr.Settings.Server.Host + ":" + mongoSvr.Settings.Server.Port + "]"));
                try
                {
                    List<string> databaseNameList = new List<string>();
                    if (SystemManager.ConfigHelperInstance.ConnectionList[mongoSvrKey].DataBaseName != String.Empty)
                    {
                        TreeNode mongoSingleDBNode = FillDataBaseInfoToTreeNode(SystemManager.ConfigHelperInstance.ConnectionList[mongoSvrKey].DataBaseName, mongoSvr, mongoSvrKey);
                        mongoSingleDBNode.Tag = SINGLE_DATABASE_TAG + ":" + mongoSvrKey + "/" + SystemManager.ConfigHelperInstance.ConnectionList[mongoSvrKey].DataBaseName;
                        mongoSingleDBNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
                        mongoSingleDBNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
                        mongoSvrNode.Nodes.Add(mongoSingleDBNode);
                        //单数据库模式
                        mongoSvrNode.Tag = SINGLE_DB_SERVICE_TAG + ":" + mongoSvrKey;
                        mongoSvrNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.WebServer;
                        mongoSvrNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.WebServer;
                    }
                    else
                    {
                        databaseNameList = mongoSvr.GetDatabaseNames().ToList<String>();
                        foreach (String strDBName in databaseNameList)
                        {
                            TreeNode mongoDBNode = FillDataBaseInfoToTreeNode(strDBName, mongoSvr, mongoSvrKey);
                            mongoDBNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
                            mongoDBNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
                            mongoSvrNode.Nodes.Add(mongoDBNode);
                        }
                        mongoSvrNode.Tag = SERVICE_TAG + ":" + mongoSvrKey;
                        mongoSvrNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.WebServer;
                        mongoSvrNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.WebServer;
                    }
                    trvMongoDB.Nodes.Add(mongoSvrNode);
                }
                catch (MongoAuthenticationException)
                {
                    //需要验证的数据服务器，没有Admin权限无法获得数据库列表
                    MessageBox.Show("认证信息错误，请检查数据库的用户名和密码", "认证失败");
                }
                catch (Exception)
                {
                    //暂时不处理任何异常，简单跳过
                    mongoSvrNode.Text += "[无法连接]";
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
            TreeNode mongoDBNode;
            switch (strDBName)
            {
                case "admin":
                    mongoDBNode = new TreeNode("管理员权限(admin)");
                    break;
                case "local":
                    mongoDBNode = new TreeNode("本地(local)");
                    break;
                case "config":
                    mongoDBNode = new TreeNode("配置(config)");
                    break;
                default:
                    mongoDBNode = new TreeNode(strDBName);
                    break;
            }

            mongoDBNode.Tag = DATABASE_TAG + ":" + mongoSvrKey + "/" + strDBName;
            MongoDatabase mongoDB = mongoSvr.GetDatabase(strDBName);

            List<String> colNameList = mongoDB.GetCollectionNames().ToList<String>();
            foreach (String strColName in colNameList)
            {
                TreeNode mongoColNode = new TreeNode();
                try
                {
                    mongoColNode = FillCollectionInfoToTreeNode(strColName, mongoDB, mongoSvrKey);
                }
                catch (Exception)
                {
                    mongoColNode = new TreeNode(strColName + "[访问异常]");
                    throw;
                }
                mongoDBNode.Nodes.Add(mongoColNode);
            }
            return mongoDBNode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strColName"></param>
        /// <param name="mongoDB"></param>
        /// <param name="mongoSvrKey"></param>
        /// <returns></returns>
        private static TreeNode FillCollectionInfoToTreeNode(string strColName, MongoDatabase mongoDB, string mongoSvrKey)
        {
            TreeNode mongoColNode;
            String strTagColName = strColName;
            switch (strColName)
            {
                case "chunks":
                    if (mongoDB.Name == "config")
                    {
                        strColName = "数据块(" + strColName + ")";
                    }
                    break;
                case "collections":
                    if (mongoDB.Name == "config")
                    {
                        strColName = "数据集(" + strColName + ")";
                    }
                    break;
                case "changelog":
                    if (mongoDB.Name == "config")
                    {
                        strColName = "变更日志(" + strColName + ")";
                    }
                    break;
                case "databases":
                    if (mongoDB.Name == "config")
                    {
                        strColName = "数据库(" + strColName + ")";
                    }
                    break;
                case "lockpings":
                    if (mongoDB.Name == "config")
                    {
                        strColName = "数据锁(" + strColName + ")";
                    }
                    break;
                case "locks":
                    if (mongoDB.Name == "config")
                    {
                        strColName = "数据锁(" + strColName + ")";
                    }
                    break;
                case "mongos":
                    if (mongoDB.Name == "config")
                    {
                        strColName = "路由服务器(" + strColName + ")";
                    }
                    break;
                case "settings":
                    if (mongoDB.Name == "config")
                    {
                        strColName = "配置(" + strColName + ")";
                    }
                    break;
                case "shards":
                    if (mongoDB.Name == "config")
                    {
                        strColName = "分片(" + strColName + ")";
                    }
                    break;
                case "version":
                    if (mongoDB.Name == "config")
                    {
                        strColName = "版本(" + strColName + ")";
                    }
                    break;
                case "me":
                    if (mongoDB.Name == "local")
                    {
                        strColName = "副本组[从属机信息](" + strColName + ")";
                    }
                    break;
                case "sources":
                    if (mongoDB.Name == "local")
                    {
                        strColName = "主机地址(" + strColName + ")";
                    }
                    break;
                case "slaves":
                    if (mongoDB.Name == "local")
                    {
                        strColName = "副本组[主机信息](" + strColName + ")";
                    }
                    break;
                case COLLECTION_NAME_GFS_CHUNKS:
                    strColName = "数据块(" + strColName + ")";
                    break;
                case COLLECTION_NAME_GFS_FILES:
                    strColName = "文件系统(" + strColName + ")";
                    break;
                case COLLECTION_NAME_OPERATION_LOG:
                    strColName = "操作结果(" + strColName + ")";
                    break;
                case COLLECTION_NAME_SYSTEM_INDEXES:
                    strColName = "索引(" + strColName + ")";
                    break;
                case COLLECTION_NAME_JAVASCRIPT:
                    strColName = "存储Javascript(" + strColName + ")";
                    break;
                case COLLECTION_NAME_SYSTEM_REPLSET:
                    strColName = "副本组(" + strColName + ")";
                    break;
                case COLLECTION_NAME_REPLSET_MINVALID:
                    strColName = "初始化同步(" + strColName + ")";
                    break;
                case COLLECTION_NAME_USER:
                    strColName = "用户列表(" + strColName + ")";
                    break;
                default:
                    break;
            }
            mongoColNode = new TreeNode(strColName);
            if (strTagColName == COLLECTION_NAME_GFS_FILES)
            {
                mongoColNode.Tag = GRID_FILE_SYSTEM_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + strTagColName;
            }
            else
            {
                mongoColNode.Tag = COLLECTION_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + strTagColName;
            }
            MongoCollection mongoCol = mongoDB.GetCollection(strTagColName);

            //Start ListIndex
            TreeNode mongoIndex = new TreeNode("Indexes");
            GetIndexesResult indexList = mongoCol.GetIndexes();
            foreach (IndexInfo indexDoc in indexList.ToList<IndexInfo>())
            {
                TreeNode mongoIndexNode = new TreeNode("Index:" + indexDoc.Name);
                mongoIndexNode.Nodes.Add(indexDoc.Key.ToString());
                mongoIndexNode.Nodes.Add("删除重复索引(DroppedDups) :" + indexDoc.DroppedDups.ToString());
                mongoIndexNode.Nodes.Add("背景索引(IsBackground):" + indexDoc.IsBackground.ToString());
                mongoIndexNode.Nodes.Add("稀疏索引(IsSparse):" + indexDoc.IsSparse.ToString());
                mongoIndexNode.Nodes.Add("统一索引(IsUnique):" + indexDoc.IsUnique.ToString());
                mongoIndexNode.Nodes.Add("名字空间:" + indexDoc.Namespace.ToString());
                mongoIndexNode.Nodes.Add("版本:" + indexDoc.Version.ToString());
                mongoIndex.Nodes.Add(mongoIndexNode);
            }
            mongoIndex.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Keys;
            mongoIndex.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Keys;
            mongoColNode.Nodes.Add(mongoIndex);
            //End ListIndex

            //Start Data
            TreeNode mongoData = new TreeNode("Data");
            mongoData.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Document;
            mongoData.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Document;
            mongoData.Tag = DOCUMENT_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + strTagColName;

            mongoColNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Collection;
            mongoColNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Collection;
            mongoColNode.Nodes.Add(mongoData);
            //End Data
            return mongoColNode;
        }
        /// <summary>
        /// 通过读取N条记录来确定数据集结构
        /// </summary>
        /// <param name="mongoCol">数据集</param>
        /// <param name="CheckRecordCnt">使用数据量，省略时为全部，海量数据时相当消耗性能</param>
        /// <returns></returns>
        public static List<string> GetCollectionSchame(MongoCollection mongoCol, int CheckRecordCnt = 100)
        {
            List<string> _ColumnList = new List<string>();
            List<BsonDocument> _dataList = new List<BsonDocument>();
            _dataList = mongoCol.FindAllAs<BsonDocument>()
                                 .SetLimit(CheckRecordCnt)
                                 .ToList<BsonDocument>();
            foreach (BsonDocument doc in _dataList)
            {
                foreach (var item in getBsonNameList(String.Empty, doc))
                {
                    if (!_ColumnList.Contains(item))
                    {
                        _ColumnList.Add(item);
                    }
                }
            }
            return _ColumnList;
        }
        /// <summary>
        /// 取得名称列表[递归获得嵌套]
        /// </summary>
        /// <param name="docName"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static List<string> getBsonNameList(String docName, BsonDocument doc)
        {
            List<string> _ColumnList = new List<string>();
            foreach (String strName in doc.Names)
            {
                if (doc.GetValue(strName).IsBsonDocument)
                {
                    //包含子文档的时候
                    foreach (var item in getBsonNameList(strName, doc.GetValue(strName).AsBsonDocument))
                    {
                        _ColumnList.Add(item);
                    }
                }
                else
                {
                    _ColumnList.Add(docName + (docName != string.Empty ? "." : String.Empty) + strName);
                }
            }
            return _ColumnList;
        }
        /// <summary>
        /// 是否有二进制数据
        /// </summary>
        private static Boolean _hasBSonBinary;
        /// <summary>
        /// 展示数据
        /// </summary>
        /// <param name="strTag"></param>
        /// <param name="controls"></param>
        public static void FillDataToControl(string strTag, List<Control> controls)
        {
            string collectionPath = strTag.Split(":".ToCharArray())[1];
            String[] cp = collectionPath.Split("/".ToCharArray());
            MongoCollection mongoCol = _mongoSrvLst[cp[(int)PathLv.ServerLV]]
                                      .GetDatabase(cp[(int)PathLv.DatabaseLV])
                                      .GetCollection(cp[(int)PathLv.CollectionLV]);

            List<BsonDocument> dataList = new List<BsonDocument>();
            //Query condition:
            if (IsUseFilter)
            {
                dataList = mongoCol.FindAs<BsonDocument>(GetQuery())
                                   .SetSkip(SkipCnt)
                                   .SetFields(GetOutputFields())
                                   .SetSortOrder(GetSort())
                                   .SetLimit(SystemManager.ConfigHelperInstance.LimitCnt)
                                   .ToList<BsonDocument>();
            }
            else
            {
                dataList = mongoCol.FindAllAs<BsonDocument>()
                                   .SetSkip(SkipCnt)
                                   .SetLimit(SystemManager.ConfigHelperInstance.LimitCnt)
                                   .ToList<BsonDocument>();
            }
            if (dataList.Count == 0)
            {
                return;
            }
            if (SkipCnt == 0)
            {
                //第一次显示，获得整个记录集的长度
                CurrentCollectionTotalCnt = (int)mongoCol.FindAllAs<BsonDocument>().Count();
            }
            SetPageEnable();
            _hasBSonBinary = false;
            foreach (var control in controls)
            {
                switch (control.GetType().ToString())
                {
                    case "System.Windows.Forms.ListView":
                        FillDataToListView(cp[(int)PathLv.CollectionLV], (ListView)control, dataList);
                        break;
                    case "System.Windows.Forms.TextBox":
                        FillDataToTextBox(cp[(int)PathLv.CollectionLV], (TextBox)control, dataList);
                        break;
                    case "System.Windows.Forms.TreeView":
                        FillDataToTreeView(cp[(int)PathLv.CollectionLV], (TreeView)control, dataList);
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// BsonValue转展示用字符
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ConvertForShow(BsonValue val)
        {
            string strVal;
            if (val.IsBsonBinaryData)
            {
                _hasBSonBinary = true;
                return "[二进制数据]";
            }
            if (val.IsBsonNull)
            {
                return "[空值]";
            }
            if (val.IsBsonDocument)
            {
                strVal = val.ToString() + "[包含" + val.ToBsonDocument().ElementCount + "个元素的文档]";
            }
            else
            {
                strVal = val.ToString();
            }
            return strVal;
        }
        /// <summary>
        /// 将数据放入TextBox里进行展示
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="txtData"></param>
        /// <param name="dataList"></param>
        public static void FillDataToTextBox(string collectionName, TextBox txtData, List<BsonDocument> dataList)
        {
            txtData.Clear();
            if (_hasBSonBinary)
            {
                txtData.Text = "二进制数据块";
            }
            else
            {
                foreach (var item in dataList)
                {
                    txtData.Text += item.ToString() + "\r\n";
                }
            }
        }
        /// <summary>
        /// 将数据放入TreeView里进行展示
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="trvData"></param>
        /// <param name="dataList"></param>
        public static void FillDataToTreeView(string collectionName, TreeView trvData, List<BsonDocument> dataList)
        {
            trvData.Nodes.Clear();
            foreach (BsonDocument item in dataList)
            {
                string treeText = string.Empty;
                if (!item.GetElement(0).Value.IsBsonArray)
                {
                    treeText = item.GetElement(0).Name + ":" + item.GetElement(0).Value.ToString();
                }
                else
                {
                    treeText = item.GetElement(0).Name + ":" + collectionName;
                }
                TreeNode dataNode = new TreeNode(treeText);

                //这里保存真实的主Key数据，删除的时候使用
                dataNode.Tag = item.GetElement(0).Value;
                FillBsonDocToTreeNode(dataNode, item);
                trvData.Nodes.Add(dataNode);
            }
        }
        /// <summary>
        /// 将数据放入TreeNode里进行展示
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="doc"></param>
        private static void FillBsonDocToTreeNode(TreeNode treeNode, BsonDocument doc)
        {
            foreach (var item in doc.Elements)
            {
                if (item.Value.IsBsonDocument)
                {
                    TreeNode newItem = new TreeNode(item.Name);
                    FillBsonDocToTreeNode(newItem, item.Value.ToBsonDocument());
                    treeNode.Nodes.Add(newItem);
                }
                else
                {
                    if (item.Value.IsBsonArray)
                    {
                        TreeNode newItem = new TreeNode(item.Name);
                        int count = 1;
                        foreach (BsonValue SubItem in item.Value.AsBsonArray)
                        {
                            TreeNode newSubItem = new TreeNode(item.Name + "[" + count + "]");
                            FillBsonDocToTreeNode(newSubItem, SubItem.ToBsonDocument());
                            newItem.Nodes.Add(newSubItem);
                            count++;
                        }
                        treeNode.Nodes.Add(newItem);
                    }
                    else
                    {
                        treeNode.Nodes.Add(item.Name + ":" + ConvertForShow(item.Value));
                    }
                }
            }
        }
        /// <summary>
        /// 将数据放入ListView中进行展示
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="lstData"></param>
        /// <param name="dataList"></param>
        public static void FillDataToListView(string collectionName, ListView lstData, List<BsonDocument> dataList)
        {
            lstData.Clear();
            lstData.SmallImageList = null;
            switch (collectionName)
            {
                case COLLECTION_NAME_GFS_FILES:
                    SetGridFileToListView(dataList, lstData);
                    break;
                case COLLECTION_NAME_USER:
                    SetUserListToListView(dataList, lstData);
                    break;
                default:
                    List<string> _columnlist = new List<string>();
                    foreach (BsonDocument docItem in dataList)
                    {
                        ListViewItem lstItem = new ListViewItem();
                        foreach (String item in docItem.Names)
                        {
                            if (!_columnlist.Contains(item))
                            {
                                _columnlist.Add(item);
                                lstData.Columns.Add(item);
                            }
                        }
                        //Key:_id
                        lstItem.Text = docItem.GetValue(_columnlist[0]).ToString();
                        //这里保存真实的主Key数据，删除的时候使用
                        lstItem.Tag = docItem.GetValue(_columnlist[0]);
                        //OtherItems
                        for (int i = 1; i < _columnlist.Count; i++)
                        {
                            BsonValue val;
                            docItem.TryGetValue(_columnlist[i].ToString(), out val);
                            if (val == null)
                            {
                                lstItem.SubItems.Add("");
                            }
                            else
                            {
                                lstItem.SubItems.Add(ConvertForShow(val));
                            }
                        }
                        lstData.Items.Add(lstItem);
                    }
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="lstData"></param>
        private static void SetUserListToListView(List<BsonDocument> dataList, ListView lstData)
        {
            lstData.Clear();
            lstData.Columns.Add("ID");
            lstData.Columns.Add("用户名");
            lstData.Columns.Add("是否只读");
            //密码是密文表示的，这里没有安全隐患
            lstData.Columns.Add("密码");
            foreach (BsonDocument docFile in dataList)
            {
                ListViewItem lstItem = new ListViewItem();
                lstItem.Text = docFile.GetValue("_id").ToString();
                lstItem.SubItems.Add(docFile.GetValue("user").ToString());
                lstItem.SubItems.Add(docFile.GetValue("readOnly").ToString());
                lstItem.SubItems.Add(docFile.GetValue("pwd").ToString());
                lstData.Items.Add(lstItem);
            }
        }
        /// <summary>
        /// GFS系统
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="lstData"></param>
        private static void SetGridFileToListView(List<BsonDocument> dataList, ListView lstData)
        {
            lstData.Clear();
            lstData.Columns.Add("文件名称");
            lstData.Columns.Add("文件大小");
            lstData.Columns.Add("块大小");
            lstData.Columns.Add("上传日期");
            lstData.Columns.Add("MD5");
            lstData.SmallImageList = GetSystemIcon.IconImagelist;
            foreach (BsonDocument docFile in dataList)
            {
                ListViewItem lstItem = new ListViewItem();
                lstItem.ImageIndex = GetSystemIcon.GetIconIndexByFileName(docFile.GetValue("filename").ToString(), false);
                lstItem.Text = docFile.GetValue("filename").ToString();
                lstItem.SubItems.Add(GetSize((int)docFile.GetValue("length")));
                lstItem.SubItems.Add(GetSize((int)docFile.GetValue("chunkSize")));
                lstItem.SubItems.Add(ConvertForShow(docFile.GetValue("uploadDate")));
                lstItem.SubItems.Add(ConvertForShow(docFile.GetValue("md5")));
                lstData.Items.Add(lstItem);
            }
        }
        #endregion

        #region"展示状态"
        /// <summary>
        /// 将DB状态放入ListView
        /// </summary>
        /// <param name="lstData"></param>
        public static void FillDBStatusToList(ListView lstData)
        {
            lstData.Clear();
            lstData.Columns.Add("名称");
            lstData.Columns.Add("文档数量");
            lstData.Columns.Add("实际大小");
            lstData.Columns.Add("占用大小");
            lstData.Columns.Add("索引");
            lstData.Columns.Add("平均对象大小");
            lstData.Columns.Add("填充因子");
            foreach (String mongoSvrKey in _mongoSrvLst.Keys)
            {
                try
                {
                    MongoServer mongoSvr = _mongoSrvLst[mongoSvrKey];
                    List<string> databaseNameList = mongoSvr.GetDatabaseNames().ToList<string>();
                    foreach (string strDBName in databaseNameList)
                    {
                        MongoDatabase mongoDB = mongoSvr.GetDatabase(strDBName);

                        List<string> colNameList = mongoDB.GetCollectionNames().ToList<string>();
                        foreach (string strColName in colNameList)
                        {

                            CollectionStatsResult dbStatus = mongoDB.GetCollection(strColName).GetStats();
                            ListViewItem lst = new ListViewItem(strDBName + "." + strColName);
                            lst.SubItems.Add(dbStatus.ObjectCount.ToString());
                            lst.SubItems.Add(GetSize(dbStatus.DataSize));
                            lst.SubItems.Add(GetSize(dbStatus.StorageSize));
                            lst.SubItems.Add(GetSize(dbStatus.TotalIndexSize));
                            try
                            {
                                //在某些条件下，这个值会抛出异常，IndexKeyNotFound
                                lst.SubItems.Add(GetSize((long)dbStatus.AverageObjectSize));
                            }
                            catch (Exception)
                            {
                                lst.SubItems.Add("-");
                            }
                            try
                            {
                                //在某些条件下，这个值会抛出异常，IndexKeyNotFound
                                lst.SubItems.Add(dbStatus.PaddingFactor.ToString());
                            }
                            catch (Exception)
                            {
                                lst.SubItems.Add("-");
                            }
                            lstData.Items.Add(lst);
                        }
                    }
                }
                catch (Exception)
                {
                    //throw;
                }
            }
        }
        /// <summary>
        /// 将服务器状态放入ListView
        /// </summary>
        /// <param name="lstSvr"></param>
        public static void FillSrvStatusToList(ListView lstSvr)
        {
            lstSvr.Clear();
            lstSvr.Columns.Add("名称");
            lstSvr.Columns.Add("数据集数量");
            lstSvr.Columns.Add("数据大小");
            lstSvr.Columns.Add("文件大小");
            lstSvr.Columns.Add("索引数量");
            lstSvr.Columns.Add("索引数量大小");
            lstSvr.Columns.Add("对象数量");
            lstSvr.Columns.Add("占用大小");
            foreach (String mongoSvrKey in _mongoSrvLst.Keys)
            {
                try
                {
                    MongoServer mongoSvr = _mongoSrvLst[mongoSvrKey];
                    List<string> databaseNameList = mongoSvr.GetDatabaseNames().ToList<string>();
                    foreach (String strDBName in databaseNameList)
                    {
                        MongoDatabase mongoDB = mongoSvr.GetDatabase(strDBName);
                        DatabaseStatsResult dbStatus = mongoDB.GetStats();
                        ListViewItem lst = new ListViewItem(mongoSvrKey + "." + strDBName);
                        try
                        {
                            lst.SubItems.Add(dbStatus.CollectionCount.ToString());

                        }
                        catch (Exception)
                        {

                            lst.SubItems.Add(string.Empty);
                        }

                        lst.SubItems.Add(GetSize(dbStatus.DataSize));
                        lst.SubItems.Add(GetSize(dbStatus.FileSize));
                        lst.SubItems.Add(dbStatus.IndexCount.ToString());
                        lst.SubItems.Add(GetSize(dbStatus.IndexSize));
                        lst.SubItems.Add(dbStatus.ObjectCount.ToString());
                        lst.SubItems.Add(GetSize(dbStatus.StorageSize));
                        lstSvr.Items.Add(lst);
                    }

                }
                catch (Exception)
                {
                    //throw;
                }
            }
        }
        /// <summary>
        /// 将数据Opr放入ListView
        /// </summary>
        /// <param name="lstSrvOpr"></param>
        public static void FillSrvOprToList(ListView lstSrvOpr)
        {
            lstSrvOpr.Clear();
            Boolean hasHeader = false;
            foreach (string mongoSvrKey in _mongoSrvLst.Keys)
            {
                try
                {
                    MongoServer mongosvr = _mongoSrvLst[mongoSvrKey];
                    List<string> databaseNameList = mongosvr.GetDatabaseNames().ToList<string>();
                    foreach (string strDBName in databaseNameList)
                    {
                        MongoDatabase mongoDB = mongosvr.GetDatabase(strDBName);
                        BsonDocument dbStatus = mongoDB.GetCurrentOp();
                        if (dbStatus.GetValue("inprog").AsBsonArray.Count > 0)
                        {
                            if (!hasHeader)
                            {

                                lstSrvOpr.Columns.Add("Name");
                                foreach (string item in dbStatus.GetValue("inprog").AsBsonArray[0].AsBsonDocument.Names)
                                {
                                    lstSrvOpr.Columns.Add(item);
                                }
                                hasHeader = true;
                            }

                            BsonArray doc = dbStatus.GetValue("inprog").AsBsonArray;
                            foreach (BsonDocument item in doc)
                            {
                                ListViewItem lst = new ListViewItem(mongoSvrKey + "." + strDBName);
                                foreach (string itemName in item.Names)
                                {
                                    lst.SubItems.Add(item.GetValue(itemName).ToString());
                                }
                                lstSrvOpr.Items.Add(lst);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    //throw;
                }


            }
        }
        #endregion

        #region"数据导航"
        /// <summary>
        /// 数据集总记录数
        /// </summary>
        public static int CurrentCollectionTotalCnt = 0;
        /// <summary>
        /// Skip记录数
        /// </summary>
        public static int SkipCnt = 0;
        /// <summary>
        /// 是否存在下一页
        /// </summary>
        public static bool HasNextPage;
        /// <summary>
        /// 是否存在上一页
        /// </summary>
        public static bool HasPrePage;
        /// <summary>
        /// 数据导航
        /// </summary>
        public enum PageChangeOpr
        {
            /// <summary>
            /// 第一页
            /// </summary>
            FirstPage,
            /// <summary>
            /// 最后一页
            /// </summary>
            LastPage,
            /// <summary>
            /// 上一页
            /// </summary>
            PrePage,
            /// <summary>
            /// 下一页
            /// </summary>
            NextPage
        }

        /// <summary>
        /// 换页操作
        /// </summary>
        /// <param name="IsNext"></param>
        /// <param name="strTag"></param>
        /// <param name="dataShower"></param>
        public static void PageChanged(PageChangeOpr pageChangeMode, string strTag, List<Control> dataShower)
        {
            switch (pageChangeMode)
            {
                case PageChangeOpr.FirstPage:
                    SkipCnt = 0;
                    break;
                case PageChangeOpr.LastPage:
                    if (CurrentCollectionTotalCnt % SystemManager.ConfigHelperInstance.LimitCnt == 0)
                    {
                        //没有余数的时候，600 % 100 == 0  => Skip = 600-100 = 500
                        SkipCnt = CurrentCollectionTotalCnt - SystemManager.ConfigHelperInstance.LimitCnt;
                    }
                    else
                    {
                        // 630 % 100 == 30  => Skip = 630-30 = 600  
                        SkipCnt = CurrentCollectionTotalCnt - CurrentCollectionTotalCnt % SystemManager.ConfigHelperInstance.LimitCnt;
                    }
                    break;
                case PageChangeOpr.NextPage:
                    SkipCnt += SystemManager.ConfigHelperInstance.LimitCnt;
                    break;
                case PageChangeOpr.PrePage:
                    SkipCnt -= SystemManager.ConfigHelperInstance.LimitCnt;
                    break;
                default:
                    break;
            }
            FillDataToControl(strTag, dataShower);
        }
        /// <summary>
        /// 设置导航状态
        /// </summary>
        public static void SetPageEnable()
        {
            if (SkipCnt == 0)
            {
                HasPrePage = false;
            }
            else
            {
                HasPrePage = true;
            }
            if ((SkipCnt + SystemManager.ConfigHelperInstance.LimitCnt) >= CurrentCollectionTotalCnt)
            {
                HasNextPage = false;
            }
            else
            {
                HasNextPage = true;
            }
        }

        #endregion

        #region "辅助方法"
        /// <summary>
        /// Size的文字表达
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private static string GetSize(long size)
        {
            string strSize = string.Empty;
            string[] Unit = new string[]{
                "Byte","KB","MB","GB","TB"
            };
            if (size == 0)
            {
                return "0 Byte";
            }
            byte unitOrder = 2;
            double tempSize = size / Math.Pow(2, 20);
            while (!(tempSize > 0.1 & tempSize < 1000))
            {
                if (tempSize < 0.1)
                {
                    tempSize = tempSize * 1024;
                    unitOrder--;
                }
                else
                {

                    tempSize = tempSize / 1024;
                    unitOrder++;
                }
            }
            return string.Format("{0:F2}", tempSize) + " " + Unit[unitOrder];
        }
        #endregion

    }
}
