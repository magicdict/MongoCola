namespace MagicMongoDBTool
{
    partial class frmQuery
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
            this.cmdAddCondition = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabFieldInfo = new System.Windows.Forms.TabPage();
            this.tabCondition = new System.Windows.Forms.TabPage();
            this.panFilter = new System.Windows.Forms.Panel();
            this.tabgeoNear = new System.Windows.Forms.TabPage();
            this.lblMaxDistance = new System.Windows.Forms.Label();
            this.lblDistanceMultiplier = new System.Windows.Forms.Label();
            this.chkSpherical = new System.Windows.Forms.CheckBox();
            this.NumMaxDistance = new System.Windows.Forms.NumericUpDown();
            this.NumResultCount = new System.Windows.Forms.NumericUpDown();
            this.cmdGeoNear = new System.Windows.Forms.Button();
            this.NumGeoY = new System.Windows.Forms.NumericUpDown();
            this.NumGeoX = new System.Windows.Forms.NumericUpDown();
            this.lblGeoNear = new System.Windows.Forms.Label();
            this.lblResultCount = new System.Windows.Forms.Label();
            this.lnkGeoNear = new System.Windows.Forms.LinkLabel();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.NumDistanceMultiplier = new System.Windows.Forms.TextBox();
            this.btnKM = new System.Windows.Forms.Button();
            this.btnMile = new System.Windows.Forms.Button();
            this.trvGeoResult = new TreeViewColumnsProject.TreeViewColumns();
            this.btnHelp = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabCondition.SuspendLayout();
            this.tabgeoNear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumResultCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumGeoY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumGeoX)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdAddCondition
            // 
            this.cmdAddCondition.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddCondition.Location = new System.Drawing.Point(445, 393);
            this.cmdAddCondition.Name = "cmdAddCondition";
            this.cmdAddCondition.Size = new System.Drawing.Size(114, 36);
            this.cmdAddCondition.TabIndex = 14;
            this.cmdAddCondition.Text = "AddFilter";
            this.cmdAddCondition.UseVisualStyleBackColor = false;
            this.cmdAddCondition.Click += new System.EventHandler(this.cmdAddCondition_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(389, 504);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(88, 33);
            this.cmdOK.TabIndex = 12;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabFieldInfo);
            this.tabControl.Controls.Add(this.tabCondition);
            this.tabControl.Controls.Add(this.tabgeoNear);
            this.tabControl.Location = new System.Drawing.Point(16, 23);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(579, 466);
            this.tabControl.TabIndex = 0;
            // 
            // tabFieldInfo
            // 
            this.tabFieldInfo.Location = new System.Drawing.Point(4, 24);
            this.tabFieldInfo.Name = "tabFieldInfo";
            this.tabFieldInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabFieldInfo.Size = new System.Drawing.Size(571, 438);
            this.tabFieldInfo.TabIndex = 0;
            this.tabFieldInfo.Text = "Output Fields";
            this.tabFieldInfo.UseVisualStyleBackColor = true;
            // 
            // tabCondition
            // 
            this.tabCondition.Controls.Add(this.panFilter);
            this.tabCondition.Controls.Add(this.cmdAddCondition);
            this.tabCondition.Location = new System.Drawing.Point(4, 24);
            this.tabCondition.Name = "tabCondition";
            this.tabCondition.Padding = new System.Windows.Forms.Padding(3);
            this.tabCondition.Size = new System.Drawing.Size(571, 438);
            this.tabCondition.TabIndex = 1;
            this.tabCondition.Text = "Condition";
            this.tabCondition.UseVisualStyleBackColor = true;
            // 
            // panFilter
            // 
            this.panFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panFilter.Location = new System.Drawing.Point(3, 3);
            this.panFilter.Name = "panFilter";
            this.panFilter.Size = new System.Drawing.Size(565, 383);
            this.panFilter.TabIndex = 15;
            // 
            // tabgeoNear
            // 
            this.tabgeoNear.Controls.Add(this.btnHelp);
            this.tabgeoNear.Controls.Add(this.btnMile);
            this.tabgeoNear.Controls.Add(this.btnKM);
            this.tabgeoNear.Controls.Add(this.NumDistanceMultiplier);
            this.tabgeoNear.Controls.Add(this.lblMaxDistance);
            this.tabgeoNear.Controls.Add(this.lblDistanceMultiplier);
            this.tabgeoNear.Controls.Add(this.chkSpherical);
            this.tabgeoNear.Controls.Add(this.NumMaxDistance);
            this.tabgeoNear.Controls.Add(this.NumResultCount);
            this.tabgeoNear.Controls.Add(this.cmdGeoNear);
            this.tabgeoNear.Controls.Add(this.NumGeoY);
            this.tabgeoNear.Controls.Add(this.NumGeoX);
            this.tabgeoNear.Controls.Add(this.lblGeoNear);
            this.tabgeoNear.Controls.Add(this.lblResultCount);
            this.tabgeoNear.Controls.Add(this.lnkGeoNear);
            this.tabgeoNear.Controls.Add(this.trvGeoResult);
            this.tabgeoNear.Location = new System.Drawing.Point(4, 24);
            this.tabgeoNear.Name = "tabgeoNear";
            this.tabgeoNear.Padding = new System.Windows.Forms.Padding(3);
            this.tabgeoNear.Size = new System.Drawing.Size(571, 438);
            this.tabgeoNear.TabIndex = 2;
            this.tabgeoNear.Text = "geoNear";
            this.tabgeoNear.UseVisualStyleBackColor = true;
            // 
            // lblMaxDistance
            // 
            this.lblMaxDistance.AutoSize = true;
            this.lblMaxDistance.Location = new System.Drawing.Point(37, 85);
            this.lblMaxDistance.Name = "lblMaxDistance";
            this.lblMaxDistance.Size = new System.Drawing.Size(82, 15);
            this.lblMaxDistance.TabIndex = 13;
            this.lblMaxDistance.Text = "Max Distance";
            // 
            // lblDistanceMultiplier
            // 
            this.lblDistanceMultiplier.AutoSize = true;
            this.lblDistanceMultiplier.Location = new System.Drawing.Point(281, 60);
            this.lblDistanceMultiplier.Name = "lblDistanceMultiplier";
            this.lblDistanceMultiplier.Size = new System.Drawing.Size(109, 15);
            this.lblDistanceMultiplier.TabIndex = 12;
            this.lblDistanceMultiplier.Text = "Distance Multiplier";
            // 
            // chkSpherical
            // 
            this.chkSpherical.AutoSize = true;
            this.chkSpherical.Location = new System.Drawing.Point(285, 27);
            this.chkSpherical.Name = "chkSpherical";
            this.chkSpherical.Size = new System.Drawing.Size(78, 19);
            this.chkSpherical.TabIndex = 11;
            this.chkSpherical.Text = "Spherical";
            this.chkSpherical.UseVisualStyleBackColor = true;
            // 
            // NumMaxDistance
            // 
            this.NumMaxDistance.Location = new System.Drawing.Point(149, 83);
            this.NumMaxDistance.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.NumMaxDistance.Name = "NumMaxDistance";
            this.NumMaxDistance.Size = new System.Drawing.Size(108, 21);
            this.NumMaxDistance.TabIndex = 10;
            this.NumMaxDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NumResultCount
            // 
            this.NumResultCount.Location = new System.Drawing.Point(149, 25);
            this.NumResultCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumResultCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumResultCount.Name = "NumResultCount";
            this.NumResultCount.Size = new System.Drawing.Size(108, 21);
            this.NumResultCount.TabIndex = 8;
            this.NumResultCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumResultCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // cmdGeoNear
            // 
            this.cmdGeoNear.Location = new System.Drawing.Point(405, 17);
            this.cmdGeoNear.Name = "cmdGeoNear";
            this.cmdGeoNear.Size = new System.Drawing.Size(116, 29);
            this.cmdGeoNear.TabIndex = 7;
            this.cmdGeoNear.Text = "GeoNear";
            this.cmdGeoNear.UseVisualStyleBackColor = true;
            this.cmdGeoNear.Click += new System.EventHandler(this.cmdGeoNear_Click);
            // 
            // NumGeoY
            // 
            this.NumGeoY.Location = new System.Drawing.Point(206, 57);
            this.NumGeoY.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.NumGeoY.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.NumGeoY.Name = "NumGeoY";
            this.NumGeoY.Size = new System.Drawing.Size(51, 21);
            this.NumGeoY.TabIndex = 5;
            this.NumGeoY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NumGeoX
            // 
            this.NumGeoX.Location = new System.Drawing.Point(149, 57);
            this.NumGeoX.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.NumGeoX.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.NumGeoX.Name = "NumGeoX";
            this.NumGeoX.Size = new System.Drawing.Size(51, 21);
            this.NumGeoX.TabIndex = 4;
            this.NumGeoX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGeoNear
            // 
            this.lblGeoNear.AutoSize = true;
            this.lblGeoNear.Location = new System.Drawing.Point(37, 59);
            this.lblGeoNear.Name = "lblGeoNear";
            this.lblGeoNear.Size = new System.Drawing.Size(63, 15);
            this.lblGeoNear.TabIndex = 3;
            this.lblGeoNear.Text = "Near(X,Y):";
            // 
            // lblResultCount
            // 
            this.lblResultCount.AutoSize = true;
            this.lblResultCount.Location = new System.Drawing.Point(37, 27);
            this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.Size = new System.Drawing.Size(74, 15);
            this.lblResultCount.TabIndex = 1;
            this.lblResultCount.Text = "ResultCount";
            // 
            // lnkGeoNear
            // 
            this.lnkGeoNear.AutoSize = true;
            this.lnkGeoNear.Location = new System.Drawing.Point(37, 409);
            this.lnkGeoNear.Name = "lnkGeoNear";
            this.lnkGeoNear.Size = new System.Drawing.Size(362, 15);
            this.lnkGeoNear.TabIndex = 0;
            this.lnkGeoNear.TabStop = true;
            this.lnkGeoNear.Text = "http://docs.mongodb.org/manual/reference/commands/#geoNear";
            this.lnkGeoNear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGeoNear_LinkClicked);
            // 
            // cmdLoad
            // 
            this.cmdLoad.BackColor = System.Drawing.Color.Transparent;
            this.cmdLoad.Location = new System.Drawing.Point(160, 504);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(117, 33);
            this.cmdLoad.TabIndex = 13;
            this.cmdLoad.Text = "Load Query";
            this.cmdLoad.UseVisualStyleBackColor = false;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.Transparent;
            this.cmdSave.Location = new System.Drawing.Point(284, 504);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(99, 33);
            this.cmdSave.TabIndex = 14;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(483, 504);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(108, 33);
            this.cmdCancel.TabIndex = 15;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // NumDistanceMultiplier
            // 
            this.NumDistanceMultiplier.Location = new System.Drawing.Point(405, 57);
            this.NumDistanceMultiplier.Name = "NumDistanceMultiplier";
            this.NumDistanceMultiplier.Size = new System.Drawing.Size(116, 21);
            this.NumDistanceMultiplier.TabIndex = 14;
            this.NumDistanceMultiplier.Text = "1";
            this.NumDistanceMultiplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumDistanceMultiplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumDistanceMultiplier_KeyPress);
            // 
            // btnKM
            // 
            this.btnKM.Location = new System.Drawing.Point(284, 81);
            this.btnKM.Name = "btnKM";
            this.btnKM.Size = new System.Drawing.Size(52, 23);
            this.btnKM.TabIndex = 15;
            this.btnKM.Text = "KM";
            this.btnKM.UseVisualStyleBackColor = true;
            this.btnKM.Click += new System.EventHandler(this.btnKM_Click);
            // 
            // btnMile
            // 
            this.btnMile.Location = new System.Drawing.Point(342, 81);
            this.btnMile.Name = "btnMile";
            this.btnMile.Size = new System.Drawing.Size(58, 23);
            this.btnMile.TabIndex = 16;
            this.btnMile.Text = "mile";
            this.btnMile.UseVisualStyleBackColor = true;
            this.btnMile.Click += new System.EventHandler(this.btnMile_Click);
            // 
            // trvGeoResult
            // 
            this.trvGeoResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvGeoResult.Location = new System.Drawing.Point(40, 110);
            this.trvGeoResult.Name = "trvGeoResult";
            this.trvGeoResult.Padding = new System.Windows.Forms.Padding(1);
            this.trvGeoResult.Size = new System.Drawing.Size(496, 295);
            this.trvGeoResult.TabIndex = 6;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(406, 81);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(35, 23);
            this.btnHelp.TabIndex = 17;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(613, 554);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdLoad);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Query";
            this.Load += new System.EventHandler(this.frmQuery_Load);
            this.tabControl.ResumeLayout(false);
            this.tabCondition.ResumeLayout(false);
            this.tabgeoNear.ResumeLayout(false);
            this.tabgeoNear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumResultCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumGeoY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumGeoX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdAddCondition;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabFieldInfo;
        private System.Windows.Forms.TabPage tabCondition;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Panel panFilter;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TabPage tabgeoNear;
        private System.Windows.Forms.LinkLabel lnkGeoNear;
        private System.Windows.Forms.Label lblResultCount;
        private System.Windows.Forms.NumericUpDown NumGeoY;
        private System.Windows.Forms.NumericUpDown NumGeoX;
        private System.Windows.Forms.Label lblGeoNear;
        private System.Windows.Forms.Button cmdGeoNear;
        private TreeViewColumnsProject.TreeViewColumns trvGeoResult;
        private System.Windows.Forms.NumericUpDown NumResultCount;
        private System.Windows.Forms.CheckBox chkSpherical;
        private System.Windows.Forms.NumericUpDown NumMaxDistance;
        private System.Windows.Forms.Label lblMaxDistance;
        private System.Windows.Forms.Label lblDistanceMultiplier;
        private System.Windows.Forms.TextBox NumDistanceMultiplier;
        private System.Windows.Forms.Button btnMile;
        private System.Windows.Forms.Button btnKM;
        private System.Windows.Forms.Button btnHelp;
    }
}