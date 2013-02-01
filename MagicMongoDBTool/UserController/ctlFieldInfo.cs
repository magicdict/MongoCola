using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class ctlFieldInfo : UserControl
    {
        public ctlFieldInfo()
        {
            InitializeComponent();
            if (!SystemManager.IsUseDefaultLanguage)
            {
                this.lblFieldName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.ctlIndexCreate_Index);
                this.radSortAcs.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_Asce);
                this.radSortDes.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_Desc);
                this.radNoSort.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_NoSort);
                this.chkIsShow.Text = SystemManager.mStringResource.GetText(StringResource.TextType.ctlFieldInfo_Show);
            }
        }
        /// <summary>
        /// 是否表示
        /// </summary>
        public bool IsShow
        {
            get { return chkIsShow.Checked; }
            set { 
                if ((lblFieldName.Text == MongoDBHelper.KEY_ID) && mIDProtectMode){
                    return;
                }
                chkIsShow.Checked = value; 
            }
        }
        private bool mIDProtectMode;
        /// <summary>
        /// ID的显示属性是否可变
        /// </summary>
        public bool IsIDProtect{
            set { mIDProtectMode = value; }
            get { return mIDProtectMode; }
        }
        /// <summary>
        /// Query Field Item
        /// </summary>
        public DataFilter.QueryFieldItem QueryFieldItem
        {
            set
            {
                lblFieldName.Text = value.ColName;
                chkIsShow.Checked = value.IsShow;
                if (value.ColName == MongoDBHelper.KEY_ID)
                {
                    chkIsShow.Checked = true;
                    chkIsShow.Enabled = !(mIDProtectMode);
                }
                switch (value.sortType)
                {
                    case DataFilter.SortType.NoSort:
                        radNoSort.Checked = true;
                        break;
                    case DataFilter.SortType.Ascending:
                        radSortAcs.Checked = true;
                        break;
                    case DataFilter.SortType.Descending:
                        radSortDes.Checked = true;
                        break;
                    default:
                        break;
                }
            }
            get
            {
                DataFilter.QueryFieldItem rtn = new DataFilter.QueryFieldItem();
                rtn.IsShow = chkIsShow.Checked;
                rtn.ColName = lblFieldName.Text;
                if (this.radNoSort.Checked)
                {
                    rtn.sortType = DataFilter.SortType.NoSort;
                }
                if (this.radSortAcs.Checked)
                {
                    rtn.sortType = DataFilter.SortType.Ascending;
                }
                if (this.radSortDes.Checked)
                {
                    rtn.sortType = DataFilter.SortType.Descending;
                }
                return rtn;
            }

        }
    }
}
