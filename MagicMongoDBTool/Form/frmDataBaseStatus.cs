using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class frmDataBaseStatus : QLFUI.QLFForm
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
