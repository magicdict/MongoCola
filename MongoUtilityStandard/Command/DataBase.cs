using MongoUtility.Basic;
using MongoUtility.Core;

namespace MongoUtility.Command
{
    public static partial class Operater
    {


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
            CommandExecute.ExecuteMongoCommand(DataBaseCommand.RepairDatabaseCommand);
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
 

        /// <summary>
        ///     数据库操作
        /// </summary>
        /// <param name="strObjTag"></param>
        /// <param name="dbName"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static string DropDatabase(string strObjTag, string dbName)
        {
            var mongoSvr = RuntimeMongoDbContext.GetCurrentServer();
            var rtnResult = string.Empty;
            TagInfo.GetTagPath(strObjTag);
            if (mongoSvr == null) return rtnResult;
            if (mongoSvr.DatabaseExists(dbName))
            {
                var result = mongoSvr.DropDatabase(dbName);
                return !result.Response.Contains("err") ? string.Empty : result.Response["err"].ToString();
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
            //在副本的时候，会发生错误，副本无法简单创建数据集
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