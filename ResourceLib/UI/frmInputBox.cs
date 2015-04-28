using System;
using System.Windows.Forms;
using ResourceLib.Method;

namespace ResourceLib.UI
{
    public partial class FrmInputBox : Form
    {
        /// <summary>
        ///     return result
        /// </summary>
        internal string Result = string.Empty;

        /// <summary>
        ///     Init
        /// </summary>
        internal FrmInputBox()
        {
            InitializeComponent();
            GuiConfig.Translateform(this);
        }

        /// <summary>
        ///     Set Text of OK,Cancel Button
        /// </summary>
        /// <param name="cancel"></param>
        /// <param name="ok"></param>
        internal void SetText(string cancel, string ok)
        {
            cmdCancel.Text = cancel;
            cmdOK.Text = ok;
        }

        /// <summary>
        ///     Set Message
        /// </summary>
        /// <param name="message"></param>
        internal void SetMessage(string message, string defaultValue)
        {
            lblMessage.Text = message;
            txtResult.Text = defaultValue;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            Result = txtResult.Text;
            Close();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Result = string.Empty;
            Close();
        }
    }
}