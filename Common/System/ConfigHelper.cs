using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MongoDB.Driver;

namespace MagicMongoDBTool.Module
{
    [Serializable]
    public class ConfigHelper
    {
        /// <summary>
        ///     服务器类型
        /// </summary>
        public enum SvrRoleType
        {
            /// <summary>
            ///     数据服务器[mongod]
            /// </summary>
            DataSvr,

            /// <summary>
            ///     Sharding服务器[mongos]
            /// </summary>
            ShardSvr,

            /// <summary>
            ///     副本服务器[Virtul]
            /// </summary>
            ReplsetSvr,

            /// <summary>
            ///     Master主服务器
            /// </summary>
            MasterSvr,

            /// <summary>
            ///     Slave从属服务器
            /// </summary>
            SlaveSvr
        }

        /// <summary>
        ///     配置文件名称
        /// </summary>
        public static String _configFilename = "config.xml";

        /// <summary>
        ///     Config Format Version
        /// </summary>
        public byte ConfigVer = 1;

        /// <summary>
        ///     连接配置列表(管理用）
        /// </summary>
        [XmlIgnore] public Dictionary<String, MongoConnectionConfig> ConnectionList =
            new Dictionary<String, MongoConnectionConfig>();

        /// <summary>
        ///     语言
        /// </summary>
        public String LanguageFileName = String.Empty;

        /// <summary>
        ///     MongoBin的路径，用于Dos命令
        /// </summary>
        public String MongoBinPath = String.Empty;

        /// <summary>
        ///     状态刷新间隔时间
        /// </summary>
        public int RefreshStatusTimer = 30;

        /// <summary>
        ///     连接配置列表(保存用）
        /// </summary>
        public List<MongoConnectionConfig> SaveConnectionList = new List<MongoConnectionConfig>();

        /// <summary>
        ///     通过Host信息获得连接名称
        /// </summary>
        /// <param name="Addr"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public String GetCollectionNameByHost(String Addr, int port)
        {
            foreach (MongoConnectionConfig item in ConnectionList.Values)
            {
                if (item.Host == Addr && item.Port == port)
                {
                    return item.ConnectionName;
                }
            }
            return String.Empty;
        }

        /// <summary>
        ///     通过连接名称获得Host信息
        /// </summary>
        /// <param name="ConnectionName"></param>
        /// <returns></returns>
        public MongoServerAddress GetMongoSvrAddrByConnectionName(String ConnectionName)
        {
            MongoServerAddress mongosrvAddr = null;
            if (ConnectionList.ContainsKey(ConnectionName))
            {
                mongosrvAddr = new MongoServerAddress(ConnectionList[ConnectionName].Host,
                    ConnectionList[ConnectionName].Port);
            }
            return mongosrvAddr;
        }

        /// <summary>
        ///     添加链接
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public Boolean AddConnection(MongoConnectionConfig con)
        {
            ConnectionList.Add(con.ConnectionName, con);
            return true;
        }

        /// <summary>
        ///     读取配置
        /// </summary>
        /// <param name="configFileName"></param>
        /// <returns></returns>
        public static ConfigHelper LoadFromConfigFile(String configFileName)
        {
            var fs = new FileStream(configFileName, FileMode.Open, FileAccess.Read);
            var xs = new XmlSerializer(typeof (ConfigHelper));
            var t = (ConfigHelper) xs.Deserialize(fs);
            foreach (MongoConnectionConfig item in t.SaveConnectionList)
            {
                t.ConnectionList.Add(item.ConnectionName, item);
            }
            fs.Close();
            _configFilename = configFileName;
            return t;
        }

        /// <summary>
        ///     写入配置
        /// </summary>
        public void SaveToConfigFile()
        {
            SaveToConfigFile(_configFilename);
        }

        /// <summary>
        ///     写入配置
        /// </summary>
        /// <param name="configFileName"></param>
        public void SaveToConfigFile(String configFileName)
        {
            FileStream fs = null;
            var xs = new XmlSerializer(typeof (ConfigHelper));

            SaveConnectionList.Clear();
            foreach (MongoConnectionConfig item in ConnectionList.Values)
            {
                SaveConnectionList.Add(item);
            }
            fs = new FileStream(configFileName, FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, this);
            fs.Close();
        }

        /// <summary>
        ///     连接结构体
        /// </summary>
        public struct MongoConnectionConfig
        {
            /// <summary>
            ///     认证模式[这个属性是运行时决定的]
            /// </summary>
            [XmlIgnore] public Boolean AuthMode;

            /// <summary>
            ///     连接名称
            /// </summary>
            public String ConnectionName;

            /// <summary>
            ///     连接字符串
            /// </summary>
            public String ConnectionString;

            /// <summary>
            ///     数据库名称
            /// </summary>
            public String DataBaseName;

            /// <summary>
            ///     当前连接是否可以使用[这个属性是运行时决定的]
            /// </summary>
            [XmlIgnore] public Boolean Health;

            /// <summary>
            ///     IP地址
            /// </summary>
            public String Host;

            /// <summary>
            ///     只读[这个属性是运行时决定的]
            /// </summary>
            /// [XmlIgnore()]
            public Boolean IsReadOnly;

            /// <summary>
            ///     作为Admin登陆[这个属性是运行时决定的]
            /// </summary>
            [XmlIgnore] public bool LoginAsAdmin;

            /// <summary>
            ///     当前连接的MongoDB版本[这个属性是运行时决定的]
            /// </summary>
            [XmlIgnore] public Version MongoDBVersion;

            /// <summary>
            ///     密码
            /// </summary>
            public String Password;

            /// <summary>
            ///     端口号
            /// </summary>
            public int Port;

            /// <summary>
            ///     ReadPreference
            /// </summary>
            public String ReadPreference;

            /// <summary>
            ///     副本名称
            /// </summary>
            public String ReplSetName;

            /// <summary>
            ///     副本服务器列表
            /// </summary>
            public List<String> ReplsetList;

            /// <summary>
            ///     服务器角色[这个属性是运行时决定的]
            /// </summary>
            [XmlIgnore] public SvrRoleType ServerRole;

            /// <summary>
            ///     是否启用主从模式[Route的时候，不能设置为True]
            /// </summary>
            /// public bool IsSlaveOk;
            /// <summary>
            ///     是否为安全模式
            /// </summary>
            /// public bool IsSafeMode;
            /// <summary>
            ///     使用SSL初始化连接
            /// </summary>
            public Boolean UseSsl;

            /// <summary>
            ///     用户名
            /// </summary>
            public String UserName;

            /// <summary>
            ///     VerifySslCertificate
            /// </summary>
            public Boolean VerifySslCertificate;

            /// <summary>
            ///     WaitQueueSize;
            /// </summary>
            /// <remarks></remarks>
            public int WaitQueueSize;

            /// <summary>
            ///     WriteConcern
            /// </summary>
            public String WriteConcern;

            /// <summary>
            ///     connect TimeOut (Sec)
            /// </summary>
            public double connectTimeoutMS;

            /// <summary>
            ///     fsync
            /// </summary>
            /// <remarks>
            ///     true: the driver adds { fsync : true } to the getlasterror command. Implies safe=true.
            ///     false: the driver does not not add fsync to the getlasterror command.
            /// </remarks>
            public bool fsync;

            /// <summary>
            ///     journal
            /// </summary>
            public bool journal;

            /// <summary>
            ///     Socket TimeOut (Sec)
            /// </summary>
            public double socketTimeoutMS;

            /// <summary>
            ///     wtimeoutMS
            /// </summary>
            /// <remarks>The driver adds { wtimeout : ms } to the getlasterror command. Implies safe=true.</remarks>
            public double wtimeoutMS;
        }
    }
}