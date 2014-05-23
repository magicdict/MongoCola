namespace 炉边传说
{
    partial class BattleField
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.lstHandCard = new System.Windows.Forms.ListBox();
            this.lblSelectedHandCardInfo = new System.Windows.Forms.Label();
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.lblEnemyBattle = new System.Windows.Forms.Label();
            this.btnUseHandCard = new System.Windows.Forms.Button();
            this.lstAction = new System.Windows.Forms.ListBox();
            this.lstMyMinion = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(61, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "战场信息：";
            // 
            // lstHandCard
            // 
            this.lstHandCard.FormattingEnabled = true;
            this.lstHandCard.Location = new System.Drawing.Point(407, 91);
            this.lstHandCard.Name = "lstHandCard";
            this.lstHandCard.Size = new System.Drawing.Size(120, 303);
            this.lstHandCard.TabIndex = 1;
            this.lstHandCard.SelectedIndexChanged += new System.EventHandler(this.lstHandCard_SelectedIndexChanged);
            // 
            // lblSelectedHandCardInfo
            // 
            this.lblSelectedHandCardInfo.AutoSize = true;
            this.lblSelectedHandCardInfo.Location = new System.Drawing.Point(548, 91);
            this.lblSelectedHandCardInfo.Name = "lblSelectedHandCardInfo";
            this.lblSelectedHandCardInfo.Size = new System.Drawing.Size(79, 13);
            this.lblSelectedHandCardInfo.TabIndex = 2;
            this.lblSelectedHandCardInfo.Text = "当前选择手牌";
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.Location = new System.Drawing.Point(871, 81);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(75, 23);
            this.btnEndTurn.TabIndex = 3;
            this.btnEndTurn.Text = "结束回合";
            this.btnEndTurn.UseVisualStyleBackColor = true;
            this.btnEndTurn.Click += new System.EventHandler(this.btnEndTurn_Click);
            // 
            // lblEnemyBattle
            // 
            this.lblEnemyBattle.AutoSize = true;
            this.lblEnemyBattle.Location = new System.Drawing.Point(293, 9);
            this.lblEnemyBattle.Name = "lblEnemyBattle";
            this.lblEnemyBattle.Size = new System.Drawing.Size(55, 13);
            this.lblEnemyBattle.TabIndex = 4;
            this.lblEnemyBattle.Text = "回合指示";
            // 
            // btnUseHandCard
            // 
            this.btnUseHandCard.Location = new System.Drawing.Point(780, 81);
            this.btnUseHandCard.Name = "btnUseHandCard";
            this.btnUseHandCard.Size = new System.Drawing.Size(75, 23);
            this.btnUseHandCard.TabIndex = 5;
            this.btnUseHandCard.Text = "使用手牌";
            this.btnUseHandCard.UseVisualStyleBackColor = true;
            this.btnUseHandCard.Click += new System.EventHandler(this.btnUseHandCard_Click);
            // 
            // lstAction
            // 
            this.lstAction.FormattingEnabled = true;
            this.lstAction.Location = new System.Drawing.Point(551, 182);
            this.lstAction.Name = "lstAction";
            this.lstAction.Size = new System.Drawing.Size(408, 173);
            this.lstAction.TabIndex = 7;
            // 
            // lstMyMinion
            // 
            this.lstMyMinion.FormattingEnabled = true;
            this.lstMyMinion.Location = new System.Drawing.Point(244, 91);
            this.lstMyMinion.Name = "lstMyMinion";
            this.lstMyMinion.Size = new System.Drawing.Size(120, 303);
            this.lstMyMinion.TabIndex = 8;
            // 
            // BattleField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(971, 502);
            this.Controls.Add(this.lstMyMinion);
            this.Controls.Add(this.lstAction);
            this.Controls.Add(this.btnUseHandCard);
            this.Controls.Add(this.lblEnemyBattle);
            this.Controls.Add(this.btnEndTurn);
            this.Controls.Add(this.lblSelectedHandCardInfo);
            this.Controls.Add(this.lstHandCard);
            this.Controls.Add(this.lblStatus);
            this.Name = "BattleField";
            this.Text = "战场";
            this.Load += new System.EventHandler(this.BattleField_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lstHandCard;
        private System.Windows.Forms.Label lblSelectedHandCardInfo;
        private System.Windows.Forms.Button btnEndTurn;
        private System.Windows.Forms.Label lblEnemyBattle;
        private System.Windows.Forms.Button btnUseHandCard;
        private System.Windows.Forms.ListBox lstAction;
        private System.Windows.Forms.ListBox lstMyMinion;

    }
}