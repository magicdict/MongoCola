using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class ctlFilePicker : UserControl
    {
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

        private void cmdLogPath_Click(object sender, EventArgs e)
        {
            switch (_dialogType)
            {
                case DialogType.OpenFile:
                    OpenFileDialog Openfd = new OpenFileDialog();
                    if (Openfd.ShowDialog() == DialogResult.OK)
                    {
                        txtLogPath.Text = Openfd.FileName;
                    }
                    break;
                case DialogType.SaveFile:
                    SaveFileDialog Savefd = new SaveFileDialog();
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
            PathChanged(txtLogPath.Text);
        }
        private void cmdClearLogPath_Click(object sender, EventArgs e)
        {
            txtLogPath.Text = "";
            PathChanged(txtLogPath.Text);
        }
    }
}
