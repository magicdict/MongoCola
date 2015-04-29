using System;
using MongoUtility.Core;

namespace MongoUtility.Basic
{
    /// <summary>
    ///     ImportExport使用的结构
    /// </summary>
    public class ImportExportInfo
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
        ///     导入导出标志
        /// </summary>
        public MongodbDosCommand.ImprotExport Direct = MongodbDosCommand.ImprotExport.Import;

        /// <summary>
        ///     字段列表
        /// </summary>
        public string FieldList = string.Empty;

        /// <summary>
        ///     文件名称
        /// </summary>
        public string FileName = string.Empty;

        /// <summary>
        ///     主机地址
        /// </summary>
        public string HostAddr = string.Empty;

        /// <summary>
        ///     日志等级
        /// </summary>
        public MongodbDosCommand.MongologLevel LogLv = MongodbDosCommand.MongologLevel.Quiet;

        /// <summary>
        ///     主机端口
        /// </summary>
        public Int32 Port = ConstMgr.MongodDefaultPort;

        public static ImportExportInfo getStruImportExport()
        {
            var mongoImportExport = new ImportExportInfo();
            var mongosrv = RuntimeMongoDbContext.GetCurrentServer().Instance;
            mongoImportExport.HostAddr = mongosrv.Address.Host;
            mongoImportExport.Port = mongosrv.Address.Port;
            mongoImportExport.DbName = RuntimeMongoDbContext.GetCurrentDataBaseName();
            mongoImportExport.CollectionName = RuntimeMongoDbContext.GetCurrentCollectionName();
            return mongoImportExport;
        }

    }
}
