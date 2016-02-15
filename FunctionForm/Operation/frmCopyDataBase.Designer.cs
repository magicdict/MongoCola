namespace FunctionForm.Operation
{
    partial class FrmCopyDataBase
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
            this.gbSelectCollections = new System.Windows.Forms.GroupBox();
            this.treeViewCollection = new System.Windows.Forms.TreeView();
            this.gbSelectDestination = new System.Windows.Forms.GroupBox();
            this.chkCopyIndexes = new System.Windows.Forms.CheckBox();
            this.comboBoxDataBase = new System.Windows.Forms.ComboBox();
            this.lblSelectDataBase = new System.Windows.Forms.Label();
            this.comboBoxServer = new System.Windows.Forms.ComboBox();
            this.lblSelectServer = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gbSelectCollections.SuspendLayout();
            this.gbSelectDestination.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSelectCollections
            // 
            this.gbSelectCollections.Controls.Add(this.treeViewCollection);
            this.gbSelectCollections.Location = new System.Drawing.Point(17, 17);
            this.gbSelectCollections.Name = "gbSelectCollections";
            this.gbSelectCollections.Size = new System.Drawing.Size(200, 269);
            this.gbSelectCollections.TabIndex = 0;
            this.gbSelectCollections.TabStop = false;
            this.gbSelectCollections.Text = "Select Collections";
            // 
            // treeViewCollection
            // 
            this.treeViewCollection.CheckBoxes = true;
            this.treeViewCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCollection.Location = new System.Drawing.Point(3, 17);
            this.treeViewCollection.Name = "treeViewCollection";
            this.treeViewCollection.Size = new System.Drawing.Size(194, 249);
            this.treeViewCollection.TabIndex = 8;
            this.treeViewCollection.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCollection_AfterCheck);
            // 
            // gbSelectDestination
            // 
            this.gbSelectDestination.Controls.Add(this.chkCopyIndexes);
            this.gbSelectDestination.Controls.Add(this.comboBoxDataBase);
            this.gbSelectDestination.Controls.Add(this.lblSelectDataBase);
            this.gbSelectDestination.Controls.Add(this.comboBoxServer);
            this.gbSelectDestination.Controls.Add(this.lblSelectServer);
            this.gbSelectDestination.Location = new System.Drawing.Point(223, 17);
            this.gbSelectDestination.Name = "gbSelectDestination";
            this.gbSelectDestination.Size = new System.Drawing.Size(200, 269);
            this.gbSelectDestination.TabIndex = 1;
            this.gbSelectDestination.TabStop = false;
            this.gbSelectDestination.Text = "Select Destination";
            // 
            // chkCopyIndexes
            // 
            this.chkCopyIndexes.AutoSize = true;
            this.chkCopyIndexes.Location = new System.Drawing.Point(9, 181);
            this.chkCopyIndexes.Name = "chkCopyIndexes";
            this.chkCopyIndexes.Size = new System.Drawing.Size(96, 19);
            this.chkCopyIndexes.TabIndex = 4;
            this.chkCopyIndexes.Text = "CopyIndexes";
            this.chkCopyIndexes.UseVisualStyleBackColor = true;
            // 
            // comboBoxDataBase
            // 
            this.comboBoxDataBase.FormattingEnabled = true;
            this.comboBoxDataBase.Location = new System.Drawing.Point(6, 132);
            this.comboBoxDataBase.Name = "comboBoxDataBase";
            this.comboBoxDataBase.Size = new System.Drawing.Size(188, 23);
            this.comboBoxDataBase.TabIndex = 3;
            // 
            // lblSelectDataBase
            // 
            this.lblSelectDataBase.AutoSize = true;
            this.lblSelectDataBase.Location = new System.Drawing.Point(6, 114);
            this.lblSelectDataBase.Name = "lblSelectDataBase";
            this.lblSelectDataBase.Size = new System.Drawing.Size(98, 15);
            this.lblSelectDataBase.TabIndex = 2;
            this.lblSelectDataBase.Text = "Select DataBase";
            // 
            // comboBoxServer
            // 
            this.comboBoxServer.FormattingEnabled = true;
            this.comboBoxServer.Location = new System.Drawing.Point(6, 47);
            this.comboBoxServer.Name = "comboBoxServer";
            this.comboBoxServer.Size = new System.Drawing.Size(188, 23);
            this.comboBoxServer.TabIndex = 1;
            this.comboBoxServer.SelectedIndexChanged += new System.EventHandler(this.comboBoxServer_SelectedIndexChanged);
            // 
            // lblSelectServer
            // 
            this.lblSelectServer.AutoSize = true;
            this.lblSelectServer.Location = new System.Drawing.Point(6, 29);
            this.lblSelectServer.Name = "lblSelectServer";
            this.lblSelectServer.Size = new System.Drawing.Size(79, 15);
            this.lblSelectServer.TabIndex = 0;
            this.lblSelectServer.Text = "Select Server";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(278, 306);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 27);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(67, 306);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 27);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(20, 289);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(403, 11);
            this.progressBar1.TabIndex = 8;
            // 
            // FrmCopyDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(444, 342);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.gbSelectDestination);
            this.Controls.Add(this.gbSelectCollections);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmCopyDataBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copy DataBase";
            this.Load += new System.EventHandler(this.FrmCopyDataBase_Load);
            this.gbSelectCollections.ResumeLayout(false);
            this.gbSelectDestination.ResumeLayout(false);
            this.gbSelectDestination.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSelectCollections;
        private System.Windows.Forms.GroupBox gbSelectDestination;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TreeView treeViewCollection;
        private System.Windows.Forms.Label lblSelectServer;
        private System.Windows.Forms.ComboBox comboBoxServer;
        private System.Windows.Forms.ComboBox comboBoxDataBase;
        private System.Windows.Forms.Label lblSelectDataBase;
        private System.Windows.Forms.CheckBox chkCopyIndexes;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}