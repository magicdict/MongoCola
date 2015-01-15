using System;
using System.Windows.Forms;
using ResourceLib;

namespace Common
{
    public partial class ctlFilePicker : UserControl
    {
        public delegate void PathChangedHandler(String FilePath);

        /// <summary>
        ///     Dialog Type
        /// </summary>
        public enum DialogType
        {
            OpenFile,
            SaveFile,
            Directory
        }

        public static GUIConfig guiconfig;
        private DialogType _dialogType = DialogType.Directory;
        private String _FileFilter = String.Empty;
        private String _FileName = String.Empty;

        public ctlFilePicker()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     文件过滤
        /// </summary>
        public String FileFilter
        {
            get { return _FileFilter; }
            set { _FileFilter = value; }
        }

        /// <summary>
        ///     文件名称
        /// </summary>
        public String FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        /// <summary>
        ///     标题
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
        ///     选择类型
        /// </summary>
        public DialogType PickerType
        {
            get { return _dialogType; }
            set { _dialogType = value; }
        }

        /// <summary>
        ///     选中路径
        /// </summary>
        public String SelectedPathOrFileName
        {
            get { return txtPathName.Text; }
            set { txtPathName.Text = value; }
        }

        public event PathChangedHandler PathChanged;

        /// <summary>
        ///     Browse Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            switch (_dialogType)
            {
                case DialogType.OpenFile:
                    var openFile = new OpenFileDialog();
                    openFile.FileName = _FileName;
                    if (_FileFilter != String.Empty)
                    {
                        openFile.Filter = _FileFilter;
                    }
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        txtPathName.Text = openFile.FileName;
                    }
                    break;
                case DialogType.SaveFile:
                    var saveFile = new SaveFileDialog();
                    saveFile.FileName = _FileName;
                    if (_FileFilter != String.Empty)
                    {
                        saveFile.Filter = _FileFilter;
                    }
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        txtPathName.Text = saveFile.FileName;
                    }
                    break;
                case DialogType.Directory:
                    var folder = new FolderBrowserDialog();
                    if (folder.ShowDialog() == DialogResult.OK)
                    {
                        txtPathName.Text = folder.SelectedPath;
                    }
                    break;
            }
            if (PathChanged != null)
            {
                PathChanged(txtPathName.Text);
            }
        }

        /// <summary>
        ///     Clear
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
        ///     Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlFilePicker_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (guiconfig == null) return;
            cmdBrowse.Text = guiconfig.GetText("Browse", StringResource.TextType.Common_Browse);
            cmdClearPath.Text = guiconfig.GetText("Clear", StringResource.TextType.Common_Clear);
        }
    }
}