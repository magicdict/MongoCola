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
            /// <summary>
            /// 打开
            /// </summary>
            OpenFile,
            /// <summary>
            /// 保存
            /// </summary>
            SaveFile,
            /// <summary>
            /// 目录
            /// </summary>
            Directory
        }
        /// <summary>
        ///     类型
        /// </summary>
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
        ///     初始文件名称
        /// </summary>
        public string InitFileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>
        ///     选中路径
        /// </summary>
        public string SelectedPathOrFileName
        {
            get { return txtPathName.Text; }
            set { txtPathName.Text = value; }
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
        ///     cmdBrowse按钮文字
        /// </summary>
        public string Browse
        {
            get { return cmdBrowse.Text; }
            set
            {
                cmdBrowse.Text = value;
                ResizeControl(null, null);
            }
        }

        /// <summary>
        ///     cmdClear按钮文字
        /// </summary>
        public string Clear
        {
            get { return cmdClear.Text; }
            set
            {
                cmdClear.Text = value;
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
                    var openFile = new OpenFileDialog { FileName = _fileName };
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
                    var saveFile = new SaveFileDialog { FileName = _fileName };
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
            txtPathName.Width = Width - cmdBrowse.Width - lblTitle.Width - cmdClear.Width - 30;
            cmdClear.Left = Width - cmdClear.Width;
            cmdBrowse.Left = Width - cmdClear.Width - cmdBrowse.Width - 4;
        }
    }
}