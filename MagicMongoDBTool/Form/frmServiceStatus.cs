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
            Timer refreshTimer = new Timer();
            refreshTimer.Interval = SystemManager.ConfigHelperInstance.RefreshStatusTimer * 1000;
            refreshTimer.Tick += new EventHandler((x, y) =>
            {
                MongoDBHelpler.FillSrvStatusToList(this.lstSrvStatus);
                MongoDBHelpler.FillSrvOprToList(this.lstSrvOpr);
                MongoDBHelpler.FillDBStatusToList(this.lstDBStatus);
            });
            refreshTimer.Enabled = true;
            MongoDBHelpler.FillSrvStatusToList(this.lstSrvStatus);
            MongoDBHelpler.FillSrvOprToList(this.lstSrvOpr);
            MongoDBHelpler.FillDBStatusToList(this.lstDBStatus);
        }
        /// <summary>
        /// 立刻刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.FillSrvStatusToList(this.lstSrvStatus);
            MongoDBHelpler.FillSrvOprToList(this.lstSrvOpr);
            MongoDBHelpler.FillDBStatusToList(this.lstDBStatus);
        }


    }
}
