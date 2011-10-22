using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class frmServiceStatus : QLFUI.QLFForm
    {
        public frmServiceStatus()
        {
            InitializeComponent();
        }

        private void frmServiceStatus_Load(object sender, EventArgs e)
        {
            Timer RefreshTimer = new Timer();
            RefreshTimer.Interval = SystemManager.mConfig.RefreshStatusTimer * 1000;
            RefreshTimer.Tick += new EventHandler((x, y) =>
            {
                MongoDBHelpler.FillSrvStatusToList(this.lstSrvStatus);
                MongoDBHelpler.FillSrvOprToList(this.lstSrvOpr);
            });
            RefreshTimer.Enabled = true;
            MongoDBHelpler.FillSrvStatusToList(this.lstSrvStatus);
            MongoDBHelpler.FillSrvOprToList(this.lstSrvOpr);
        }


    }
}
