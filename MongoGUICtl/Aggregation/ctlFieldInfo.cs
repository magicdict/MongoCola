using System.Windows.Forms;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using ResourceLib.Method;

namespace MongoGUICtl.Aggregation
{
    public partial class CtlFieldInfo : UserControl
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
            Query,

            /// <summary>
            ///     字段加Project
            /// </summary>
            Aggregation,

            /// <summary>
            ///     完整模式
            /// </summary>
            Full
        }

        /// <summary>
        ///     是否是主键保护模式
        /// </summary>
        private bool _mIdProtectMode;


        public CtlFieldInfo()
        {
            InitializeComponent();
            Common.UIAssistant.FillComberWithEnum(cmbSort, typeof(DataFilter.SortType));
        }

        /// <summary>
        ///     控件模式
        /// </summary>
        public FieldMode Mode
        {
            set
            {
                switch (value)
                {
                    case FieldMode.Field:
                        chkIsShow.Visible = true;
                        txtProject.Visible = false;
                        cmbSort.Visible = false;
                        NumIndexOrder.Visible = false;
                        break;
                    case FieldMode.Query:
                        chkIsShow.Visible = true;
                        txtProject.Visible = false;
                        cmbSort.Visible = true;
                        cmbSort.Left = chkIsShow.Left + chkIsShow.Width + 10;
                        NumIndexOrder.Visible = true;
                        NumIndexOrder.Left = cmbSort.Left + cmbSort.Width + 10;
                        break;
                    case FieldMode.Aggregation:
                        chkIsShow.Visible = true;
                        txtProject.Visible = true;
                        cmbSort.Visible = false;
                        NumIndexOrder.Visible = false;
                        break;
                    case FieldMode.Full:
                        chkIsShow.Visible = true;
                        txtProject.Visible = true;
                        cmbSort.Visible = true;
                        NumIndexOrder.Visible = true;
                        break;
                    default:
                        break;
                }
            }
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
                if ((lblFieldName.Text == ConstMgr.KeyId) && _mIdProtectMode)
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
        public bool IsIdProtect
        {
            set { _mIdProtectMode = value; }
            get { return _mIdProtectMode; }
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
                if (value.ColName == ConstMgr.KeyId)
                {
                    chkIsShow.Checked = true;
                    chkIsShow.Enabled = !_mIdProtectMode;
                }
                switch (value.SortType)
                {
                    case DataFilter.SortType.NoSort:
                        cmbSort.SelectedIndex = 0;
                        break;
                    case DataFilter.SortType.Ascending:
                        cmbSort.SelectedIndex = 1;
                        break;
                    case DataFilter.SortType.Descending:
                        cmbSort.SelectedIndex = 2;
                        break;
                    default:
                        break;
                }
                NumIndexOrder.Value = value.SortOrder;
            }
            get
            {
                var rtnQueryFieldItem = new DataFilter.QueryFieldItem()
                {
                    IsShow = chkIsShow.Checked,
                    ColName = lblFieldName.Text,
                    ProjectName = txtProject.Text
                };
                if (cmbSort.SelectedIndex == 0)
                {
                    rtnQueryFieldItem.SortType = DataFilter.SortType.NoSort;
                }
                if (cmbSort.SelectedIndex == 1)
                {
                    rtnQueryFieldItem.SortType = DataFilter.SortType.Ascending;
                }
                if (cmbSort.SelectedIndex == 2)
                {
                    rtnQueryFieldItem.SortType = DataFilter.SortType.Descending;
                }
                rtnQueryFieldItem.SortOrder = (int)NumIndexOrder.Value;
                return rtnQueryFieldItem;
            }
        }

        private void CtlFieldInfo_Load(object sender, System.EventArgs e)
        {
            cmbSort.Items.Clear();
            cmbSort.Items.Add(GuiConfig.GetText("None Sort", "Index.NoSort"));
            cmbSort.Items.Add(GuiConfig.GetText("Asce", "Index.Asce"));
            cmbSort.Items.Add(GuiConfig.GetText("Desc", "Index.Desc"));
        }
    }
}