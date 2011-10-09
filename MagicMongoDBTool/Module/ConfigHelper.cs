using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
namespace MagicMongoDBTool.Module
{
    [Serializable]
    public class ConfigHelper
    {
        /// <summary>
        /// 链接结构体
        /// </summary>
        public struct MongoConnectionConfig{
            public String HostName;
            public String IpAddr;
            public int Port;
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
        /// <param name="mHostName"></param>
        /// <param name="mIpAddr"></param>
        /// <param name="mPort"></param>
        /// <returns></returns>
        public Boolean AddConnection(MongoConnectionConfig mConnection) {
            ConnectionList.Add(mConnection.HostName, mConnection);
            return true;
        }
        /// <summary>
        /// MongoBin的路径，用于Dos命令
        /// </summary>
        public String MongoBinPath = String.Empty;
        /// <summary>
        /// 
        /// </summary>
        public int LimitCnt = 100;
        /// <summary>
        /// 配置文件名称
        /// </summary>
        static private String ConfigFilename = "config.xml"; 
        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="ConfigFilename"></param>
        /// <returns></returns>
        public static ConfigHelper LoadFromConfigFile(String mConfigFilename)
        {
            FileStream fs = null;
            fs = new FileStream(mConfigFilename, FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(ConfigHelper));
            ConfigHelper t = (ConfigHelper)xs.Deserialize(fs);
            foreach (MongoConnectionConfig item in t.SaveConnectionList)
            {
                t.ConnectionList.Add(item.HostName, item);
            }
            fs.Close();
            ConfigFilename = mConfigFilename;
            return t;
        }
        /// <summary>
        /// 写入配置
        /// </summary>
        public void SaveToConfigFile() {
            SaveToConfigFile(ConfigFilename);
        }
        /// <summary>
        /// 写入配置
        /// </summary>
        /// <param name="ConfigFilename"></param>
        public void SaveToConfigFile(String mConfigFilename)
        {
            FileStream fs = null;
            XmlSerializer xs = new XmlSerializer(typeof(ConfigHelper));

            SaveConnectionList.Clear();
            foreach (MongoConnectionConfig item in ConnectionList.Values)
            {
                SaveConnectionList.Add(item);
            }
            fs = new FileStream(mConfigFilename, FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, this);
            fs.Close();
        }
    }
}
