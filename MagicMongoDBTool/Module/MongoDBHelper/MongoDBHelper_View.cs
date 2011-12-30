using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;
namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {

        #region"展示数据集内容"

        /// <summary>
        /// 通过读取N条记录来确定数据集结构
        /// </summary>
        /// <param name="mongoCol">数据集</param>
        /// <param name="CheckRecordCnt">使用数据量，省略时为全部，海量数据时相当消耗性能</param>
        /// <returns></returns>
        public static List<String> GetCollectionSchame(MongoCollection mongoCol, int CheckRecordCnt = 100)
        {
            List<String> _ColumnList = new List<String>();
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
        public static List<String> getBsonNameList(String docName, BsonDocument doc)
        {
            List<String> _ColumnList = new List<String>();
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
                    _ColumnList.Add(docName + (docName != String.Empty ? "." : String.Empty) + strName);
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
        public static void FillDataToControl(String strTag, List<Control> controls)
        {
            String collectionPath = strTag.Split(":".ToCharArray())[1];
            String[] cp = collectionPath.Split("/".ToCharArray());
            MongoCollection mongoCol = _mongoSrvLst[cp[(int)PathLv.ServerLV]]
                                      .GetDatabase(cp[(int)PathLv.DatabaseLV])
                                      .GetCollection(cp[(int)PathLv.CollectionLV]);

            List<BsonDocument> dataList = new List<BsonDocument>();
            //Query condition:
            if (IsUseFilter)
            {
                dataList = mongoCol.FindAs<BsonDocument>(GetQuery(SystemManager.CurrDataFilter.QueryConditionList))
                                   .SetSkip(SkipCnt)
                                   .SetFields(GetOutputFields(SystemManager.CurrDataFilter.QueryFieldList))
                                   .SetSortOrder(GetSort(SystemManager.CurrDataFilter.QueryFieldList))
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
            if (SkipCnt == 0)
            {
                if (IsUseFilter)
                {
                    CurrentCollectionTotalCnt = mongoCol.FindAs<BsonDocument>(GetQuery(SystemManager.CurrDataFilter.QueryConditionList))
                                                        .ToList<BsonDocument>().Count;

                }
                else
                {
                    CurrentCollectionTotalCnt = mongoCol.FindAllAs<BsonDocument>().ToList<BsonDocument>().Count;
                }
            }
            if (dataList.Count == 0)
            {
                return;
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
                        FillDataToTextBox((TextBox)control, dataList);
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
        public static String ConvertForShow(BsonValue val)
        {
            //二进制数据
            if (val.IsBsonBinaryData)
            {
                _hasBSonBinary = true;
                return "[Binary]";
            }
            //空值
            if (val.IsBsonNull)
            {
                return "[Empty]";
            }

            //文档
            if (val.IsBsonDocument)
            {
                return val.ToString() + "[Contains" + val.ToBsonDocument().ElementCount + "Documents]";
            }

            //时间
            if (val.IsBsonDateTime)
            {
                DateTime bsonData = val.AsDateTime;
                //@flydreamer提出的本地化时间要求
                return bsonData.ToLocalTime().ToString();
            }

            //字符
            if (val.IsString)
            {
                //只有在字符的时候加上""
                return "\"" + val.ToString() + "\"";
            }

            //其他
            return val.ToString();
        }
        /// <summary>
        /// 将数据放入TextBox里进行展示
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="txtData"></param>
        /// <param name="dataList"></param>
        public static void FillDataToTextBox(TextBox txtData, List<BsonDocument> dataList)
        {
            txtData.Clear();
            if (_hasBSonBinary)
            {
                txtData.Text = "Binary Data";
            }
            else
            {
                int Count = 1;
                StringBuilder sb = new StringBuilder();
                foreach (BsonDocument BsonDoc in dataList)
                {
                    sb.AppendLine("/* " + (SkipCnt + Count).ToString() + " */");
                    sb.AppendLine("{");
                    foreach (String itemName in BsonDoc.Names)
                    {
                        BsonValue value = BsonDoc.GetValue(itemName);
                        sb.Append(GetBsonElementText(itemName, value, 0));
                    }
                    sb.Append("}");
                    sb.AppendLine("");
                    sb.AppendLine("");
                    Count++;
                }
                txtData.Text = sb.ToString();
            }
        }
        /// <summary>
        /// 单个文档的TextView表示整理
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="value"></param>
        /// <param name="DeepLv"></param>
        /// <returns></returns>
        public static String GetBsonElementText(String itemName, BsonValue value, int DeepLv)
        {
            String rtnText = String.Empty;
            if (value.IsBsonArray)
            {
                int count = 1;
                BsonArray mBsonlst = value.AsBsonArray;
                for (int BsonNo = 0; BsonNo < mBsonlst.Count; BsonNo++)
                {
                    if (BsonNo == 0)
                    {
                        if (itemName != String.Empty)
                        {
                            for (int i = 0; i < DeepLv; i++)
                            {
                                rtnText += "  ";
                            }
                            rtnText += "  \"" + itemName + "\":";
                        }
                        rtnText += "[";
                        rtnText += System.Environment.NewLine;
                        DeepLv++;
                    }
                    DeepLv++;
                    rtnText += GetBsonElementText(String.Empty, mBsonlst[BsonNo], DeepLv);
                    DeepLv--;
                    if (BsonNo == mBsonlst.Count - 1)
                    {
                        DeepLv--;
                        //   "itemName": "Value"
                        for (int i = 0; i < DeepLv; i++)
                        {
                            rtnText += "  ";
                        }
                        rtnText += "  ]";
                        rtnText += System.Environment.NewLine;
                    }
                    count++;
                }
            }
            else
            {
                if (value.IsBsonDocument)
                {
                    if (itemName != String.Empty)
                    {
                        //   "itemName": "Value"
                        for (int i = 0; i < DeepLv; i++)
                        {
                            rtnText += "  ";
                        }
                        rtnText += "  \"" + itemName + "\":";
                        rtnText += System.Environment.NewLine;
                    }
                    DeepLv++;
                    for (int i = 0; i < DeepLv; i++)
                    {
                        rtnText += "  ";
                    }
                    rtnText += "{";
                    rtnText += System.Environment.NewLine;
                    BsonDocument SubDoc = value.ToBsonDocument();
                    foreach (String SubitemName in SubDoc.Names)
                    {
                        BsonValue Subvalue = SubDoc.GetValue(SubitemName);
                        rtnText += GetBsonElementText(SubitemName, Subvalue, DeepLv);
                    }
                    for (int i = 0; i < DeepLv; i++)
                    {
                        rtnText += "  ";
                    }
                    rtnText += "}";
                    rtnText += System.Environment.NewLine;
                    DeepLv--;
                }
                else
                {
                    if (itemName != String.Empty)
                    {
                        //   "itemName": "Value"
                        for (int i = 0; i < DeepLv; i++)
                        {
                            rtnText += "  ";
                        }
                        rtnText += "  \"" + itemName + "\":";
                    }
                    rtnText += ConvertForShow(value) + System.Environment.NewLine;
                }
            }
            return rtnText;
        }
        /// <summary>
        /// 将数据放入TreeView里进行展示
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="trvData"></param>
        /// <param name="dataList"></param>
        public static void FillDataToTreeView(String collectionName, TreeView trvData, List<BsonDocument> dataList)
        {
            trvData.Nodes.Clear();
            int Count = 1;
            foreach (BsonDocument item in dataList)
            {
                TreeNode dataNode = new TreeNode(collectionName + "[" + (SkipCnt + Count).ToString() + "]");
                //这里保存真实的主Key数据，删除的时候使用
                switch (collectionName)
                {
                    case COLLECTION_NAME_GFS_FILES:
                        dataNode.Tag = item.GetElement(1).Value;
                        break;
                    case COLLECTION_NAME_USER:
                        dataNode.Tag = item.GetElement(1).Value;
                        break;
                    default:
                        //SelectDocId属性的设置
                        dataNode.Tag = item.GetElement(0).Value;
                        break;
                }
                FillBsonDocToTreeNode(dataNode, item, (BsonValue)dataNode.Tag);
                trvData.Nodes.Add(dataNode);
                Count++;
            }
        }
        /// <summary>
        /// 将数据放入TreeNode里进行展示
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="doc"></param>
        public static void FillBsonDocToTreeNode(TreeNode treeNode, BsonDocument doc, BsonValue Key)
        {
            foreach (var item in doc.Elements)
            {
                if (item.Value.IsBsonDocument)
                {
                    TreeNode newItem = new TreeNode(item.Name);
                    FillBsonDocToTreeNode(newItem, item.Value.ToBsonDocument(), Key);
                    newItem.Tag = Key;
                    treeNode.Nodes.Add(newItem);
                }
                else
                {
                    if (item.Value.IsBsonArray)
                    {
                        TreeNode newItem = new TreeNode(item.Name + Array_Mark);
                        int count = 1;
                        foreach (BsonValue SubItem in item.Value.AsBsonArray)
                        {
                            if (SubItem.IsBsonDocument)
                            {
                                TreeNode newSubItem = new TreeNode(item.Name + "[" + count + "]");
                                FillBsonDocToTreeNode(newSubItem, SubItem.ToBsonDocument(), Key);
                                newSubItem.Tag = Key;
                                newItem.Nodes.Add(newSubItem);
                            }
                            else
                            {
                                TreeNode newSubItem = new TreeNode(SubItem.ToString());
                                newSubItem.Tag = Key;
                                newItem.Nodes.Add(newSubItem);
                            }
                            count++;
                        }
                        newItem.Tag = Key;
                        treeNode.Nodes.Add(newItem);
                    }
                    else
                    {
                        TreeNode ElementNode = new TreeNode(item.Name + ":" + ConvertForShow(item.Value));
                        ElementNode.Tag = Key;
                        treeNode.Nodes.Add(ElementNode);
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
        public static void FillDataToListView(String collectionName, ListView lstData, List<BsonDocument> dataList)
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
                    List<String> _columnlist = new List<String>();
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
        /// 用户列表
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="lstData"></param>
        private static void SetUserListToListView(List<BsonDocument> dataList, ListView lstData)
        {
            lstData.Clear();
            if (!SystemManager.IsUseDefaultLanguage())
            {
                lstData.Columns.Add("ID");
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Common_Username));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Common_ReadOnly));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Common_Password));
            }
            else
            {
                lstData.Columns.Add("ID");
                lstData.Columns.Add("user");
                lstData.Columns.Add("readonly");
                lstData.Columns.Add("password");
            }
            foreach (BsonDocument docFile in dataList)
            {
                ListViewItem lstItem = new ListViewItem();
                lstItem.Text = docFile.GetValue("_id").ToString();
                lstItem.SubItems.Add(docFile.GetValue("user").ToString());
                lstItem.SubItems.Add(docFile.GetValue("readOnly").ToString());
                //密码是密文表示的，这里没有安全隐患
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
            if (!SystemManager.IsUseDefaultLanguage())
            {
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.GFS_filename));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.GFS_length));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.GFS_chunkSize));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.GFS_uploadDate));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.GFS_md5));
            }
            else
            {
                lstData.Columns.Add("filename");
                lstData.Columns.Add("length");
                lstData.Columns.Add("chunkSize");
                lstData.Columns.Add("uploadDate");
                lstData.Columns.Add("MD5");
            }
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
        /// Fill Server Status to treeview
        /// </summary>
        /// <param name="trvSvrStatus"></param>
        public static void FillSrvStatusToList(TreeView trvSvrStatus)
        {
            List<BsonDocument> SrvDocList = new List<BsonDocument>();
            foreach (String mongoSvrKey in _mongoSrvLst.Keys)
            {
                try
                {
                    MongoServer mongosvr = _mongoSrvLst[mongoSvrKey];
                    //flydreamer提供的代码
                    BsonDocument cr = RunMongoCommandAtMongoSrv(serverStatus_Command, mongosvr).Response;
                    SrvDocList.Add(cr);
                }
                catch (Exception)
                {
                    //throw;
                }
            }
            FillDataToTreeView("Server Status", trvSvrStatus, SrvDocList);
        }

        /// <summary>
        /// Fill Database status to ListView
        /// </summary>
        /// <param name="lstSvr"></param>
        public static void FillDataBaseStatusToList(ListView lstSvr)
        {
            lstSvr.Clear();
            if (SystemManager.IsUseDefaultLanguage())
            {
                lstSvr.Columns.Add("DataBaseName");
                lstSvr.Columns.Add("CollectionCount");
                lstSvr.Columns.Add("DataSize");
                lstSvr.Columns.Add("FileSize");
                lstSvr.Columns.Add("IndexCount");
                lstSvr.Columns.Add("IndexSize");
                lstSvr.Columns.Add("ObjectCount");
                lstSvr.Columns.Add("StorageSize");
            }
            else
            {
                lstSvr.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.DataBase_Status_DataBaseName));
                lstSvr.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.DataBase_Status_CollectionCount));
                lstSvr.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.DataBase_Status_DataSize));
                lstSvr.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.DataBase_Status_FileSize));
                lstSvr.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.DataBase_Status_IndexCount));
                lstSvr.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.DataBase_Status_IndexSize));
                lstSvr.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.DataBase_Status_ObjectCount));
                lstSvr.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.DataBase_Status_StorageSize));

            }
            foreach (String mongoSvrKey in _mongoSrvLst.Keys)
            {
                try
                {
                    MongoServer mongoSvr = _mongoSrvLst[mongoSvrKey];
                    List<String> databaseNameList = mongoSvr.GetDatabaseNames().ToList<String>();
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
                            lst.SubItems.Add("0");
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
        /// fill Collection status to ListView
        /// </summary>
        /// <param name="lstData"></param>
        public static void FillCollectionStatusToList(ListView lstData)
        {
            lstData.Clear();

            if (SystemManager.IsUseDefaultLanguage())
            {
                lstData.Columns.Add("CollectionName");
                lstData.Columns.Add("ObjectCount");
                lstData.Columns.Add("DataSize");
                lstData.Columns.Add("LastExtentSize");
                lstData.Columns.Add("StorageSize");
                lstData.Columns.Add("TotalIndexSize");
                lstData.Columns.Add("AverageObjectSize");
                lstData.Columns.Add("PaddingFactor");
            }
            else
            {
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Status_CollectionName));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Status_ObjectCount));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Status_DataSize));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Status_LastExtentSize));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Status_StorageSize));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Status_TotalIndexSize));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Status_AverageObjectSize));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Status_PaddingFactor));
            }
            foreach (String mongoSvrKey in _mongoSrvLst.Keys)
            {
                try
                {
                    MongoServer mongoSvr = _mongoSrvLst[mongoSvrKey];
                    List<String> databaseNameList = mongoSvr.GetDatabaseNames().ToList<String>();
                    foreach (String strDBName in databaseNameList)
                    {
                        MongoDatabase mongoDB = mongoSvr.GetDatabase(strDBName);

                        List<String> colNameList = mongoDB.GetCollectionNames().ToList<String>();
                        foreach (String strColName in colNameList)
                        {
                            try
                            {
                                CollectionStatsResult CollectionStatus = mongoDB.GetCollection(strColName).GetStats();
                                ListViewItem lst = new ListViewItem(mongoSvrKey + "." + strDBName + "." + strColName);
                                lst.SubItems.Add(CollectionStatus.ObjectCount.ToString());
                                lst.SubItems.Add(GetSize(CollectionStatus.DataSize));
                                lst.SubItems.Add(GetSize(CollectionStatus.LastExtentSize));
                                lst.SubItems.Add(GetSize(CollectionStatus.StorageSize));
                                lst.SubItems.Add(GetSize(CollectionStatus.TotalIndexSize));
                                if (CollectionStatus.ObjectCount != 0)
                                {
                                    //在某些条件下，这个值会抛出异常，IndexKeyNotFound
                                    //同时发现,这个时候Count = 0,TryCatch可能会消耗时间，所以改为条件判断
                                    lst.SubItems.Add(GetSize((long)CollectionStatus.AverageObjectSize));
                                }
                                else
                                {
                                    lst.SubItems.Add("0");
                                }

                                try
                                {
                                    //在某些条件下，这个值会抛出异常，IndexKeyNotFound
                                    lst.SubItems.Add(CollectionStatus.PaddingFactor.ToString());
                                }
                                catch (Exception)
                                {
                                    lst.SubItems.Add("0");
                                }
                                lstData.Items.Add(lst);
                            }
                            catch (Exception)
                            {
                                //throw;
                                //TODO:排序时候会发生错误，所以暂时不对应
                                //lstData.Items.Add(new ListViewItem(strColName + "[Exception]"));
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
        /// <summary>
        /// 将数据Opr放入ListView
        /// </summary>
        /// <param name="lstSrvOpr"></param>
        public static void FillSrvOprToList(ListView lstSrvOpr)
        {
            lstSrvOpr.Clear();
            Boolean hasHeader = false;
            foreach (String mongoSvrKey in _mongoSrvLst.Keys)
            {
                try
                {
                    MongoServer mongosvr = _mongoSrvLst[mongoSvrKey];
                    List<String> databaseNameList = mongosvr.GetDatabaseNames().ToList<String>();
                    foreach (String strDBName in databaseNameList)
                    {
                        try
                        {
                            MongoDatabase mongoDB = mongosvr.GetDatabase(strDBName);
                            BsonDocument dbStatus = mongoDB.GetCurrentOp();
                            if (dbStatus.GetValue("inprog").AsBsonArray.Count > 0)
                            {
                                if (!hasHeader)
                                {

                                    lstSrvOpr.Columns.Add("Name");
                                    foreach (String item in dbStatus.GetValue("inprog").AsBsonArray[0].AsBsonDocument.Names)
                                    {
                                        lstSrvOpr.Columns.Add(item);
                                    }
                                    hasHeader = true;
                                }

                                BsonArray doc = dbStatus.GetValue("inprog").AsBsonArray;
                                foreach (BsonDocument item in doc)
                                {
                                    ListViewItem lst = new ListViewItem(mongoSvrKey + "." + strDBName);
                                    foreach (String itemName in item.Names)
                                    {
                                        lst.SubItems.Add(item.GetValue(itemName).ToString());
                                    }
                                    lstSrvOpr.Items.Add(lst);
                                }
                            }
                        }
                        catch
                        {
                            //throw
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
        public static void PageChanged(PageChangeOpr pageChangeMode, String strTag, List<Control> dataShower)
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

        #region "辅助方法和排序器"

        internal class lvwColumnSorter : System.Collections.IComparer
        {
            /// <summary>
            /// 比较方式
            /// </summary>
            public enum SortMethod
            {
                StringCompare,
                SizeCompare,
                NumberCompare
            }

            /// <summary>
            /// 指定按照哪个列排序  
            /// </summary>
            private int ColumnToSort;
            /// <summary>
            /// 指定排序的方式  
            /// </summary>
            private SortOrder OrderOfSort;
            /// <summary>
            /// 声明CaseInsensitiveComparer类对象 
            /// </summary>
            private CaseInsensitiveComparer ObjectCompare;

            /// <summary>
            /// 比较方式 
            /// </summary>
            private SortMethod mCompareMethod;

            /// <summary>
            /// 构造函数
            /// </summary>
            public lvwColumnSorter()
            {
                ColumnToSort = 0;// 默认按第一列排序            
                OrderOfSort = SortOrder.None;// 排序方式为不排序            
                ObjectCompare = new CaseInsensitiveComparer();// 初始化CaseInsensitiveComparer类对象
                mCompareMethod = SortMethod.StringCompare; //是否使用Size比较
            }

            /// <summary>
            /// 比较
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(Object x, Object y)
            {
                ListViewItem lstX = (ListViewItem)x;
                ListViewItem lstY = (ListViewItem)y;
                int rtnCompare = 0;
                switch (mCompareMethod)
                {
                    case SortMethod.StringCompare:
                        rtnCompare = ObjectCompare.Compare(lstX.SubItems[ColumnToSort].Text, lstY.SubItems[ColumnToSort].Text);
                        break;
                    case SortMethod.SizeCompare:
                        rtnCompare = (int)(ReconvSize(lstX.SubItems[ColumnToSort].Text) - ReconvSize(lstY.SubItems[ColumnToSort].Text));
                        break;
                    case SortMethod.NumberCompare:
                        //当两个数字相减小于1时，(int)的强制转换会将结果变成0，所以不能使用减法来获得Ret。。。
                        if (Convert.ToDouble(lstX.SubItems[ColumnToSort].Text) > Convert.ToDouble(lstY.SubItems[ColumnToSort].Text))
                        {
                            rtnCompare = 1;
                        }
                        else
                        {
                            if (Convert.ToDouble(lstX.SubItems[ColumnToSort].Text) == Convert.ToDouble(lstY.SubItems[ColumnToSort].Text))
                            {
                                rtnCompare = 0;
                            }
                            else
                            {
                                rtnCompare = -1;
                            }
                        }
                        break;
                }
                if (OrderOfSort == SortOrder.Descending)
                {
                    rtnCompare = rtnCompare * -1;
                }
                return rtnCompare;
            }
            public SortMethod CompareMethod
            {
                set
                {
                    mCompareMethod = value;
                }
                get
                {
                    return mCompareMethod;
                }
            }

            /// 获取或设置按照哪一列排序.        
            public int SortColumn
            {
                set
                {
                    ColumnToSort = value;
                }
                get
                {
                    return ColumnToSort;
                }
            }
            /// 获取或设置排序方式.    
            public SortOrder Order
            {
                set
                {
                    OrderOfSort = value;
                }
                get
                {
                    return OrderOfSort;
                }
            }
        }
        /// <summary>
        /// 将执行结果转化为细节报告文字列
        /// </summary>
        /// <param name="Resultlst"></param>
        /// <returns></returns>
        public static String ConvertCommandResultlstToString(List<CommandResult> Resultlst)
        {
            String Details = String.Empty;
            foreach (CommandResult item in Resultlst)
            {
                Details += item.Response.ToString() + System.Environment.NewLine;
            }
            return Details;
        }
        /// <summary>
        /// Size的文字表达
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private static String GetSize(long size)
        {
            String[] Unit = new String[]{
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
            return String.Format("{0:F2}", tempSize) + " " + Unit[unitOrder];
        }
        /// <summary>
        /// 将表示的尺寸还原为实际尺寸以对应排序的要求
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static long ReconvSize(String size)
        {
            String[] Unit = new String[]{
                "Byte","KB","MB","GB","TB"
            };
            if (size == "0 Byte")
            {
                return 0;
            }
            for (int i = 0; i < Unit.Length; i++)
            {
                if (size.EndsWith(Unit[i].ToString()))
                {
                    size = size.Replace(Unit[i].ToString(), String.Empty).Trim();
                    return (long)(Convert.ToDouble(size) * Math.Pow(2, (i * 10)));
                }
            }
            return 0;
        }

        #endregion
    }
}
