using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using MongoDB.Bson;
using MongoGUICtl;
using MongoGUICtl.ClientTree;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;

namespace MongoGUIView
{
    public static class ViewHelper
    {
        #region"展示数据集内容[WebForm]"

        /// <summary>
        ///     DateTime:IsUTC
        /// </summary>
        public static bool IsUtc { set; get; }

        /// <summary>
        ///     数字使用K系统表示
        /// </summary>
        public static bool IsDisplayNumberWithKSystem { set; get; }

        /// <summary>
        ///     展示数据
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="controls"></param>
        /// <param name="currentDataViewInfo"></param>
        public static void FillDataToControl(List<BsonDocument> dataList, List<Control> controls,
            DataViewInfo currentDataViewInfo)
        {
            var collectionPath = currentDataViewInfo.StrDbTag.Split(":".ToCharArray())[1];
            var cp = collectionPath.Split("/".ToCharArray());
            foreach (var control in controls)
            {
                if (control.GetType() == typeof (ListView))
                {
                    if (
                        !(dataList.Count == 0 &&
                          currentDataViewInfo.StrDbTag.Split(":".ToCharArray())[0] == ConstMgr.CollectionTag))
                    {
                        //只有在纯数据集的时候才退出，不然的话，至少需要将字段结构在ListView中显示出来。
                        FillDataToListView(cp[(int) EnumMgr.PathLevel.Collection], (ListView) control, dataList);
                    }
                }
                if (control.GetType() == typeof (TextBox))
                {
                    FillJsonDataToTextBox((TextBox) control, dataList, currentDataViewInfo.SkipCnt);
                }
                if (control.GetType() == typeof (CtlTreeViewColumns))
                {
                    UiHelper.FillDataToTreeView(cp[(int) EnumMgr.PathLevel.Collection], (CtlTreeViewColumns) control,
                        dataList,
                        currentDataViewInfo.SkipCnt);
                }
            }
        }

        /// <summary>
        ///     字符转Bsonvalue
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public static BsonValue ConvertFromString(string strData)
        {
            //以引号开始结尾的，解释为字符串
            if (strData.StartsWith("\"") && strData.EndsWith("\""))
            {
                return new BsonString(strData.Trim("\"".ToCharArray()));
            }
            return new BsonString("");
        }

        /// <summary>
        ///     BsonValue转展示用字符
        /// </summary>
        /// <param name="bsonValue"></param>
        /// <returns></returns>
        public static string ConvertToString(BsonValue bsonValue)
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
                return bsonValue + "[Contains" + bsonValue.ToBsonDocument().ElementCount + "Documents]";
            }
            //时间
            if (bsonValue.IsValidDateTime)
            {
                if (IsUtc)
                {
                    return bsonValue.ToUniversalTime().ToString();
                }
                //@flydreamer提出的本地化时间要求
                return bsonValue.ToLocalTime().ToString();
            }

            //字符
            if (bsonValue.IsString)
            {
                //只有在字符的时候加上""
                return "\"" + bsonValue + "\"";
            }

            //其他
            return bsonValue.ToString();
        }

        /// <summary>
        /// </summary>
        /// <param name="txtData"></param>
        /// <param name="dataList"></param>
        public static void FillJsonDataToTextBox(TextBox txtData, List<BsonDocument> dataList, int skipCnt)
        {
            txtData.Clear();
            var count = 1;
            var sb = new StringBuilder();
            foreach (var bsonDoc in dataList)
            {
                sb.AppendLine("/* " + (skipCnt + count) + " */");

                sb.AppendLine(bsonDoc.ToJson(MongoHelper.JsonWriterSettings));
                count++;
            }
            txtData.Text = sb.ToString();
        }

        /// <summary>
        ///     将数据放入ListView中进行展示
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
                case ConstMgr.CollectionNameGfsFiles:
                    SetGridFileToListView(dataList, lstData);
                    break;
                case ConstMgr.CollectionNameUser:
                    SetUserListToListView(dataList, lstData);
                    break;
                default:
                    //普通数据的加载
                    SetDataListToListView(dataList, lstData, collectionName);
                    break;
            }
        }

        /// <summary>
        ///     普通数据的加载
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="lstData"></param>
        /// <param name="collectionName"></param>
        private static void SetDataListToListView(List<BsonDocument> dataList, ListView lstData, string collectionName)
        {
            var columnlist = new List<string>();
            //可以让_id 不在第一位，昏过去了,很多逻辑需要调整
            var isSystem = Operater.IsSystemCollection(string.Empty, collectionName);
            if (!isSystem)
            {
                columnlist.Add(ConstMgr.KeyId);
                lstData.Columns.Add(ConstMgr.KeyId);
            }
            foreach (var docItem in dataList)
            {
                var lstItem = new ListViewItem();
                foreach (var item in docItem.Names)
                {
                    if (!columnlist.Contains(item))
                    {
                        columnlist.Add(item);
                        lstData.Columns.Add(item);
                    }
                }
                //Key:_id
                if (!isSystem)
                {
                    BsonElement id;
                    docItem.TryGetElement(ConstMgr.KeyId, out id);
                    if (!(id.Value is BsonNull))
                    {
                        lstItem.Text = docItem.GetValue(ConstMgr.KeyId).ToString();
                        //这里保存真实的主Key数据，删除的时候使用
                        lstItem.Tag = docItem.GetValue(ConstMgr.KeyId);
                    }
                    else
                    {
                        lstItem.Text = "[Empty]";
                        lstItem.Tag = docItem.GetElement(0).Value;
                    }
                }
                else
                {
                    lstItem.Text = docItem.GetValue(columnlist[0]).ToString();
                }
                //OtherItems
                for (var i = isSystem ? 1 : 0; i < columnlist.Count; i++)
                {
                    if (columnlist[i] == ConstMgr.KeyId)
                    {
                        continue;
                    }
                    BsonValue val;
                    docItem.TryGetValue(columnlist[i], out val);
                    lstItem.SubItems.Add(val == null ? "" : ConvertToString(val));
                }
                lstData.Items.Add(lstItem);
            }
            Utility.ListViewColumnResize(lstData);
        }

        /// <summary>
        ///     用户列表
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="lstData"></param>
        private static void SetUserListToListView(List<BsonDocument> dataList, ListView lstData)
        {
            //2.4以后的用户，没有ReadOnly属性，取而代之的是roles属性
            //这里为了向前兼容暂时保持ReadOnle属性
            //Ref:http://docs.mongodb.org/manual/reference/method/db.addUser/
            lstData.Clear();
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                lstData.Columns.Add("ID");
                lstData.Columns.Add(
                    GuiConfig.GetText(TextType.CommonUsername));
                lstData.Columns.Add(GuiConfig.GetText(TextType.CommonRoles));
                lstData.Columns.Add(
                    GuiConfig.GetText(TextType.CommonPassword));
                lstData.Columns.Add("userSource");
                lstData.Columns.Add("otherDBRoles");
                lstData.Columns.Add(
                    GuiConfig.GetText(TextType.CommonReadOnly));
            }
            else
            {
                lstData.Columns.Add("ID");
                lstData.Columns.Add("user");
                lstData.Columns.Add("roles");
                lstData.Columns.Add("password");
                lstData.Columns.Add("userSource");
                lstData.Columns.Add("otherDBRoles");
                lstData.Columns.Add("readonly");
            }
            foreach (var docFile in dataList)
            {
                var lstItem = new ListViewItem();
                //ID
                lstItem.Text = docFile.GetValue(ConstMgr.KeyId).ToString();
                //User
                lstItem.SubItems.Add(docFile.GetValue("user").ToString());
                //roles
                BsonValue strRoles;
                docFile.TryGetValue("roles", out strRoles);
                lstItem.SubItems.Add(strRoles == null ? "N/A" : strRoles.ToString());
                //密码是Hash表示的，这里没有安全隐患
                //Password和userSource不能同时设置，所以password也可能不存在
                BsonValue strPassword;
                docFile.TryGetValue("pwd", out strPassword);
                lstItem.SubItems.Add(strPassword == null ? "N/A" : strPassword.ToString());
                //userSource
                BsonValue strUserSource;
                docFile.TryGetValue("userSource", out strUserSource);
                lstItem.SubItems.Add(strUserSource == null ? "N/A" : strUserSource.ToString());
                //OtherDBRoles
                BsonValue strOtherDbRoles;
                docFile.TryGetValue("otherDBRoles", out strOtherDbRoles);
                lstItem.SubItems.Add(strOtherDbRoles == null ? "N/A" : strOtherDbRoles.ToString());
                //ReadOnly
                //20130802 roles列表示。ReadOnly可能不存在！
                BsonValue strReadOnly;
                docFile.TryGetValue("readOnly", out strReadOnly);
                lstItem.SubItems.Add(strReadOnly == null ? "N/A" : strReadOnly.ToString());
                lstData.Items.Add(lstItem);
            }
            Utility.ListViewColumnResize(lstData);
            //lstData.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        /// <summary>
        ///     GFS系统
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="lstData"></param>
        private static void SetGridFileToListView(List<BsonDocument> dataList, ListView lstData)
        {
            lstData.Clear();
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                lstData.Columns.Add(GuiConfig.GetText(TextType.GfsFilename));
                lstData.Columns.Add(GuiConfig.GetText(TextType.GfsLength));
                lstData.Columns.Add(
                    GuiConfig.GetText(TextType.GfsChunkSize));
                lstData.Columns.Add(
                    GuiConfig.GetText(TextType.GfsUploadDate));
                lstData.Columns.Add(GuiConfig.GetText(TextType.GfsMd5));
                //!MONO
                lstData.Columns.Add("ContentType");
            }
            else
            {
                lstData.Columns.Add("filename");
                lstData.Columns.Add("length");
                lstData.Columns.Add("chunkSize");
                lstData.Columns.Add("uploadDate");
                lstData.Columns.Add("MD5");
                //!MONO
                lstData.Columns.Add("ContentType");
            }
            lstData.SmallImageList = GetSystemIcon.IconImagelist;
            lstData.LargeImageList = GetSystemIcon.IconImagelist;
            lstData.TileSize = new Size(200, 100);

            foreach (var docFile in dataList)
            {
                var filename = docFile.GetValue("filename").ToString();
                var lstItem = new ListViewItem();
                lstItem.ImageIndex = GetSystemIcon.GetIconIndexByFileName(filename, false);
                lstItem.Text = filename;
                lstItem.ToolTipText = filename;
                lstItem.SubItems.Add(MongoHelper.GetBsonSize(docFile.GetValue("length")));
                lstItem.SubItems.Add(MongoHelper.GetBsonSize(docFile.GetValue("chunkSize")));
                lstItem.SubItems.Add(ConvertToString(docFile.GetValue("uploadDate")));
                lstItem.SubItems.Add(ConvertToString(docFile.GetValue("md5")));
                //!MONO
                lstItem.SubItems.Add(GetSystemIcon.GetContentType(filename));
                lstData.Items.Add(lstItem);
            }
            //自动调节列宽
            Utility.ListViewColumnResize(lstData);
            // 用新的排序方法对ListView排序
            var lvwGfsColumnSorter = new LvwColumnSorter();
            lstData.ListViewItemSorter = lvwGfsColumnSorter;
            lstData.ColumnClick += (sender, e) =>
            {
                switch (e.Column)
                {
                    case 1:
                    case 2:
                        lvwGfsColumnSorter.CompareMethod = LvwColumnSorter.SortMethod.SizeCompare;
                        break;
                    default:
                        lvwGfsColumnSorter.CompareMethod = LvwColumnSorter.SortMethod.StringCompare;
                        break;
                }
                // 检查点击的列是不是现在的排序列.
                if (e.Column == lvwGfsColumnSorter.SortColumn)
                {
                    // 重新设置此列的排序方法.
                    lvwGfsColumnSorter.Order = lvwGfsColumnSorter.Order == SortOrder.Ascending
                        ? SortOrder.Descending
                        : SortOrder.Ascending;
                }
                else
                {
                    // 设置排序列，默认为正向排序
                    lvwGfsColumnSorter.SortColumn = e.Column;
                    lvwGfsColumnSorter.Order = SortOrder.Ascending;
                }
                lstData.Sort();
            };
        }

        #endregion

        #region"数据导航"

        /// <summary>
        ///     数据导航
        /// </summary>
        public enum PageChangeOpr
        {
            /// <summary>
            ///     第一页
            /// </summary>
            FirstPage,

            /// <summary>
            ///     最后一页
            /// </summary>
            LastPage,

            /// <summary>
            ///     上一页
            /// </summary>
            PrePage,

            /// <summary>
            ///     下一页
            /// </summary>
            NextPage
        }

        /// <summary>
        ///     换页操作
        /// </summary>
        /// <param name="pageChangeMode"></param>
        /// <param name="mDataViewInfo"></param>
        /// <param name="dataShower"></param>
        public static void PageChanged(PageChangeOpr pageChangeMode, ref DataViewInfo mDataViewInfo,
            List<Control> dataShower)
        {
            switch (pageChangeMode)
            {
                case PageChangeOpr.FirstPage:
                    mDataViewInfo.SkipCnt = 0;
                    break;
                case PageChangeOpr.LastPage:
                    if (mDataViewInfo.CurrentCollectionTotalCnt%mDataViewInfo.LimitCnt == 0)
                    {
                        //没有余数的时候，600 % 100 == 0  => Skip = 600-100 = 500
                        mDataViewInfo.SkipCnt = mDataViewInfo.CurrentCollectionTotalCnt - mDataViewInfo.LimitCnt;
                    }
                    else
                    {
                        // 630 % 100 == 30  => Skip = 630-30 = 600  
                        mDataViewInfo.SkipCnt = mDataViewInfo.CurrentCollectionTotalCnt -
                                                mDataViewInfo.CurrentCollectionTotalCnt%mDataViewInfo.LimitCnt;
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
            var datalist = DataViewInfo.GetDataList(ref mDataViewInfo, RuntimeMongoDbContext.GetCurrentServer());
            FillDataToControl(datalist, dataShower, mDataViewInfo);
        }

        #endregion
    }
}