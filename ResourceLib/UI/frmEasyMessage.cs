using System;
using System.Windows.Forms;
using ResourceLib.Method;

namespace ResourceLib.UI
{
    public partial class FrmEasyMessage : Form
    {
        public FrmEasyMessage()
        {
            InitializeComponent();
            GuiConfig.Translateform(this);
        }

        /// <summary>
        ///     SetMessage
        /// </summary>
        /// <param name="message"></param>
        internal void SetMessage(string message)
        {
            lblMessage.Text = message;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}