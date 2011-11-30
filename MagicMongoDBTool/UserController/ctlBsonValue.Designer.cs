namespace MagicMongoDBTool
{
    partial class ctlBsonValue
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.radFalse = new System.Windows.Forms.RadioButton();
            this.radTrue = new System.Windows.Forms.RadioButton();
            this.txtBsonValue = new QLFUI.TextBoxEx();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.NumberPick = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumberPick)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDataType
            // 
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(107, 4);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(97, 21);
            this.cmbDataType.TabIndex = 4;
            this.cmbDataType.SelectedIndexChanged += new System.EventHandler(this.cmbDataType_SelectedIndexChanged);
            // 
            // radFalse
            // 
            this.radFalse.AutoSize = true;
            this.radFalse.BackColor = System.Drawing.Color.Transparent;
            this.radFalse.Location = new System.Drawing.Point(51, 4);
            this.radFalse.Name = "radFalse";
            this.radFalse.Size = new System.Drawing.Size(50, 17);
            this.radFalse.TabIndex = 6;
            this.radFalse.TabStop = true;
            this.radFalse.Text = "False";
            this.radFalse.UseVisualStyleBackColor = false;
            // 
            // radTrue
            // 
            this.radTrue.AutoSize = true;
            this.radTrue.BackColor = System.Drawing.Color.Transparent;
            this.radTrue.Location = new System.Drawing.Point(3, 5);
            this.radTrue.Name = "radTrue";
            this.radTrue.Size = new System.Drawing.Size(47, 17);
            this.radTrue.TabIndex = 7;
            this.radTrue.TabStop = true;
            this.radTrue.Text = "True";
            this.radTrue.UseVisualStyleBackColor = false;
            // 
            // txtBsonValue
            // 
            this.txtBsonValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtBsonValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtBsonValue.BackColor = System.Drawing.Color.Transparent;
            this.txtBsonValue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtBsonValue.ForeImage = null;
            this.txtBsonValue.Location = new System.Drawing.Point(0, 3);
            this.txtBsonValue.Multiline = false;
            this.txtBsonValue.Name = "txtBsonValue";
            this.txtBsonValue.Radius = 3;
            this.txtBsonValue.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtBsonValue.Size = new System.Drawing.Size(105, 29);
            this.txtBsonValue.TabIndex = 5;
            this.txtBsonValue.UseSystemPasswordChar = false;
            this.txtBsonValue.WaterMark = "元素值";
            this.txtBsonValue.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(0, 4);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(101, 20);
            this.dateTimePicker.TabIndex = 8;
            // 
            // NumberPick
            // 
            this.NumberPick.Location = new System.Drawing.Point(0, 3);
            this.NumberPick.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.NumberPick.Minimum = new decimal(new int[] {
            -727379969,
            232,
            0,
            -2147483648});
            this.NumberPick.Name = "NumberPick";
            this.NumberPick.Size = new System.Drawing.Size(105, 20);
            this.NumberPick.TabIndex = 9;
            this.NumberPick.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ctlBsonValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NumberPick);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.radTrue);
            this.Controls.Add(this.radFalse);
            this.Controls.Add(this.txtBsonValue);
            this.Controls.Add(this.cmbDataType);
            this.Name = "ctlBsonValue";
            this.Size = new System.Drawing.Size(211, 28);
            ((System.ComponentModel.ISupportInitialize)(this.NumberPick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QLFUI.TextBoxEx txtBsonValue;
        private System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.RadioButton radFalse;
        private System.Windows.Forms.RadioButton radTrue;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.NumericUpDown NumberPick;

    }
}
