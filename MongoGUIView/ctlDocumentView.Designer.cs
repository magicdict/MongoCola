using System.ComponentModel;
using System.Windows.Forms;

namespace MongoGUIView
{
    partial class CtlDocumentView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlDocumentView));
            this.NewDocumentStripButton = new System.Windows.Forms.ToolStripButton();
            this.DelSelectRecordToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.OpenDocInEditorStripButton = new System.Windows.Forms.ToolStripButton();
            this.CutElementStripButton = new System.Windows.Forms.ToolStripButton();
            this.CopyElementStripButton = new System.Windows.Forms.ToolStripButton();
            this.PasteElementStripButton = new System.Windows.Forms.ToolStripButton();
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
            this.tabDataShower.SuspendLayout();
            this.tabTreeView.SuspendLayout();
            this.tabTableView.SuspendLayout();
            this.tabTextView.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDataShower
            // 
            this.tabDataShower.Size = new System.Drawing.Size(917, 366);
            // 
            // tabTreeView
            // 
            this.tabTreeView.Size = new System.Drawing.Size(909, 340);
            // 
            // tabTableView
            // 
            this.tabTableView.Size = new System.Drawing.Size(909, 340);
            // 
            // trvData
            // 
            this.trvData.Size = new System.Drawing.Size(903, 334);
            // 
            // lstData
            // 
            this.lstData.Size = new System.Drawing.Size(903, 334);
            this.lstData.SelectedIndexChanged += new System.EventHandler(this.lstData_SelectedIndexChanged);
            // 
            // tabTextView
            // 
            this.tabTextView.Size = new System.Drawing.Size(909, 340);
            // 
            // txtData
            // 
            this.txtData.Size = new System.Drawing.Size(903, 334);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(917, 366);
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
            // DelSelectRecordToolStripButton
            // 
            this.DelSelectRecordToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DelSelectRecordToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DelSelectRecordToolStripButton.Image")));
            this.DelSelectRecordToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelSelectRecordToolStripButton.Name = "DelSelectRecordToolStripButton";
            this.DelSelectRecordToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.DelSelectRecordToolStripButton.Text = "Delete Selected Record";
            this.DelSelectRecordToolStripButton.Click += new System.EventHandler(this.DelSelectRecordToolStripButton_Click);
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
            // NewDocumentToolStripMenuItem
            // 
            this.NewDocumentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NewDocumentToolStripMenuItem.Image")));
            this.NewDocumentToolStripMenuItem.Name = "NewDocumentToolStripMenuItem";
            this.NewDocumentToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.NewDocumentToolStripMenuItem.Text = "Add Document";
            this.NewDocumentToolStripMenuItem.Click += new System.EventHandler(this.NewDocumentStripButton_Click);
            // 
            // OpenDocInEditorToolStripMenuItem
            // 
            this.OpenDocInEditorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenDocInEditorToolStripMenuItem.Image")));
            this.OpenDocInEditorToolStripMenuItem.Name = "OpenDocInEditorToolStripMenuItem";
            this.OpenDocInEditorToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.OpenDocInEditorToolStripMenuItem.Text = "Open Doc In Editor";
            this.OpenDocInEditorToolStripMenuItem.Click += new System.EventHandler(this.OpenDocInEditorDocStripButton_Click);
            // 
            // DelSelectRecordToolToolStripMenuItem
            // 
            this.DelSelectRecordToolToolStripMenuItem.Name = "DelSelectRecordToolToolStripMenuItem";
            this.DelSelectRecordToolToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.DelSelectRecordToolToolStripMenuItem.Text = "Del Selected Records";
            this.DelSelectRecordToolToolStripMenuItem.Click += new System.EventHandler(this.DelSelectRecordToolStripButton_Click);
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
            this.CopyElementToolStripMenuItem.Name = "CopyElementToolStripMenuItem";
            this.CopyElementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.CopyElementToolStripMenuItem.Text = "Copy Element";
            this.CopyElementToolStripMenuItem.Click += new System.EventHandler(this.CopyElementToolStripMenuItem_Click);
            // 
            // CutElementToolStripMenuItem
            // 
            this.CutElementToolStripMenuItem.Name = "CutElementToolStripMenuItem";
            this.CutElementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.CutElementToolStripMenuItem.Text = "Cut Element";
            this.CutElementToolStripMenuItem.Click += new System.EventHandler(this.CutElementToolStripMenuItem_Click);
            // 
            // PasteElementToolStripMenuItem
            // 
            this.PasteElementToolStripMenuItem.Name = "PasteElementToolStripMenuItem";
            this.PasteElementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.PasteElementToolStripMenuItem.Text = "Paste Element";
            this.PasteElementToolStripMenuItem.Click += new System.EventHandler(this.PasteElementToolStripMenuItem_Click);
            // 
            // CtlDocumentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CtlDocumentView";
            this.Load += new System.EventHandler(this.ctlDocumentView_Load);
            this.Controls.SetChildIndex(this.toolStripContainer1, 0);
            this.tabDataShower.ResumeLayout(false);
            this.tabTreeView.ResumeLayout(false);
            this.tabTableView.ResumeLayout(false);
            this.tabTextView.ResumeLayout(false);
            this.tabTextView.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }
        private void InitToolAndMenu()
        {
            this.CustomtoolStrip.Items.Add(NewDocumentStripButton);
            this.CustomtoolStrip.Items.Add(DelSelectRecordToolStripButton);
            this.CustomtoolStrip.Items.Add(OpenDocInEditorStripButton);
            this.CustomtoolStrip.Items.Add(CutElementStripButton);
            this.CustomtoolStrip.Items.Add(CopyElementStripButton);
            this.CustomtoolStrip.Items.Add(PasteElementStripButton);
        }
        #endregion

        private ToolStripMenuItem OpenDocInEditorToolStripMenuItem;
        private ToolStripMenuItem NewDocumentToolStripMenuItem;
        private ToolStripMenuItem DelSelectRecordToolToolStripMenuItem;

        private ToolStripMenuItem AddElementToolStripMenuItem;
        private ToolStripMenuItem DropElementToolStripMenuItem;
        private ToolStripMenuItem ModifyElementToolStripMenuItem;

        private ToolStripMenuItem CopyElementToolStripMenuItem;
        private ToolStripMenuItem CutElementToolStripMenuItem;
        private ToolStripMenuItem PasteElementToolStripMenuItem;


        private ToolStripSeparator SeperateBarForMenuItem2;
        private ToolStripSeparator SeperateBarForMenuItem1;

        private ToolStripButton NewDocumentStripButton;
        private ToolStripButton DelSelectRecordToolStripButton;
        private ToolStripButton OpenDocInEditorStripButton;
        private ToolStripButton CutElementStripButton;
        private ToolStripButton CopyElementStripButton;
        private ToolStripButton PasteElementStripButton;
    }
}
