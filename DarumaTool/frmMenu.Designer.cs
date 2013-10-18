namespace DarumaTool
{
    partial class frmMenu
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSystemConfig = new System.Windows.Forms.Button();
            this.btnIDW = new System.Windows.Forms.Button();
            this.btnIDL2Source = new System.Windows.Forms.Button();
            this.btnReadFromExcel = new System.Windows.Forms.Button();
            this.btnModuleCall = new System.Windows.Forms.Button();
            this.btnGetBranch = new System.Windows.Forms.Button();
            this.btnWriteToExcel = new System.Windows.Forms.Button();
            this.btnMarcoPatten = new System.Windows.Forms.Button();
            this.btnWriteToExcelPatternList = new System.Windows.Forms.Button();
            this.btnStartUpMongoDB = new System.Windows.Forms.Button();
            this.btnLinkage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(197, 207);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(158, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSystemConfig
            // 
            this.btnSystemConfig.Enabled = false;
            this.btnSystemConfig.Location = new System.Drawing.Point(23, 207);
            this.btnSystemConfig.Name = "btnSystemConfig";
            this.btnSystemConfig.Size = new System.Drawing.Size(158, 23);
            this.btnSystemConfig.TabIndex = 1;
            this.btnSystemConfig.Text = "システム設定";
            this.btnSystemConfig.UseVisualStyleBackColor = true;
            this.btnSystemConfig.Click += new System.EventHandler(this.btnSystemConfig_Click);
            // 
            // btnIDW
            // 
            this.btnIDW.Location = new System.Drawing.Point(23, 65);
            this.btnIDW.Name = "btnIDW";
            this.btnIDW.Size = new System.Drawing.Size(158, 23);
            this.btnIDW.TabIndex = 2;
            this.btnIDW.Text = "IDW解析";
            this.btnIDW.UseVisualStyleBackColor = true;
            this.btnIDW.Click += new System.EventHandler(this.btnIDW_Click);
            // 
            // btnIDL2Source
            // 
            this.btnIDL2Source.Location = new System.Drawing.Point(23, 12);
            this.btnIDL2Source.Name = "btnIDL2Source";
            this.btnIDL2Source.Size = new System.Drawing.Size(158, 23);
            this.btnIDL2Source.TabIndex = 3;
            this.btnIDL2Source.Text = "IDL2ソース一覧作成";
            this.btnIDL2Source.UseVisualStyleBackColor = true;
            this.btnIDL2Source.Click += new System.EventHandler(this.btnIDL2Source_Click);
            // 
            // btnReadFromExcel
            // 
            this.btnReadFromExcel.Location = new System.Drawing.Point(23, 104);
            this.btnReadFromExcel.Name = "btnReadFromExcel";
            this.btnReadFromExcel.Size = new System.Drawing.Size(158, 23);
            this.btnReadFromExcel.TabIndex = 4;
            this.btnReadFromExcel.Text = "Excelから情報読み込む";
            this.btnReadFromExcel.UseVisualStyleBackColor = true;
            this.btnReadFromExcel.Click += new System.EventHandler(this.btnReadFromExcel_Click);
            // 
            // btnModuleCall
            // 
            this.btnModuleCall.Location = new System.Drawing.Point(197, 12);
            this.btnModuleCall.Name = "btnModuleCall";
            this.btnModuleCall.Size = new System.Drawing.Size(158, 23);
            this.btnModuleCall.TabIndex = 5;
            this.btnModuleCall.Text = "モジュール呼び出す整理";
            this.btnModuleCall.UseVisualStyleBackColor = true;
            this.btnModuleCall.Click += new System.EventHandler(this.btnModuleCall_Click);
            // 
            // btnGetBranch
            // 
            this.btnGetBranch.Location = new System.Drawing.Point(197, 65);
            this.btnGetBranch.Name = "btnGetBranch";
            this.btnGetBranch.Size = new System.Drawing.Size(158, 23);
            this.btnGetBranch.TabIndex = 6;
            this.btnGetBranch.Text = "分岐点の解析";
            this.btnGetBranch.UseVisualStyleBackColor = true;
            this.btnGetBranch.Click += new System.EventHandler(this.btnGetBranch_Click);
            // 
            // btnWriteToExcel
            // 
            this.btnWriteToExcel.Location = new System.Drawing.Point(197, 104);
            this.btnWriteToExcel.Name = "btnWriteToExcel";
            this.btnWriteToExcel.Size = new System.Drawing.Size(158, 23);
            this.btnWriteToExcel.TabIndex = 7;
            this.btnWriteToExcel.Text = "Excelに書き込む";
            this.btnWriteToExcel.UseVisualStyleBackColor = true;
            this.btnWriteToExcel.Click += new System.EventHandler(this.btnWriteToExcel_Click);
            // 
            // btnMarcoPatten
            // 
            this.btnMarcoPatten.Location = new System.Drawing.Point(23, 41);
            this.btnMarcoPatten.Name = "btnMarcoPatten";
            this.btnMarcoPatten.Size = new System.Drawing.Size(158, 23);
            this.btnMarcoPatten.TabIndex = 8;
            this.btnMarcoPatten.Text = "マクロパターン整理";
            this.btnMarcoPatten.UseVisualStyleBackColor = true;
            this.btnMarcoPatten.Click += new System.EventHandler(this.btnMarcoPatten_Click);
            // 
            // btnWriteToExcelPatternList
            // 
            this.btnWriteToExcelPatternList.Location = new System.Drawing.Point(23, 133);
            this.btnWriteToExcelPatternList.Name = "btnWriteToExcelPatternList";
            this.btnWriteToExcelPatternList.Size = new System.Drawing.Size(158, 23);
            this.btnWriteToExcelPatternList.TabIndex = 9;
            this.btnWriteToExcelPatternList.Text = "Excelに書き込む(パターンリスト)";
            this.btnWriteToExcelPatternList.UseVisualStyleBackColor = true;
            this.btnWriteToExcelPatternList.Click += new System.EventHandler(this.btnWriteToExcelPatternList_Click);
            // 
            // btnStartUpMongoDB
            // 
            this.btnStartUpMongoDB.Location = new System.Drawing.Point(23, 178);
            this.btnStartUpMongoDB.Name = "btnStartUpMongoDB";
            this.btnStartUpMongoDB.Size = new System.Drawing.Size(158, 23);
            this.btnStartUpMongoDB.TabIndex = 10;
            this.btnStartUpMongoDB.Text = "MongoDB起動";
            this.btnStartUpMongoDB.UseVisualStyleBackColor = true;
            this.btnStartUpMongoDB.Click += new System.EventHandler(this.btnStartUpMongoDB_Click);
            // 
            // btnLinkage
            // 
            this.btnLinkage.Location = new System.Drawing.Point(197, 41);
            this.btnLinkage.Name = "btnLinkage";
            this.btnLinkage.Size = new System.Drawing.Size(158, 23);
            this.btnLinkage.TabIndex = 11;
            this.btnLinkage.Text = "Linkage抽出";
            this.btnLinkage.UseVisualStyleBackColor = true;
            this.btnLinkage.Click += new System.EventHandler(this.btnLinkage_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(381, 238);
            this.Controls.Add(this.btnLinkage);
            this.Controls.Add(this.btnStartUpMongoDB);
            this.Controls.Add(this.btnWriteToExcelPatternList);
            this.Controls.Add(this.btnMarcoPatten);
            this.Controls.Add(this.btnWriteToExcel);
            this.Controls.Add(this.btnGetBranch);
            this.Controls.Add(this.btnModuleCall);
            this.Controls.Add(this.btnReadFromExcel);
            this.Controls.Add(this.btnIDL2Source);
            this.Controls.Add(this.btnIDW);
            this.Controls.Add(this.btnSystemConfig);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMenu";
            this.Text = "メニュー";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSystemConfig;
        private System.Windows.Forms.Button btnIDW;
        private System.Windows.Forms.Button btnIDL2Source;
        private System.Windows.Forms.Button btnReadFromExcel;
        private System.Windows.Forms.Button btnModuleCall;
        private System.Windows.Forms.Button btnGetBranch;
        private System.Windows.Forms.Button btnWriteToExcel;
        private System.Windows.Forms.Button btnMarcoPatten;
        private System.Windows.Forms.Button btnWriteToExcelPatternList;
        private System.Windows.Forms.Button btnStartUpMongoDB;
        private System.Windows.Forms.Button btnLinkage;
    }
}

