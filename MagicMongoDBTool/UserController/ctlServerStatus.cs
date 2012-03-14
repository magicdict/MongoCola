using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool.UserController
{
    public partial class ctlServerStatus : UserControl
    {
        public ctlServerStatus()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 关闭Tab事件
        /// </summary>
        public event EventHandler CloseTab;
        /// <summary>
        /// 常规刷新
        /// </summary>
        Timer refreshTimer = new Timer();
        /// <summary>
        /// 短时间刷新
        /// </summary>
        Timer ShortTimer = new Timer();
        /// <summary>
        /// Auto Refresh Flag
        /// </summary>
        Boolean AutoRefresh = true;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsAuto"></param>
        public void RefreshStatus(Boolean IsAuto) {
            if (!IsAuto)
            {
                MongoDBHelper.FillSrvStatusToList(trvSvrStatus);
            }
            MongoDBHelper.FillDataBaseStatusToList(this.lstDBStatus);
            MongoDBHelper.FillCollectionStatusToList(this.lstCollectionStatus);
        }
        /// <summary>
        /// 
        /// </summary>
        public void RefreshCurrentOpr() {
            MongoDBHelper.FillCurrentOprToList(this.lstSrvOpr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlServerStatus_Load(object sender, EventArgs e)
        {
            RefreshStatus(false);
            if (!SystemManager.IsUseDefaultLanguage())
            {
                this.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.ServiceStatus_Title);
                this.tabSvrBasicInfo.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.ServiceStatus_ServerInfo);
                this.tabDBBasicInfo.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.ServiceStatus_DataBaseInfo);
                this.tabCollectionInfo.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.ServiceStatus_CollectionInfo);
                this.tabCurrentOprInfo.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.ServiceStatus_CurrentOperationInfo);
                this.RefreshStripButton.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Refresh);
                this.btnSwitch.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Collection_Stop_AutoRefresh);

            }
            refreshTimer.Interval = SystemManager.ConfigHelperInstance.RefreshStatusTimer * 1000;
            refreshTimer.Tick += new EventHandler(
                (x, y) =>
                {
                    //防止在查看树形状态的时候被打扰
                    this.RefreshStatus(true);
                }
            );
            ShortTimer.Interval = 5000;
            ShortTimer.Tick += new EventHandler(
                (x, y) =>
                {
                    //防止在查看树形状态的时候被打扰
                    this.RefreshCurrentOpr();
                }
            );

            refreshTimer.Enabled = false;
            ShortTimer.Enabled = false;
            AutoRefresh = true;
            // 用新的排序方法对ListView排序
            this.lstDBStatus.ListViewItemSorter = _lvwDBStatusColumnSorter;
            lstDBStatus.ColumnClick += new ColumnClickEventHandler(lstDBStatus_ColumnClick);
            this.lstCollectionStatus.ListViewItemSorter = _lvwCollectionStatusColumnSorter;
            lstCollectionStatus.ColumnClick += new ColumnClickEventHandler(lstCollectionStatus_ColumnClick);
        }
        public void SetEnable(Boolean Enable) {
            refreshTimer.Enabled = Enable;
            ShortTimer.Enabled = Enable;
        }
        //Collection Status用排序器
        MongoDBHelper.lvwColumnSorter _lvwCollectionStatusColumnSorter = new MongoDBHelper.lvwColumnSorter();
        private void lstCollectionStatus_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            switch (e.Column)
            {
                case 0:
                    _lvwCollectionStatusColumnSorter.CompareMethod = MongoDBHelper.lvwColumnSorter.SortMethod.StringCompare;
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    _lvwCollectionStatusColumnSorter.CompareMethod = MongoDBHelper.lvwColumnSorter.SortMethod.SizeCompare;
                    break;
                default:
                    _lvwCollectionStatusColumnSorter.CompareMethod = MongoDBHelper.lvwColumnSorter.SortMethod.NumberCompare;
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
            this.lstCollectionStatus.Sort();
        }
        //DB Status用排序器
        MongoDBHelper.lvwColumnSorter _lvwDBStatusColumnSorter = new MongoDBHelper.lvwColumnSorter();
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
            this.lstDBStatus.Sort();
        }

        private void RefreshStripButton_Click(object sender, EventArgs e)
        {
            this.RefreshStatus(false);
            this.RefreshCurrentOpr();
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            AutoRefresh = !AutoRefresh;
            if (AutoRefresh)
            {
                refreshTimer.Start();
                ShortTimer.Start();
                if (!SystemManager.IsUseDefaultLanguage())
                {
                    this.btnSwitch.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Collection_Stop_AutoRefresh);
                }
                else
                {
                    btnSwitch.Text = "Stop Auto Refresh";
                }
                btnSwitch.Image = MagicMongoDBTool.Properties.Resources.Pause;
            }
            else
            {
                refreshTimer.Stop();
                ShortTimer.Stop();
                if (!SystemManager.IsUseDefaultLanguage())
                {
                    this.btnSwitch.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Collection_Resume_AutoRefresh);
                }
                else
                {
                    btnSwitch.Text = "Resume Auto Refresh";
                }
                btnSwitch.Image = MagicMongoDBTool.Properties.Resources.Run;
            }
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
