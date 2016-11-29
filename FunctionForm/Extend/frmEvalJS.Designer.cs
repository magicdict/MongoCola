using System.ComponentModel;
using System.Windows.Forms;
using MongoGUICtl;

namespace FunctionForm.Extend
{
    partial class FrmEvalJs
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
            this.cmdEval = new System.Windows.Forms.Button();
            this.txtParm = new System.Windows.Forms.TextBox();
            this.lblParm = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.ctlEval = new MongoGUICtl.ctlJsCodeEditor();
            this.SuspendLayout();
            // 
            // cmdEval
            // 
            this.cmdEval.BackColor = System.Drawing.Color.Transparent;
            this.cmdEval.Location = new System.Drawing.Point(386, 285);
            this.cmdEval.Name = "cmdEval";
            this.cmdEval.Size = new System.Drawing.Size(93, 24);
            this.cmdEval.TabIndex = 2;
            this.cmdEval.Tag = "Common.Run";
            this.cmdEval.Text = "Eval";
            this.cmdEval.UseVisualStyleBackColor = false;
            this.cmdEval.Click += new System.EventHandler(this.cmdEval_Click);
            // 
            // txtParm
            // 
            this.txtParm.Location = new System.Drawing.Point(21, 285);
            this.txtParm.Name = "txtParm";
            this.txtParm.Size = new System.Drawing.Size(342, 21);
            this.txtParm.TabIndex = 4;
            // 
            // lblParm
            // 
            this.lblParm.AutoSize = true;
            this.lblParm.BackColor = System.Drawing.Color.Transparent;
            this.lblParm.Location = new System.Drawing.Point(26, 267);
            this.lblParm.Name = "lblParm";
            this.lblParm.Size = new System.Drawing.Size(148, 15);
            this.lblParm.TabIndex = 23;
            this.lblParm.Tag = "EvalJS.Parameter";
            this.lblParm.Text = "Parameter(seperate by \',\')";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(21, 345);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(472, 170);
            this.txtResult.TabIndex = 25;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(26, 321);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(42, 15);
            this.lblResult.TabIndex = 26;
            this.lblResult.Tag = "Common.Result";
            this.lblResult.Text = "Result";
            // 
            // ctlEval
            // 
            this.ctlEval.Context = "";
            this.ctlEval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlEval.Location = new System.Drawing.Point(12, 0);
            this.ctlEval.Name = "ctlEval";
            this.ctlEval.Size = new System.Drawing.Size(497, 264);
            this.ctlEval.TabIndex = 24;
            this.ctlEval.Tag = "EvalJS_Method";
            this.ctlEval.Title = "Eval Js";
            // 
            // FrmEvalJs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(515, 527);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.ctlEval);
            this.Controls.Add(this.lblParm);
            this.Controls.Add(this.cmdEval);
            this.Controls.Add(this.txtParm);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEvalJs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "EvalJS.Title";
            this.Text = "Eval Javascript";
            this.Load += new System.EventHandler(this.frmevalJS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button cmdEval;
        private Label lblParm;
        private TextBox txtParm;
        private ctlJsCodeEditor ctlEval;
        private TextBox txtResult;
        private Label lblResult;
    }
}