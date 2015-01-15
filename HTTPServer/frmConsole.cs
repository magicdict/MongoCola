using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using SystemUtility.Config;

namespace HTTPServer
{
    public partial class frmConsole : Form
    {
        public frmConsole()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Console_Load(object sender, EventArgs e)
        {
            //TEST START
            ServerPathPicker.SelectedPathOrFileName = @"C:\MongoCola\TemplatePackage\HTML";
            ConfigFile.SelectedPathOrFileName = @"C:\MongoCola\MongoCola\bin\Debug\config.xml";
            //TEST END
            CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="Message"></param>
        private void Write(String Info, byte Message)
        {
            txtInfo.Text += Info + Environment.NewLine;
        }

        /// <summary>
        ///     Entry Of MongoCola@Browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkWebFormEntry_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //加载Config
            ConfigHelper.LoadFromConfigFile(ConfigFile.SelectedPathOrFileName);
            HTTPServer.ServerPath = ServerPathPicker.SelectedPathOrFileName;
            var svr = new HTTPServer();
            svr.LogInfo += (x, y) =>
            {
                if (txtInfo.InvokeRequired)
                {
                    WriteInfo t = Write;
                    var o = new object[2] {y.Info, y.Level};
                    Invoke(t, o);
                }
                Write(y.Info, y.Level);
            };
            var q = new Thread(svr.Start);
            q.Start();
            Process.Start("http://localhost:13000/");
        }

        /// <summary>
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="Message"></param>
        private delegate void WriteInfo(String Info, byte Message);
    }
}