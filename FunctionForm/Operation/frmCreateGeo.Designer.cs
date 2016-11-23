namespace FunctionForm.Operation
{
    partial class frmCreateGeo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.rad2d = new System.Windows.Forms.RadioButton();
            this.rad2dSphere = new System.Windows.Forms.RadioButton();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLongitude);
            this.groupBox1.Controls.Add(this.txtLatitude);
            this.groupBox1.Controls.Add(this.lblLatitude);
            this.groupBox1.Controls.Add(this.lblLongitude);
            this.groupBox1.Controls.Add(this.rad2d);
            this.groupBox1.Controls.Add(this.rad2dSphere);
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Geo Type";
            // 
            // txtLongitude
            // 
            this.txtLongitude.Location = new System.Drawing.Point(129, 52);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(100, 21);
            this.txtLongitude.TabIndex = 3;
            // 
            // txtLatitude
            // 
            this.txtLatitude.Location = new System.Drawing.Point(129, 82);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(100, 21);
            this.txtLatitude.TabIndex = 5;
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Location = new System.Drawing.Point(28, 82);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(59, 12);
            this.lblLatitude.TabIndex = 4;
            this.lblLatitude.Tag = "Common.Latitude";
            this.lblLatitude.Text = "latitude ";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Location = new System.Drawing.Point(28, 55);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(59, 12);
            this.lblLongitude.TabIndex = 2;
            this.lblLongitude.Tag = "Common.Longitude";
            this.lblLongitude.Text = "longitude";
            // 
            // rad2d
            // 
            this.rad2d.AutoSize = true;
            this.rad2d.Location = new System.Drawing.Point(29, 20);
            this.rad2d.Name = "rad2d";
            this.rad2d.Size = new System.Drawing.Size(35, 16);
            this.rad2d.TabIndex = 0;
            this.rad2d.TabStop = true;
            this.rad2d.Tag = "Common.TwoD";
            this.rad2d.Text = "2D";
            this.rad2d.UseVisualStyleBackColor = true;
            // 
            // rad2dSphere
            // 
            this.rad2dSphere.AutoSize = true;
            this.rad2dSphere.Location = new System.Drawing.Point(129, 20);
            this.rad2dSphere.Name = "rad2dSphere";
            this.rad2dSphere.Size = new System.Drawing.Size(113, 16);
            this.rad2dSphere.TabIndex = 1;
            this.rad2dSphere.TabStop = true;
            this.rad2dSphere.Tag = "Common.TwoDSphere";
            this.rad2dSphere.Text = "2dSphere(WGS84)";
            this.rad2dSphere.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(170, 153);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(82, 25);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Tag = "Common.Cancel";
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(82, 153);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(82, 25);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Tag = "Common.OK";
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmCreateGeo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(351, 190);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateGeo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create GeoJSON";
            this.Load += new System.EventHandler(this.frmCreateGeo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rad2d;
        private System.Windows.Forms.RadioButton rad2dSphere;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
    }
}