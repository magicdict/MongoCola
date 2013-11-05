namespace DarumaUTGenerator
{
    partial class MacroAnalyze
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
            this.lblIDL2File = new System.Windows.Forms.Label();
            this.btnSourcePick = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.lstParm = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSpeces = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstBranch = new System.Windows.Forms.ListView();
            this.colSyntax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNestLv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLineNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCondition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.lstKeySet = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lblIDL2File
            // 
            this.lblIDL2File.AutoSize = true;
            this.lblIDL2File.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDL2File.Location = new System.Drawing.Point(296, 22);
            this.lblIDL2File.Name = "lblIDL2File";
            this.lblIDL2File.Size = new System.Drawing.Size(107, 13);
            this.lblIDL2File.TabIndex = 5;
            this.lblIDL2File.Text = "ＩＤＬソース：未選択";
            // 
            // btnSourcePick
            // 
            this.btnSourcePick.Location = new System.Drawing.Point(12, 17);
            this.btnSourcePick.Name = "btnSourcePick";
            this.btnSourcePick.Size = new System.Drawing.Size(241, 23);
            this.btnSourcePick.TabIndex = 4;
            this.btnSourcePick.Text = "ソースを選ぶ…";
            this.btnSourcePick.UseVisualStyleBackColor = true;
            this.btnSourcePick.Click += new System.EventHandler(this.btnSourcePick_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 46);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(241, 23);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "パラメータ分析";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lstParm
            // 
            this.lstParm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colType,
            this.colSpeces});
            this.lstParm.FullRowSelect = true;
            this.lstParm.GridLines = true;
            this.lstParm.Location = new System.Drawing.Point(290, 46);
            this.lstParm.Name = "lstParm";
            this.lstParm.Size = new System.Drawing.Size(241, 169);
            this.lstParm.TabIndex = 7;
            this.lstParm.UseCompatibleStateImageBehavior = false;
            this.lstParm.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "名称";
            // 
            // colType
            // 
            this.colType.Text = "種類";
            // 
            // colSpeces
            // 
            this.colSpeces.Text = "属性";
            // 
            // lstBranch
            // 
            this.lstBranch.CheckBoxes = true;
            this.lstBranch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSyntax,
            this.colNestLv,
            this.colLineNo,
            this.colCondition});
            this.lstBranch.FullRowSelect = true;
            this.lstBranch.GridLines = true;
            this.lstBranch.Location = new System.Drawing.Point(29, 237);
            this.lstBranch.Name = "lstBranch";
            this.lstBranch.Size = new System.Drawing.Size(979, 106);
            this.lstBranch.TabIndex = 8;
            this.lstBranch.UseCompatibleStateImageBehavior = false;
            this.lstBranch.View = System.Windows.Forms.View.Details;
            // 
            // colSyntax
            // 
            this.colSyntax.Text = "種類";
            // 
            // colNestLv
            // 
            this.colNestLv.Text = "ネスト";
            // 
            // colLineNo
            // 
            this.colLineNo.Text = "行番号";
            // 
            // colCondition
            // 
            this.colCondition.Text = "条件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "テスト対象外の制御分岐をチェックしてください";
            // 
            // lstKeySet
            // 
            this.lstKeySet.FullRowSelect = true;
            this.lstKeySet.GridLines = true;
            this.lstKeySet.Location = new System.Drawing.Point(29, 365);
            this.lstKeySet.Name = "lstKeySet";
            this.lstKeySet.Size = new System.Drawing.Size(979, 131);
            this.lstKeySet.TabIndex = 11;
            this.lstKeySet.UseCompatibleStateImageBehavior = false;
            this.lstKeySet.View = System.Windows.Forms.View.Details;
            // 
            // MacroAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 508);
            this.Controls.Add(this.lstKeySet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstBranch);
            this.Controls.Add(this.lstParm);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lblIDL2File);
            this.Controls.Add(this.btnSourcePick);
            this.Name = "MacroAnalyze";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MacroAnalyze";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIDL2File;
        private System.Windows.Forms.Button btnSourcePick;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ListView lstParm;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colSpeces;
        private System.Windows.Forms.ListView lstBranch;
        private System.Windows.Forms.ColumnHeader colSyntax;
        private System.Windows.Forms.ColumnHeader colNestLv;
        private System.Windows.Forms.ColumnHeader colLineNo;
        private System.Windows.Forms.ColumnHeader colCondition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstKeySet;
    }
}