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
            this.txtMapJs = new System.Windows.Forms.TextBox();
            this.txtReduceJs = new System.Windows.Forms.TextBox();
            this.cmdRun = new System.Windows.Forms.Button();
            this.trvResult = new TreeViewColumnsProject.TreeViewColumns();
            this.SuspendLayout();
            // 
            // cmbForMap
            // 
            this.cmbForMap.FormattingEnabled = true;
            this.cmbForMap.Location = new System.Drawing.Point(100, 21);
            this.cmbForMap.Name = "cmbForMap";
            this.cmbForMap.Size = new System.Drawing.Size(175, 23);
            this.cmbForMap.TabIndex = 0;
            // 
            // cmbForReduce
            // 
            this.cmbForReduce.FormattingEnabled = true;
            this.cmbForReduce.Location = new System.Drawing.Point(101, 262);
            this.cmbForReduce.Name = "cmbForReduce";
            this.cmbForReduce.Size = new System.Drawing.Size(175, 23);
            this.cmbForReduce.TabIndex = 3;
            // 
            // cmdSaveReduceJs
            // 
            this.cmdSaveReduceJs.BackColor = System.Drawing.Color.Transparent;
            this.cmdSaveReduceJs.Location = new System.Drawing.Point(283, 260);
            this.cmdSaveReduceJs.Name = "cmdSaveReduceJs";
            this.cmdSaveReduceJs.Size = new System.Drawing.Size(82, 25);
            this.cmdSaveReduceJs.TabIndex = 4;
            this.cmdSaveReduceJs.Text = "Save";
            this.cmdSaveReduceJs.UseVisualStyleBackColor = false;
            this.cmdSaveReduceJs.Click += new System.EventHandler(this.cmdSaveReduceJs_Click);
            // 
            // cmdSaveMapJs
            // 
            this.cmdSaveMapJs.BackColor = System.Drawing.Color.Transparent;
            this.cmdSaveMapJs.Location = new System.Drawing.Point(283, 21);
            this.cmdSaveMapJs.Name = "cmdSaveMapJs";
            this.cmdSaveMapJs.Size = new System.Drawing.Size(82, 25);
            this.cmdSaveMapJs.TabIndex = 1;
            this.cmdSaveMapJs.Text = "Save";
            this.cmdSaveMapJs.UseVisualStyleBackColor = false;
            this.cmdSaveMapJs.Click += new System.EventHandler(this.cmdSaveMapJs_Click);
            // 
            // lblReduceFunction
            // 
            this.lblReduceFunction.AutoSize = true;
            this.lblReduceFunction.BackColor = System.Drawing.Color.Transparent;
            this.lblReduceFunction.Location = new System.Drawing.Point(21, 270);
            this.lblReduceFunction.Name = "lblReduceFunction";
            this.lblReduceFunction.Size = new System.Drawing.Size(65, 15);
            this.lblReduceFunction.TabIndex = 16;
            this.lblReduceFunction.Text = "Reduce Js";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Location = new System.Drawing.Point(381, 24);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(42, 15);
            this.lblResult.TabIndex = 15;
            this.lblResult.Text = "Result";
            // 
            // lblMapFunction
            // 
            this.lblMapFunction.AutoSize = true;
            this.lblMapFunction.BackColor = System.Drawing.Color.Transparent;
            this.lblMapFunction.Location = new System.Drawing.Point(21, 24);
            this.lblMapFunction.Name = "lblMapFunction";
            this.lblMapFunction.Size = new System.Drawing.Size(47, 15);
            this.lblMapFunction.TabIndex = 14;
            this.lblMapFunction.Text = "Map Js";
            // 
            // txtMapJs
            // 
            this.txtMapJs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMapJs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMapJs.Location = new System.Drawing.Point(16, 52);
            this.txtMapJs.Multiline = true;
            this.txtMapJs.Name = "txtMapJs";
            this.txtMapJs.Size = new System.Drawing.Size(348, 198);
            this.txtMapJs.TabIndex = 2;
            this.txtMapJs.Text = "function Map(){\r\n     emit(this.Age,1);\r\n     }\r\n";
            // 
            // txtReduceJs
            // 
            this.txtReduceJs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReduceJs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReduceJs.Location = new System.Drawing.Point(16, 292);
            this.txtReduceJs.Multiline = true;
            this.txtReduceJs.Name = "txtReduceJs";
            this.txtReduceJs.Size = new System.Drawing.Size(348, 194);
            this.txtReduceJs.TabIndex = 5;
            this.txtReduceJs.Text = "function Reduce(key, arr_values) {\r\n     var total = 0;\r\n     for(var i in arr_va" +
                "lues){\r\n         temp = arr_values[i];\r\n         total += temp;\r\n     }\r\n     re" +
                "turn total;\r\n     }\r\n";
            // 
            // cmdRun
            // 
            this.cmdRun.BackColor = System.Drawing.Color.Transparent;
            this.cmdRun.Location = new System.Drawing.Point(693, 494);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(103, 39);
            this.cmdRun.TabIndex = 7;
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = false;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // trvResult
            // 
            this.trvResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(172)))), ((int)(((byte)(178)))));
            this.trvResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trvResult.Location = new System.Drawing.Point(378, 53);
            this.trvResult.Name = "trvResult";
            this.trvResult.Padding = new System.Windows.Forms.Padding(1);
            this.trvResult.Size = new System.Drawing.Size(417, 432);
            this.trvResult.TabIndex = 17;
            // 
            // frmMapReduce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(807, 543);
            this.Controls.Add(this.trvResult);
            this.Controls.Add(this.cmbForMap);
            this.Controls.Add(this.cmbForReduce);
            this.Controls.Add(this.cmdSaveReduceJs);
            this.Controls.Add(this.cmdSaveMapJs);
            this.Controls.Add(this.lblReduceFunction);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblMapFunction);
            this.Controls.Add(this.txtMapJs);
            this.Controls.Add(this.txtReduceJs);
            this.Controls.Add(this.cmdRun);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
        private System.Windows.Forms.TextBox txtMapJs;
        private System.Windows.Forms.TextBox txtReduceJs;
        private System.Windows.Forms.Button cmdRun;
        private TreeViewColumnsProject.TreeViewColumns trvResult;
    }
}