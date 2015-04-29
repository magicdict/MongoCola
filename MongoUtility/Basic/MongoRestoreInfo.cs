using System;
using MongoUtility.Core;

namespace MongoUtility.Basic
{
    /// <summary>
    ///     MongoRestore使用的结构
    /// </summary>
    public class MongoRestoreInfo
    {
        /// <summary>
        ///     备份数据库路径
        /// </summary>
        public string DirectoryPerDb = string.Empty;

        /// <summary>
        ///     主机地址
        /// </summary>
        public string HostAddr = string.Empty;

        /// <summary>
        ///     主机端口
        /// </summary>
        public Int32 Port = ConstMgr.MongodDefaultPort;

        public static MongoRestoreInfo getMongoRestoreInfo()
        {
            var mongoRestore = new MongoRestoreInfo();
            var mongosrv = RuntimeMongoDbContext.GetCurrentServer().Instance;
            mongoRestore.HostAddr = mongosrv.Address.Host;
            mongoRestore.Port = mongosrv.Address.Port;
            return mongoRestore;
        }
    }
}
