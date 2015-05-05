using System;
using System.Windows.Forms;
using ResourceLib.Method;

namespace ResourceLib.UI
{
    public partial class CtlFilePicker : UserControl
    {
        public delegate void PathChangedHandler(string filePath);

        /// <summary>
        ///     Dialog Type
        /// </summary>
        public enum DialogType
        {
            OpenFile,
            SaveFile,
            Directory
        }

        private DialogType _dialogType = DialogType.Directory;
        private string _fileFilter = string.Empty;
        private string _fileName = string.Empty;

        public CtlFilePicker()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     文件过滤
        /// </summary>
        public string FileFilter
        {
            get { return _fileFilter; }
            set { _fileFilter = value; }
        }

        /// <summary>
        ///     文件名称
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>
        ///     标题
        /// </summary>
        public string Title
        {
            get { return lblTitle.Text; }
            set
            {
                lblTitle.Text = value;
                ResizeControl(null, null);
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
        public string SelectedPathOrFileName
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
                    var openFile = new OpenFileDialog {FileName = _fileName};
                    if (_fileFilter != string.Empty)
                    {
                        openFile.Filter = _fileFilter;
                    }
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        txtPathName.Text = openFile.FileName;
                    }
                    break;
                case DialogType.SaveFile:
                    var saveFile = new SaveFileDialog {FileName = _fileName};
                    if (_fileFilter != string.Empty)
                    {
                        saveFile.Filter = _fileFilter;
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
            txtPathName.Text = string.Empty;
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
            GuiConfig.Translateform(Controls);
        }

        private void ResizeControl(object sender, EventArgs e)
        {
            txtPathName.Left = lblTitle.Right + 4;
            txtPathName.Width = Width - cmdBrowse.Width - lblTitle.Width - cmdClearPath.Width - 30;
            cmdClearPath.Left = Width - cmdClearPath.Width;
            cmdBrowse.Left = Width - cmdClearPath.Width - cmdBrowse.Width - 4;
        }
    }
}