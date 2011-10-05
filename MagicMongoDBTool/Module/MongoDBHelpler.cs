using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool.Module
{
    public static class MongoDBHelpler
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

        public static void FillDBToTreeView(TreeView trvMongoDB)
        {
            trvMongoDB.Nodes.Clear();
            foreach (String mongosvrKey in mongosrvlst.Keys)
            {
                MongoServer mongosvr = mongosrvlst[mongosvrKey];
                TreeNode mongosrvnode = new TreeNode(mongosvrKey + " [" + mongosvr.Settings.Server.Host + ":" + mongosvr.Settings.Server.Port + "]");

                List<String> DatabaseNameList = mongosvr.GetDatabaseNames().ToList<String>();
                foreach (String strDBName in DatabaseNameList)
                {
                    TreeNode mongoDBNode = new TreeNode(strDBName);
                    MongoDatabase Mongodb = mongosvr.GetDatabase(strDBName);

                    List<String> ColNameList = Mongodb.GetCollectionNames().ToList<String>();
                    foreach (String strColName in ColNameList)
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
                        mongoData.Tag = mongosvrKey + "/" + strDBName + "/" + strColName;
                        mongoColNode.Nodes.Add(mongoData);
                        //End Data

                        mongoDBNode.Nodes.Add(mongoColNode);
                    }

                    //FileSystem
                    MongoGridFS mongoGridFs = Mongodb.GetGridFS(new global::MongoDB.Driver.GridFS.MongoGridFSSettings());
                    TreeNode fsNode = new TreeNode("文件系统");
                    fsNode.Tag = mongosvrKey + "/" + strDBName + "/" + mongoGridFs.Files.Name;
                    mongoDBNode.Nodes.Add(fsNode);


                    //User
                    TreeNode userNode = new TreeNode("用户");
                    MongoUser[] mongouserlst = Mongodb.FindAllUsers();
                    foreach (MongoUser mongouser in mongouserlst)
                    {
                        userNode.Nodes.Add(mongouser.Username);
                    }
                    mongoDBNode.Nodes.Add(userNode);

                    mongosrvnode.Nodes.Add(mongoDBNode);
                }
                trvMongoDB.Nodes.Add(mongosrvnode);
            }
        }

        public static void FillDataToListView(String CollectionPath, ListView lstData)
        {
            lstData.Clear();
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
            lstData.Columns.Add("使用空间");
            lstData.Columns.Add("上传日期");
            lstData.Columns.Add("MD5");
            foreach (BsonDocument docfile in DataList)
            {
                ListViewItem lstItem = new ListViewItem();
                lstItem.Text = docfile.GetValue("filename").ToString();
                lstItem.SubItems.Add(docfile.GetValue("length").ToString());
                lstItem.SubItems.Add(docfile.GetValue("chunkSize").ToString());
                lstItem.SubItems.Add(docfile.GetValue("uploadDate").ToString());
                lstItem.SubItems.Add(docfile.GetValue("md5").ToString());
                lstData.Items.Add(lstItem);
            }
        }

    }
}
