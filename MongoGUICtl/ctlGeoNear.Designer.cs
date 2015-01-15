namespace MongoGUICtl
{
    partial class ctlGeoNear
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnMile = new System.Windows.Forms.Button();
            this.btnKM = new System.Windows.Forms.Button();
            this.NumGeoX = new System.Windows.Forms.TextBox();
            this.NumGeoY = new System.Windows.Forms.TextBox();
            this.NumMaxDistance = new System.Windows.Forms.TextBox();
            this.NumDistanceMultiplier = new System.Windows.Forms.TextBox();
            this.lblMaxDistance = new System.Windows.Forms.Label();
            this.lblDistanceMultiplier = new System.Windows.Forms.Label();
            this.chkSpherical = new System.Windows.Forms.CheckBox();
            this.NumResultCount = new System.Windows.Forms.NumericUpDown();
            this.cmdGeoNear = new System.Windows.Forms.Button();
            this.lblGeoNear = new System.Windows.Forms.Label();
            this.lblResultCount = new System.Windows.Forms.Label();
            this.lnkGeoNear = new System.Windows.Forms.LinkLabel();
            this.trvGeoResult = new ctlTreeViewColumns();
            ((System.ComponentModel.ISupportInitialize)(this.NumResultCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(372, 65);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(35, 23);
            this.btnHelp.TabIndex = 33;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnMile
            // 
            this.btnMile.Location = new System.Drawing.Point(308, 65);
            this.btnMile.Name = "btnMile";
            this.btnMile.Size = new System.Drawing.Size(58, 23);
            this.btnMile.TabIndex = 32;
            this.btnMile.Text = "Mile";
            this.btnMile.UseVisualStyleBackColor = true;
            this.btnMile.Click += new System.EventHandler(this.btnMile_Click);
            // 
            // btnKM
            // 
            this.btnKM.Location = new System.Drawing.Point(250, 65);
            this.btnKM.Name = "btnKM";
            this.btnKM.Size = new System.Drawing.Size(52, 23);
            this.btnKM.TabIndex = 31;
            this.btnKM.Text = "KM";
            this.btnKM.UseVisualStyleBackColor = true;
            this.btnKM.Click += new System.EventHandler(this.btnKM_Click);
            // 
            // NumGeoX
            // 
            this.NumGeoX.Location = new System.Drawing.Point(115, 38);
            this.NumGeoX.Name = "NumGeoX";
            this.NumGeoX.Size = new System.Drawing.Size(51, 20);
            this.NumGeoX.TabIndex = 27;
            this.NumGeoX.Text = "1";
            this.NumGeoX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NumGeoY
            // 
            this.NumGeoY.Location = new System.Drawing.Point(172, 38);
            this.NumGeoY.Name = "NumGeoY";
            this.NumGeoY.Size = new System.Drawing.Size(51, 20);
            this.NumGeoY.TabIndex = 28;
            this.NumGeoY.Text = "1";
            this.NumGeoY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NumMaxDistance
            // 
            this.NumMaxDistance.Location = new System.Drawing.Point(115, 69);
            this.NumMaxDistance.Name = "NumMaxDistance";
            this.NumMaxDistance.Size = new System.Drawing.Size(116, 20);
            this.NumMaxDistance.TabIndex = 29;
            this.NumMaxDistance.Text = "1";
            this.NumMaxDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NumDistanceMultiplier
            // 
            this.NumDistanceMultiplier.Location = new System.Drawing.Point(371, 41);
            this.NumDistanceMultiplier.Name = "NumDistanceMultiplier";
            this.NumDistanceMultiplier.Size = new System.Drawing.Size(116, 20);
            this.NumDistanceMultiplier.TabIndex = 30;
            this.NumDistanceMultiplier.Text = "1";
            this.NumDistanceMultiplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMaxDistance
            // 
            this.lblMaxDistance.AutoSize = true;
            this.lblMaxDistance.Location = new System.Drawing.Point(3, 69);
            this.lblMaxDistance.Name = "lblMaxDistance";
            this.lblMaxDistance.Size = new System.Drawing.Size(72, 13);
            this.lblMaxDistance.TabIndex = 26;
            this.lblMaxDistance.Text = "Max Distance";
            // 
            // lblDistanceMultiplier
            // 
            this.lblDistanceMultiplier.AutoSize = true;
            this.lblDistanceMultiplier.Location = new System.Drawing.Point(247, 44);
            this.lblDistanceMultiplier.Name = "lblDistanceMultiplier";
            this.lblDistanceMultiplier.Size = new System.Drawing.Size(93, 13);
            this.lblDistanceMultiplier.TabIndex = 25;
            this.lblDistanceMultiplier.Text = "Distance Multiplier";
            // 
            // chkSpherical
            // 
            this.chkSpherical.AutoSize = true;
            this.chkSpherical.Location = new System.Drawing.Point(251, 11);
            this.chkSpherical.Name = "chkSpherical";
            this.chkSpherical.Size = new System.Drawing.Size(70, 17);
            this.chkSpherical.TabIndex = 24;
            this.chkSpherical.Text = "Spherical";
            this.chkSpherical.UseVisualStyleBackColor = true;
            // 
            // NumResultCount
            // 
            this.NumResultCount.Location = new System.Drawing.Point(115, 9);
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
            this.NumResultCount.Size = new System.Drawing.Size(108, 20);
            this.NumResultCount.TabIndex = 23;
            this.NumResultCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumResultCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // cmdGeoNear
            // 
            this.cmdGeoNear.Location = new System.Drawing.Point(371, 1);
            this.cmdGeoNear.Name = "cmdGeoNear";
            this.cmdGeoNear.Size = new System.Drawing.Size(116, 29);
            this.cmdGeoNear.TabIndex = 22;
            this.cmdGeoNear.Text = "GeoNear";
            this.cmdGeoNear.UseVisualStyleBackColor = true;
            this.cmdGeoNear.Click += new System.EventHandler(this.cmdGeoNear_Click);
            // 
            // lblGeoNear
            // 
            this.lblGeoNear.AutoSize = true;
            this.lblGeoNear.Location = new System.Drawing.Point(3, 43);
            this.lblGeoNear.Name = "lblGeoNear";
            this.lblGeoNear.Size = new System.Drawing.Size(56, 13);
            this.lblGeoNear.TabIndex = 20;
            this.lblGeoNear.Text = "Near(X,Y):";
            // 
            // lblResultCount
            // 
            this.lblResultCount.AutoSize = true;
            this.lblResultCount.Location = new System.Drawing.Point(3, 11);
            this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.Size = new System.Drawing.Size(65, 13);
            this.lblResultCount.TabIndex = 19;
            this.lblResultCount.Text = "ResultCount";
            // 
            // lnkGeoNear
            // 
            this.lnkGeoNear.AutoSize = true;
            this.lnkGeoNear.Location = new System.Drawing.Point(16, 378);
            this.lnkGeoNear.Name = "lnkGeoNear";
            this.lnkGeoNear.Size = new System.Drawing.Size(324, 13);
            this.lnkGeoNear.TabIndex = 18;
            this.lnkGeoNear.TabStop = true;
            this.lnkGeoNear.Text = "http://docs.mongodb.org/manual/reference/commands/#geoNear";
            this.lnkGeoNear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGeoNear_LinkClicked);
            // 
            // trvGeoResult
            // 
            this.trvGeoResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvGeoResult.Location = new System.Drawing.Point(6, 94);
            this.trvGeoResult.Name = "trvGeoResult";
            this.trvGeoResult.Padding = new System.Windows.Forms.Padding(1);
            this.trvGeoResult.Size = new System.Drawing.Size(496, 281);
            this.trvGeoResult.TabIndex = 21;
            // 
            // ctlGeoNear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnMile);
            this.Controls.Add(this.btnKM);
            this.Controls.Add(this.NumGeoX);
            this.Controls.Add(this.NumGeoY);
            this.Controls.Add(this.NumMaxDistance);
            this.Controls.Add(this.NumDistanceMultiplier);
            this.Controls.Add(this.lblMaxDistance);
            this.Controls.Add(this.lblDistanceMultiplier);
            this.Controls.Add(this.chkSpherical);
            this.Controls.Add(this.NumResultCount);
            this.Controls.Add(this.cmdGeoNear);
            this.Controls.Add(this.lblGeoNear);
            this.Controls.Add(this.lblResultCount);
            this.Controls.Add(this.lnkGeoNear);
            this.Controls.Add(this.trvGeoResult);
            this.Name = "ctlGeoNear";
            this.Size = new System.Drawing.Size(508, 402);
            ((System.ComponentModel.ISupportInitialize)(this.NumResultCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnMile;
        private System.Windows.Forms.Button btnKM;
        private System.Windows.Forms.TextBox NumGeoX;
        private System.Windows.Forms.TextBox NumGeoY;
        private System.Windows.Forms.TextBox NumMaxDistance;
        private System.Windows.Forms.TextBox NumDistanceMultiplier;
        private System.Windows.Forms.Label lblMaxDistance;
        private System.Windows.Forms.Label lblDistanceMultiplier;
        private System.Windows.Forms.CheckBox chkSpherical;
        private System.Windows.Forms.NumericUpDown NumResultCount;
        private System.Windows.Forms.Button cmdGeoNear;
        private System.Windows.Forms.Label lblGeoNear;
        private System.Windows.Forms.Label lblResultCount;
        private System.Windows.Forms.LinkLabel lnkGeoNear;
        private ctlTreeViewColumns trvGeoResult;
    }
}
