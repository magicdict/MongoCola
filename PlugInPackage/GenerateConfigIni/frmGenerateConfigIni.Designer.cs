using System.ComponentModel;
using System.Windows.Forms;
using PlugInPackage.DosCommand;

namespace PlugInPackage.GenerateConfigIni
{
    partial class FrmGenerateConfigIni
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpReplset = new System.Windows.Forms.GroupBox();
            this.lnkRef = new System.Windows.Forms.LinkLabel();
            this.ctlGenerateMongod = new CtlMongod();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(487, 306);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(121, 31);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(614, 307);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpReplset
            // 
            this.grpReplset.Location = new System.Drawing.Point(38, 229);
            this.grpReplset.Name = "grpReplset";
            this.grpReplset.Size = new System.Drawing.Size(696, 72);
            this.grpReplset.TabIndex = 4;
            this.grpReplset.TabStop = false;
            this.grpReplset.Text = "Replset";
            // 
            // lnkRef
            // 
            this.lnkRef.AutoSize = true;
            this.lnkRef.Location = new System.Drawing.Point(52, 315);
            this.lnkRef.Name = "lnkRef";
            this.lnkRef.Size = new System.Drawing.Size(323, 13);
            this.lnkRef.TabIndex = 5;
            this.lnkRef.TabStop = true;
            this.lnkRef.Text = "http://docs.mongodb.org/manual/reference/configuration-options/";
            this.lnkRef.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRef_LinkClicked);
            // 
            // ctlGenerateMongod
            // 
            this.ctlGenerateMongod.BackColor = System.Drawing.Color.Transparent;
            this.ctlGenerateMongod.Location = new System.Drawing.Point(12, 2);
            this.ctlGenerateMongod.Name = "ctlGenerateMongod";
            this.ctlGenerateMongod.Size = new System.Drawing.Size(767, 210);
            this.ctlGenerateMongod.TabIndex = 0;
            // 
            // frmGenerateConfigIni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(779, 362);
            this.Controls.Add(this.lnkRef);
            this.Controls.Add(this.grpReplset);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.ctlGenerateMongod);
            this.Name = "FrmGenerateConfigIni";
            this.Text = "Generate Config INI File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtlMongod ctlGenerateMongod;
        private Button btnGenerate;
        private Button btnClose;
        private GroupBox grpReplset;
        private LinkLabel lnkRef;
    }
}