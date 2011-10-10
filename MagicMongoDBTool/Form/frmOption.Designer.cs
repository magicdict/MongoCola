namespace MagicMongoDBTool
{
    partial class frmOption
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.ctlFilePickerMongoBinPath = new MagicMongoDBTool.ctlFilePicker();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(530, 224);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "确认";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(627, 224);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // ctlFilePickerMongoBinPath
            // 
            this.ctlFilePickerMongoBinPath.Location = new System.Drawing.Point(12, 12);
            this.ctlFilePickerMongoBinPath.Name = "ctlFilePickerMongoBinPath";
            this.ctlFilePickerMongoBinPath.PickType = MagicMongoDBTool.ctlFilePicker.DialogType.Directory;
            this.ctlFilePickerMongoBinPath.Size = new System.Drawing.Size(739, 27);
            this.ctlFilePickerMongoBinPath.TabIndex = 5;
            this.ctlFilePickerMongoBinPath.Title = "Mongodb的Bin路径";
            // 
            // frmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 273);
            this.Controls.Add(this.ctlFilePickerMongoBinPath);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Name = "frmOption";
            this.Text = "配置";
            this.Load += new System.EventHandler(this.frmOption_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private ctlFilePicker ctlFilePickerMongoBinPath;
    }
}