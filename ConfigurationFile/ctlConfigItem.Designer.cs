namespace ConfigurationFile
{
    partial class CtlConfigItem
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
            this.lblPrimaryVersion = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.radTrue = new System.Windows.Forms.RadioButton();
            this.radFalse = new System.Windows.Forms.RadioButton();
            this.lblBoolean = new System.Windows.Forms.Label();
            this.lblString = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblInteger = new System.Windows.Forms.Label();
            this.intValue = new System.Windows.Forms.NumericUpDown();
            this.lblValueType = new System.Windows.Forms.Label();
            this.lblList = new System.Windows.Forms.Label();
            this.cmbValue = new System.Windows.Forms.ComboBox();
            this.fileValue = new ResourceLib.UI.CtlFilePicker();
            ((System.ComponentModel.ISupportInitialize)(this.intValue)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPrimaryVersion
            // 
            this.lblPrimaryVersion.AutoSize = true;
            this.lblPrimaryVersion.Location = new System.Drawing.Point(12, 211);
            this.lblPrimaryVersion.Name = "lblPrimaryVersion";
            this.lblPrimaryVersion.Size = new System.Drawing.Size(65, 12);
            this.lblPrimaryVersion.TabIndex = 0;
            this.lblPrimaryVersion.Text = "*版本信息*";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 15);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(53, 12);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "*全路径*";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(9, 89);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(519, 108);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "*描述*";
            // 
            // radTrue
            // 
            this.radTrue.AutoSize = true;
            this.radTrue.Location = new System.Drawing.Point(99, 42);
            this.radTrue.Name = "radTrue";
            this.radTrue.Size = new System.Drawing.Size(47, 16);
            this.radTrue.TabIndex = 1;
            this.radTrue.TabStop = true;
            this.radTrue.Text = "True";
            this.radTrue.UseVisualStyleBackColor = true;
            this.radTrue.Visible = false;
            // 
            // radFalse
            // 
            this.radFalse.AutoSize = true;
            this.radFalse.Location = new System.Drawing.Point(165, 42);
            this.radFalse.Name = "radFalse";
            this.radFalse.Size = new System.Drawing.Size(53, 16);
            this.radFalse.TabIndex = 2;
            this.radFalse.TabStop = true;
            this.radFalse.Text = "False";
            this.radFalse.UseVisualStyleBackColor = true;
            this.radFalse.Visible = false;
            // 
            // lblBoolean
            // 
            this.lblBoolean.AutoSize = true;
            this.lblBoolean.Location = new System.Drawing.Point(37, 42);
            this.lblBoolean.Name = "lblBoolean";
            this.lblBoolean.Size = new System.Drawing.Size(41, 12);
            this.lblBoolean.TabIndex = 3;
            this.lblBoolean.Text = "布尔型";
            this.lblBoolean.Visible = false;
            // 
            // lblString
            // 
            this.lblString.AutoSize = true;
            this.lblString.Location = new System.Drawing.Point(37, 42);
            this.lblString.Name = "lblString";
            this.lblString.Size = new System.Drawing.Size(41, 12);
            this.lblString.TabIndex = 3;
            this.lblString.Text = "字符型";
            this.lblString.Visible = false;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(99, 42);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(196, 21);
            this.txtValue.TabIndex = 4;
            this.txtValue.Visible = false;
            // 
            // lblInteger
            // 
            this.lblInteger.AutoSize = true;
            this.lblInteger.Location = new System.Drawing.Point(37, 42);
            this.lblInteger.Name = "lblInteger";
            this.lblInteger.Size = new System.Drawing.Size(41, 12);
            this.lblInteger.TabIndex = 3;
            this.lblInteger.Text = "数字型";
            this.lblInteger.Visible = false;
            // 
            // intValue
            // 
            this.intValue.Location = new System.Drawing.Point(99, 42);
            this.intValue.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.intValue.Name = "intValue";
            this.intValue.Size = new System.Drawing.Size(73, 21);
            this.intValue.TabIndex = 5;
            this.intValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.intValue.Visible = false;
            // 
            // lblValueType
            // 
            this.lblValueType.AutoSize = true;
            this.lblValueType.Location = new System.Drawing.Point(233, 15);
            this.lblValueType.Name = "lblValueType";
            this.lblValueType.Size = new System.Drawing.Size(41, 12);
            this.lblValueType.TabIndex = 0;
            this.lblValueType.Text = "*类型*";
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.Location = new System.Drawing.Point(37, 42);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(41, 12);
            this.lblList.TabIndex = 3;
            this.lblList.Text = "可选值";
            this.lblList.Visible = false;
            // 
            // cmbValue
            // 
            this.cmbValue.FormattingEnabled = true;
            this.cmbValue.Location = new System.Drawing.Point(99, 42);
            this.cmbValue.Name = "cmbValue";
            this.cmbValue.Size = new System.Drawing.Size(121, 20);
            this.cmbValue.TabIndex = 6;
            this.cmbValue.Visible = false;
            // 
            // fileValue
            // 
            this.fileValue.AutoSize = true;
            this.fileValue.BackColor = System.Drawing.Color.Transparent;
            this.fileValue.Browse = "浏览";
            this.fileValue.Clear = "清空";
            this.fileValue.FileFilter = "";
            this.fileValue.InitFileName = "";
            this.fileValue.Location = new System.Drawing.Point(27, 30);
            this.fileValue.Name = "fileValue";
            this.fileValue.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.Directory;
            this.fileValue.SelectedPathOrFileName = "";
            this.fileValue.Size = new System.Drawing.Size(477, 38);
            this.fileValue.TabIndex = 7;
            this.fileValue.Title = "";
            // 
            // ctlConfigItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fileValue);
            this.Controls.Add(this.cmbValue);
            this.Controls.Add(this.intValue);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblList);
            this.Controls.Add(this.lblInteger);
            this.Controls.Add(this.lblString);
            this.Controls.Add(this.lblBoolean);
            this.Controls.Add(this.radFalse);
            this.Controls.Add(this.radTrue);
            this.Controls.Add(this.lblValueType);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblPrimaryVersion);
            this.Name = "CtlConfigItem";
            this.Size = new System.Drawing.Size(558, 238);
            ((System.ComponentModel.ISupportInitialize)(this.intValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrimaryVersion;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RadioButton radTrue;
        private System.Windows.Forms.RadioButton radFalse;
        private System.Windows.Forms.Label lblBoolean;
        private System.Windows.Forms.Label lblString;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lblInteger;
        private System.Windows.Forms.NumericUpDown intValue;
        private System.Windows.Forms.Label lblValueType;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.ComboBox cmbValue;
        private ResourceLib.UI.CtlFilePicker fileValue;
    }
}
