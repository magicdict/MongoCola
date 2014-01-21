using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            ///这句话如果写到后面去的话，在没有Config文件的时候，服务器树形列表显示不正确
            Application.EnableVisualStyles();

            FileVersionInfo info = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\MongoDB.Driver.dll");
            SystemManager.MongoDbDriverVersion = info.ProductVersion;

            info = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\MongoDB.Bson.dll");
            SystemManager.MongoDbBsonVersion = info.ProductVersion;

            if (File.Exists(ConfigHelper._configFilename))
            {
                SystemManager.ConfigHelperInstance = ConfigHelper.LoadFromConfigFile(ConfigHelper._configFilename);
                SystemManager.InitLanguage();
            }
            else
            {
                SystemManager.ConfigHelperInstance = new ConfigHelper();
                var _frmLanguage = new frmLanguage();
                _frmLanguage.ShowDialog();
                SystemManager.InitLanguage();
                var _frmOption = new frmOption();
                _frmOption.ShowDialog();
                SystemManager.ConfigHelperInstance.SaveToConfigFile(ConfigHelper._configFilename);
            }
            //SystemManager.DEBUG_MODE = true;
            SystemManager.DebugMode = false;
            SystemManager.MonoMode = Type.GetType("Mono.Runtime") != null;
            Application.Run(new frmMain());
            //Application.Run(new frmServerMonitor());  
            //delete tempfile directory when exit
            if (Directory.Exists(MongoDbHelper.TempFileFolder))
            {
                Directory.Delete(MongoDbHelper.TempFileFolder, true);
            }
        }
    }
}