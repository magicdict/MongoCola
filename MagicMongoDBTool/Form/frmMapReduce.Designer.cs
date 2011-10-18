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
            this.cmdLoadMapJs = new System.Windows.Forms.Button();
            this.cmdSaveMapJs = new System.Windows.Forms.Button();
            this.cmdLoadReduceJs = new System.Windows.Forms.Button();
            this.cmdSaveReduceJs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdRun
            // 
            this.cmdRun.Location = new System.Drawing.Point(794, 447);
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
            this.trvResult.Size = new System.Drawing.Size(543, 404);
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
            this.label2.Location = new System.Drawing.Point(25, 245);
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
            // cmdLoadMapJs
            // 
            this.cmdLoadMapJs.Location = new System.Drawing.Point(100, 24);
            this.cmdLoadMapJs.Name = "cmdLoadMapJs";
            this.cmdLoadMapJs.Size = new System.Drawing.Size(92, 23);
            this.cmdLoadMapJs.TabIndex = 6;
            this.cmdLoadMapJs.Text = "载入Map函数";
            this.cmdLoadMapJs.UseVisualStyleBackColor = true;
            this.cmdLoadMapJs.Click += new System.EventHandler(this.cmdLoadMapJs_Click);
            // 
            // cmdSaveMapJs
            // 
            this.cmdSaveMapJs.Location = new System.Drawing.Point(213, 24);
            this.cmdSaveMapJs.Name = "cmdSaveMapJs";
            this.cmdSaveMapJs.Size = new System.Drawing.Size(92, 23);
            this.cmdSaveMapJs.TabIndex = 6;
            this.cmdSaveMapJs.Text = "保存Map函数";
            this.cmdSaveMapJs.UseVisualStyleBackColor = true;
            this.cmdSaveMapJs.Click += new System.EventHandler(this.cmdSaveMapJs_Click);
            // 
            // cmdLoadReduceJs
            // 
            this.cmdLoadReduceJs.Location = new System.Drawing.Point(100, 235);
            this.cmdLoadReduceJs.Name = "cmdLoadReduceJs";
            this.cmdLoadReduceJs.Size = new System.Drawing.Size(107, 23);
            this.cmdLoadReduceJs.TabIndex = 7;
            this.cmdLoadReduceJs.Text = "载入Reduce函数";
            this.cmdLoadReduceJs.UseVisualStyleBackColor = true;
            // 
            // cmdSaveReduceJs
            // 
            this.cmdSaveReduceJs.Location = new System.Drawing.Point(213, 235);
            this.cmdSaveReduceJs.Name = "cmdSaveReduceJs";
            this.cmdSaveReduceJs.Size = new System.Drawing.Size(106, 23);
            this.cmdSaveReduceJs.TabIndex = 8;
            this.cmdSaveReduceJs.Text = "保存Reduce函数";
            this.cmdSaveReduceJs.UseVisualStyleBackColor = true;
            this.cmdSaveReduceJs.Click += new System.EventHandler(this.cmdSaveReduceJs_Click);
            // 
            // frmMapReduce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 485);
            this.Controls.Add(this.cmdSaveReduceJs);
            this.Controls.Add(this.cmdLoadReduceJs);
            this.Controls.Add(this.cmdSaveMapJs);
            this.Controls.Add(this.cmdLoadMapJs);
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
        private System.Windows.Forms.Button cmdLoadMapJs;
        private System.Windows.Forms.Button cmdSaveMapJs;
        private System.Windows.Forms.Button cmdLoadReduceJs;
        private System.Windows.Forms.Button cmdSaveReduceJs;
    }
}