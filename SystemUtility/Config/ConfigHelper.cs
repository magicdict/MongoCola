using System;
using MongoUtility.Core;

namespace SystemUtility
{

	public static class ConfigHelper
	{
		/// <summary>
		///     配置文件名称
		/// </summary>
		public static String _configFilename = "config.xml";
		#region"读写配置"
		/// <summary>
		///     写入配置
		/// </summary>
		public static void SaveToConfigFile()
		{
			SaveToConfigFile(ConfigHelper._configFilename);
		}
		/// <summary>
		///     写入配置
		/// </summary>
		/// <param name="configFileName"></param>
		public static void SaveToConfigFile(String configFileName)
		{
			SystemConfig.config.SerializableConnectionList.Clear();
			foreach (MongoConnectionConfig item in SystemConfig.config.ConnectionList.Values) {
				SystemConfig.config.SerializableConnectionList.Add(item);
			}
			Common.Utility.SaveObjAsXml(configFileName,SystemConfig.config);
		}
		/// <summary>
		///     读取配置
		/// </summary>
		/// <param name="configFileName"></param>
		/// <returns></returns>
		public static void  LoadFromConfigFile(String configFileName)
		{
			SystemConfig.config = Common.Utility.LoadObjFromXml<Config>(configFileName);
			SystemConfig.config.ConnectionList.Clear();
			foreach (MongoConnectionConfig item in SystemConfig.config.SerializableConnectionList) {
				SystemConfig.config.ConnectionList.Add(item.ConnectionName, item);
			}
			ConfigHelper._configFilename = configFileName;
		}
		#endregion
        
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
			foreach (MongoConnectionConfig item in SystemConfig.config.ConnectionList.Values) {
				if (item.Host == Addr && item.Port == port) {
					return item.ConnectionName;
				}
			}
			return String.Empty;
		}

	}
}