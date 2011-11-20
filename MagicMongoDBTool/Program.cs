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
            if (File.Exists("config.xml"))
            {
                SystemManager.ConfigHelperInstance = ConfigHelper.LoadFromConfigFile("config.xml");
            }
            else
            {
                SystemManager.ConfigHelperInstance = new ConfigHelper();
                SystemManager.ConfigHelperInstance.SaveToConfigFile("config.xml");
            }
            SystemManager.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
