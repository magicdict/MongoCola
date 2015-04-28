using System.ComponentModel;
using System.Windows.Forms;
using ResourceLib.UI;

namespace MongoGUICtl
{
    partial class CtlMongodump
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
            this.ctllogLvT = new CtllogLv();
            this.ctlFilePickerOutput = new CtlFilePicker();
            this.lblHostAddr = new System.Windows.Forms.Label();
            this.txtHostAddr = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblDBName = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.lblCollectionName = new System.Windows.Forms.Label();
            this.txtCollectionName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // ctllogLvT
            // 
            this.ctllogLvT.BackColor = System.Drawing.Color.Transparent;
            this.ctllogLvT.Location = new System.Drawing.Point(485, 146);
            this.ctllogLvT.Name = "ctllogLvT";
            this.ctllogLvT.Size = new System.Drawing.Size(312, 51);
            this.ctllogLvT.TabIndex = 0;
            // 
            // ctlFilePickerOutput
            // 
            this.ctlFilePickerOutput.BackColor = System.Drawing.Color.Transparent;
            this.ctlFilePickerOutput.FileFilter = "";
            this.ctlFilePickerOutput.Location = new System.Drawing.Point(33, 98);
            this.ctlFilePickerOutput.Name = "ctlFilePickerOutput";
            this.ctlFilePickerOutput.PickerType = CtlFilePicker.DialogType.Directory;
            this.ctlFilePickerOutput.SelectedPathOrFileName = "";
            this.ctlFilePickerOutput.Size = new System.Drawing.Size(739, 41);
            this.ctlFilePickerOutput.TabIndex = 1;
            this.ctlFilePickerOutput.Title = "BackUpPath";
            // 
            // lblHostAddr
            // 
            this.lblHostAddr.AutoSize = true;
            this.lblHostAddr.Location = new System.Drawing.Point(37, 28);
            this.lblHostAddr.Name = "lblHostAddr";
            this.lblHostAddr.Size = new System.Drawing.Size(29, 13);
            this.lblHostAddr.TabIndex = 2;
            this.lblHostAddr.Text = "Host";
            // 
            // txtHostAddr
            // 
            this.txtHostAddr.Location = new System.Drawing.Point(131, 25);
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
            this.lblDBName.Size = new System.Drawing.Size(81, 13);
            this.lblDBName.TabIndex = 10;
            this.lblDBName.Text = "DatabaseName";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(131, 54);
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
            this.lblCollectionName.Size = new System.Drawing.Size(81, 13);
            this.lblCollectionName.TabIndex = 12;
            this.lblCollectionName.Text = "CollectionName";
            // 
            // txtCollectionName
            // 
            this.txtCollectionName.Location = new System.Drawing.Point(392, 54);
            this.txtCollectionName.Name = "txtCollectionName";
            this.txtCollectionName.Size = new System.Drawing.Size(173, 20);
            this.txtCollectionName.TabIndex = 13;
            this.txtCollectionName.TextChanged += new System.EventHandler(this.txtCollectionName_TextChanged);
            // 
            // ctlMongodump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtCollectionName);
            this.Controls.Add(this.lblCollectionName);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.lblDBName);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtHostAddr);
            this.Controls.Add(this.lblHostAddr);
            this.Controls.Add(this.ctlFilePickerOutput);
            this.Controls.Add(this.ctllogLvT);
            this.Name = "CtlMongodump";
            this.Size = new System.Drawing.Size(800, 200);
            this.Load += new System.EventHandler(this.ctlMongodump_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtllogLv ctllogLvT;
        private CtlFilePicker ctlFilePickerOutput;
        private Label lblHostAddr;
        private TextBox txtHostAddr;
        private Label lblPort;
        private NumericUpDown numPort;
        private Label lblDBName;
        private TextBox txtDBName;
        private Label lblCollectionName;
        private TextBox txtCollectionName;
    }
}
