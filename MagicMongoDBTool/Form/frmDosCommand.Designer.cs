namespace MagicMongoDBTool
{
    partial class frmDosCommand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDosCommand));
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdRunDos = new System.Windows.Forms.Button();
            this.tabFunction = new System.Windows.Forms.TabControl();
            this.tabMongod = new System.Windows.Forms.TabPage();
            this.ctlMongodPanel = new MagicMongoDBTool.ctlMongod();
            this.tabMongoDump = new System.Windows.Forms.TabPage();
            this.ctlMongodumpPanel = new MagicMongoDBTool.Module.ctlMongodump();
            this.tabMongoImportExport = new System.Windows.Forms.TabPage();
            this.ctlMongoImportExportPanel = new MagicMongoDBTool.Module.ctlMongoImportExport();
            this.txtDosCommand = new System.Windows.Forms.TextBox();
            this.contentPanel.SuspendLayout();
            this.tabFunction.SuspendLayout();
            this.tabMongod.SuspendLayout();
            this.tabMongoDump.SuspendLayout();
            this.tabMongoImportExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.cmdSave);
            this.contentPanel.Controls.Add(this.cmdRunDos);
            this.contentPanel.Controls.Add(this.tabFunction);
            this.contentPanel.Controls.Add(this.txtDosCommand);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(869, 436);
            // 
            // cmdSave
            // 
            this.cmdSave.Enabled = false;
            this.cmdSave.Location = new System.Drawing.Point(760, 322);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(96, 25);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "保存";
            this.cmdSave.UseVisualStyleBackColor = true;
            // 
            // cmdRunDos
            // 
            this.cmdRunDos.Location = new System.Drawing.Point(760, 283);
            this.cmdRunDos.Name = "cmdRunDos";
            this.cmdRunDos.Size = new System.Drawing.Size(96, 29);
            this.cmdRunDos.TabIndex = 6;
            this.cmdRunDos.Text = "运行";
            this.cmdRunDos.UseVisualStyleBackColor = true;
            this.cmdRunDos.Click += new System.EventHandler(this.cmdRunDos_Click);
            // 
            // tabFunction
            // 
            this.tabFunction.Controls.Add(this.tabMongod);
            this.tabFunction.Controls.Add(this.tabMongoDump);
            this.tabFunction.Controls.Add(this.tabMongoImportExport);
            this.tabFunction.Location = new System.Drawing.Point(9, 15);
            this.tabFunction.Name = "tabFunction";
            this.tabFunction.SelectedIndex = 0;
            this.tabFunction.Size = new System.Drawing.Size(851, 247);
            this.tabFunction.TabIndex = 5;
            // 
            // tabMongod
            // 
            this.tabMongod.Controls.Add(this.ctlMongodPanel);
            this.tabMongod.Location = new System.Drawing.Point(4, 22);
            this.tabMongod.Name = "tabMongod";
            this.tabMongod.Padding = new System.Windows.Forms.Padding(3);
            this.tabMongod.Size = new System.Drawing.Size(843, 221);
            this.tabMongod.TabIndex = 0;
            this.tabMongod.Text = "部署（Mongod）";
            this.tabMongod.UseVisualStyleBackColor = true;
            // 
            // ctlMongodPanel
            // 
            this.ctlMongodPanel.Location = new System.Drawing.Point(6, 6);
            this.ctlMongodPanel.Name = "ctlMongodPanel";
            this.ctlMongodPanel.Size = new System.Drawing.Size(831, 209);
            this.ctlMongodPanel.TabIndex = 2;
            // 
            // tabMongoDump
            // 
            this.tabMongoDump.Controls.Add(this.ctlMongodumpPanel);
            this.tabMongoDump.Location = new System.Drawing.Point(4, 22);
            this.tabMongoDump.Name = "tabMongoDump";
            this.tabMongoDump.Padding = new System.Windows.Forms.Padding(3);
            this.tabMongoDump.Size = new System.Drawing.Size(843, 221);
            this.tabMongoDump.TabIndex = 1;
            this.tabMongoDump.Text = "备份与恢复(mongodump)";
            this.tabMongoDump.UseVisualStyleBackColor = true;
            // 
            // ctlMongodumpPanel
            // 
            this.ctlMongodumpPanel.Location = new System.Drawing.Point(16, 6);
            this.ctlMongodumpPanel.Name = "ctlMongodumpPanel";
            this.ctlMongodumpPanel.Size = new System.Drawing.Size(800, 200);
            this.ctlMongodumpPanel.TabIndex = 0;
            // 
            // tabMongoImportExport
            // 
            this.tabMongoImportExport.Controls.Add(this.ctlMongoImportExportPanel);
            this.tabMongoImportExport.Location = new System.Drawing.Point(4, 22);
            this.tabMongoImportExport.Name = "tabMongoImportExport";
            this.tabMongoImportExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabMongoImportExport.Size = new System.Drawing.Size(843, 221);
            this.tabMongoImportExport.TabIndex = 2;
            this.tabMongoImportExport.Text = "导入于导出（mongoImport/mongoExport)";
            this.tabMongoImportExport.UseVisualStyleBackColor = true;
            // 
            // ctlMongoImportExportPanel
            // 
            this.ctlMongoImportExportPanel.Location = new System.Drawing.Point(6, 6);
            this.ctlMongoImportExportPanel.Name = "ctlMongoImportExportPanel";
            this.ctlMongoImportExportPanel.Size = new System.Drawing.Size(800, 195);
            this.ctlMongoImportExportPanel.TabIndex = 0;
            // 
            // txtDosCommand
            // 
            this.txtDosCommand.Location = new System.Drawing.Point(9, 283);
            this.txtDosCommand.Multiline = true;
            this.txtDosCommand.Name = "txtDosCommand";
            this.txtDosCommand.Size = new System.Drawing.Size(737, 138);
            this.txtDosCommand.TabIndex = 4;
            // 
            // frmDosCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 499);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDosCommand";
            this.Text = "frmDosCommand";
            this.Load += new System.EventHandler(this.frmDosCommand_Load);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.tabFunction.ResumeLayout(false);
            this.tabMongod.ResumeLayout(false);
            this.tabMongoDump.ResumeLayout(false);
            this.tabMongoImportExport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdRunDos;
        private System.Windows.Forms.TabControl tabFunction;
        private System.Windows.Forms.TabPage tabMongod;
        private ctlMongod ctlMongodPanel;
        private System.Windows.Forms.TabPage tabMongoDump;
        private Module.ctlMongodump ctlMongodumpPanel;
        private System.Windows.Forms.TabPage tabMongoImportExport;
        private Module.ctlMongoImportExport ctlMongoImportExportPanel;
        private System.Windows.Forms.TextBox txtDosCommand;
    }
}