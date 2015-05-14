using System.ComponentModel;
using System.Windows.Forms;

namespace FunctionForm.Ctrl
{
    partial class CtlMongoConfig
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
            this.cmbWriteConcern = new System.Windows.Forms.ComboBox();
            this.cmbReadPreference = new System.Windows.Forms.ComboBox();
            this.NumWaitQueueSize = new System.Windows.Forms.NumericUpDown();
            this.NumWTimeoutMS = new System.Windows.Forms.NumericUpDown();
            this.lnkWriteConcern = new System.Windows.Forms.LinkLabel();
            this.lnkReadPreference = new System.Windows.Forms.LinkLabel();
            this.lblWriteConcern = new System.Windows.Forms.Label();
            this.lblReadPreference = new System.Windows.Forms.Label();
            this.lblWtimeoutDescript = new System.Windows.Forms.Label();
            this.lblQueueSize = new System.Windows.Forms.Label();
            this.lblWTimeout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumWaitQueueSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWTimeoutMS)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbWriteConcern
            // 
            this.cmbWriteConcern.FormattingEnabled = true;
            this.cmbWriteConcern.Location = new System.Drawing.Point(193, 17);
            this.cmbWriteConcern.Name = "cmbWriteConcern";
            this.cmbWriteConcern.Size = new System.Drawing.Size(121, 20);
            this.cmbWriteConcern.TabIndex = 0;
            // 
            // cmbReadPreference
            // 
            this.cmbReadPreference.FormattingEnabled = true;
            this.cmbReadPreference.Location = new System.Drawing.Point(193, 43);
            this.cmbReadPreference.Name = "cmbReadPreference";
            this.cmbReadPreference.Size = new System.Drawing.Size(121, 20);
            this.cmbReadPreference.TabIndex = 1;
            // 
            // NumWaitQueueSize
            // 
            this.NumWaitQueueSize.Location = new System.Drawing.Point(194, 96);
            this.NumWaitQueueSize.Name = "NumWaitQueueSize";
            this.NumWaitQueueSize.Size = new System.Drawing.Size(120, 21);
            this.NumWaitQueueSize.TabIndex = 2;
            // 
            // NumWTimeoutMS
            // 
            this.NumWTimeoutMS.Location = new System.Drawing.Point(193, 69);
            this.NumWTimeoutMS.Name = "NumWTimeoutMS";
            this.NumWTimeoutMS.Size = new System.Drawing.Size(120, 21);
            this.NumWTimeoutMS.TabIndex = 3;
            // 
            // lnkWriteConcern
            // 
            this.lnkWriteConcern.AutoSize = true;
            this.lnkWriteConcern.Location = new System.Drawing.Point(192, 149);
            this.lnkWriteConcern.Name = "lnkWriteConcern";
            this.lnkWriteConcern.Size = new System.Drawing.Size(77, 12);
            this.lnkWriteConcern.TabIndex = 4;
            this.lnkWriteConcern.TabStop = true;
            this.lnkWriteConcern.Text = "WriteConcern";
            // 
            // lnkReadPreference
            // 
            this.lnkReadPreference.AutoSize = true;
            this.lnkReadPreference.Location = new System.Drawing.Point(192, 120);
            this.lnkReadPreference.Name = "lnkReadPreference";
            this.lnkReadPreference.Size = new System.Drawing.Size(89, 12);
            this.lnkReadPreference.TabIndex = 5;
            this.lnkReadPreference.TabStop = true;
            this.lnkReadPreference.Text = "ReadPreference";
            // 
            // lblWriteConcern
            // 
            this.lblWriteConcern.AutoSize = true;
            this.lblWriteConcern.Location = new System.Drawing.Point(70, 25);
            this.lblWriteConcern.Name = "lblWriteConcern";
            this.lblWriteConcern.Size = new System.Drawing.Size(77, 12);
            this.lblWriteConcern.TabIndex = 6;
            this.lblWriteConcern.Text = "WriteConcern";
            // 
            // lblReadPreference
            // 
            this.lblReadPreference.AutoSize = true;
            this.lblReadPreference.Location = new System.Drawing.Point(58, 51);
            this.lblReadPreference.Name = "lblReadPreference";
            this.lblReadPreference.Size = new System.Drawing.Size(89, 12);
            this.lblReadPreference.TabIndex = 7;
            this.lblReadPreference.Text = "ReadPreference";
            // 
            // lblWtimeoutDescript
            // 
            this.lblWtimeoutDescript.AutoSize = true;
            this.lblWtimeoutDescript.Location = new System.Drawing.Point(46, 149);
            this.lblWtimeoutDescript.Name = "lblWtimeoutDescript";
            this.lblWtimeoutDescript.Size = new System.Drawing.Size(101, 12);
            this.lblWtimeoutDescript.TabIndex = 8;
            this.lblWtimeoutDescript.Text = "WtimeoutDescript";
            // 
            // lblQueueSize
            // 
            this.lblQueueSize.AutoSize = true;
            this.lblQueueSize.Location = new System.Drawing.Point(88, 105);
            this.lblQueueSize.Name = "lblQueueSize";
            this.lblQueueSize.Size = new System.Drawing.Size(59, 12);
            this.lblQueueSize.TabIndex = 9;
            this.lblQueueSize.Text = "QueueSize";
            // 
            // lblWTimeout
            // 
            this.lblWTimeout.AutoSize = true;
            this.lblWTimeout.Location = new System.Drawing.Point(94, 78);
            this.lblWTimeout.Name = "lblWTimeout";
            this.lblWTimeout.Size = new System.Drawing.Size(53, 12);
            this.lblWTimeout.TabIndex = 10;
            this.lblWTimeout.Text = "WTimeout";
            // 
            // CtlMongoConfig
            // 
            this.Controls.Add(this.lblWTimeout);
            this.Controls.Add(this.lblQueueSize);
            this.Controls.Add(this.lblWtimeoutDescript);
            this.Controls.Add(this.lblReadPreference);
            this.Controls.Add(this.lblWriteConcern);
            this.Controls.Add(this.lnkReadPreference);
            this.Controls.Add(this.lnkWriteConcern);
            this.Controls.Add(this.NumWTimeoutMS);
            this.Controls.Add(this.NumWaitQueueSize);
            this.Controls.Add(this.cmbReadPreference);
            this.Controls.Add(this.cmbWriteConcern);
            this.Name = "CtlMongoConfig";
            this.Size = new System.Drawing.Size(415, 174);
            ((System.ComponentModel.ISupportInitialize)(this.NumWaitQueueSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWTimeoutMS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cmbWriteConcern;
        private ComboBox cmbReadPreference;
        private NumericUpDown NumWaitQueueSize;
        private NumericUpDown NumWTimeoutMS;
        private LinkLabel lnkWriteConcern;
        private LinkLabel lnkReadPreference;
        private Label lblWriteConcern;
        private Label lblReadPreference;
        private Label lblWtimeoutDescript;
        private Label lblQueueSize;
        private Label lblWTimeout;
    }
}
