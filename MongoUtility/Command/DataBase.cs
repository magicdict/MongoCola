using System;
using Common;
using MongoUtility.Basic;
using MongoUtility.Core;

namespace MongoUtility.Command
{
    public static partial class Operater
    {
        /// <summary>
        ///     操作模式
        /// </summary>
        public enum Oprcode
        {
            /// <summary>
            ///     新建
            /// </summary>
            Create,

            /// <summary>
            ///     删除
            /// </summary>
            Drop,

            /// <summary>
            ///     压缩
            /// </summary>
            Repair,

            /// <summary>
            ///     重命名
            /// </summary>
            Rename
        }

        /// <summary>
        /// </summary>
        /// <param name="strDbName"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public static bool IsDatabaseNameValid(string strDbName, out string errMessage)
        {
            return RuntimeMongoDbContext.GetCurrentServer().IsDatabaseNameValid(strDbName, out errMessage);
        }

        /// <summary>
        /// </summary>
        public static void RepairDb()
        {
            CommandHelper.ExecuteMongoCommand(CommandHelper.RepairDatabaseCommand);
        }

        /// <summary>
        ///     是否为系统数据库[无法删除]
        /// </summary>
        /// <param name="dataBaseName"></param>
        /// <returns></returns>
        public static bool IsSystemDataBase(string dataBaseName)
        {
            //config数据库,默认为系统
            //admin数据库,默认为系统
            //local数据库,默认为系统
            switch (dataBaseName)
            {
                case ConstMgr.DatabaseNameLocal:
                case ConstMgr.DatabaseNameConfig:
                case ConstMgr.DatabaseNameAdmin:
                    return true;
            }
            return false;
        }

        /// <summary>
        ///     数据库操作
        /// </summary>
        /// <param name="strObjTag"></param>
        /// <param name="dbName"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static string DataBaseOpration(string strObjTag, string dbName, Oprcode func)
        {
            var mongoSvr = RuntimeMongoDbContext.GetCurrentServer();
            var rtnResult = string.Empty;
            TagInfo.GetTagPath(strObjTag);
            if (mongoSvr == null) return rtnResult;
            switch (func)
            {
                case Oprcode.Create:
                    if (!mongoSvr.DatabaseExists(dbName))
                    {
                        //从权限上看，clusterAdmin是必须的
                        //但是能够建立数据库，不表示能够看到里面的内容！
                        //dbAdmin可以访问数据库。
                        //clusterAdmin能创建数据库但是不能访问数据库。
                        try
                        {
                            //Driver 2.0.1 
                            //如果没有后续对于db的操作，则数据库无法新建
                            var db = mongoSvr.GetDatabase(dbName);
                            db.CreateCollection("demo");
                        }
                        catch (Exception ex)
                        {
                            //如果使用没有dbAdmin权限的clusterAdmin。。。。
                            Utility.ExceptionDeal(ex);
                        }
                    }
                    break;
                case Oprcode.Drop:
                    if (mongoSvr.DatabaseExists(dbName))
                    {
                        var result = mongoSvr.DropDatabase(dbName);
                        return !result.Response.Contains("err") ? string.Empty : result.Response["err"].ToString();
                    }
                    break;
                case Oprcode.Repair:
                    //其实Repair的入口不在这个方法里面
                    CommandHelper.ExecuteMongoDBCommand(CommandHelper.RepairDatabaseCommand,
                        mongoSvr.GetDatabase(dbName));
                    break;
            }
            return rtnResult;
        }
    }
}