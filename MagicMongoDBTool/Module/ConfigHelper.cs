using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
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
        //连接配置列表
        public List<MongoConnectionConfig> MongoConnectionlst = new List<MongoConnectionConfig>();
        /// <summary>
        /// 添加链接
        /// </summary>
        /// <param name="mHostName"></param>
        /// <param name="mIpAddr"></param>
        /// <param name="mPort"></param>
        /// <returns></returns>
        public Boolean AddConnection(String mHostName, String mIpAddr, int mPort) {
            MongoConnectionConfig m = new MongoConnectionConfig();
            m.HostName = mHostName;
            m.IpAddr = mIpAddr;
            m.Port = mPort;
            MongoConnectionlst.Add(m);
            return true;
        }
        /// <summary>
        /// MongoBin的路径，用于Dos命令
        /// </summary>
        public String MongoBinPath = String.Empty;

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="ConfigFilename"></param>
        /// <returns></returns>
        public static ConfigHelper LoadFromConfigFile(String ConfigFilename) {
            FileStream fs = null;
            fs = new FileStream(ConfigFilename, FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(ConfigHelper));
            ConfigHelper t = (ConfigHelper)xs.Deserialize(fs);
            fs.Close();
            return t;
        }
        /// <summary>
        /// 写入配置
        /// </summary>
        /// <param name="ConfigFilename"></param>
        public void SaveToConfigFile(String ConfigFilename)
        {
            FileStream fs = null;
            XmlSerializer xs = new XmlSerializer(typeof(ConfigHelper));
            fs = new FileStream(ConfigFilename, FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, this);
            fs.Close();
        }
    }
}
