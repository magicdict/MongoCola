using System.Windows.Forms;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using ResourceLib.Utility;

namespace MongoGUICtl.Aggregation
{
    public partial class ctlFieldInfo : UserControl
    {
        /// <summary>
        ///     模式
        /// </summary>
        public enum FieldMode
        {
            /// <summary>
            ///     字段
            /// </summary>
            Field,

            /// <summary>
            ///     字段加排序
            /// </summary>
            FiledSort,

            /// <summary>
            ///     字段加Project
            /// </summary>
            FieldProject,

            /// <summary>
            ///     完整模式
            /// </summary>
            Full
        }

        /// <summary>
        ///     是否是主键保护模式
        /// </summary>
        private bool mIDProtectMode;

        private FieldMode mMode;

        public ctlFieldInfo()
        {
            InitializeComponent();
            if (!GUIConfig.IsUseDefaultLanguage)
            {
                lblFieldName.Text =
                    GUIConfig.MStringResource.GetText(TextType.ctlIndexCreate_Index);
                radSortAcs.Text = GUIConfig.MStringResource.GetText(TextType.Index_Asce);
                radSortDes.Text = GUIConfig.MStringResource.GetText(TextType.Index_Desc);
                radNoSort.Text = GUIConfig.MStringResource.GetText(TextType.Index_NoSort);
                chkIsShow.Text =
                    GUIConfig.MStringResource.GetText(TextType.ctlFieldInfo_Show);
            }
        }

        /// <summary>
        ///     控件模式
        /// </summary>
        public FieldMode Mode
        {
            set
            {
                mMode = value;
                switch (mMode)
                {
                    case FieldMode.Field:
                        chkIsShow.Visible = true;
                        radNoSort.Visible = false;
                        radSortAcs.Visible = false;
                        radSortDes.Visible = false;
                        txtProject.Visible = false;
                        break;
                    case FieldMode.FiledSort:
                        chkIsShow.Visible = true;
                        radNoSort.Visible = true;
                        radSortAcs.Visible = true;
                        radSortDes.Visible = true;
                        txtProject.Visible = false;
                        break;
                    case FieldMode.FieldProject:
                        chkIsShow.Visible = true;
                        radNoSort.Visible = false;
                        radSortAcs.Visible = false;
                        radSortDes.Visible = false;
                        txtProject.Visible = true;
                        txtProject.Left = radNoSort.Left;
                        break;
                    case FieldMode.Full:
                        chkIsShow.Visible = true;
                        radNoSort.Visible = true;
                        radSortAcs.Visible = true;
                        radSortDes.Visible = true;
                        txtProject.Visible = true;
                        break;
                    default:
                        break;
                }
            }
            get { return mMode; }
        }

        /// <summary>
        ///     是否显示字段重命名
        /// </summary>
        public bool IsProject
        {
            get { return txtProject.Visible; }
            set { txtProject.Visible = value; }
        }

        /// <summary>
        ///     是否表示
        /// </summary>
        public bool IsShow
        {
            get { return chkIsShow.Checked; }
            set
            {
                if ((lblFieldName.Text == ConstMgr.KEY_ID) && mIDProtectMode)
                {
                    return;
                }
                chkIsShow.Checked = value;
            }
        }

        /// <summary>
        ///     投影名称
        /// </summary>
        public string ProjectName
        {
            get { return txtProject.Text; }
            set { txtProject.Text = value; }
        }

        /// <summary>
        ///     ID的显示属性是否可变
        /// </summary>
        public bool IsIDProtect
        {
            set { mIDProtectMode = value; }
            get { return mIDProtectMode; }
        }

        /// <summary>
        ///     Query Field Item
        /// </summary>
        public DataFilter.QueryFieldItem QueryFieldItem
        {
            set
            {
                lblFieldName.Text = value.ColName;
                chkIsShow.Checked = value.IsShow;
                txtProject.Text = value.ProjectName;
                if (value.ColName == ConstMgr.KEY_ID)
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
                var rtnQueryFieldItem = new DataFilter.QueryFieldItem();
                rtnQueryFieldItem.IsShow = chkIsShow.Checked;
                rtnQueryFieldItem.ColName = lblFieldName.Text;
                rtnQueryFieldItem.ProjectName = txtProject.Text;
                if (radNoSort.Checked)
                {
                    rtnQueryFieldItem.sortType = DataFilter.SortType.NoSort;
                }
                if (radSortAcs.Checked)
                {
                    rtnQueryFieldItem.sortType = DataFilter.SortType.Ascending;
                }
                if (radSortDes.Checked)
                {
                    rtnQueryFieldItem.sortType = DataFilter.SortType.Descending;
                }
                return rtnQueryFieldItem;
            }
        }
    }
}