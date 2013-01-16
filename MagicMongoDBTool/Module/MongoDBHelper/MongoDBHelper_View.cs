using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using TreeViewColumnsProject;
using System.Drawing;
namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {

        #region"展示数据集内容[WebForm]"
        /// <summary>
        /// 唯一的网页展示数据的数据信息
        /// </summary>
        public static DataViewInfo WebDataViewInfo;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static String GetCollectionzTreeJSON()
        {
            //获得数据
            WebDataViewInfo.LimitCnt = 100;
            List<BsonDocument> dataList = GetDataList(ref WebDataViewInfo);
            String collectionName = SystemManager.GetTagData(WebDataViewInfo.strDBTag).Split("/".ToCharArray())[(int)MongoDBHelper.PathLv.CollectionLV];
            int SkipCnt = WebDataViewInfo.SkipCnt;
            TreeViewColumns tree = new TreeViewColumns();
            FillDataToTreeView(collectionName, tree, dataList, WebDataViewInfo.SkipCnt);
            BsonArray array = new BsonArray();
            foreach (TreeNode item in tree.TreeView.Nodes)
            {
                array.Add(ConvertTreeNodeTozTreeBsonDoc(item));
            }
            return array.ToJson(SystemManager.JsonWriterSettings); ;
        }
        #endregion

        #region"展示数据集内容"

        /// <summary>
        /// 通过读取N条记录来确定数据集结构
        /// </summary>
        /// <param name="mongoCol">数据集</param>
        /// <param name="CheckRecordCnt">使用数据量，省略时为全部，海量数据时相当消耗性能</param>
        /// <returns></returns>
        public static List<String> GetCollectionSchame(MongoCollection mongoCol)
        {
            int CheckRecordCnt = 100;
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
                    _ColumnList.Add(strName);
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
        /// 获得展示数据
        /// </summary>
        /// <param name="CurrentDataViewInfo"></param>
        public static List<BsonDocument> GetDataList(ref DataViewInfo CurrentDataViewInfo)
        {
            String collectionPath = CurrentDataViewInfo.strDBTag.Split(":".ToCharArray())[1];
            String[] cp = collectionPath.Split("/".ToCharArray());
            MongoServer mServer = SystemManager.GetCurrentServer();
            MongoCollection mongoCol = mServer.GetDatabase(cp[(int)PathLv.DatabaseLV]).GetCollection(cp[(int)PathLv.CollectionLV]);


            MongoCursor<BsonDocument> cursor;
            //Query condition:
            if (CurrentDataViewInfo.IsUseFilter)
            {
                cursor = mongoCol.FindAs<BsonDocument>(GetQuery(CurrentDataViewInfo.mDataFilter.QueryConditionList))
                                   .SetSkip(CurrentDataViewInfo.SkipCnt)
                                   .SetFields(GetOutputFields(CurrentDataViewInfo.mDataFilter.QueryFieldList))
                                   .SetSortOrder(GetSort(CurrentDataViewInfo.mDataFilter.QueryFieldList))
                                   .SetLimit(CurrentDataViewInfo.LimitCnt);
            }
            else
            {
                cursor = mongoCol.FindAllAs<BsonDocument>()
                                   .SetSkip(CurrentDataViewInfo.SkipCnt)
                                   .SetLimit(CurrentDataViewInfo.LimitCnt);

            }
            if (cursor.Query != null)
            {
                CurrentDataViewInfo.Query = cursor.Query.ToJson(SystemManager.JsonWriterSettings);
            }
            else
            {
                CurrentDataViewInfo.Query = String.Empty;
            }
            CurrentDataViewInfo.Explain = cursor.Explain().ToJson(SystemManager.JsonWriterSettings);
            List<BsonDocument> dataList = cursor.ToList();
            if (CurrentDataViewInfo.SkipCnt == 0)
            {
                if (CurrentDataViewInfo.IsUseFilter)
                {
                    //感谢cnblogs.com 网友Shadower
                    CurrentDataViewInfo.CurrentCollectionTotalCnt = (int)mongoCol.Count(GetQuery(CurrentDataViewInfo.mDataFilter.QueryConditionList));
                }
                else
                {
                    CurrentDataViewInfo.CurrentCollectionTotalCnt = (int)mongoCol.Count();
                }
            }
            SetPageEnable(ref CurrentDataViewInfo);
            return dataList;

        }
        /// <summary>
        /// 展示数据
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="controls"></param>
        /// <param name="CurrentDataViewInfo"></param>
        public static void FillDataToControl(List<BsonDocument> dataList, List<Control> controls, DataViewInfo CurrentDataViewInfo)
        {
            String collectionPath = CurrentDataViewInfo.strDBTag.Split(":".ToCharArray())[1];
            String[] cp = collectionPath.Split("/".ToCharArray());
            foreach (var control in controls)
            {
                switch (control.GetType().ToString())
                {
                    case "System.Windows.Forms.ListView":
                        if (!(dataList.Count == 0 && CurrentDataViewInfo.strDBTag.Split(":".ToCharArray())[0] == COLLECTION_TAG))
                        {
                            ///只有在纯数据集的时候才退出，不然的话，至少需要将字段结构在ListView中显示出来。
                            FillDataToListView(cp[(int)PathLv.CollectionLV], (ListView)control, dataList);
                        }
                        break;
                    case "System.Windows.Forms.TextBox":
                        FillJSONDataToTextBox((TextBox)control, dataList, CurrentDataViewInfo.SkipCnt);
                        break;
                    case "TreeViewColumnsProject.TreeViewColumns":
                        FillDataToTreeView(cp[(int)PathLv.CollectionLV], (TreeViewColumns)control, dataList, CurrentDataViewInfo.SkipCnt);
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
        public static void FillJSONDataToTextBox(TextBox txtData, List<BsonDocument> dataList, int SkipCnt)
        {
            txtData.Clear();
            int Count = 1;
            StringBuilder sb = new StringBuilder();
            foreach (BsonDocument BsonDoc in dataList)
            {
                sb.AppendLine("/* " + (SkipCnt + Count).ToString() + " */");

                sb.AppendLine(BsonDoc.ToJson(SystemManager.JsonWriterSettings));
                Count++;
            }
            txtData.Text = sb.ToString();
        }
        /// <summary>
        /// 将数据放入TreeView里进行展示
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="trvData"></param>
        /// <param name="dataList"></param>
        public static void FillDataToTreeView(String collectionName, TreeViewColumns trvData, List<BsonDocument> dataList, int mSkip)
        {
            trvData.DatatreeView.Nodes.Clear();
            int SkipCnt = mSkip;
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
                        //SelectDocId属性的设置,
                        //2012/03/19 不一定id是在第一位
                        BsonElement id;
                        item.TryGetElement(KEY_ID, out id);
                        if (id != null)
                        {
                            dataNode.Tag = id.Value;
                        }
                        else
                        {
                            dataNode.Tag = item.GetElement(0).Value;
                        }
                        break;
                }
                AddBsonDocToTreeNode(dataNode, item);
                trvData.DatatreeView.Nodes.Add(dataNode);
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
                    TreeNode newItem = new TreeNode(item.Name);
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
                        TreeNode newItem = new TreeNode(item.Name + Array_Mark);
                        AddBsonArrayToTreeNode(newItem, item.Value.AsBsonArray);
                        newItem.Tag = item;
                        treeNode.Nodes.Add(newItem);
                    }
                    else
                    {
                        TreeNode ElementNode = new TreeNode(item.Name);
                        ElementNode.Tag = item;
                        treeNode.Nodes.Add(ElementNode);
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="item"></param>
        public static void AddBsonArrayToTreeNode(TreeNode newItem, BsonArray item)
        {
            foreach (BsonValue SubItem in item)
            {
                if (SubItem.IsBsonDocument)
                {
                    TreeNode newSubItem = new TreeNode();
                    AddBsonDocToTreeNode(newSubItem, SubItem.ToBsonDocument());
                    newSubItem.Tag = SubItem;
                    newItem.Nodes.Add(newSubItem);
                }
                else
                {
                    if (SubItem.IsBsonArray)
                    {
                        TreeNode newSubItem = new TreeNode();
                        AddBsonArrayToTreeNode(newSubItem, SubItem.AsBsonArray);
                        newSubItem.Tag = SubItem;
                        newItem.Nodes.Add(newSubItem);
                    }
                    else
                    {
                        TreeNode newSubItem = new TreeNode();
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
                    //可以让_id 不在第一位，昏过去了,很多逻辑需要调整
                    bool isSystem = IsSystemCollection(SystemManager.GetCurrentCollection());
                    if (!isSystem)
                    {
                        _columnlist.Add(KEY_ID);
                        lstData.Columns.Add(KEY_ID);
                    }
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
                        if (!isSystem)
                        {
                            BsonElement id;
                            docItem.TryGetElement(KEY_ID, out id);
                            if (id != null)
                            {
                                lstItem.Text = docItem.GetValue(KEY_ID).ToString();
                                //这里保存真实的主Key数据，删除的时候使用
                                lstItem.Tag = docItem.GetValue(KEY_ID);
                            }
                            else
                            {
                                lstItem.Text = "[Empty]";
                                lstItem.Tag = docItem.GetElement(0).Value;
                            }
                        }
                        else
                        {
                            lstItem.Text = docItem.GetValue(_columnlist[0].ToString()).ToString();
                        }
                        //OtherItems
                        for (int i = isSystem ? 1 : 0; i < _columnlist.Count; i++)
                        {
                            if (_columnlist[i].ToString() == KEY_ID) { continue; }
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
            if (!SystemManager.IsUseDefaultLanguage)
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
                lstItem.Text = docFile.GetValue(KEY_ID).ToString();
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
            if (!SystemManager.IsUseDefaultLanguage)
            {
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.GFS_filename));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.GFS_length));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.GFS_chunkSize));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.GFS_uploadDate));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.GFS_md5));
                if (!SystemManager.MONO_MODE)
                {
                    lstData.Columns.Add("ContentType");
                }
            }
            else
            {
                lstData.Columns.Add("filename");
                lstData.Columns.Add("length");
                lstData.Columns.Add("chunkSize");
                lstData.Columns.Add("uploadDate");
                lstData.Columns.Add("MD5");
                if (!SystemManager.MONO_MODE)
                {
                    lstData.Columns.Add("ContentType");
                }
            }
            lstData.SmallImageList = GetSystemIcon.IconImagelist;
            lstData.LargeImageList = GetSystemIcon.IconImagelist;
            lstData.TileSize = new Size(200, 100);

            foreach (BsonDocument docFile in dataList)
            {
                String Filename = docFile.GetValue("filename").ToString();
                ListViewItem lstItem = new ListViewItem();
                lstItem.ImageIndex = GetSystemIcon.GetIconIndexByFileName(Filename, false);
                lstItem.Text = Filename;
                lstItem.ToolTipText = Filename;
                lstItem.SubItems.Add(GetSize(docFile.GetValue("length")));
                lstItem.SubItems.Add(GetSize(docFile.GetValue("chunkSize")));
                lstItem.SubItems.Add(ConvertToString(docFile.GetValue("uploadDate")));
                lstItem.SubItems.Add(ConvertToString(docFile.GetValue("md5")));

                if (!SystemManager.MONO_MODE)
                {
                    lstItem.SubItems.Add(GetSystemIcon.GetContentType(Filename));
                }
                lstData.Items.Add(lstItem);
            }
            // 用新的排序方法对ListView排序
            MongoDBHelper.lvwColumnSorter _lvwGFSColumnSorter = new MongoDBHelper.lvwColumnSorter();
            lstData.ListViewItemSorter = _lvwGFSColumnSorter;
            lstData.ColumnClick += new ColumnClickEventHandler(
                (sender, e) =>
                {
                    switch (e.Column)
                    {
                        case 1:
                        case 2:
                            _lvwGFSColumnSorter.CompareMethod = MongoDBHelper.lvwColumnSorter.SortMethod.SizeCompare;
                            break;
                        default:
                            _lvwGFSColumnSorter.CompareMethod = MongoDBHelper.lvwColumnSorter.SortMethod.StringCompare;
                            break;
                    }
                    // 检查点击的列是不是现在的排序列.
                    if (e.Column == _lvwGFSColumnSorter.SortColumn)
                    {
                        // 重新设置此列的排序方法.
                        if (_lvwGFSColumnSorter.Order == SortOrder.Ascending)
                        {
                            _lvwGFSColumnSorter.Order = SortOrder.Descending;
                        }
                        else
                        {
                            _lvwGFSColumnSorter.Order = SortOrder.Ascending;
                        }
                    }
                    else
                    {
                        // 设置排序列，默认为正向排序
                        _lvwGFSColumnSorter.SortColumn = e.Column;
                        _lvwGFSColumnSorter.Order = SortOrder.Ascending;
                    }
                    lstData.Sort();

                }
                );

        }

        #endregion

        #region"数据导航"
        /// <summary>
        /// 多数据集视图中，每个数据集保留一个DataViewInfo
        /// </summary>
        public class DataViewInfo
        {
            public String strDBTag;
            /// <summary>
            /// 是否使用过滤器
            /// </summary>
            public bool IsUseFilter;
            /// <summary>
            /// 数据过滤器
            /// </summary>
            public DataFilter mDataFilter;
            /// <summary>
            /// 数据集总记录数
            /// </summary>
            public int CurrentCollectionTotalCnt;
            /// <summary>
            /// Skip记录数
            /// </summary>
            public int SkipCnt;
            /// <summary>
            /// 是否存在下一页
            /// </summary>
            public bool HasNextPage;
            /// <summary>
            /// 是否存在上一页
            /// </summary>
            public bool HasPrePage;
            /// <summary>
            /// 是否为SafeMode
            /// </summary>
            public bool IsSafeMode;
            /// <summary>
            /// 是否为只读
            /// </summary>
            public bool IsReadOnly;
            /// <summary>
            /// 每页显示数
            /// </summary>
            public int LimitCnt;
            /// <summary>
            /// 查询
            /// </summary>
            public String Query;
            /// <summary>
            /// 解释
            /// </summary>
            public String Explain;
            /// <summary>
            /// 是否为Admin数据库
            /// </summary>
            public Boolean IsAdminDB
            {
                get
                {
                    String strNodeData = strDBTag.Split(":".ToCharArray())[1];
                    String[] DataList = strNodeData.Split("/".ToCharArray());
                    if (DataList[(int)MongoDBHelper.PathLv.DatabaseLV] == MongoDBHelper.DATABASE_NAME_ADMIN)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            /// <summary>
            /// 是否为系统数据集
            /// </summary>
            public Boolean IsSystemCollection
            {
                get
                {
                    String strNodeData = strDBTag.Split(":".ToCharArray())[1];
                    String[] DataList = strNodeData.Split("/".ToCharArray());
                    return MongoDBHelper.IsSystemCollection(DataList[(int)MongoDBHelper.PathLv.DatabaseLV],
                                                            DataList[(int)MongoDBHelper.PathLv.CollectionLV]);

                }
            }
        }
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
        public static void PageChanged(PageChangeOpr pageChangeMode, ref DataViewInfo mDataViewInfo, List<Control> dataShower)
        {
            switch (pageChangeMode)
            {
                case PageChangeOpr.FirstPage:
                    mDataViewInfo.SkipCnt = 0;
                    break;
                case PageChangeOpr.LastPage:
                    if (mDataViewInfo.CurrentCollectionTotalCnt % mDataViewInfo.LimitCnt == 0)
                    {
                        //没有余数的时候，600 % 100 == 0  => Skip = 600-100 = 500
                        mDataViewInfo.SkipCnt = mDataViewInfo.CurrentCollectionTotalCnt - mDataViewInfo.LimitCnt;
                    }
                    else
                    {
                        // 630 % 100 == 30  => Skip = 630-30 = 600  
                        mDataViewInfo.SkipCnt = mDataViewInfo.CurrentCollectionTotalCnt - mDataViewInfo.CurrentCollectionTotalCnt % mDataViewInfo.LimitCnt;
                    }
                    break;
                case PageChangeOpr.NextPage:
                    mDataViewInfo.SkipCnt += mDataViewInfo.LimitCnt;
                    if (mDataViewInfo.SkipCnt >= mDataViewInfo.CurrentCollectionTotalCnt)
                    {
                        mDataViewInfo.SkipCnt = mDataViewInfo.CurrentCollectionTotalCnt - 1;
                    }
                    break;
                case PageChangeOpr.PrePage:
                    mDataViewInfo.SkipCnt -= mDataViewInfo.LimitCnt;
                    if (mDataViewInfo.SkipCnt < 0)
                    {
                        mDataViewInfo.SkipCnt = 0;
                    }
                    break;
                default:
                    break;
            }
            List<BsonDocument> datalist = MongoDBHelper.GetDataList(ref mDataViewInfo);
            MongoDBHelper.FillDataToControl(datalist, dataShower, mDataViewInfo);
        }
        /// <summary>
        /// 设置导航状态
        /// </summary>
        /// <param name="mDataViewInfo">Data View Information(Structure,Must By Ref)</param>
        public static void SetPageEnable(ref DataViewInfo mDataViewInfo)
        {
            if (mDataViewInfo.SkipCnt == 0)
            {
                mDataViewInfo.HasPrePage = false;
            }
            else
            {
                mDataViewInfo.HasPrePage = true;
            }
            if ((mDataViewInfo.SkipCnt + mDataViewInfo.LimitCnt) >= mDataViewInfo.CurrentCollectionTotalCnt)
            {
                mDataViewInfo.HasNextPage = false;
            }
            else
            {
                mDataViewInfo.HasNextPage = true;
            }
        }

        #endregion

    }
}