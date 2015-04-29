using Common;
using MongoUtility.Core;

namespace MongoCola.Config
{
    public static class ConfigHelper
    {
        /// <summary>
        ///     配置文件名称
        /// </summary>
        public static string ConfigFilename = "config.xml";

        /// <summary>
        ///     添加链接
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public static bool AddConnection(MongoConnectionConfig con)
        {
            SystemManager.MongoConfig.ConnectionList.Add(con.ConnectionName, con);
            return true;
        }

        /// <summary>
        ///     通过Host信息获得连接名称
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static string GetConnectionNameByHost(string addr, int port)
        {
            foreach (var item in SystemManager.MongoConfig.ConnectionList.Values)
            {
                if (item.Host == addr && item.Port == port)
                {
                    return item.ConnectionName;
                }
            }
            return string.Empty;
        }

        #region"读写配置"

        /// <summary>
        ///     写入配置
        /// </summary>
        public static void SaveToConfigFile()
        {
            SaveToConfigFile(ConfigFilename);
        }

        /// <summary>
        ///     写入配置
        /// </summary>
        /// <param name="configFileName"></param>
        public static void SaveToConfigFile(string configFileName)
        {
            SystemManager.MongoConfig.SerializableConnectionList.Clear();
            foreach (var item in SystemManager.MongoConfig.ConnectionList.Values)
            {
                SystemManager.MongoConfig.SerializableConnectionList.Add(item);
            }
            Utility.SaveObjAsXml(configFileName, SystemManager.SystemConfig);
        }

        /// <summary>
        ///     读取配置
        /// </summary>
        /// <param name="configFileName"></param>
        /// <returns></returns>
        public static void LoadFromConfigFile(string configFileName)
        {
            SystemManager.SystemConfig = Utility.LoadObjFromXml<SystemConfig>(configFileName);
            SystemManager.MongoConfig.ConnectionList.Clear();
            foreach (var item in SystemManager.MongoConfig.SerializableConnectionList)
            {
                SystemManager.MongoConfig.ConnectionList.Add(item.ConnectionName, item);
            }
            ConfigFilename = configFileName;
        }

        #endregion
    }
}