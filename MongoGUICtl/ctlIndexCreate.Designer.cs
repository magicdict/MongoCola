using System.ComponentModel;
using System.Windows.Forms;

namespace MongoGUICtl
{
    partial class CtlIndexCreate
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
            this.radAscendingKey = new System.Windows.Forms.RadioButton();
            this.radDescendingKey = new System.Windows.Forms.RadioButton();
            this.lblKeyName = new System.Windows.Forms.Label();
            this.radGeoSpatial = new System.Windows.Forms.RadioButton();
            this.cmbKeyName = new System.Windows.Forms.ComboBox();
            this.radText = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radAscendingKey
            // 
            this.radAscendingKey.AutoSize = true;
            this.radAscendingKey.Checked = true;
            this.radAscendingKey.Location = new System.Drawing.Point(301, 6);
            this.radAscendingKey.Name = "radAscendingKey";
            this.radAscendingKey.Size = new System.Drawing.Size(41, 16);
            this.radAscendingKey.TabIndex = 1;
            this.radAscendingKey.TabStop = true;
            this.radAscendingKey.Tag = "Index_Asce";
            this.radAscendingKey.Text = "Asc";
            this.radAscendingKey.UseVisualStyleBackColor = true;
            // 
            // radDescendingKey
            // 
            this.radDescendingKey.AutoSize = true;
            this.radDescendingKey.Location = new System.Drawing.Point(356, 6);
            this.radDescendingKey.Name = "radDescendingKey";
            this.radDescendingKey.Size = new System.Drawing.Size(41, 16);
            this.radDescendingKey.TabIndex = 2;
            this.radDescendingKey.Tag = "Index_Desc";
            this.radDescendingKey.Text = "Des";
            this.radDescendingKey.UseVisualStyleBackColor = true;
            // 
            // lblKeyName
            // 
            this.lblKeyName.AutoSize = true;
            this.lblKeyName.Location = new System.Drawing.Point(8, 6);
            this.lblKeyName.Name = "lblKeyName";
            this.lblKeyName.Size = new System.Drawing.Size(65, 12);
            this.lblKeyName.TabIndex = 3;
            this.lblKeyName.Tag = "ctlIndexCreate_Index";
            this.lblKeyName.Text = "IndexFiled";
            // 
            // radGeoSpatial
            // 
            this.radGeoSpatial.AutoSize = true;
            this.radGeoSpatial.Location = new System.Drawing.Point(406, 6);
            this.radGeoSpatial.Name = "radGeoSpatial";
            this.radGeoSpatial.Size = new System.Drawing.Size(41, 16);
            this.radGeoSpatial.TabIndex = 5;
            this.radGeoSpatial.TabStop = true;
            this.radGeoSpatial.Text = "Geo";
            this.radGeoSpatial.UseVisualStyleBackColor = true;
            // 
            // cmbKeyName
            // 
            this.cmbKeyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKeyName.FormattingEnabled = true;
            this.cmbKeyName.Location = new System.Drawing.Point(82, 2);
            this.cmbKeyName.Name = "cmbKeyName";
            this.cmbKeyName.Size = new System.Drawing.Size(213, 20);
            this.cmbKeyName.TabIndex = 6;
            // 
            // radText
            // 
            this.radText.AutoSize = true;
            this.radText.Location = new System.Drawing.Point(457, 6);
            this.radText.Name = "radText";
            this.radText.Size = new System.Drawing.Size(47, 16);
            this.radText.TabIndex = 7;
            this.radText.TabStop = true;
            this.radText.Text = "Text";
            this.radText.UseVisualStyleBackColor = true;
            // 
            // ctlIndexCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.radText);
            this.Controls.Add(this.cmbKeyName);
            this.Controls.Add(this.radGeoSpatial);
            this.Controls.Add(this.lblKeyName);
            this.Controls.Add(this.radDescendingKey);
            this.Controls.Add(this.radAscendingKey);
            this.Name = "CtlIndexCreate";
            this.Size = new System.Drawing.Size(524, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadioButton radAscendingKey;
        private RadioButton radDescendingKey;
        private Label lblKeyName;
        private RadioButton radGeoSpatial;
        private ComboBox cmbKeyName;
        private RadioButton radText;
    }
}
