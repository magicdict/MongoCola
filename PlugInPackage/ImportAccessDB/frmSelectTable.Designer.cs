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
        	this.AccessPicker = new CtlFilePicker();
        	this.btnGetTabelList = new System.Windows.Forms.Button();
        	this.chkTable = new System.Windows.Forms.CheckedListBox();
        	this.btnImport = new System.Windows.Forms.Button();
        	this.SuspendLayout();
        	// 
        	// AccessPicker
        	// 
        	this.AccessPicker.BackColor = System.Drawing.Color.Transparent;
        	this.AccessPicker.FileFilter = "";
        	this.AccessPicker.InitFileName = "";
        	this.AccessPicker.Location = new System.Drawing.Point(35, 20);
        	this.AccessPicker.Name = "AccessPicker";
        	this.AccessPicker.PickerType = CtlFilePicker.DialogType.OpenFile;
        	this.AccessPicker.SelectedPathOrFileName = "";
        	this.AccessPicker.Size = new System.Drawing.Size(640, 29);
        	this.AccessPicker.TabIndex = 0;
        	this.AccessPicker.Title = "AccessFileName";
        	// 
        	// btnGetTabelList
        	// 
        	this.btnGetTabelList.Location = new System.Drawing.Point(542, 55);
        	this.btnGetTabelList.Name = "btnGetTabelList";
        	this.btnGetTabelList.Size = new System.Drawing.Size(116, 31);
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
        	this.btnImport.Location = new System.Drawing.Point(542, 245);
        	this.btnImport.Name = "btnImport";
        	this.btnImport.Size = new System.Drawing.Size(116, 27);
        	this.btnImport.TabIndex = 3;
        	this.btnImport.Text = "Import";
        	this.btnImport.UseVisualStyleBackColor = true;
        	this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
        	// 
        	// SelectTable
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.Color.White;
        	this.ClientSize = new System.Drawing.Size(679, 284);
        	this.Controls.Add(this.btnImport);
        	this.Controls.Add(this.chkTable);
        	this.Controls.Add(this.btnGetTabelList);
        	this.Controls.Add(this.AccessPicker);
        	this.Name = "SelectTable";
        	this.Text = "SelectTable";
        	this.Load += new System.EventHandler(this.SelectTable_Load);
        	this.ResumeLayout(false);

        }

        #endregion

        private CtlFilePicker AccessPicker;
        private Button btnGetTabelList;
        private CheckedListBox chkTable;
        private Button btnImport;
    }
}