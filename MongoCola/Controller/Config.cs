/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/8
 * Time: 13:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MongoUtility.Core;

namespace MongoCola
{
	/// <summary>
	/// Description of Config.
	/// </summary>
	/// <summary>
	/// Config
	/// </summary>
	[Serializable]
	public class Config
	{
		/// <summary>
		///     连接配置列表(保存用）
		/// </summary>
		public List<MongoConnectionConfig> SaveConnectionList = new List<MongoConnectionConfig>();
		/// <summary>
		///     连接配置列表(管理用）
		/// </summary>
		[XmlIgnore] 
		public Dictionary<String, MongoConnectionConfig> ConnectionList =
			new Dictionary<String, MongoConnectionConfig>();
		#region"通用"
		/// <summary>
		///     MongoBin的路径，用于Dos命令
		/// </summary>
		public String MongoBinPath = String.Empty;
		/// <summary>
		///     Config Format Version
		/// </summary>
		public byte ConfigVer = 1;
		/// <summary>
		///     语言
		/// </summary>
		public String LanguageFileName = String.Empty;
		/// <summary>
		///     状态刷新间隔时间
		/// </summary>
		public  int RefreshStatusTimer = 30;
		#endregion
        
		#region"Default ReadWrite"
		/// <summary>
		///     ReadPreference
		/// </summary>
		public  String ReadPreference;
		/// <summary>
		///     WriteConcern
		/// </summary>
		public  String WriteConcern;
		/// <summary>
		///     WaitQueueSize;
		/// </summary>
		/// <remarks></remarks>
		public  int WaitQueueSize;
		/// <summary>
		///     wtimeoutMS
		/// </summary>
		/// <remarks>The driver adds { wtimeout : ms } to the getlasterror command. Implies safe=true.</remarks>
		public  double wtimeoutMS;
		#endregion
	}
}
