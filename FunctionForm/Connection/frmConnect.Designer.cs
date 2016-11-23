using System.ComponentModel;
using System.Windows.Forms;

namespace FunctionForm.Connection
{
    partial class frmConnect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnect));
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lstConnection = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReplsetMember = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdAddCon = new System.Windows.Forms.ToolStripButton();
            this.cmdModifyCon = new System.Windows.Forms.ToolStripButton();
            this.cmdDelCon = new System.Windows.Forms.ToolStripButton();
            this.cmdToUrlString = new System.Windows.Forms.ToolStripButton();
            this.cmdFromUriString = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.Transparent;
            this.cmdClose.Location = new System.Drawing.Point(295, 332);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(90, 36);
            this.cmdClose.TabIndex = 7;
            this.cmdClose.Tag = "Common.Close";
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = false;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(153, 332);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(90, 36);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Tag = "Common.OK";
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // lstConnection
            // 
            this.lstConnection.CheckBoxes = true;
            this.lstConnection.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colHost,
            this.colPort,
            this.colReplsetMember,
            this.colUser});
            this.lstConnection.FullRowSelect = true;
            this.lstConnection.GridLines = true;
            this.lstConnection.Location = new System.Drawing.Point(0, 28);
            this.lstConnection.Name = "lstConnection";
            this.lstConnection.Size = new System.Drawing.Size(549, 287);
            this.lstConnection.TabIndex = 11;
            this.lstConnection.UseCompatibleStateImageBehavior = false;
            this.lstConnection.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Tag = "Common.Name";
            this.colName.Text = "Name";
            this.colName.Width = 79;
            // 
            // colHost
            // 
            this.colHost.Tag = "Common.Host";
            this.colHost.Text = "Host";
            this.colHost.Width = 132;
            // 
            // colPort
            // 
            this.colPort.Tag = "Common.Port";
            this.colPort.Text = "Port";
            this.colPort.Width = 93;
            // 
            // colReplsetMember
            // 
            this.colReplsetMember.Tag = "Common.ReplsetMember";
            this.colReplsetMember.Text = "ReplsetMember";
            this.colReplsetMember.Width = 100;
            // 
            // colUser
            // 
            this.colUser.Tag = "Common.User";
            this.colUser.Text = "User";
            this.colUser.Width = 71;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdAddCon,
            this.cmdModifyCon,
            this.cmdDelCon,
            this.cmdToUrlString,
            this.cmdFromUriString});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(549, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmdAddCon
            // 
            this.cmdAddCon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdAddCon.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddCon.Image")));
            this.cmdAddCon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdAddCon.Name = "cmdAddCon";
            this.cmdAddCon.Size = new System.Drawing.Size(23, 22);
            this.cmdAddCon.Tag = "Common.Add";
            this.cmdAddCon.Text = "New";
            this.cmdAddCon.Click += new System.EventHandler(this.cmdAddCon_Click);
            // 
            // cmdModifyCon
            // 
            this.cmdModifyCon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdModifyCon.Image = ((System.Drawing.Image)(resources.GetObject("cmdModifyCon.Image")));
            this.cmdModifyCon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdModifyCon.Name = "cmdModifyCon";
            this.cmdModifyCon.Size = new System.Drawing.Size(23, 22);
            this.cmdModifyCon.Tag = "Common.Modify";
            this.cmdModifyCon.Text = "Modify";
            this.cmdModifyCon.Click += new System.EventHandler(this.cmdModifyCon_Click);
            // 
            // cmdDelCon
            // 
            this.cmdDelCon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdDelCon.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelCon.Image")));
            this.cmdDelCon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDelCon.Name = "cmdDelCon";
            this.cmdDelCon.Size = new System.Drawing.Size(23, 22);
            this.cmdDelCon.Tag = "Connect_Action_Del";
            this.cmdDelCon.Text = "Drop";
            this.cmdDelCon.Click += new System.EventHandler(this.cmdDelCon_Click);
            // 
            // cmdToUrlString
            // 
            this.cmdToUrlString.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdToUrlString.Image = ((System.Drawing.Image)(resources.GetObject("cmdToUrlString.Image")));
            this.cmdToUrlString.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdToUrlString.Name = "cmdToUrlString";
            this.cmdToUrlString.Size = new System.Drawing.Size(23, 22);
            this.cmdToUrlString.Text = "ToUri";
            this.cmdToUrlString.Click += new System.EventHandler(this.cmdToUrlString_Click);
            // 
            // cmdFromUriString
            // 
            this.cmdFromUriString.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdFromUriString.Image = ((System.Drawing.Image)(resources.GetObject("cmdFromUriString.Image")));
            this.cmdFromUriString.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdFromUriString.Name = "cmdFromUriString";
            this.cmdFromUriString.Size = new System.Drawing.Size(23, 22);
            this.cmdFromUriString.Text = "FromUri";
            this.cmdFromUriString.Click += new System.EventHandler(this.cmdFromUriString_Click);
            // 
            // frmConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(549, 380);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lstConnection);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Connect_Title";
            this.Text = "Server Connection";
            this.Load += new System.EventHandler(this.frmConnect_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button cmdClose;
        private Button cmdOK;
        private ListView lstConnection;
        private ColumnHeader colName;
        private ColumnHeader colHost;
        private ColumnHeader colPort;
        private ColumnHeader colUser;
        private ColumnHeader colReplsetMember;
        private ToolStrip toolStrip1;
        private ToolStripButton cmdAddCon;
        private ToolStripButton cmdModifyCon;
        private ToolStripButton cmdDelCon;
        private ToolStripButton cmdToUrlString;
        private ToolStripButton cmdFromUriString;
    }
}