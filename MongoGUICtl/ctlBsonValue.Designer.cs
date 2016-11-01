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
            this.radFalse.Location = new System.Drawing.Point(53, 3);
            this.radFalse.Name = "radFalse";
            this.radFalse.Size = new System.Drawing.Size(53, 16);
            this.radFalse.TabIndex = 6;
            this.radFalse.TabStop = true;
            this.radFalse.Text = "False";
            this.radFalse.UseVisualStyleBackColor = false;
            // 
            // radTrue
            // 
            this.radTrue.AutoSize = true;
            this.radTrue.BackColor = System.Drawing.Color.Transparent;
            this.radTrue.Location = new System.Drawing.Point(0, 3);
            this.radTrue.Name = "radTrue";
            this.radTrue.Size = new System.Drawing.Size(47, 16);
            this.radTrue.TabIndex = 7;
            this.radTrue.TabStop = true;
            this.radTrue.Text = "True";
            this.radTrue.UseVisualStyleBackColor = false;
            // 
            // txtBsonValue
            // 
            this.txtBsonValue.Location = new System.Drawing.Point(0, 3);
            this.txtBsonValue.Name = "txtBsonValue";
            this.txtBsonValue.Size = new System.Drawing.Size(219, 21);
            this.txtBsonValue.TabIndex = 5;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(0, 3);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(219, 21);
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
            this.NumberPick.Size = new System.Drawing.Size(219, 21);
            this.NumberPick.TabIndex = 9;
            this.NumberPick.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ctlBsonValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtBsonValue);
            this.Controls.Add(this.radTrue);
            this.Controls.Add(this.radFalse);
            this.Controls.Add(this.NumberPick);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "ctlBsonValue";
            this.Size = new System.Drawing.Size(225, 28);
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
