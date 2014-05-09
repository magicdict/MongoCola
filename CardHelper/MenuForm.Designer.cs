namespace CardHelper
{
    partial class MenuForm
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
            this.btnCardDeck = new System.Windows.Forms.Button();
            this.btnRunMagic = new System.Windows.Forms.Button();
            this.btnGameFlow = new System.Windows.Forms.Button();
            this.btnExcelImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCardDeck
            // 
            this.btnCardDeck.Location = new System.Drawing.Point(39, 31);
            this.btnCardDeck.Name = "btnCardDeck";
            this.btnCardDeck.Size = new System.Drawing.Size(147, 23);
            this.btnCardDeck.TabIndex = 0;
            this.btnCardDeck.Text = "牌堆测试";
            this.btnCardDeck.UseVisualStyleBackColor = true;
            this.btnCardDeck.Click += new System.EventHandler(this.btnCardDeck_Click);
            // 
            // btnRunMagic
            // 
            this.btnRunMagic.Location = new System.Drawing.Point(40, 60);
            this.btnRunMagic.Name = "btnRunMagic";
            this.btnRunMagic.Size = new System.Drawing.Size(147, 23);
            this.btnRunMagic.TabIndex = 1;
            this.btnRunMagic.Text = "魔法测试";
            this.btnRunMagic.UseVisualStyleBackColor = true;
            this.btnRunMagic.Click += new System.EventHandler(this.btnRunMagic_Click);
            // 
            // btnGameFlow
            // 
            this.btnGameFlow.Location = new System.Drawing.Point(40, 89);
            this.btnGameFlow.Name = "btnGameFlow";
            this.btnGameFlow.Size = new System.Drawing.Size(147, 23);
            this.btnGameFlow.TabIndex = 2;
            this.btnGameFlow.Text = "游戏流程";
            this.btnGameFlow.UseVisualStyleBackColor = true;
            this.btnGameFlow.Click += new System.EventHandler(this.btnGameFlow_Click);
            // 
            // btnExcelImport
            // 
            this.btnExcelImport.Location = new System.Drawing.Point(39, 184);
            this.btnExcelImport.Name = "btnExcelImport";
            this.btnExcelImport.Size = new System.Drawing.Size(147, 23);
            this.btnExcelImport.TabIndex = 3;
            this.btnExcelImport.Text = "Excel 转数据库";
            this.btnExcelImport.UseVisualStyleBackColor = true;
            this.btnExcelImport.Click += new System.EventHandler(this.btnExcelImport_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(227, 233);
            this.Controls.Add(this.btnExcelImport);
            this.Controls.Add(this.btnGameFlow);
            this.Controls.Add(this.btnRunMagic);
            this.Controls.Add(this.btnCardDeck);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "菜单";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCardDeck;
        private System.Windows.Forms.Button btnRunMagic;
        private System.Windows.Forms.Button btnGameFlow;
        private System.Windows.Forms.Button btnExcelImport;
    }
}