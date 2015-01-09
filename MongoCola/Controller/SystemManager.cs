using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System;
using System.IO;
using MongoCola.Module;
using MongoUtility.Basic;
using MongoUtility.Core;

namespace MongoCola
{
	public static class SystemManager
	{
		#region"通用"
		/// <summary>
		///     测试模式
		/// </summary>
		public static bool DebugMode = false;
		/// <summary>
		///     是否为MONO
		/// </summary>
		public static bool MonoMode = false;
		/// <summary>
		///     版本号
		/// </summary>
		public static string Version = Application.ProductVersion;
		/// <summary>
		/// 配置
		/// </summary>
		public static Config config = new Config();
		#endregion

		#region"多语言"
		public static ResourceLib.GUIConfig guiConfig = new ResourceLib.GUIConfig();
		/// <summary>
		///     是否使用默认语言
		/// </summary>
		/// <returns></returns>
		public static bool IsUseDefaultLanguage {
			get {
				if (config == null) {
					return true;
				}
				return (config.LanguageFileName == "English.xml" ||
				string.IsNullOrEmpty(config.LanguageFileName));
			}
		}
		/// <summary>
		///     初始化
		/// </summary>
		public static void InitLanguage()
		{
			guiConfig.IsUseDefaultLanguage = IsUseDefaultLanguage;
			//语言的初始化
			if (!IsUseDefaultLanguage) {
				string LanguageFile = "Language" + Path.DirectorySeparatorChar + config.LanguageFileName;
				if (File.Exists(LanguageFile)) {
					guiConfig.MStringResource.InitLanguage(LanguageFile);
				}
				Common.MyMessageBox.SwitchLanguage(guiConfig.MStringResource);
			}
			//TODO:各个子系统的多语言设定
			MongoGUICtl.configuration.guiConfig = guiConfig;
			MongoGUICtl.configuration.RefreshStatusTimer = config.RefreshStatusTimer;
			
			MongoGUIView.configuration.guiConfig = guiConfig;
		}
		
		#endregion
		
		/// <summary>
		/// 初始化
		/// </summary>
		public static void Init()
		{
			//MongoDB驱动版本的取得
			FileVersionInfo info = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\MongoDB.Driver.dll");
			MongoUtility.Basic.Utility.MongoDbDriverVersion = info.ProductVersion;
			info = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\MongoDB.Bson.dll");
			MongoUtility.Basic.Utility.MongoDbBsonVersion = info.ProductVersion;
			//异常处理器的初始化
			Common.Utility.ExceptionAppendInfo = "MongoDbDriverVersion:" + MongoUtility.Basic.Utility.MongoDbDriverVersion + System.Environment.NewLine;
			Common.Utility.ExceptionAppendInfo += "MongoDbBsonVersion:" + MongoUtility.Basic.Utility.MongoDbBsonVersion + System.Environment.NewLine;
			if (File.Exists(ConfigHelper._configFilename)) {
				ConfigHelper.LoadFromConfigFile(ConfigHelper._configFilename);
				SystemManager.InitLanguage();
			} else {
				SystemManager.config = new Config();
				var _frmLanguage = new frmLanguage();
				_frmLanguage.ShowDialog();
				SystemManager.InitLanguage();
				var _frmOption = new frmOption();
				_frmOption.ShowDialog();
				ConfigHelper.SaveToConfigFile(ConfigHelper._configFilename);
			}
			//设定MongoUtility
			RuntimeMongoDBContext._mongoConnectionConfigList = config.ConnectionList;
			
			//SystemManager.DEBUG_MODE = true;
			SystemManager.DebugMode = false;
			SystemManager.MonoMode = Type.GetType("Mono.Runtime") != null;
			Application.Run(new frmMain());
			//delete tempfile directory when exit
			if (Directory.Exists(MongoUtility.GFS.TempFileFolder)) {
				Directory.Delete(MongoUtility.GFS.TempFileFolder, true);
			}
		}
		
		#region "多文档视图管理"
		/// <summary>
		///     多文档视图管理
		/// </summary>
		public static Dictionary<string, MongoUtility.Aggregation.DataViewInfo> _viewInfoList =
			new Dictionary<string, MongoUtility.Aggregation.DataViewInfo>();
		/// <summary>
		///     多文档视图管理
		/// </summary>
		public static Dictionary<string, TabPage> _viewTabList = new Dictionary<string, TabPage>();
		#endregion

		
	}
}