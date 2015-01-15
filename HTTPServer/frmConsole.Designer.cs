using Common.UI;

namespace HTTPServer
{
    partial class frmConsole
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
            this.lnkWebFormEntry = new System.Windows.Forms.LinkLabel();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.ServerPathPicker = new ctlFilePicker();
            this.ConfigFile = new ctlFilePicker();
            this.SuspendLayout();
            // 
            // lnkWebFormEntry
            // 
            this.lnkWebFormEntry.AutoSize = true;
            this.lnkWebFormEntry.Location = new System.Drawing.Point(361, 75);
            this.lnkWebFormEntry.Name = "lnkWebFormEntry";
            this.lnkWebFormEntry.Size = new System.Drawing.Size(143, 12);
            this.lnkWebFormEntry.TabIndex = 12;
            this.lnkWebFormEntry.TabStop = true;
            this.lnkWebFormEntry.Text = "MongoCola WebForm(Beta)";
            this.lnkWebFormEntry.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWebFormEntry_LinkClicked);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(21, 90);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(508, 142);
            this.txtInfo.TabIndex = 13;
            // 
            // ServerPathPicker
            // 
            this.ServerPathPicker.BackColor = System.Drawing.Color.Transparent;
            this.ServerPathPicker.FileFilter = "";
            this.ServerPathPicker.FileName = "";
            this.ServerPathPicker.Location = new System.Drawing.Point(21, 12);
            this.ServerPathPicker.Name = "ServerPathPicker";
            this.ServerPathPicker.PickerType = ctlFilePicker.DialogType.Directory;
            this.ServerPathPicker.SelectedPathOrFileName = "";
            this.ServerPathPicker.Size = new System.Drawing.Size(508, 29);
            this.ServerPathPicker.TabIndex = 14;
            this.ServerPathPicker.Title = "Template";
            // 
            // ConfigFile
            // 
            this.ConfigFile.BackColor = System.Drawing.Color.Transparent;
            this.ConfigFile.FileFilter = "";
            this.ConfigFile.FileName = "";
            this.ConfigFile.Location = new System.Drawing.Point(21, 43);
            this.ConfigFile.Name = "ConfigFile";
            this.ConfigFile.PickerType = ctlFilePicker.DialogType.OpenFile;
            this.ConfigFile.SelectedPathOrFileName = "";
            this.ConfigFile.Size = new System.Drawing.Size(508, 29);
            this.ConfigFile.TabIndex = 14;
            this.ConfigFile.Title = "Config  ";
            // 
            // frmConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(553, 242);
            this.Controls.Add(this.ConfigFile);
            this.Controls.Add(this.ServerPathPicker);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.lnkWebFormEntry);
            this.Name = "frmConsole";
            this.Text = "Console";
            this.Load += new System.EventHandler(this.Console_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkWebFormEntry;
        private System.Windows.Forms.TextBox txtInfo;
        private ctlFilePicker ServerPathPicker;
        private ctlFilePicker ConfigFile;
    }
}