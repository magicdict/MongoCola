using System;
using System.IO;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MagicMongoDBTool.UserController;

namespace MagicMongoDBTool
{
    public partial class ctlGFSView : ctlDataView
    {
        public ctlGFSView(MongoDBHelper.DataViewInfo _DataViewInfo)
        {
            InitializeComponent();
            InitTool();
            mDataViewInfo = _DataViewInfo;
            _dataShower.Add(lstData);
        }

        private void ctlGFSView_Load(object sender, EventArgs e)
        {
            OpenFileToolStripMenuItem.Click += OpenFileStripButton_Click;
            DownloadFileToolStripMenuItem.Click += DownloadFileStripButton_Click;
            UploadFileToolStripMenuItem.Click += UploadFileStripButton_Click;
            UploadFolderToolStripMenuItem.Click += UpLoadFolderStripButton_Click;
            DeleteFileToolStripMenuItem.Click += DeleteFileStripButton_Click;

            if (!SystemManager.IsUseDefaultLanguage)
            {
                DeleteFileToolStripMenuItem.Text =
                    SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_DelFile);
                DeleteFileStripButton.Text = DeleteFileToolStripMenuItem.Text;

                UploadFileToolStripMenuItem.Text =
                    SystemManager.mStringResource.GetText(
                        StringResource.TextType.Main_Menu_Operation_FileSystem_UploadFile);
                UploadFileStripButton.Text = UploadFileToolStripMenuItem.Text;

                UploadFolderToolStripMenuItem.Text =
                    SystemManager.mStringResource.GetText(
                        StringResource.TextType.Main_Menu_Operation_FileSystem_UploadFolder);
                UpLoadFolderStripButton.Text = UploadFolderToolStripMenuItem.Text;

                DownloadFileToolStripMenuItem.Text =
                    SystemManager.mStringResource.GetText(
                        StringResource.TextType.Main_Menu_Operation_FileSystem_Download);
                DownloadFileStripButton.Text = DownloadFileToolStripMenuItem.Text;

                OpenFileToolStripMenuItem.Text =
                    SystemManager.mStringResource.GetText(
                        StringResource.TextType.Main_Menu_Operation_FileSystem_OpenFile);
                OpenFileStripButton.Text = OpenFileToolStripMenuItem.Text;
            }
            UploadFileStripButton.Enabled = true;
            UploadFileToolStripMenuItem.Enabled = true;

            UpLoadFolderStripButton.Enabled = true;
            UploadFolderToolStripMenuItem.Enabled = true;

            cmbListViewStyle.Visible = true;
            cmbListViewStyle.SelectedIndexChanged += (x, y) => { lstData.View = (View) cmbListViewStyle.SelectedIndex; };
        }

        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {
            //文件系统
            UploadFileToolStripMenuItem.Enabled = true;
            UploadFileStripButton.Enabled = true;

            UpLoadFolderStripButton.Enabled = true;
            UploadFolderToolStripMenuItem.Enabled = true;
            switch (lstData.SelectedItems.Count)
            {
                case 0:
                    //禁止所有操作
                    OpenFileStripButton.Enabled = false;
                    OpenFileToolStripMenuItem.Enabled = false;

                    DownloadFileToolStripMenuItem.Enabled = false;
                    DownloadFileStripButton.Enabled = false;

                    DeleteFileStripButton.Enabled = false;
                    DeleteFileToolStripMenuItem.Enabled = false;

                    lstData.ContextMenuStrip = null;
                    break;
                case 1:
                    //可以进行所有操作
                    OpenFileStripButton.Enabled = true;
                    OpenFileToolStripMenuItem.Enabled = true;
                    DownloadFileToolStripMenuItem.Enabled = true;
                    DownloadFileStripButton.Enabled = true;
                    if (!mDataViewInfo.IsReadOnly)
                    {
                        DeleteFileStripButton.Enabled = true;
                        DeleteFileToolStripMenuItem.Enabled = true;
                    }
                    break;
                default:
                    //可以删除多个文件
                    OpenFileStripButton.Enabled = false;
                    OpenFileToolStripMenuItem.Enabled = false;

                    DownloadFileToolStripMenuItem.Enabled = false;
                    DownloadFileStripButton.Enabled = false;
                    if (!mDataViewInfo.IsReadOnly)
                    {
                        DeleteFileStripButton.Enabled = true;
                        DeleteFileToolStripMenuItem.Enabled = true;
                    }
                    break;
            }
        }

        protected void lstData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFileStripButton_Click(sender, e);
        }

        protected void lstData_MouseClick(object sender, MouseEventArgs e)
        {
            SystemManager.SelectObjectTag = mDataViewInfo.strDBTag;
            if (lstData.SelectedItems.Count > 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStripMain = new ContextMenuStrip();
                    contextMenuStripMain.Items.Add(OpenFileToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(UploadFileToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(UploadFolderToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(DownloadFileToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(DeleteFileToolStripMenuItem.Clone());
                    contextMenuStripMain.Show(lstData.PointToScreen(e.Location));
                }
            }
        }

        #region"管理：GFS"

        /// <summary>
        ///     Upload File
        /// </summary>
        private void UploadFileStripButton_Click(object sender, EventArgs e)
        {
            var upfile = new OpenFileDialog();
            var opt = new MongoDBHelper.UpLoadFileOption();
            if (upfile.ShowDialog() == DialogResult.OK)
            {
                var frm = new frmGFSOption();
                SystemManager.OpenForm(frm, false, true);
                opt.FileNameOpt = frm.filename;
                opt.AlreadyOpt = frm.option;
                opt.DirectorySeparatorChar = frm.DirectorySeparatorChar;
                frm.Dispose();
                MongoDBHelper.UpLoadFile(upfile.FileName, opt);
                RefreshGUI();
            }
        }

        /// <summary>
        ///     上传文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpLoadFolderStripButton_Click(object sender, EventArgs e)
        {
            var upfolder = new FolderBrowserDialog();
            var opt = new MongoDBHelper.UpLoadFileOption();
            if (upfolder.ShowDialog() == DialogResult.OK)
            {
                var frm = new frmGFSOption();
                SystemManager.OpenForm(frm, false, true);
                opt.FileNameOpt = frm.filename;
                opt.AlreadyOpt = frm.option;
                opt.IgnoreSubFolder = frm.ignoreSubFolder;
                opt.DirectorySeparatorChar = frm.DirectorySeparatorChar;
                frm.Dispose();
                var uploadDir = new DirectoryInfo(upfolder.SelectedPath);
                int count = 0;
                UploadFolder(uploadDir, ref count, opt);
                MyMessageBox.ShowMessage("Upload", "Upload Completed! Upload Files Count: " + count);
                RefreshGUI();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="uploadDir"></param>
        /// <param name="fileCount"></param>
        /// <param name="opt"></param>
        /// <returns>是否继续执行后续的所有操作</returns>
        private Boolean UploadFolder(DirectoryInfo uploadDir, ref int fileCount, MongoDBHelper.UpLoadFileOption opt)
        {
            foreach (FileInfo file in uploadDir.GetFiles())
            {
                MongoDBHelper.UploadResult rtn = MongoDBHelper.UpLoadFile(file.FullName, opt);
                switch (rtn)
                {
                    case MongoDBHelper.UploadResult.Complete:
                        fileCount++;
                        break;
                    case MongoDBHelper.UploadResult.Skip:
                        if (opt.AlreadyOpt == MongoDBHelper.enumGFSAlready.Stop)
                        {
                            ///这个操作返回为False，停止包括父亲过程在内的所有操作
                            return false;
                        }
                        break;
                    case MongoDBHelper.UploadResult.Exception:
                        return MyMessageBox.ShowConfirm("Upload Exception", "Is Continue?");
                    default:
                        break;
                }
            }
            if (!opt.IgnoreSubFolder)
            {
                foreach (DirectoryInfo dir in uploadDir.GetDirectories())
                {
                    ///递归文件夹操作，如果下层有任何停止的意愿，则立刻停止，并且使上层也立刻停止
                    Boolean IsContinue = UploadFolder(dir, ref fileCount, opt);
                    if (!IsContinue)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        ///     DownLoad File
        /// </summary>
        public void DownloadFileStripButton_Click(object sender, EventArgs e)
        {
            var downfile = new SaveFileDialog();
            String strFileName = lstData.SelectedItems[0].Text;
            //For Winodws,Linux user DirectorySeparatorChar Replace with @"\"
            downfile.FileName =
                strFileName.Split(Path.DirectorySeparatorChar)[strFileName.Split(Path.DirectorySeparatorChar).Length - 1
                    ];
            if (downfile.ShowDialog() == DialogResult.OK)
            {
                MongoDBHelper.DownloadFile(downfile.FileName, strFileName);
            }
            RefreshGUI();
        }

        /// <summary>
        ///     Open File
        /// </summary>
        private void OpenFileStripButton_Click(object sender, EventArgs e)
        {
            if (lstData.SelectedItems.Count == 1)
            {
                String strFileName = lstData.SelectedItems[0].Text;
                MongoDBHelper.OpenFile(strFileName);
            }
        }

        /// <summary>
        ///     Delete File
        /// </summary>
        public void DeleteFileStripButton_Click(object sender, EventArgs e)
        {
            String strTitle = "Delete Files";
            String strMessage = "Are you sure to delete selected File(s)?";
            if (!SystemManager.IsUseDefaultLanguage)
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                foreach (ListViewItem item in lstData.SelectedItems)
                {
                    MongoDBHelper.DelFile(item.Text);
                }
                RefreshGUI();
            }
        }

        #endregion
    }
}