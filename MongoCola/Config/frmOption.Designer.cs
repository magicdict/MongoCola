using System.ComponentModel;
using System.Windows.Forms;
using ResourceLib.UI;

namespace MongoCola
{
    partial class FrmOption
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
            this.numRefreshForStatus = new System.Windows.Forms.NumericUpDown();
            this.lblRefreshIntervalForStatus = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGerneric = new System.Windows.Forms.TabPage();
            this.tabTooktip = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.ctlFilePickerMongoBinPath = new ResourceLib.UI.CtlFilePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshForStatus)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGerneric.SuspendLayout();
            this.tabTooktip.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumWTimeoutMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWaitQueueSize)).BeginInit();
            this.SuspendLayout();
            // 
            // numRefreshForStatus
            // 
            this.numRefreshForStatus.Location = new System.Drawing.Point(181, 31);
            this.numRefreshForStatus.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numRefreshForStatus.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRefreshForStatus.Name = "numRefreshForStatus";
            this.numRefreshForStatus.Size = new System.Drawing.Size(77, 21);
            this.numRefreshForStatus.TabIndex = 2;
            this.numRefreshForStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRefreshForStatus.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblRefreshIntervalForStatus
            // 
            this.lblRefreshIntervalForStatus.AutoSize = true;
            this.lblRefreshIntervalForStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblRefreshIntervalForStatus.Location = new System.Drawing.Point(27, 33);
            this.lblRefreshIntervalForStatus.Name = "lblRefreshIntervalForStatus";
            this.lblRefreshIntervalForStatus.Size = new System.Drawing.Size(135, 15);
            this.lblRefreshIntervalForStatus.TabIndex = 15;
            this.lblRefreshIntervalForStatus.Text = "Refresh Interval（sec）";
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(379, 240);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 35);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(125, 240);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 35);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.BackColor = System.Drawing.Color.Transparent;
            this.lblLanguage.Location = new System.Drawing.Point(27, 79);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(63, 15);
            this.lblLanguage.TabIndex = 16;
            this.lblLanguage.Text = "Language";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(181, 76);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(140, 23);
            this.cmbLanguage.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGerneric);
            this.tabControl1.Controls.Add(this.tabTooktip);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(635, 218);
            this.tabControl1.TabIndex = 18;
            // 
            // tabGerneric
            // 
            this.tabGerneric.Controls.Add(this.cmbLanguage);
            this.tabGerneric.Controls.Add(this.lblRefreshIntervalForStatus);
            this.tabGerneric.Controls.Add(this.lblLanguage);
            this.tabGerneric.Controls.Add(this.numRefreshForStatus);
            this.tabGerneric.Location = new System.Drawing.Point(4, 24);
            this.tabGerneric.Name = "tabGerneric";
            this.tabGerneric.Padding = new System.Windows.Forms.Padding(3);
            this.tabGerneric.Size = new System.Drawing.Size(627, 190);
            this.tabGerneric.TabIndex = 1;
            this.tabGerneric.Text = "Gerneric";
            this.tabGerneric.UseVisualStyleBackColor = true;
            // 
            // tabTooktip
            // 
            this.tabTooktip.Controls.Add(this.ctlFilePickerMongoBinPath);
            this.tabTooktip.Location = new System.Drawing.Point(4, 24);
            this.tabTooktip.Name = "tabTooktip";
            this.tabTooktip.Padding = new System.Windows.Forms.Padding(3);
            this.tabTooktip.Size = new System.Drawing.Size(627, 190);
            this.tabTooktip.TabIndex = 0;
            this.tabTooktip.Text = "Toolkit";
            this.tabTooktip.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lnkWriteConcern);
            this.tabPage1.Controls.Add(this.lnkReadPreference);
            this.tabPage1.Controls.Add(this.cmbWriteConcern);
            this.tabPage1.Controls.Add(this.lblWriteConcern);
            this.tabPage1.Controls.Add(this.cmbReadPreference);
            this.tabPage1.Controls.Add(this.lblReadPreference);
            this.tabPage1.Controls.Add(this.lblWtimeoutDescript);
            this.tabPage1.Controls.Add(this.NumWTimeoutMS);
            this.tabPage1.Controls.Add(this.lblQueueSize);
            this.tabPage1.Controls.Add(this.lblWTimeout);
            this.tabPage1.Controls.Add(this.NumWaitQueueSize);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(627, 190);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Read Write";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lnkWriteConcern
            // 
            this.lnkWriteConcern.AutoSize = true;
            this.lnkWriteConcern.Location = new System.Drawing.Point(345, 129);
            this.lnkWriteConcern.Name = "lnkWriteConcern";
            this.lnkWriteConcern.Size = new System.Drawing.Size(115, 15);
            this.lnkWriteConcern.TabIndex = 52;
            this.lnkWriteConcern.TabStop = true;
            this.lnkWriteConcern.Text = "About WriteConcern";
            // 
            // lnkReadPreference
            // 
            this.lnkReadPreference.AutoSize = true;
            this.lnkReadPreference.Location = new System.Drawing.Point(346, 105);
            this.lnkReadPreference.Name = "lnkReadPreference";
            this.lnkReadPreference.Size = new System.Drawing.Size(131, 15);
            this.lnkReadPreference.TabIndex = 51;
            this.lnkReadPreference.TabStop = true;
            this.lnkReadPreference.Text = "About ReadPreference";
            // 
            // cmbWriteConcern
            // 
            this.cmbWriteConcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWriteConcern.FormattingEnabled = true;
            this.cmbWriteConcern.Location = new System.Drawing.Point(149, 129);
            this.cmbWriteConcern.Name = "cmbWriteConcern";
            this.cmbWriteConcern.Size = new System.Drawing.Size(170, 23);
            this.cmbWriteConcern.TabIndex = 50;
            // 
            // lblWriteConcern
            // 
            this.lblWriteConcern.AutoSize = true;
            this.lblWriteConcern.Location = new System.Drawing.Point(27, 129);
            this.lblWriteConcern.Name = "lblWriteConcern";
            this.lblWriteConcern.Size = new System.Drawing.Size(81, 15);
            this.lblWriteConcern.TabIndex = 49;
            this.lblWriteConcern.Text = "WriteConcern";
            // 
            // cmbReadPreference
            // 
            this.cmbReadPreference.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReadPreference.FormattingEnabled = true;
            this.cmbReadPreference.Location = new System.Drawing.Point(149, 102);
            this.cmbReadPreference.Name = "cmbReadPreference";
            this.cmbReadPreference.Size = new System.Drawing.Size(170, 23);
            this.cmbReadPreference.TabIndex = 48;
            // 
            // lblReadPreference
            // 
            this.lblReadPreference.AutoSize = true;
            this.lblReadPreference.Location = new System.Drawing.Point(27, 102);
            this.lblReadPreference.Name = "lblReadPreference";
            this.lblReadPreference.Size = new System.Drawing.Size(97, 15);
            this.lblReadPreference.TabIndex = 47;
            this.lblReadPreference.Text = "ReadPreference";
            // 
            // lblWtimeoutDescript
            // 
            this.lblWtimeoutDescript.AutoSize = true;
            this.lblWtimeoutDescript.Location = new System.Drawing.Point(152, 52);
            this.lblWtimeoutDescript.Name = "lblWtimeoutDescript";
            this.lblWtimeoutDescript.Size = new System.Drawing.Size(444, 15);
            this.lblWtimeoutDescript.TabIndex = 46;
            this.lblWtimeoutDescript.Text = "The driver adds { wtimeout : ms } to the getlasterror command. Implies safe=true." +
    "";
            // 
            // NumWTimeoutMS
            // 
            this.NumWTimeoutMS.Location = new System.Drawing.Point(149, 22);
            this.NumWTimeoutMS.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumWTimeoutMS.Name = "NumWTimeoutMS";
            this.NumWTimeoutMS.Size = new System.Drawing.Size(87, 21);
            this.NumWTimeoutMS.TabIndex = 42;
            this.NumWTimeoutMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQueueSize
            // 
            this.lblQueueSize.AutoSize = true;
            this.lblQueueSize.Location = new System.Drawing.Point(25, 74);
            this.lblQueueSize.Name = "lblQueueSize";
            this.lblQueueSize.Size = new System.Drawing.Size(92, 15);
            this.lblQueueSize.TabIndex = 44;
            this.lblQueueSize.Text = "WaitQueueSize";
            // 
            // lblWTimeout
            // 
            this.lblWTimeout.AutoSize = true;
            this.lblWTimeout.Location = new System.Drawing.Point(27, 25);
            this.lblWTimeout.Name = "lblWTimeout";
            this.lblWTimeout.Size = new System.Drawing.Size(84, 15);
            this.lblWTimeout.TabIndex = 45;
            this.lblWTimeout.Text = "wtimeout(MS)";
            // 
            // NumWaitQueueSize
            // 
            this.NumWaitQueueSize.Location = new System.Drawing.Point(149, 72);
            this.NumWaitQueueSize.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumWaitQueueSize.Name = "NumWaitQueueSize";
            this.NumWaitQueueSize.Size = new System.Drawing.Size(87, 21);
            this.NumWaitQueueSize.TabIndex = 43;
            this.NumWaitQueueSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ctlFilePickerMongoBinPath
            // 
            this.ctlFilePickerMongoBinPath.AutoSize = true;
            this.ctlFilePickerMongoBinPath.BackColor = System.Drawing.Color.Transparent;
            this.ctlFilePickerMongoBinPath.FileFilter = "";
            this.ctlFilePickerMongoBinPath.FileName = "";
            this.ctlFilePickerMongoBinPath.Location = new System.Drawing.Point(0, 8);
            this.ctlFilePickerMongoBinPath.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ctlFilePickerMongoBinPath.Name = "ctlFilePickerMongoBinPath";
            this.ctlFilePickerMongoBinPath.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.Directory;
            this.ctlFilePickerMongoBinPath.SelectedPathOrFileName = "";
            this.ctlFilePickerMongoBinPath.Size = new System.Drawing.Size(628, 61);
            this.ctlFilePickerMongoBinPath.TabIndex = 18;
            this.ctlFilePickerMongoBinPath.Title = "Title";
            // 
            // FrmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(659, 287);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Option";
            this.Load += new System.EventHandler(this.frmOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshForStatus)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGerneric.ResumeLayout(false);
            this.tabGerneric.PerformLayout();
            this.tabTooktip.ResumeLayout(false);
            this.tabTooktip.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumWTimeoutMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWaitQueueSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NumericUpDown numRefreshForStatus;
        private Label lblRefreshIntervalForStatus;
        private Button cmdCancel;
        private Button cmdOK;
        private ComboBox cmbLanguage;
        private Label lblLanguage;
        private TabControl tabControl1;
        private TabPage tabTooktip;
        private TabPage tabGerneric;
        private TabPage tabPage1;
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
        private CtlFilePicker ctlFilePickerMongoBinPath;

    }
}