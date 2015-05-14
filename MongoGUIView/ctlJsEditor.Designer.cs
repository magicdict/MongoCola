using System.ComponentModel;
using System.Windows.Forms;

namespace MongoGUIView
{
    partial class CtlJsEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlJsEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.EditDocStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveStripButton = new System.Windows.Forms.ToolStripButton();
            this.CloseStripButton = new System.Windows.Forms.ToolStripButton();
            this.txtJavaScript = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditDocStripButton,
            this.SaveStripButton,
            this.CloseStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(696, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // EditDocStripButton
            // 
            this.EditDocStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditDocStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EditDocStripButton.Image")));
            this.EditDocStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditDocStripButton.Name = "EditDocStripButton";
            this.EditDocStripButton.Size = new System.Drawing.Size(23, 22);
            this.EditDocStripButton.Tag = "Common_Edit";
            this.EditDocStripButton.Text = "Editor";
            this.EditDocStripButton.Click += new System.EventHandler(this.EditDocStripButton_Click);
            // 
            // SaveStripButton
            // 
            this.SaveStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveStripButton.Image")));
            this.SaveStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveStripButton.Name = "SaveStripButton";
            this.SaveStripButton.Size = new System.Drawing.Size(23, 22);
            this.SaveStripButton.Tag = "Common_Save";
            this.SaveStripButton.Text = "Save";
            this.SaveStripButton.Click += new System.EventHandler(this.SaveStripButton_Click);
            // 
            // CloseStripButton
            // 
            this.CloseStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CloseStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseStripButton.Image")));
            this.CloseStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseStripButton.Name = "CloseStripButton";
            this.CloseStripButton.Size = new System.Drawing.Size(23, 22);
            this.CloseStripButton.Tag = "Common_Close";
            this.CloseStripButton.Text = "Close";
            this.CloseStripButton.Click += new System.EventHandler(this.CloseStripButton_Click);
            // 
            // txtJavaScript
            // 
            this.txtJavaScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJavaScript.Location = new System.Drawing.Point(0, 25);
            this.txtJavaScript.Multiline = true;
            this.txtJavaScript.Name = "txtJavaScript";
            this.txtJavaScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtJavaScript.Size = new System.Drawing.Size(696, 332);
            this.txtJavaScript.TabIndex = 1;
            // 
            // ctlJsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtJavaScript);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CtlJsEditor";
            this.Size = new System.Drawing.Size(696, 357);
            this.Load += new System.EventHandler(this.JsEditor_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton CloseStripButton;
        private ToolStripButton SaveStripButton;
        private TextBox txtJavaScript;
        private ToolStripButton EditDocStripButton;
    }
}
