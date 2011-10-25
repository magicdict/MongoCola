namespace MagicMongoDBTool.Module
{
    partial class ctlMongoImportExport
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.lblHostAddr = new System.Windows.Forms.Label();
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
            this.ctlFilePickerOutput = new MagicMongoDBTool.ctlFilePicker();
            this.ctllogLvT = new MagicMongoDBTool.Module.ctllogLv();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.grpDirect.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHostAddr
            // 
            this.lblHostAddr.AutoSize = true;
            this.lblHostAddr.Location = new System.Drawing.Point(37, 28);
            this.lblHostAddr.Name = "lblHostAddr";
            this.lblHostAddr.Size = new System.Drawing.Size(61, 13);
            this.lblHostAddr.TabIndex = 2;
            this.lblHostAddr.Text = "主机地址：";
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
            this.lblPort.Size = new System.Drawing.Size(49, 13);
            this.lblPort.TabIndex = 4;
            this.lblPort.Text = "端口号：";
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
            this.lblDBName.Size = new System.Drawing.Size(73, 13);
            this.lblDBName.TabIndex = 10;
            this.lblDBName.Text = "数据库名称：";
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
            this.lblCollectionName.Size = new System.Drawing.Size(67, 13);
            this.lblCollectionName.TabIndex = 12;
            this.lblCollectionName.Text = "数据集名称";
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
            this.lblFieldList.Size = new System.Drawing.Size(55, 13);
            this.lblFieldList.TabIndex = 14;
            this.lblFieldList.Text = "字段列表";
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
            this.grpDirect.Text = "操作";
            // 
            // radExport
            // 
            this.radExport.AutoSize = true;
            this.radExport.Location = new System.Drawing.Point(90, 16);
            this.radExport.Name = "radExport";
            this.radExport.Size = new System.Drawing.Size(49, 17);
            this.radExport.TabIndex = 1;
            this.radExport.Text = "导出";
            this.radExport.UseVisualStyleBackColor = true;
            this.radExport.CheckedChanged += new System.EventHandler(this.radExport_CheckedChanged);
            // 
            // radImport
            // 
            this.radImport.AutoSize = true;
            this.radImport.Checked = true;
            this.radImport.Location = new System.Drawing.Point(26, 16);
            this.radImport.Name = "radImport";
            this.radImport.Size = new System.Drawing.Size(49, 17);
            this.radImport.TabIndex = 0;
            this.radImport.TabStop = true;
            this.radImport.Text = "导入";
            this.radImport.UseVisualStyleBackColor = true;
            this.radImport.CheckedChanged += new System.EventHandler(this.radImport_CheckedChanged);
            // 
            // ctlFilePickerOutput
            // 
            this.ctlFilePickerOutput.BackColor = System.Drawing.Color.Transparent;
            this.ctlFilePickerOutput.Location = new System.Drawing.Point(34, 107);
            this.ctlFilePickerOutput.Name = "ctlFilePickerOutput";
            this.ctlFilePickerOutput.PickType = MagicMongoDBTool.ctlFilePicker.DialogType.SaveFile;
            this.ctlFilePickerOutput.SelectedPath = "";
            this.ctlFilePickerOutput.Size = new System.Drawing.Size(739, 33);
            this.ctlFilePickerOutput.TabIndex = 1;
            this.ctlFilePickerOutput.Title = "工作文件：";
            // 
            // ctllogLvT
            // 
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
            this.Controls.Add(this.lblHostAddr);
            this.Controls.Add(this.ctlFilePickerOutput);
            this.Controls.Add(this.ctllogLvT);
            this.Name = "ctlMongoImportExport";
            this.Size = new System.Drawing.Size(800, 195);
            this.Load += new System.EventHandler(this.ctlMongodump_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.grpDirect.ResumeLayout(false);
            this.grpDirect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctllogLv ctllogLvT;
        private ctlFilePicker ctlFilePickerOutput;
        private System.Windows.Forms.Label lblHostAddr;
        private System.Windows.Forms.TextBox txtHostAddr;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label lblCollectionName;
        private System.Windows.Forms.TextBox txtCollectionName;
        private System.Windows.Forms.Label lblFieldList;
        private System.Windows.Forms.TextBox txtFieldList;
        private System.Windows.Forms.GroupBox grpDirect;
        private System.Windows.Forms.RadioButton radExport;
        private System.Windows.Forms.RadioButton radImport;
    }
}
