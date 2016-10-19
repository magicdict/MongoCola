using System.ComponentModel;
using System.Windows.Forms;
using MongoGUICtl;

namespace FunctionForm.Aggregation
{
    partial class FrmAggregation
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
            this.lblResult = new System.Windows.Forms.Label();
            this.cmdRun = new System.Windows.Forms.Button();
            this.cmdAddCondition = new System.Windows.Forms.Button();
            this.lnkReference = new System.Windows.Forms.LinkLabel();
            this.cmdSaveAggregatePipeline = new System.Windows.Forms.Button();
            this.lblAggregatePipeline = new System.Windows.Forms.Label();
            this.cmbForAggregatePipeline = new System.Windows.Forms.ComboBox();
            this.cmdClear = new System.Windows.Forms.Button();
            this.btnAggrBuilder = new System.Windows.Forms.Button();
            this.trvCondition = new MongoGUICtl.CtlTreeViewColumns();
            this.trvResult = new MongoGUICtl.CtlTreeViewColumns();
            this.btnSaveAsView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Location = new System.Drawing.Point(430, 23);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(41, 12);
            this.lblResult.TabIndex = 20;
            this.lblResult.Text = "Result";
            // 
            // cmdRun
            // 
            this.cmdRun.BackColor = System.Drawing.Color.Transparent;
            this.cmdRun.Location = new System.Drawing.Point(694, 376);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(89, 30);
            this.cmdRun.TabIndex = 21;
            this.cmdRun.Tag = "Command_Run";
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = false;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // cmdAddCondition
            // 
            this.cmdAddCondition.Location = new System.Drawing.Point(126, 376);
            this.cmdAddCondition.Name = "cmdAddCondition";
            this.cmdAddCondition.Size = new System.Drawing.Size(103, 30);
            this.cmdAddCondition.TabIndex = 23;
            this.cmdAddCondition.Text = "Add Stage(s)";
            this.cmdAddCondition.UseVisualStyleBackColor = true;
            this.cmdAddCondition.Click += new System.EventHandler(this.cmdAddCondition_Click);
            // 
            // lnkReference
            // 
            this.lnkReference.AutoSize = true;
            this.lnkReference.Location = new System.Drawing.Point(430, 8);
            this.lnkReference.Name = "lnkReference";
            this.lnkReference.Size = new System.Drawing.Size(191, 12);
            this.lnkReference.TabIndex = 24;
            this.lnkReference.TabStop = true;
            this.lnkReference.Text = "Aggregation Framework Reference";
            this.lnkReference.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReference_LinkClicked);
            // 
            // cmdSaveAggregatePipeline
            // 
            this.cmdSaveAggregatePipeline.Location = new System.Drawing.Point(599, 376);
            this.cmdSaveAggregatePipeline.Name = "cmdSaveAggregatePipeline";
            this.cmdSaveAggregatePipeline.Size = new System.Drawing.Size(89, 30);
            this.cmdSaveAggregatePipeline.TabIndex = 25;
            this.cmdSaveAggregatePipeline.Text = "Save Stages";
            this.cmdSaveAggregatePipeline.UseVisualStyleBackColor = true;
            this.cmdSaveAggregatePipeline.Click += new System.EventHandler(this.cmdSaveAggregatePipeline_Click);
            // 
            // lblAggregatePipeline
            // 
            this.lblAggregatePipeline.AutoSize = true;
            this.lblAggregatePipeline.BackColor = System.Drawing.Color.Transparent;
            this.lblAggregatePipeline.Location = new System.Drawing.Point(13, 23);
            this.lblAggregatePipeline.Name = "lblAggregatePipeline";
            this.lblAggregatePipeline.Size = new System.Drawing.Size(41, 12);
            this.lblAggregatePipeline.TabIndex = 26;
            this.lblAggregatePipeline.Text = "Stages";
            // 
            // cmbForAggregatePipeline
            // 
            this.cmbForAggregatePipeline.FormattingEnabled = true;
            this.cmbForAggregatePipeline.Location = new System.Drawing.Point(60, 20);
            this.cmbForAggregatePipeline.Name = "cmbForAggregatePipeline";
            this.cmbForAggregatePipeline.Size = new System.Drawing.Size(345, 20);
            this.cmbForAggregatePipeline.TabIndex = 27;
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(235, 376);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(89, 30);
            this.cmdClear.TabIndex = 29;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // btnAggrBuilder
            // 
            this.btnAggrBuilder.Location = new System.Drawing.Point(15, 376);
            this.btnAggrBuilder.Name = "btnAggrBuilder";
            this.btnAggrBuilder.Size = new System.Drawing.Size(105, 30);
            this.btnAggrBuilder.TabIndex = 30;
            this.btnAggrBuilder.Text = "Stage Builder";
            this.btnAggrBuilder.UseVisualStyleBackColor = true;
            this.btnAggrBuilder.Click += new System.EventHandler(this.btnAggrBuilder_Click);
            // 
            // trvCondition
            // 
            this.trvCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvCondition.Location = new System.Drawing.Point(12, 45);
            this.trvCondition.Name = "trvCondition";
            this.trvCondition.Padding = new System.Windows.Forms.Padding(1);
            this.trvCondition.Size = new System.Drawing.Size(393, 304);
            this.trvCondition.TabIndex = 22;
            // 
            // trvResult
            // 
            this.trvResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvResult.Location = new System.Drawing.Point(433, 42);
            this.trvResult.Name = "trvResult";
            this.trvResult.Padding = new System.Windows.Forms.Padding(1);
            this.trvResult.Size = new System.Drawing.Size(385, 307);
            this.trvResult.TabIndex = 0;
            // 
            // btnSaveAsView
            // 
            this.btnSaveAsView.Location = new System.Drawing.Point(502, 376);
            this.btnSaveAsView.Name = "btnSaveAsView";
            this.btnSaveAsView.Size = new System.Drawing.Size(89, 30);
            this.btnSaveAsView.TabIndex = 31;
            this.btnSaveAsView.Text = "Save As View";
            this.btnSaveAsView.UseVisualStyleBackColor = true;
            this.btnSaveAsView.Click += new System.EventHandler(this.btnSaveAsView_Click);
            // 
            // FrmAggregation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(829, 423);
            this.Controls.Add(this.btnSaveAsView);
            this.Controls.Add(this.btnAggrBuilder);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmbForAggregatePipeline);
            this.Controls.Add(this.lblAggregatePipeline);
            this.Controls.Add(this.cmdSaveAggregatePipeline);
            this.Controls.Add(this.lnkReference);
            this.Controls.Add(this.cmdAddCondition);
            this.Controls.Add(this.trvCondition);
            this.Controls.Add(this.cmdRun);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.trvResult);
            this.Name = "FrmAggregation";
            this.Text = "Aggregation";
            this.Load += new System.EventHandler(this.frmAggregation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtlTreeViewColumns trvResult;
        private Label lblResult;
        private Button cmdRun;
        private CtlTreeViewColumns trvCondition;
        private Button cmdAddCondition;
        private LinkLabel lnkReference;
        private Button cmdSaveAggregatePipeline;
        private Label lblAggregatePipeline;
        private ComboBox cmbForAggregatePipeline;
        private Button cmdClear;
        private Button btnAggrBuilder;
        private Button btnSaveAsView;
    }
}