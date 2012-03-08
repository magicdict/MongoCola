using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
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

                //2012-3-6
                lstData.Columns.Add("IsCapped");
                lstData.Columns.Add("MaxDocuments");

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

                //2012-3-6
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Status_IsCapped));
                lstData.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Status_MaxDocuments));


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

                                //2012-3-6
                                lst.SubItems.Add(CollectionStatus.IsCapped.ToString());
                                lst.SubItems.Add(CollectionStatus.MaxDocuments.ToString());

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
                        catch
                        {
                            throw;
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
        private static String GetSize(BsonValue size)
        {
            if (size.IsInt32)
            {
                return GetSize((Int32)size);
            }
            else
            {
                return GetSize((Int64)size);
            }
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
