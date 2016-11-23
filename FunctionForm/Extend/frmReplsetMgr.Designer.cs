using System.ComponentModel;
using System.Windows.Forms;

namespace FunctionForm.Extend
{
    partial class FrmReplsetMgr
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
            this.grpAddHost = new System.Windows.Forms.GroupBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.grpRemoveHost = new System.Windows.Forms.GroupBox();
            this.cmdRemoveHost = new System.Windows.Forms.Button();
            this.lstHost = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumReplPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPriority)).BeginInit();
            this.grpAddHost.SuspendLayout();
            this.grpRemoveHost.SuspendLayout();
            this.SuspendLayout();
            // 
            // NumReplPort
            // 
            this.NumReplPort.Location = new System.Drawing.Point(79, 52);
            this.NumReplPort.Margin = new System.Windows.Forms.Padding(4);
            this.NumReplPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumReplPort.Name = "NumReplPort";
            this.NumReplPort.Size = new System.Drawing.Size(107, 21);
            this.NumReplPort.TabIndex = 3;
            this.NumReplPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblReplPort
            // 
            this.lblReplPort.AutoSize = true;
            this.lblReplPort.BackColor = System.Drawing.Color.Transparent;
            this.lblReplPort.Location = new System.Drawing.Point(26, 54);
            this.lblReplPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReplPort.Name = "lblReplPort";
            this.lblReplPort.Size = new System.Drawing.Size(29, 15);
            this.lblReplPort.TabIndex = 2;
            this.lblReplPort.Tag = "Common.Port";
            this.lblReplPort.Text = "Port";
            // 
            // txtReplHost
            // 
            this.txtReplHost.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtReplHost.Location = new System.Drawing.Point(79, 27);
            this.txtReplHost.Margin = new System.Windows.Forms.Padding(4);
            this.txtReplHost.Name = "txtReplHost";
            this.txtReplHost.Size = new System.Drawing.Size(106, 21);
            this.txtReplHost.TabIndex = 1;
            // 
            // lblReplHost
            // 
            this.lblReplHost.AutoSize = true;
            this.lblReplHost.BackColor = System.Drawing.Color.Transparent;
            this.lblReplHost.Location = new System.Drawing.Point(26, 26);
            this.lblReplHost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReplHost.Name = "lblReplHost";
            this.lblReplHost.Size = new System.Drawing.Size(32, 15);
            this.lblReplHost.TabIndex = 0;
            this.lblReplHost.Tag = "Common.Host";
            this.lblReplHost.Text = "Host";
            // 
            // cmdAddHost
            // 
            this.cmdAddHost.Location = new System.Drawing.Point(52, 138);
            this.cmdAddHost.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAddHost.Name = "cmdAddHost";
            this.cmdAddHost.Size = new System.Drawing.Size(108, 36);
            this.cmdAddHost.TabIndex = 7;
            this.cmdAddHost.Tag = "AddConnection_Region_AddHost";
            this.cmdAddHost.Text = "Add Host";
            this.cmdAddHost.UseVisualStyleBackColor = true;
            this.cmdAddHost.Click += new System.EventHandler(this.cmdAddHost_Click);
            // 
            // NumPriority
            // 
            this.NumPriority.Location = new System.Drawing.Point(79, 82);
            this.NumPriority.Margin = new System.Windows.Forms.Padding(4);
            this.NumPriority.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumPriority.Name = "NumPriority";
            this.NumPriority.Size = new System.Drawing.Size(107, 21);
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
            this.lblpriority.Location = new System.Drawing.Point(26, 83);
            this.lblpriority.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblpriority.Name = "lblpriority";
            this.lblpriority.Size = new System.Drawing.Size(43, 15);
            this.lblpriority.TabIndex = 4;
            this.lblpriority.Tag = "AddConnection_Priority";
            this.lblpriority.Text = "priority";
            // 
            // chkArbiterOnly
            // 
            this.chkArbiterOnly.AutoSize = true;
            this.chkArbiterOnly.Location = new System.Drawing.Point(29, 112);
            this.chkArbiterOnly.Name = "chkArbiterOnly";
            this.chkArbiterOnly.Size = new System.Drawing.Size(85, 19);
            this.chkArbiterOnly.TabIndex = 6;
            this.chkArbiterOnly.Text = "ArbiterOnly";
            this.chkArbiterOnly.UseVisualStyleBackColor = true;
            // 
            // grpAddHost
            // 
            this.grpAddHost.Controls.Add(this.chkArbiterOnly);
            this.grpAddHost.Controls.Add(this.txtReplHost);
            this.grpAddHost.Controls.Add(this.NumPriority);
            this.grpAddHost.Controls.Add(this.lblReplHost);
            this.grpAddHost.Controls.Add(this.lblpriority);
            this.grpAddHost.Controls.Add(this.NumReplPort);
            this.grpAddHost.Controls.Add(this.lblReplPort);
            this.grpAddHost.Controls.Add(this.cmdAddHost);
            this.grpAddHost.Location = new System.Drawing.Point(18, 11);
            this.grpAddHost.Name = "grpAddHost";
            this.grpAddHost.Size = new System.Drawing.Size(214, 199);
            this.grpAddHost.TabIndex = 0;
            this.grpAddHost.TabStop = false;
            this.grpAddHost.Tag = "AddConnection_Region_AddHost";
            this.grpAddHost.Text = "Add Host Member";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(189, 225);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(108, 34);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Tag = "Common.Close";
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // grpRemoveHost
            // 
            this.grpRemoveHost.Controls.Add(this.cmdRemoveHost);
            this.grpRemoveHost.Controls.Add(this.lstHost);
            this.grpRemoveHost.Location = new System.Drawing.Point(254, 11);
            this.grpRemoveHost.Name = "grpRemoveHost";
            this.grpRemoveHost.Size = new System.Drawing.Size(237, 199);
            this.grpRemoveHost.TabIndex = 1;
            this.grpRemoveHost.TabStop = false;
            this.grpRemoveHost.Tag = "AddConnection_Region_RemoveHost";
            this.grpRemoveHost.Text = "Remove Host Member";
            // 
            // cmdRemoveHost
            // 
            this.cmdRemoveHost.Location = new System.Drawing.Point(58, 138);
            this.cmdRemoveHost.Name = "cmdRemoveHost";
            this.cmdRemoveHost.Size = new System.Drawing.Size(108, 36);
            this.cmdRemoveHost.TabIndex = 1;
            this.cmdRemoveHost.Tag = "AddConnection_Region_RemoveHost";
            this.cmdRemoveHost.Text = "Remove Host";
            this.cmdRemoveHost.UseVisualStyleBackColor = true;
            this.cmdRemoveHost.Click += new System.EventHandler(this.cmdRemoveHost_Click);
            // 
            // lstHost
            // 
            this.lstHost.FormattingEnabled = true;
            this.lstHost.ItemHeight = 15;
            this.lstHost.Location = new System.Drawing.Point(13, 27);
            this.lstHost.Name = "lstHost";
            this.lstHost.Size = new System.Drawing.Size(206, 94);
            this.lstHost.TabIndex = 0;
            // 
            // frmReplsetMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(514, 270);
            this.Controls.Add(this.grpRemoveHost);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.grpAddHost);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmReplsetMgr";
            this.Tag = "Main_Menu_Distributed_ReplicaSet";
            this.Text = "Add Replset Member";
            this.Load += new System.EventHandler(this.frmReplsetMgr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumReplPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPriority)).EndInit();
            this.grpAddHost.ResumeLayout(false);
            this.grpAddHost.PerformLayout();
            this.grpRemoveHost.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NumericUpDown NumReplPort;
        private Label lblReplPort;
        private TextBox txtReplHost;
        private Label lblReplHost;
        private Button cmdAddHost;
        private NumericUpDown NumPriority;
        private Label lblpriority;
        private CheckBox chkArbiterOnly;
        private GroupBox grpAddHost;
        private Button cmdClose;
        private GroupBox grpRemoveHost;
        private Button cmdRemoveHost;
        private ListBox lstHost;
    }
}