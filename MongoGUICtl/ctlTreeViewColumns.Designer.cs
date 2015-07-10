using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MongoGUICtl
{
	partial class CtlTreeViewColumns
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listView = new System.Windows.Forms.ListView();
			this.colName = new System.Windows.Forms.ColumnHeader();
			this.colValue = new System.Windows.Forms.ColumnHeader();
			this.colType = new System.Windows.Forms.ColumnHeader();
			this.DatatreeView = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// listView
			// 
			this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.colName,
			this.colValue,
			this.colType});
			this.listView.Dock = System.Windows.Forms.DockStyle.Top;
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.Location = new System.Drawing.Point(0, 0);
			this.listView.Name = "listView";
			this.listView.Scrollable = false;
			this.listView.Size = new System.Drawing.Size(438, 18);
			this.listView.TabIndex = 3;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
			this.listView.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.listView_ColumnWidthChanged);
			this.listView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView_ColumnWidthChanging);
			// 
			// colName
			// 
			this.colName.Text = "Name";
			this.colName.Width = 130;
			// 
			// colValue
			// 
			this.colValue.Text = "Value";
			this.colValue.Width = 129;
			// 
			// colType
			// 
			this.colType.Text = "Type";
			this.colType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colType.Width = 145;
			// 
			// DatatreeView
			// 
			this.DatatreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DatatreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DatatreeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
			this.DatatreeView.FullRowSelect = true;
			this.DatatreeView.HideSelection = false;
			this.DatatreeView.Location = new System.Drawing.Point(0, 18);
			this.DatatreeView.Name = "DatatreeView";
			this.DatatreeView.Size = new System.Drawing.Size(438, 152);
			this.DatatreeView.TabIndex = 2;
			this.DatatreeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView_DrawNode);
			this.DatatreeView.Click += new System.EventHandler(this.treeView_Click);
			// 
			// ctlTreeViewColumns
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.DatatreeView);
			this.Controls.Add(this.listView);
			this.Name = "CtlTreeViewColumns";
			this.Size = new System.Drawing.Size(438, 170);
			this.Load += new System.EventHandler(this.CtlTreeViewColumnsLoad);
			this.SizeChanged += new System.EventHandler(this.Control_SizeChanged);
			this.ResumeLayout(false);

		}

        #endregion

        public ListView listView;
		private ColumnHeader colName;
		private ColumnHeader colValue;
		private ColumnHeader colType;
		public TreeView DatatreeView;
	}
}
