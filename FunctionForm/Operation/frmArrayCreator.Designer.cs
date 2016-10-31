using System.ComponentModel;
using System.Windows.Forms;
using MongoGUICtl.Aggregation;

namespace FunctionForm.Operation
{
    partial class frmArrayCreator
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.ArrayPanel = new MongoGUICtl.Aggregation.BsonArrayPanel();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(150, 303);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(253, 303);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 30);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(357, 303);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 30);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ArrayPanel
            // 
            this.ArrayPanel.AutoScroll = true;
            this.ArrayPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ArrayPanel.Location = new System.Drawing.Point(0, 0);
            this.ArrayPanel.Name = "ArrayPanel";
            this.ArrayPanel.Size = new System.Drawing.Size(455, 282);
            this.ArrayPanel.TabIndex = 2;
            // 
            // frmArrayCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(455, 345);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ArrayPanel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClear);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArrayCreator";
            this.Text = "Array Creator";
            this.Load += new System.EventHandler(this.frmArrayCreator_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnAdd;
        private Button btnClear;
        private BsonArrayPanel ArrayPanel;
        private Button btnOK;
    }
}