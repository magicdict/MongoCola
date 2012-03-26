namespace MagicMongoDBTool
{
    partial class frmAddReplsetMember
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
            ((System.ComponentModel.ISupportInitialize)(this.NumReplPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // NumReplPort
            // 
            this.NumReplPort.Location = new System.Drawing.Point(95, 38);
            this.NumReplPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NumReplPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumReplPort.Name = "NumReplPort";
            this.NumReplPort.Size = new System.Drawing.Size(122, 22);
            this.NumReplPort.TabIndex = 37;
            this.NumReplPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblReplPort
            // 
            this.lblReplPort.AutoSize = true;
            this.lblReplPort.BackColor = System.Drawing.Color.Transparent;
            this.lblReplPort.Location = new System.Drawing.Point(35, 40);
            this.lblReplPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReplPort.Name = "lblReplPort";
            this.lblReplPort.Size = new System.Drawing.Size(32, 16);
            this.lblReplPort.TabIndex = 40;
            this.lblReplPort.Text = "Port";
            // 
            // txtReplHost
            // 
            this.txtReplHost.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtReplHost.Location = new System.Drawing.Point(95, 10);
            this.txtReplHost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtReplHost.Name = "txtReplHost";
            this.txtReplHost.Size = new System.Drawing.Size(121, 22);
            this.txtReplHost.TabIndex = 36;
            // 
            // lblReplHost
            // 
            this.lblReplHost.AutoSize = true;
            this.lblReplHost.BackColor = System.Drawing.Color.Transparent;
            this.lblReplHost.Location = new System.Drawing.Point(35, 9);
            this.lblReplHost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReplHost.Name = "lblReplHost";
            this.lblReplHost.Size = new System.Drawing.Size(36, 16);
            this.lblReplHost.TabIndex = 39;
            this.lblReplHost.Text = "Host";
            // 
            // cmdAddHost
            // 
            this.cmdAddHost.Location = new System.Drawing.Point(65, 132);
            this.cmdAddHost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdAddHost.Name = "cmdAddHost";
            this.cmdAddHost.Size = new System.Drawing.Size(124, 38);
            this.cmdAddHost.TabIndex = 38;
            this.cmdAddHost.Text = "Add Host";
            this.cmdAddHost.UseVisualStyleBackColor = true;
            this.cmdAddHost.Click += new System.EventHandler(this.cmdAddHost_Click);
            // 
            // NumPriority
            // 
            this.NumPriority.Location = new System.Drawing.Point(95, 72);
            this.NumPriority.Margin = new System.Windows.Forms.Padding(4);
            this.NumPriority.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumPriority.Name = "NumPriority";
            this.NumPriority.Size = new System.Drawing.Size(122, 22);
            this.NumPriority.TabIndex = 41;
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
            this.lblpriority.Location = new System.Drawing.Point(35, 74);
            this.lblpriority.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblpriority.Name = "lblpriority";
            this.lblpriority.Size = new System.Drawing.Size(48, 16);
            this.lblpriority.TabIndex = 42;
            this.lblpriority.Text = "priority";
            // 
            // chkArbiterOnly
            // 
            this.chkArbiterOnly.AutoSize = true;
            this.chkArbiterOnly.Location = new System.Drawing.Point(38, 105);
            this.chkArbiterOnly.Name = "chkArbiterOnly";
            this.chkArbiterOnly.Size = new System.Drawing.Size(93, 20);
            this.chkArbiterOnly.TabIndex = 43;
            this.chkArbiterOnly.Text = "ArbiterOnly";
            this.chkArbiterOnly.UseVisualStyleBackColor = true;
            // 
            // frmAddReplsetMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 183);
            this.Controls.Add(this.chkArbiterOnly);
            this.Controls.Add(this.NumPriority);
            this.Controls.Add(this.lblpriority);
            this.Controls.Add(this.NumReplPort);
            this.Controls.Add(this.lblReplPort);
            this.Controls.Add(this.txtReplHost);
            this.Controls.Add(this.lblReplHost);
            this.Controls.Add(this.cmdAddHost);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAddReplsetMember";
            this.Text = "Add Replset Member";
            ((System.ComponentModel.ISupportInitialize)(this.NumReplPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPriority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}