using System;
using System.Windows.Forms;
using Common;
using MongoGUICtl;
using MongoGUICtl.ClientTree;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.Properties;

namespace MongoGUIView
{
    public partial class CtlServerStatus : UserControl
    {
        /// <summary>
        ///     常规刷新
        /// </summary>
        private readonly Timer _refreshTimer = new Timer();

        /// <summary>
        ///     短时间刷新
        /// </summary>
        private readonly Timer _shortTimer = new Timer();

        /// <summary>
        ///     Auto Refresh Flag
        /// </summary>
        private bool _autoRefresh = true;

        public CtlServerStatus()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     关闭Tab事件
        /// </summary>
        public event EventHandler CloseTab;

        /// <summary>
        ///     刷新状态，不包含当前操作状态
        /// </summary>
        /// <param name="isAuto">是否自动刷新</param>
        public void RefreshStatus(bool isAuto)
        {
            try
            {
                if (!isAuto)
                {
                    //手动刷新
                    FillMongoDb.FillClientStatusToList(trvSvrStatus, RuntimeMongoDbContext.MongoConnClientLst);
                }
                FillMongoDb.FillDataBaseStatusToList(trvDBStatus, RuntimeMongoDbContext.MongoConnSvrLst);
                FillMongoDb.FillCollectionStatusToList(trvColStatus, RuntimeMongoDbContext.MongoConnSvrLst);
            }
            catch (Exception ex)
            {
                _refreshTimer.Stop();
                _shortTimer.Stop();
                btnSwitch.Text = !GuiConfig.IsUseDefaultLanguage
                    ? GuiConfig.GetText(
                        TextType.CollectionResumeAutoRefresh)
                    : "Resume Auto Refresh";
                btnSwitch.Image = Resources.Run;
                btnSwitch.Enabled = false;
                RefreshStripButton.Enabled = false;

                Utility.ExceptionDeal(ex, "Refresh Status");
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlServerStatus_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            GuiConfig.Translateform(Controls);
            SetEnable(false);
            _autoRefresh = false;
        }

        public void SetEnable(bool enable)
        {
            _refreshTimer.Enabled = enable;
            _shortTimer.Enabled = enable;
        }


        /// <summary>
        ///     手动刷新所有状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshStripButton_Click(object sender, EventArgs e)
        {
            RefreshStatus(false);
        }

        /// <summary>
        ///     切换自动手动模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            _autoRefresh = !_autoRefresh;
            if (_autoRefresh)
            {
                _refreshTimer.Start();
                _shortTimer.Start();
                btnSwitch.Text = !GuiConfig.IsUseDefaultLanguage
                    ? GuiConfig.GetText(
                        TextType.CollectionStopAutoRefresh)
                    : "Stop Auto Refresh";
                btnSwitch.Image = Resources.Pause;
            }
            else
            {
                _refreshTimer.Stop();
                _shortTimer.Stop();
                btnSwitch.Text = !GuiConfig.IsUseDefaultLanguage
                    ? GuiConfig.GetText(
                        TextType.CollectionResumeAutoRefresh)
                    : "Resume Auto Refresh";
                btnSwitch.Image = Resources.Run;
            }
        }

        public void ResetCtl()
        {
            _refreshTimer.Enabled = true;
            _shortTimer.Enabled = true;
            btnSwitch.Enabled = true;
            RefreshStripButton.Enabled = true;
            btnSwitch.Image = Resources.Run;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseStripButton_Click(object sender, EventArgs e)
        {
            _refreshTimer.Stop();
            _shortTimer.Stop();
            if (CloseTab != null)
            {
                CloseTab(sender, e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollapseAllStripButton_Click(object sender, EventArgs e)
        {
            trvSvrStatus.DatatreeView.BeginUpdate();
            trvSvrStatus.DatatreeView.CollapseAll();
            trvSvrStatus.DatatreeView.EndUpdate();
        }

        private void ExpandAllStripButton_Click(object sender, EventArgs e)
        {
            trvSvrStatus.DatatreeView.BeginUpdate();
            trvSvrStatus.DatatreeView.ExpandAll();
            trvSvrStatus.DatatreeView.EndUpdate();
        }
    }
}