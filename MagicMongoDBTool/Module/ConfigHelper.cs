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
        /// 服务器类型
        /// </summary>
        public enum SvrType
        {
            /// <summary>
            /// 数据服务器[mongod]
            /// </summary>
            DataSvr,
            /// <summary>
            /// 配置服务器[mongod]
            /// </summary>
            ConfigSvr,
            /// <summary>
            /// 路由服务器[mongos]
            /// </summary>
            RouteSvr,
            /// <summary>
            /// 副本服务器[Virtul]
            /// </summary>
            ReplsetSvr,
            /// <summary>
            /// 仲裁服务器[mongod --replset,without data]
            /// </summary>
            ArbiterSvr,
            /// <summary>
            /// Master主服务器
            /// </summary>
            Master,
            /// <summary>
            /// Slave从属服务器
            /// </summary>
            Slave
        }
        /// <summary>
        /// 链接结构体
        /// </summary>
        public struct MongoConnectionConfig
        {
            /// <summary>
            /// 连接名称
            /// </summary>
            public string ConnectionName;
            /// <summary>
            /// 连接字符串
            /// </summary>
            public String ConnectionString;
            /// <summary>
            /// IP地址
            /// </summary>
            public string Host;
            /// <summary>
            /// 端口号
            /// </summary>
            public int Port;
            /// <summary>
            /// 主副本名称
            /// </summary>
            public String MainReplSetName;
            /// <summary>
            /// 是否启用主从模式[Route的时候，不能设置为True]
            /// </summary>
            public bool IsSlaveOk;
            /// <summary>
            /// 是否为安全模式
            /// </summary>
            public bool IsSafeMode;
            /// <summary>
            /// 作为Admin登陆
            /// </summary>
            public bool LoginAsAdmin;
            /// <summary>
            /// 用户名
            /// </summary>
            public string UserName;
            /// <summary>
            /// 密码
            /// </summary>
            public string Password;
            /// <summary>
            /// 只读[这个属性是运行时决定的]
            /// </summary>
            [XmlIgnore()]
            public Boolean IsReadOnly;
            /// <summary>
            /// 认证模式[这个属性是运行时决定的]
            /// </summary>
            [XmlIgnore()]
            public Boolean AuthMode;
            /// <summary>
            /// 服务器类型
            /// </summary>
            public SvrType ServerType;
            /// <summary>
            /// 副本名称
            /// </summary>
            public string ReplSetName;
            /// <summary>
            /// 数据库名称
            /// </summary>
            public string DataBaseName;
            /// <summary>
            /// 副本服务器列表
            /// </summary>
            public List<String> ReplsetList;
            /// <summary>
            /// 副本主机裁决优先度
            /// </summary>
            public int Priority;
            /// <summary>
            /// 超时
            /// </summary>
            public int TimeOut;
        }
        /// <summary>
        /// 通过Host信息获得连接名称
        /// </summary>
        /// <param name="Addr"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public String GetCollectionNameByHost(String Addr, int port)
        {
            foreach (var item in ConnectionList.Values)
            {
                if (item.Host == Addr && item.Port == port)
                {
                    return item.ConnectionName;
                }
            }
            return String.Empty;
        }
        /// <summary>
        /// 通过连接名称获得Host信息
        /// </summary>
        /// <param name="ConnectionName"></param>
        /// <returns></returns>
        public MongoServerAddress GetMongoSvrAddrByConnectionName(String ConnectionName)
        {
            MongoServerAddress mongosrvAddr = null;
            if (ConnectionList.ContainsKey(ConnectionName))
            {
                mongosrvAddr = new MongoServerAddress(ConnectionList[ConnectionName].Host, ConnectionList[ConnectionName].Port);
            }
            return mongosrvAddr;
        }
        /// <summary>
        /// 连接配置列表(管理用）
        /// </summary>
        [XmlIgnore]
        public Dictionary<String, MongoConnectionConfig> ConnectionList = new Dictionary<String, MongoConnectionConfig>();
        /// <summary>
        /// 连接配置列表(保存用）
        /// </summary>
        public List<MongoConnectionConfig> SaveConnectionList = new List<MongoConnectionConfig>();
        /// <summary>
        /// 添加链接
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public Boolean AddConnection(MongoConnectionConfig con)
        {
            ConnectionList.Add(con.ConnectionName, con);
            return true;
        }
        /// <summary>
        /// MongoBin的路径，用于Dos命令
        /// </summary>
        public string MongoBinPath = string.Empty;
        /// <summary>
        /// 每页显示数
        /// </summary>
        public int LimitCnt = 100;
        /// <summary>
        /// 状态刷新间隔时间
        /// </summary>
        public int RefreshStatusTimer = 30;
        /// <summary>
        /// 语言
        /// </summary>
        public String LanguageFileName = String.Empty;
        /// <summary>
        /// 皮肤目录
        /// </summary>
        public String SkipFolder = "";
        /// <summary>
        /// 配置文件名称
        /// </summary>
        private static string _configFilename = "config.xml";
        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="configFileName"></param>
        /// <returns></returns>
        public static ConfigHelper LoadFromConfigFile(string configFileName)
        {
            FileStream fs = new FileStream(configFileName, FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(ConfigHelper));
            ConfigHelper t = (ConfigHelper)xs.Deserialize(fs);
            foreach (MongoConnectionConfig item in t.SaveConnectionList)
            {
                t.ConnectionList.Add(item.ConnectionName, item);
            }
            fs.Close();
            _configFilename = configFileName;
            return t;
        }
        /// <summary>
        /// 写入配置
        /// </summary>
        public void SaveToConfigFile()
        {
            SaveToConfigFile(_configFilename);
        }
        /// <summary>
        /// 写入配置
        /// </summary>
        /// <param name="configFileName"></param>
        public void SaveToConfigFile(string configFileName)
        {
            FileStream fs = null;
            XmlSerializer xs = new XmlSerializer(typeof(ConfigHelper));

            SaveConnectionList.Clear();
            foreach (MongoConnectionConfig item in ConnectionList.Values)
            {
                SaveConnectionList.Add(item);
            }
            fs = new FileStream(configFileName, FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, this);
            fs.Close();
        }
    }
}
