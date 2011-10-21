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
    public partial class frmDataBaseStatus : frmBase
    {
        public frmDataBaseStatus()
        {
            InitializeComponent();
        }

        private void frmDataBaseStatus_Load(object sender, EventArgs e)
        {
            Timer RefreshTimer = new Timer();
            RefreshTimer.Interval = SystemManager.mConfig.RefreshStatusTimer * 1000;
            RefreshTimer.Tick += new EventHandler((x, y) => { MongoDBHelpler.FillDBStatusToList(this.lstDBStatus); });
            RefreshTimer.Enabled = true;
            MongoDBHelpler.FillDBStatusToList(this.lstDBStatus);
        }
    }
}
