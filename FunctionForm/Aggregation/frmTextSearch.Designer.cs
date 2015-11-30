using System.ComponentModel;
using System.Windows.Forms;
using MongoGUICtl;

namespace FunctionForm.Aggregation
{
    partial class FrmTextSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.trvResult = new MongoGUICtl.CtlTreeViewColumns();
            this.lnkRef = new System.Windows.Forms.LinkLabel();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.chkDiacriticSensitive = new System.Windows.Forms.CheckBox();
            this.chkCaseSensitive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUDLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Location = new System.Drawing.Point(14, 65);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(41, 12);
            this.lblResult.TabIndex = 18;
            this.lblResult.Text = "Result";
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(14, 8);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(65, 12);
            this.lblInput.TabIndex = 20;
            this.lblInput.Text = "SearchKey:";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(94, 8);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(443, 21);
            this.txtKey.TabIndex = 21;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(555, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 27);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Tag = "Common_Search";
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(94, 32);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(137, 20);
            this.cmbLanguage.TabIndex = 23;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(14, 35);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(53, 12);
            this.lblLanguage.TabIndex = 24;
            this.lblLanguage.Text = "Language";
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(254, 35);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(35, 12);
            this.lblLimit.TabIndex = 25;
            this.lblLimit.Text = "Limit";
            // 
            // NUDLimit
            // 
            this.NUDLimit.Location = new System.Drawing.Point(303, 33);
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
            this.NUDLimit.Size = new System.Drawing.Size(79, 21);
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
            this.trvResult.Location = new System.Drawing.Point(12, 89);
            this.trvResult.Name = "trvResult";
            this.trvResult.Padding = new System.Windows.Forms.Padding(1);
            this.trvResult.Size = new System.Drawing.Size(710, 300);
            this.trvResult.TabIndex = 19;
            // 
            // lnkRef
            // 
            this.lnkRef.AutoSize = true;
            this.lnkRef.Location = new System.Drawing.Point(14, 402);
            this.lnkRef.Name = "lnkRef";
            this.lnkRef.Size = new System.Drawing.Size(461, 12);
            this.lnkRef.TabIndex = 27;
            this.lnkRef.TabStop = true;
            this.lnkRef.Text = "http://docs.mongodb.org/manual/reference/command/text/#text-search-languages";
            this.lnkRef.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRef_LinkClicked);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(488, 412);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(105, 27);
            this.cmdSave.TabIndex = 29;
            this.cmdSave.Tag = "Common_Save";
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(608, 412);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(105, 27);
            this.cmdClose.TabIndex = 28;
            this.cmdClose.Tag = "Common_Close";
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // chkDiacriticSensitive
            // 
            this.chkDiacriticSensitive.AutoSize = true;
            this.chkDiacriticSensitive.Location = new System.Drawing.Point(208, 61);
            this.chkDiacriticSensitive.Name = "chkDiacriticSensitive";
            this.chkDiacriticSensitive.Size = new System.Drawing.Size(138, 16);
            this.chkDiacriticSensitive.TabIndex = 30;
            this.chkDiacriticSensitive.Text = "Diacritic Sensitive";
            this.chkDiacriticSensitive.UseVisualStyleBackColor = true;
            // 
            // chkCaseSensitive
            // 
            this.chkCaseSensitive.AutoSize = true;
            this.chkCaseSensitive.Location = new System.Drawing.Point(94, 61);
            this.chkCaseSensitive.Name = "chkCaseSensitive";
            this.chkCaseSensitive.Size = new System.Drawing.Size(108, 16);
            this.chkCaseSensitive.TabIndex = 31;
            this.chkCaseSensitive.Text = "Case Sensitive";
            this.chkCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // FrmTextSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 460);
            this.Controls.Add(this.chkCaseSensitive);
            this.Controls.Add(this.chkDiacriticSensitive);
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
            this.Name = "FrmTextSearch";
            this.Text = "TextSearch";
            ((System.ComponentModel.ISupportInitialize)(this.NUDLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtlTreeViewColumns trvResult;
        private Label lblResult;
        private Label lblInput;
        private TextBox txtKey;
        private Button btnSearch;
        private ComboBox cmbLanguage;
        private Label lblLanguage;
        private Label lblLimit;
        private NumericUpDown NUDLimit;
        private LinkLabel lnkRef;
        private Button cmdSave;
        private Button cmdClose;
        private CheckBox chkDiacriticSensitive;
        private CheckBox chkCaseSensitive;
    }
}