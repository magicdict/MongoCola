using System;
using MongoDB.Driver;
using MongoUtility.Core;

namespace MongoCola
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
			SystemManager.config.SaveConnectionList.Clear();
			foreach (MongoConnectionConfig item in SystemManager.config.ConnectionList.Values) {
				SystemManager.config.SaveConnectionList.Add(item);
			}
			Common.Utility.SaveObjAsXml(configFileName,SystemManager.config);
		}
		/// <summary>
		///     读取配置
		/// </summary>
		/// <param name="configFileName"></param>
		/// <returns></returns>
		public static void  LoadFromConfigFile(String configFileName)
		{
			SystemManager.config = Common.Utility.LoadObjFromXml<Config>(configFileName);
			SystemManager.config.SaveConnectionList.Clear();
			foreach (MongoConnectionConfig item in SystemManager.config.SaveConnectionList) {
				SystemManager.config.ConnectionList.Add(item.ConnectionName, item);
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
			SystemManager.config.ConnectionList.Add(con.ConnectionName, con);
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
			foreach (MongoConnectionConfig item in SystemManager.config.ConnectionList.Values) {
				if (item.Host == Addr && item.Port == port) {
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
		public static MongoServerAddress GetMongoSvrAddrByConnectionName(String ConnectionName)
		{
			MongoServerAddress mongosrvAddr = null;
			if (SystemManager.config.ConnectionList.ContainsKey(ConnectionName)) {
				mongosrvAddr = new MongoServerAddress(SystemManager.config.ConnectionList[ConnectionName].Host,
					SystemManager.config.ConnectionList[ConnectionName].Port);
			}
			return mongosrvAddr;
		}
	}
}