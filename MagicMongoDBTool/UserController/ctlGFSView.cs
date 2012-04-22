using System;
using System.IO;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class ctlGFSView : UserController.ctlDataView
    {
        public ctlGFSView(MongoDBHelper.DataViewInfo _DataViewInfo)
        {
            InitializeComponent();
            InitTool();
            mDataViewInfo = _DataViewInfo;
        }
        private void ctlGFSView_Load(object sender, EventArgs e)
        {

            OpenFileToolStripMenuItem.Click += new EventHandler(OpenFileStripButton_Click);
            DownloadFileToolStripMenuItem.Click += new EventHandler(DownloadFileStripButton_Click);
            UploadFileToolStripMenuItem.Click += new EventHandler(UploadFileStripButton_Click);
            UploadFolderToolStripMenuItem.Click += new EventHandler(UpLoadFolderStripButton_Click);
            DeleteFileToolStripMenuItem.Click += new EventHandler(DeleteFileStripButton_Click);

            if (!SystemManager.IsUseDefaultLanguage())
            {
                this.DeleteFileToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_DelFile);
                this.DeleteFileStripButton.Text = this.DeleteFileToolStripMenuItem.Text;

                this.UploadFileToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_UploadFile);
                this.UploadFileStripButton.Text = this.UploadFileToolStripMenuItem.Text;

                this.UploadFolderToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_UploadFolder);
                this.UpLoadFolderStripButton.Text = this.UploadFolderToolStripMenuItem.Text;

                this.DownloadFileToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_Download);
                this.DownloadFileStripButton.Text = this.DownloadFileToolStripMenuItem.Text;

                this.OpenFileToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_OpenFile);
                this.OpenFileStripButton.Text = this.OpenFileToolStripMenuItem.Text;
            }
            UploadFileStripButton.Enabled = true;
            UploadFileToolStripMenuItem.Enabled = true;

            UpLoadFolderStripButton.Enabled = true;
            UploadFolderToolStripMenuItem.Enabled = true;

            cmbListViewStyle.Visible = true;
            this.cmbListViewStyle.SelectedIndexChanged += new EventHandler(
                (x, y) =>
                {
                    lstData.View = (View)cmbListViewStyle.SelectedIndex;
                }
           );
        }
        #region"管理：GFS"
        /// <summary>
        /// Upload File
        /// </summary>
        private void UploadFileStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog upfile = new OpenFileDialog();
            MongoDBHelper.UpLoadFileOption opt = new MongoDBHelper.UpLoadFileOption();
            if (upfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                frmGFSOption frm = new frmGFSOption();
                SystemManager.OpenForm(frm, false);
                opt.FileNameOpt = frm.filename;
                opt.AlreadyOpt = frm.option;
                opt.DirectorySeparatorChar = frm.DirectorySeparatorChar;
                frm.Dispose();
                MongoDBHelper.UpLoadFile(upfile.FileName, opt);
                RefreshGUI();
            }
        }
        /// <summary>
        /// 上传文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpLoadFolderStripButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog upfolder = new FolderBrowserDialog();
            MongoDBHelper.UpLoadFileOption opt = new MongoDBHelper.UpLoadFileOption();
            if (upfolder.ShowDialog() == DialogResult.OK)
            {
                frmGFSOption frm = new frmGFSOption();
                SystemManager.OpenForm(frm, false);
                opt.FileNameOpt = frm.filename;
                opt.AlreadyOpt = frm.option;
                opt.IgnoreSubFolder = frm.ignoreSubFolder;
                opt.DirectorySeparatorChar = frm.DirectorySeparatorChar;
                frm.Dispose();
                DirectoryInfo uploadDir = new DirectoryInfo(upfolder.SelectedPath);
                int count = 0;
                UploadFolder(uploadDir, ref count, opt);
                MyMessageBox.ShowMessage("Upload", "Upload Completed! Upload Files Count: " + count.ToString());
                RefreshGUI();
            }
        }
        /// <summary>
        /// 
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
                    if (!IsContinue) { return false; }
                }
            }
            return true;
        }
        /// <summary>
        /// DownLoad File
        /// </summary>
        public void DownloadFileStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog downfile = new SaveFileDialog();
            String strFileName = lstData.SelectedItems[0].Text;
            //For Winodws,Linux user DirectorySeparatorChar Replace with @"\"
            downfile.FileName = strFileName.Split(System.IO.Path.DirectorySeparatorChar)[strFileName.Split(System.IO.Path.DirectorySeparatorChar).Length - 1];
            if (downfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDBHelper.DownloadFile(downfile.FileName, strFileName);
            }
            RefreshGUI();
        }
        /// <summary>
        /// Open File
        /// </summary>
        private void OpenFileStripButton_Click(object sender, EventArgs e)
        {
            String strFileName = lstData.SelectedItems[0].Text;
            MongoDBHelper.OpenFile(strFileName);
        }
        /// <summary>
        /// Delete File
        /// </summary>
        public void DeleteFileStripButton_Click(object sender, EventArgs e)
        {
            String strTitle = "Delete Files";
            String strMessage = "Are you sure to delete selected File(s)?";
            if (!SystemManager.IsUseDefaultLanguage())
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

        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {

            //文件系统
            this.UploadFileToolStripMenuItem.Enabled = true;
            this.UploadFileStripButton.Enabled = true;

            this.UpLoadFolderStripButton.Enabled = true;
            this.UploadFolderToolStripMenuItem.Enabled = true;
            switch (lstData.SelectedItems.Count)
            {
                case 0:
                    //禁止所有操作
                    this.OpenFileStripButton.Enabled = false;
                    this.OpenFileToolStripMenuItem.Enabled = false;

                    this.DownloadFileToolStripMenuItem.Enabled = false;
                    this.DownloadFileStripButton.Enabled = false;

                    this.DeleteFileStripButton.Enabled = false;
                    this.DeleteFileToolStripMenuItem.Enabled = false;

                    lstData.ContextMenuStrip = null;
                    break;
                case 1:
                    //可以进行所有操作
                    this.OpenFileStripButton.Enabled = true;
                    this.OpenFileToolStripMenuItem.Enabled = true;
                    this.DownloadFileToolStripMenuItem.Enabled = true;
                    this.DownloadFileStripButton.Enabled = true;
                    if (!mDataViewInfo.IsReadOnly)
                    {
                        this.DeleteFileStripButton.Enabled = true;
                        this.DeleteFileToolStripMenuItem.Enabled = true;
                    }
                    break;
                default:
                    //可以删除多个文件
                    this.OpenFileStripButton.Enabled = false;
                    this.OpenFileToolStripMenuItem.Enabled = false;

                    this.DownloadFileToolStripMenuItem.Enabled = false;
                    this.DownloadFileStripButton.Enabled = false;
                    if (!mDataViewInfo.IsReadOnly)
                    {
                        this.DeleteFileStripButton.Enabled = true;
                        this.DeleteFileToolStripMenuItem.Enabled = true;
                    }
                    break;

            }
        }

        protected override void lstData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFileStripButton_Click(sender, e);
        }

        protected override void lstData_MouseClick(object sender, MouseEventArgs e)
        {
            SystemManager.SelectObjectTag = mDataViewInfo.strDBTag;
            if (lstData.SelectedItems.Count > 0)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this.contextMenuStripMain = new ContextMenuStrip();
                    this.contextMenuStripMain.Items.Add(this.OpenFileToolStripMenuItem.Clone());
                    this.contextMenuStripMain.Items.Add(this.UploadFileToolStripMenuItem.Clone());
                    this.contextMenuStripMain.Items.Add(this.UploadFolderToolStripMenuItem.Clone());
                    this.contextMenuStripMain.Items.Add(this.DownloadFileToolStripMenuItem.Clone());
                    this.contextMenuStripMain.Items.Add(this.DeleteFileToolStripMenuItem.Clone());
                    contextMenuStripMain.Show(lstData.PointToScreen(e.Location));
                }
            }
        }


    }
}
