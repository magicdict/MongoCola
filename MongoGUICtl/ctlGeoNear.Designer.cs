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
            this.btnHelp = new Button();
            this.btnMile = new Button();
            this.btnKM = new Button();
            this.NumGeoX = new TextBox();
            this.NumGeoY = new TextBox();
            this.NumMaxDistance = new TextBox();
            this.NumDistanceMultiplier = new TextBox();
            this.lblMaxDistance = new Label();
            this.lblDistanceMultiplier = new Label();
            this.chkSpherical = new CheckBox();
            this.NumResultCount = new NumericUpDown();
            this.cmdGeoNear = new Button();
            this.lblGeoNear = new Label();
            this.lblResultCount = new Label();
            this.lnkGeoNear = new LinkLabel();
            this.trvGeoResult = new CtlTreeViewColumns();
            ((ISupportInitialize)(this.NumResultCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new Point(372, 65);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new Size(35, 23);
            this.btnHelp.TabIndex = 33;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new EventHandler(this.btnHelp_Click);
            // 
            // btnMile
            // 
            this.btnMile.Location = new Point(308, 65);
            this.btnMile.Name = "btnMile";
            this.btnMile.Size = new Size(58, 23);
            this.btnMile.TabIndex = 32;
            this.btnMile.Text = "Mile";
            this.btnMile.UseVisualStyleBackColor = true;
            this.btnMile.Click += new EventHandler(this.btnMile_Click);
            // 
            // btnKM
            // 
            this.btnKM.Location = new Point(250, 65);
            this.btnKM.Name = "btnKM";
            this.btnKM.Size = new Size(52, 23);
            this.btnKM.TabIndex = 31;
            this.btnKM.Text = "KM";
            this.btnKM.UseVisualStyleBackColor = true;
            this.btnKM.Click += new EventHandler(this.btnKM_Click);
            // 
            // NumGeoX
            // 
            this.NumGeoX.Location = new Point(115, 38);
            this.NumGeoX.Name = "NumGeoX";
            this.NumGeoX.Size = new Size(51, 20);
            this.NumGeoX.TabIndex = 27;
            this.NumGeoX.Text = "1";
            this.NumGeoX.TextAlign = HorizontalAlignment.Right;
            // 
            // NumGeoY
            // 
            this.NumGeoY.Location = new Point(172, 38);
            this.NumGeoY.Name = "NumGeoY";
            this.NumGeoY.Size = new Size(51, 20);
            this.NumGeoY.TabIndex = 28;
            this.NumGeoY.Text = "1";
            this.NumGeoY.TextAlign = HorizontalAlignment.Right;
            // 
            // NumMaxDistance
            // 
            this.NumMaxDistance.Location = new Point(115, 69);
            this.NumMaxDistance.Name = "NumMaxDistance";
            this.NumMaxDistance.Size = new Size(116, 20);
            this.NumMaxDistance.TabIndex = 29;
            this.NumMaxDistance.Text = "1";
            this.NumMaxDistance.TextAlign = HorizontalAlignment.Right;
            // 
            // NumDistanceMultiplier
            // 
            this.NumDistanceMultiplier.Location = new Point(371, 41);
            this.NumDistanceMultiplier.Name = "NumDistanceMultiplier";
            this.NumDistanceMultiplier.Size = new Size(116, 20);
            this.NumDistanceMultiplier.TabIndex = 30;
            this.NumDistanceMultiplier.Text = "1";
            this.NumDistanceMultiplier.TextAlign = HorizontalAlignment.Right;
            // 
            // lblMaxDistance
            // 
            this.lblMaxDistance.AutoSize = true;
            this.lblMaxDistance.Location = new Point(3, 69);
            this.lblMaxDistance.Name = "lblMaxDistance";
            this.lblMaxDistance.Size = new Size(72, 13);
            this.lblMaxDistance.TabIndex = 26;
            this.lblMaxDistance.Text = "Max Distance";
            // 
            // lblDistanceMultiplier
            // 
            this.lblDistanceMultiplier.AutoSize = true;
            this.lblDistanceMultiplier.Location = new Point(247, 44);
            this.lblDistanceMultiplier.Name = "lblDistanceMultiplier";
            this.lblDistanceMultiplier.Size = new Size(93, 13);
            this.lblDistanceMultiplier.TabIndex = 25;
            this.lblDistanceMultiplier.Text = "Distance Multiplier";
            // 
            // chkSpherical
            // 
            this.chkSpherical.AutoSize = true;
            this.chkSpherical.Location = new Point(251, 11);
            this.chkSpherical.Name = "chkSpherical";
            this.chkSpherical.Size = new Size(70, 17);
            this.chkSpherical.TabIndex = 24;
            this.chkSpherical.Text = "Spherical";
            this.chkSpherical.UseVisualStyleBackColor = true;
            // 
            // NumResultCount
            // 
            this.NumResultCount.Location = new Point(115, 9);
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
            this.NumResultCount.Size = new Size(108, 20);
            this.NumResultCount.TabIndex = 23;
            this.NumResultCount.TextAlign = HorizontalAlignment.Right;
            this.NumResultCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // cmdGeoNear
            // 
            this.cmdGeoNear.Location = new Point(371, 1);
            this.cmdGeoNear.Name = "cmdGeoNear";
            this.cmdGeoNear.Size = new Size(116, 29);
            this.cmdGeoNear.TabIndex = 22;
            this.cmdGeoNear.Text = "GeoNear";
            this.cmdGeoNear.UseVisualStyleBackColor = true;
            this.cmdGeoNear.Click += new EventHandler(this.cmdGeoNear_Click);
            // 
            // lblGeoNear
            // 
            this.lblGeoNear.AutoSize = true;
            this.lblGeoNear.Location = new Point(3, 43);
            this.lblGeoNear.Name = "lblGeoNear";
            this.lblGeoNear.Size = new Size(56, 13);
            this.lblGeoNear.TabIndex = 20;
            this.lblGeoNear.Text = "Near(X,Y):";
            // 
            // lblResultCount
            // 
            this.lblResultCount.AutoSize = true;
            this.lblResultCount.Location = new Point(3, 11);
            this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.Size = new Size(65, 13);
            this.lblResultCount.TabIndex = 19;
            this.lblResultCount.Text = "ResultCount";
            // 
            // lnkGeoNear
            // 
            this.lnkGeoNear.AutoSize = true;
            this.lnkGeoNear.Location = new Point(16, 378);
            this.lnkGeoNear.Name = "lnkGeoNear";
            this.lnkGeoNear.Size = new Size(324, 13);
            this.lnkGeoNear.TabIndex = 18;
            this.lnkGeoNear.TabStop = true;
            this.lnkGeoNear.Text = "http://docs.mongodb.org/manual/reference/commands/#geoNear";
            this.lnkGeoNear.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lnkGeoNear_LinkClicked);
            // 
            // trvGeoResult
            // 
            this.trvGeoResult.BackColor = Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvGeoResult.Location = new Point(6, 94);
            this.trvGeoResult.Name = "trvGeoResult";
            this.trvGeoResult.Padding = new Padding(1);
            this.trvGeoResult.Size = new Size(496, 281);
            this.trvGeoResult.TabIndex = 21;
            // 
            // ctlGeoNear
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
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
            this.Name = "CtlGeoNear";
            this.Size = new Size(508, 402);
            ((ISupportInitialize)(this.NumResultCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnHelp;
        private Button btnMile;
        private Button btnKM;
        private TextBox NumGeoX;
        private TextBox NumGeoY;
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
    }
}
