using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using ResourceLib.Method;

namespace MongoGUICtl
{
    public static class FillMongoDb
    {
        #region "辅助方法和排序器"

        public class LvwColumnSorter : IComparer
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
            private readonly CaseInsensitiveComparer _objectCompare;

            /// <summary>
            ///     构造函数
            /// </summary>
            public LvwColumnSorter()
            {
                SortColumn = 0; // 默认按第一列排序            
                Order = SortOrder.None; // 排序方式为不排序            
                _objectCompare = new CaseInsensitiveComparer(); // 初始化CaseInsensitiveComparer类对象
                CompareMethod = SortMethod.StringCompare; //是否使用Size比较
            }

            public SortMethod CompareMethod { set; get; }

            /// 获取或设置按照哪一列排序.
            public int SortColumn { set; get; }

            /// 获取或设置排序方式.
            public SortOrder Order { set; get; }

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
                var rtnCompare = 0;
                switch (CompareMethod)
                {
                    case SortMethod.StringCompare:
                        rtnCompare = _objectCompare.Compare(lstX.SubItems[SortColumn].Text,
                            lstY.SubItems[SortColumn].Text);
                        break;
                    case SortMethod.SizeCompare:
                        rtnCompare =
                            (int)
                                (Utility.ReconvSize(lstX.SubItems[SortColumn].Text) -
                                 Utility.ReconvSize(lstY.SubItems[SortColumn].Text));
                        break;
                    case SortMethod.NumberCompare:
                        //当两个数字相减小于1时，(int)的强制转换会将结果变成0，所以不能使用减法来获得Ret。。。
                        if (Convert.ToDouble(lstX.SubItems[SortColumn].Text) >
                            Convert.ToDouble(lstY.SubItems[SortColumn].Text))
                        {
                            rtnCompare = 1;
                        }
                        else
                        {
                            if (Convert.ToDouble(lstX.SubItems[SortColumn].Text) ==
                                Convert.ToDouble(lstY.SubItems[SortColumn].Text))
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
                if (Order == SortOrder.Descending)
                {
                    rtnCompare = rtnCompare * -1;
                }
                return rtnCompare;
            }
        }

        #endregion

        #region"展示状态"

        /// <summary>
        /// </summary>
        /// <param name="trvSvrStatus"></param>
        /// <param name="mongoConnClientLst"></param>
        public static void FillClientStatusToList(CtlTreeViewColumns trvSvrStatus,
            Dictionary<string, MongoClient> mongoConnClientLst)
        {
            var srvDocList = new List<BsonDocument>();
            foreach (var mongoSvrKey in mongoConnClientLst.Keys)
            {
                try
                {
                    var mongoClient = mongoConnClientLst[mongoSvrKey];
                    if (!RuntimeMongoDbContext.GetServerConfigBySvrPath(mongoSvrKey).Health)
                    {
                        continue;
                    }
                    //flydreamer提供的代码
                    // 感谢 魏琼东 的Bug信息,一些命令必须以Admin执行
                    if (RuntimeMongoDbContext.GetServerConfigBySvrPath(mongoSvrKey).LoginAsAdmin)
                    {
                        var adminDb = mongoClient.GetDatabase(ConstMgr.DatabaseNameAdmin);
                        //Can't Convert IMongoDB To MongoDB
                        var serverStatusDoc =
                            CommandHelper.ExecuteMongoDBCommand(CommandHelper.ServerStatusCommand,
                                (MongoDatabase)adminDb).Response;
                        srvDocList.Add(serverStatusDoc);
                    }
                }
                catch (Exception ex)
                {
                    Utility.ExceptionDeal(ex);
                }
            }
            UIHelper.FillDataToTreeView("Server Status", trvSvrStatus, srvDocList, 0);
            //打开第一层
            foreach (TreeNode item in trvSvrStatus.DatatreeView.Nodes)
            {
                item.Expand();
            }
        }


        /// <summary>
        ///     Legacy:
        ///     Fill Server Status to treeview
        /// </summary>
        /// <param name="trvSvrStatus"></param>
        public static void FillSrvStatusToList(CtlTreeViewColumns trvSvrStatus,
            Dictionary<string, MongoServer> mongoConnSvrLst)
        {
            var srvDocList = new List<BsonDocument>();
            foreach (var mongoSvrKey in mongoConnSvrLst.Keys)
            {
                try
                {
                    var mongoSvr = mongoConnSvrLst[mongoSvrKey];
                    if (!RuntimeMongoDbContext.GetServerConfigBySvrPath(mongoSvrKey).Health)
                    {
                        continue;
                    }
                    //flydreamer提供的代码
                    // 感谢 魏琼东 的Bug信息,一些命令必须以Admin执行
                    if (RuntimeMongoDbContext.GetServerConfigBySvrPath(mongoSvrKey).LoginAsAdmin)
                    {
                        var serverStatusDoc =
                            CommandHelper.ExecuteMongoSvrCommand(CommandHelper.ServerStatusCommand, mongoSvr).Response;
                        srvDocList.Add(serverStatusDoc);
                    }
                }
                catch (Exception ex)
                {
                    Utility.ExceptionDeal(ex);
                }
            }
            UIHelper.FillDataToTreeView("Server Status", trvSvrStatus, srvDocList, 0);
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
        public static void FillDataBaseStatusToList(ListView lstSvr, Dictionary<string, MongoServer> mongoConnSvrLst)
        {
            lstSvr.Clear();
            lstSvr.Columns.Add(GuiConfig.GetText("DataBaseName",
                TextType.DataBaseStatusDataBaseName));
            lstSvr.Columns.Add(GuiConfig.GetText("CollectionCount",
                TextType.DataBaseStatusCollectionCount));
            lstSvr.Columns.Add(GuiConfig.GetText("DataSize",
                TextType.DataBaseStatusDataSize));
            lstSvr.Columns.Add(GuiConfig.GetText("FileSize",
                TextType.DataBaseStatusFileSize));
            lstSvr.Columns.Add(GuiConfig.GetText("IndexCount",
                TextType.DataBaseStatusIndexCount));
            lstSvr.Columns.Add(GuiConfig.GetText("IndexSize",
                TextType.DataBaseStatusIndexSize));
            lstSvr.Columns.Add(GuiConfig.GetText("ObjectCount",
                TextType.DataBaseStatusObjectCount));
            lstSvr.Columns.Add(GuiConfig.GetText("StorageSize",
                TextType.DataBaseStatusStorageSize));
            foreach (var mongoSvrKey in mongoConnSvrLst.Keys)
            {
                var mongoSvr = mongoConnSvrLst[mongoSvrKey];
                //感谢 魏琼东 的Bug信息,一些命令必须以Admin执行
                if (!RuntimeMongoDbContext.GetServerConfigBySvrPath(mongoSvrKey).Health ||
                    !RuntimeMongoDbContext.GetServerConfigBySvrPath(mongoSvrKey).LoginAsAdmin)
                {
                    continue;
                }
                var databaseNameList = mongoSvr.GetDatabaseNames().ToList();
                foreach (var strDbName in databaseNameList)
                {
                    var mongoDb = mongoSvr.GetDatabase(strDbName);
                    var dbStatus = mongoDb.GetStats();
                    var lst = new ListViewItem(mongoSvrKey + "." + strDbName);
                    try
                    {
                        lst.SubItems.Add(dbStatus.CollectionCount.ToString());
                    }
                    catch (Exception)
                    {
                        lst.SubItems.Add("0");
                    }
                    lst.SubItems.Add(MongoHelper.GetBsonSize(dbStatus.DataSize));
                    try
                    {
                        //WideTiger:FileSize
                        lst.SubItems.Add(MongoHelper.GetBsonSize(dbStatus.FileSize));
                    }
                    catch (Exception)
                    {
                        lst.SubItems.Add("N/A");
                    }
                    lst.SubItems.Add(dbStatus.IndexCount.ToString());
                    lst.SubItems.Add(MongoHelper.GetBsonSize(dbStatus.IndexSize));
                    lst.SubItems.Add(dbStatus.ObjectCount.ToString());
                    lst.SubItems.Add(MongoHelper.GetBsonSize(dbStatus.StorageSize));
                    lstSvr.Items.Add(lst);
                }
            }
            lstSvr.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        /// <summary>
        ///     fill Collection status to ListView
        /// </summary>
        /// <param name="lstData"></param>
        public static void FillCollectionStatusToList(ListView lstData, Dictionary<string, MongoServer> mongoConnSvrLst)
        {
            lstData.Clear();
            lstData.Columns.Add(GuiConfig.GetText("CollectionName", TextType.CollectionStatusCollectionName));
            lstData.Columns.Add(GuiConfig.GetText("ObjectCount", TextType.CollectionStatusObjectCount));
            lstData.Columns.Add(GuiConfig.GetText("DataSize", TextType.CollectionStatusDataSize));
            lstData.Columns.Add(GuiConfig.GetText("LastExtentSize", TextType.CollectionStatusLastExtentSize));
            lstData.Columns.Add(GuiConfig.GetText("StorageSize", TextType.CollectionStatusStorageSize));
            lstData.Columns.Add(GuiConfig.GetText("TotalIndexSize", TextType.CollectionStatusTotalIndexSize));
            lstData.Columns.Add(GuiConfig.GetText("IsCapped", TextType.CollectionStatusIsCapped));
            lstData.Columns.Add(GuiConfig.GetText("MaxDocuments", TextType.CollectionStatusMaxDocuments));
            lstData.Columns.Add(GuiConfig.GetText("AverageObjectSize", TextType.CollectionStatusAverageObjectSize));
            lstData.Columns.Add(GuiConfig.GetText("PaddingFactor", TextType.CollectionStatusPaddingFactor));
            foreach (var mongoSvrKey in mongoConnSvrLst.Keys)
            {
                var mongoSvr = mongoConnSvrLst[mongoSvrKey];
                //感谢 魏琼东 的Bug信息,一些命令必须以Admin执行
                if (!RuntimeMongoDbContext.GetServerConfigBySvrPath(mongoSvrKey).Health ||
                    !RuntimeMongoDbContext.GetServerConfigBySvrPath(mongoSvrKey).LoginAsAdmin)
                {
                    continue;
                }
                var databaseNameList = mongoSvr.GetDatabaseNames().ToList();
                foreach (var strDbName in databaseNameList)
                {
                    var mongoDb = mongoSvr.GetDatabase(strDbName);

                    var colNameList = mongoDb.GetCollectionNames().ToList();
                    foreach (var strColName in colNameList)
                    {
                        try
                        {
                            var collectionStatus = mongoDb.GetCollection(strColName).GetStats();
                            var lst = new ListViewItem(mongoSvrKey + "." + strDbName + "." + strColName);
                            lst.SubItems.Add(collectionStatus.ObjectCount.ToString());
                            lst.SubItems.Add(MongoHelper.GetBsonSize(collectionStatus.DataSize));
                            try
                            {
                                //WideTiger:LastExtentSize
                                lst.SubItems.Add(
                                    MongoHelper.GetBsonSize(collectionStatus.LastExtentSize));
                            }
                            catch (Exception)
                            {
                                lst.SubItems.Add("N/A");
                            }

                            lst.SubItems.Add(MongoHelper.GetBsonSize(collectionStatus.StorageSize));
                            lst.SubItems.Add(MongoHelper.GetBsonSize(collectionStatus.TotalIndexSize));

                            //2012-3-6
                            lst.SubItems.Add(collectionStatus.IsCapped.ToString());
                            //https://jira.mongodb.org/browse/CSHARP-665
                            try
                            {
                                //注意：这个MaxDocuments只是在CappedCollection时候有效
                                lst.SubItems.Add(collectionStatus.MaxDocuments.ToString());
                            }
                            catch (Exception ex)
                            {
                                //溢出
                                lst.SubItems.Add(int.MaxValue.ToString());
                                Utility.ExceptionLog(ex);
                            }

                            lst.SubItems.Add(collectionStatus.ObjectCount != 0
                                ? MongoHelper.GetBsonSize((long)collectionStatus.AverageObjectSize)
                                : "0");

                            try
                            {
                                //在某些条件下，这个值会抛出异常，IndexKeyNotFound
                                lst.SubItems.Add(collectionStatus.PaddingFactor.ToString());
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
                            Utility.ExceptionDeal(ex);
                        }
                    }
                }
            }
            lstData.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        /// <summary>
        ///     将数据Opr放入ListView
        /// </summary>
        /// <param name="lstSrvOpr"></param>
        public static void FillCurrentOprToList(ListView lstSrvOpr,
            Dictionary<string, MongoServer> mongoConnSvrLst)
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
            foreach (var mongoSvrKey in mongoConnSvrLst.Keys)
            {
                var mongoSvr = mongoConnSvrLst[mongoSvrKey];
                //感谢 魏琼东 的Bug信息,一些命令必须以Admin执行
                var databaseNameList = mongoSvr.GetDatabaseNames().ToList();
                foreach (var strDbName in databaseNameList)
                {
                    try
                    {
                        var mongoDb = mongoSvr.GetDatabase(strDbName);
                        var dbStatus = mongoDb.GetCurrentOp();
                        var doc = dbStatus.GetValue("inprog").AsBsonArray;
                        foreach (BsonDocument item in doc)
                        {
                            var lst = new ListViewItem(mongoSvrKey + "." + strDbName);
                            foreach (var itemName in item.Names)
                            {
                                lst.SubItems.Add(item.GetValue(itemName).ToString());
                            }
                            lstSrvOpr.Items.Add(lst);
                        }
                    }
                    catch (EndOfStreamException)
                    {
                        //SkipIt
                        return;
                    }
                    catch (Exception ex)
                    {
                        Utility.ExceptionDeal(ex);
                    }
                }
            }
            lstSrvOpr.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        #endregion
    }
}