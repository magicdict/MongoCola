using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FunctionForm.Connection
{
    partial class CtlReadWriteConfig
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
            this.chkUseDefault = new System.Windows.Forms.CheckBox();
            this.lnkWriteConcern = new System.Windows.Forms.LinkLabel();
            this.lnkReadPreference = new System.Windows.Forms.LinkLabel();
            this.cmbWriteConcern = new System.Windows.Forms.ComboBox();
            this.lblWriteConcern = new System.Windows.Forms.Label();
            this.cmbReadPreference = new System.Windows.Forms.ComboBox();
            this.lblReadPreference = new System.Windows.Forms.Label();
            this.lblWtimeoutDescript = new System.Windows.Forms.Label();
            this.NumWTimeoutMS = new System.Windows.Forms.NumericUpDown();
            this.lblQueueSize = new System.Windows.Forms.Label();
            this.lblWTimeout = new System.Windows.Forms.Label();
            this.NumWaitQueueSize = new System.Windows.Forms.NumericUpDown();
            this.lnkReadConcern = new System.Windows.Forms.LinkLabel();
            this.cmbReadConcern = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumWTimeoutMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWaitQueueSize)).BeginInit();
            this.SuspendLayout();
            // 
            // chkUseDefault
            // 
            this.chkUseDefault.AutoSize = true;
            this.chkUseDefault.Location = new System.Drawing.Point(43, 4);
            this.chkUseDefault.Name = "chkUseDefault";
            this.chkUseDefault.Size = new System.Drawing.Size(168, 16);
            this.chkUseDefault.TabIndex = 76;
            this.chkUseDefault.Text = "Use Tool Default Setting";
            this.chkUseDefault.UseVisualStyleBackColor = true;
            // 
            // lnkWriteConcern
            // 
            this.lnkWriteConcern.AutoSize = true;
            this.lnkWriteConcern.Location = new System.Drawing.Point(321, 149);
            this.lnkWriteConcern.Name = "lnkWriteConcern";
            this.lnkWriteConcern.Size = new System.Drawing.Size(113, 12);
            this.lnkWriteConcern.TabIndex = 75;
            this.lnkWriteConcern.TabStop = true;
            this.lnkWriteConcern.Text = "About WriteConcern";
            this.lnkWriteConcern.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWriteConcern_LinkClicked);
            // 
            // lnkReadPreference
            // 
            this.lnkReadPreference.AutoSize = true;
            this.lnkReadPreference.Location = new System.Drawing.Point(321, 98);
            this.lnkReadPreference.Name = "lnkReadPreference";
            this.lnkReadPreference.Size = new System.Drawing.Size(125, 12);
            this.lnkReadPreference.TabIndex = 74;
            this.lnkReadPreference.TabStop = true;
            this.lnkReadPreference.Text = "About ReadPreference";
            this.lnkReadPreference.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReadPreference_LinkClicked);
            // 
            // cmbWriteConcern
            // 
            this.cmbWriteConcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWriteConcern.FormattingEnabled = true;
            this.cmbWriteConcern.Location = new System.Drawing.Point(147, 149);
            this.cmbWriteConcern.Name = "cmbWriteConcern";
            this.cmbWriteConcern.Size = new System.Drawing.Size(149, 20);
            this.cmbWriteConcern.TabIndex = 73;
            // 
            // lblWriteConcern
            // 
            this.lblWriteConcern.AutoSize = true;
            this.lblWriteConcern.Location = new System.Drawing.Point(43, 149);
            this.lblWriteConcern.Name = "lblWriteConcern";
            this.lblWriteConcern.Size = new System.Drawing.Size(77, 12);
            this.lblWriteConcern.TabIndex = 72;
            this.lblWriteConcern.Text = "WriteConcern";
            // 
            // cmbReadPreference
            // 
            this.cmbReadPreference.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReadPreference.FormattingEnabled = true;
            this.cmbReadPreference.Location = new System.Drawing.Point(147, 96);
            this.cmbReadPreference.Name = "cmbReadPreference";
            this.cmbReadPreference.Size = new System.Drawing.Size(149, 20);
            this.cmbReadPreference.TabIndex = 71;
            // 
            // lblReadPreference
            // 
            this.lblReadPreference.AutoSize = true;
            this.lblReadPreference.Location = new System.Drawing.Point(43, 96);
            this.lblReadPreference.Name = "lblReadPreference";
            this.lblReadPreference.Size = new System.Drawing.Size(89, 12);
            this.lblReadPreference.TabIndex = 70;
            this.lblReadPreference.Text = "ReadPreference";
            // 
            // lblWtimeoutDescript
            // 
            this.lblWtimeoutDescript.AutoSize = true;
            this.lblWtimeoutDescript.Location = new System.Drawing.Point(43, 27);
            this.lblWtimeoutDescript.Name = "lblWtimeoutDescript";
            this.lblWtimeoutDescript.Size = new System.Drawing.Size(491, 12);
            this.lblWtimeoutDescript.TabIndex = 69;
            this.lblWtimeoutDescript.Text = "The driver adds { wtimeout : ms } to the getlasterror command. Implies safe=true." +
    "";
            // 
            // NumWTimeoutMS
            // 
            this.NumWTimeoutMS.Location = new System.Drawing.Point(147, 44);
            this.NumWTimeoutMS.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumWTimeoutMS.Name = "NumWTimeoutMS";
            this.NumWTimeoutMS.Size = new System.Drawing.Size(76, 21);
            this.NumWTimeoutMS.TabIndex = 65;
            this.NumWTimeoutMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQueueSize
            // 
            this.lblQueueSize.AutoSize = true;
            this.lblQueueSize.Location = new System.Drawing.Point(43, 69);
            this.lblQueueSize.Name = "lblQueueSize";
            this.lblQueueSize.Size = new System.Drawing.Size(83, 12);
            this.lblQueueSize.TabIndex = 67;
            this.lblQueueSize.Text = "WaitQueueSize";
            // 
            // lblWTimeout
            // 
            this.lblWTimeout.AutoSize = true;
            this.lblWTimeout.Location = new System.Drawing.Point(43, 47);
            this.lblWTimeout.Name = "lblWTimeout";
            this.lblWTimeout.Size = new System.Drawing.Size(77, 12);
            this.lblWTimeout.TabIndex = 68;
            this.lblWTimeout.Text = "wtimeout(MS)";
            // 
            // NumWaitQueueSize
            // 
            this.NumWaitQueueSize.Location = new System.Drawing.Point(147, 67);
            this.NumWaitQueueSize.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumWaitQueueSize.Name = "NumWaitQueueSize";
            this.NumWaitQueueSize.Size = new System.Drawing.Size(76, 21);
            this.NumWaitQueueSize.TabIndex = 66;
            this.NumWaitQueueSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lnkReadConcern
            // 
            this.lnkReadConcern.AutoSize = true;
            this.lnkReadConcern.Location = new System.Drawing.Point(321, 122);
            this.lnkReadConcern.Name = "lnkReadConcern";
            this.lnkReadConcern.Size = new System.Drawing.Size(107, 12);
            this.lnkReadConcern.TabIndex = 79;
            this.lnkReadConcern.TabStop = true;
            this.lnkReadConcern.Text = "About ReadConcern";
            this.lnkReadConcern.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReadConcern_LinkClicked);
            // 
            // cmbReadConcern
            // 
            this.cmbReadConcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReadConcern.FormattingEnabled = true;
            this.cmbReadConcern.Location = new System.Drawing.Point(147, 122);
            this.cmbReadConcern.Name = "cmbReadConcern";
            this.cmbReadConcern.Size = new System.Drawing.Size(149, 20);
            this.cmbReadConcern.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 77;
            this.label1.Text = "ReadConcern";
            // 
            // CtlReadWriteConfig
            // 
            this.Controls.Add(this.lnkReadConcern);
            this.Controls.Add(this.cmbReadConcern);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkUseDefault);
            this.Controls.Add(this.lnkWriteConcern);
            this.Controls.Add(this.lnkReadPreference);
            this.Controls.Add(this.cmbWriteConcern);
            this.Controls.Add(this.lblWriteConcern);
            this.Controls.Add(this.cmbReadPreference);
            this.Controls.Add(this.lblReadPreference);
            this.Controls.Add(this.lblWtimeoutDescript);
            this.Controls.Add(this.NumWTimeoutMS);
            this.Controls.Add(this.lblQueueSize);
            this.Controls.Add(this.lblWTimeout);
            this.Controls.Add(this.NumWaitQueueSize);
            this.Name = "CtlReadWriteConfig";
            this.Size = new System.Drawing.Size(656, 198);
            this.Load += new System.EventHandler(this.CtlMongoConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumWTimeoutMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWaitQueueSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox chkUseDefault;
        private LinkLabel lnkWriteConcern;
        private LinkLabel lnkReadPreference;
        private ComboBox cmbWriteConcern;
        private Label lblWriteConcern;
        private ComboBox cmbReadPreference;
        private Label lblReadPreference;
        private Label lblWtimeoutDescript;
        private NumericUpDown NumWTimeoutMS;
        private Label lblQueueSize;
        private Label lblWTimeout;
        private NumericUpDown NumWaitQueueSize;
        private LinkLabel lnkReadConcern;
        private ComboBox cmbReadConcern;
        private Label label1;
    }
}
