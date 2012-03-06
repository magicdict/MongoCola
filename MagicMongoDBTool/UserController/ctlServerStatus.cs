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
        public void RefreshStatus(Boolean IsAuto) {
            if (!IsAuto)
            {
                MongoDBHelper.FillSrvStatusToList(trvSvrStatus);
            }
            MongoDBHelper.FillDataBaseStatusToList(this.lstDBStatus);
            MongoDBHelper.FillCollectionStatusToList(this.lstCollectionStatus);
            MongoDBHelper.FillSrvOprToList(this.lstSrvOpr);
        }
        private void ctlServerStatus_Load(object sender, EventArgs e)
        {
            RefreshStatus(false);
            if (!SystemManager.IsUseDefaultLanguage())
            {
                this.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.ServiceStatus_Title);
                this.tabSvrBasicInfo.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.ServiceStatus_ServerInfo);
                this.tabDBBasicInfo.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.ServiceStatus_DataBaseInfo);
                this.tabCollectionInfo.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.ServiceStatus_CollectionInfo);
                this.tabClusterInfo.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.ServiceStatus_ClusterInfo);
            }

            // 用新的排序方法对ListView排序
            this.lstDBStatus.ListViewItemSorter = _lvwDBStatusColumnSorter;
            lstDBStatus.ColumnClick += new ColumnClickEventHandler(lstDBStatus_ColumnClick);
            this.lstCollectionStatus.ListViewItemSorter = _lvwCollectionStatusColumnSorter;
            lstCollectionStatus.ColumnClick += new ColumnClickEventHandler(lstCollectionStatus_ColumnClick);
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
