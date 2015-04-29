using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Common;
using MongoCola.Config;
using MongoGUIView;
using MongoUtility.Basic;
using MongoUtility.Core;
using ResourceLib.Method;

namespace MongoCola
{
    public static class SystemManager
    {

        /// <summary>
        ///     配置
        /// </summary>
        public static SystemConfig SystemConfig = new SystemConfig();


        /// <summary>
        ///     版本号
        /// </summary>
        public static string Version = string.Empty;

        /// <summary>
        ///     测试模式
        /// </summary>
        public static bool DebugMode = false;

        /// <summary>
        ///     是否为MONO
        /// </summary>
        public static bool MonoMode = false;

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
            SystemManager.Version = Application.ProductVersion;
            SystemManager.DebugMode = false;
            SystemManager.MonoMode = Type.GetType("Mono.Runtime") != null;
            //异常处理器的初始化
            Utility.ExceptionAppendInfo = "MongoDbDriverVersion:" + MongoHelper.MongoDbDriverVersion +
                                          Environment.NewLine;
            Utility.ExceptionAppendInfo += "MongoDbBsonVersion:" + MongoHelper.MongoDbBsonVersion +
                                           Environment.NewLine;
            //config
            SystemConfig.AppPath = Application.StartupPath + "\\";
            MongoConfig.AppPath = Application.StartupPath + "\\";
            string localconfigfile = Application.StartupPath + "\\" + SystemConfig.SystemConfigFilename;
            if (File.Exists(localconfigfile))
            {
                SystemConfig.LoadFromConfigFile();
                InitLanguage();
                MongodbDosCommand.MongoBinPath = SystemManager.SystemConfig.MongoBinPath;
            }
            else
            {
                SystemManager.SystemConfig = new Config.SystemConfig();
                var frmLanguage = new FrmLanguage();
                frmLanguage.ShowDialog();
                InitLanguage();
                var frmOption = new FrmOption();
                frmOption.ShowDialog();
                SystemConfig.SaveSystemConfig();
            }
            localconfigfile = Application.StartupPath + "\\" + MongoConfig.MongoConfigFilename;
            if (File.Exists(localconfigfile))
            {
                MongoConfig.LoadFromConfigFile();
                RuntimeMongoDbContext.MongoConnectionConfigList = MongoConnectionConfig.MongoConfig.ConnectionList;
            }
            //各个子系统的多语言设定
            Configuration.RefreshStatusTimer = SystemManager.SystemConfig.RefreshStatusTimer;
            Application.Run(new FrmMain());
            //delete tempfile directory when exit
            if (Directory.Exists(Gfs.TempFileFolder))
            {
                Directory.Delete(Gfs.TempFileFolder, true);
            }
        }

        /// <summary>
        ///     初始化语言
        /// </summary>
        public static void InitLanguage()
        {
            GuiConfig.IsUseDefaultLanguage = SystemConfig.IsUseDefaultLanguage();
            //语言的初始化
            if (!SystemConfig.IsUseDefaultLanguage())
            {
                var languageFile = "Language" + Path.DirectorySeparatorChar + SystemConfig.LanguageFileName;
                if (File.Exists(languageFile))
                {
                    GuiConfig.MStringResource.InitLanguage(languageFile);
                }
            }
        }

    }
}