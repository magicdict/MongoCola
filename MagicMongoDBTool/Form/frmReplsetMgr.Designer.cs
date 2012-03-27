namespace MagicMongoDBTool
{
    partial class frmReplsetMgr
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
            this.NumReplPort = new System.Windows.Forms.NumericUpDown();
            this.lblReplPort = new System.Windows.Forms.Label();
            this.txtReplHost = new System.Windows.Forms.TextBox();
            this.lblReplHost = new System.Windows.Forms.Label();
            this.cmdAddHost = new System.Windows.Forms.Button();
            this.NumPriority = new System.Windows.Forms.NumericUpDown();
            this.lblpriority = new System.Windows.Forms.Label();
            this.chkArbiterOnly = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdRemoveHost = new System.Windows.Forms.Button();
            this.lstHost = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumReplPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPriority)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // NumReplPort
            // 
            this.NumReplPort.Location = new System.Drawing.Point(90, 56);
            this.NumReplPort.Margin = new System.Windows.Forms.Padding(4);
            this.NumReplPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumReplPort.Name = "NumReplPort";
            this.NumReplPort.Size = new System.Drawing.Size(122, 22);
            this.NumReplPort.TabIndex = 3;
            this.NumReplPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblReplPort
            // 
            this.lblReplPort.AutoSize = true;
            this.lblReplPort.BackColor = System.Drawing.Color.Transparent;
            this.lblReplPort.Location = new System.Drawing.Point(30, 58);
            this.lblReplPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReplPort.Name = "lblReplPort";
            this.lblReplPort.Size = new System.Drawing.Size(32, 16);
            this.lblReplPort.TabIndex = 2;
            this.lblReplPort.Text = "Port";
            // 
            // txtReplHost
            // 
            this.txtReplHost.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtReplHost.Location = new System.Drawing.Point(90, 29);
            this.txtReplHost.Margin = new System.Windows.Forms.Padding(4);
            this.txtReplHost.Name = "txtReplHost";
            this.txtReplHost.Size = new System.Drawing.Size(121, 22);
            this.txtReplHost.TabIndex = 1;
            // 
            // lblReplHost
            // 
            this.lblReplHost.AutoSize = true;
            this.lblReplHost.BackColor = System.Drawing.Color.Transparent;
            this.lblReplHost.Location = new System.Drawing.Point(30, 28);
            this.lblReplHost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReplHost.Name = "lblReplHost";
            this.lblReplHost.Size = new System.Drawing.Size(36, 16);
            this.lblReplHost.TabIndex = 0;
            this.lblReplHost.Text = "Host";
            // 
            // cmdAddHost
            // 
            this.cmdAddHost.Location = new System.Drawing.Point(60, 147);
            this.cmdAddHost.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAddHost.Name = "cmdAddHost";
            this.cmdAddHost.Size = new System.Drawing.Size(124, 38);
            this.cmdAddHost.TabIndex = 7;
            this.cmdAddHost.Text = "Add Host";
            this.cmdAddHost.UseVisualStyleBackColor = true;
            this.cmdAddHost.Click += new System.EventHandler(this.cmdAddHost_Click);
            // 
            // NumPriority
            // 
            this.NumPriority.Location = new System.Drawing.Point(90, 87);
            this.NumPriority.Margin = new System.Windows.Forms.Padding(4);
            this.NumPriority.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumPriority.Name = "NumPriority";
            this.NumPriority.Size = new System.Drawing.Size(122, 22);
            this.NumPriority.TabIndex = 5;
            this.NumPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumPriority.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblpriority
            // 
            this.lblpriority.AutoSize = true;
            this.lblpriority.BackColor = System.Drawing.Color.Transparent;
            this.lblpriority.Location = new System.Drawing.Point(30, 89);
            this.lblpriority.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblpriority.Name = "lblpriority";
            this.lblpriority.Size = new System.Drawing.Size(48, 16);
            this.lblpriority.TabIndex = 4;
            this.lblpriority.Text = "priority";
            // 
            // chkArbiterOnly
            // 
            this.chkArbiterOnly.AutoSize = true;
            this.chkArbiterOnly.Location = new System.Drawing.Point(33, 120);
            this.chkArbiterOnly.Name = "chkArbiterOnly";
            this.chkArbiterOnly.Size = new System.Drawing.Size(77, 17);
            this.chkArbiterOnly.TabIndex = 6;
            this.chkArbiterOnly.Text = "ArbiterOnly";
            this.chkArbiterOnly.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkArbiterOnly);
            this.groupBox1.Controls.Add(this.txtReplHost);
            this.groupBox1.Controls.Add(this.NumPriority);
            this.groupBox1.Controls.Add(this.lblReplHost);
            this.groupBox1.Controls.Add(this.lblpriority);
            this.groupBox1.Controls.Add(this.NumReplPort);
            this.groupBox1.Controls.Add(this.lblReplPort);
            this.groupBox1.Controls.Add(this.cmdAddHost);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 212);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Host Member";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(216, 240);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(124, 36);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdRemoveHost);
            this.groupBox2.Controls.Add(this.lstHost);
            this.groupBox2.Location = new System.Drawing.Point(290, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 212);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remove Host Member";
            // 
            // cmdRemoveHost
            // 
            this.cmdRemoveHost.Enabled = false;
            this.cmdRemoveHost.Location = new System.Drawing.Point(66, 147);
            this.cmdRemoveHost.Name = "cmdRemoveHost";
            this.cmdRemoveHost.Size = new System.Drawing.Size(123, 38);
            this.cmdRemoveHost.TabIndex = 1;
            this.cmdRemoveHost.Text = "Remove Host";
            this.cmdRemoveHost.UseVisualStyleBackColor = true;
            this.cmdRemoveHost.Click += new System.EventHandler(this.cmdRemoveHost_Click);
            // 
            // lstHost
            // 
            this.lstHost.FormattingEnabled = true;
            this.lstHost.ItemHeight = 16;
            this.lstHost.Location = new System.Drawing.Point(15, 29);
            this.lstHost.Name = "lstHost";
            this.lstHost.Size = new System.Drawing.Size(235, 100);
            this.lstHost.TabIndex = 0;
            // 
            // frmReplsetMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(587, 288);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReplsetMgr";
            this.Text = "Add Replset Member";
            this.Load += new System.EventHandler(this.frmReplsetMgr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumReplPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPriority)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumReplPort;
        private System.Windows.Forms.Label lblReplPort;
        private System.Windows.Forms.TextBox txtReplHost;
        private System.Windows.Forms.Label lblReplHost;
        private System.Windows.Forms.Button cmdAddHost;
        private System.Windows.Forms.NumericUpDown NumPriority;
        private System.Windows.Forms.Label lblpriority;
        private System.Windows.Forms.CheckBox chkArbiterOnly;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdRemoveHost;
        private System.Windows.Forms.ListBox lstHost;
    }
}