using System;
using System.Windows.Forms;

namespace MongoCola
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
            //这句话如果写到后面去的话，在没有Config文件的时候，服务器树形列表显示不正确
            Application.EnableVisualStyles();
            //初始化
            SystemManager.Init();
        }
    }
}