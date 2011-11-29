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

        Timer refreshTimer = new Timer();


        private void frmServiceStatus_Load(object sender, EventArgs e)
        {
            refreshTimer.Interval = SystemManager.ConfigHelperInstance.RefreshStatusTimer * 1000;
            refreshTimer.Tick += new EventHandler((x, y) =>
            {
                //防止在查看树形状态的时候被打扰
                //MongoDBHelper.FillExtraSrvStatusToList(trvSvrStatus);
                MongoDBHelper.FillDataBaseStatusToList(this.lstDBStatus);
                MongoDBHelper.FillCollectionStatusToList(this.lstCollectionStatus);
                MongoDBHelper.FillSrvOprToList(this.lstSrvOpr);
            });

            refreshTimer.Enabled = true;
            MongoDBHelper.FillSrvStatusToList(trvSvrStatus);
            MongoDBHelper.FillDataBaseStatusToList(this.lstDBStatus);
            MongoDBHelper.FillCollectionStatusToList(this.lstCollectionStatus);
            MongoDBHelper.FillSrvOprToList(this.lstSrvOpr);

            if (!SystemManager.IsUseDefaultLanguage())
            {
                this.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.ServiceStatus_Title);
                cmdRefresh.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_Refresh);
                this.tabSvrBasicInfo.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.ServiceStatus_ServerInfo);
                this.tabDBBasicInfo.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.ServiceStatus_DataBaseInfo);
                this.tabCollectionInfo.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.ServiceStatus_CollectionInfo);
                this.tabClusterInfo.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.ServiceStatus_ClusterInfo);
            }

            // 用新的排序方法对ListView排序
            this.lstDBStatus.ListViewItemSorter = _lvwDBStatusColumnSorter;
            lstDBStatus.ColumnClick += new ColumnClickEventHandler(lstDBStatus_ColumnClick);
            this.lstCollectionStatus.ListViewItemSorter = _lvwCollectionStatusColumnSorter;
            lstCollectionStatus.ColumnClick += new ColumnClickEventHandler(lstCollectionStatus_ColumnClick);
        }
        /// <summary>
        /// 立刻刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            MongoDBHelper.FillSrvStatusToList(trvSvrStatus);
            MongoDBHelper.FillDataBaseStatusToList(this.lstDBStatus);
            MongoDBHelper.FillCollectionStatusToList(this.lstCollectionStatus);
            MongoDBHelper.FillSrvOprToList(this.lstSrvOpr);
        }
        /// <summary>
        /// Timer停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmServiceStatus_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            refreshTimer.Stop();
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
    }
}
