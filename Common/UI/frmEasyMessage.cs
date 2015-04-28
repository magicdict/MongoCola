using ResourceLib.Utility;
using System;
using System.Windows.Forms;

namespace Common.UI
{
    public partial class frmEasyMessage : Form
    {
        public frmEasyMessage()
        {
            InitializeComponent();
            GUIConfig.Translateform(this);
        }

        /// <summary>
        ///     SetMessage
        /// </summary>
        /// <param name="Message"></param>
        internal void SetMessage(string Message)
        {
            lblMessage.Text = Message;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}