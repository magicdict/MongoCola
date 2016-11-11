using System.ComponentModel;
using System.Windows.Forms;
using ResourceLib.UI;

namespace PlugInPackage.ImportAccessDB
{
    partial class FrmSelectTable
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
            this.btnGetTabelList = new System.Windows.Forms.Button();
            this.chkTable = new System.Windows.Forms.CheckedListBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.AccessPicker = new ResourceLib.UI.CtlFilePicker();
            this.SuspendLayout();
            // 
            // btnGetTabelList
            // 
            this.btnGetTabelList.Location = new System.Drawing.Point(499, 59);
            this.btnGetTabelList.Name = "btnGetTabelList";
            this.btnGetTabelList.Size = new System.Drawing.Size(168, 31);
            this.btnGetTabelList.TabIndex = 1;
            this.btnGetTabelList.Text = "Get Table List";
            this.btnGetTabelList.UseVisualStyleBackColor = true;
            this.btnGetTabelList.Click += new System.EventHandler(this.btnGetTabelList_Click);
            // 
            // chkTable
            // 
            this.chkTable.FormattingEnabled = true;
            this.chkTable.Location = new System.Drawing.Point(35, 105);
            this.chkTable.Name = "chkTable";
            this.chkTable.Size = new System.Drawing.Size(623, 116);
            this.chkTable.TabIndex = 2;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(499, 238);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(159, 34);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // AccessPicker
            // 
            this.AccessPicker.AutoSize = true;
            this.AccessPicker.BackColor = System.Drawing.Color.Transparent;
            this.AccessPicker.Browse = "Browse...";
            this.AccessPicker.Clear = "Clear";
            this.AccessPicker.FileFilter = "";
            this.AccessPicker.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AccessPicker.InitFileName = "";
            this.AccessPicker.Location = new System.Drawing.Point(35, 20);
            this.AccessPicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AccessPicker.Name = "AccessPicker";
            this.AccessPicker.PickerType = ResourceLib.UI.CtlFilePicker.DialogType.OpenFile;
            this.AccessPicker.SelectedPathOrFileName = "";
            this.AccessPicker.Size = new System.Drawing.Size(640, 32);
            this.AccessPicker.TabIndex = 0;
            this.AccessPicker.Title = "AccessFileName";
            // 
            // FrmSelectTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(679, 284);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.chkTable);
            this.Controls.Add(this.btnGetTabelList);
            this.Controls.Add(this.AccessPicker);
            this.Name = "FrmSelectTable";
            this.Text = "SelectTable";
            this.Load += new System.EventHandler(this.SelectTable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtlFilePicker AccessPicker;
        private Button btnGetTabelList;
        private CheckedListBox chkTable;
        private Button btnImport;
    }
}