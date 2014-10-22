using System;
using System.Windows.Forms;
using MongoCola.Module;

namespace HTTPServer
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            SystemManager.ConfigHelperInstance = ConfigHelper.LoadFromConfigFile(ConfigHelper._configFilename);
            GetSystemIcon.InitMainTreeImage();
            Application.Run(new Console());
        }
    }
}