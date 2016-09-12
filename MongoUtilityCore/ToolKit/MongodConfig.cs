using MongoUtility.Basic;

namespace MongoUtility.ToolKit
{
    /// <summary>
    ///     Mongod使用结构体
    /// </summary>
    public class MongodConfig
    {
        /// <summary>
        ///     # 如果从库与主库同步数据差得多，自动重新同步，
        /// </summary>
        public bool Autoresync = false;

        /// <summary>
        ///     # 绑定服务IP，若绑定127.0.0.1，则只能本机访问，不指定默认本地所有IP
        /// </summary>
        public string BindIp = string.Empty;

        /// <summary>
        ///     # 声明这是一个集群的config服务,默认端口27019，默认目录/data/configdb
        /// </summary>
        public string Configsvr = string.Empty;

        /// <summary>
        ///     # 指定数据库路径
        /// </summary>
        public string DbPath = string.Empty;

        /// Replicaton 参数
        /// <summary>
        ///     # 从一个dbpath里启用从库复制服务，该dbpath的数据库是主库的快照，可用于快速启用同步
        /// </summary>
        public bool Fastsync = false;

        /// <summary>
        ///     是否采用认证模式
        /// </summary>
        public bool IsAuth = false;

        /// <summary>
        ///     是否作为Windows服务
        /// </summary>
        public bool IsInstall = false;

        /// <summary>
        ///     日志是否为添加模式
        /// </summary>
        public bool Islogappend = false;

        /// <summary>
        ///     日志等级
        /// </summary>
        public MongodbDosCommand.MongologLevel LogLv = MongodbDosCommand.MongologLevel.Quiet;

        /// <summary>
        ///     日志文件
        /// </summary>
        public string LogPath = string.Empty;

        /// 主/从参数
        /// <summary>
        ///     # 主库模式
        /// </summary>
        public bool Master = false;

        /// <summary>
        ///     # 关闭偏执为moveChunk数据保存??
        /// </summary>
        public bool MoveParanoia = false;

        /// <summary>
        ///     # 指定单一的数据库复制
        /// </summary>
        public string Only = string.Empty;

        /// <summary>
        ///     # 设置oplog的大小(MB)
        /// </summary>
        public int OplogSize = 0;

        /// <summary>
        ///     # 指定服务端口号，默认端口27017
        /// </summary>
        public int Port = ConstMgr.MongodDefaultPort;

        /// Replica set(副本集)选项
        /// <summary>
        ///     # 设置副本集名称
        /// </summary>
        public string ReplSet = string.Empty;

        /// <summary>
        ///     # 声明这是一个集群的分片,默认端口27018
        /// </summary>
        public string Shardsvr = string.Empty;

        /// <summary>
        ///     # 从库模式
        /// </summary>
        public bool Slave = false;

        /// <summary>
        ///     # 设置从库同步主库的延迟时间
        /// </summary>
        public int Slavedelay = 0;

        /// <summary>
        ///     # 从库 端口号
        /// </summary>
        public string Source = string.Empty;
    }
}