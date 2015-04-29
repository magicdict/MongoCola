using System;
using MongoUtility.Core;

namespace MongoUtility.Basic
{
    /// <summary>
    ///     Mongodump使用的结构
    /// </summary>
    public class MongoDumpInfo
    {
        /// <summary>
        ///     数据集名称
        /// </summary>
        public string CollectionName = string.Empty;

        /// <summary>
        ///     数据库名称
        /// </summary>
        public string DbName = string.Empty;

        /// <summary>
        ///     主机地址
        /// </summary>
        public string HostAddr = string.Empty;

        /// <summary>
        ///     日志等级
        /// </summary>
        public MongodbDosCommand.MongologLevel LogLv = MongodbDosCommand.MongologLevel.Quiet;

        /// <summary>
        ///     输出路径
        /// </summary>
        public string OutPutPath = string.Empty;

        /// <summary>
        ///     主机端口
        /// </summary>
        public Int32 Port = ConstMgr.MongodDefaultPort;

        public static MongoDumpInfo getMongoDump(bool isDB)
        {
            var mongoDump = new MongoDumpInfo();
            var mongosrv = RuntimeMongoDbContext.GetCurrentServer().Instance;
            mongoDump.HostAddr = mongosrv.Address.Host;
            mongoDump.Port = mongosrv.Address.Port;
            mongoDump.DbName = RuntimeMongoDbContext.GetCurrentDataBaseName();
            if(!isDB) mongoDump.CollectionName = RuntimeMongoDbContext.GetCurrentCollectionName();
            return mongoDump;
        }
    }
}
