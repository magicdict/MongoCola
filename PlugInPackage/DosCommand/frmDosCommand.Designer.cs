using System.ComponentModel;
using System.Windows.Forms;

namespace PlugInPackage.DosCommand
{
    partial class FrmDosCommand
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
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdRunDos = new System.Windows.Forms.Button();
            this.tabFunction = new System.Windows.Forms.TabControl();
            this.tabMongod = new System.Windows.Forms.TabPage();
            this.tabMongoDump = new System.Windows.Forms.TabPage();
            this.tabMongoImportExport = new System.Windows.Forms.TabPage();
            this.txtDosCommand = new System.Windows.Forms.TextBox();
            this.ctlMongodPanel = new CtlMongod();
            this.ctlMongodumpPanel = new CtlMongodump();
            this.ctlMongoImportExportPanel = new CtlMongoImportExport();
            this.tabFunction.SuspendLayout();
            this.tabMongod.SuspendLayout();
            this.tabMongoDump.SuspendLayout();
            this.tabMongoImportExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.Transparent;
            this.cmdSave.Enabled = false;
            this.cmdSave.Location = new System.Drawing.Point(887, 410);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(112, 32);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdRunDos
            // 
            this.cmdRunDos.BackColor = System.Drawing.Color.Transparent;
            this.cmdRunDos.Location = new System.Drawing.Point(887, 449);
            this.cmdRunDos.Name = "cmdRunDos";
            this.cmdRunDos.Size = new System.Drawing.Size(112, 33);
            this.cmdRunDos.TabIndex = 6;
            this.cmdRunDos.Text = "Run";
            this.cmdRunDos.UseVisualStyleBackColor = false;
            this.cmdRunDos.Click += new System.EventHandler(this.cmdRunDos_Click);
            // 
            // tabFunction
            // 
            this.tabFunction.Controls.Add(this.tabMongod);
            this.tabFunction.Controls.Add(this.tabMongoDump);
            this.tabFunction.Controls.Add(this.tabMongoImportExport);
            this.tabFunction.Location = new System.Drawing.Point(10, 17);
            this.tabFunction.Name = "tabFunction";
            this.tabFunction.SelectedIndex = 0;
            this.tabFunction.Size = new System.Drawing.Size(993, 285);
            this.tabFunction.TabIndex = 5;
            // 
            // tabMongod
            // 
            this.tabMongod.Controls.Add(this.ctlMongodPanel);
            this.tabMongod.Location = new System.Drawing.Point(4, 24);
            this.tabMongod.Name = "tabMongod";
            this.tabMongod.Padding = new System.Windows.Forms.Padding(3);
            this.tabMongod.Size = new System.Drawing.Size(985, 257);
            this.tabMongod.TabIndex = 0;
            this.tabMongod.Text = "Mongod";
            this.tabMongod.UseVisualStyleBackColor = true;
            // 
            // tabMongoDump
            // 
            this.tabMongoDump.Controls.Add(this.ctlMongodumpPanel);
            this.tabMongoDump.Location = new System.Drawing.Point(4, 22);
            this.tabMongoDump.Name = "tabMongoDump";
            this.tabMongoDump.Padding = new System.Windows.Forms.Padding(3);
            this.tabMongoDump.Size = new System.Drawing.Size(985, 259);
            this.tabMongoDump.TabIndex = 1;
            this.tabMongoDump.Text = "mongodump";
            this.tabMongoDump.UseVisualStyleBackColor = true;
            // 
            // tabMongoImportExport
            // 
            this.tabMongoImportExport.Controls.Add(this.ctlMongoImportExportPanel);
            this.tabMongoImportExport.Location = new System.Drawing.Point(4, 22);
            this.tabMongoImportExport.Name = "tabMongoImportExport";
            this.tabMongoImportExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabMongoImportExport.Size = new System.Drawing.Size(985, 259);
            this.tabMongoImportExport.TabIndex = 2;
            this.tabMongoImportExport.Text = "mongoImport/mongoExport";
            this.tabMongoImportExport.UseVisualStyleBackColor = true;
            // 
            // txtDosCommand
            // 
            this.txtDosCommand.BackColor = System.Drawing.Color.Black;
            this.txtDosCommand.ForeColor = System.Drawing.Color.White;
            this.txtDosCommand.Location = new System.Drawing.Point(10, 327);
            this.txtDosCommand.Multiline = true;
            this.txtDosCommand.Name = "txtDosCommand";
            this.txtDosCommand.Size = new System.Drawing.Size(859, 159);
            this.txtDosCommand.TabIndex = 4;
            // 
            // ctlMongodPanel
            // 
            this.ctlMongodPanel.BackColor = System.Drawing.Color.Transparent;
            this.ctlMongodPanel.Location = new System.Drawing.Point(7, 7);
            this.ctlMongodPanel.Name = "ctlMongodPanel";
            this.ctlMongodPanel.Size = new System.Drawing.Size(969, 241);
            this.ctlMongodPanel.TabIndex = 2;
            // 
            // ctlMongodumpPanel
            // 
            this.ctlMongodumpPanel.BackColor = System.Drawing.Color.Transparent;
            this.ctlMongodumpPanel.Location = new System.Drawing.Point(19, 7);
            this.ctlMongodumpPanel.Name = "ctlMongodumpPanel";
            this.ctlMongodumpPanel.Size = new System.Drawing.Size(933, 231);
            this.ctlMongodumpPanel.TabIndex = 0;
            // 
            // ctlMongoImportExportPanel
            // 
            this.ctlMongoImportExportPanel.BackColor = System.Drawing.Color.Transparent;
            this.ctlMongoImportExportPanel.Location = new System.Drawing.Point(7, 7);
            this.ctlMongoImportExportPanel.Name = "ctlMongoImportExportPanel";
            this.ctlMongoImportExportPanel.Size = new System.Drawing.Size(933, 225);
            this.ctlMongoImportExportPanel.TabIndex = 0;
            // 
            // frmDosCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 500);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdRunDos);
            this.Controls.Add(this.tabFunction);
            this.Controls.Add(this.txtDosCommand);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDosCommand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DosCommand";
            this.Load += new System.EventHandler(this.frmDosCommand_Load);
            this.tabFunction.ResumeLayout(false);
            this.tabMongod.ResumeLayout(false);
            this.tabMongoDump.ResumeLayout(false);
            this.tabMongoImportExport.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button cmdSave;
        private Button cmdRunDos;
        private TabControl tabFunction;
        private TabPage tabMongod;
        private CtlMongod ctlMongodPanel;
        private TabPage tabMongoDump;
        private CtlMongodump ctlMongodumpPanel;
        private TabPage tabMongoImportExport;
        private CtlMongoImportExport ctlMongoImportExportPanel;
        private TextBox txtDosCommand;
    }
}