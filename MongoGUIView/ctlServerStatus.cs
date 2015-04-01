using System;
using System.Windows.Forms;
using Common.Logic;
using MongoGUICtl;
using MongoUtility.Core;
using ResourceLib.Properties;
using ResourceLib.Utility;

namespace MongoGUIView
{
    public partial class ctlServerStatus : UserControl
    {
        /// <summary>
        /// </summary>
        private readonly FillMongoDB.lvwColumnSorter _lvwCollectionStatusColumnSorter =
            new FillMongoDB.lvwColumnSorter();

        /// <summary>
        /// </summary>
        private readonly FillMongoDB.lvwColumnSorter _lvwDBStatusColumnSorter = new FillMongoDB.lvwColumnSorter();

        /// <summary>
        ///     常规刷新
        /// </summary>
        private readonly Timer refreshTimer = new Timer();

        /// <summary>
        ///     短时间刷新
        /// </summary>
        private readonly Timer ShortTimer = new Timer();

        /// <summary>
        ///     Auto Refresh Flag
        /// </summary>
        private bool AutoRefresh = true;

        public ctlServerStatus()
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
        /// <param name="IsAuto">是否自动刷新</param>
        public void RefreshStatus(bool IsAuto)
        {
            try
            {
                if (!IsAuto)
                {
                    //手动刷新
                    FillMongoDB.FillSrvStatusToList(trvSvrStatus, RuntimeMongoDBContext._mongoConnSvrLst);
                }
                FillMongoDB.FillDataBaseStatusToList(lstDBStatus, RuntimeMongoDBContext._mongoConnSvrLst);
                FillMongoDB.FillCollectionStatusToList(lstCollectionStatus, RuntimeMongoDBContext._mongoConnSvrLst);
            }
            catch (Exception ex)
            {
                refreshTimer.Stop();
                ShortTimer.Stop();
                btnSwitch.Text = !configuration.guiConfig.IsUseDefaultLanguage
                    ? configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Collection_Resume_AutoRefresh)
                    : "Resume Auto Refresh";
                btnSwitch.Image = Resources.Run;
                btnSwitch.Enabled = false;
                RefreshStripButton.Enabled = false;

                Utility.ExceptionDeal(ex, "Refresh Status");
            }
        }

        /// <summary>
        ///     当前操作状态
        /// </summary>
        public void RefreshCurrentOpr()
        {
            try
            {
                //Mongo 3.0 Drvier2.0开始不稳定
                //FillMongoDB.FillCurrentOprToList(lstSrvOpr, RuntimeMongoDBContext._mongoConnSvrLst);
            }
            catch (Exception ex)
            {
                refreshTimer.Stop();
                ShortTimer.Stop();
                btnSwitch.Text = !configuration.guiConfig.IsUseDefaultLanguage
                    ? configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Collection_Resume_AutoRefresh)
                    : "Resume Auto Refresh";
                btnSwitch.Image = Resources.Run;
                btnSwitch.Enabled = false;
                RefreshStripButton.Enabled = false;

                Utility.ExceptionDeal(ex, "Refresh Current Opreation Exception");
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlServerStatus_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            //RefreshStatus(false);
            if (!configuration.guiConfig.IsUseDefaultLanguage)
            {
                Text = configuration.guiConfig.MStringResource.GetText(StringResource.TextType.ServiceStatus_Title);
                tabSvrBasicInfo.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.ServiceStatus_ServerInfo);
                tabDBBasicInfo.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.ServiceStatus_DataBaseInfo);
                tabCollectionInfo.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.ServiceStatus_CollectionInfo);
                tabCurrentOprInfo.Text =
                    configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.ServiceStatus_CurrentOperationInfo);
                RefreshStripButton.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Refresh);
                btnSwitch.Text =
                    configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Collection_Resume_AutoRefresh);
                CloseStripButton.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Close);
            }
            refreshTimer.Interval = configuration.RefreshStatusTimer*1000;
            refreshTimer.Tick += (x, y) => RefreshStatus(true);
            //
            ShortTimer.Interval = configuration.RefreshStatusTimer*1000;
            //ShortTimer.Tick += (x, y) => RefreshCurrentOpr();

            SetEnable(false);
            AutoRefresh = false;
            // 用新的排序方法对ListView排序
            lstDBStatus.ListViewItemSorter = _lvwDBStatusColumnSorter;
            lstDBStatus.ColumnClick += lstDBStatus_ColumnClick;
            lstCollectionStatus.ListViewItemSorter = _lvwCollectionStatusColumnSorter;
            lstCollectionStatus.ColumnClick += lstCollectionStatus_ColumnClick;
        }

        public void SetEnable(bool Enable)
        {
            refreshTimer.Enabled = Enable;
            ShortTimer.Enabled = Enable;
        }

        //Collection Status用排序器

        private void lstCollectionStatus_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            switch (e.Column)
            {
                case 0:
                case 6:
                    _lvwCollectionStatusColumnSorter.CompareMethod =
                        FillMongoDB.lvwColumnSorter.SortMethod.StringCompare;
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 8:
                    _lvwCollectionStatusColumnSorter.CompareMethod =
                        FillMongoDB.lvwColumnSorter.SortMethod.SizeCompare;
                    break;
                default:
                    _lvwCollectionStatusColumnSorter.CompareMethod =
                        FillMongoDB.lvwColumnSorter.SortMethod.NumberCompare;
                    break;
            }
            // 检查点击的列是不是现在的排序列.
            if (e.Column == _lvwCollectionStatusColumnSorter.SortColumn)
            {
                // 重新设置此列的排序方法.
                _lvwCollectionStatusColumnSorter.Order = _lvwCollectionStatusColumnSorter.Order == SortOrder.Ascending
                    ? SortOrder.Descending
                    : SortOrder.Ascending;
            }
            else
            {
                // 设置排序列，默认为正向排序
                _lvwCollectionStatusColumnSorter.SortColumn = e.Column;
                _lvwCollectionStatusColumnSorter.Order = SortOrder.Ascending;
            }
            lstCollectionStatus.Sort();
        }

        //DB Status用排序器

        private void lstDBStatus_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            switch (e.Column)
            {
                case 0:
                    _lvwDBStatusColumnSorter.CompareMethod = FillMongoDB.lvwColumnSorter.SortMethod.StringCompare;
                    break;
                case 2:
                case 3:
                case 5:
                case 7:
                    _lvwDBStatusColumnSorter.CompareMethod = FillMongoDB.lvwColumnSorter.SortMethod.SizeCompare;
                    break;
                default:
                    _lvwDBStatusColumnSorter.CompareMethod = FillMongoDB.lvwColumnSorter.SortMethod.NumberCompare;
                    break;
            }

            // 检查点击的列是不是现在的排序列.
            if (e.Column == _lvwDBStatusColumnSorter.SortColumn)
            {
                // 重新设置此列的排序方法.
                _lvwDBStatusColumnSorter.Order = _lvwDBStatusColumnSorter.Order == SortOrder.Ascending
                    ? SortOrder.Descending
                    : SortOrder.Ascending;
            }
            else
            {
                // 设置排序列，默认为正向排序
                _lvwDBStatusColumnSorter.SortColumn = e.Column;
                _lvwDBStatusColumnSorter.Order = SortOrder.Ascending;
            }
            lstDBStatus.Sort();
        }

        /// <summary>
        ///     手动刷新所有状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshStripButton_Click(object sender, EventArgs e)
        {
            RefreshStatus(false);
            //RefreshCurrentOpr();
        }

        /// <summary>
        ///     切换自动手动模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            AutoRefresh = !AutoRefresh;
            if (AutoRefresh)
            {
                refreshTimer.Start();
                ShortTimer.Start();
                btnSwitch.Text = !configuration.guiConfig.IsUseDefaultLanguage
                    ? configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Collection_Stop_AutoRefresh)
                    : "Stop Auto Refresh";
                btnSwitch.Image = Resources.Pause;
            }
            else
            {
                refreshTimer.Stop();
                ShortTimer.Stop();
                btnSwitch.Text = !configuration.guiConfig.IsUseDefaultLanguage
                    ? configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Collection_Resume_AutoRefresh)
                    : "Resume Auto Refresh";
                btnSwitch.Image = Resources.Run;
            }
        }

        public void ResetCtl()
        {
            refreshTimer.Enabled = true;
            ShortTimer.Enabled = true;
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
            refreshTimer.Stop();
            ShortTimer.Stop();
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