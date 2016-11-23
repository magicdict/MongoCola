using System.ComponentModel;
using System.Windows.Forms;
using FunctionForm.Connection;
using ResourceLib.UI;

namespace MongoCola.Config
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
            this.intRefreshStatusTimer = new System.Windows.Forms.NumericUpDown();
            this.lblRefreshIntervalForStatus = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGerneric = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDateTimeFormat = new System.Windows.Forms.TextBox();
            this.radDateTime_Custom = new System.Windows.Forms.RadioButton();
            this.radDateTime_Time = new System.Windows.Forms.RadioButton();
            this.radDateTime_Short = new System.Windows.Forms.RadioButton();
            this.radDateTime_Long = new System.Windows.Forms.RadioButton();
            this.cmbGuidRepresentation = new System.Windows.Forms.ComboBox();
            this.lblGuidRepresentation = new System.Windows.Forms.Label();
            this.chkIsDisplayNumberWithKSystem = new System.Windows.Forms.CheckBox();
            this.lblCurrentFont = new System.Windows.Forms.Label();
            this.btnFont = new System.Windows.Forms.Button();
            this.lblFont = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radLocal = new System.Windows.Forms.RadioButton();
            this.radUTC = new System.Windows.Forms.RadioButton();
            this.fileMongoBinPath = new ResourceLib.UI.CtlFilePicker();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._ctlReadWriteConfig1 = new FunctionForm.Connection.CtlReadWriteConfig();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radJsonShell = new System.Windows.Forms.RadioButton();
            this.radJsonStrict = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.intRefreshStatusTimer)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGerneric.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // intRefreshStatusTimer
            // 
            this.intRefreshStatusTimer.Location = new System.Drawing.Point(218, 47);
            this.intRefreshStatusTimer.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.intRefreshStatusTimer.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.intRefreshStatusTimer.Name = "intRefreshStatusTimer";
            this.intRefreshStatusTimer.Size = new System.Drawing.Size(65, 21);
            this.intRefreshStatusTimer.TabIndex = 2;
            this.intRefreshStatusTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.intRefreshStatusTimer.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblRefreshIntervalForStatus
            // 
            this.lblRefreshIntervalForStatus.AutoSize = true;
            this.lblRefreshIntervalForStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblRefreshIntervalForStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefreshIntervalForStatus.Location = new System.Drawing.Point(15, 47);
            this.lblRefreshIntervalForStatus.Name = "lblRefreshIntervalForStatus";
            this.lblRefreshIntervalForStatus.Size = new System.Drawing.Size(197, 15);
            this.lblRefreshIntervalForStatus.TabIndex = 15;
            this.lblRefreshIntervalForStatus.Tag = "";
            this.lblRefreshIntervalForStatus.Text = "Monitor Refresh Interval (sec)";
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(553, 308);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 35);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Tag = "Common.Cancel";
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(460, 308);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 35);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Tag = "Common.OK";
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.BackColor = System.Drawing.Color.Transparent;
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.Location = new System.Drawing.Point(15, 21);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(71, 15);
            this.lblLanguage.TabIndex = 16;
            this.lblLanguage.Tag = "";
            this.lblLanguage.Text = "Language";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(108, 17);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(175, 23);
            this.cmbLanguage.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGerneric);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(628, 290);
            this.tabControl1.TabIndex = 18;
            // 
            // tabGerneric
            // 
            this.tabGerneric.Controls.Add(this.groupBox2);
            this.tabGerneric.Controls.Add(this.cmbGuidRepresentation);
            this.tabGerneric.Controls.Add(this.lblGuidRepresentation);
            this.tabGerneric.Controls.Add(this.chkIsDisplayNumberWithKSystem);
            this.tabGerneric.Controls.Add(this.lblCurrentFont);
            this.tabGerneric.Controls.Add(this.btnFont);
            this.tabGerneric.Controls.Add(this.lblFont);
            this.tabGerneric.Controls.Add(this.groupBox3);
            this.tabGerneric.Controls.Add(this.groupBox1);
            this.tabGerneric.Controls.Add(this.fileMongoBinPath);
            this.tabGerneric.Controls.Add(this.cmbLanguage);
            this.tabGerneric.Controls.Add(this.lblRefreshIntervalForStatus);
            this.tabGerneric.Controls.Add(this.lblLanguage);
            this.tabGerneric.Controls.Add(this.intRefreshStatusTimer);
            this.tabGerneric.Location = new System.Drawing.Point(4, 24);
            this.tabGerneric.Name = "tabGerneric";
            this.tabGerneric.Padding = new System.Windows.Forms.Padding(3);
            this.tabGerneric.Size = new System.Drawing.Size(620, 262);
            this.tabGerneric.TabIndex = 1;
            this.tabGerneric.Text = "Gerneric";
            this.tabGerneric.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDateTimeFormat);
            this.groupBox2.Controls.Add(this.radDateTime_Custom);
            this.groupBox2.Controls.Add(this.radDateTime_Time);
            this.groupBox2.Controls.Add(this.radDateTime_Short);
            this.groupBox2.Controls.Add(this.radDateTime_Long);
            this.groupBox2.Location = new System.Drawing.Point(258, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 130);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DateTime Format";
            // 
            // txtDateTimeFormat
            // 
            this.txtDateTimeFormat.Location = new System.Drawing.Point(128, 103);
            this.txtDateTimeFormat.Name = "txtDateTimeFormat";
            this.txtDateTimeFormat.Size = new System.Drawing.Size(219, 21);
            this.txtDateTimeFormat.TabIndex = 1;
            // 
            // radDateTime_Custom
            // 
            this.radDateTime_Custom.AutoSize = true;
            this.radDateTime_Custom.Location = new System.Drawing.Point(34, 105);
            this.radDateTime_Custom.Name = "radDateTime_Custom";
            this.radDateTime_Custom.Size = new System.Drawing.Size(67, 19);
            this.radDateTime_Custom.TabIndex = 0;
            this.radDateTime_Custom.Text = "Custom";
            this.radDateTime_Custom.UseVisualStyleBackColor = true;
            // 
            // radDateTime_Time
            // 
            this.radDateTime_Time.AutoSize = true;
            this.radDateTime_Time.Location = new System.Drawing.Point(34, 78);
            this.radDateTime_Time.Name = "radDateTime_Time";
            this.radDateTime_Time.Size = new System.Drawing.Size(53, 19);
            this.radDateTime_Time.TabIndex = 0;
            this.radDateTime_Time.Text = "Time";
            this.radDateTime_Time.UseVisualStyleBackColor = true;
            // 
            // radDateTime_Short
            // 
            this.radDateTime_Short.AutoSize = true;
            this.radDateTime_Short.Location = new System.Drawing.Point(34, 52);
            this.radDateTime_Short.Name = "radDateTime_Short";
            this.radDateTime_Short.Size = new System.Drawing.Size(54, 19);
            this.radDateTime_Short.TabIndex = 0;
            this.radDateTime_Short.Text = "Short";
            this.radDateTime_Short.UseVisualStyleBackColor = true;
            // 
            // radDateTime_Long
            // 
            this.radDateTime_Long.AutoSize = true;
            this.radDateTime_Long.Checked = true;
            this.radDateTime_Long.Location = new System.Drawing.Point(34, 27);
            this.radDateTime_Long.Name = "radDateTime_Long";
            this.radDateTime_Long.Size = new System.Drawing.Size(53, 19);
            this.radDateTime_Long.TabIndex = 0;
            this.radDateTime_Long.TabStop = true;
            this.radDateTime_Long.Text = "Long";
            this.radDateTime_Long.UseVisualStyleBackColor = true;
            // 
            // cmbGuidRepresentation
            // 
            this.cmbGuidRepresentation.FormattingEnabled = true;
            this.cmbGuidRepresentation.Location = new System.Drawing.Point(145, 122);
            this.cmbGuidRepresentation.Name = "cmbGuidRepresentation";
            this.cmbGuidRepresentation.Size = new System.Drawing.Size(103, 23);
            this.cmbGuidRepresentation.TabIndex = 25;
            // 
            // lblGuidRepresentation
            // 
            this.lblGuidRepresentation.AutoSize = true;
            this.lblGuidRepresentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuidRepresentation.Location = new System.Drawing.Point(15, 122);
            this.lblGuidRepresentation.Name = "lblGuidRepresentation";
            this.lblGuidRepresentation.Size = new System.Drawing.Size(135, 15);
            this.lblGuidRepresentation.TabIndex = 24;
            this.lblGuidRepresentation.Text = "GuidRepresentation";
            // 
            // chkIsDisplayNumberWithKSystem
            // 
            this.chkIsDisplayNumberWithKSystem.AutoSize = true;
            this.chkIsDisplayNumberWithKSystem.Location = new System.Drawing.Point(319, 49);
            this.chkIsDisplayNumberWithKSystem.Name = "chkIsDisplayNumberWithKSystem";
            this.chkIsDisplayNumberWithKSystem.Size = new System.Drawing.Size(191, 19);
            this.chkIsDisplayNumberWithKSystem.TabIndex = 19;
            this.chkIsDisplayNumberWithKSystem.Text = "Display Number  With K,M,G,T";
            this.chkIsDisplayNumberWithKSystem.UseVisualStyleBackColor = true;
            // 
            // lblCurrentFont
            // 
            this.lblCurrentFont.AutoSize = true;
            this.lblCurrentFont.Location = new System.Drawing.Point(353, 13);
            this.lblCurrentFont.Name = "lblCurrentFont";
            this.lblCurrentFont.Size = new System.Drawing.Size(71, 15);
            this.lblCurrentFont.TabIndex = 23;
            this.lblCurrentFont.Text = "SystemFont";
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(537, 13);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(68, 23);
            this.btnFont.TabIndex = 22;
            this.btnFont.Text = "Font...";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // lblFont
            // 
            this.lblFont.AutoSize = true;
            this.lblFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFont.Location = new System.Drawing.Point(316, 13);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(35, 15);
            this.lblFont.TabIndex = 21;
            this.lblFont.Text = "Font";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radLocal);
            this.groupBox1.Controls.Add(this.radUTC);
            this.groupBox1.Location = new System.Drawing.Point(16, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 52);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TimeZone";
            // 
            // radLocal
            // 
            this.radLocal.AutoSize = true;
            this.radLocal.Location = new System.Drawing.Point(101, 20);
            this.radLocal.Name = "radLocal";
            this.radLocal.Size = new System.Drawing.Size(55, 19);
            this.radLocal.TabIndex = 1;
            this.radLocal.Text = "Local";
            this.radLocal.UseVisualStyleBackColor = true;
            // 
            // radUTC
            // 
            this.radUTC.AutoSize = true;
            this.radUTC.Checked = true;
            this.radUTC.Location = new System.Drawing.Point(24, 21);
            this.radUTC.Name = "radUTC";
            this.radUTC.Size = new System.Drawing.Size(49, 19);
            this.radUTC.TabIndex = 0;
            this.radUTC.TabStop = true;
            this.radUTC.Text = "UTC";
            this.radUTC.UseVisualStyleBackColor = true;
            // 
            // fileMongoBinPath
            // 
            this.fileMongoBinPath.AutoSize = true;
            this.fileMongoBinPath.BackColor = System.Drawing.Color.Transparent;
            this.fileMongoBinPath.Browse = "Browse...";
            this.fileMongoBinPath.Clear = "Clear";
            this.fileMongoBinPath.FileFilter = "";
            this.fileMongoBinPath.InitFileName = "";
            this.fileMongoBinPath.Location = new System.Drawing.Point(12, 68);
            this.fileMongoBinPath.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.fileMongoBinPath.Name = "fileMongoBinPath";
            this.fileMongoBinPath.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.Directory;
            this.fileMongoBinPath.SelectedPathOrFileName = "";
            this.fileMongoBinPath.Size = new System.Drawing.Size(578, 49);
            this.fileMongoBinPath.TabIndex = 19;
            this.fileMongoBinPath.Title = "MongoBin";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._ctlReadWriteConfig1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(620, 264);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Read Write";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _ctlReadWriteConfig1
            // 
            this._ctlReadWriteConfig1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctlReadWriteConfig1.Location = new System.Drawing.Point(3, 3);
            this._ctlReadWriteConfig1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._ctlReadWriteConfig1.Name = "_ctlReadWriteConfig1";
            this._ctlReadWriteConfig1.Size = new System.Drawing.Size(614, 258);
            this._ctlReadWriteConfig1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radJsonShell);
            this.groupBox3.Controls.Add(this.radJsonStrict);
            this.groupBox3.Location = new System.Drawing.Point(18, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(233, 52);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "JsonOutputMode";
            // 
            // radJsonShell
            // 
            this.radJsonShell.AutoSize = true;
            this.radJsonShell.Location = new System.Drawing.Point(101, 20);
            this.radJsonShell.Name = "radJsonShell";
            this.radJsonShell.Size = new System.Drawing.Size(115, 19);
            this.radJsonShell.TabIndex = 1;
            this.radJsonShell.Text = "Shell(Javascript)";
            this.radJsonShell.UseVisualStyleBackColor = true;
            // 
            // radJsonStrict
            // 
            this.radJsonStrict.AutoSize = true;
            this.radJsonStrict.Checked = true;
            this.radJsonStrict.Location = new System.Drawing.Point(24, 21);
            this.radJsonStrict.Name = "radJsonStrict";
            this.radJsonStrict.Size = new System.Drawing.Size(52, 19);
            this.radJsonStrict.TabIndex = 0;
            this.radJsonStrict.TabStop = true;
            this.radJsonStrict.Text = "Strict";
            this.radJsonStrict.UseVisualStyleBackColor = true;
            // 
            // FrmOption
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(662, 355);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "OptionTitle";
            this.Text = "Option";
            this.Load += new System.EventHandler(this.frmOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.intRefreshStatusTimer)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGerneric.ResumeLayout(false);
            this.tabGerneric.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private NumericUpDown intRefreshStatusTimer;
        private Label lblRefreshIntervalForStatus;
        private Button cmdCancel;
        private Button cmdOK;
        private ComboBox cmbLanguage;
        private Label lblLanguage;
        private TabControl tabControl1;
        private TabPage tabGerneric;
        private TabPage tabPage1;
        private CtlFilePicker fileMongoBinPath;
        private CtlReadWriteConfig _ctlReadWriteConfig1;
        private GroupBox groupBox1;
        private RadioButton radLocal;
        private RadioButton radUTC;
        private Label lblFont;
        private FontDialog fontDialog;
        private Label lblCurrentFont;
        private Button btnFont;
        private CheckBox chkIsDisplayNumberWithKSystem;
        private Label lblGuidRepresentation;
        private ComboBox cmbGuidRepresentation;
        private GroupBox groupBox2;
        private RadioButton radDateTime_Custom;
        private RadioButton radDateTime_Time;
        private RadioButton radDateTime_Short;
        private RadioButton radDateTime_Long;
        private TextBox txtDateTimeFormat;
        private GroupBox groupBox3;
        private RadioButton radJsonShell;
        private RadioButton radJsonStrict;
    }
}