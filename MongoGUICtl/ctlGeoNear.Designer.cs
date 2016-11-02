using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MongoGUICtl
{
    partial class CtlGeoNear
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

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
            this.chkHaystack = new System.Windows.Forms.CheckBox();
            this.trvGeoResult = new MongoGUICtl.CtlTreeViewColumns();
            this.cmdGeoJson = new System.Windows.Forms.Button();
            this.lblPoint = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumResultCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(352, 67);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(35, 21);
            this.btnHelp.TabIndex = 33;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnMile
            // 
            this.btnMile.Location = new System.Drawing.Point(288, 67);
            this.btnMile.Name = "btnMile";
            this.btnMile.Size = new System.Drawing.Size(58, 21);
            this.btnMile.TabIndex = 32;
            this.btnMile.Text = "Mile";
            this.btnMile.UseVisualStyleBackColor = true;
            this.btnMile.Click += new System.EventHandler(this.btnMile_Click);
            // 
            // btnKM
            // 
            this.btnKM.Location = new System.Drawing.Point(230, 67);
            this.btnKM.Name = "btnKM";
            this.btnKM.Size = new System.Drawing.Size(52, 21);
            this.btnKM.TabIndex = 31;
            this.btnKM.Text = "KM";
            this.btnKM.UseVisualStyleBackColor = true;
            this.btnKM.Click += new System.EventHandler(this.btnKM_Click);
            // 
            // NumMaxDistance
            // 
            this.NumMaxDistance.Location = new System.Drawing.Point(95, 71);
            this.NumMaxDistance.Name = "NumMaxDistance";
            this.NumMaxDistance.Size = new System.Drawing.Size(116, 21);
            this.NumMaxDistance.TabIndex = 29;
            this.NumMaxDistance.Text = "1";
            this.NumMaxDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NumDistanceMultiplier
            // 
            this.NumDistanceMultiplier.Location = new System.Drawing.Point(469, 44);
            this.NumDistanceMultiplier.Name = "NumDistanceMultiplier";
            this.NumDistanceMultiplier.Size = new System.Drawing.Size(116, 21);
            this.NumDistanceMultiplier.TabIndex = 30;
            this.NumDistanceMultiplier.Text = "1";
            this.NumDistanceMultiplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMaxDistance
            // 
            this.lblMaxDistance.AutoSize = true;
            this.lblMaxDistance.Location = new System.Drawing.Point(12, 71);
            this.lblMaxDistance.Name = "lblMaxDistance";
            this.lblMaxDistance.Size = new System.Drawing.Size(77, 12);
            this.lblMaxDistance.TabIndex = 26;
            this.lblMaxDistance.Text = "Max Distance";
            // 
            // lblDistanceMultiplier
            // 
            this.lblDistanceMultiplier.AutoSize = true;
            this.lblDistanceMultiplier.Location = new System.Drawing.Point(345, 46);
            this.lblDistanceMultiplier.Name = "lblDistanceMultiplier";
            this.lblDistanceMultiplier.Size = new System.Drawing.Size(119, 12);
            this.lblDistanceMultiplier.TabIndex = 25;
            this.lblDistanceMultiplier.Text = "Distance Multiplier";
            // 
            // chkSpherical
            // 
            this.chkSpherical.AutoSize = true;
            this.chkSpherical.Location = new System.Drawing.Point(231, 17);
            this.chkSpherical.Name = "chkSpherical";
            this.chkSpherical.Size = new System.Drawing.Size(78, 16);
            this.chkSpherical.TabIndex = 24;
            this.chkSpherical.Text = "Spherical";
            this.chkSpherical.UseVisualStyleBackColor = true;
            // 
            // NumResultCount
            // 
            this.NumResultCount.Location = new System.Drawing.Point(95, 15);
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
            this.cmdGeoNear.Location = new System.Drawing.Point(498, 10);
            this.cmdGeoNear.Name = "cmdGeoNear";
            this.cmdGeoNear.Size = new System.Drawing.Size(87, 27);
            this.cmdGeoNear.TabIndex = 22;
            this.cmdGeoNear.Text = "GeoNear";
            this.cmdGeoNear.UseVisualStyleBackColor = true;
            this.cmdGeoNear.Click += new System.EventHandler(this.cmdGeoNear_Click);
            // 
            // lblGeoNear
            // 
            this.lblGeoNear.AutoSize = true;
            this.lblGeoNear.Location = new System.Drawing.Point(12, 47);
            this.lblGeoNear.Name = "lblGeoNear";
            this.lblGeoNear.Size = new System.Drawing.Size(65, 12);
            this.lblGeoNear.TabIndex = 20;
            this.lblGeoNear.Text = "Near(X,Y):";
            // 
            // lblResultCount
            // 
            this.lblResultCount.AutoSize = true;
            this.lblResultCount.Location = new System.Drawing.Point(12, 17);
            this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.Size = new System.Drawing.Size(71, 12);
            this.lblResultCount.TabIndex = 19;
            this.lblResultCount.Text = "ResultCount";
            // 
            // lnkGeoNear
            // 
            this.lnkGeoNear.AutoSize = true;
            this.lnkGeoNear.Location = new System.Drawing.Point(13, 347);
            this.lnkGeoNear.Name = "lnkGeoNear";
            this.lnkGeoNear.Size = new System.Drawing.Size(353, 12);
            this.lnkGeoNear.TabIndex = 18;
            this.lnkGeoNear.TabStop = true;
            this.lnkGeoNear.Text = "http://docs.mongodb.org/manual/reference/commands/#geoNear";
            this.lnkGeoNear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGeoNear_LinkClicked);
            // 
            // chkHaystack
            // 
            this.chkHaystack.AutoSize = true;
            this.chkHaystack.Location = new System.Drawing.Point(314, 17);
            this.chkHaystack.Name = "chkHaystack";
            this.chkHaystack.Size = new System.Drawing.Size(168, 16);
            this.chkHaystack.TabIndex = 24;
            this.chkHaystack.Text = "GeoSpatialHaystack Index";
            this.chkHaystack.UseVisualStyleBackColor = true;
            // 
            // trvGeoResult
            // 
            this.trvGeoResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvGeoResult.Location = new System.Drawing.Point(15, 94);
            this.trvGeoResult.Name = "trvGeoResult";
            this.trvGeoResult.Padding = new System.Windows.Forms.Padding(1);
            this.trvGeoResult.Size = new System.Drawing.Size(570, 235);
            this.trvGeoResult.TabIndex = 21;
            // 
            // cmdGeoJson
            // 
            this.cmdGeoJson.Location = new System.Drawing.Point(95, 44);
            this.cmdGeoJson.Name = "cmdGeoJson";
            this.cmdGeoJson.Size = new System.Drawing.Size(75, 23);
            this.cmdGeoJson.TabIndex = 34;
            this.cmdGeoJson.Text = "GeoJson";
            this.cmdGeoJson.UseVisualStyleBackColor = true;
            this.cmdGeoJson.Click += new System.EventHandler(this.cmdGeoJson_Click);
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Location = new System.Drawing.Point(188, 49);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(35, 12);
            this.lblPoint.TabIndex = 35;
            this.lblPoint.Text = "Point";
            // 
            // CtlGeoNear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPoint);
            this.Controls.Add(this.cmdGeoJson);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnMile);
            this.Controls.Add(this.btnKM);
            this.Controls.Add(this.NumMaxDistance);
            this.Controls.Add(this.NumDistanceMultiplier);
            this.Controls.Add(this.lblMaxDistance);
            this.Controls.Add(this.lblDistanceMultiplier);
            this.Controls.Add(this.chkHaystack);
            this.Controls.Add(this.chkSpherical);
            this.Controls.Add(this.NumResultCount);
            this.Controls.Add(this.cmdGeoNear);
            this.Controls.Add(this.lblGeoNear);
            this.Controls.Add(this.lblResultCount);
            this.Controls.Add(this.lnkGeoNear);
            this.Controls.Add(this.trvGeoResult);
            this.Name = "CtlGeoNear";
            this.Size = new System.Drawing.Size(631, 392);
            ((System.ComponentModel.ISupportInitialize)(this.NumResultCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnHelp;
        private Button btnMile;
        private Button btnKM;
        private TextBox NumMaxDistance;
        private TextBox NumDistanceMultiplier;
        private Label lblMaxDistance;
        private Label lblDistanceMultiplier;
        private CheckBox chkSpherical;
        private NumericUpDown NumResultCount;
        private Button cmdGeoNear;
        private Label lblGeoNear;
        private Label lblResultCount;
        private LinkLabel lnkGeoNear;
        private CtlTreeViewColumns trvGeoResult;
        private CheckBox chkHaystack;
        private Button cmdGeoJson;
        private Label lblPoint;
    }
}
