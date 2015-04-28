using System.ComponentModel;
using System.Windows.Forms;
using ResourceLib.UI;

namespace MongoGUICtl
{
    partial class CtlMongoImportExport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHost = new System.Windows.Forms.Label();
            this.txtHostAddr = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblDBName = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.lblCollectionName = new System.Windows.Forms.Label();
            this.txtCollectionName = new System.Windows.Forms.TextBox();
            this.lblFieldList = new System.Windows.Forms.Label();
            this.txtFieldList = new System.Windows.Forms.TextBox();
            this.grpDirect = new System.Windows.Forms.GroupBox();
            this.radExport = new System.Windows.Forms.RadioButton();
            this.radImport = new System.Windows.Forms.RadioButton();
            this.ctlFilePickerOutput = new CtlFilePicker();
            this.ctllogLvT = new CtllogLv();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.grpDirect.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(37, 28);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(29, 13);
            this.lblHost.TabIndex = 2;
            this.lblHost.Text = "Host";
            // 
            // txtHostAddr
            // 
            this.txtHostAddr.Location = new System.Drawing.Point(116, 25);
            this.txtHostAddr.Name = "txtHostAddr";
            this.txtHostAddr.Size = new System.Drawing.Size(161, 20);
            this.txtHostAddr.TabIndex = 3;
            this.txtHostAddr.TextChanged += new System.EventHandler(this.txtHostAddr_TextChanged);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(304, 28);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 4;
            this.lblPort.Text = "Port";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(392, 26);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(67, 20);
            this.numPort.TabIndex = 9;
            this.numPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPort.Value = new decimal(new int[] {
            27017,
            0,
            0,
            0});
            this.numPort.ValueChanged += new System.EventHandler(this.numPort_ValueChanged);
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(37, 61);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(54, 13);
            this.lblDBName.TabIndex = 10;
            this.lblDBName.Text = "DataBase";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(116, 54);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(161, 20);
            this.txtDBName.TabIndex = 11;
            this.txtDBName.TextChanged += new System.EventHandler(this.txtDBName_TextChanged);
            // 
            // lblCollectionName
            // 
            this.lblCollectionName.AutoSize = true;
            this.lblCollectionName.Location = new System.Drawing.Point(304, 57);
            this.lblCollectionName.Name = "lblCollectionName";
            this.lblCollectionName.Size = new System.Drawing.Size(53, 13);
            this.lblCollectionName.TabIndex = 12;
            this.lblCollectionName.Text = "Collection";
            // 
            // txtCollectionName
            // 
            this.txtCollectionName.Location = new System.Drawing.Point(392, 54);
            this.txtCollectionName.Name = "txtCollectionName";
            this.txtCollectionName.Size = new System.Drawing.Size(173, 20);
            this.txtCollectionName.TabIndex = 13;
            this.txtCollectionName.TextChanged += new System.EventHandler(this.txtCollectionName_TextChanged);
            // 
            // lblFieldList
            // 
            this.lblFieldList.AutoSize = true;
            this.lblFieldList.Location = new System.Drawing.Point(37, 86);
            this.lblFieldList.Name = "lblFieldList";
            this.lblFieldList.Size = new System.Drawing.Size(38, 13);
            this.lblFieldList.TabIndex = 14;
            this.lblFieldList.Text = "fieldlist";
            // 
            // txtFieldList
            // 
            this.txtFieldList.Location = new System.Drawing.Point(116, 83);
            this.txtFieldList.Name = "txtFieldList";
            this.txtFieldList.Size = new System.Drawing.Size(449, 20);
            this.txtFieldList.TabIndex = 15;
            this.txtFieldList.TextChanged += new System.EventHandler(this.txtFieldList_TextChanged);
            // 
            // grpDirect
            // 
            this.grpDirect.Controls.Add(this.radExport);
            this.grpDirect.Controls.Add(this.radImport);
            this.grpDirect.Location = new System.Drawing.Point(596, 54);
            this.grpDirect.Name = "grpDirect";
            this.grpDirect.Size = new System.Drawing.Size(161, 41);
            this.grpDirect.TabIndex = 16;
            this.grpDirect.TabStop = false;
            this.grpDirect.Text = "Opration";
            // 
            // radExport
            // 
            this.radExport.AutoSize = true;
            this.radExport.Location = new System.Drawing.Point(90, 16);
            this.radExport.Name = "radExport";
            this.radExport.Size = new System.Drawing.Size(55, 17);
            this.radExport.TabIndex = 1;
            this.radExport.Text = "ExportImport";
            this.radExport.UseVisualStyleBackColor = true;
            this.radExport.CheckedChanged += new System.EventHandler(this.radExport_CheckedChanged);
            // 
            // radImport
            // 
            this.radImport.AutoSize = true;
            this.radImport.Checked = true;
            this.radImport.Location = new System.Drawing.Point(26, 16);
            this.radImport.Name = "radImport";
            this.radImport.Size = new System.Drawing.Size(54, 17);
            this.radImport.TabIndex = 0;
            this.radImport.TabStop = true;
            this.radImport.Text = "Import";
            this.radImport.UseVisualStyleBackColor = true;
            this.radImport.CheckedChanged += new System.EventHandler(this.radImport_CheckedChanged);
            // 
            // ctlFilePickerOutput
            // 
            this.ctlFilePickerOutput.BackColor = System.Drawing.Color.Transparent;
            this.ctlFilePickerOutput.FileFilter = "";
            this.ctlFilePickerOutput.Location = new System.Drawing.Point(34, 107);
            this.ctlFilePickerOutput.Name = "ctlFilePickerOutput";
            this.ctlFilePickerOutput.PickerType = CtlFilePicker.DialogType.SaveFile;
            this.ctlFilePickerOutput.SelectedPathOrFileName = "";
            this.ctlFilePickerOutput.Size = new System.Drawing.Size(739, 33);
            this.ctlFilePickerOutput.TabIndex = 1;
            this.ctlFilePickerOutput.Title = "FilePath：";
            // 
            // ctllogLvT
            // 
            this.ctllogLvT.BackColor = System.Drawing.Color.Transparent;
            this.ctllogLvT.Location = new System.Drawing.Point(485, 146);
            this.ctllogLvT.Name = "ctllogLvT";
            this.ctllogLvT.Size = new System.Drawing.Size(312, 51);
            this.ctllogLvT.TabIndex = 0;
            // 
            // ctlMongoImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpDirect);
            this.Controls.Add(this.txtFieldList);
            this.Controls.Add(this.lblFieldList);
            this.Controls.Add(this.txtCollectionName);
            this.Controls.Add(this.lblCollectionName);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.lblDBName);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtHostAddr);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.ctlFilePickerOutput);
            this.Controls.Add(this.ctllogLvT);
            this.Name = "CtlMongoImportExport";
            this.Size = new System.Drawing.Size(800, 195);
            this.Load += new System.EventHandler(this.ctlMongodump_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.grpDirect.ResumeLayout(false);
            this.grpDirect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtllogLv ctllogLvT;
        private CtlFilePicker ctlFilePickerOutput;
        private Label lblHost;
        private TextBox txtHostAddr;
        private Label lblPort;
        private NumericUpDown numPort;
        private Label lblDBName;
        private TextBox txtDBName;
        private Label lblCollectionName;
        private TextBox txtCollectionName;
        private Label lblFieldList;
        private TextBox txtFieldList;
        private GroupBox grpDirect;
        private RadioButton radExport;
        private RadioButton radImport;
    }
}
