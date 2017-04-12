using MongoUtility.Basic;
using MongoUtility.Core;

namespace MongoUtility.ToolKit
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
        public int Port = ConstMgr.MongodDefaultPort;

        /// <summary>
        ///     获得恢复的配置
        ///     和恢复数据库是相同的操作，只是根据目录结构不同进行不同恢复操作
        ///     目录名称表示数据库名称，BSON文件表示数据集
        /// </summary>
        /// <param name="mongoRestore"></param>
        /// <returns></returns>
        public static string GetMongoRestoreCommandLine(MongoRestoreInfo mongoRestore)
        {
            //mongorestore.exe 恢复程序
            var dosCommand = @"mongorestore -h @hostaddr:@port --directoryperdb @dbname";
            dosCommand = dosCommand.Replace("@hostaddr", mongoRestore.HostAddr);
            dosCommand = dosCommand.Replace("@port", mongoRestore.Port.ToString());
            dosCommand = dosCommand.Replace("@dbname", mongoRestore.DirectoryPerDb);
            return dosCommand;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        public static MongoRestoreInfo GetMongoRestoreInfo()
        {
            var mongoRestore = new MongoRestoreInfo();
            var mongosrv = RuntimeMongoDbContext.GetCurrentServer().Instance;
            mongoRestore.HostAddr = mongosrv.Address.Host;
            mongoRestore.Port = mongosrv.Address.Port;
            return mongoRestore;
        }
    }
}