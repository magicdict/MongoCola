using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Common;
using MongoCola.Config;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.ToolKit;
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
        public static bool DebugMode;

        /// <summary>
        ///     是否为MONO
        /// </summary>
        public static bool MonoMode;

        /// <summary>
        ///     OSVersion
        /// </summary>
        public static string OsVersion = Environment.OSVersion.ToString();

        /// <summary>
        ///     初始化
        /// </summary>
        public static void Init()
        {
            //MongoDB驱动版本的取得
            Debug.Print(Path.DirectorySeparatorChar.ToString());
            var info =
                FileVersionInfo.GetVersionInfo(Application.StartupPath + Path.DirectorySeparatorChar +
                                               "MongoDB.Driver.dll");
            MongoHelper.MongoDbDriverVersion = info.ProductVersion;
            info =
                FileVersionInfo.GetVersionInfo(Application.StartupPath + Path.DirectorySeparatorChar +
                                               "MongoDB.Bson.dll");
            MongoHelper.MongoDbBsonVersion = info.ProductVersion;
            //版本设定
            Version = Application.ProductVersion;
            DebugMode = false;
            MonoMode = Type.GetType("Mono.Runtime") != null;
            GuiConfig.IsMono = MonoMode;
            //Can't know for OSVersion to diff Mac or Unix....
            //异常处理器的初始化
            Utility.ExceptionAppendInfo = "MongoDbDriverVersion:" + MongoHelper.MongoDbDriverVersion +
                                          Environment.NewLine;
            Utility.ExceptionAppendInfo += "MongoDbBsonVersion:" + MongoHelper.MongoDbBsonVersion +
                                           Environment.NewLine;
            //config
            SystemConfig.AppPath = Application.StartupPath + Path.DirectorySeparatorChar;
            MongoConfig.AppPath = Application.StartupPath + Path.DirectorySeparatorChar;
            var localconfigfile = Application.StartupPath + Path.DirectorySeparatorChar +
                                  SystemConfig.SystemConfigFilename;
            if (File.Exists(localconfigfile))
            {
                SystemConfig.LoadFromConfigFile();
                InitLanguage();
                MongodbDosCommand.MongoBinPath = SystemConfig.MongoBinPath;
            }
            else
            {
                SystemConfig = new SystemConfig();
                var frmLanguage = new FrmLanguage();
                frmLanguage.ShowDialog();
                InitLanguage();
                var frmOption = new FrmOption();
                frmOption.ShowDialog();
                SystemConfig.SaveSystemConfig();
            }
            localconfigfile = Application.StartupPath + Path.DirectorySeparatorChar + MongoConfig.MongoConfigFilename;
            if (File.Exists(localconfigfile))
            {
                MongoConfig.LoadFromConfigFile();
                RuntimeMongoDbContext.MongoConnectionConfigList = MongoConnectionConfig.MongoConfig.ConnectionList;
            }
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
                var languageFile = SystemConfig.AppPath + "Language" + Path.DirectorySeparatorChar +
                                   SystemConfig.LanguageFileName;
                if (File.Exists(languageFile))
                {
                    StringResource.InitLanguage(languageFile);
                }
            }
        }
    }
}