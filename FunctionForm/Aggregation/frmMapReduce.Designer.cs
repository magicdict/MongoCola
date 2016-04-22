using System.ComponentModel;
using System.Windows.Forms;
using MongoGUICtl;

namespace FunctionForm.Aggregation
{
    partial class FrmMapReduce
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
            this.ctlMapFunction = new MongoGUICtl.CtlTextMgr();
            this.trvResult = new MongoGUICtl.CtlTreeViewColumns();
            this.ctlReduceFunction = new MongoGUICtl.CtlTextMgr();
            this.cmdClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Location = new System.Drawing.Point(407, 12);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(42, 15);
            this.lblResult.TabIndex = 15;
            this.lblResult.Tag = "";
            this.lblResult.Text = "Result";
            // 
            // cmdRun
            // 
            this.cmdRun.BackColor = System.Drawing.Color.Transparent;
            this.cmdRun.Location = new System.Drawing.Point(607, 501);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(103, 30);
            this.cmdRun.TabIndex = 7;
            this.cmdRun.Tag = "Common_Run";
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = false;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // ctlMapFunction
            // 
            this.ctlMapFunction.Context = "";
            this.ctlMapFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlMapFunction.Location = new System.Drawing.Point(12, 12);
            this.ctlMapFunction.Name = "ctlMapFunction";
            this.ctlMapFunction.Size = new System.Drawing.Size(369, 245);
            this.ctlMapFunction.TabIndex = 20;
            this.ctlMapFunction.Title = "MapFunction";
            // 
            // trvResult
            // 
            this.trvResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(172)))), ((int)(((byte)(178)))));
            this.trvResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trvResult.Location = new System.Drawing.Point(410, 30);
            this.trvResult.Name = "trvResult";
            this.trvResult.Padding = new System.Windows.Forms.Padding(1);
            this.trvResult.Size = new System.Drawing.Size(417, 460);
            this.trvResult.TabIndex = 17;
            // 
            // ctlReduceFunction
            // 
            this.ctlReduceFunction.Context = "";
            this.ctlReduceFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlReduceFunction.Location = new System.Drawing.Point(12, 263);
            this.ctlReduceFunction.Name = "ctlReduceFunction";
            this.ctlReduceFunction.Size = new System.Drawing.Size(369, 227);
            this.ctlReduceFunction.TabIndex = 21;
            this.ctlReduceFunction.Title = "Reduce Function";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(716, 501);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(111, 30);
            this.cmdClose.TabIndex = 22;
            this.cmdClose.Tag = "Common_Close";
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // FrmMapReduce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(839, 543);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.ctlReduceFunction);
            this.Controls.Add(this.ctlMapFunction);
            this.Controls.Add(this.trvResult);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.cmdRun);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMapReduce";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MapReduce";
            this.Load += new System.EventHandler(this.frmMapReduce_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblResult;
        private Button cmdRun;
        
        private CtlTreeViewColumns trvResult;
        private CtlTextMgr ctlMapFunction;
        private CtlTextMgr ctlReduceFunction;
        private Button cmdClose;
    }
}