namespace QLFUI
{
    partial class QLFForm
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
            this.components = new System.ComponentModel.Container();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.skinContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectSkinButton = new QLFUI.BaseButton();
            this.closeButton = new QLFUI.BaseButton();
            this.maxButton = new QLFUI.BaseButton();
            this.minButton = new QLFUI.BaseButton();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.contentPanel.Location = new System.Drawing.Point(62, 108);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(215, 202);
            this.contentPanel.TabIndex = 0;
            // 
            // skinContextMenu
            // 
            this.skinContextMenu.Name = "skinContextMenu";
            this.skinContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // selectSkinButton
            // 
            this.selectSkinButton.BackColor = System.Drawing.Color.Transparent;
            this.selectSkinButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectSkinButton.ContextMenuStrip = this.skinContextMenu;
            this.selectSkinButton.DownImage = null;
            this.selectSkinButton.Location = new System.Drawing.Point(181, 13);
            this.selectSkinButton.MoveImage = null;
            this.selectSkinButton.Name = "selectSkinButton";
            this.selectSkinButton.NormalImage = null;
            this.selectSkinButton.Size = new System.Drawing.Size(42, 38);
            this.selectSkinButton.TabIndex = 4;
            this.selectSkinButton.TranskeyColor = System.Drawing.Color.Empty;
            this.selectSkinButton.XOffset = 0;
            this.selectSkinButton.Click += new System.EventHandler(this.selectSkinButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.DownImage = null;
            this.closeButton.Location = new System.Drawing.Point(302, 13);
            this.closeButton.MoveImage = null;
            this.closeButton.Name = "closeButton";
            this.closeButton.NormalImage = null;
            this.closeButton.Size = new System.Drawing.Size(42, 38);
            this.closeButton.TabIndex = 1;
            this.closeButton.TranskeyColor = System.Drawing.Color.Empty;
            this.closeButton.XOffset = 0;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // maxButton
            // 
            this.maxButton.BackColor = System.Drawing.Color.Transparent;
            this.maxButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.maxButton.DownImage = null;
            this.maxButton.Location = new System.Drawing.Point(254, 13);
            this.maxButton.MoveImage = null;
            this.maxButton.Name = "maxButton";
            this.maxButton.NormalImage = null;
            this.maxButton.Size = new System.Drawing.Size(42, 38);
            this.maxButton.TabIndex = 3;
            this.maxButton.TranskeyColor = System.Drawing.Color.Empty;
            this.maxButton.XOffset = 0;
            this.maxButton.Click += new System.EventHandler(this.maxButton_Click);
            // 
            // minButton
            // 
            this.minButton.BackColor = System.Drawing.Color.Transparent;
            this.minButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minButton.DownImage = null;
            this.minButton.Location = new System.Drawing.Point(220, 13);
            this.minButton.MoveImage = null;
            this.minButton.Name = "minButton";
            this.minButton.NormalImage = null;
            this.minButton.Size = new System.Drawing.Size(42, 38);
            this.minButton.TabIndex = 2;
            this.minButton.TranskeyColor = System.Drawing.Color.Empty;
            this.minButton.XOffset = 0;
            this.minButton.Click += new System.EventHandler(this.minButton_Click);
            // 
            // QLFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(385, 323);
            this.Controls.Add(this.selectSkinButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.maxButton);
            this.Controls.Add(this.minButton);
            this.Controls.Add(this.contentPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QLFForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QLFForm";
            this.Load += new System.EventHandler(this.QLFForm_Load);
            this.Resize += new System.EventHandler(QLFForm_Resize);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.QLFForm_MouseDoubleClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.QLFForm_MouseMove);
            this.ResumeLayout(false);

        }



        #endregion

        protected System.Windows.Forms.Panel contentPanel;
        private BaseButton closeButton;
        private BaseButton minButton;
        private BaseButton maxButton;
        private BaseButton selectSkinButton;
        private System.Windows.Forms.ContextMenuStrip skinContextMenu;
    }
}