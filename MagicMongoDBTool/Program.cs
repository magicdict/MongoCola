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
                SystemManager.mConfig = ConfigHelper.LoadFromConfigFile("config.xml");
            }
            else
            {
                SystemManager.mConfig = new ConfigHelper();
                SystemManager.mConfig.SaveToConfigFile("config.xml");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
