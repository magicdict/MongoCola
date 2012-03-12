using System.Windows.Forms;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool.UserController
{
    partial class ctlDataView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlDataView));
            this.tabDataShower = new System.Windows.Forms.TabControl();
            this.tabTreeView = new System.Windows.Forms.TabPage();
            this.trvData = new System.Windows.Forms.TreeView();
            this.tabTableView = new System.Windows.Forms.TabPage();
            this.lstData = new System.Windows.Forms.ListView();
            this.tabTextView = new System.Windows.Forms.TabPage();
            this.txtData = new System.Windows.Forms.TextBox();
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DataDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelSelectRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DropElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifyElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.UploadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.RemoveUserFromAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewtoolStrip = new System.Windows.Forms.ToolStrip();
            this.NewDocumentStripButton = new System.Windows.Forms.ToolStripButton();
            this.EditDocStripButton = new System.Windows.Forms.ToolStripButton();
            this.DelSelectRecordToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.FirstPageStripButton = new System.Windows.Forms.ToolStripButton();
            this.PrePageStripButton = new System.Windows.Forms.ToolStripButton();
            this.NextPageStripButton = new System.Windows.Forms.ToolStripButton();
            this.LastPageStripButton = new System.Windows.Forms.ToolStripButton();
            this.ExpandAllStripButton = new System.Windows.Forms.ToolStripButton();
            this.CollapseAllStripButton = new System.Windows.Forms.ToolStripButton();
            this.QueryStripButton = new System.Windows.Forms.ToolStripButton();
            this.FilterStripButton = new System.Windows.Forms.ToolStripButton();
            this.DataNaviToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshStripButton = new System.Windows.Forms.ToolStripButton();
            this.CloseStripButton = new System.Windows.Forms.ToolStripButton();
            this.tabDataShower.SuspendLayout();
            this.tabTreeView.SuspendLayout();
            this.tabTableView.SuspendLayout();
            this.tabTextView.SuspendLayout();
            this.contextMenuStripMain.SuspendLayout();
            this.ViewtoolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDataShower
            // 
            this.tabDataShower.Controls.Add(this.tabTreeView);
            this.tabDataShower.Controls.Add(this.tabTableView);
            this.tabDataShower.Controls.Add(this.tabTextView);
            this.tabDataShower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDataShower.Location = new System.Drawing.Point(0, 25);
            this.tabDataShower.Name = "tabDataShower";
            this.tabDataShower.SelectedIndex = 0;
            this.tabDataShower.Size = new System.Drawing.Size(688, 453);
            this.tabDataShower.TabIndex = 1;
            // 
            // tabTreeView
            // 
            this.tabTreeView.BackColor = System.Drawing.Color.Orange;
            this.tabTreeView.Controls.Add(this.trvData);
            this.tabTreeView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabTreeView.Location = new System.Drawing.Point(4, 22);
            this.tabTreeView.Name = "tabTreeView";
            this.tabTreeView.Padding = new System.Windows.Forms.Padding(3);
            this.tabTreeView.Size = new System.Drawing.Size(680, 427);
            this.tabTreeView.TabIndex = 0;
            this.tabTreeView.Text = "TreeView";
            // 
            // trvData
            // 
            this.trvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvData.Location = new System.Drawing.Point(3, 3);
            this.trvData.Name = "trvData";
            this.trvData.Size = new System.Drawing.Size(674, 421);
            this.trvData.TabIndex = 0;
            // 
            // tabTableView
            // 
            this.tabTableView.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tabTableView.Controls.Add(this.lstData);
            this.tabTableView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabTableView.Location = new System.Drawing.Point(4, 22);
            this.tabTableView.Name = "tabTableView";
            this.tabTableView.Padding = new System.Windows.Forms.Padding(3);
            this.tabTableView.Size = new System.Drawing.Size(680, 427);
            this.tabTableView.TabIndex = 1;
            this.tabTableView.Text = "TableView";
            // 
            // lstData
            // 
            this.lstData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstData.FullRowSelect = true;
            this.lstData.GridLines = true;
            this.lstData.HideSelection = false;
            this.lstData.Location = new System.Drawing.Point(3, 3);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(674, 421);
            this.lstData.TabIndex = 1;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.Details;
            // 
            // tabTextView
            // 
            this.tabTextView.BackColor = System.Drawing.Color.Yellow;
            this.tabTextView.Controls.Add(this.txtData);
            this.tabTextView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabTextView.Location = new System.Drawing.Point(4, 22);
            this.tabTextView.Name = "tabTextView";
            this.tabTextView.Padding = new System.Windows.Forms.Padding(3);
            this.tabTextView.Size = new System.Drawing.Size(680, 427);
            this.tabTextView.TabIndex = 2;
            this.tabTextView.Text = "TextView";
            // 
            // txtData
            // 
            this.txtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtData.Location = new System.Drawing.Point(3, 3);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtData.Size = new System.Drawing.Size(674, 421);
            this.txtData.TabIndex = 0;
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataDocumentToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(123, 26);
            // 
            // DataDocumentToolStripMenuItem
            // 
            this.DataDocumentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddDocumentToolStripMenuItem,
            this.DelSelectRecordToolStripMenuItem,
            this.toolStripSeparator1,
            this.AddElementToolStripMenuItem,
            this.DropElementToolStripMenuItem,
            this.ModifyElementToolStripMenuItem,
            this.toolStripMenuItem1,
            this.CopyElementToolStripMenuItem,
            this.CutElementToolStripMenuItem,
            this.PasteElementToolStripMenuItem,
            this.toolStripMenuItem3,
            this.UploadFileToolStripMenuItem,
            this.DownloadFileToolStripMenuItem,
            this.OpenFileToolStripMenuItem,
            this.DelFileToolStripMenuItem,
            this.toolStripMenuItem2,
            this.RemoveUserFromAdminToolStripMenuItem,
            this.RemoveUserToolStripMenuItem});
            this.DataDocumentToolStripMenuItem.Name = "DataDocumentToolStripMenuItem";
            this.DataDocumentToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.DataDocumentToolStripMenuItem.Text = "Document";
            // 
            // AddDocumentToolStripMenuItem
            // 
            this.AddDocumentToolStripMenuItem.Name = "AddDocumentToolStripMenuItem";
            this.AddDocumentToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.AddDocumentToolStripMenuItem.Text = "Add Document";
            // 
            // DelSelectRecordToolStripMenuItem
            // 
            this.DelSelectRecordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DelSelectRecordToolStripMenuItem.Image")));
            this.DelSelectRecordToolStripMenuItem.Name = "DelSelectRecordToolStripMenuItem";
            this.DelSelectRecordToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.DelSelectRecordToolStripMenuItem.Text = "Del Selected Records";
            this.DelSelectRecordToolStripMenuItem.Click += new System.EventHandler(this.DelSelectedRecord_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(194, 6);
            // 
            // AddElementToolStripMenuItem
            // 
            this.AddElementToolStripMenuItem.Name = "AddElementToolStripMenuItem";
            this.AddElementToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.AddElementToolStripMenuItem.Text = "Add Element";
            // 
            // DropElementToolStripMenuItem
            // 
            this.DropElementToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DropElementToolStripMenuItem.Image")));
            this.DropElementToolStripMenuItem.Name = "DropElementToolStripMenuItem";
            this.DropElementToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.DropElementToolStripMenuItem.Text = "Drop Element";
            // 
            // ModifyElementToolStripMenuItem
            // 
            this.ModifyElementToolStripMenuItem.Name = "ModifyElementToolStripMenuItem";
            this.ModifyElementToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.ModifyElementToolStripMenuItem.Text = "Modify Element";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 6);
            // 
            // CopyElementToolStripMenuItem
            // 
            this.CopyElementToolStripMenuItem.Name = "CopyElementToolStripMenuItem";
            this.CopyElementToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.CopyElementToolStripMenuItem.Text = "Copy Element";
            // 
            // CutElementToolStripMenuItem
            // 
            this.CutElementToolStripMenuItem.Name = "CutElementToolStripMenuItem";
            this.CutElementToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.CutElementToolStripMenuItem.Text = "Cut Element";
            // 
            // PasteElementToolStripMenuItem
            // 
            this.PasteElementToolStripMenuItem.Name = "PasteElementToolStripMenuItem";
            this.PasteElementToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.PasteElementToolStripMenuItem.Text = "Paste Element";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(194, 6);
            // 
            // UploadFileToolStripMenuItem
            // 
            this.UploadFileToolStripMenuItem.Name = "UploadFileToolStripMenuItem";
            this.UploadFileToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.UploadFileToolStripMenuItem.Text = "Upload File";
            // 
            // DownloadFileToolStripMenuItem
            // 
            this.DownloadFileToolStripMenuItem.Name = "DownloadFileToolStripMenuItem";
            this.DownloadFileToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.DownloadFileToolStripMenuItem.Text = "Download File";
            // 
            // OpenFileToolStripMenuItem
            // 
            this.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
            this.OpenFileToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.OpenFileToolStripMenuItem.Text = "Open File";
            // 
            // DelFileToolStripMenuItem
            // 
            this.DelFileToolStripMenuItem.Name = "DelFileToolStripMenuItem";
            this.DelFileToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.DelFileToolStripMenuItem.Text = "Delete File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(194, 6);
            // 
            // RemoveUserFromAdminToolStripMenuItem
            // 
            this.RemoveUserFromAdminToolStripMenuItem.Name = "RemoveUserFromAdminToolStripMenuItem";
            this.RemoveUserFromAdminToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.RemoveUserFromAdminToolStripMenuItem.Text = "Remove User From Admin";
            // 
            // RemoveUserToolStripMenuItem
            // 
            this.RemoveUserToolStripMenuItem.Name = "RemoveUserToolStripMenuItem";
            this.RemoveUserToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.RemoveUserToolStripMenuItem.Text = "Remove User";
            // 
            // ViewtoolStrip
            // 
            this.ViewtoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewDocumentStripButton,
            this.EditDocStripButton,
            this.DelSelectRecordToolStripButton,
            this.toolStripSeparator2,
            this.FirstPageStripButton,
            this.PrePageStripButton,
            this.NextPageStripButton,
            this.LastPageStripButton,
            this.ExpandAllStripButton,
            this.CollapseAllStripButton,
            this.QueryStripButton,
            this.FilterStripButton,
            this.DataNaviToolStripLabel,
            this.toolStripSeparator3,
            this.RefreshStripButton,
            this.CloseStripButton});
            this.ViewtoolStrip.Location = new System.Drawing.Point(0, 0);
            this.ViewtoolStrip.Name = "ViewtoolStrip";
            this.ViewtoolStrip.Size = new System.Drawing.Size(688, 25);
            this.ViewtoolStrip.TabIndex = 2;
            this.ViewtoolStrip.Text = "toolStrip1";
            // 
            // NewDocumentStripButton
            // 
            this.NewDocumentStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewDocumentStripButton.Image = global::MagicMongoDBTool.Properties.Resources.NewDocument;
            this.NewDocumentStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewDocumentStripButton.Name = "NewDocumentStripButton";
            this.NewDocumentStripButton.Size = new System.Drawing.Size(23, 22);
            this.NewDocumentStripButton.Text = "New Document";
            this.NewDocumentStripButton.Click += new System.EventHandler(this.NewDocumentStripButton_Click);
            // 
            // EditDocStripButton
            // 
            this.EditDocStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditDocStripButton.Image = global::MagicMongoDBTool.Properties.Resources.Edit;
            this.EditDocStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditDocStripButton.Name = "EditDocStripButton";
            this.EditDocStripButton.Size = new System.Drawing.Size(23, 22);
            this.EditDocStripButton.Text = "Editor";
            this.EditDocStripButton.Click += new System.EventHandler(this.EditDocStripButton_Click);
            // 
            // DelSelectRecordToolStripButton
            // 
            this.DelSelectRecordToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DelSelectRecordToolStripButton.Image = global::MagicMongoDBTool.Properties.Resources.DeleteDoc;
            this.DelSelectRecordToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelSelectRecordToolStripButton.Name = "DelSelectRecordToolStripButton";
            this.DelSelectRecordToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.DelSelectRecordToolStripButton.Text = "Delete Selected Record";
            this.DelSelectRecordToolStripButton.Click += new System.EventHandler(this.DelSelectedRecord_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // FirstPageStripButton
            // 
            this.FirstPageStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FirstPageStripButton.Image = ((System.Drawing.Image)(resources.GetObject("FirstPageStripButton.Image")));
            this.FirstPageStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FirstPageStripButton.Name = "FirstPageStripButton";
            this.FirstPageStripButton.Size = new System.Drawing.Size(23, 22);
            this.FirstPageStripButton.Text = "First Page";
            this.FirstPageStripButton.Click += new System.EventHandler(this.FirstPage_Click);
            // 
            // PrePageStripButton
            // 
            this.PrePageStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PrePageStripButton.Image = ((System.Drawing.Image)(resources.GetObject("PrePageStripButton.Image")));
            this.PrePageStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrePageStripButton.Name = "PrePageStripButton";
            this.PrePageStripButton.Size = new System.Drawing.Size(23, 22);
            this.PrePageStripButton.Text = "Previous Page";
            this.PrePageStripButton.Click += new System.EventHandler(this.PrePage_Click);
            // 
            // NextPageStripButton
            // 
            this.NextPageStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NextPageStripButton.Image = ((System.Drawing.Image)(resources.GetObject("NextPageStripButton.Image")));
            this.NextPageStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NextPageStripButton.Name = "NextPageStripButton";
            this.NextPageStripButton.Size = new System.Drawing.Size(23, 22);
            this.NextPageStripButton.Text = "Next Page";
            this.NextPageStripButton.Click += new System.EventHandler(this.NextPage_Click);
            // 
            // LastPageStripButton
            // 
            this.LastPageStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LastPageStripButton.Image = ((System.Drawing.Image)(resources.GetObject("LastPageStripButton.Image")));
            this.LastPageStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LastPageStripButton.Name = "LastPageStripButton";
            this.LastPageStripButton.Size = new System.Drawing.Size(23, 22);
            this.LastPageStripButton.Text = "Last Page";
            this.LastPageStripButton.Click += new System.EventHandler(this.LastPage_Click);
            // 
            // ExpandAllStripButton
            // 
            this.ExpandAllStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExpandAllStripButton.Image = global::MagicMongoDBTool.Properties.Resources.Expand;
            this.ExpandAllStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExpandAllStripButton.Name = "ExpandAllStripButton";
            this.ExpandAllStripButton.Size = new System.Drawing.Size(23, 22);
            this.ExpandAllStripButton.Text = "ExpandAll";
            this.ExpandAllStripButton.Click += new System.EventHandler(this.ExpandAll_Click);
            // 
            // CollapseAllStripButton
            // 
            this.CollapseAllStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CollapseAllStripButton.Image = global::MagicMongoDBTool.Properties.Resources.Collpse;
            this.CollapseAllStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CollapseAllStripButton.Name = "CollapseAllStripButton";
            this.CollapseAllStripButton.Size = new System.Drawing.Size(23, 22);
            this.CollapseAllStripButton.Text = "CollapseAll";
            this.CollapseAllStripButton.Click += new System.EventHandler(this.CollapseAll_Click);
            // 
            // QueryStripButton
            // 
            this.QueryStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.QueryStripButton.Image = global::MagicMongoDBTool.Properties.Resources.Query;
            this.QueryStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QueryStripButton.Name = "QueryStripButton";
            this.QueryStripButton.Size = new System.Drawing.Size(23, 22);
            this.QueryStripButton.Text = "Query";
            this.QueryStripButton.Click += new System.EventHandler(this.QueryStripButton_Click);
            // 
            // FilterStripButton
            // 
            this.FilterStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FilterStripButton.Image = global::MagicMongoDBTool.Properties.Resources.Filter;
            this.FilterStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FilterStripButton.Name = "FilterStripButton";
            this.FilterStripButton.Size = new System.Drawing.Size(23, 22);
            this.FilterStripButton.Text = "Filter";
            this.FilterStripButton.Click += new System.EventHandler(this.FilterStripButton_Click);
            // 
            // DataNaviToolStripLabel
            // 
            this.DataNaviToolStripLabel.Name = "DataNaviToolStripLabel";
            this.DataNaviToolStripLabel.Size = new System.Drawing.Size(118, 22);
            this.DataNaviToolStripLabel.Text = "DataNaviToolStripLabel";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // RefreshStripButton
            // 
            this.RefreshStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshStripButton.Image = global::MagicMongoDBTool.Properties.Resources.Refresh;
            this.RefreshStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshStripButton.Name = "RefreshStripButton";
            this.RefreshStripButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshStripButton.Text = "Refresh";
            this.RefreshStripButton.Click += new System.EventHandler(this.RefreshStripButton_Click);
            // 
            // CloseStripButton
            // 
            this.CloseStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CloseStripButton.Image = global::MagicMongoDBTool.Properties.Resources.ShutDown;
            this.CloseStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseStripButton.Name = "CloseStripButton";
            this.CloseStripButton.Size = new System.Drawing.Size(23, 22);
            this.CloseStripButton.Text = "Close";
            this.CloseStripButton.Click += new System.EventHandler(this.CloseStripButton_Click);
            // 
            // ctlDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabDataShower);
            this.Controls.Add(this.ViewtoolStrip);
            this.Name = "ctlDataView";
            this.Size = new System.Drawing.Size(688, 478);
            this.Load += new System.EventHandler(this.ctlDataView_Load);
            this.tabDataShower.ResumeLayout(false);
            this.tabTreeView.ResumeLayout(false);
            this.tabTableView.ResumeLayout(false);
            this.tabTextView.ResumeLayout(false);
            this.tabTextView.PerformLayout();
            this.contextMenuStripMain.ResumeLayout(false);
            this.ViewtoolStrip.ResumeLayout(false);
            this.ViewtoolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.TabControl tabDataShower;
        private System.Windows.Forms.TabPage tabTreeView;
        private System.Windows.Forms.TreeView trvData;
        private System.Windows.Forms.TabPage tabTableView;
        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.TabPage tabTextView;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;

        private ToolStrip ViewtoolStrip;
        private ToolStripButton PrePageStripButton;
        private ToolStripButton FirstPageStripButton;
        private ToolStripButton NextPageStripButton;
        private ToolStripButton LastPageStripButton;
        private ToolStripButton ExpandAllStripButton;
        private ToolStripButton CollapseAllStripButton;
        private ToolStripMenuItem DataDocumentToolStripMenuItem;

        private ToolStripMenuItem AddDocumentToolStripMenuItem;
        private ToolStripMenuItem DelSelectRecordToolStripMenuItem;
        private ToolStripMenuItem AddElementToolStripMenuItem;
        private ToolStripMenuItem DropElementToolStripMenuItem;
        private ToolStripMenuItem ModifyElementToolStripMenuItem;
        private ToolStripMenuItem CopyElementToolStripMenuItem;
        private ToolStripMenuItem CutElementToolStripMenuItem;
        private ToolStripMenuItem PasteElementToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton CloseStripButton;
        private ToolStripButton RefreshStripButton;
        private ToolStripButton QueryStripButton;
        private ToolStripButton FilterStripButton;
        private ToolStripLabel DataNaviToolStripLabel;
        private ToolStripButton NewDocumentStripButton;

        //GFS
        private ToolStripMenuItem UploadFileToolStripMenuItem;
        private ToolStripMenuItem DownloadFileToolStripMenuItem;
        private ToolStripMenuItem OpenFileToolStripMenuItem;
        private ToolStripMenuItem DelFileToolStripMenuItem;

        //Record
        private ToolStripMenuItem RemoveUserFromAdminToolStripMenuItem;
        private ToolStripMenuItem RemoveUserToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripButton DelSelectRecordToolStripButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton EditDocStripButton;

    }
}
