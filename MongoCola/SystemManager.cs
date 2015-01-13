using System.Diagnostics;
using System.Windows.Forms;
using System;
using System.IO;
using MongoUtility.Core;
using SystemUtility;

namespace MongoCola
{
	public static class SystemManager
	{
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
			//版本设定
			SystemConfig.Version = Application.ProductVersion;
			SystemConfig.DebugMode = false;
			SystemConfig.MonoMode = Type.GetType("Mono.Runtime") != null;
			//异常处理器的初始化
			Common.Utility.ExceptionAppendInfo = "MongoDbDriverVersion:" + MongoUtility.Basic.Utility.MongoDbDriverVersion + System.Environment.NewLine;
			Common.Utility.ExceptionAppendInfo += "MongoDbBsonVersion:" + MongoUtility.Basic.Utility.MongoDbBsonVersion + System.Environment.NewLine;
			//config
			var localconfigfile = Application.StartupPath + "\\" + ConfigHelper._configFilename;
			if (File.Exists(localconfigfile)) {
				ConfigHelper.LoadFromConfigFile(localconfigfile);
				SystemConfig.InitLanguage();
			} else {
				SystemConfig.config = new Config();
				var _frmLanguage = new frmLanguage();
				_frmLanguage.ShowDialog();
				SystemConfig.InitLanguage();
				var _frmOption = new frmOption();
				_frmOption.ShowDialog();
				ConfigHelper.SaveToConfigFile(localconfigfile);
			}
			//设定MongoUtility
			RuntimeMongoDBContext._mongoConnectionConfigList = SystemConfig.config.ConnectionList;
			//各个子系统的多语言设定
			MongoGUICtl.configuration.guiConfig = SystemConfig.guiConfig;
			MongoGUICtl.configuration.RefreshStatusTimer = SystemConfig.config.RefreshStatusTimer;
			MongoGUIView.configuration.guiConfig = SystemConfig.guiConfig;
			Application.Run(new frmMain());
			//delete tempfile directory when exit
			if (Directory.Exists(MongoUtility.GFS.TempFileFolder)) {
				Directory.Delete(MongoUtility.GFS.TempFileFolder, true);
			}
		}
		
	}
}