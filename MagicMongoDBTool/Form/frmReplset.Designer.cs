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
            this.tabReplset = new System.Windows.Forms.TabControl();
            this.tabAddSvr = new System.Windows.Forms.TabPage();
            this.cmdAddSvr = new System.Windows.Forms.Button();
            this.lstServerOutReplset = new System.Windows.Forms.ListBox();
            this.tabRemoveSvr = new System.Windows.Forms.TabPage();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.lstServerInReplset = new System.Windows.Forms.ListBox();
            this.tabReplset.SuspendLayout();
            this.tabAddSvr.SuspendLayout();
            this.tabRemoveSvr.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabReplset
            // 
            this.tabReplset.Controls.Add(this.tabAddSvr);
            this.tabReplset.Controls.Add(this.tabRemoveSvr);
            this.tabReplset.Location = new System.Drawing.Point(13, 20);
            this.tabReplset.Name = "tabReplset";
            this.tabReplset.SelectedIndex = 0;
            this.tabReplset.Size = new System.Drawing.Size(470, 260);
            this.tabReplset.TabIndex = 5;
            // 
            // tabAddSvr
            // 
            this.tabAddSvr.Controls.Add(this.cmdAddSvr);
            this.tabAddSvr.Controls.Add(this.lstServerOutReplset);
            this.tabAddSvr.Location = new System.Drawing.Point(4, 24);
            this.tabAddSvr.Name = "tabAddSvr";
            this.tabAddSvr.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddSvr.Size = new System.Drawing.Size(462, 232);
            this.tabAddSvr.TabIndex = 0;
            this.tabAddSvr.Text = "Add Server";
            this.tabAddSvr.UseVisualStyleBackColor = true;
            // 
            // cmdAddSvr
            // 
            this.cmdAddSvr.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddSvr.Location = new System.Drawing.Point(316, 170);
            this.cmdAddSvr.Name = "cmdAddSvr";
            this.cmdAddSvr.Size = new System.Drawing.Size(117, 37);
            this.cmdAddSvr.TabIndex = 6;
            this.cmdAddSvr.Text = "Add";
            this.cmdAddSvr.UseVisualStyleBackColor = false;
            this.cmdAddSvr.Click += new System.EventHandler(this.cmdAddSvr_Click);
            // 
            // lstServerOutReplset
            // 
            this.lstServerOutReplset.FormattingEnabled = true;
            this.lstServerOutReplset.ItemHeight = 15;
            this.lstServerOutReplset.Location = new System.Drawing.Point(23, 23);
            this.lstServerOutReplset.Name = "lstServerOutReplset";
            this.lstServerOutReplset.Size = new System.Drawing.Size(410, 124);
            this.lstServerOutReplset.TabIndex = 5;
            // 
            // tabRemoveSvr
            // 
            this.tabRemoveSvr.Controls.Add(this.cmdRemove);
            this.tabRemoveSvr.Controls.Add(this.lstServerInReplset);
            this.tabRemoveSvr.Location = new System.Drawing.Point(4, 24);
            this.tabRemoveSvr.Name = "tabRemoveSvr";
            this.tabRemoveSvr.Padding = new System.Windows.Forms.Padding(3);
            this.tabRemoveSvr.Size = new System.Drawing.Size(462, 232);
            this.tabRemoveSvr.TabIndex = 1;
            this.tabRemoveSvr.Text = "Remove Server";
            this.tabRemoveSvr.UseVisualStyleBackColor = true;
            // 
            // cmdRemove
            // 
            this.cmdRemove.BackColor = System.Drawing.Color.Transparent;
            this.cmdRemove.Location = new System.Drawing.Point(316, 170);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(117, 37);
            this.cmdRemove.TabIndex = 1;
            this.cmdRemove.Text = "Drop";
            this.cmdRemove.UseVisualStyleBackColor = false;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // lstServerInReplset
            // 
            this.lstServerInReplset.FormattingEnabled = true;
            this.lstServerInReplset.ItemHeight = 15;
            this.lstServerInReplset.Location = new System.Drawing.Point(23, 23);
            this.lstServerInReplset.Name = "lstServerInReplset";
            this.lstServerInReplset.Size = new System.Drawing.Size(408, 124);
            this.lstServerInReplset.TabIndex = 0;
            // 
            // frmReplset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 294);
            this.Controls.Add(this.tabReplset);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReplset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replset Config";
            this.Load += new System.EventHandler(this.frmReplset_Load);
            this.tabReplset.ResumeLayout(false);
            this.tabAddSvr.ResumeLayout(false);
            this.tabRemoveSvr.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabReplset;
        private System.Windows.Forms.TabPage tabAddSvr;
        private System.Windows.Forms.TabPage tabRemoveSvr;
        private System.Windows.Forms.ListBox lstServerOutReplset;
        private System.Windows.Forms.ListBox lstServerInReplset;
        private System.Windows.Forms.Button cmdAddSvr;
        private System.Windows.Forms.Button cmdRemove;

    }
}