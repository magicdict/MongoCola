using System.ComponentModel;
using System.Windows.Forms;
using MongoGUICtl;
using MongoGUICtl.Aggregation;

namespace MongoGUIView
{
    partial class FrmQuery
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabFieldInfo = new System.Windows.Forms.TabPage();
            this.QueryFieldPicker = new MongoGUICtl.Aggregation.FieldPicker();
            this.tabCondition = new System.Windows.Forms.TabPage();
            this.ConditionPan = new MongoGUICtl.Aggregation.ConditionPanel();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabFieldInfo.SuspendLayout();
            this.tabCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(227, 509);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(99, 33);
            this.cmdOK.TabIndex = 12;
            this.cmdOK.Tag = "Common_OK";
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabFieldInfo);
            this.tabControl.Controls.Add(this.tabCondition);
            this.tabControl.Location = new System.Drawing.Point(6, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(539, 476);
            this.tabControl.TabIndex = 0;
            // 
            // tabFieldInfo
            // 
            this.tabFieldInfo.AutoScroll = true;
            this.tabFieldInfo.Controls.Add(this.QueryFieldPicker);
            this.tabFieldInfo.Location = new System.Drawing.Point(4, 24);
            this.tabFieldInfo.Name = "tabFieldInfo";
            this.tabFieldInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabFieldInfo.Size = new System.Drawing.Size(531, 448);
            this.tabFieldInfo.TabIndex = 0;
            this.tabFieldInfo.Text = "Output Fields";
            this.tabFieldInfo.UseVisualStyleBackColor = true;
            // 
            // QueryFieldPicker
            // 
            this.QueryFieldPicker.AutoScroll = true;
            this.QueryFieldPicker.BackColor = System.Drawing.Color.White;
            this.QueryFieldPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueryFieldPicker.FieldListMode = MongoGUICtl.Aggregation.CtlFieldInfo.FieldMode.Query;
            this.QueryFieldPicker.IsIdProtect = true;
            this.QueryFieldPicker.Location = new System.Drawing.Point(3, 3);
            this.QueryFieldPicker.Name = "QueryFieldPicker";
            this.QueryFieldPicker.Size = new System.Drawing.Size(525, 442);
            this.QueryFieldPicker.TabIndex = 0;
            // 
            // tabCondition
            // 
            this.tabCondition.Controls.Add(this.ConditionPan);
            this.tabCondition.Location = new System.Drawing.Point(4, 24);
            this.tabCondition.Name = "tabCondition";
            this.tabCondition.Padding = new System.Windows.Forms.Padding(3);
            this.tabCondition.Size = new System.Drawing.Size(696, 468);
            this.tabCondition.TabIndex = 1;
            this.tabCondition.Text = "Condition";
            this.tabCondition.UseVisualStyleBackColor = true;
            // 
            // ConditionPan
            // 
            this.ConditionPan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConditionPan.Location = new System.Drawing.Point(3, 3);
            this.ConditionPan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConditionPan.Name = "ConditionPan";
            this.ConditionPan.Size = new System.Drawing.Size(690, 462);
            this.ConditionPan.TabIndex = 0;
            // 
            // cmdLoad
            // 
            this.cmdLoad.BackColor = System.Drawing.Color.Transparent;
            this.cmdLoad.Location = new System.Drawing.Point(13, 509);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(99, 33);
            this.cmdLoad.TabIndex = 13;
            this.cmdLoad.Tag = "Common_Load";
            this.cmdLoad.Text = "Load Query";
            this.cmdLoad.UseVisualStyleBackColor = false;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.Transparent;
            this.cmdSave.Location = new System.Drawing.Point(120, 509);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(99, 33);
            this.cmdSave.TabIndex = 14;
            this.cmdSave.Tag = "Common_Save";
            this.cmdSave.Text = "Save Query";
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(334, 509);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(99, 33);
            this.cmdCancel.TabIndex = 15;
            this.cmdCancel.Tag = "Common_Cancel";
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // FrmQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(556, 554);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdLoad);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Query_Title";
            this.Text = "Query";
            this.Load += new System.EventHandler(this.frmQuery_Load);
            this.tabControl.ResumeLayout(false);
            this.tabFieldInfo.ResumeLayout(false);
            this.tabCondition.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Button cmdOK;
        private TabControl tabControl;
        private TabPage tabCondition;
        private Button cmdSave;
        private Button cmdLoad;
        private Button cmdCancel;
        private TabPage tabFieldInfo;
        private FieldPicker QueryFieldPicker;
        private ConditionPanel ConditionPan;
    }
}