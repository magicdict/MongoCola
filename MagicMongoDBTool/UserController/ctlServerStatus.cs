using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MagicMongoDBTool.Properties;

namespace MagicMongoDBTool.UserController
{
    public partial class ctlServerStatus : UserControl
    {
        /// <summary>
        ///     短时间刷新
        /// </summary>
        private readonly Timer ShortTimer = new Timer();

        private readonly MongoDBHelper.lvwColumnSorter _lvwCollectionStatusColumnSorter =
            new MongoDBHelper.lvwColumnSorter();

        private readonly MongoDBHelper.lvwColumnSorter _lvwDBStatusColumnSorter = new MongoDBHelper.lvwColumnSorter();

        /// <summary>
        ///     常规刷新
        /// </summary>
        private readonly Timer refreshTimer = new Timer();

        /// <summary>
        ///     Auto Refresh Flag
        /// </summary>
        private Boolean AutoRefresh = true;

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
        public void RefreshStatus(Boolean IsAuto)
        {
            try
            {
                if (!IsAuto)
                {
                    MongoDBHelper.FillSrvStatusToList(trvSvrStatus);
                }
                MongoDBHelper.FillDataBaseStatusToList(lstDBStatus);
                MongoDBHelper.FillCollectionStatusToList(lstCollectionStatus);
            }
            catch (Exception ex)
            {
                refreshTimer.Stop();
                ShortTimer.Stop();
                if (!SystemManager.IsUseDefaultLanguage)
                {
                    btnSwitch.Text =
                        SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Resume_AutoRefresh);
                }
                else
                {
                    btnSwitch.Text = "Resume Auto Refresh";
                }
                btnSwitch.Image = Resources.Run;
                btnSwitch.Enabled = false;
                RefreshStripButton.Enabled = false;

                SystemManager.ExceptionDeal(ex, "Refresh Status");
            }
        }

        /// <summary>
        ///     当前操作状态
        /// </summary>
        public void RefreshCurrentOpr()
        {
            try
            {
                MongoDBHelper.FillCurrentOprToList(lstSrvOpr);
            }
            catch (Exception ex)
            {
                refreshTimer.Stop();
                ShortTimer.Stop();
                if (!SystemManager.IsUseDefaultLanguage)
                {
                    btnSwitch.Text =
                        SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Resume_AutoRefresh);
                }
                else
                {
                    btnSwitch.Text = "Resume Auto Refresh";
                }
                btnSwitch.Image = Resources.Run;
                btnSwitch.Enabled = false;
                RefreshStripButton.Enabled = false;

                SystemManager.ExceptionDeal(ex, "Refresh Current Opreation Exception");
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlServerStatus_Load(object sender, EventArgs e)
        {
            RefreshStatus(false);
            if (!SystemManager.IsUseDefaultLanguage)
            {
                Text = SystemManager.mStringResource.GetText(StringResource.TextType.ServiceStatus_Title);
                tabSvrBasicInfo.Text =
                    SystemManager.mStringResource.GetText(StringResource.TextType.ServiceStatus_ServerInfo);
                tabDBBasicInfo.Text =
                    SystemManager.mStringResource.GetText(StringResource.TextType.ServiceStatus_DataBaseInfo);
                tabCollectionInfo.Text =
                    SystemManager.mStringResource.GetText(StringResource.TextType.ServiceStatus_CollectionInfo);
                tabCurrentOprInfo.Text =
                    SystemManager.mStringResource.GetText(StringResource.TextType.ServiceStatus_CurrentOperationInfo);
                RefreshStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Refresh);
                btnSwitch.Text =
                    SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Stop_AutoRefresh);
                CloseStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Close);
            }
            refreshTimer.Interval = SystemManager.ConfigHelperInstance.RefreshStatusTimer*1000;
            refreshTimer.Tick += (x, y) =>
            {
                //防止在查看树形状态的时候被打扰
                RefreshStatus(true);
            };
            //
            ShortTimer.Interval = SystemManager.ConfigHelperInstance.RefreshStatusTimer*1000;
            ;
            ShortTimer.Tick += (x, y) =>
            {
                //防止在查看树形状态的时候被打扰
                RefreshCurrentOpr();
            };

            refreshTimer.Enabled = false;
            ShortTimer.Enabled = false;
            AutoRefresh = true;
            // 用新的排序方法对ListView排序
            lstDBStatus.ListViewItemSorter = _lvwDBStatusColumnSorter;
            lstDBStatus.ColumnClick += lstDBStatus_ColumnClick;
            lstCollectionStatus.ListViewItemSorter = _lvwCollectionStatusColumnSorter;
            lstCollectionStatus.ColumnClick += lstCollectionStatus_ColumnClick;
        }

        public void SetEnable(Boolean Enable)
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
                        MongoDBHelper.lvwColumnSorter.SortMethod.StringCompare;
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 8:
                    _lvwCollectionStatusColumnSorter.CompareMethod =
                        MongoDBHelper.lvwColumnSorter.SortMethod.SizeCompare;
                    break;
                default:
                    _lvwCollectionStatusColumnSorter.CompareMethod =
                        MongoDBHelper.lvwColumnSorter.SortMethod.NumberCompare;
                    break;
            }
            // 检查点击的列是不是现在的排序列.
            if (e.Column == _lvwCollectionStatusColumnSorter.SortColumn)
            {
                // 重新设置此列的排序方法.
                if (_lvwCollectionStatusColumnSorter.Order == SortOrder.Ascending)
                {
                    _lvwCollectionStatusColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    _lvwCollectionStatusColumnSorter.Order = SortOrder.Ascending;
                }
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
                    _lvwDBStatusColumnSorter.CompareMethod = MongoDBHelper.lvwColumnSorter.SortMethod.StringCompare;
                    break;
                case 2:
                case 3:
                case 5:
                case 7:
                    _lvwDBStatusColumnSorter.CompareMethod = MongoDBHelper.lvwColumnSorter.SortMethod.SizeCompare;
                    break;
                default:
                    _lvwDBStatusColumnSorter.CompareMethod = MongoDBHelper.lvwColumnSorter.SortMethod.NumberCompare;
                    break;
            }

            // 检查点击的列是不是现在的排序列.
            if (e.Column == _lvwDBStatusColumnSorter.SortColumn)
            {
                // 重新设置此列的排序方法.
                if (_lvwDBStatusColumnSorter.Order == SortOrder.Ascending)
                {
                    _lvwDBStatusColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    _lvwDBStatusColumnSorter.Order = SortOrder.Ascending;
                }
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
            RefreshCurrentOpr();
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
                if (!SystemManager.IsUseDefaultLanguage)
                {
                    btnSwitch.Text =
                        SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Stop_AutoRefresh);
                }
                else
                {
                    btnSwitch.Text = "Stop Auto Refresh";
                }
                btnSwitch.Image = Resources.Pause;
            }
            else
            {
                refreshTimer.Stop();
                ShortTimer.Stop();
                if (!SystemManager.IsUseDefaultLanguage)
                {
                    btnSwitch.Text =
                        SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Resume_AutoRefresh);
                }
                else
                {
                    btnSwitch.Text = "Resume Auto Refresh";
                }
                btnSwitch.Image = Resources.Run;
            }
        }

        public void ResetCtl()
        {
            refreshTimer.Enabled = true;
            ShortTimer.Enabled = true;
            btnSwitch.Enabled = true;
            RefreshStripButton.Enabled = true;
            btnSwitch.Image = Resources.Pause;
        }

        private void CloseStripButton_Click(object sender, EventArgs e)
        {
            refreshTimer.Stop();
            ShortTimer.Stop();
            if (CloseTab != null)
            {
                CloseTab(sender, e);
            }
        }
    }
}