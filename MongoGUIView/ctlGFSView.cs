using System;
using System.IO;
using System.Windows.Forms;
using MongoUtility.Aggregation;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.UI;

namespace MongoGUIView
{
    public partial class CtlGfsView : CtlDataView
    {
        public CtlGfsView(DataViewInfo dataViewInfo)
        {
            InitializeComponent();
            InitTool();
            mDataViewInfo = dataViewInfo;
            DataShower.Add(lstData);
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                DeleteFileToolStripMenuItem.Text = GuiConfig.GetText("MainMenu.OperationFileSystemDelFile");
                DeleteFileStripButton.Text = DeleteFileToolStripMenuItem.Text;

                UploadFileToolStripMenuItem.Text = GuiConfig.GetText("MainMenu.OperationFileSystemUploadFile");
                UploadFileStripButton.Text = UploadFileToolStripMenuItem.Text;

                UploadFolderToolStripMenuItem.Text =
                    GuiConfig.GetText("MainMenu.OperationFileSystemUploadFolder");
                UpLoadFolderStripButton.Text = UploadFolderToolStripMenuItem.Text;

                DownloadFileToolStripMenuItem.Text = GuiConfig.GetText("MainMenu.OperationFileSystemDownload");
                DownloadFileStripButton.Text = DownloadFileToolStripMenuItem.Text;

                OpenFileToolStripMenuItem.Text = GuiConfig.GetText("MainMenu.OperationFileSystemOpenFile");
                OpenFileStripButton.Text = OpenFileToolStripMenuItem.Text;
            }
        }

        private void ctlGFSView_Load(object sender, EventArgs e)
        {

            lstData.AllowDrop = true;
            tabDataShower.AllowDrop = true;
            AllowDrop = true;

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
            cmbListViewStyle.SelectedIndexChanged += (x, y) => { lstData.View = (View)cmbListViewStyle.SelectedIndex; };
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

        /// <summary>
        ///     双击操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lstData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFileStripButton_Click(sender, e);
        }


        public static Func<Gfs.UpLoadFileOption> GetUploadFileOption;

        /// <summary>
        ///     拖曳终止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstData_DragDrop(object sender, DragEventArgs e)
        {
            Array UploadfileList = (Array)e.Data.GetData(DataFormats.FileDrop);
            if (!MyMessageBox.ShowConfirm("UploadFile", "是否上传" + UploadfileList.Length + "个文件")) return;
            var opt = GetUploadFileOption();
            var count = 0;
            foreach (string UploadFilename in UploadfileList)
            {
                if (File.Exists(UploadFilename))
                {
                    Gfs.UpLoadFile(UploadFilename, opt, RuntimeMongoDbContext.GetCurrentDataBase());
                    count++;
                }
                else
                {
                    if (Directory.Exists(UploadFilename))
                    {
                        var uploadDir = new DirectoryInfo(UploadFilename);
                        UploadFolder(uploadDir, ref count, opt);
                    }
                }
            }
            RefreshGui();
            MyMessageBox.ShowMessage("Upload", "Upload Completed! Upload Files Count: " + count);
        }
        
        /// <summary>
        ///     开始拖曳
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstData_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        protected void lstData_MouseClick(object sender, MouseEventArgs e)
        {
            RuntimeMongoDbContext.SelectObjectTag = mDataViewInfo.strCollectionPath;
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
                var opt = GetUploadFileOption();
                Gfs.UpLoadFile(upfile.FileName, opt, RuntimeMongoDbContext.GetCurrentDataBase());
                RefreshGui();
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
                var opt = GetUploadFileOption();
                var uploadDir = new DirectoryInfo(upfolder.SelectedPath);
                var count = 0;
                UploadFolder(uploadDir, ref count, opt);
                MyMessageBox.ShowMessage("Upload", "Upload Completed! Upload Files Count: " + count);
                RefreshGui();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="uploadDir"></param>
        /// <param name="fileCount"></param>
        /// <param name="opt"></param>
        /// <returns>是否继续执行后续的所有操作</returns>
        private bool UploadFolder(DirectoryInfo uploadDir, ref int fileCount, Gfs.UpLoadFileOption opt)
        {
            foreach (var file in uploadDir.GetFiles())
            {
                var rtn = Gfs.UpLoadFile(file.FullName, opt, RuntimeMongoDbContext.GetCurrentDataBase());
                switch (rtn)
                {
                    case Gfs.UploadResult.Complete:
                        fileCount++;
                        break;
                    case Gfs.UploadResult.Skip:
                        if (opt.AlreadyOpt == Gfs.EnumGfsAlready.Stop)
                        {
                            //这个操作返回为False，停止包括父亲过程在内的所有操作
                            return false;
                        }
                        break;
                    case Gfs.UploadResult.Exception:
                        return MyMessageBox.ShowConfirm("Upload Exception", "Is Continue?");
                }
            }
            if (!opt.IgnoreSubFolder)
            {
                foreach (var dir in uploadDir.GetDirectories())
                {
                    //递归文件夹操作，如果下层有任何停止的意愿，则立刻停止，并且使上层也立刻停止
                    var isContinue = UploadFolder(dir, ref fileCount, opt);
                    if (!isContinue)
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
                Gfs.DownloadFile(downfile.FileName, strFileName, RuntimeMongoDbContext.GetCurrentDataBase());
            }
            RefreshGui();
        }

        /// <summary>
        ///     Open File
        /// </summary>
        private void OpenFileStripButton_Click(object sender, EventArgs e)
        {
            if (lstData.SelectedItems.Count == 1)
            {
                var strFileName = lstData.SelectedItems[0].Text;
                Gfs.OpenFile(strFileName, RuntimeMongoDbContext.GetCurrentDataBase());
            }
            else
            {
                MessageBox.Show("请选择一个文件");
            }
        }

        /// <summary>
        ///     Delete File
        /// </summary>
        public void DeleteFileStripButton_Click(object sender, EventArgs e)
        {
            var strTitle = GuiConfig.GetText("Delete Files", "DropData");
            var strMessage = GuiConfig.GetText("Are you sure to delete selected File(s)?", "DropDataConfirm");
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                foreach (ListViewItem item in lstData.SelectedItems)
                {
                    Gfs.DelFile(item.Text, RuntimeMongoDbContext.GetCurrentDataBase());
                }
                RefreshGui();
            }
        }

        #endregion


    }
}