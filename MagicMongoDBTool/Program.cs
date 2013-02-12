using System;
using System.IO;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using System.Diagnostics;
namespace MagicMongoDBTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            ///这句话如果写到后面去的话，在没有Config文件的时候，服务器树形列表显示不正确
            Application.EnableVisualStyles();

            FileVersionInfo info = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\MongoDB.Driver.dll");
            SystemManager.MongoDBDriverVersion = info.ProductVersion.ToString();

            info = FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\MongoDB.Bson.dll");
            SystemManager.MongoDBBsonVersion = info.ProductVersion.ToString();

            if (File.Exists(ConfigHelper._configFilename))
            {
                SystemManager.ConfigHelperInstance = ConfigHelper.LoadFromConfigFile(ConfigHelper._configFilename);
                SystemManager.InitLanguage();
            }
            else
            {
                SystemManager.ConfigHelperInstance = new ConfigHelper();
                frmLanguage _frmLanguage = new frmLanguage();
                _frmLanguage.ShowDialog();
                SystemManager.InitLanguage();
                frmOption _frmOption = new frmOption();
                _frmOption.ShowDialog();
                SystemManager.ConfigHelperInstance.SaveToConfigFile(ConfigHelper._configFilename);
            }
            SystemManager.DEBUG_MODE = true;
            SystemManager.MONO_MODE = Type.GetType("Mono.Runtime") != null;
            Application.Run(new frmMain());

            //delete tempfile directory when exit
            if (Directory.Exists(MongoDBHelper.TempFileFolder))
            {
                Directory.Delete(MongoDBHelper.TempFileFolder, true);
            }
        }
    }
}
