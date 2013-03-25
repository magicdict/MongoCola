namespace MagicMongoDBTool
{
    partial class frmTextSearch
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
            this.trvResult = new TreeViewColumnsProject.TreeViewColumns();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trvResult
            // 
            this.trvResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(172)))), ((int)(((byte)(178)))));
            this.trvResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trvResult.Location = new System.Drawing.Point(12, 54);
            this.trvResult.Name = "trvResult";
            this.trvResult.Padding = new System.Windows.Forms.Padding(1);
            this.trvResult.Size = new System.Drawing.Size(710, 432);
            this.trvResult.TabIndex = 19;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Location = new System.Drawing.Point(12, 38);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(37, 13);
            this.lblResult.TabIndex = 18;
            this.lblResult.Text = "Result";
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(12, 9);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(62, 13);
            this.lblInput.TabIndex = 20;
            this.lblInput.Text = "SearchKey:";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(94, 9);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(443, 20);
            this.txtKey.TabIndex = 21;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(555, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmTextSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 498);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.trvResult);
            this.Controls.Add(this.lblResult);
            this.Name = "frmTextSearch";
            this.Text = "frmTextSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeViewColumnsProject.TreeViewColumns trvResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnSearch;
    }
}