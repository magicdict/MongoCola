using System.ComponentModel;
using System.Windows.Forms;
using MongoGUICtl;

namespace FunctionForm.Aggregation
{
    partial class FrmMapReduce
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
            this.cmdRun = new System.Windows.Forms.Button();
            this.ctlMapFunction = new MongoGUICtl.CtlTextMgr();
            this.ctlReduceFunction = new MongoGUICtl.CtlTextMgr();
            this.cmdClose = new System.Windows.Forms.Button();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.cmbOutputMode = new System.Windows.Forms.ComboBox();
            this.NumLimit = new System.Windows.Forms.NumericUpDown();
            this.txtOutputCollectionName = new System.Windows.Forms.TextBox();
            this.lblLimit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCollectionName = new System.Windows.Forms.Label();
            this.chkjsMode = new System.Windows.Forms.CheckBox();
            this.chkverbose = new System.Windows.Forms.CheckBox();
            this.chkbypassDocumentValidation = new System.Windows.Forms.CheckBox();
            this.ctlFinalizeFunction = new MongoGUICtl.CtlTextMgr();
            this.grpQuery = new System.Windows.Forms.GroupBox();
            this.QueryTreeView = new MongoGUICtl.CtlTreeViewColumns();
            this.cmdCreateQueryDocument = new System.Windows.Forms.Button();
            this.cmdClearQuery = new System.Windows.Forms.Button();
            this.grpOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumLimit)).BeginInit();
            this.grpQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdRun
            // 
            this.cmdRun.BackColor = System.Drawing.Color.Transparent;
            this.cmdRun.Location = new System.Drawing.Point(491, 477);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(103, 30);
            this.cmdRun.TabIndex = 7;
            this.cmdRun.Tag = "Common_Run";
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = false;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // ctlMapFunction
            // 
            this.ctlMapFunction.Context = "";
            this.ctlMapFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlMapFunction.Location = new System.Drawing.Point(12, 12);
            this.ctlMapFunction.Name = "ctlMapFunction";
            this.ctlMapFunction.Size = new System.Drawing.Size(369, 139);
            this.ctlMapFunction.TabIndex = 20;
            this.ctlMapFunction.Title = "MapFunction";
            // 
            // ctlReduceFunction
            // 
            this.ctlReduceFunction.Context = "";
            this.ctlReduceFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlReduceFunction.Location = new System.Drawing.Point(4, 157);
            this.ctlReduceFunction.Name = "ctlReduceFunction";
            this.ctlReduceFunction.Size = new System.Drawing.Size(377, 133);
            this.ctlReduceFunction.TabIndex = 21;
            this.ctlReduceFunction.Title = "Reduce Function";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(600, 477);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(111, 30);
            this.cmdClose.TabIndex = 22;
            this.cmdClose.Tag = "Common_Close";
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.cmbOutputMode);
            this.grpOutput.Controls.Add(this.NumLimit);
            this.grpOutput.Controls.Add(this.txtOutputCollectionName);
            this.grpOutput.Controls.Add(this.lblLimit);
            this.grpOutput.Controls.Add(this.label1);
            this.grpOutput.Controls.Add(this.lblCollectionName);
            this.grpOutput.Location = new System.Drawing.Point(410, 263);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(377, 148);
            this.grpOutput.TabIndex = 23;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "Output";
            // 
            // cmbOutputMode
            // 
            this.cmbOutputMode.FormattingEnabled = true;
            this.cmbOutputMode.Location = new System.Drawing.Point(123, 32);
            this.cmbOutputMode.Name = "cmbOutputMode";
            this.cmbOutputMode.Size = new System.Drawing.Size(165, 23);
            this.cmbOutputMode.TabIndex = 7;
            // 
            // NumLimit
            // 
            this.NumLimit.Location = new System.Drawing.Point(123, 98);
            this.NumLimit.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.NumLimit.Name = "NumLimit";
            this.NumLimit.Size = new System.Drawing.Size(164, 21);
            this.NumLimit.TabIndex = 6;
            this.NumLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOutputCollectionName
            // 
            this.txtOutputCollectionName.Location = new System.Drawing.Point(123, 65);
            this.txtOutputCollectionName.Name = "txtOutputCollectionName";
            this.txtOutputCollectionName.Size = new System.Drawing.Size(165, 21);
            this.txtOutputCollectionName.TabIndex = 5;
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(22, 100);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(34, 15);
            this.lblLimit.TabIndex = 4;
            this.lblLimit.Text = "Limit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mode";
            // 
            // lblCollectionName
            // 
            this.lblCollectionName.AutoSize = true;
            this.lblCollectionName.Location = new System.Drawing.Point(22, 68);
            this.lblCollectionName.Name = "lblCollectionName";
            this.lblCollectionName.Size = new System.Drawing.Size(95, 15);
            this.lblCollectionName.TabIndex = 4;
            this.lblCollectionName.Text = "CollectionName";
            // 
            // chkjsMode
            // 
            this.chkjsMode.AutoSize = true;
            this.chkjsMode.Location = new System.Drawing.Point(442, 428);
            this.chkjsMode.Name = "chkjsMode";
            this.chkjsMode.Size = new System.Drawing.Size(67, 19);
            this.chkjsMode.TabIndex = 24;
            this.chkjsMode.Text = "jsMode";
            this.chkjsMode.UseVisualStyleBackColor = true;
            // 
            // chkverbose
            // 
            this.chkverbose.AutoSize = true;
            this.chkverbose.Checked = true;
            this.chkverbose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkverbose.Location = new System.Drawing.Point(515, 429);
            this.chkverbose.Name = "chkverbose";
            this.chkverbose.Size = new System.Drawing.Size(69, 19);
            this.chkverbose.TabIndex = 25;
            this.chkverbose.Text = "verbose";
            this.chkverbose.UseVisualStyleBackColor = true;
            // 
            // chkbypassDocumentValidation
            // 
            this.chkbypassDocumentValidation.AutoSize = true;
            this.chkbypassDocumentValidation.Location = new System.Drawing.Point(600, 429);
            this.chkbypassDocumentValidation.Name = "chkbypassDocumentValidation";
            this.chkbypassDocumentValidation.Size = new System.Drawing.Size(175, 19);
            this.chkbypassDocumentValidation.TabIndex = 26;
            this.chkbypassDocumentValidation.Text = "bypassDocumentValidation";
            this.chkbypassDocumentValidation.UseVisualStyleBackColor = true;
            // 
            // ctlFinalizeFunction
            // 
            this.ctlFinalizeFunction.Context = "";
            this.ctlFinalizeFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFinalizeFunction.Location = new System.Drawing.Point(4, 319);
            this.ctlFinalizeFunction.Name = "ctlFinalizeFunction";
            this.ctlFinalizeFunction.Size = new System.Drawing.Size(377, 139);
            this.ctlFinalizeFunction.TabIndex = 21;
            this.ctlFinalizeFunction.Title = "Finalize Function";
            // 
            // grpQuery
            // 
            this.grpQuery.Controls.Add(this.cmdClearQuery);
            this.grpQuery.Controls.Add(this.QueryTreeView);
            this.grpQuery.Controls.Add(this.cmdCreateQueryDocument);
            this.grpQuery.Location = new System.Drawing.Point(410, 13);
            this.grpQuery.Name = "grpQuery";
            this.grpQuery.Size = new System.Drawing.Size(377, 225);
            this.grpQuery.TabIndex = 27;
            this.grpQuery.TabStop = false;
            this.grpQuery.Text = "Query Document";
            // 
            // QueryTreeView
            // 
            this.QueryTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.QueryTreeView.Location = new System.Drawing.Point(12, 48);
            this.QueryTreeView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QueryTreeView.Name = "QueryTreeView";
            this.QueryTreeView.Padding = new System.Windows.Forms.Padding(1);
            this.QueryTreeView.Size = new System.Drawing.Size(359, 170);
            this.QueryTreeView.TabIndex = 1;
            // 
            // cmdCreateQueryDocument
            // 
            this.cmdCreateQueryDocument.Location = new System.Drawing.Point(145, 13);
            this.cmdCreateQueryDocument.Name = "cmdCreateQueryDocument";
            this.cmdCreateQueryDocument.Size = new System.Drawing.Size(127, 28);
            this.cmdCreateQueryDocument.TabIndex = 0;
            this.cmdCreateQueryDocument.Text = "Create Document";
            this.cmdCreateQueryDocument.UseVisualStyleBackColor = true;
            this.cmdCreateQueryDocument.Click += new System.EventHandler(this.cmdCreateQueryDocument_Click);
            // 
            // cmdClearQuery
            // 
            this.cmdClearQuery.Location = new System.Drawing.Point(278, 14);
            this.cmdClearQuery.Name = "cmdClearQuery";
            this.cmdClearQuery.Size = new System.Drawing.Size(75, 26);
            this.cmdClearQuery.TabIndex = 2;
            this.cmdClearQuery.Text = "Clear";
            this.cmdClearQuery.UseVisualStyleBackColor = true;
            this.cmdClearQuery.Click += new System.EventHandler(this.cmdClearQuery_Click);
            // 
            // FrmMapReduce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(839, 519);
            this.Controls.Add(this.grpQuery);
            this.Controls.Add(this.chkbypassDocumentValidation);
            this.Controls.Add(this.chkverbose);
            this.Controls.Add(this.chkjsMode);
            this.Controls.Add(this.grpOutput);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.ctlFinalizeFunction);
            this.Controls.Add(this.ctlReduceFunction);
            this.Controls.Add(this.ctlMapFunction);
            this.Controls.Add(this.cmdRun);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMapReduce";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MapReduce";
            this.Load += new System.EventHandler(this.frmMapReduce_Load);
            this.grpOutput.ResumeLayout(false);
            this.grpOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumLimit)).EndInit();
            this.grpQuery.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button cmdRun;
        private CtlTextMgr ctlMapFunction;
        private CtlTextMgr ctlReduceFunction;
        private Button cmdClose;
        private GroupBox grpOutput;
        private TextBox txtOutputCollectionName;
        private Label lblCollectionName;
        private CheckBox chkjsMode;
        private CheckBox chkverbose;
        private CheckBox chkbypassDocumentValidation;
        private CtlTextMgr ctlFinalizeFunction;
        private NumericUpDown NumLimit;
        private Label lblLimit;
        private ComboBox cmbOutputMode;
        private Label label1;
        private GroupBox grpQuery;
        private Button cmdCreateQueryDocument;
        private CtlTreeViewColumns QueryTreeView;
        private Button cmdClearQuery;
    }
}