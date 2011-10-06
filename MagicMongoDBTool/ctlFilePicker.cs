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
        private DialogType mDialogType = DialogType.Directory;
        public String Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }
        public DialogType PickType
        {
            get { return mDialogType; }
            set { mDialogType = value; }
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

        public delegate void PathChangedHandler(String FilePath);
        public event PathChangedHandler PathChanged;

        private void cmdLogPath_Click(object sender, EventArgs e)
        {

            switch (mDialogType)
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
