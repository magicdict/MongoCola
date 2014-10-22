using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TreeViewColumnsProject;

namespace MongoCola.Module
{
    public static partial class MongoDbHelper
    {
        #region"展示状态"

        /// <summary>
        ///     Fill Server Status to treeview
        /// </summary>
        /// <param name="trvSvrStatus"></param>
        public static void FillSrvStatusToList(TreeViewColumns trvSvrStatus)
        {
            var SrvDocList = new List<BsonDocument>();
            foreach (string mongoSvrKey in _mongoConnSvrLst.Keys)
            {
                try
                {
                    MongoServer mongoSvr = _mongoConnSvrLst[mongoSvrKey];
                    if (!SystemManager.GetCurrentServerConfig(mongoSvrKey).Health)
                    {
                        continue;
                    }
                    //flydreamer提供的代码
                    //感谢 魏琼东 的Bug信息,一些命令必须以Admin执行
                    if (SystemManager.GetCurrentServerConfig(mongoSvrKey).LoginAsAdmin)
                    {
                        BsonDocument ServerStatusDoc = CommandHelper.ExecuteMongoSvrCommand(CommandHelper.serverStatus_Command, mongoSvr).Response;
                        SrvDocList.Add(ServerStatusDoc);
                    }
                }
                catch (Exception ex)
                {
                    SystemManager.ExceptionDeal(ex);
                }
            }
            FillDataToTreeView("Server Status", trvSvrStatus, SrvDocList, 0);
            //打开第一层
            foreach (TreeNode item in trvSvrStatus.DatatreeView.Nodes)
            {
                item.Expand();
            }
        }

        /// <summary>
        ///     Fill Database status to ListView
        /// </summary>
        /// <param name="lstSvr"></param>
        public static void FillDataBaseStatusToList(ListView lstSvr)
        {
            lstSvr.Clear();
            if (SystemManager.IsUseDefaultLanguage)
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
                lstSvr.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.DataBase_Status_DataBaseName));
                lstSvr.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.DataBase_Status_CollectionCount));
                lstSvr.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.DataBase_Status_DataSize));
                lstSvr.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.DataBase_Status_FileSize));
                lstSvr.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.DataBase_Status_IndexCount));
                lstSvr.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.DataBase_Status_IndexSize));
                lstSvr.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.DataBase_Status_ObjectCount));
                lstSvr.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.DataBase_Status_StorageSize));
            }
            foreach (string mongoSvrKey in _mongoConnSvrLst.Keys)
            {
                try
                {
                    MongoServer mongoSvr = _mongoConnSvrLst[mongoSvrKey];
                    //感谢 魏琼东 的Bug信息,一些命令必须以Admin执行
                    if (!SystemManager.GetCurrentServerConfig(mongoSvrKey).Health ||
                        !SystemManager.GetCurrentServerConfig(mongoSvrKey).LoginAsAdmin)
                    {
                        continue;
                    }
                    List<string> databaseNameList = mongoSvr.GetDatabaseNames().ToList();
                    foreach (string strDBName in databaseNameList)
                    {
                        MongoDatabase mongoDB = mongoSvr.GetDatabase(strDBName);
                        DatabaseStatsResult dbStatus = mongoDB.GetStats();
                        var lst = new ListViewItem(mongoSvrKey + "." + strDBName);
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
                catch (Exception ex)
                {
                    SystemManager.ExceptionDeal(ex);
                }
            }
            lstSvr.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        /// <summary>
        ///     fill Collection status to ListView
        /// </summary>
        /// <param name="lstData"></param>
        public static void FillCollectionStatusToList(ListView lstData)
        {
            lstData.Clear();

            if (SystemManager.IsUseDefaultLanguage)
            {
                lstData.Columns.Add("CollectionName");
                lstData.Columns.Add("ObjectCount");
                lstData.Columns.Add("DataSize");
                lstData.Columns.Add("LastExtentSize");
                lstData.Columns.Add("StorageSize");
                lstData.Columns.Add("TotalIndexSize");

                //2012-3-6
                lstData.Columns.Add("IsCapped");
                lstData.Columns.Add("MaxDocuments");

                lstData.Columns.Add("AverageObjectSize");
                lstData.Columns.Add("PaddingFactor");
            }
            else
            {
                lstData.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.Collection_Status_CollectionName));
                lstData.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.Collection_Status_ObjectCount));
                lstData.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.Collection_Status_DataSize));
                lstData.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.Collection_Status_LastExtentSize));
                lstData.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.Collection_Status_StorageSize));
                lstData.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.Collection_Status_TotalIndexSize));

                //2012-3-6
                lstData.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.Collection_Status_IsCapped));
                lstData.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.Collection_Status_MaxDocuments));


                lstData.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.Collection_Status_AverageObjectSize));
                lstData.Columns.Add(
                    SystemManager.MStringResource.GetText(StringResource.TextType.Collection_Status_PaddingFactor));
            }
            foreach (string mongoSvrKey in _mongoConnSvrLst.Keys)
            {
                try
                {
                    MongoServer mongoSvr = _mongoConnSvrLst[mongoSvrKey];
                    //感谢 魏琼东 的Bug信息,一些命令必须以Admin执行
                    if (!SystemManager.GetCurrentServerConfig(mongoSvrKey).Health ||
                        !SystemManager.GetCurrentServerConfig(mongoSvrKey).LoginAsAdmin)
                    {
                        continue;
                    }
                    List<string> databaseNameList = mongoSvr.GetDatabaseNames().ToList();
                    foreach (string strDBName in databaseNameList)
                    {
                        MongoDatabase mongoDB = mongoSvr.GetDatabase(strDBName);

                        List<string> colNameList = mongoDB.GetCollectionNames().ToList();
                        foreach (string strColName in colNameList)
                        {
                            try
                            {
                                CollectionStatsResult CollectionStatus = mongoDB.GetCollection(strColName).GetStats();
                                var lst = new ListViewItem(mongoSvrKey + "." + strDBName + "." + strColName);
                                lst.SubItems.Add(CollectionStatus.ObjectCount.ToString());
                                lst.SubItems.Add(GetSize(CollectionStatus.DataSize));
                                lst.SubItems.Add(GetSize(CollectionStatus.LastExtentSize));
                                lst.SubItems.Add(GetSize(CollectionStatus.StorageSize));
                                lst.SubItems.Add(GetSize(CollectionStatus.TotalIndexSize));

                                //2012-3-6
                                lst.SubItems.Add(CollectionStatus.IsCapped.ToString());
                                //https://jira.mongodb.org/browse/CSHARP-665
                                try
                                {
                                    //注意：这个MaxDocuments只是在CappedCollection时候有效
                                    lst.SubItems.Add(CollectionStatus.MaxDocuments.ToString());
                                }
                                catch (Exception ex)
                                {
                                    //溢出
                                    lst.SubItems.Add(int.MaxValue.ToString());
                                    SystemManager.ExceptionLog(ex);
                                }

                                lst.SubItems.Add(CollectionStatus.ObjectCount != 0
                                    ? GetSize((long)CollectionStatus.AverageObjectSize)
                                    : "0");

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
                            catch (Exception ex)
                            {
                                //throw;
                                //TODO:排序时候会发生错误，所以暂时不对应
                                //lstData.Items.Add(new ListViewItem(strColName + "[Exception]"));
                                SystemManager.ExceptionDeal(ex);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    SystemManager.ExceptionDeal(ex);
                }
            }
            lstData.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        /// <summary>
        ///     将数据Opr放入ListView
        /// </summary>
        /// <param name="lstSrvOpr"></param>
        public static void FillCurrentOprToList(ListView lstSrvOpr)
        {
            lstSrvOpr.Clear();
            lstSrvOpr.Columns.Add("Name");
            lstSrvOpr.Columns.Add("opid");
            lstSrvOpr.Columns.Add("active");
            lstSrvOpr.Columns.Add("lockType");
            lstSrvOpr.Columns.Add("waitingForLock");
            lstSrvOpr.Columns.Add("secs_running");
            lstSrvOpr.Columns.Add("op");
            lstSrvOpr.Columns.Add("ns");
            lstSrvOpr.Columns.Add("query");
            lstSrvOpr.Columns.Add("client");
            lstSrvOpr.Columns.Add("desc");
            lstSrvOpr.Columns.Add("connectionId");
            lstSrvOpr.Columns.Add("numYields");

            foreach (string mongoSvrKey in _mongoConnSvrLst.Keys)
            {
                try
                {
                    MongoServer mongoSvr = _mongoConnSvrLst[mongoSvrKey];
                    //感谢 魏琼东 的Bug信息,一些命令必须以Admin执行
                    if (!SystemManager.GetCurrentServerConfig(mongoSvrKey).Health ||
                        !SystemManager.GetCurrentServerConfig(mongoSvrKey).LoginAsAdmin)
                    {
                        continue;
                    }
                    List<string> databaseNameList = mongoSvr.GetDatabaseNames().ToList();
                    foreach (string strDBName in databaseNameList)
                    {
                        try
                        {
                            MongoDatabase mongoDB = mongoSvr.GetDatabase(strDBName);
                            BsonDocument dbStatus = mongoDB.GetCurrentOp();
                            BsonArray doc = dbStatus.GetValue("inprog").AsBsonArray;
                            foreach (BsonDocument item in doc)
                            {
                                var lst = new ListViewItem(mongoSvrKey + "." + strDBName);
                                foreach (string itemName in item.Names)
                                {
                                    lst.SubItems.Add(item.GetValue(itemName).ToString());
                                }
                                lstSrvOpr.Items.Add(lst);
                            }
                        }
                        catch (Exception ex)
                        {
                            SystemManager.ExceptionDeal(ex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    SystemManager.ExceptionDeal(ex);
                }
            }
            lstSrvOpr.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        #endregion

        #region "辅助方法和排序器"

        /// <summary>
        ///     将执行结果转化为细节报告文字列
        /// </summary>
        /// <param name="Resultlst"></param>
        /// <returns></returns>
        public static string ConvertCommandResultlstToString(List<CommandResult> Resultlst)
        {
            string Details = string.Empty;
            foreach (CommandResult item in Resultlst)
            {
                Details += item.Response + Environment.NewLine;
            }
            return Details;
        }

        /// <summary>
        ///     Size的文字表达
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private static string GetSize(BsonValue size)
        {
            if (size.IsInt32)
            {
                return GetSize((int)size);
            }
            return GetSize((long)size);
        }

        /// <summary>
        ///     Size的文字表达
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private static string GetSize(long size)
        {
            string[] Unit =
            {
                "Byte", "KB", "MB", "GB", "TB"
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

        /// <summary>
        ///     将表示的尺寸还原为实际尺寸以对应排序的要求
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static long ReconvSize(string size)
        {
            string[] Unit =
            {
                "Byte", "KB", "MB", "GB", "TB"
            };
            if (size == "0 Byte")
            {
                return 0;
            }
            for (int i = 0; i < Unit.Length; i++)
            {
                if (size.EndsWith(Unit[i]))
                {
                    size = size.Replace(Unit[i], string.Empty).Trim();
                    return (long)(Convert.ToDouble(size) * Math.Pow(2, (i * 10)));
                }
            }
            return 0;
        }

        public class lvwColumnSorter : IComparer
        {
            /// <summary>
            ///     比较方式
            /// </summary>
            public enum SortMethod
            {
                StringCompare,
                SizeCompare,
                NumberCompare
            }

            /// <summary>
            ///     声明CaseInsensitiveComparer类对象
            /// </summary>
            private readonly CaseInsensitiveComparer ObjectCompare;

            /// <summary>
            ///     指定按照哪个列排序
            /// </summary>
            private int ColumnToSort;

            /// <summary>
            ///     指定排序的方式
            /// </summary>
            private SortOrder OrderOfSort;

            /// <summary>
            ///     比较方式
            /// </summary>
            private SortMethod mCompareMethod;

            /// <summary>
            ///     构造函数
            /// </summary>
            public lvwColumnSorter()
            {
                ColumnToSort = 0; // 默认按第一列排序            
                OrderOfSort = SortOrder.None; // 排序方式为不排序            
                ObjectCompare = new CaseInsensitiveComparer(); // 初始化CaseInsensitiveComparer类对象
                mCompareMethod = SortMethod.StringCompare; //是否使用Size比较
            }

            public SortMethod CompareMethod
            {
                set { mCompareMethod = value; }
                get { return mCompareMethod; }
            }

            /// 获取或设置按照哪一列排序.
            public int SortColumn
            {
                set { ColumnToSort = value; }
                get { return ColumnToSort; }
            }

            /// 获取或设置排序方式.
            public SortOrder Order
            {
                set { OrderOfSort = value; }
                get { return OrderOfSort; }
            }

            /// <summary>
            ///     比较
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(object x, object y)
            {
                var lstX = (ListViewItem)x;
                var lstY = (ListViewItem)y;
                int rtnCompare = 0;
                switch (mCompareMethod)
                {
                    case SortMethod.StringCompare:
                        rtnCompare = ObjectCompare.Compare(lstX.SubItems[ColumnToSort].Text,
                            lstY.SubItems[ColumnToSort].Text);
                        break;
                    case SortMethod.SizeCompare:
                        rtnCompare =
                            (int)
                                (ReconvSize(lstX.SubItems[ColumnToSort].Text) -
                                 ReconvSize(lstY.SubItems[ColumnToSort].Text));
                        break;
                    case SortMethod.NumberCompare:
                        //当两个数字相减小于1时，(int)的强制转换会将结果变成0，所以不能使用减法来获得Ret。。。
                        if (Convert.ToDouble(lstX.SubItems[ColumnToSort].Text) >
                            Convert.ToDouble(lstY.SubItems[ColumnToSort].Text))
                        {
                            rtnCompare = 1;
                        }
                        else
                        {
                            if (Convert.ToDouble(lstX.SubItems[ColumnToSort].Text) ==
                                Convert.ToDouble(lstY.SubItems[ColumnToSort].Text))
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
        }

        #endregion
    }
}