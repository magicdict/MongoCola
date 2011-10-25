namespace MagicMongoDBTool
{
    partial class frmMapReduce
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMapReduce));
            this.cmbForMap = new System.Windows.Forms.ComboBox();
            this.cmbForReduce = new System.Windows.Forms.ComboBox();
            this.cmdSaveReduceJs = new System.Windows.Forms.VistaButton();
            this.cmdSaveMapJs = new System.Windows.Forms.VistaButton();
            this.lblReduceFunction = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblMapFunction = new System.Windows.Forms.Label();
            this.trvResult = new System.Windows.Forms.TreeView();
            this.txtMapJs = new System.Windows.Forms.TextBox();
            this.txtReduceJs = new System.Windows.Forms.TextBox();
            this.cmdRun = new System.Windows.Forms.VistaButton();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.cmbForMap);
            this.contentPanel.Controls.Add(this.cmbForReduce);
            this.contentPanel.Controls.Add(this.cmdSaveReduceJs);
            this.contentPanel.Controls.Add(this.cmdSaveMapJs);
            this.contentPanel.Controls.Add(this.lblReduceFunction);
            this.contentPanel.Controls.Add(this.lblResult);
            this.contentPanel.Controls.Add(this.lblMapFunction);
            this.contentPanel.Controls.Add(this.trvResult);
            this.contentPanel.Controls.Add(this.txtMapJs);
            this.contentPanel.Controls.Add(this.txtReduceJs);
            this.contentPanel.Controls.Add(this.cmdRun);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(727, 489);
            // 
            // cmbForMap
            // 
            this.cmbForMap.FormattingEnabled = true;
            this.cmbForMap.Location = new System.Drawing.Point(100, 28);
            this.cmbForMap.Name = "cmbForMap";
            this.cmbForMap.Size = new System.Drawing.Size(151, 21);
            this.cmbForMap.TabIndex = 19;
            // 
            // cmbForReduce
            // 
            this.cmbForReduce.FormattingEnabled = true;
            this.cmbForReduce.Location = new System.Drawing.Point(101, 239);
            this.cmbForReduce.Name = "cmbForReduce";
            this.cmbForReduce.Size = new System.Drawing.Size(151, 21);
            this.cmbForReduce.TabIndex = 20;
            // 
            // cmdSaveReduceJs
            // 
            this.cmdSaveReduceJs.BackColor = System.Drawing.Color.Transparent;
            this.cmdSaveReduceJs.Location = new System.Drawing.Point(257, 234);
            this.cmdSaveReduceJs.Name = "cmdSaveReduceJs";
            this.cmdSaveReduceJs.Size = new System.Drawing.Size(70, 30);
            this.cmdSaveReduceJs.TabIndex = 18;
            this.cmdSaveReduceJs.Text = "保存";
            this.cmdSaveReduceJs.Click += new System.EventHandler(this.cmdSaveReduceJs_Click);
            // 
            // cmdSaveMapJs
            // 
            this.cmdSaveMapJs.BackColor = System.Drawing.Color.Transparent;
            this.cmdSaveMapJs.Location = new System.Drawing.Point(257, 22);
            this.cmdSaveMapJs.Name = "cmdSaveMapJs";
            this.cmdSaveMapJs.Size = new System.Drawing.Size(70, 30);
            this.cmdSaveMapJs.TabIndex = 17;
            this.cmdSaveMapJs.Text = "保存";
            this.cmdSaveMapJs.Click += new System.EventHandler(this.cmdSaveMapJs_Click);
            // 
            // lblReduceFunction
            // 
            this.lblReduceFunction.AutoSize = true;
            this.lblReduceFunction.BackColor = System.Drawing.Color.Transparent;
            this.lblReduceFunction.Location = new System.Drawing.Point(32, 244);
            this.lblReduceFunction.Name = "lblReduceFunction";
            this.lblReduceFunction.Size = new System.Drawing.Size(69, 13);
            this.lblReduceFunction.TabIndex = 16;
            this.lblReduceFunction.Text = "Reduce函数";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Location = new System.Drawing.Point(330, 11);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(31, 13);
            this.lblResult.TabIndex = 15;
            this.lblResult.Text = "结果";
            // 
            // lblMapFunction
            // 
            this.lblMapFunction.AutoSize = true;
            this.lblMapFunction.BackColor = System.Drawing.Color.Transparent;
            this.lblMapFunction.Location = new System.Drawing.Point(32, 31);
            this.lblMapFunction.Name = "lblMapFunction";
            this.lblMapFunction.Size = new System.Drawing.Size(52, 13);
            this.lblMapFunction.TabIndex = 14;
            this.lblMapFunction.Text = "Map函数";
            // 
            // trvResult
            // 
            this.trvResult.Location = new System.Drawing.Point(333, 28);
            this.trvResult.Name = "trvResult";
            this.trvResult.Size = new System.Drawing.Size(363, 404);
            this.trvResult.TabIndex = 13;
            // 
            // txtMapJs
            // 
            this.txtMapJs.Location = new System.Drawing.Point(28, 55);
            this.txtMapJs.Multiline = true;
            this.txtMapJs.Name = "txtMapJs";
            this.txtMapJs.Size = new System.Drawing.Size(299, 172);
            this.txtMapJs.TabIndex = 12;
            // 
            // txtReduceJs
            // 
            this.txtReduceJs.Location = new System.Drawing.Point(28, 263);
            this.txtReduceJs.Multiline = true;
            this.txtReduceJs.Name = "txtReduceJs";
            this.txtReduceJs.Size = new System.Drawing.Size(299, 169);
            this.txtReduceJs.TabIndex = 11;
            // 
            // cmdRun
            // 
            this.cmdRun.BackColor = System.Drawing.Color.Transparent;
            this.cmdRun.Location = new System.Drawing.Point(621, 438);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(75, 34);
            this.cmdRun.TabIndex = 10;
            this.cmdRun.Text = "运行";
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // frmMapReduce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 552);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMapReduce";
            this.ShowSelectSkinButton = false;
            this.Text = "frmMapReduce";
            this.Load += new System.EventHandler(this.frmMapReduce_Load);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbForMap;
        private System.Windows.Forms.ComboBox cmbForReduce;
        private System.Windows.Forms.VistaButton cmdSaveReduceJs;
        private System.Windows.Forms.VistaButton cmdSaveMapJs;
        private System.Windows.Forms.Label lblReduceFunction;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblMapFunction;
        private System.Windows.Forms.TreeView trvResult;
        private System.Windows.Forms.TextBox txtMapJs;
        private System.Windows.Forms.TextBox txtReduceJs;
        private System.Windows.Forms.VistaButton cmdRun;
    }
}