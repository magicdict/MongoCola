using System.Windows.Forms;
namespace MagicMongoDBTool
{
    partial class ctlGFSView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UploadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UploadFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteFileStripButton = new System.Windows.Forms.ToolStripButton();
            this.DownloadFileStripButton = new System.Windows.Forms.ToolStripButton();
            this.UpLoadFolderStripButton = new System.Windows.Forms.ToolStripButton();
            this.UploadFileStripButton = new System.Windows.Forms.ToolStripButton();
            this.OpenFileStripButton = new System.Windows.Forms.ToolStripButton();
            this.tabDataShower.SuspendLayout();
            this.tabTreeView.SuspendLayout();
            this.tabTableView.SuspendLayout();
            this.tabTextView.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstData
            // 
            this.lstData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstData_MouseDoubleClick);
            this.lstData.SelectedIndexChanged += new System.EventHandler(this.lstData_SelectedIndexChanged);
            // 
            // OpenFileToolStripMenuItem
            // 
            this.OpenFileToolStripMenuItem.Image = global::MagicMongoDBTool.Properties.Resources.OpenFile;
            this.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
            this.OpenFileToolStripMenuItem.Size = new System.Drawing.Size(80, 25);
            this.OpenFileToolStripMenuItem.Text = "Open File";
            // 
            // UploadFileToolStripMenuItem
            // 
            this.UploadFileToolStripMenuItem.Image = global::MagicMongoDBTool.Properties.Resources.UpLoadFile;
            this.UploadFileToolStripMenuItem.Name = "UploadFileToolStripMenuItem";
            this.UploadFileToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.UploadFileToolStripMenuItem.Text = "Upload File";
            // 
            // UploadFolderToolStripMenuItem
            // 
            this.UploadFolderToolStripMenuItem.Image = global::MagicMongoDBTool.Properties.Resources.UploadFolder;
            this.UploadFolderToolStripMenuItem.Name = "UploadFolderToolStripMenuItem";
            this.UploadFolderToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.UploadFolderToolStripMenuItem.Text = "UploadFolder";
            // 
            // DownloadFileToolStripMenuItem
            // 
            this.DownloadFileToolStripMenuItem.Image = global::MagicMongoDBTool.Properties.Resources.DownloadFile;
            this.DownloadFileToolStripMenuItem.Name = "DownloadFileToolStripMenuItem";
            this.DownloadFileToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.DownloadFileToolStripMenuItem.Text = "Download File";
            // 
            // DeleteFileToolStripMenuItem
            // 
            this.DeleteFileToolStripMenuItem.Image = global::MagicMongoDBTool.Properties.Resources.delete_file;
            this.DeleteFileToolStripMenuItem.Name = "DeleteFileToolStripMenuItem";
            this.DeleteFileToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.DeleteFileToolStripMenuItem.Text = "Delete File";
            // 
            // DeleteFileStripButton
            // 
            this.DeleteFileStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteFileStripButton.Image = global::MagicMongoDBTool.Properties.Resources.delete_file;
            this.DeleteFileStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteFileStripButton.Name = "DeleteFileStripButton";
            this.DeleteFileStripButton.Size = new System.Drawing.Size(23, 22);
            this.DeleteFileStripButton.Text = "Delete File";
            // 
            // DownloadFileStripButton
            // 
            this.DownloadFileStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DownloadFileStripButton.Image = global::MagicMongoDBTool.Properties.Resources.DownloadFile;
            this.DownloadFileStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DownloadFileStripButton.Name = "DownloadFileStripButton";
            this.DownloadFileStripButton.Size = new System.Drawing.Size(23, 22);
            this.DownloadFileStripButton.Text = "Download File";
            // 
            // UpLoadFolderStripButton
            // 
            this.UpLoadFolderStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UpLoadFolderStripButton.Image = global::MagicMongoDBTool.Properties.Resources.UploadFolder;
            this.UpLoadFolderStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpLoadFolderStripButton.Name = "UpLoadFolderStripButton";
            this.UpLoadFolderStripButton.Size = new System.Drawing.Size(23, 22);
            this.UpLoadFolderStripButton.Text = "UpLoad Folder";
            this.UpLoadFolderStripButton.Click += new System.EventHandler(this.UpLoadFolderStripButton_Click);
            // 
            // UploadFileStripButton
            // 
            this.UploadFileStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UploadFileStripButton.Image = global::MagicMongoDBTool.Properties.Resources.UpLoadFile;
            this.UploadFileStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UploadFileStripButton.Name = "UploadFileStripButton";
            this.UploadFileStripButton.Size = new System.Drawing.Size(23, 22);
            this.UploadFileStripButton.Text = "UpLoad File";
            this.UploadFileStripButton.Click += new System.EventHandler(this.UploadFileStripButton_Click);
            // 
            // OpenFileStripButton
            // 
            this.OpenFileStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenFileStripButton.Image = global::MagicMongoDBTool.Properties.Resources.OpenFile;
            this.OpenFileStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenFileStripButton.Name = "OpenFileStripButton";
            this.OpenFileStripButton.Size = new System.Drawing.Size(23, 22);
            this.OpenFileStripButton.Text = "Open File";
            this.OpenFileStripButton.Click += new System.EventHandler(this.OpenFileStripButton_Click);


            this.ViewtoolStrip.Items.Insert(0, DeleteFileStripButton);
            this.ViewtoolStrip.Items.Insert(0, DownloadFileStripButton);
            this.ViewtoolStrip.Items.Insert(0, UpLoadFolderStripButton);
            this.ViewtoolStrip.Items.Insert(0, UploadFileStripButton);
            this.ViewtoolStrip.Items.Insert(0, OpenFileStripButton);


            // 
            // ctlGFSView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsDataView = false;
            this.Name = "ctlGFSView";
            this.Controls.SetChildIndex(this.tabDataShower, 0);
            this.tabDataShower.ResumeLayout(false);
            this.tabTreeView.ResumeLayout(false);
            this.tabTableView.ResumeLayout(false);
            this.tabTextView.ResumeLayout(false);
            this.tabTextView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitTool() {
            this.ViewtoolStrip.Items.Insert(0, DeleteFileStripButton);
            this.ViewtoolStrip.Items.Insert(0,DownloadFileStripButton);
            this.ViewtoolStrip.Items.Insert(0, UpLoadFolderStripButton);
            this.ViewtoolStrip.Items.Insert(0, UploadFileStripButton);
            this.ViewtoolStrip.Items.Insert(0,OpenFileStripButton);
        }
        #endregion


        private ToolStripMenuItem OpenFileToolStripMenuItem;
        private ToolStripMenuItem UploadFileToolStripMenuItem;
        private ToolStripMenuItem UploadFolderToolStripMenuItem;
        private ToolStripMenuItem DownloadFileToolStripMenuItem;
        private ToolStripMenuItem DeleteFileToolStripMenuItem;

        private ToolStripButton OpenFileStripButton;
        private ToolStripButton UploadFileStripButton;
        private ToolStripButton UpLoadFolderStripButton;
        private ToolStripButton DownloadFileStripButton;
        private ToolStripButton DeleteFileStripButton;

    }
}
