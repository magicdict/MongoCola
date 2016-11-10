using System.ComponentModel;
using System.Windows.Forms;

namespace MongoGUICtl
{
    partial class ctlBsonValue
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
            this.radFalse = new System.Windows.Forms.RadioButton();
            this.radTrue = new System.Windows.Forms.RadioButton();
            this.txtBsonValue = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.NumberPick = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumberPick)).BeginInit();
            this.SuspendLayout();
            // 
            // radFalse
            // 
            this.radFalse.AutoSize = true;
            this.radFalse.BackColor = System.Drawing.Color.Transparent;
            this.radFalse.Location = new System.Drawing.Point(62, 4);
            this.radFalse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radFalse.Name = "radFalse";
            this.radFalse.Size = new System.Drawing.Size(55, 21);
            this.radFalse.TabIndex = 6;
            this.radFalse.TabStop = true;
            this.radFalse.Text = "False";
            this.radFalse.UseVisualStyleBackColor = false;
            // 
            // radTrue
            // 
            this.radTrue.AutoSize = true;
            this.radTrue.BackColor = System.Drawing.Color.Transparent;
            this.radTrue.Location = new System.Drawing.Point(0, 4);
            this.radTrue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radTrue.Name = "radTrue";
            this.radTrue.Size = new System.Drawing.Size(52, 21);
            this.radTrue.TabIndex = 7;
            this.radTrue.TabStop = true;
            this.radTrue.Text = "True";
            this.radTrue.UseVisualStyleBackColor = false;
            // 
            // txtBsonValue
            // 
            this.txtBsonValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBsonValue.Location = new System.Drawing.Point(2, 4);
            this.txtBsonValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBsonValue.Name = "txtBsonValue";
            this.txtBsonValue.Size = new System.Drawing.Size(194, 23);
            this.txtBsonValue.TabIndex = 5;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker.Location = new System.Drawing.Point(-1, 4);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(198, 23);
            this.dateTimePicker.TabIndex = 8;
            // 
            // NumberPick
            // 
            this.NumberPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberPick.Location = new System.Drawing.Point(-1, 4);
            this.NumberPick.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.NumberPick.Size = new System.Drawing.Size(193, 23);
            this.NumberPick.TabIndex = 9;
            this.NumberPick.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ctlBsonValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtBsonValue);
            this.Controls.Add(this.radTrue);
            this.Controls.Add(this.radFalse);
            this.Controls.Add(this.NumberPick);
            this.Controls.Add(this.dateTimePicker);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ctlBsonValue";
            this.Size = new System.Drawing.Size(197, 32);
            ((System.ComponentModel.ISupportInitialize)(this.NumberPick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtBsonValue;
        private RadioButton radFalse;
        private RadioButton radTrue;
        private DateTimePicker dateTimePicker;
        private NumericUpDown NumberPick;

    }
}
