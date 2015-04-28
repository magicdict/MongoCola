using System;
using System.IO;
using System.Windows.Forms;
using Common.Logic;
using Common.UI;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;
using ResourceLib;

namespace MongoGUIView
{
    public partial class ctlGFSView : ctlDataView
    {
        public ctlGFSView(DataViewInfo _DataViewInfo)
        {
            InitializeComponent();
            InitTool();
            mDataViewInfo = _DataViewInfo;
            _dataShower.Add(lstData);
            if (!GUIConfig.IsUseDefaultLanguage)
            {
                DeleteFileToolStripMenuItem.Text =
                    GUIConfig.MStringResource.GetText(
                        "Main_Menu_Operation_FileSystem_DelFile");
                DeleteFileStripButton.Text = DeleteFileToolStripMenuItem.Text;

                UploadFileToolStripMenuItem.Text =
                    GUIConfig.MStringResource.GetText(
                        "Main_Menu_Operation_FileSystem_UploadFile");
                UploadFileStripButton.Text = UploadFileToolStripMenuItem.Text;

                UploadFolderToolStripMenuItem.Text =
                    GUIConfig.MStringResource.GetText(
                        "Main_Menu_Operation_FileSystem_UploadFolder");
                UpLoadFolderStripButton.Text = UploadFolderToolStripMenuItem.Text;

                DownloadFileToolStripMenuItem.Text =
                    GUIConfig.MStringResource.GetText(
                        "Main_Menu_Operation_FileSystem_Download");
                DownloadFileStripButton.Text = DownloadFileToolStripMenuItem.Text;

                OpenFileToolStripMenuItem.Text =
                    GUIConfig.MStringResource.GetText(
                        "Main_Menu_Operation_FileSystem_OpenFile");
                OpenFileStripButton.Text = OpenFileToolStripMenuItem.Text;
            }
        }

        private void ctlGFSView_Load(object sender, EventArgs e)
        {
            OpenFileToolStripMenuItem.Click += OpenFileStripButton_Click;
            DownloadFileToolStripMenuItem.Click += DownloadFileStripButton_Click;
            UploadFileToolStripMenuItem.Click += UploadFileStripButton_Click;
            UploadFolderToolStripMenuItem.Click += UpLoadFolderStripButton_Click;
            DeleteFileToolStripMenuItem.Click += DeleteFileStripButton_Click;


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
            RuntimeMongoDBContext.SelectObjectTag = mDataViewInfo.strDBTag;
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
            if (upfile.ShowDialog() == DialogResult.OK)
            {
                var opt = new GFS.UpLoadFileOption();
                var frm = new frmGFSOption();
                frm.ShowDialog();
                opt.AlreadyOpt = frm.option;
                opt.DirectorySeparatorChar = frm.DirectorySeparatorChar;
                opt.FileNameOpt = frm.filename;
                opt.IgnoreSubFolder = frm.ignoreSubFolder;
                GFS.UpLoadFile(upfile.FileName, opt, null);
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
            if (upfolder.ShowDialog() == DialogResult.OK)
            {
                var opt = new GFS.UpLoadFileOption();
                var frm = new frmGFSOption();
                frm.ShowDialog();
                opt.AlreadyOpt = frm.option;
                opt.DirectorySeparatorChar = frm.DirectorySeparatorChar;
                opt.FileNameOpt = frm.filename;
                opt.IgnoreSubFolder = frm.ignoreSubFolder;
                var uploadDir = new DirectoryInfo(upfolder.SelectedPath);
                var count = 0;
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
        private bool UploadFolder(DirectoryInfo uploadDir, ref int fileCount, GFS.UpLoadFileOption opt)
        {
            foreach (var file in uploadDir.GetFiles())
            {
                var rtn = GFS.UpLoadFile(file.FullName, opt, RuntimeMongoDBContext.GetCurrentDataBase());
                switch (rtn)
                {
                    case GFS.UploadResult.Complete:
                        fileCount++;
                        break;
                    case GFS.UploadResult.Skip:
                        if (opt.AlreadyOpt == GFS.enumGFSAlready.Stop)
                        {
                            //这个操作返回为False，停止包括父亲过程在内的所有操作
                            return false;
                        }
                        break;
                    case GFS.UploadResult.Exception:
                        return MyMessageBox.ShowConfirm("Upload Exception", "Is Continue?");
                }
            }
            if (!opt.IgnoreSubFolder)
            {
                foreach (var dir in uploadDir.GetDirectories())
                {
                    //递归文件夹操作，如果下层有任何停止的意愿，则立刻停止，并且使上层也立刻停止
                    var IsContinue = UploadFolder(dir, ref fileCount, opt);
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
            var strFileName = lstData.SelectedItems[0].Text;
            //For Winodws,Linux user DirectorySeparatorChar Replace with @"\"
            downfile.FileName =
                strFileName.Split(Path.DirectorySeparatorChar)[strFileName.Split(Path.DirectorySeparatorChar).Length - 1
                    ];
            if (downfile.ShowDialog() == DialogResult.OK)
            {
                GFS.DownloadFile(downfile.FileName, strFileName, null);
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
                var strFileName = lstData.SelectedItems[0].Text;
                GFS.OpenFile(strFileName, null);
            }
        }

        /// <summary>
        ///     Delete File
        /// </summary>
        public void DeleteFileStripButton_Click(object sender, EventArgs e)
        {
            var strTitle = "Delete Files";
            var strMessage = "Are you sure to delete selected File(s)?";
            if (!GUIConfig.IsUseDefaultLanguage)
            {
                strTitle = GUIConfig.MStringResource.GetText(TextType.Drop_Data);
                strMessage = GUIConfig.MStringResource.GetText(TextType.Drop_Data_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                foreach (ListViewItem item in lstData.SelectedItems)
                {
                    GFS.DelFile(item.Text, null);
                }
                RefreshGUI();
            }
        }

        #endregion
    }
}