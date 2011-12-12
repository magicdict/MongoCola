namespace MagicMongoDBTool
{
    partial class frmevalJS
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
            this.cmbFuncLst = new System.Windows.Forms.ComboBox();
            this.cmdSaveJs = new System.Windows.Forms.Button();
            this.lblFunction = new System.Windows.Forms.Label();
            this.txtevalJs = new System.Windows.Forms.TextBox();
            this.cmdEval = new System.Windows.Forms.Button();
            this.txtParm = new System.Windows.Forms.TextBox();
            this.lblParm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbFuncLst
            // 
            this.cmbFuncLst.FormattingEnabled = true;
            this.cmbFuncLst.Location = new System.Drawing.Point(80, 12);
            this.cmbFuncLst.Name = "cmbFuncLst";
            this.cmbFuncLst.Size = new System.Drawing.Size(151, 21);
            this.cmbFuncLst.TabIndex = 0;
            // 
            // cmdSaveJs
            // 
            this.cmdSaveJs.BackColor = System.Drawing.Color.Transparent;
            this.cmdSaveJs.Location = new System.Drawing.Point(237, 8);
            this.cmdSaveJs.Name = "cmdSaveJs";
            this.cmdSaveJs.Size = new System.Drawing.Size(70, 30);
            this.cmdSaveJs.TabIndex = 1;
            this.cmdSaveJs.Text = "Save";
            this.cmdSaveJs.UseVisualStyleBackColor = false;
            this.cmdSaveJs.Click += new System.EventHandler(this.cmdSaveMapJs_Click);
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.BackColor = System.Drawing.Color.Transparent;
            this.lblFunction.Location = new System.Drawing.Point(12, 17);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(41, 13);
            this.lblFunction.TabIndex = 20;
            this.lblFunction.Text = "Eval Js";
            // 
            // txtevalJs
            // 
            this.txtevalJs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtevalJs.Location = new System.Drawing.Point(8, 41);
            this.txtevalJs.Multiline = true;
            this.txtevalJs.Name = "txtevalJs";
            this.txtevalJs.Size = new System.Drawing.Size(520, 160);
            this.txtevalJs.TabIndex = 3;
            this.txtevalJs.Text = "function eval(){\r\n     var i = 0;\r\n     i++;\r\n     return i;\r\n     }";
            // 
            // cmdEval
            // 
            this.cmdEval.BackColor = System.Drawing.Color.Transparent;
            this.cmdEval.Location = new System.Drawing.Point(322, 8);
            this.cmdEval.Name = "cmdEval";
            this.cmdEval.Size = new System.Drawing.Size(80, 30);
            this.cmdEval.TabIndex = 2;
            this.cmdEval.Text = "Eval";
            this.cmdEval.UseVisualStyleBackColor = false;
            this.cmdEval.Click += new System.EventHandler(this.cmdEval_Click);
            // 
            // txtParm
            // 
            this.txtParm.Location = new System.Drawing.Point(8, 223);
            this.txtParm.Name = "txtParm";
            this.txtParm.Size = new System.Drawing.Size(520, 20);
            this.txtParm.TabIndex = 4;
            // 
            // lblParm
            // 
            this.lblParm.AutoSize = true;
            this.lblParm.BackColor = System.Drawing.Color.Transparent;
            this.lblParm.Location = new System.Drawing.Point(12, 207);
            this.lblParm.Name = "lblParm";
            this.lblParm.Size = new System.Drawing.Size(126, 13);
            this.lblParm.TabIndex = 23;
            this.lblParm.Text = "Parameter(seperate by \',\')";
            // 
            // frmevalJS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 266);
            this.Controls.Add(this.lblParm);
            this.Controls.Add(this.cmdEval);
            this.Controls.Add(this.cmbFuncLst);
            this.Controls.Add(this.cmdSaveJs);
            this.Controls.Add(this.lblFunction);
            this.Controls.Add(this.txtevalJs);
            this.Controls.Add(this.txtParm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmevalJS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "执行Javascript";
            this.Load += new System.EventHandler(this.frmevalJS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFuncLst;
        private System.Windows.Forms.Button cmdSaveJs;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.TextBox txtevalJs;
        private System.Windows.Forms.Button cmdEval;
        private System.Windows.Forms.Label lblParm;
        private System.Windows.Forms.TextBox txtParm;
    }
}