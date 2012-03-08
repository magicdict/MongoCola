using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
                    //感谢cnblogs.com 网友Shadower
                    CurrentCollectionTotalCnt = (int)mongoCol.Count(GetQuery(SystemManager.CurrDataFilter.QueryConditionList));
                }
                else
                {
                    CurrentCollectionTotalCnt = (int)mongoCol.Count(); 
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
                        //FillJSONDataToTextBox((TextBox)control, dataList);
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
        /// 字符转Bsonvalue
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public static BsonValue ConvertFromString(String strData)
        {
            //以引号开始结尾的，解释为字符串
            if (strData.StartsWith("\"") && strData.EndsWith("\""))
            {
                return new BsonString(strData.Trim("\"".ToCharArray()));
            }
            return new BsonString("");
        }
        /// <summary>
        /// BsonValue转展示用字符
        /// </summary>
        /// <param name="bsonValue"></param>
        /// <returns></returns>
        public static String ConvertToString(BsonValue bsonValue)
        {
            //二进制数据
            if (bsonValue.IsBsonBinaryData)
            {
                _hasBSonBinary = true;
                return "[Binary]";
            }
            //空值
            if (bsonValue.IsBsonNull)
            {
                return "[Empty]";
            }
            //文档
            if (bsonValue.IsBsonDocument)
            {
                return bsonValue.ToString() + "[Contains" + bsonValue.ToBsonDocument().ElementCount + "Documents]";
            }
            //时间
            if (bsonValue.IsBsonDateTime)
            {
                DateTime bsonData = bsonValue.AsDateTime;
                //@flydreamer提出的本地化时间要求
                return bsonData.ToLocalTime().ToString();
            }

            //字符
            if (bsonValue.IsString)
            {
                //只有在字符的时候加上""
                return "\"" + bsonValue.ToString() + "\"";
            }

            //其他
            return bsonValue.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="txtData"></param>
        /// <param name="dataList"></param>
        public static void FillJSONDataToTextBox(TextBox txtData, List<BsonDocument> dataList)
        {
            txtData.Clear();
            int Count = 1;
            StringBuilder sb = new StringBuilder();
            foreach (BsonDocument BsonDoc in dataList)
            {
                sb.AppendLine("/* " + (SkipCnt + Count).ToString() + " */");
                sb.AppendLine(BsonDoc.ToJson());
                Count++;
            }
            txtData.Text = sb.ToString();
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
                    rtnText += ConvertToString(value) + System.Environment.NewLine;
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
                AddBsonDocToTreeNode(dataNode, item);
                trvData.Nodes.Add(dataNode);
                Count++;
            }
        }
        /// <summary>
        /// 将数据放入TreeNode里进行展示
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="doc"></param>
        public static void AddBsonDocToTreeNode(TreeNode treeNode, BsonDocument doc)
        {
            foreach (var item in doc.Elements)
            {
                if (item.Value.IsBsonDocument)
                {
                    TreeNode newItem = new TreeNode(item.Name + ":" + Document_Mark);
                    AddBsonDocToTreeNode(newItem, item.Value.ToBsonDocument());
                    newItem.Tag = item;
                    treeNode.Nodes.Add(newItem);
                }
                else
                {
                    if (item.Value.IsBsonArray)
                    {
                        TreeNode newItem = new TreeNode(item.Name + ":" + Array_Mark);
                        AddBSonArrayToTreeNode(newItem, item.Value.AsBsonArray);
                        newItem.Tag = item;
                        treeNode.Nodes.Add(newItem);
                    }
                    else
                    {
                        TreeNode ElementNode = new TreeNode(item.Name + ":" + ConvertToString(item.Value));
                        ElementNode.Tag = item;
                        treeNode.Nodes.Add(ElementNode);
                    }
                }
            }
        }
        public static void AddBSonArrayToTreeNode(TreeNode newItem, BsonArray item)
        {
            foreach (BsonValue SubItem in item)
            {
                if (SubItem.IsBsonDocument)
                {
                    TreeNode newSubItem = new TreeNode(Document_Mark);
                    AddBsonDocToTreeNode(newSubItem, SubItem.ToBsonDocument());
                    newSubItem.Tag = SubItem;
                    newItem.Nodes.Add(newSubItem);
                }
                else
                {
                    if (SubItem.IsBsonArray)
                    {
                        TreeNode newSubItem = new TreeNode(Array_Mark);
                        AddBSonArrayToTreeNode(newSubItem, SubItem.AsBsonArray);
                        newSubItem.Tag = SubItem;
                        newItem.Nodes.Add(newSubItem);
                    }
                    else
                    {
                        TreeNode newSubItem = new TreeNode(ConvertToString(SubItem));
                        newSubItem.Tag = SubItem;
                        newItem.Nodes.Add(newSubItem);
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
                                lstItem.SubItems.Add(ConvertToString(val));
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
                lstItem.SubItems.Add(GetSize(docFile.GetValue("length")));
                lstItem.SubItems.Add(GetSize(docFile.GetValue("chunkSize")));
                lstItem.SubItems.Add(ConvertToString(docFile.GetValue("uploadDate")));
                lstItem.SubItems.Add(ConvertToString(docFile.GetValue("md5")));
                lstData.Items.Add(lstItem);
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

    }
}
