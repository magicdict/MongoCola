using System;
using System.Windows.Forms;
using ResourceLib.Utility;

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
            GetSystemIcon.InitMainTreeImage();
            Application.Run(new frmConsole());
        }
    }
}