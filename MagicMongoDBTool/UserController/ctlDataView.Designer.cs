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
            this.lnkFile = new System.Windows.Forms.LinkLabel();
            this.txtData = new System.Windows.Forms.TextBox();
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DataDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelSelectRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DropElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifyElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewtoolStrip = new System.Windows.Forms.ToolStrip();
            this.FirstPage = new System.Windows.Forms.ToolStripButton();
            this.PrePage = new System.Windows.Forms.ToolStripButton();
            this.NextPage = new System.Windows.Forms.ToolStripButton();
            this.LastPage = new System.Windows.Forms.ToolStripButton();
            this.ExpandAll = new System.Windows.Forms.ToolStripButton();
            this.CollapseAll = new System.Windows.Forms.ToolStripButton();
            this.DataNaviToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
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
            this.tabTextView.Controls.Add(this.lnkFile);
            this.tabTextView.Controls.Add(this.txtData);
            this.tabTextView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabTextView.Location = new System.Drawing.Point(4, 22);
            this.tabTextView.Name = "tabTextView";
            this.tabTextView.Padding = new System.Windows.Forms.Padding(3);
            this.tabTextView.Size = new System.Drawing.Size(680, 427);
            this.tabTextView.TabIndex = 2;
            this.tabTextView.Text = "TextView";
            // 
            // lnkFile
            // 
            this.lnkFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkFile.AutoSize = true;
            this.lnkFile.Location = new System.Drawing.Point(547, 3);
            this.lnkFile.Name = "lnkFile";
            this.lnkFile.Size = new System.Drawing.Size(109, 13);
            this.lnkFile.TabIndex = 1;
            this.lnkFile.TabStop = true;
            this.lnkFile.Text = "Open In Native Editor";
            this.lnkFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFile_LinkClicked);
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
            this.contextMenuStripMain.Size = new System.Drawing.Size(153, 48);
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
            this.PasteElementToolStripMenuItem});
            this.DataDocumentToolStripMenuItem.Name = "DataDocumentToolStripMenuItem";
            this.DataDocumentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DataDocumentToolStripMenuItem.Text = "Document";

            this.DelSelectRecordToolStripMenuItem.Image = MagicMongoDBTool.Module.GetResource.GetIcon(IconType.No).ToBitmap();
            this.DropElementToolStripMenuItem.Image = MagicMongoDBTool.Module.GetResource.GetIcon(IconType.No).ToBitmap();

            // 
            // AddDocumentToolStripMenuItem
            // 
            this.AddDocumentToolStripMenuItem.Name = "AddDocumentToolStripMenuItem";
            this.AddDocumentToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.AddDocumentToolStripMenuItem.Text = "Add Document";
            // 
            // DelSelectRecordToolStripMenuItem
            // 
            this.DelSelectRecordToolStripMenuItem.Name = "DelSelectRecordToolStripMenuItem";
            this.DelSelectRecordToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.DelSelectRecordToolStripMenuItem.Text = "Del Selected Records";
            this.DelSelectRecordToolStripMenuItem.Click += new System.EventHandler(this.DelSelectRecordToolStripMenuItem_Click);
            // 
            // AddElementToolStripMenuItem
            // 
            this.AddElementToolStripMenuItem.Name = "AddElementToolStripMenuItem";
            this.AddElementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.AddElementToolStripMenuItem.Text = "Add Element";
            // 
            // DropElementToolStripMenuItem
            // 
            this.DropElementToolStripMenuItem.Name = "DropElementToolStripMenuItem";
            this.DropElementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.DropElementToolStripMenuItem.Text = "Drop Element";
            // 
            // ModifyElementToolStripMenuItem
            // 
            this.ModifyElementToolStripMenuItem.Name = "ModifyElementToolStripMenuItem";
            this.ModifyElementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.ModifyElementToolStripMenuItem.Text = "Modify Element";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
            // 
            // CopyElementToolStripMenuItem
            // 
            this.CopyElementToolStripMenuItem.Name = "CopyElementToolStripMenuItem";
            this.CopyElementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.CopyElementToolStripMenuItem.Text = "Copy Element";
            // 
            // CutElementToolStripMenuItem
            // 
            this.CutElementToolStripMenuItem.Name = "CutElementToolStripMenuItem";
            this.CutElementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.CutElementToolStripMenuItem.Text = "Cut Element";
            // 
            // PasteElementToolStripMenuItem
            // 
            this.PasteElementToolStripMenuItem.Name = "PasteElementToolStripMenuItem";
            this.PasteElementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.PasteElementToolStripMenuItem.Text = "Paste Element";
            // 
            // ViewtoolStrip
            // 
            this.ViewtoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FirstPage,
            this.PrePage,
            this.NextPage,
            this.LastPage,
            this.ExpandAll,
            this.CollapseAll});
            this.ViewtoolStrip.Location = new System.Drawing.Point(0, 0);
            this.ViewtoolStrip.Name = "ViewtoolStrip";
            this.ViewtoolStrip.Size = new System.Drawing.Size(688, 25);
            this.ViewtoolStrip.TabIndex = 2;
            this.ViewtoolStrip.Text = "toolStrip1";
            // 
            // FirstPage
            // 
            this.FirstPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FirstPage.Image = ((System.Drawing.Image)(resources.GetObject("FirstPage.Image")));
            this.FirstPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FirstPage.Name = "FirstPage";
            this.FirstPage.Size = new System.Drawing.Size(23, 22);
            this.FirstPage.Text = "First Page";
            this.FirstPage.Click += new System.EventHandler(this.FirstPage_Click);
            // 
            // PrePage
            // 
            this.PrePage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PrePage.Image = ((System.Drawing.Image)(resources.GetObject("PrePage.Image")));
            this.PrePage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrePage.Name = "PrePage";
            this.PrePage.Size = new System.Drawing.Size(23, 22);
            this.PrePage.Text = "Previous Page";
            this.PrePage.Click += new System.EventHandler(this.PrePage_Click);
            // 
            // NextPage
            // 
            this.NextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NextPage.Image = ((System.Drawing.Image)(resources.GetObject("NextPage.Image")));
            this.NextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NextPage.Name = "NextPage";
            this.NextPage.Size = new System.Drawing.Size(23, 22);
            this.NextPage.Text = "Next Page";
            this.NextPage.Click += new System.EventHandler(this.NextPage_Click);
            // 
            // LastPage
            // 
            this.LastPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LastPage.Image = ((System.Drawing.Image)(resources.GetObject("LastPage.Image")));
            this.LastPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LastPage.Name = "LastPage";
            this.LastPage.Size = new System.Drawing.Size(23, 22);
            this.LastPage.Text = "Last Page";
            this.LastPage.Click += new System.EventHandler(this.LastPage_Click);
            // 
            // ExpandAll
            // 
            this.ExpandAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("ExpandAll.Image")));
            this.ExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExpandAll.Name = "ExpandAll";
            this.ExpandAll.Size = new System.Drawing.Size(58, 22);
            this.ExpandAll.Text = "ExpandAll";
            this.ExpandAll.Click += new System.EventHandler(this.ExpandAll_Click);
            // 
            // CollapseAll
            // 
            this.CollapseAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CollapseAll.Image = ((System.Drawing.Image)(resources.GetObject("CollapseAll.Image")));
            this.CollapseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CollapseAll.Name = "CollapseAll";
            this.CollapseAll.Size = new System.Drawing.Size(62, 22);
            this.CollapseAll.Text = "CollapseAll";
            this.CollapseAll.Click += new System.EventHandler(this.CollapseAll_Click);
            // 
            // DataNaviToolStripLabel
            // 
            this.DataNaviToolStripLabel.Name = "DataNaviToolStripLabel";
            this.DataNaviToolStripLabel.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
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

        public ToolStripButton NextPageToolStripButton;
        public ToolStripButton PrePageToolStripButton;
        public ToolStripButton FirstPageToolStripButton;
        public ToolStripButton LastPageToolStripButton;
        public ToolStripButton QueryDataToolStripButton;
        public ToolStripButton DataFilterToolStripButton;
        public ToolStripLabel DataNaviToolStripLabel;

        public System.Windows.Forms.TabControl tabDataShower;
        public System.Windows.Forms.TabPage tabTreeView;
        public System.Windows.Forms.TreeView trvData;
        public System.Windows.Forms.TabPage tabTableView;
        public System.Windows.Forms.ListView lstData;
        public System.Windows.Forms.TabPage tabTextView;
        public System.Windows.Forms.LinkLabel lnkFile;
        public System.Windows.Forms.TextBox txtData;
        public System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        public ToolStrip ViewtoolStrip;
        private ToolStripButton PrePage;
        private ToolStripButton FirstPage;
        private ToolStripButton NextPage;
        private ToolStripButton LastPage;
        private ToolStripButton ExpandAll;
        private ToolStripButton CollapseAll;
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
    }
}
