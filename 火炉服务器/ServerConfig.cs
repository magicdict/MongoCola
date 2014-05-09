using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 火炉服务器
{
    public partial class ServerConfig : Form
    {
        public ServerConfig()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 启动服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            HTTPServer.Start();
        }
    }
}
