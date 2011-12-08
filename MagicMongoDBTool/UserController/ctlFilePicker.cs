using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class ctlFilePicker : UserControl
    {
        private String _FileFilter = String.Empty;
        /// <summary>
        /// 文件过滤
        /// </summary>
        public String FileFilter {
            get { return _FileFilter; }
            set { _FileFilter = value; }
        }

        private DialogType _dialogType = DialogType.Directory;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }
        /// <summary>
        /// 选择类型
        /// </summary>
        public DialogType PickType
        {
            get { return _dialogType; }
            set { _dialogType = value; }
        }
        /// <summary>
        /// 选中路径
        /// </summary>
        public string SelectedPath 
        {
            get { return txtLogPath.Text; }
            set { txtLogPath.Text = value; }
        }

        public enum DialogType
        {
            OpenFile,
            SaveFile,
            Directory
        }

        public ctlFilePicker()
        {
            InitializeComponent();
        }

        public delegate void PathChangedHandler(string FilePath);
        public event PathChangedHandler PathChanged;
        /// <summary>
        /// 浏览按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            switch (_dialogType)
            {
                case DialogType.OpenFile:
                    OpenFileDialog Openfd = new OpenFileDialog();
                    if (_FileFilter != String.Empty) {
                        Openfd.Filter = _FileFilter;
                    }
                    if (Openfd.ShowDialog() == DialogResult.OK)
                    {
                        txtLogPath.Text = Openfd.FileName;
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
                        txtLogPath.Text = Savefd.FileName;
                    }
                    break;
                case DialogType.Directory:
                    FolderBrowserDialog fd = new FolderBrowserDialog();
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        this.txtLogPath.Text = fd.SelectedPath;
                    }
                    break;
                default:
                    break;
            }
            if (PathChanged != null)
            {
                PathChanged(txtLogPath.Text);
            }
        }

        /// <summary>
        /// 清除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClearPath_Click(object sender, EventArgs e)
        {
            txtLogPath.Text = "";
            if (PathChanged != null)
            {
                PathChanged(txtLogPath.Text);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlFilePicker_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage()) {
                cmdBrowse.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Browse);
                cmdClearPath.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Clear);
            }
        }
    }
}
