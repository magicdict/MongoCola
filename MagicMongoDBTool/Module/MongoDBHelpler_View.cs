using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace MagicMongoDBTool.Module
{
    public  static partial class MongoDBHelpler
    {
        public static Dictionary<String, MongoServer> mongosrvlst = new Dictionary<String, MongoServer>();
        public static Boolean AddServer(List<ConfigHelper.MongoConnectionConfig> connlst)
        {
            try
            {
                foreach (ConfigHelper.MongoConnectionConfig item in connlst)
                {
                    MongoServerSettings mongosvrsetting_Master = new MongoServerSettings();
                    mongosvrsetting_Master.ConnectionMode = ConnectionMode.Direct;
                    mongosvrsetting_Master.SlaveOk = true;
                    mongosvrsetting_Master.Server = new MongoServerAddress(item.IpAddr, item.Port);
                    MongoServer Mastermongosvr = new MongoServer(mongosvrsetting_Master);
                    mongosrvlst.Add(item.HostName, Mastermongosvr);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public const String ServiceTag = "MongoService";
        public const String DataBaseTag = "MongoDatabase";
        public const String CollectionTag = "MongoCollection";
        public const String DocumentTag = "MongoDocument";
        public const String GridFileSystemTag = "MongoGFS";
        public const String UserListTag = "MongoUserList";
        public const String UserTag = "MongoUser";

        public static void FillMongodbToTreeView(TreeView trvMongoDB)
        {
            trvMongoDB.Nodes.Clear();
            foreach (String mongosvrKey in mongosrvlst.Keys)
            {
                MongoServer mongosvr = mongosrvlst[mongosvrKey];
                TreeNode mongosrvnode = new TreeNode(mongosvrKey + " [" + mongosvr.Settings.Server.Host + ":" + mongosvr.Settings.Server.Port + "]");
                mongosrvnode.Tag = ServiceTag + ":" + mongosvrKey;

                List<String> DatabaseNameList = mongosvr.GetDatabaseNames().ToList<String>();
                foreach (String strDBName in DatabaseNameList)
                {
                    mongosrvnode.Nodes.Add(FillDataBaseInfoToTreeNode(strDBName, mongosvr,mongosvrKey));
                }
                trvMongoDB.Nodes.Add(mongosrvnode);
            }
        }
        private static TreeNode FillDataBaseInfoToTreeNode(String strDBName, MongoServer mongosvr,String mongosvrKey)
        {
            TreeNode mongoDBNode = new TreeNode(strDBName);
            mongoDBNode.Tag = DataBaseTag + ":" + mongosvrKey + "/" + strDBName;

            MongoDatabase Mongodb = mongosvr.GetDatabase(strDBName);

            List<String> ColNameList = Mongodb.GetCollectionNames().ToList<String>();
            foreach (String strColName in ColNameList)
            {
                TreeNode mongoColNode = FillCollectionInfoToTreeNode(strColName, Mongodb, mongosvrKey);
                mongoDBNode.Nodes.Add(mongoColNode);
            }

            //FileSystem
            MongoGridFS mongoGridFs = Mongodb.GetGridFS(new global::MongoDB.Driver.GridFS.MongoGridFSSettings());
            TreeNode fsNode = new TreeNode("文件系统");
            fsNode.Tag = GridFileSystemTag + ":" + mongosvrKey + "/" + strDBName + "/" + mongoGridFs.Files.Name;
            mongoDBNode.Nodes.Add(fsNode);


            //User
            TreeNode userlstNode = new TreeNode("用户列表");
            userlstNode.Tag = UserListTag + ":" + mongosvrKey + "/" + strDBName + "/" + mongoGridFs.Files.Name;
            MongoUser[] mongouserlst = Mongodb.FindAllUsers();
            foreach (MongoUser mongouser in mongouserlst)
            {
                TreeNode userNode = new TreeNode(mongouser.Username);
                userlstNode.Nodes.Add(userNode);
            }
            mongoDBNode.Nodes.Add(userlstNode);
            return mongoDBNode;
        }
        private static TreeNode FillCollectionInfoToTreeNode(String strColName, MongoDatabase Mongodb, String mongosvrKey)
        {
            TreeNode mongoColNode;
            switch (strColName)
            {
                case "system.indexes":
                    mongoColNode = new TreeNode("索引(" + strColName + ")");
                    break;
                case "system.js":
                    mongoColNode = new TreeNode("存储Javascript(" + strColName + ")");
                    break;
                default:
                    mongoColNode = new TreeNode(strColName);
                    break;
            }
            mongoColNode.Tag = CollectionTag + ":" + mongosvrKey + "/" + Mongodb.Name + "/" + strColName;

            MongoCollection mongoCol = Mongodb.GetCollection(strColName);

            //Start ListIndex
            TreeNode mongoIndex = new TreeNode("Indexes");
            List<BsonDocument> IndexList = mongoCol.GetIndexes().ToList<BsonDocument>();
            foreach (BsonDocument Indexdoc in IndexList)
            {
                TreeNode mongoIndexNode = new TreeNode("Index:" + Indexdoc.GetValue("name"));
                foreach (String item in Indexdoc.Names)
                {
                    TreeNode mongoIndexItemNode = new TreeNode(item + ":" + Indexdoc.GetValue(item));

                    mongoIndexNode.Nodes.Add(mongoIndexItemNode);
                }
                mongoIndex.Nodes.Add(mongoIndexNode);
            }
            mongoColNode.Nodes.Add(mongoIndex);
            //End ListIndex

            //Start Data
            TreeNode mongoData = new TreeNode("Data");
            mongoData.Tag = DocumentTag + ":" + mongosvrKey + "/" + Mongodb.Name + "/" + strColName;
            mongoColNode.Nodes.Add(mongoData);
            //End Data
            return mongoColNode;
        }
        public static void FillDataToListView(String strTag, ListView lstData)
        {
            String CollectionPath = strTag.Split(":".ToCharArray())[1];
            String[] cp = CollectionPath.Split("/".ToCharArray());
            List<BsonDocument> DataList = new List<BsonDocument>();
            if (cp[2] == "fs.files")
            {
                DataList = mongosrvlst[cp[0]].GetDatabase(cp[1]).GetGridFS(new global::MongoDB.Driver.GridFS.MongoGridFSSettings())
                                                                .Files.FindAllAs<BsonDocument>().ToList<BsonDocument>();
                if (DataList.Count == 0) { return; }
                SetGridFileToListView(DataList, lstData);
            }
            else
            {
                DataList = mongosrvlst[cp[0]].GetDatabase(cp[1]).GetCollection(cp[2]).FindAllAs<BsonDocument>().ToList<BsonDocument>();
                if (DataList.Count == 0) { return; }
                List<String> Columnlist = new List<String>();
                foreach (BsonDocument Docitem in DataList)
                {
                    ListViewItem lstItem = new ListViewItem();
                    foreach (String item in Docitem.Names)
                    {
                        if (!Columnlist.Contains(item))
                        {
                            Columnlist.Add(item);
                            lstData.Columns.Add(item);
                        }
                    }
                    //Key:_id
                    lstItem.Text = Docitem.GetValue(Columnlist[0]).ToString();
                    //OtherItems
                    for (int i = 1; i < Columnlist.Count; i++)
                    {
                        BsonValue val;
                        Docitem.TryGetValue(Columnlist[i].ToString(), out val);
                        if (val == null)
                        {
                            lstItem.SubItems.Add("");
                        }
                        else
                        {
                            if (val.IsBsonDocument)
                            {
                                lstItem.SubItems.Add(val.ToString() + "[包含" + val.ToBsonDocument().ElementCount + "个元素的文档]");
                            }
                            else
                            {
                                lstItem.SubItems.Add(val.ToString());
                            }
                        }
                    }
                    lstData.Items.Add(lstItem);
                }
            }
        }

        private static void SetGridFileToListView(List<BsonDocument> DataList, ListView lstData)
        {
            lstData.Columns.Add("文件名称");
            lstData.Columns.Add("文件大小");
            lstData.Columns.Add("块大小");
            lstData.Columns.Add("上传日期");
            lstData.Columns.Add("MD5");
            foreach (BsonDocument docfile in DataList)
            {
                ListViewItem lstItem = new ListViewItem();
                lstItem.Text = docfile.GetValue("filename").ToString();
                lstItem.SubItems.Add(GetSize((int)docfile.GetValue("length")));
                lstItem.SubItems.Add(GetSize((int)docfile.GetValue("chunkSize")));
                lstItem.SubItems.Add(docfile.GetValue("uploadDate").ToString());
                lstItem.SubItems.Add(docfile.GetValue("md5").ToString());
                lstData.Items.Add(lstItem);
            }
        }

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
            foreach (String mongosvrKey in mongosrvlst.Keys)
            {
                MongoServer mongosvr = mongosrvlst[mongosvrKey];
                List<String> DatabaseNameList = mongosvr.GetDatabaseNames().ToList<String>();
                foreach (String strDBName in DatabaseNameList)
                {
                    MongoDatabase Mongodb = mongosvr.GetDatabase(strDBName);

                    List<String> ColNameList = Mongodb.GetCollectionNames().ToList<String>();
                    foreach (String strColName in ColNameList)
                    {

                        CollectionStatsResult dbstatus = Mongodb.GetCollection(strColName).GetStats();
                        ListViewItem lst = new ListViewItem(strDBName + "." + strColName);
                        lst.SubItems.Add(dbstatus.ObjectCount.ToString());
                        lst.SubItems.Add(GetSize(dbstatus.DataSize));
                        lst.SubItems.Add(GetSize(dbstatus.StorageSize));
                        lst.SubItems.Add(GetSize(dbstatus.TotalIndexSize));
                        lst.SubItems.Add(GetSize((long)dbstatus.AverageObjectSize));

                        lst.SubItems.Add(dbstatus.PaddingFactor.ToString());
                        lstData.Items.Add(lst);
                    }
                }
            }
        }
        public static void FillSrvStatusToList(ListView lstData)
        {
            lstData.Clear();
            lstData.Columns.Add("名称");
            lstData.Columns.Add("数据集数量");
            lstData.Columns.Add("数据大小");
            lstData.Columns.Add("文件大小");
            lstData.Columns.Add("索引数量");
            lstData.Columns.Add("索引数量大小");
            lstData.Columns.Add("对象数量");
            lstData.Columns.Add("占用大小");
            foreach (String mongosvrKey in mongosrvlst.Keys)
            {
                MongoServer mongosvr = mongosrvlst[mongosvrKey];
                List<String> DatabaseNameList = mongosvr.GetDatabaseNames().ToList<String>();
                foreach (String strDBName in DatabaseNameList)
                {
                    MongoDatabase Mongodb = mongosvr.GetDatabase(strDBName);
                    DatabaseStatsResult dbstatus = Mongodb.GetStats();
                    ListViewItem lst = new ListViewItem(mongosvrKey + "." + strDBName);
                    lst.SubItems.Add(dbstatus.CollectionCount.ToString());
                    lst.SubItems.Add(GetSize(dbstatus.DataSize));
                    lst.SubItems.Add(GetSize(dbstatus.FileSize));
                    lst.SubItems.Add(dbstatus.IndexCount.ToString());
                    lst.SubItems.Add(GetSize(dbstatus.IndexSize));
                    lst.SubItems.Add(dbstatus.ObjectCount.ToString());
                    lst.SubItems.Add(GetSize(dbstatus.StorageSize));
                    lstData.Items.Add(lst);
                }
            }
        }
        public static void FillSrvOprToList(ListView lstData)
        {
            lstData.Clear();
            Boolean HasHeader = false;
            foreach (String mongosvrKey in mongosrvlst.Keys)
            {
                MongoServer mongosvr = mongosrvlst[mongosvrKey];
                List<String> DatabaseNameList = mongosvr.GetDatabaseNames().ToList<String>();
                foreach (String strDBName in DatabaseNameList)
                {
                    MongoDatabase Mongodb = mongosvr.GetDatabase(strDBName);
                    BsonDocument dbstatus = Mongodb.GetCurrentOp();
                    if (!HasHeader)
                    {

                        lstData.Columns.Add("Name");
                        foreach (String item in dbstatus.GetValue("inprog").AsBsonArray[0].AsBsonDocument.Names)
                        {
                            lstData.Columns.Add(item);

                        }
                        HasHeader = true;
                    }

                    BsonArray doc = dbstatus.GetValue("inprog").AsBsonArray;
                    foreach (BsonDocument item in doc)
                    {
                        ListViewItem lst = new ListViewItem(mongosvrKey + "." + strDBName);
                        foreach (String itemName in item.Names)
                        {
                            lst.SubItems.Add(item.GetValue(itemName).ToString());
                        }
                        lstData.Items.Add(lst);
                    }
                }
            }
        }

        //public static void FillSomething() {
        //    foreach (String mongosvrKey in mongosrvlst.Keys)
        //    {
        //        MongoServer mongosvr = mongosrvlst[mongosvrKey];
        //    }
        //}

        private static String GetSize(long mSize)
        {
            String strSize = String.Empty;
            String[] Unit = new String[]{
                "Byte","KB","MB","GB","TB"
            };
            if (mSize == 0)
            {
                return "0 Byte";
            }
            byte UnitOrder = 2;
            Double tempSize = mSize / Math.Pow(2, 20);
            while (!(tempSize > 0.1 & tempSize < 1000))
            {
                if (tempSize < 0.1)
                {
                    tempSize = tempSize * 1024;
                    UnitOrder--;
                }
                else
                {

                    tempSize = tempSize / 1024;
                    UnitOrder++;
                }
            }
            return string.Format("{0:F2}", tempSize) + " " + Unit[UnitOrder];
        }


    }
}
