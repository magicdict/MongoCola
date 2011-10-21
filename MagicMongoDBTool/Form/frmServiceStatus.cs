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
    public partial class frmServiceStatus : frmBase
    {
        public frmServiceStatus()
        {
            InitializeComponent();
        }

        private void frmServiceStatus_Load(object sender, EventArgs e)
        {
            Timer RefreshTimer = new Timer();
            RefreshTimer.Interval = SystemManager.mConfig.RefreshStatusTimer * 1000;
            RefreshTimer.Tick += new EventHandler((x, y) => {
                MongoDBHelpler.FillSrvStatusToList(this.lstSrvStatus);
                MongoDBHelpler.FillSrvOprToList(this.lstSrvOpr);
            });
            RefreshTimer.Enabled = true;
            MongoDBHelpler.FillSrvStatusToList(this.lstSrvStatus);
            MongoDBHelpler.FillSrvOprToList(this.lstSrvOpr);
        }
    }
}
