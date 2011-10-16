namespace MagicMongoDBTool
{
    partial class frmQuery
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
            this.lstColumn = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsShow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCondition1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCondition2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCondition3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCondition4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCondition5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkIsShow = new System.Windows.Forms.CheckBox();
            this.lblSelectColName = new System.Windows.Forms.Label();
            this.ctlQueryCondition1 = new MagicMongoDBTool.ctlQueryCondition();
            this.ctlQueryCondition2 = new MagicMongoDBTool.ctlQueryCondition();
            this.ctlQueryCondition3 = new MagicMongoDBTool.ctlQueryCondition();
            this.ctlQueryCondition4 = new MagicMongoDBTool.ctlQueryCondition();
            this.ctlQueryCondition5 = new MagicMongoDBTool.ctlQueryCondition();
            this.grpField = new System.Windows.Forms.GroupBox();
            this.cmdSaveItem = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.grpField.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstColumn
            // 
            this.lstColumn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colIsShow,
            this.colSort,
            this.colCondition1,
            this.colCondition2,
            this.colCondition3,
            this.colCondition4,
            this.colCondition5});
            this.lstColumn.HideSelection = false;
            this.lstColumn.Location = new System.Drawing.Point(26, 23);
            this.lstColumn.Name = "lstColumn";
            this.lstColumn.Size = new System.Drawing.Size(688, 235);
            this.lstColumn.TabIndex = 0;
            this.lstColumn.UseCompatibleStateImageBehavior = false;
            this.lstColumn.View = System.Windows.Forms.View.Details;
            this.lstColumn.SelectedIndexChanged += new System.EventHandler(this.lstColumn_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "字段名称";
            this.colName.Width = 73;
            // 
            // colIsShow
            // 
            this.colIsShow.Text = "是否表示";
            this.colIsShow.Width = 78;
            // 
            // colSort
            // 
            this.colSort.Text = "排序";
            this.colSort.Width = 65;
            // 
            // colCondition1
            // 
            this.colCondition1.Text = "条件1";
            this.colCondition1.Width = 111;
            // 
            // colCondition2
            // 
            this.colCondition2.Text = "条件2";
            this.colCondition2.Width = 104;
            // 
            // colCondition3
            // 
            this.colCondition3.Text = "条件3";
            this.colCondition3.Width = 101;
            // 
            // colCondition4
            // 
            this.colCondition4.Text = "条件4";
            this.colCondition4.Width = 88;
            // 
            // colCondition5
            // 
            this.colCondition5.Text = "条件5";
            // 
            // chkIsShow
            // 
            this.chkIsShow.AutoSize = true;
            this.chkIsShow.Location = new System.Drawing.Point(252, 20);
            this.chkIsShow.Name = "chkIsShow";
            this.chkIsShow.Size = new System.Drawing.Size(86, 17);
            this.chkIsShow.TabIndex = 3;
            this.chkIsShow.Text = "显示该字段";
            this.chkIsShow.UseVisualStyleBackColor = true;
            // 
            // lblSelectColName
            // 
            this.lblSelectColName.AutoSize = true;
            this.lblSelectColName.Location = new System.Drawing.Point(20, 21);
            this.lblSelectColName.Name = "lblSelectColName";
            this.lblSelectColName.Size = new System.Drawing.Size(37, 13);
            this.lblSelectColName.TabIndex = 4;
            this.lblSelectColName.Text = "字段：";
            // 
            // ctlQueryCondition1
            // 
            this.ctlQueryCondition1.Location = new System.Drawing.Point(6, 40);
            this.ctlQueryCondition1.Name = "ctlQueryCondition1";
            this.ctlQueryCondition1.Size = new System.Drawing.Size(678, 30);
            this.ctlQueryCondition1.TabIndex = 5;
            // 
            // ctlQueryCondition2
            // 
            this.ctlQueryCondition2.Location = new System.Drawing.Point(6, 76);
            this.ctlQueryCondition2.Name = "ctlQueryCondition2";
            this.ctlQueryCondition2.Size = new System.Drawing.Size(678, 30);
            this.ctlQueryCondition2.TabIndex = 5;
            // 
            // ctlQueryCondition3
            // 
            this.ctlQueryCondition3.Location = new System.Drawing.Point(6, 112);
            this.ctlQueryCondition3.Name = "ctlQueryCondition3";
            this.ctlQueryCondition3.Size = new System.Drawing.Size(678, 30);
            this.ctlQueryCondition3.TabIndex = 5;
            // 
            // ctlQueryCondition4
            // 
            this.ctlQueryCondition4.Location = new System.Drawing.Point(6, 148);
            this.ctlQueryCondition4.Name = "ctlQueryCondition4";
            this.ctlQueryCondition4.Size = new System.Drawing.Size(678, 30);
            this.ctlQueryCondition4.TabIndex = 5;
            // 
            // ctlQueryCondition5
            // 
            this.ctlQueryCondition5.Location = new System.Drawing.Point(6, 184);
            this.ctlQueryCondition5.Name = "ctlQueryCondition5";
            this.ctlQueryCondition5.Size = new System.Drawing.Size(678, 30);
            this.ctlQueryCondition5.TabIndex = 5;
            // 
            // grpField
            // 
            this.grpField.Controls.Add(this.cmdSaveItem);
            this.grpField.Controls.Add(this.ctlQueryCondition1);
            this.grpField.Controls.Add(this.ctlQueryCondition5);
            this.grpField.Controls.Add(this.chkIsShow);
            this.grpField.Controls.Add(this.ctlQueryCondition4);
            this.grpField.Controls.Add(this.lblSelectColName);
            this.grpField.Controls.Add(this.ctlQueryCondition3);
            this.grpField.Controls.Add(this.ctlQueryCondition2);
            this.grpField.Location = new System.Drawing.Point(26, 264);
            this.grpField.Name = "grpField";
            this.grpField.Size = new System.Drawing.Size(688, 224);
            this.grpField.TabIndex = 6;
            this.grpField.TabStop = false;
            this.grpField.Text = "字段过滤";
            // 
            // cmdSaveItem
            // 
            this.cmdSaveItem.Location = new System.Drawing.Point(561, 11);
            this.cmdSaveItem.Name = "cmdSaveItem";
            this.cmdSaveItem.Size = new System.Drawing.Size(108, 23);
            this.cmdSaveItem.TabIndex = 7;
            this.cmdSaveItem.Text = "更新当前字段";
            this.cmdSaveItem.UseVisualStyleBackColor = true;
            this.cmdSaveItem.Click += new System.EventHandler(this.cmdSaveItem_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(587, 514);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(108, 23);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "确定";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 549);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.grpField);
            this.Controls.Add(this.lstColumn);
            this.Name = "frmQuery";
            this.Text = "frmQuery";
            this.Load += new System.EventHandler(this.frmQuery_Load);
            this.grpField.ResumeLayout(false);
            this.grpField.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstColumn;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colIsShow;
        private System.Windows.Forms.ColumnHeader colSort;
        private System.Windows.Forms.ColumnHeader colCondition1;
        private System.Windows.Forms.ColumnHeader colCondition2;
        private System.Windows.Forms.ColumnHeader colCondition3;
        private System.Windows.Forms.ColumnHeader colCondition4;
        private System.Windows.Forms.ColumnHeader colCondition5;
        private System.Windows.Forms.CheckBox chkIsShow;
        private System.Windows.Forms.Label lblSelectColName;
        private ctlQueryCondition ctlQueryCondition1;
        private ctlQueryCondition ctlQueryCondition2;
        private ctlQueryCondition ctlQueryCondition3;
        private ctlQueryCondition ctlQueryCondition4;
        private ctlQueryCondition ctlQueryCondition5;
        private System.Windows.Forms.GroupBox grpField;
        private System.Windows.Forms.Button cmdSaveItem;
        private System.Windows.Forms.Button cmdOK;

    }
}