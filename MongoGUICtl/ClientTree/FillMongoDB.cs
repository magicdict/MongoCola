using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;

namespace MongoGUICtl.ClientTree
{
    public static class FillMongoDb
    {
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
                    //flydreamer提供的代码
                    // 感谢 魏琼东 的Bug信息,一些命令必须以Admin执行
                    if (RuntimeMongoDbContext.GetServerConfigBySvrPath(mongoSvrKey).LoginAsAdmin)
                    {
                        var adminDb = mongoClient.GetDatabase(ConstMgr.DatabaseNameAdmin);
                        //Can't Convert IMongoDB To MongoDB
                        var command = new CommandDocument {{CommandHelper.ServerStatusCommand.CommandString, 1}};

                        var serverStatusDoc =
                            CommandHelper.ExecuteMongoDBCommand(command, adminDb).Response;
                        srvDocList.Add(serverStatusDoc);
                    }
                }
                catch (Exception ex)
                {
                    Utility.ExceptionDeal(ex);
                }
            }
            UiHelper.FillDataToTreeView("Server Status", trvSvrStatus, srvDocList, 0);
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
        /// <param name="mongoConnSvrLst"></param>
        public static void FillDataBaseStatusToList(CtlTreeViewColumns lstSvr,
            Dictionary<string, MongoServer> mongoConnSvrLst)
        {
            var dbStatusList = new List<BsonDocument>();
            foreach (var mongoSvrKey in mongoConnSvrLst.Keys)
            {
                var mongoSvr = mongoConnSvrLst[mongoSvrKey];
                var databaseNameList = mongoSvr.GetDatabaseNames().ToList();
                foreach (var strDbName in databaseNameList)
                {
                    var mongoDb = mongoSvr.GetDatabase(strDbName);
                    var dbStatus = mongoDb.GetStats();
                    dbStatusList.Add(dbStatus.Response);
                }
            }
            UiHelper.FillDataToTreeView("DataBase Status", lstSvr, dbStatusList, 0);
        }

        /// <summary>
        ///     fill Collection status to ListView
        /// </summary>
        /// <param name="lstData"></param>
        /// <param name="mongoConnSvrLst"></param>
        public static void FillCollectionStatusToList(CtlTreeViewColumns lstData,
            Dictionary<string, MongoServer> mongoConnSvrLst)
        {
            var dbStatusList = new List<BsonDocument>();
            foreach (var mongoSvrKey in mongoConnSvrLst.Keys)
            {
                var mongoSvr = mongoConnSvrLst[mongoSvrKey];
                var databaseNameList = mongoSvr.GetDatabaseNames().ToList();
                foreach (var strDbName in databaseNameList)
                {
                    var mongoDb = mongoSvr.GetDatabase(strDbName);
                    var colNameList = mongoDb.GetCollectionNames().ToList();
                    foreach (var strColName in colNameList)
                    {
                        var collectionStatus = mongoDb.GetCollection(strColName).GetStats();
                        dbStatusList.Add(collectionStatus.Response);
                    }
                }
            }
            UiHelper.FillDataToTreeView("Collection Status", lstData, dbStatusList, 0);
        }

        #endregion
    }
}