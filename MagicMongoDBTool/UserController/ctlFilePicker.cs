using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class ctlFilePicker : UserControl
    {
        public delegate void PathChangedHandler(String FilePath);
        public event PathChangedHandler PathChanged;
        private String _FileFilter = String.Empty;
        /// <summary>
        /// 文件过滤
        /// </summary>
        public String FileFilter
        {
            get { return _FileFilter; }
            set { _FileFilter = value; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public String Title
        {
            get { return lblTitle.Text; }
            set
            {
                lblTitle.Text = value;
                txtPathName.Left = lblTitle.Right + 4;
                txtPathName.Width = cmdBrowse.Left - lblTitle.Right - 8;
            }
        }

        /// <summary>
        /// Dialog Type
        /// </summary>
        public enum DialogType
        {
            OpenFile,
            SaveFile,
            Directory
        }
        private DialogType _dialogType = DialogType.Directory;
        /// <summary>
        /// 选择类型
        /// </summary>
        public DialogType PickerType
        {
            get { return _dialogType; }
            set { _dialogType = value; }
        }
        /// <summary>
        /// 选中路径
        /// </summary>
        public String SelectedPathOrFileName
        {
            get { return txtPathName.Text; }
            set { txtPathName.Text = value; }
        }
        public ctlFilePicker()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Browse Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            switch (_dialogType)
            {
                case DialogType.OpenFile:
                    OpenFileDialog Openfd = new OpenFileDialog();
                    if (_FileFilter != String.Empty)
                    {
                        Openfd.Filter = _FileFilter;
                    }
                    if (Openfd.ShowDialog() == DialogResult.OK)
                    {
                        txtPathName.Text = Openfd.FileName;
                    }
                    break;
                case DialogType.SaveFile:
                    SaveFileDialog Savefd = new SaveFileDialog();
                    if (_FileFilter != String.Empty)
                    {
                        Savefd.Filter = _FileFilter;
                    }
                    if (Savefd.ShowDialog() == DialogResult.OK)
                    {
                        txtPathName.Text = Savefd.FileName;
                    }
                    break;
                case DialogType.Directory:
                    FolderBrowserDialog fd = new FolderBrowserDialog();
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        this.txtPathName.Text = fd.SelectedPath;
                    }
                    break;
                default:
                    break;
            }
            if (PathChanged != null)
            {
                PathChanged(txtPathName.Text);
            }
        }

        /// <summary>
        /// Clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClearPath_Click(object sender, EventArgs e)
        {
            txtPathName.Text = String.Empty;
            if (PathChanged != null)
            {
                PathChanged(txtPathName.Text);
            }
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlFilePicker_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage)
            {
                cmdBrowse.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Browse);
                cmdClearPath.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Clear);
            }
        }
    }
}
