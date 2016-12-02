using MongoUtility.Basic;
using MongoUtility.Core;

namespace MongoUtility.ToolKit
{
    /// <summary>
    ///     Mongodump使用的结构
    /// </summary>
    public class MongoDumpInfo
    {
        /// <summary>
        /// </summary>
        public string ArchiveFilename = string.Empty;

        //https://docs.mongodb.org/master/reference/program/mongodump/#mongodump-example-archive-file


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
        ///     Writes the output to a single archive file or to the standard output (stdout).
        ///     (Since 3.2.0)
        /// </summary>
        public bool IsArchive = false;

        /// <summary>
        ///     Compresses the output.(Since 3.2.0)
        /// </summary>
        public bool IsGZip = false;

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
        public int Port = ConstMgr.MongodDefaultPort;

        /// <summary>
        ///     获得备份的配置
        /// </summary>
        /// <param name="mongoDump"></param>
        /// <returns></returns>
        public static string GetMongodumpCommandLine(MongoDumpInfo mongoDump)
        {
            //mongodump.exe 备份程序
            var dosCommand = @"mongodump -h @hostaddr:@port -d @dbname";
            dosCommand = dosCommand.Replace("@hostaddr", mongoDump.HostAddr);
            dosCommand = dosCommand.Replace("@port", mongoDump.Port.ToString());
            dosCommand = dosCommand.Replace("@dbname", mongoDump.DbName);
            if (mongoDump.CollectionName != string.Empty)
            {
                //-c CollectionName Or --collection CollectionName
                dosCommand += " --collection " + mongoDump.CollectionName;
            }
            if (mongoDump.OutPutPath != string.Empty)
            {
                //3.0.0 RC10 不允许带有空格的路径了?
                //dosCommand += " --out \"" + mongoDump.OutPutPath + "\"";
                dosCommand += " --out " + mongoDump.OutPutPath;
            }
            if (mongoDump.IsGZip)
            {
                //Since 3.2.0
                dosCommand += " --gzip";
            }
            if (mongoDump.IsArchive)
            {
                //Since 3.2.0
                dosCommand += " --archive";
                if (!string.IsNullOrEmpty(mongoDump.ArchiveFilename))
                {
                    dosCommand += "=" + mongoDump.ArchiveFilename;
                }
            }
            return dosCommand;
        }

        public static MongoDumpInfo GetMongoDump(bool isDb)
        {
            var mongoDump = new MongoDumpInfo();
            var mongosrv = RuntimeMongoDbContext.GetCurrentServer().Instance;
            mongoDump.HostAddr = mongosrv.Address.Host;
            mongoDump.Port = mongosrv.Address.Port;
            mongoDump.DbName = RuntimeMongoDbContext.GetCurrentDataBaseName();
            if (!isDb) mongoDump.CollectionName = RuntimeMongoDbContext.GetCurrentCollectionName();
            return mongoDump;
        }
    }
}