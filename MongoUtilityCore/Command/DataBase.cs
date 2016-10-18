using System;
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
        ///     是否为合法的数据库名称
        /// </summary>
        /// <param name="strDbName"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public static bool IsDatabaseNameValid(string strDbName, out string errMessage)
        {
            return RuntimeMongoDbContext.GetCurrentServer().IsDatabaseNameValid(strDbName, out errMessage);
        }

        /// <summary>
        ///     修复和压缩数据库
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


        //从权限上看，clusterAdmin是必须的
        //但是能够建立数据库，不表示能够看到里面的内容！
        //dbAdmin可以访问数据库。
        //clusterAdmin能创建数据库但是不能访问数据库。
        //try
        //{
        //Driver 2.0.1 
        //如果没有后续对于db的操作，则数据库无法新建
        //db.CreateCollection("demo");
        //}
        //catch (Exception ex)
        //{
        //    //如果使用没有dbAdmin权限的clusterAdmin。。。。
        //    Utility.ExceptionDeal(ex);
        //}


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
            var db = mongoSvr.GetDatabase(dbName);
            switch (func)
            {
                case Oprcode.Create:
                    if (!mongoSvr.DatabaseExists(dbName))
                    {
                        db.CreateCollection("demo");
                        //如果一个数据库没有数据集，则这个数据库则会被自动回收掉
                        //db.DropCollection("demo");
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
        /// <summary>
        ///     新建数据库
        ///     数据库必须有一个数据集，如果没有数据集的话，则数据库会被回收掉
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="CollectionName"></param>
        /// <returns></returns>
        public static string CreateDataBaseWithInitCollection(string dbName, string CollectionName)
        {
            var mongoSvr = RuntimeMongoDbContext.GetCurrentServer();
            var rtnResult = string.Empty;
            if (mongoSvr == null) return rtnResult;
            if (!mongoSvr.DatabaseExists(dbName))
            {
                var db = mongoSvr.GetDatabase(dbName);
                db.CreateCollection(CollectionName);
            }
            return rtnResult;
        }
    }
}