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
            this.txtDosCommand = new System.Windows.Forms.TextBox();
            this.tabFunction = new System.Windows.Forms.TabControl();
            this.tabMongod = new System.Windows.Forms.TabPage();
            this.tabMongoDump = new System.Windows.Forms.TabPage();
            this.cmdRunDos = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.ctlMongodPanel = new MagicMongoDBTool.ctlMongod();
            this.ctlMongodump1 = new MagicMongoDBTool.Module.ctlMongodump();
            this.tabFunction.SuspendLayout();
            this.tabMongod.SuspendLayout();
            this.tabMongoDump.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDosCommand
            // 
            this.txtDosCommand.Location = new System.Drawing.Point(12, 280);
            this.txtDosCommand.Multiline = true;
            this.txtDosCommand.Name = "txtDosCommand";
            this.txtDosCommand.Size = new System.Drawing.Size(737, 138);
            this.txtDosCommand.TabIndex = 0;
            // 
            // tabFunction
            // 
            this.tabFunction.Controls.Add(this.tabMongod);
            this.tabFunction.Controls.Add(this.tabMongoDump);
            this.tabFunction.Location = new System.Drawing.Point(12, 12);
            this.tabFunction.Name = "tabFunction";
            this.tabFunction.SelectedIndex = 0;
            this.tabFunction.Size = new System.Drawing.Size(851, 247);
            this.tabFunction.TabIndex = 1;
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
            // tabMongoDump
            // 
            this.tabMongoDump.Controls.Add(this.ctlMongodump1);
            this.tabMongoDump.Location = new System.Drawing.Point(4, 22);
            this.tabMongoDump.Name = "tabMongoDump";
            this.tabMongoDump.Padding = new System.Windows.Forms.Padding(3);
            this.tabMongoDump.Size = new System.Drawing.Size(843, 221);
            this.tabMongoDump.TabIndex = 1;
            this.tabMongoDump.Text = "备份与恢复(mongodump)";
            this.tabMongoDump.UseVisualStyleBackColor = true;
            // 
            // cmdRunDos
            // 
            this.cmdRunDos.Location = new System.Drawing.Point(763, 280);
            this.cmdRunDos.Name = "cmdRunDos";
            this.cmdRunDos.Size = new System.Drawing.Size(96, 29);
            this.cmdRunDos.TabIndex = 2;
            this.cmdRunDos.Text = "运行";
            this.cmdRunDos.UseVisualStyleBackColor = true;
            this.cmdRunDos.Click += new System.EventHandler(this.cmdRunDos_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(763, 319);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(96, 25);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "保存";
            this.cmdSave.UseVisualStyleBackColor = true;
            // 
            // ctlMongodPanel
            // 
            this.ctlMongodPanel.Location = new System.Drawing.Point(6, 6);
            this.ctlMongodPanel.Name = "ctlMongodPanel";
            this.ctlMongodPanel.Size = new System.Drawing.Size(831, 209);
            this.ctlMongodPanel.TabIndex = 2;
            // 
            // ctlMongodump1
            // 
            this.ctlMongodump1.Location = new System.Drawing.Point(16, 6);
            this.ctlMongodump1.Name = "ctlMongodump1";
            this.ctlMongodump1.Size = new System.Drawing.Size(800, 200);
            this.ctlMongodump1.TabIndex = 0;
            // 
            // frmDosCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 445);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdRunDos);
            this.Controls.Add(this.tabFunction);
            this.Controls.Add(this.txtDosCommand);
            this.Name = "frmDosCommand";
            this.Text = "frmDosCommand";
            this.Load += new System.EventHandler(this.frmDosCommand_Load);
            this.tabFunction.ResumeLayout(false);
            this.tabMongod.ResumeLayout(false);
            this.tabMongoDump.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDosCommand;
        private System.Windows.Forms.TabControl tabFunction;
        private System.Windows.Forms.TabPage tabMongod;
        private System.Windows.Forms.TabPage tabMongoDump;
        private ctlMongod ctlMongodPanel;
        private System.Windows.Forms.Button cmdRunDos;
        private System.Windows.Forms.Button cmdSave;
        private Module.ctlMongodump ctlMongodump1;
    }
}