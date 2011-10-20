namespace MagicMongoDBTool
{
    partial class frmMapReduce
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
            this.cmdRun = new System.Windows.Forms.Button();
            this.txtReduceJs = new System.Windows.Forms.TextBox();
            this.txtMapJs = new System.Windows.Forms.TextBox();
            this.trvResult = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSaveMapJs = new System.Windows.Forms.Button();
            this.cmdSaveReduceJs = new System.Windows.Forms.Button();
            this.cmbForReduce = new System.Windows.Forms.ComboBox();
            this.cmbForMap = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmdRun
            // 
            this.cmdRun.Location = new System.Drawing.Point(614, 450);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(75, 23);
            this.cmdRun.TabIndex = 0;
            this.cmdRun.Text = "运行";
            this.cmdRun.UseVisualStyleBackColor = true;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // txtReduceJs
            // 
            this.txtReduceJs.Location = new System.Drawing.Point(21, 261);
            this.txtReduceJs.Multiline = true;
            this.txtReduceJs.Name = "txtReduceJs";
            this.txtReduceJs.Size = new System.Drawing.Size(299, 169);
            this.txtReduceJs.TabIndex = 1;
            // 
            // txtMapJs
            // 
            this.txtMapJs.Location = new System.Drawing.Point(21, 53);
            this.txtMapJs.Multiline = true;
            this.txtMapJs.Name = "txtMapJs";
            this.txtMapJs.Size = new System.Drawing.Size(299, 172);
            this.txtMapJs.TabIndex = 2;
            // 
            // trvResult
            // 
            this.trvResult.Location = new System.Drawing.Point(326, 26);
            this.trvResult.Name = "trvResult";
            this.trvResult.Size = new System.Drawing.Size(363, 404);
            this.trvResult.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Map函数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Reduce函数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "结果";
            // 
            // cmdSaveMapJs
            // 
            this.cmdSaveMapJs.Location = new System.Drawing.Point(250, 24);
            this.cmdSaveMapJs.Name = "cmdSaveMapJs";
            this.cmdSaveMapJs.Size = new System.Drawing.Size(70, 23);
            this.cmdSaveMapJs.TabIndex = 6;
            this.cmdSaveMapJs.Text = "保存";
            this.cmdSaveMapJs.UseVisualStyleBackColor = true;
            this.cmdSaveMapJs.Click += new System.EventHandler(this.cmdSaveMapJs_Click);
            // 
            // cmdSaveReduceJs
            // 
            this.cmdSaveReduceJs.Location = new System.Drawing.Point(250, 236);
            this.cmdSaveReduceJs.Name = "cmdSaveReduceJs";
            this.cmdSaveReduceJs.Size = new System.Drawing.Size(70, 23);
            this.cmdSaveReduceJs.TabIndex = 8;
            this.cmdSaveReduceJs.Text = "保存";
            this.cmdSaveReduceJs.UseVisualStyleBackColor = true;
            this.cmdSaveReduceJs.Click += new System.EventHandler(this.cmdSaveReduceJs_Click);
            // 
            // cmbForReduce
            // 
            this.cmbForReduce.FormattingEnabled = true;
            this.cmbForReduce.Location = new System.Drawing.Point(94, 237);
            this.cmbForReduce.Name = "cmbForReduce";
            this.cmbForReduce.Size = new System.Drawing.Size(151, 21);
            this.cmbForReduce.TabIndex = 9;
            // 
            // cmbForMap
            // 
            this.cmbForMap.FormattingEnabled = true;
            this.cmbForMap.Location = new System.Drawing.Point(93, 26);
            this.cmbForMap.Name = "cmbForMap";
            this.cmbForMap.Size = new System.Drawing.Size(151, 21);
            this.cmbForMap.TabIndex = 9;
            // 
            // frmMapReduce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 485);
            this.Controls.Add(this.cmbForMap);
            this.Controls.Add(this.cmbForReduce);
            this.Controls.Add(this.cmdSaveReduceJs);
            this.Controls.Add(this.cmdSaveMapJs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trvResult);
            this.Controls.Add(this.txtMapJs);
            this.Controls.Add(this.txtReduceJs);
            this.Controls.Add(this.cmdRun);
            this.Name = "frmMapReduce";
            this.Text = "frmMapReduce";
            this.Load += new System.EventHandler(this.frmMapReduce_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdRun;
        private System.Windows.Forms.TextBox txtReduceJs;
        private System.Windows.Forms.TextBox txtMapJs;
        private System.Windows.Forms.TreeView trvResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdSaveMapJs;
        private System.Windows.Forms.Button cmdSaveReduceJs;
        private System.Windows.Forms.ComboBox cmbForReduce;
        private System.Windows.Forms.ComboBox cmbForMap;
    }
}