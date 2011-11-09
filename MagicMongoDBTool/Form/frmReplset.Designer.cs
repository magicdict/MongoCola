namespace MagicMongoDBTool
{
    partial class frmReplset
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReplset));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAddSvr = new System.Windows.Forms.TabPage();
            this.tabRemoveSvr = new System.Windows.Forms.TabPage();
            this.lstServerOutReplset = new System.Windows.Forms.ListBox();
            this.lstServerInReplset = new System.Windows.Forms.ListBox();
            this.cmdAddSvr = new System.Windows.Forms.VistaButton();
            this.cmdRemove = new System.Windows.Forms.VistaButton();
            this.contentPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAddSvr.SuspendLayout();
            this.tabRemoveSvr.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.tabControl1);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(425, 260);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAddSvr);
            this.tabControl1.Controls.Add(this.tabRemoveSvr);
            this.tabControl1.Location = new System.Drawing.Point(11, 17);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(403, 225);
            this.tabControl1.TabIndex = 5;
            // 
            // tabAddSvr
            // 
            this.tabAddSvr.Controls.Add(this.cmdAddSvr);
            this.tabAddSvr.Controls.Add(this.lstServerOutReplset);
            this.tabAddSvr.Location = new System.Drawing.Point(4, 22);
            this.tabAddSvr.Name = "tabAddSvr";
            this.tabAddSvr.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddSvr.Size = new System.Drawing.Size(395, 199);
            this.tabAddSvr.TabIndex = 0;
            this.tabAddSvr.Text = "添加服务器";
            this.tabAddSvr.UseVisualStyleBackColor = true;
            // 
            // tabRemoveSvr
            // 
            this.tabRemoveSvr.Controls.Add(this.cmdRemove);
            this.tabRemoveSvr.Controls.Add(this.lstServerInReplset);
            this.tabRemoveSvr.Location = new System.Drawing.Point(4, 22);
            this.tabRemoveSvr.Name = "tabRemoveSvr";
            this.tabRemoveSvr.Padding = new System.Windows.Forms.Padding(3);
            this.tabRemoveSvr.Size = new System.Drawing.Size(395, 199);
            this.tabRemoveSvr.TabIndex = 1;
            this.tabRemoveSvr.Text = "删除服务器";
            this.tabRemoveSvr.UseVisualStyleBackColor = true;
            // 
            // lstServerOutReplset
            // 
            this.lstServerOutReplset.FormattingEnabled = true;
            this.lstServerOutReplset.Location = new System.Drawing.Point(20, 20);
            this.lstServerOutReplset.Name = "lstServerOutReplset";
            this.lstServerOutReplset.Size = new System.Drawing.Size(350, 108);
            this.lstServerOutReplset.TabIndex = 5;
            // 
            // lstServerInReplset
            // 
            this.lstServerInReplset.FormattingEnabled = true;
            this.lstServerInReplset.Location = new System.Drawing.Point(20, 20);
            this.lstServerInReplset.Name = "lstServerInReplset";
            this.lstServerInReplset.Size = new System.Drawing.Size(350, 108);
            this.lstServerInReplset.TabIndex = 0;
            // 
            // cmdAddSvr
            // 
            this.cmdAddSvr.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddSvr.Location = new System.Drawing.Point(271, 147);
            this.cmdAddSvr.Name = "cmdAddSvr";
            this.cmdAddSvr.Size = new System.Drawing.Size(100, 32);
            this.cmdAddSvr.TabIndex = 6;
            this.cmdAddSvr.Text = "添加";
            this.cmdAddSvr.Click += new System.EventHandler(this.cmdAddSvr_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.BackColor = System.Drawing.Color.Transparent;
            this.cmdRemove.Location = new System.Drawing.Point(271, 147);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(100, 32);
            this.cmdRemove.TabIndex = 1;
            this.cmdRemove.Text = "删除";
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // frmReplset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 323);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmReplset";
            this.ShowSelectSkinButton = false;
            this.Text = "副本管理";
            this.Load += new System.EventHandler(this.frmReplset_Load);
            this.contentPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabAddSvr.ResumeLayout(false);
            this.tabRemoveSvr.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAddSvr;
        private System.Windows.Forms.TabPage tabRemoveSvr;
        private System.Windows.Forms.ListBox lstServerOutReplset;
        private System.Windows.Forms.ListBox lstServerInReplset;
        private System.Windows.Forms.VistaButton cmdAddSvr;
        private System.Windows.Forms.VistaButton cmdRemove;

    }
}