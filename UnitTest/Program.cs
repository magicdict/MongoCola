using System;
using System.Windows.Forms;
using UnitTest.Lagacy;

namespace UnitTest
{
    internal static class Program
    {
        /// <summary>
        ///     应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SystemManager.Init();
            //Application.Run(new CardUnit());
            Application.Run(new UserRoleTest());
            //Application.Run(new frmUnitTest());
        }
    }
}