using MongoGUICtl;
namespace MongoCola
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
            this.lblResult = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblLimit = new System.Windows.Forms.Label();
            this.NUDLimit = new System.Windows.Forms.NumericUpDown();
            this.trvResult = new ctlTreeViewColumns();
            this.lnkRef = new System.Windows.Forms.LinkLabel();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NUDLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Location = new System.Drawing.Point(14, 70);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(37, 13);
            this.lblResult.TabIndex = 18;
            this.lblResult.Text = "Result";
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(14, 9);
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
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(94, 35);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(137, 21);
            this.cmbLanguage.TabIndex = 23;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(14, 38);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(55, 13);
            this.lblLanguage.TabIndex = 24;
            this.lblLanguage.Text = "Language";
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(254, 38);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(28, 13);
            this.lblLimit.TabIndex = 25;
            this.lblLimit.Text = "Limit";
            // 
            // NUDLimit
            // 
            this.NUDLimit.Location = new System.Drawing.Point(303, 36);
            this.NUDLimit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUDLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDLimit.Name = "NUDLimit";
            this.NUDLimit.Size = new System.Drawing.Size(79, 20);
            this.NUDLimit.TabIndex = 26;
            this.NUDLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUDLimit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // trvResult
            // 
            this.trvResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(172)))), ((int)(((byte)(178)))));
            this.trvResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trvResult.Location = new System.Drawing.Point(12, 96);
            this.trvResult.Name = "trvResult";
            this.trvResult.Padding = new System.Windows.Forms.Padding(1);
            this.trvResult.Size = new System.Drawing.Size(710, 325);
            this.trvResult.TabIndex = 19;
            // 
            // lnkRef
            // 
            this.lnkRef.AutoSize = true;
            this.lnkRef.Location = new System.Drawing.Point(14, 435);
            this.lnkRef.Name = "lnkRef";
            this.lnkRef.Size = new System.Drawing.Size(404, 13);
            this.lnkRef.TabIndex = 27;
            this.lnkRef.TabStop = true;
            this.lnkRef.Text = "http://docs.mongodb.org/manual/reference/command/text/#text-search-languages";
            this.lnkRef.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRef_LinkClicked);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(488, 449);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(105, 27);
            this.cmdSave.TabIndex = 29;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(608, 449);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(114, 27);
            this.cmdClose.TabIndex = 28;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmTextSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 498);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.lnkRef);
            this.Controls.Add(this.NUDLimit);
            this.Controls.Add(this.lblLimit);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.trvResult);
            this.Controls.Add(this.lblResult);
            this.Name = "frmTextSearch";
            this.Text = "TextSearch";
            ((System.ComponentModel.ISupportInitialize)(this.NUDLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MongoGUICtl.ctlTreeViewColumns trvResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.NumericUpDown NUDLimit;
        private System.Windows.Forms.LinkLabel lnkRef;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdClose;
    }
}