namespace MagicMongoDBTool
{
    partial class frmConnect
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
            this.cmdModifyCon = new System.Windows.Forms.Button();
            this.cmdDelCon = new System.Windows.Forms.Button();
            this.cmdAddCon = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lstConnection = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // cmdModifyCon
            // 
            this.cmdModifyCon.BackColor = System.Drawing.Color.Transparent;
            this.cmdModifyCon.Location = new System.Drawing.Point(478, 321);
            this.cmdModifyCon.Name = "cmdModifyCon";
            this.cmdModifyCon.Size = new System.Drawing.Size(90, 36);
            this.cmdModifyCon.TabIndex = 9;
            this.cmdModifyCon.Text = "Modify";
            this.cmdModifyCon.UseVisualStyleBackColor = false;
            this.cmdModifyCon.Click += new System.EventHandler(this.cmdModifyCon_Click);
            // 
            // cmdDelCon
            // 
            this.cmdDelCon.BackColor = System.Drawing.Color.Transparent;
            this.cmdDelCon.Location = new System.Drawing.Point(574, 321);
            this.cmdDelCon.Name = "cmdDelCon";
            this.cmdDelCon.Size = new System.Drawing.Size(90, 36);
            this.cmdDelCon.TabIndex = 10;
            this.cmdDelCon.Text = "Drop";
            this.cmdDelCon.UseVisualStyleBackColor = false;
            this.cmdDelCon.Click += new System.EventHandler(this.cmdDelCon_Click);
            // 
            // cmdAddCon
            // 
            this.cmdAddCon.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddCon.Location = new System.Drawing.Point(382, 321);
            this.cmdAddCon.Name = "cmdAddCon";
            this.cmdAddCon.Size = new System.Drawing.Size(90, 36);
            this.cmdAddCon.TabIndex = 8;
            this.cmdAddCon.Text = "New";
            this.cmdAddCon.UseVisualStyleBackColor = false;
            this.cmdAddCon.Click += new System.EventHandler(this.cmdAddCon_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.Location = new System.Drawing.Point(190, 321);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(90, 36);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(72, 321);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(90, 36);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // lstConnection
            // 
            this.lstConnection.CheckBoxes = true;
            this.lstConnection.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colIP,
            this.colPort,
            this.colUser});
            this.lstConnection.FullRowSelect = true;
            this.lstConnection.GridLines = true;
            this.lstConnection.Location = new System.Drawing.Point(12, 12);
            this.lstConnection.Name = "lstConnection";
            this.lstConnection.Size = new System.Drawing.Size(678, 303);
            this.lstConnection.TabIndex = 11;
            this.lstConnection.UseCompatibleStateImageBehavior = false;
            this.lstConnection.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 79;
            // 
            // colIP
            // 
            this.colIP.Text = "IP";
            this.colIP.Width = 132;
            // 
            // colPort
            // 
            this.colPort.Text = "Port";
            this.colPort.Width = 93;
            // 
            // colUser
            // 
            this.colUser.Text = "User";
            this.colUser.Width = 92;
            // 
            // frmConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(714, 380);
            this.Controls.Add(this.lstConnection);
            this.Controls.Add(this.cmdModifyCon);
            this.Controls.Add(this.cmdDelCon);
            this.Controls.Add(this.cmdAddCon);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Server Connection";
            this.Load += new System.EventHandler(this.frmConnect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdModifyCon;
        private System.Windows.Forms.Button cmdDelCon;
        private System.Windows.Forms.Button cmdAddCon;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.ListView lstConnection;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colIP;
        private System.Windows.Forms.ColumnHeader colPort;
        private System.Windows.Forms.ColumnHeader colUser;
    }
}