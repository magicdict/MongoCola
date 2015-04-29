using System;
using System.Windows.Forms;
using Common;
using MongoGUICtl;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.Properties;

namespace MongoGUIView
{
    public partial class CtlServerStatus : UserControl
    {
        /// <summary>
        /// </summary>
        private readonly FillMongoDb.LvwColumnSorter _lvwCollectionStatusColumnSorter =
            new FillMongoDb.LvwColumnSorter();

        /// <summary>
        /// </summary>
        private readonly FillMongoDb.LvwColumnSorter _lvwDbStatusColumnSorter = new FillMongoDb.LvwColumnSorter();

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
                    //Lagacy
                    FillMongoDb.FillSrvStatusToList(trvSvrStatus, RuntimeMongoDbContext.MongoConnSvrLst);
                    //FillMongoDB.FillClientStatusToList(trvSvrStatus, RuntimeMongoDBContext._mongoConnClientLst);
                }
                FillMongoDb.FillDataBaseStatusToList(lstDBStatus, RuntimeMongoDbContext.MongoConnSvrLst);
                FillMongoDb.FillCollectionStatusToList(lstCollectionStatus, RuntimeMongoDbContext.MongoConnSvrLst);
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
                _refreshTimer.Stop();
                _shortTimer.Stop();
                btnSwitch.Text = !GuiConfig.IsUseDefaultLanguage
                    ? GuiConfig.GetText(
                        TextType.CollectionResumeAutoRefresh)
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
            GuiConfig.Translateform(Controls);
            SetEnable(false);
            _autoRefresh = false;
            // 用新的排序方法对ListView排序
            lstDBStatus.ListViewItemSorter = _lvwDbStatusColumnSorter;
            lstDBStatus.ColumnClick += lstDBStatus_ColumnClick;
            lstCollectionStatus.ListViewItemSorter = _lvwCollectionStatusColumnSorter;
            lstCollectionStatus.ColumnClick += lstCollectionStatus_ColumnClick;
        }

        public void SetEnable(bool enable)
        {
            _refreshTimer.Enabled = enable;
            _shortTimer.Enabled = enable;
        }

        //Collection Status用排序器

        private void lstCollectionStatus_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            switch (e.Column)
            {
                case 0:
                case 6:
                    _lvwCollectionStatusColumnSorter.CompareMethod =
                        FillMongoDb.LvwColumnSorter.SortMethod.StringCompare;
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 8:
                    _lvwCollectionStatusColumnSorter.CompareMethod =
                        FillMongoDb.LvwColumnSorter.SortMethod.SizeCompare;
                    break;
                default:
                    _lvwCollectionStatusColumnSorter.CompareMethod =
                        FillMongoDb.LvwColumnSorter.SortMethod.NumberCompare;
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
                    _lvwDbStatusColumnSorter.CompareMethod = FillMongoDb.LvwColumnSorter.SortMethod.StringCompare;
                    break;
                case 2:
                case 3:
                case 5:
                case 7:
                    _lvwDbStatusColumnSorter.CompareMethod = FillMongoDb.LvwColumnSorter.SortMethod.SizeCompare;
                    break;
                default:
                    _lvwDbStatusColumnSorter.CompareMethod = FillMongoDb.LvwColumnSorter.SortMethod.NumberCompare;
                    break;
            }

            // 检查点击的列是不是现在的排序列.
            if (e.Column == _lvwDbStatusColumnSorter.SortColumn)
            {
                // 重新设置此列的排序方法.
                _lvwDbStatusColumnSorter.Order = _lvwDbStatusColumnSorter.Order == SortOrder.Ascending
                    ? SortOrder.Descending
                    : SortOrder.Ascending;
            }
            else
            {
                // 设置排序列，默认为正向排序
                _lvwDbStatusColumnSorter.SortColumn = e.Column;
                _lvwDbStatusColumnSorter.Order = SortOrder.Ascending;
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