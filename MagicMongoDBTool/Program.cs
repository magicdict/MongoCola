using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using System.IO;
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
            if (File.Exists("config.xml"))
            {
                SystemManager.ConfigHelperInstance = ConfigHelper.LoadFromConfigFile("config.xml");
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
                SystemManager.ConfigHelperInstance.SaveToConfigFile("config.xml");
            }
            //SystemManager.DEBUG_MODE = true;
            SystemManager.MONO_MODE = Type.GetType("Mono.Runtime") != null;
            Application.EnableVisualStyles();
            Application.Run(new frmMain());

            //delete tempfile directory when exit
            if (Directory.Exists("TempFile"))
            {
                Directory.Delete("TempFile",true);
            }
        }
    }
}
