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
            this.chkUseDefault = new CheckBox();
            this.lnkWriteConcern = new LinkLabel();
            this.lnkReadPreference = new LinkLabel();
            this.cmbWriteConcern = new ComboBox();
            this.lblWriteConcern = new Label();
            this.cmbReadPreference = new ComboBox();
            this.lblReadPreference = new Label();
            this.lblWtimeoutDescript = new Label();
            this.NumWTimeoutMS = new NumericUpDown();
            this.lblQueueSize = new Label();
            this.lblWTimeout = new Label();
            this.NumWaitQueueSize = new NumericUpDown();
            ((ISupportInitialize)(this.NumWTimeoutMS)).BeginInit();
            ((ISupportInitialize)(this.NumWaitQueueSize)).BeginInit();
            this.SuspendLayout();
            // 
            // chkUseDefault
            // 
            this.chkUseDefault.AutoSize = true;
            this.chkUseDefault.Location = new Point(41, 14);
            this.chkUseDefault.Name = "chkUseDefault";
            this.chkUseDefault.Size = new Size(168, 16);
            this.chkUseDefault.TabIndex = 76;
            this.chkUseDefault.Text = "Use Tool Default Setting";
            this.chkUseDefault.UseVisualStyleBackColor = true;
            // 
            // lnkWriteConcern
            // 
            this.lnkWriteConcern.AutoSize = true;
            this.lnkWriteConcern.Location = new Point(318, 145);
            this.lnkWriteConcern.Name = "lnkWriteConcern";
            this.lnkWriteConcern.Size = new Size(113, 12);
            this.lnkWriteConcern.TabIndex = 75;
            this.lnkWriteConcern.TabStop = true;
            this.lnkWriteConcern.Text = "About WriteConcern";
            // 
            // lnkReadPreference
            // 
            this.lnkReadPreference.AutoSize = true;
            this.lnkReadPreference.Location = new Point(319, 122);
            this.lnkReadPreference.Name = "lnkReadPreference";
            this.lnkReadPreference.Size = new Size(125, 12);
            this.lnkReadPreference.TabIndex = 74;
            this.lnkReadPreference.TabStop = true;
            this.lnkReadPreference.Text = "About ReadPreference";
            // 
            // cmbWriteConcern
            // 
            this.cmbWriteConcern.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbWriteConcern.FormattingEnabled = true;
            this.cmbWriteConcern.Location = new Point(147, 145);
            this.cmbWriteConcern.Name = "cmbWriteConcern";
            this.cmbWriteConcern.Size = new Size(149, 20);
            this.cmbWriteConcern.TabIndex = 73;
            // 
            // lblWriteConcern
            // 
            this.lblWriteConcern.AutoSize = true;
            this.lblWriteConcern.Location = new Point(40, 145);
            this.lblWriteConcern.Name = "lblWriteConcern";
            this.lblWriteConcern.Size = new Size(77, 12);
            this.lblWriteConcern.TabIndex = 72;
            this.lblWriteConcern.Text = "WriteConcern";
            // 
            // cmbReadPreference
            // 
            this.cmbReadPreference.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbReadPreference.FormattingEnabled = true;
            this.cmbReadPreference.Location = new Point(147, 120);
            this.cmbReadPreference.Name = "cmbReadPreference";
            this.cmbReadPreference.Size = new Size(149, 20);
            this.cmbReadPreference.TabIndex = 71;
            // 
            // lblReadPreference
            // 
            this.lblReadPreference.AutoSize = true;
            this.lblReadPreference.Location = new Point(40, 120);
            this.lblReadPreference.Name = "lblReadPreference";
            this.lblReadPreference.Size = new Size(89, 12);
            this.lblReadPreference.TabIndex = 70;
            this.lblReadPreference.Text = "ReadPreference";
            // 
            // lblWtimeoutDescript
            // 
            this.lblWtimeoutDescript.AutoSize = true;
            this.lblWtimeoutDescript.Location = new Point(149, 73);
            this.lblWtimeoutDescript.Name = "lblWtimeoutDescript";
            this.lblWtimeoutDescript.Size = new Size(491, 12);
            this.lblWtimeoutDescript.TabIndex = 69;
            this.lblWtimeoutDescript.Text = "The driver adds { wtimeout : ms } to the getlasterror command. Implies safe=true." +
    "";
            // 
            // NumWTimeoutMS
            // 
            this.NumWTimeoutMS.Location = new Point(147, 44);
            this.NumWTimeoutMS.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumWTimeoutMS.Name = "NumWTimeoutMS";
            this.NumWTimeoutMS.Size = new Size(76, 21);
            this.NumWTimeoutMS.TabIndex = 65;
            this.NumWTimeoutMS.TextAlign = HorizontalAlignment.Right;
            // 
            // lblQueueSize
            // 
            this.lblQueueSize.AutoSize = true;
            this.lblQueueSize.Location = new Point(38, 93);
            this.lblQueueSize.Name = "lblQueueSize";
            this.lblQueueSize.Size = new Size(83, 12);
            this.lblQueueSize.TabIndex = 67;
            this.lblQueueSize.Text = "WaitQueueSize";
            // 
            // lblWTimeout
            // 
            this.lblWTimeout.AutoSize = true;
            this.lblWTimeout.Location = new Point(40, 47);
            this.lblWTimeout.Name = "lblWTimeout";
            this.lblWTimeout.Size = new Size(77, 12);
            this.lblWTimeout.TabIndex = 68;
            this.lblWTimeout.Text = "wtimeout(MS)";
            // 
            // NumWaitQueueSize
            // 
            this.NumWaitQueueSize.Location = new Point(147, 91);
            this.NumWaitQueueSize.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumWaitQueueSize.Name = "NumWaitQueueSize";
            this.NumWaitQueueSize.Size = new Size(76, 21);
            this.NumWaitQueueSize.TabIndex = 66;
            this.NumWaitQueueSize.TextAlign = HorizontalAlignment.Right;
            // 
            // ctlReadWriteConfig
            // 
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
            this.Size = new Size(656, 198);
            this.Load += new EventHandler(this.CtlMongoConfig_Load);
            ((ISupportInitialize)(this.NumWTimeoutMS)).EndInit();
            ((ISupportInitialize)(this.NumWaitQueueSize)).EndInit();
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

    }
}
