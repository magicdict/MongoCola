using System;
using Common.Logic;
using MongoUtility.Core;

namespace SystemUtility.Config
{
    public static class ConfigHelper
    {
        /// <summary>
        ///     配置文件名称
        /// </summary>
        public static String _configFilename = "config.xml";

        /// <summary>
        ///     添加链接
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public static Boolean AddConnection(MongoConnectionConfig con)
        {
            SystemConfig.config.ConnectionList.Add(con.ConnectionName, con);
            return true;
        }

        /// <summary>
        ///     通过Host信息获得连接名称
        /// </summary>
        /// <param name="Addr"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static String GetConnectionNameByHost(String Addr, int port)
        {
            foreach (var item in SystemConfig.config.ConnectionList.Values)
            {
                if (item.Host == Addr && item.Port == port)
                {
                    return item.ConnectionName;
                }
            }
            return String.Empty;
        }

        #region"读写配置"

        /// <summary>
        ///     写入配置
        /// </summary>
        public static void SaveToConfigFile()
        {
            SaveToConfigFile(_configFilename);
        }

        /// <summary>
        ///     写入配置
        /// </summary>
        /// <param name="configFileName"></param>
        public static void SaveToConfigFile(String configFileName)
        {
            SystemConfig.config.SerializableConnectionList.Clear();
            foreach (var item in SystemConfig.config.ConnectionList.Values)
            {
                SystemConfig.config.SerializableConnectionList.Add(item);
            }
            Utility.SaveObjAsXml(configFileName, SystemConfig.config);
        }

        /// <summary>
        ///     读取配置
        /// </summary>
        /// <param name="configFileName"></param>
        /// <returns></returns>
        public static void LoadFromConfigFile(String configFileName)
        {
            SystemConfig.config = Utility.LoadObjFromXml<Config>(configFileName);
            SystemConfig.config.ConnectionList.Clear();
            foreach (var item in SystemConfig.config.SerializableConnectionList)
            {
                SystemConfig.config.ConnectionList.Add(item.ConnectionName, item);
            }
            _configFilename = configFileName;
        }

        #endregion
    }
}