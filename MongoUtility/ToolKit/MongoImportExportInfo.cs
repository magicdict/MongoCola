using System;
using MongoUtility.Basic;
using MongoUtility.Core;

namespace MongoUtility.ToolKit
{
    /// <summary>
    ///     ImportExport使用的结构
    /// </summary>
    public class MongoImportExportInfo
    {
        public enum ImprotExport
        {
            /// <summary>
            ///     导入
            /// </summary>
            Import,

            /// <summary>
            ///     导出
            /// </summary>
            Export
        }

        /// <summary>
        ///     数据集名称
        /// </summary>
        public string CollectionName = String.Empty;

        /// <summary>
        ///     数据库名称
        /// </summary>
        public string DbName = String.Empty;

        /// <summary>
        ///     导入导出标志
        /// </summary>
        public ImprotExport Direct = ImprotExport.Import;

        /// <summary>
        ///     字段列表
        /// </summary>
        public string FieldList = String.Empty;

        /// <summary>
        ///     文件名称
        /// </summary>
        public string FileName = String.Empty;

        /// <summary>
        ///     主机地址
        /// </summary>
        public string HostAddr = String.Empty;

        /// <summary>
        ///     日志等级
        /// </summary>
        public MongodbDosCommand.MongologLevel LogLv = MongodbDosCommand.MongologLevel.Quiet;

        /// <summary>
        ///     主机端口
        /// </summary>
        public Int32 Port = ConstMgr.MongodDefaultPort;

        /// <summary>
        ///     获得MongoImportExport命令[必须指定数据集名称！！]
        /// </summary>
        /// <param name="mongoImprotExport"></param>
        /// <returns></returns>
        public static string GetMongoImportExportCommandLine(MongoImportExportInfo mongoImprotExport)
        {
            //mongodump.exe 备份程序
            string dosCommand;
            if (mongoImprotExport.Direct == ImprotExport.Import)
            {
                dosCommand = @"mongoimport -h @hostaddr:@port -d @dbname";
                if (mongoImprotExport.FieldList != String.Empty)
                {
                    dosCommand += " --fields " + mongoImprotExport.FieldList;
                }
                if (mongoImprotExport.FileName != String.Empty)
                {
                    dosCommand += " --file \"" + mongoImprotExport.FileName + "\"";
                }
            }
            else
            {
                dosCommand = @"mongoexport -h @hostaddr:@port -d @dbname";
                if (mongoImprotExport.FileName != String.Empty)
                {
                    dosCommand += " --out \"" + mongoImprotExport.FileName + "\"";
                }
            }
            dosCommand = dosCommand.Replace("@hostaddr", mongoImprotExport.HostAddr);
            dosCommand = dosCommand.Replace("@port", mongoImprotExport.Port.ToString());
            dosCommand = dosCommand.Replace("@dbname", mongoImprotExport.DbName);
            if (mongoImprotExport.CollectionName != String.Empty)
            {
                //-c CollectionName Or --collection CollectionName
                dosCommand += " --collection " + mongoImprotExport.CollectionName;
            }
            return dosCommand;
        }

        public static MongoImportExportInfo GetImportExportInfo()
        {
            var mongoImportExport = new MongoImportExportInfo();
            var mongosrv = RuntimeMongoDbContext.GetCurrentServer().Instance;
            mongoImportExport.HostAddr = mongosrv.Address.Host;
            mongoImportExport.Port = mongosrv.Address.Port;
            mongoImportExport.DbName = RuntimeMongoDbContext.GetCurrentDataBaseName();
            mongoImportExport.CollectionName = RuntimeMongoDbContext.GetCurrentCollectionName();
            return mongoImportExport;
        }
    }
}