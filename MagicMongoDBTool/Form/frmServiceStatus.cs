using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class frmServiceStatus : Form
    {
        public frmServiceStatus()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 常规刷新
        /// </summary>
        Timer refreshTimer = new Timer();
        /// <summary>
        /// 短时间刷新
        /// </summary>
        Timer ShortTimer = new Timer();

        private void frmServiceStatus_Load(object sender, EventArgs e)
        {
            refreshTimer.Interval = SystemManager.ConfigHelperInstance.RefreshStatusTimer * 1000;
            refreshTimer.Tick += new EventHandler(
                (x, y) =>
                {
                //防止在查看树形状态的时候被打扰
                this.ServerStatusCtl.RefreshStatus(true);
                }
            );

            ShortTimer.Interval = 1000;
            ShortTimer.Tick +=new EventHandler(                
                (x, y) =>
                {
                //防止在查看树形状态的时候被打扰
                this.ServerStatusCtl.RefreshCurrentOpr();
                }
            );
            
            if (!SystemManager.IsUseDefaultLanguage())
            {
                this.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.ServiceStatus_Title);
                cmdRefresh.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Refresh);
            }
            refreshTimer.Enabled = true;
            ShortTimer.Enabled = true;
        }
        /// <summary>
        /// 立刻刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            this.ServerStatusCtl.RefreshStatus(false);
            this.ServerStatusCtl.RefreshCurrentOpr();
        }
        /// <summary>
        /// Timer停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmServiceStatus_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            refreshTimer.Stop();
            ShortTimer.Stop();
        }
    }
}
