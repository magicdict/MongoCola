using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmAddConnection : frmBase
    {
        public frmAddConnection()
        {
            InitializeComponent();
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //仅仅将链接参数放入配置文件中，这里并不实际获得服务器实例
            SystemManager.mConfig.AddConnection(txtHostName.Text, txtIpAddr.Text, Convert.ToInt32( txtPort.Text));
            this.Close();
        }
    }
}
