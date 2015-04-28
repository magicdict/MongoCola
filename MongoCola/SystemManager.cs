using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Common;
using MongoCola.Config;
using MongoGUIView;
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
            MongoHelper.MongoDbDriverVersion = info.ProductVersion;
            info = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\MongoDB.Bson.dll");
            MongoHelper.MongoDbBsonVersion = info.ProductVersion;
            //版本设定
            SystemConfig.Version = Application.ProductVersion;
            SystemConfig.DebugMode = false;
            SystemConfig.MonoMode = Type.GetType("Mono.Runtime") != null;
            //异常处理器的初始化
            Utility.ExceptionAppendInfo = "MongoDbDriverVersion:" + MongoHelper.MongoDbDriverVersion +
                                          Environment.NewLine;
            Utility.ExceptionAppendInfo += "MongoDbBsonVersion:" + MongoHelper.MongoDbBsonVersion +
                                           Environment.NewLine;
            //config
            var localconfigfile = Application.StartupPath + "\\" + ConfigHelper.ConfigFilename;
            if (File.Exists(localconfigfile))
            {
                ConfigHelper.LoadFromConfigFile(localconfigfile);
                SystemConfig.InitLanguage();
                MongodbDosCommand.MongoBinPath = SystemConfig.Config.MongoBinPath;
            }
            else
            {
                SystemConfig.Config = new Config.Config();
                var frmLanguage = new FrmLanguage();
                frmLanguage.ShowDialog();
                SystemConfig.InitLanguage();
                var frmOption = new FrmOption();
                frmOption.ShowDialog();
                ConfigHelper.SaveToConfigFile(localconfigfile);
            }
            //设定MongoUtility
            RuntimeMongoDbContext.MongoConnectionConfigList = SystemConfig.Config.ConnectionList;
            //各个子系统的多语言设定
            Configuration.RefreshStatusTimer = SystemConfig.Config.RefreshStatusTimer;
            Application.Run(new FrmMain());
            //delete tempfile directory when exit
            if (Directory.Exists(Gfs.TempFileFolder))
            {
                Directory.Delete(Gfs.TempFileFolder, true);
            }
        }
    }
}