namespace UnitTestLagacy.Lagacy
{
    partial class frmUnitTest
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
            this.btnFillDataForGeoObject = new System.Windows.Forms.Button();
            this.btnFillDataForTTL = new System.Windows.Forms.Button();
            this.btnFillDataForUser = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFillDataForMapReduce = new System.Windows.Forms.Button();
            this.btnFillDataForAggregation = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFillDataForGeoObject
            // 
            this.btnFillDataForGeoObject.Location = new System.Drawing.Point(22, 77);
            this.btnFillDataForGeoObject.Name = "btnFillDataForGeoObject";
            this.btnFillDataForGeoObject.Size = new System.Drawing.Size(174, 23);
            this.btnFillDataForGeoObject.TabIndex = 7;
            this.btnFillDataForGeoObject.Text = "FillDataForGeoObject";
            this.btnFillDataForGeoObject.UseVisualStyleBackColor = true;
            this.btnFillDataForGeoObject.Click += new System.EventHandler(this.btnFillDataForGeoObject_Click);
            // 
            // btnFillDataForTTL
            // 
            this.btnFillDataForTTL.Location = new System.Drawing.Point(22, 48);
            this.btnFillDataForTTL.Name = "btnFillDataForTTL";
            this.btnFillDataForTTL.Size = new System.Drawing.Size(174, 23);
            this.btnFillDataForTTL.TabIndex = 6;
            this.btnFillDataForTTL.Text = "FillDataForTTL";
            this.btnFillDataForTTL.UseVisualStyleBackColor = true;
            this.btnFillDataForTTL.Click += new System.EventHandler(this.btnFillDataForTTL_Click);
            // 
            // btnFillDataForUser
            // 
            this.btnFillDataForUser.Location = new System.Drawing.Point(22, 19);
            this.btnFillDataForUser.Name = "btnFillDataForUser";
            this.btnFillDataForUser.Size = new System.Drawing.Size(174, 23);
            this.btnFillDataForUser.TabIndex = 5;
            this.btnFillDataForUser.Text = "FillDataForUser";
            this.btnFillDataForUser.UseVisualStyleBackColor = true;
            this.btnFillDataForUser.Click += new System.EventHandler(this.btnFillDataForUser_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFillDataForMapReduce);
            this.groupBox1.Controls.Add(this.btnFillDataForAggregation);
            this.groupBox1.Controls.Add(this.btnFillDataForUser);
            this.groupBox1.Controls.Add(this.btnFillDataForGeoObject);
            this.groupBox1.Controls.Add(this.btnFillDataForTTL);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 157);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UnitTest";
            // 
            // btnFillDataForMapReduce
            // 
            this.btnFillDataForMapReduce.Location = new System.Drawing.Point(22, 128);
            this.btnFillDataForMapReduce.Name = "btnFillDataForMapReduce";
            this.btnFillDataForMapReduce.Size = new System.Drawing.Size(174, 23);
            this.btnFillDataForMapReduce.TabIndex = 9;
            this.btnFillDataForMapReduce.Text = "FillDataForMapReduce";
            this.btnFillDataForMapReduce.UseVisualStyleBackColor = true;
            this.btnFillDataForMapReduce.Click += new System.EventHandler(this.btnFillDataForMapReduce_Click);
            // 
            // btnFillDataForAggregation
            // 
            this.btnFillDataForAggregation.Location = new System.Drawing.Point(22, 104);
            this.btnFillDataForAggregation.Name = "btnFillDataForAggregation";
            this.btnFillDataForAggregation.Size = new System.Drawing.Size(174, 23);
            this.btnFillDataForAggregation.TabIndex = 8;
            this.btnFillDataForAggregation.Text = "FillDataForAggregation";
            this.btnFillDataForAggregation.UseVisualStyleBackColor = true;
            this.btnFillDataForAggregation.Click += new System.EventHandler(this.btnFillDataForAggregation_Click);
            // 
            // frmUnitTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 187);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmUnitTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UnitTest";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFillDataForGeoObject;
        private System.Windows.Forms.Button btnFillDataForTTL;
        private System.Windows.Forms.Button btnFillDataForUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFillDataForAggregation;
        private System.Windows.Forms.Button btnFillDataForMapReduce;
    }
}