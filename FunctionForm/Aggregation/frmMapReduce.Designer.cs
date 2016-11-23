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
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmbOutputMode = new System.Windows.Forms.ComboBox();
            this.NumLimit = new System.Windows.Forms.NumericUpDown();
            this.txtOutputCollectionName = new System.Windows.Forms.TextBox();
            this.lblLimit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCollectionName = new System.Windows.Forms.Label();
            this.chkjsMode = new System.Windows.Forms.CheckBox();
            this.chkverbose = new System.Windows.Forms.CheckBox();
            this.chkbypassDocumentValidation = new System.Windows.Forms.CheckBox();
            this.cmdClearQuery = new System.Windows.Forms.Button();
            this.QueryTreeView = new MongoGUICtl.CtlTreeViewColumns();
            this.cmdCreateQueryDocument = new System.Windows.Forms.Button();
            this.ctlFinalizeFunction = new MongoGUICtl.ctlJsCodeEditor();
            this.ctlReduceFunction = new MongoGUICtl.ctlJsCodeEditor();
            this.ctlMapFunction = new MongoGUICtl.ctlJsCodeEditor();
            this.trvCollation = new MongoGUICtl.CtlTreeViewColumns();
            this.btnCollation = new System.Windows.Forms.Button();
            this.tabMapReduce = new System.Windows.Forms.TabControl();
            this.tabMap = new System.Windows.Forms.TabPage();
            this.tabReduce = new System.Windows.Forms.TabPage();
            this.tabFinalize = new System.Windows.Forms.TabPage();
            this.tabQuery = new System.Windows.Forms.TabPage();
            this.tabCollation = new System.Windows.Forms.TabPage();
            this.btnClearCollation = new System.Windows.Forms.Button();
            this.tabOutPut = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.NumLimit)).BeginInit();
            this.tabMapReduce.SuspendLayout();
            this.tabMap.SuspendLayout();
            this.tabReduce.SuspendLayout();
            this.tabFinalize.SuspendLayout();
            this.tabQuery.SuspendLayout();
            this.tabCollation.SuspendLayout();
            this.tabOutPut.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdRun
            // 
            this.cmdRun.BackColor = System.Drawing.Color.Transparent;
            this.cmdRun.Location = new System.Drawing.Point(194, 415);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(103, 30);
            this.cmdRun.TabIndex = 7;
            this.cmdRun.Tag = "Common.Run";
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = false;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(303, 415);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(111, 30);
            this.cmdClose.TabIndex = 22;
            this.cmdClose.Tag = "Common.Close";
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmbOutputMode
            // 
            this.cmbOutputMode.FormattingEnabled = true;
            this.cmbOutputMode.Location = new System.Drawing.Point(149, 36);
            this.cmbOutputMode.Name = "cmbOutputMode";
            this.cmbOutputMode.Size = new System.Drawing.Size(165, 23);
            this.cmbOutputMode.TabIndex = 7;
            // 
            // NumLimit
            // 
            this.NumLimit.Location = new System.Drawing.Point(149, 102);
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
            this.txtOutputCollectionName.Location = new System.Drawing.Point(149, 69);
            this.txtOutputCollectionName.Name = "txtOutputCollectionName";
            this.txtOutputCollectionName.Size = new System.Drawing.Size(165, 21);
            this.txtOutputCollectionName.TabIndex = 5;
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(48, 104);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(34, 15);
            this.lblLimit.TabIndex = 4;
            this.lblLimit.Text = "Limit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mode";
            // 
            // lblCollectionName
            // 
            this.lblCollectionName.AutoSize = true;
            this.lblCollectionName.Location = new System.Drawing.Point(48, 72);
            this.lblCollectionName.Name = "lblCollectionName";
            this.lblCollectionName.Size = new System.Drawing.Size(95, 15);
            this.lblCollectionName.TabIndex = 4;
            this.lblCollectionName.Text = "CollectionName";
            // 
            // chkjsMode
            // 
            this.chkjsMode.AutoSize = true;
            this.chkjsMode.Location = new System.Drawing.Point(47, 142);
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
            this.chkverbose.Location = new System.Drawing.Point(120, 143);
            this.chkverbose.Name = "chkverbose";
            this.chkverbose.Size = new System.Drawing.Size(69, 19);
            this.chkverbose.TabIndex = 25;
            this.chkverbose.Text = "verbose";
            this.chkverbose.UseVisualStyleBackColor = true;
            // 
            // chkbypassDocumentValidation
            // 
            this.chkbypassDocumentValidation.AutoSize = true;
            this.chkbypassDocumentValidation.Location = new System.Drawing.Point(205, 143);
            this.chkbypassDocumentValidation.Name = "chkbypassDocumentValidation";
            this.chkbypassDocumentValidation.Size = new System.Drawing.Size(175, 19);
            this.chkbypassDocumentValidation.TabIndex = 26;
            this.chkbypassDocumentValidation.Text = "bypassDocumentValidation";
            this.chkbypassDocumentValidation.UseVisualStyleBackColor = true;
            // 
            // cmdClearQuery
            // 
            this.cmdClearQuery.Location = new System.Drawing.Point(139, 17);
            this.cmdClearQuery.Name = "cmdClearQuery";
            this.cmdClearQuery.Size = new System.Drawing.Size(97, 28);
            this.cmdClearQuery.TabIndex = 2;
            this.cmdClearQuery.Tag = "Common.Clear";
            this.cmdClearQuery.Text = "Clear";
            this.cmdClearQuery.UseVisualStyleBackColor = true;
            this.cmdClearQuery.Click += new System.EventHandler(this.cmdClearQuery_Click);
            // 
            // QueryTreeView
            // 
            this.QueryTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.QueryTreeView.Location = new System.Drawing.Point(24, 52);
            this.QueryTreeView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QueryTreeView.Name = "QueryTreeView";
            this.QueryTreeView.Padding = new System.Windows.Forms.Padding(1);
            this.QueryTreeView.Size = new System.Drawing.Size(516, 297);
            this.QueryTreeView.TabIndex = 1;
            // 
            // cmdCreateQueryDocument
            // 
            this.cmdCreateQueryDocument.Location = new System.Drawing.Point(24, 17);
            this.cmdCreateQueryDocument.Name = "cmdCreateQueryDocument";
            this.cmdCreateQueryDocument.Size = new System.Drawing.Size(97, 28);
            this.cmdCreateQueryDocument.TabIndex = 0;
            this.cmdCreateQueryDocument.Tag = "Common.Create";
            this.cmdCreateQueryDocument.Text = "Create";
            this.cmdCreateQueryDocument.UseVisualStyleBackColor = true;
            this.cmdCreateQueryDocument.Click += new System.EventHandler(this.cmdCreateQueryDocument_Click);
            // 
            // ctlFinalizeFunction
            // 
            this.ctlFinalizeFunction.Context = "";
            this.ctlFinalizeFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlFinalizeFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlFinalizeFunction.Location = new System.Drawing.Point(3, 3);
            this.ctlFinalizeFunction.Name = "ctlFinalizeFunction";
            this.ctlFinalizeFunction.Size = new System.Drawing.Size(561, 363);
            this.ctlFinalizeFunction.TabIndex = 21;
            this.ctlFinalizeFunction.Title = "Finalize Function";
            // 
            // ctlReduceFunction
            // 
            this.ctlReduceFunction.Context = "";
            this.ctlReduceFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlReduceFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlReduceFunction.Location = new System.Drawing.Point(3, 3);
            this.ctlReduceFunction.Name = "ctlReduceFunction";
            this.ctlReduceFunction.Size = new System.Drawing.Size(561, 363);
            this.ctlReduceFunction.TabIndex = 21;
            this.ctlReduceFunction.Title = "Reduce Function";
            // 
            // ctlMapFunction
            // 
            this.ctlMapFunction.Context = "";
            this.ctlMapFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlMapFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlMapFunction.Location = new System.Drawing.Point(3, 3);
            this.ctlMapFunction.Name = "ctlMapFunction";
            this.ctlMapFunction.Size = new System.Drawing.Size(561, 363);
            this.ctlMapFunction.TabIndex = 20;
            this.ctlMapFunction.Title = "MapFunction";
            // 
            // trvCollation
            // 
            this.trvCollation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvCollation.Location = new System.Drawing.Point(25, 54);
            this.trvCollation.Margin = new System.Windows.Forms.Padding(6);
            this.trvCollation.Name = "trvCollation";
            this.trvCollation.Padding = new System.Windows.Forms.Padding(1);
            this.trvCollation.Size = new System.Drawing.Size(511, 291);
            this.trvCollation.TabIndex = 40;
            // 
            // btnCollation
            // 
            this.btnCollation.Location = new System.Drawing.Point(25, 17);
            this.btnCollation.Name = "btnCollation";
            this.btnCollation.Size = new System.Drawing.Size(96, 27);
            this.btnCollation.TabIndex = 39;
            this.btnCollation.Tag = "Common.Create";
            this.btnCollation.Text = "Create";
            this.btnCollation.UseVisualStyleBackColor = true;
            this.btnCollation.Click += new System.EventHandler(this.btnCollation_Click);
            // 
            // tabMapReduce
            // 
            this.tabMapReduce.Controls.Add(this.tabMap);
            this.tabMapReduce.Controls.Add(this.tabReduce);
            this.tabMapReduce.Controls.Add(this.tabFinalize);
            this.tabMapReduce.Controls.Add(this.tabQuery);
            this.tabMapReduce.Controls.Add(this.tabCollation);
            this.tabMapReduce.Controls.Add(this.tabOutPut);
            this.tabMapReduce.Location = new System.Drawing.Point(21, 12);
            this.tabMapReduce.Name = "tabMapReduce";
            this.tabMapReduce.SelectedIndex = 0;
            this.tabMapReduce.Size = new System.Drawing.Size(575, 397);
            this.tabMapReduce.TabIndex = 29;
            // 
            // tabMap
            // 
            this.tabMap.Controls.Add(this.ctlMapFunction);
            this.tabMap.Location = new System.Drawing.Point(4, 24);
            this.tabMap.Name = "tabMap";
            this.tabMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabMap.Size = new System.Drawing.Size(567, 369);
            this.tabMap.TabIndex = 3;
            this.tabMap.Text = "Map";
            this.tabMap.UseVisualStyleBackColor = true;
            // 
            // tabReduce
            // 
            this.tabReduce.Controls.Add(this.ctlReduceFunction);
            this.tabReduce.Location = new System.Drawing.Point(4, 24);
            this.tabReduce.Name = "tabReduce";
            this.tabReduce.Padding = new System.Windows.Forms.Padding(3);
            this.tabReduce.Size = new System.Drawing.Size(567, 369);
            this.tabReduce.TabIndex = 4;
            this.tabReduce.Text = "Reduce";
            this.tabReduce.UseVisualStyleBackColor = true;
            // 
            // tabFinalize
            // 
            this.tabFinalize.Controls.Add(this.ctlFinalizeFunction);
            this.tabFinalize.Location = new System.Drawing.Point(4, 24);
            this.tabFinalize.Name = "tabFinalize";
            this.tabFinalize.Padding = new System.Windows.Forms.Padding(3);
            this.tabFinalize.Size = new System.Drawing.Size(567, 369);
            this.tabFinalize.TabIndex = 5;
            this.tabFinalize.Text = "Finalize";
            this.tabFinalize.UseVisualStyleBackColor = true;
            // 
            // tabQuery
            // 
            this.tabQuery.Controls.Add(this.cmdClearQuery);
            this.tabQuery.Controls.Add(this.QueryTreeView);
            this.tabQuery.Controls.Add(this.cmdCreateQueryDocument);
            this.tabQuery.Location = new System.Drawing.Point(4, 24);
            this.tabQuery.Name = "tabQuery";
            this.tabQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuery.Size = new System.Drawing.Size(567, 369);
            this.tabQuery.TabIndex = 2;
            this.tabQuery.Text = "Query";
            this.tabQuery.UseVisualStyleBackColor = true;
            // 
            // tabCollation
            // 
            this.tabCollation.Controls.Add(this.btnClearCollation);
            this.tabCollation.Controls.Add(this.btnCollation);
            this.tabCollation.Controls.Add(this.trvCollation);
            this.tabCollation.Location = new System.Drawing.Point(4, 24);
            this.tabCollation.Name = "tabCollation";
            this.tabCollation.Padding = new System.Windows.Forms.Padding(3);
            this.tabCollation.Size = new System.Drawing.Size(567, 369);
            this.tabCollation.TabIndex = 0;
            this.tabCollation.Text = "Collation";
            this.tabCollation.UseVisualStyleBackColor = true;
            // 
            // btnClearCollation
            // 
            this.btnClearCollation.Location = new System.Drawing.Point(136, 17);
            this.btnClearCollation.Name = "btnClearCollation";
            this.btnClearCollation.Size = new System.Drawing.Size(97, 28);
            this.btnClearCollation.TabIndex = 41;
            this.btnClearCollation.Tag = "Common.Clear";
            this.btnClearCollation.Text = "Clear";
            this.btnClearCollation.UseVisualStyleBackColor = true;
            this.btnClearCollation.Click += new System.EventHandler(this.btnClearCollation_Click);
            // 
            // tabOutPut
            // 
            this.tabOutPut.Controls.Add(this.cmbOutputMode);
            this.tabOutPut.Controls.Add(this.NumLimit);
            this.tabOutPut.Controls.Add(this.chkjsMode);
            this.tabOutPut.Controls.Add(this.txtOutputCollectionName);
            this.tabOutPut.Controls.Add(this.chkbypassDocumentValidation);
            this.tabOutPut.Controls.Add(this.lblLimit);
            this.tabOutPut.Controls.Add(this.chkverbose);
            this.tabOutPut.Controls.Add(this.label1);
            this.tabOutPut.Controls.Add(this.lblCollectionName);
            this.tabOutPut.Location = new System.Drawing.Point(4, 24);
            this.tabOutPut.Name = "tabOutPut";
            this.tabOutPut.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutPut.Size = new System.Drawing.Size(567, 369);
            this.tabOutPut.TabIndex = 1;
            this.tabOutPut.Text = "OutPut";
            this.tabOutPut.UseVisualStyleBackColor = true;
            // 
            // FrmMapReduce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(608, 457);
            this.Controls.Add(this.tabMapReduce);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdRun);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMapReduce";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MapReduce";
            this.Load += new System.EventHandler(this.frmMapReduce_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumLimit)).EndInit();
            this.tabMapReduce.ResumeLayout(false);
            this.tabMap.ResumeLayout(false);
            this.tabReduce.ResumeLayout(false);
            this.tabFinalize.ResumeLayout(false);
            this.tabQuery.ResumeLayout(false);
            this.tabCollation.ResumeLayout(false);
            this.tabOutPut.ResumeLayout(false);
            this.tabOutPut.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button cmdRun;
        private ctlJsCodeEditor ctlMapFunction;
        private ctlJsCodeEditor ctlReduceFunction;
        private Button cmdClose;
        private TextBox txtOutputCollectionName;
        private Label lblCollectionName;
        private CheckBox chkjsMode;
        private CheckBox chkverbose;
        private CheckBox chkbypassDocumentValidation;
        private ctlJsCodeEditor ctlFinalizeFunction;
        private NumericUpDown NumLimit;
        private Label lblLimit;
        private ComboBox cmbOutputMode;
        private Label label1;
        private Button cmdCreateQueryDocument;
        private CtlTreeViewColumns QueryTreeView;
        private Button cmdClearQuery;
        private CtlTreeViewColumns trvCollation;
        private Button btnCollation;
        private TabControl tabMapReduce;
        private TabPage tabCollation;
        private TabPage tabOutPut;
        private TabPage tabQuery;
        private TabPage tabMap;
        private TabPage tabReduce;
        private TabPage tabFinalize;
        private Button btnClearCollation;
    }
}