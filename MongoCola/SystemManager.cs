using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using SystemUtility;
using SystemUtility.Config;
using MongoGUICtl;
using MongoUtility.Basic;
using MongoUtility.Core;

namespace MongoCola
{
    public static class SystemManager
    {
        /// <summary>
        ///     初始化
        /// </summary>
        public static void Init()
        {
            //MongoDB驱动版本的取得
            var info = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\MongoDB.Driver.dll");
            Utility.MongoDbDriverVersion = info.ProductVersion;
            info = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\MongoDB.Bson.dll");
            Utility.MongoDbBsonVersion = info.ProductVersion;
            //版本设定
            SystemConfig.Version = Application.ProductVersion;
            SystemConfig.DebugMode = false;
            SystemConfig.MonoMode = Type.GetType("Mono.Runtime") != null;
            //异常处理器的初始化
            Common.Logic.Utility.ExceptionAppendInfo = "MongoDbDriverVersion:" + Utility.MongoDbDriverVersion +
                                                         Environment.NewLine;
            Common.Logic.Utility.ExceptionAppendInfo += "MongoDbBsonVersion:" + Utility.MongoDbBsonVersion +
                                                          Environment.NewLine;
            //config
            var localconfigfile = Application.StartupPath + "\\" + ConfigHelper._configFilename;
            if (File.Exists(localconfigfile))
            {
                ConfigHelper.LoadFromConfigFile(localconfigfile);
                SystemConfig.InitLanguage();
            }
            else
            {
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
            MongoGUIView.configuration.RefreshStatusTimer = SystemConfig.config.RefreshStatusTimer;
            MongoGUIView.configuration.guiConfig = SystemConfig.guiConfig;
            Application.Run(new frmMain());
            //delete tempfile directory when exit
            if (Directory.Exists(GFS.TempFileFolder))
            {
                Directory.Delete(GFS.TempFileFolder, true);
            }
        }
    }
}