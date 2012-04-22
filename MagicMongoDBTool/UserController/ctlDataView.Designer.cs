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
            this.trvData = new TreeViewColumnsProject.TreeViewColumns();
            this.tabTableView = new System.Windows.Forms.TabPage();
            this.lstData = new System.Windows.Forms.ListView();
            this.tabTextView = new System.Windows.Forms.TabPage();
            this.txtData = new System.Windows.Forms.TextBox();
            this.tabQuery = new System.Windows.Forms.TabPage();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDocInEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelSelectRecordToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SeperateBarForMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DropElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifyElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SeperateBarForMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CutElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewtoolStrip = new System.Windows.Forms.ToolStrip();
            this.NewDocumentStripButton = new System.Windows.Forms.ToolStripButton();
            this.OpenDocInEditorStripButton = new System.Windows.Forms.ToolStripButton();
            this.DelSelectRecordToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SeperateBar1 = new System.Windows.Forms.ToolStripSeparator();
            this.CutElementStripButton = new System.Windows.Forms.ToolStripButton();
            this.CopyElementStripButton = new System.Windows.Forms.ToolStripButton();
            this.PasteElementStripButton = new System.Windows.Forms.ToolStripButton();
            this.SeperateBar2 = new System.Windows.Forms.ToolStripSeparator();
            this.FirstPageStripButton = new System.Windows.Forms.ToolStripButton();
            this.PrePageStripButton = new System.Windows.Forms.ToolStripButton();
            this.NextPageStripButton = new System.Windows.Forms.ToolStripButton();
            this.LastPageStripButton = new System.Windows.Forms.ToolStripButton();
            this.ExpandAllStripButton = new System.Windows.Forms.ToolStripButton();
            this.CollapseAllStripButton = new System.Windows.Forms.ToolStripButton();
            this.QueryStripButton = new System.Windows.Forms.ToolStripButton();
            this.FilterStripButton = new System.Windows.Forms.ToolStripButton();
            this.DataNaviToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.txtSkip = new System.Windows.Forms.ToolStripTextBox();
            this.GotoStripButton = new System.Windows.Forms.ToolStripButton();
            this.cmbRecPerPage = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshStripButton = new System.Windows.Forms.ToolStripButton();
            this.CloseStripButton = new System.Windows.Forms.ToolStripButton();
            this.tabDataShower.SuspendLayout();
            this.tabTreeView.SuspendLayout();
            this.tabTableView.SuspendLayout();
            this.tabTextView.SuspendLayout();
            this.tabQuery.SuspendLayout();
            this.contextMenuStripMain.SuspendLayout();
            this.ViewtoolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDataShower
            // 
            this.tabDataShower.Controls.Add(this.tabTreeView);
            this.tabDataShower.Controls.Add(this.tabTableView);
            this.tabDataShower.Controls.Add(this.tabTextView);
            this.tabDataShower.Controls.Add(this.tabQuery);
            this.tabDataShower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDataShower.Location = new System.Drawing.Point(0, 25);
            this.tabDataShower.Name = "tabDataShower";
            this.tabDataShower.SelectedIndex = 0;
            this.tabDataShower.Size = new System.Drawing.Size(917, 416);
            this.tabDataShower.TabIndex = 1;
            // 
            // tabTreeView
            // 
            this.tabTreeView.BackColor = System.Drawing.Color.Orange;
            this.tabTreeView.Controls.Add(this.trvData);
            this.tabTreeView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabTreeView.Location = new System.Drawing.Point(4, 21);
            this.tabTreeView.Name = "tabTreeView";
            this.tabTreeView.Padding = new System.Windows.Forms.Padding(3);
            this.tabTreeView.Size = new System.Drawing.Size(909, 391);
            this.tabTreeView.TabIndex = 0;
            this.tabTreeView.Text = "TreeView";
            this.tabTreeView.UseVisualStyleBackColor = true;
            // 
            // trvData
            // 
            this.trvData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(172)))), ((int)(((byte)(178)))));
            this.trvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvData.Location = new System.Drawing.Point(3, 3);
            this.trvData.Name = "trvData";
            this.trvData.Padding = new System.Windows.Forms.Padding(1);
            this.trvData.Size = new System.Drawing.Size(903, 385);
            this.trvData.TabIndex = 0;
            // 
            // tabTableView
            // 
            this.tabTableView.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tabTableView.Controls.Add(this.lstData);
            this.tabTableView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabTableView.Location = new System.Drawing.Point(4, 21);
            this.tabTableView.Name = "tabTableView";
            this.tabTableView.Padding = new System.Windows.Forms.Padding(3);
            this.tabTableView.Size = new System.Drawing.Size(909, 391);
            this.tabTableView.TabIndex = 1;
            this.tabTableView.Text = "TableView";
            this.tabTableView.UseVisualStyleBackColor = true;
            // 
            // lstData
            // 
            this.lstData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstData.FullRowSelect = true;
            this.lstData.GridLines = true;
            this.lstData.HideSelection = false;
            this.lstData.Location = new System.Drawing.Point(3, 3);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(903, 385);
            this.lstData.TabIndex = 1;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.Details;
            // 
            // tabTextView
            // 
            this.tabTextView.BackColor = System.Drawing.Color.Yellow;
            this.tabTextView.Controls.Add(this.txtData);
            this.tabTextView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabTextView.Location = new System.Drawing.Point(4, 21);
            this.tabTextView.Name = "tabTextView";
            this.tabTextView.Padding = new System.Windows.Forms.Padding(3);
            this.tabTextView.Size = new System.Drawing.Size(909, 391);
            this.tabTextView.TabIndex = 2;
            this.tabTextView.Text = "TextView";
            this.tabTextView.UseVisualStyleBackColor = true;
            // 
            // txtData
            // 
            this.txtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtData.Location = new System.Drawing.Point(3, 3);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtData.Size = new System.Drawing.Size(903, 385);
            this.txtData.TabIndex = 0;
            // 
            // tabQuery
            // 
            this.tabQuery.Controls.Add(this.txtQuery);
            this.tabQuery.Location = new System.Drawing.Point(4, 21);
            this.tabQuery.Name = "tabQuery";
            this.tabQuery.Size = new System.Drawing.Size(909, 391);
            this.tabQuery.TabIndex = 3;
            this.tabQuery.Text = "Query";
            this.tabQuery.UseVisualStyleBackColor = true;
            // 
            // txtQuery
            // 
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuery.Location = new System.Drawing.Point(0, 0);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(909, 391);
            this.txtQuery.TabIndex = 0;
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewDocumentToolStripMenuItem,
            this.OpenDocInEditorToolStripMenuItem,
            this.DelSelectRecordToolToolStripMenuItem,
            this.SeperateBarForMenuItem1,
            this.AddElementToolStripMenuItem,
            this.DropElementToolStripMenuItem,
            this.ModifyElementToolStripMenuItem,
            this.SeperateBarForMenuItem2,
            this.CopyElementToolStripMenuItem,
            this.CutElementToolStripMenuItem,
            this.PasteElementToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(176, 236);
            // 
            // NewDocumentToolStripMenuItem
            // 
            this.NewDocumentToolStripMenuItem.Image = global::MagicMongoDBTool.Properties.Resources.NewDocument;
            this.NewDocumentToolStripMenuItem.Name = "NewDocumentToolStripMenuItem";
            this.NewDocumentToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.NewDocumentToolStripMenuItem.Text = "Add Document";
            // 
            // OpenDocInEditorToolStripMenuItem
            // 
            this.OpenDocInEditorToolStripMenuItem.Image = global::MagicMongoDBTool.Properties.Resources.Edit;
            this.OpenDocInEditorToolStripMenuItem.Name = "OpenDocInEditorToolStripMenuItem";
            this.OpenDocInEditorToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.OpenDocInEditorToolStripMenuItem.Text = "Open Doc In Editor";
            // 
            // DelSelectRecordToolToolStripMenuItem
            // 
            this.DelSelectRecordToolToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DelSelectRecordToolToolStripMenuItem.Image")));
            this.DelSelectRecordToolToolStripMenuItem.Name = "DelSelectRecordToolToolStripMenuItem";
            this.DelSelectRecordToolToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.DelSelectRecordToolToolStripMenuItem.Text = "Del Selected Records";
            // 
            // SeperateBarForMenuItem1
            // 
            this.SeperateBarForMenuItem1.Name = "SeperateBarForMenuItem1";
            this.SeperateBarForMenuItem1.Size = new System.Drawing.Size(172, 6);
            // 
            // AddElementToolStripMenuItem
            // 
            this.AddElementToolStripMenuItem.Name = "AddElementToolStripMenuItem";
            this.AddElementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.AddElementToolStripMenuItem.Text = "Add Element";
            this.AddElementToolStripMenuItem.Click += new System.EventHandler(this.AddElementToolStripMenuItem_Click);
            // 
            // DropElementToolStripMenuItem
            // 
            this.DropElementToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DropElementToolStripMenuItem.Image")));
            this.DropElementToolStripMenuItem.Name = "DropElementToolStripMenuItem";
            this.DropElementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.DropElementToolStripMenuItem.Text = "Drop Element";
            this.DropElementToolStripMenuItem.Click += new System.EventHandler(this.DropElementToolStripMenuItem_Click);
            // 
            // ModifyElementToolStripMenuItem
            // 
            this.ModifyElementToolStripMenuItem.Name = "ModifyElementToolStripMenuItem";
            this.ModifyElementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.ModifyElementToolStripMenuItem.Text = "Modify Element";
            this.ModifyElementToolStripMenuItem.Click += new System.EventHandler(this.ModifyElementToolStripMenuItem_Click);
            // 
            // SeperateBarForMenuItem2
            // 
            this.SeperateBarForMenuItem2.Name = "SeperateBarForMenuItem2";
            this.SeperateBarForMenuItem2.Size = new System.Drawing.Size(172, 6);
            // 
            // CopyElementToolStripMenuItem
            // 
            this.CopyElementToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CopyElementToolStripMenuItem.Image")));
            this.CopyElementToolStripMenuItem.Name = "CopyElementToolStripMenuItem";
            this.CopyElementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.CopyElementToolStripMenuItem.Text = "Copy Element";
            this.CopyElementToolStripMenuItem.Click += new System.EventHandler(this.CopyElementToolStripMenuItem_Click);
            // 
            // CutElementToolStripMenuItem
            // 
            this.CutElementToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CutElementToolStripMenuItem.Image")));
            this.CutElementToolStripMenuItem.Name = "CutElementToolStripMenuItem";
            this.CutElementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.CutElementToolStripMenuItem.Text = "Cut Element";
            this.CutElementToolStripMenuItem.Click += new System.EventHandler(this.CutElementToolStripMenuItem_Click);
            // 
            // PasteElementToolStripMenuItem
            // 
            this.PasteElementToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PasteElementToolStripMenuItem.Image")));
            this.PasteElementToolStripMenuItem.Name = "PasteElementToolStripMenuItem";
            this.PasteElementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.PasteElementToolStripMenuItem.Text = "Paste Element";
            this.PasteElementToolStripMenuItem.Click += new System.EventHandler(this.PasteElementToolStripMenuItem_Click);
            // 
            // ViewtoolStrip
            // 
            this.ViewtoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewDocumentStripButton,
            this.OpenDocInEditorStripButton,
            this.DelSelectRecordToolStripButton,
            this.SeperateBar1,
            this.CutElementStripButton,
            this.CopyElementStripButton,
            this.PasteElementStripButton,
            this.SeperateBar2,
            this.FirstPageStripButton,
            this.PrePageStripButton,
            this.NextPageStripButton,
            this.LastPageStripButton,
            this.ExpandAllStripButton,
            this.CollapseAllStripButton,
            this.QueryStripButton,
            this.FilterStripButton,
            this.DataNaviToolStripLabel,
            this.txtSkip,
            this.GotoStripButton,
            this.cmbRecPerPage,
            this.toolStripSeparator3,
            this.RefreshStripButton,
            this.CloseStripButton});
            this.ViewtoolStrip.Location = new System.Drawing.Point(0, 0);
            this.ViewtoolStrip.Name = "ViewtoolStrip";
            this.ViewtoolStrip.Size = new System.Drawing.Size(917, 25);
            this.ViewtoolStrip.TabIndex = 2;
            this.ViewtoolStrip.Text = "toolStrip1";
            // 
            // NewDocumentStripButton
            // 
            this.NewDocumentStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewDocumentStripButton.Image = ((System.Drawing.Image)(resources.GetObject("NewDocumentStripButton.Image")));
            this.NewDocumentStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewDocumentStripButton.Name = "NewDocumentStripButton";
            this.NewDocumentStripButton.Size = new System.Drawing.Size(23, 22);
            this.NewDocumentStripButton.Text = "New Document";
            this.NewDocumentStripButton.Click += new System.EventHandler(this.NewDocumentStripButton_Click);
            // 
            // OpenDocInEditorStripButton
            // 
            this.OpenDocInEditorStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenDocInEditorStripButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenDocInEditorStripButton.Image")));
            this.OpenDocInEditorStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenDocInEditorStripButton.Name = "OpenDocInEditorStripButton";
            this.OpenDocInEditorStripButton.Size = new System.Drawing.Size(23, 22);
            this.OpenDocInEditorStripButton.Text = "Editor";
            this.OpenDocInEditorStripButton.Click += new System.EventHandler(this.OpenDocInEditorDocStripButton_Click);
            // 
            // DelSelectRecordToolStripButton
            // 
            this.DelSelectRecordToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DelSelectRecordToolStripButton.Image = global::MagicMongoDBTool.Properties.Resources.DeleteDoc;
            this.DelSelectRecordToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelSelectRecordToolStripButton.Name = "DelSelectRecordToolStripButton";
            this.DelSelectRecordToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.DelSelectRecordToolStripButton.Text = "Delete Selected Record";
            this.DelSelectRecordToolStripButton.Click += new System.EventHandler(this.DelSelectRecordToolStripButton_Click);
            // 
            // SeperateBar1
            // 
            this.SeperateBar1.Name = "SeperateBar1";
            this.SeperateBar1.Size = new System.Drawing.Size(6, 25);
            // 
            // CutElementStripButton
            // 
            this.CutElementStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CutElementStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CutElementStripButton.Image")));
            this.CutElementStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CutElementStripButton.Name = "CutElementStripButton";
            this.CutElementStripButton.Size = new System.Drawing.Size(23, 22);
            this.CutElementStripButton.Text = "Cut";
            // 
            // CopyElementStripButton
            // 
            this.CopyElementStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CopyElementStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CopyElementStripButton.Image")));
            this.CopyElementStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyElementStripButton.Name = "CopyElementStripButton";
            this.CopyElementStripButton.Size = new System.Drawing.Size(23, 22);
            this.CopyElementStripButton.Text = "Copy";
            // 
            // PasteElementStripButton
            // 
            this.PasteElementStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PasteElementStripButton.Image = ((System.Drawing.Image)(resources.GetObject("PasteElementStripButton.Image")));
            this.PasteElementStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PasteElementStripButton.Name = "PasteElementStripButton";
            this.PasteElementStripButton.Size = new System.Drawing.Size(23, 22);
            this.PasteElementStripButton.Text = "Paste";
            // 
            // SeperateBar2
            // 
            this.SeperateBar2.Name = "SeperateBar2";
            this.SeperateBar2.Size = new System.Drawing.Size(6, 25);
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
            this.ExpandAllStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ExpandAllStripButton.Image")));
            this.ExpandAllStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExpandAllStripButton.Name = "ExpandAllStripButton";
            this.ExpandAllStripButton.Size = new System.Drawing.Size(23, 22);
            this.ExpandAllStripButton.Text = "ExpandAll";
            this.ExpandAllStripButton.Click += new System.EventHandler(this.ExpandAll_Click);
            // 
            // CollapseAllStripButton
            // 
            this.CollapseAllStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CollapseAllStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CollapseAllStripButton.Image")));
            this.CollapseAllStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CollapseAllStripButton.Name = "CollapseAllStripButton";
            this.CollapseAllStripButton.Size = new System.Drawing.Size(23, 22);
            this.CollapseAllStripButton.Text = "CollapseAll";
            this.CollapseAllStripButton.Click += new System.EventHandler(this.CollapseAll_Click);
            // 
            // QueryStripButton
            // 
            this.QueryStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.QueryStripButton.Image = ((System.Drawing.Image)(resources.GetObject("QueryStripButton.Image")));
            this.QueryStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QueryStripButton.Name = "QueryStripButton";
            this.QueryStripButton.Size = new System.Drawing.Size(23, 22);
            this.QueryStripButton.Text = "Query";
            this.QueryStripButton.Click += new System.EventHandler(this.QueryStripButton_Click);
            // 
            // FilterStripButton
            // 
            this.FilterStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FilterStripButton.Image = ((System.Drawing.Image)(resources.GetObject("FilterStripButton.Image")));
            this.FilterStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FilterStripButton.Name = "FilterStripButton";
            this.FilterStripButton.Size = new System.Drawing.Size(23, 22);
            this.FilterStripButton.Text = "Filter";
            this.FilterStripButton.Click += new System.EventHandler(this.FilterStripButton_Click);
            // 
            // DataNaviToolStripLabel
            // 
            this.DataNaviToolStripLabel.Name = "DataNaviToolStripLabel";
            this.DataNaviToolStripLabel.Size = new System.Drawing.Size(47, 22);
            this.DataNaviToolStripLabel.Text = "100/200";
            // 
            // txtSkip
            // 
            this.txtSkip.Name = "txtSkip";
            this.txtSkip.Size = new System.Drawing.Size(100, 25);
            // 
            // GotoStripButton
            // 
            this.GotoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GotoStripButton.Image = global::MagicMongoDBTool.Properties.Resources.Run;
            this.GotoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GotoStripButton.Name = "GotoStripButton";
            this.GotoStripButton.Size = new System.Drawing.Size(23, 22);
            this.GotoStripButton.Text = "Go";
            this.GotoStripButton.Click += new System.EventHandler(this.GotoStripButton_Click);
            // 
            // cmbRecPerPage
            // 
            this.cmbRecPerPage.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbRecPerPage.Items.AddRange(new object[] {
            "50    Documents",
            "100  Documents",
            "200  Documents"});
            this.cmbRecPerPage.Name = "cmbRecPerPage";
            this.cmbRecPerPage.Size = new System.Drawing.Size(121, 25);
            this.cmbRecPerPage.SelectedIndexChanged += new System.EventHandler(this.cmbRecPerPage_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // RefreshStripButton
            // 
            this.RefreshStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshStripButton.Image")));
            this.RefreshStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshStripButton.Name = "RefreshStripButton";
            this.RefreshStripButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshStripButton.Text = "Refresh";
            this.RefreshStripButton.Click += new System.EventHandler(this.RefreshStripButton_Click);
            // 
            // CloseStripButton
            // 
            this.CloseStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CloseStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseStripButton.Image")));
            this.CloseStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseStripButton.Name = "CloseStripButton";
            this.CloseStripButton.Size = new System.Drawing.Size(23, 22);
            this.CloseStripButton.Text = "Close";
            this.CloseStripButton.Click += new System.EventHandler(this.CloseStripButton_Click);
            // 
            // ctlDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabDataShower);
            this.Controls.Add(this.ViewtoolStrip);
            this.Name = "ctlDataView";
            this.Size = new System.Drawing.Size(917, 441);
            this.Load += new System.EventHandler(this.ctlDataView_Load);
            this.tabDataShower.ResumeLayout(false);
            this.tabTreeView.ResumeLayout(false);
            this.tabTableView.ResumeLayout(false);
            this.tabTextView.ResumeLayout(false);
            this.tabTextView.PerformLayout();
            this.tabQuery.ResumeLayout(false);
            this.tabQuery.PerformLayout();
            this.contextMenuStripMain.ResumeLayout(false);
            this.ViewtoolStrip.ResumeLayout(false);
            this.ViewtoolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        protected System.Windows.Forms.TabControl tabDataShower;
        protected System.Windows.Forms.TabPage tabTreeView;
        protected System.Windows.Forms.TabPage tabTableView;
        protected TreeViewColumnsProject.TreeViewColumns trvData;
        protected System.Windows.Forms.ListView lstData;
        protected System.Windows.Forms.TabPage tabTextView;
        protected System.Windows.Forms.TextBox txtData;
        protected System.Windows.Forms.ContextMenuStrip contextMenuStripMain;

        protected ToolStrip ViewtoolStrip;
        private ToolStripButton PrePageStripButton;
        private ToolStripButton FirstPageStripButton;
        private ToolStripButton NextPageStripButton;
        private ToolStripButton LastPageStripButton;
        private ToolStripButton ExpandAllStripButton;
        private ToolStripButton CollapseAllStripButton;

        private ToolStripMenuItem AddElementToolStripMenuItem;
        private ToolStripMenuItem DropElementToolStripMenuItem;
        private ToolStripMenuItem ModifyElementToolStripMenuItem;

        private ToolStripMenuItem CopyElementToolStripMenuItem;
        private ToolStripMenuItem CutElementToolStripMenuItem;
        private ToolStripMenuItem PasteElementToolStripMenuItem;
        private ToolStripButton CutElementStripButton;
        private ToolStripButton CopyElementStripButton;
        private ToolStripButton PasteElementStripButton;


        private ToolStripSeparator SeperateBarForMenuItem2;
        private ToolStripSeparator SeperateBarForMenuItem1;

        private ToolStripButton CloseStripButton;
        private ToolStripButton RefreshStripButton;
        private ToolStripButton QueryStripButton;
        private ToolStripButton FilterStripButton;
        private ToolStripLabel DataNaviToolStripLabel;

        private ToolStripButton OpenDocInEditorStripButton;
        private ToolStripMenuItem OpenDocInEditorToolStripMenuItem;
        private ToolStripButton NewDocumentStripButton;
        private ToolStripMenuItem NewDocumentToolStripMenuItem;
        private ToolStripMenuItem DelSelectRecordToolToolStripMenuItem;
        private ToolStripButton DelSelectRecordToolStripButton;

        //Record
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator SeperateBar1;
        private ToolStripSeparator SeperateBar2;
        private ToolStripComboBox cmbRecPerPage;

        private ToolStripTextBox txtSkip;
        private ToolStripButton GotoStripButton;
        private TabPage tabQuery;
        private TextBox txtQuery;

    }
}
