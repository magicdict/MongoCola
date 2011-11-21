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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmevalJS));
            this.cmbForMap = new System.Windows.Forms.ComboBox();
            this.cmdSaveMapJs = new System.Windows.Forms.VistaButton();
            this.lblMapFunction = new System.Windows.Forms.Label();
            this.txtevalJs = new System.Windows.Forms.TextBox();
            this.cmdEval = new System.Windows.Forms.VistaButton();
            this.txtParm = new System.Windows.Forms.TextBox();
            this.lblParm = new System.Windows.Forms.Label();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.lblParm);
            this.contentPanel.Controls.Add(this.cmdEval);
            this.contentPanel.Controls.Add(this.cmbForMap);
            this.contentPanel.Controls.Add(this.cmdSaveMapJs);
            this.contentPanel.Controls.Add(this.lblMapFunction);
            this.contentPanel.Controls.Add(this.txtevalJs);
            this.contentPanel.Controls.Add(this.txtParm);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(573, 292);
            // 
            // cmbForMap
            // 
            this.cmbForMap.FormattingEnabled = true;
            this.cmbForMap.Location = new System.Drawing.Point(114, 32);
            this.cmbForMap.Name = "cmbForMap";
            this.cmbForMap.Size = new System.Drawing.Size(151, 21);
            this.cmbForMap.TabIndex = 18;
            // 
            // cmdSaveMapJs
            // 
            this.cmdSaveMapJs.BackColor = System.Drawing.Color.Transparent;
            this.cmdSaveMapJs.Location = new System.Drawing.Point(271, 28);
            this.cmdSaveMapJs.Name = "cmdSaveMapJs";
            this.cmdSaveMapJs.Size = new System.Drawing.Size(70, 30);
            this.cmdSaveMapJs.TabIndex = 21;
            this.cmdSaveMapJs.Text = "保存";
            this.cmdSaveMapJs.Click += new System.EventHandler(this.cmdSaveMapJs_Click);
            // 
            // lblMapFunction
            // 
            this.lblMapFunction.AutoSize = true;
            this.lblMapFunction.BackColor = System.Drawing.Color.Transparent;
            this.lblMapFunction.Location = new System.Drawing.Point(46, 37);
            this.lblMapFunction.Name = "lblMapFunction";
            this.lblMapFunction.Size = new System.Drawing.Size(55, 13);
            this.lblMapFunction.TabIndex = 20;
            this.lblMapFunction.Text = "执行函数";
            // 
            // txtevalJs
            // 
            this.txtevalJs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtevalJs.Location = new System.Drawing.Point(42, 61);
            this.txtevalJs.Multiline = true;
            this.txtevalJs.Name = "txtevalJs";
            this.txtevalJs.Size = new System.Drawing.Size(520, 160);
            this.txtevalJs.TabIndex = 19;
            this.txtevalJs.Text = "function eval(){\r\n     var i = 0;\r\n     i++;\r\n     return i;\r\n     }";
            // 
            // cmdEval
            // 
            this.cmdEval.BackColor = System.Drawing.Color.Transparent;
            this.cmdEval.Location = new System.Drawing.Point(356, 28);
            this.cmdEval.Name = "cmdEval";
            this.cmdEval.Size = new System.Drawing.Size(80, 30);
            this.cmdEval.TabIndex = 22;
            this.cmdEval.Text = "执行";
            this.cmdEval.Click += new System.EventHandler(this.cmdEval_Click);
            // 
            // txtParm
            // 
            this.txtParm.Location = new System.Drawing.Point(42, 243);
            this.txtParm.Name = "txtParm";
            this.txtParm.Size = new System.Drawing.Size(520, 20);
            this.txtParm.TabIndex = 5;
            // 
            // lblParm
            // 
            this.lblParm.AutoSize = true;
            this.lblParm.BackColor = System.Drawing.Color.Transparent;
            this.lblParm.Location = new System.Drawing.Point(46, 227);
            this.lblParm.Name = "lblParm";
            this.lblParm.Size = new System.Drawing.Size(103, 13);
            this.lblParm.TabIndex = 23;
            this.lblParm.Text = "参数（用逗号分开）";
            // 
            // frmevalJS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 355);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmevalJS";
            this.ShowSelectSkinButton = false;
            this.Text = "执行Javascript";
            this.Load += new System.EventHandler(this.frmevalJS_Load);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbForMap;
        private System.Windows.Forms.VistaButton cmdSaveMapJs;
        private System.Windows.Forms.Label lblMapFunction;
        private System.Windows.Forms.TextBox txtevalJs;
        private System.Windows.Forms.VistaButton cmdEval;
        private System.Windows.Forms.Label lblParm;
        private System.Windows.Forms.TextBox txtParm;
    }
}