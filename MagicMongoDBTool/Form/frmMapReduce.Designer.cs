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
            this.cmbForMap = new System.Windows.Forms.ComboBox();
            this.cmbForReduce = new System.Windows.Forms.ComboBox();
            this.cmdSaveReduceJs = new System.Windows.Forms.Button();
            this.cmdSaveMapJs = new System.Windows.Forms.Button();
            this.lblReduceFunction = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblMapFunction = new System.Windows.Forms.Label();
            this.trvResult = new System.Windows.Forms.TreeView();
            this.txtMapJs = new System.Windows.Forms.TextBox();
            this.txtReduceJs = new System.Windows.Forms.TextBox();
            this.cmdRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbForMap
            // 
            this.cmbForMap.FormattingEnabled = true;
            this.cmbForMap.Location = new System.Drawing.Point(100, 28);
            this.cmbForMap.Name = "cmbForMap";
            this.cmbForMap.Size = new System.Drawing.Size(151, 21);
            this.cmbForMap.TabIndex = 0;
            // 
            // cmbForReduce
            // 
            this.cmbForReduce.FormattingEnabled = true;
            this.cmbForReduce.Location = new System.Drawing.Point(101, 239);
            this.cmbForReduce.Name = "cmbForReduce";
            this.cmbForReduce.Size = new System.Drawing.Size(151, 21);
            this.cmbForReduce.TabIndex = 3;
            // 
            // cmdSaveReduceJs
            // 
            this.cmdSaveReduceJs.BackColor = System.Drawing.Color.Transparent;
            this.cmdSaveReduceJs.Location = new System.Drawing.Point(257, 234);
            this.cmdSaveReduceJs.Name = "cmdSaveReduceJs";
            this.cmdSaveReduceJs.Size = new System.Drawing.Size(70, 30);
            this.cmdSaveReduceJs.TabIndex = 4;
            this.cmdSaveReduceJs.Text = "保存";
            this.cmdSaveReduceJs.UseVisualStyleBackColor = false;
            this.cmdSaveReduceJs.Click += new System.EventHandler(this.cmdSaveReduceJs_Click);
            // 
            // cmdSaveMapJs
            // 
            this.cmdSaveMapJs.BackColor = System.Drawing.Color.Transparent;
            this.cmdSaveMapJs.Location = new System.Drawing.Point(257, 22);
            this.cmdSaveMapJs.Name = "cmdSaveMapJs";
            this.cmdSaveMapJs.Size = new System.Drawing.Size(70, 30);
            this.cmdSaveMapJs.TabIndex = 1;
            this.cmdSaveMapJs.Text = "保存";
            this.cmdSaveMapJs.UseVisualStyleBackColor = false;
            this.cmdSaveMapJs.Click += new System.EventHandler(this.cmdSaveMapJs_Click);
            // 
            // lblReduceFunction
            // 
            this.lblReduceFunction.AutoSize = true;
            this.lblReduceFunction.BackColor = System.Drawing.Color.Transparent;
            this.lblReduceFunction.Location = new System.Drawing.Point(32, 244);
            this.lblReduceFunction.Name = "lblReduceFunction";
            this.lblReduceFunction.Size = new System.Drawing.Size(69, 13);
            this.lblReduceFunction.TabIndex = 16;
            this.lblReduceFunction.Text = "Reduce函数";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Location = new System.Drawing.Point(333, 28);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(31, 13);
            this.lblResult.TabIndex = 15;
            this.lblResult.Text = "结果";
            // 
            // lblMapFunction
            // 
            this.lblMapFunction.AutoSize = true;
            this.lblMapFunction.BackColor = System.Drawing.Color.Transparent;
            this.lblMapFunction.Location = new System.Drawing.Point(32, 31);
            this.lblMapFunction.Name = "lblMapFunction";
            this.lblMapFunction.Size = new System.Drawing.Size(52, 13);
            this.lblMapFunction.TabIndex = 14;
            this.lblMapFunction.Text = "Map函数";
            // 
            // trvResult
            // 
            this.trvResult.Location = new System.Drawing.Point(333, 55);
            this.trvResult.Name = "trvResult";
            this.trvResult.Size = new System.Drawing.Size(363, 377);
            this.trvResult.TabIndex = 6;
            // 
            // txtMapJs
            // 
            this.txtMapJs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMapJs.Location = new System.Drawing.Point(28, 55);
            this.txtMapJs.Multiline = true;
            this.txtMapJs.Name = "txtMapJs";
            this.txtMapJs.Size = new System.Drawing.Size(299, 172);
            this.txtMapJs.TabIndex = 2;
            this.txtMapJs.Text = "function Map(){\r\n     emit(this.Age,1);\r\n     }\r\n";
            // 
            // txtReduceJs
            // 
            this.txtReduceJs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReduceJs.Location = new System.Drawing.Point(28, 263);
            this.txtReduceJs.Multiline = true;
            this.txtReduceJs.Name = "txtReduceJs";
            this.txtReduceJs.Size = new System.Drawing.Size(299, 169);
            this.txtReduceJs.TabIndex = 5;
            this.txtReduceJs.Text = "function Reduce(key, arr_values) {\r\n     var total = 0;\r\n     for(var i in arr_va" +
    "lues){\r\n         temp = arr_values[i];\r\n         total += temp;\r\n     }\r\n     re" +
    "turn total;\r\n     }\r\n";
            // 
            // cmdRun
            // 
            this.cmdRun.BackColor = System.Drawing.Color.Transparent;
            this.cmdRun.Location = new System.Drawing.Point(621, 438);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(75, 34);
            this.cmdRun.TabIndex = 7;
            this.cmdRun.Text = "运行";
            this.cmdRun.UseVisualStyleBackColor = false;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // frmMapReduce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 485);
            this.Controls.Add(this.cmbForMap);
            this.Controls.Add(this.cmbForReduce);
            this.Controls.Add(this.cmdSaveReduceJs);
            this.Controls.Add(this.cmdSaveMapJs);
            this.Controls.Add(this.lblReduceFunction);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblMapFunction);
            this.Controls.Add(this.trvResult);
            this.Controls.Add(this.txtMapJs);
            this.Controls.Add(this.txtReduceJs);
            this.Controls.Add(this.cmdRun);
            this.Name = "frmMapReduce";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MapReduce";
            this.Load += new System.EventHandler(this.frmMapReduce_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbForMap;
        private System.Windows.Forms.ComboBox cmbForReduce;
        private System.Windows.Forms.Button cmdSaveReduceJs;
        private System.Windows.Forms.Button cmdSaveMapJs;
        private System.Windows.Forms.Label lblReduceFunction;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblMapFunction;
        private System.Windows.Forms.TreeView trvResult;
        private System.Windows.Forms.TextBox txtMapJs;
        private System.Windows.Forms.TextBox txtReduceJs;
        private System.Windows.Forms.Button cmdRun;
    }
}