using System.ComponentModel;
using System.Windows.Forms;
using FunctionForm.Ctrl;
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
            this.numRefreshForStatus = new System.Windows.Forms.NumericUpDown();
            this.lblRefreshIntervalForStatus = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGerneric = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctlFilePickerMongoBinPath = new ResourceLib.UI.CtlFilePicker();
            this._ctlReadWriteConfig1 = new CtlReadWriteConfig();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshForStatus)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGerneric.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.lblRefreshIntervalForStatus.Location = new System.Drawing.Point(30, 33);
            this.lblRefreshIntervalForStatus.Name = "lblRefreshIntervalForStatus";
            this.lblRefreshIntervalForStatus.Size = new System.Drawing.Size(135, 15);
            this.lblRefreshIntervalForStatus.TabIndex = 15;
            this.lblRefreshIntervalForStatus.Tag = "OptionRefreshInterval";
            this.lblRefreshIntervalForStatus.Text = "Refresh Interval（sec）";
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(267, 240);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 35);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Tag = "Common_Cancel";
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
            this.cmdOK.Tag = "Common_OK";
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.BackColor = System.Drawing.Color.Transparent;
            this.lblLanguage.Location = new System.Drawing.Point(30, 79);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(63, 15);
            this.lblLanguage.TabIndex = 16;
            this.lblLanguage.Tag = "OptionLanguage";
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
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(635, 218);
            this.tabControl1.TabIndex = 18;
            // 
            // tabGerneric
            // 
            this.tabGerneric.Controls.Add(this.ctlFilePickerMongoBinPath);
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._ctlReadWriteConfig1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(627, 190);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Read Write";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ctlFilePickerMongoBinPath
            // 
            this.ctlFilePickerMongoBinPath.AutoSize = true;
            this.ctlFilePickerMongoBinPath.BackColor = System.Drawing.Color.Transparent;
            this.ctlFilePickerMongoBinPath.FileFilter = "";
            this.ctlFilePickerMongoBinPath.FileName = "";
            this.ctlFilePickerMongoBinPath.Location = new System.Drawing.Point(30, 108);
            this.ctlFilePickerMongoBinPath.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.ctlFilePickerMongoBinPath.Name = "ctlFilePickerMongoBinPath";
            this.ctlFilePickerMongoBinPath.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.Directory;
            this.ctlFilePickerMongoBinPath.SelectedPathOrFileName = "";
            this.ctlFilePickerMongoBinPath.Size = new System.Drawing.Size(578, 49);
            this.ctlFilePickerMongoBinPath.TabIndex = 19;
            this.ctlFilePickerMongoBinPath.Title = "MongoBin";
            // 
            // _ctlReadWriteConfig1
            // 
            this._ctlReadWriteConfig1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctlReadWriteConfig1.Location = new System.Drawing.Point(3, 3);
            this._ctlReadWriteConfig1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._ctlReadWriteConfig1.Name = "_ctlReadWriteConfig1";
            this._ctlReadWriteConfig1.Size = new System.Drawing.Size(621, 184);
            this._ctlReadWriteConfig1.TabIndex = 0;
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
            this.Tag = "OptionTitle";
            this.Text = "Option";
            this.Load += new System.EventHandler(this.frmOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshForStatus)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGerneric.ResumeLayout(false);
            this.tabGerneric.PerformLayout();
            this.tabPage1.ResumeLayout(false);
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
        private TabPage tabGerneric;
        private TabPage tabPage1;
        private CtlFilePicker ctlFilePickerMongoBinPath;
        private CtlReadWriteConfig _ctlReadWriteConfig1;

    }
}