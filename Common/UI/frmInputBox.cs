using ResourceLib;
using System;
using System.Windows.Forms;

namespace Common.UI
{
    public partial class frmInputBox : Form
    {
        /// <summary>
        ///     return result
        /// </summary>
        internal string Result = string.Empty;

        /// <summary>
        ///     Init
        /// </summary>
        internal frmInputBox()
        {
            InitializeComponent();
            GUIConfig.Translateform(this);
        }

        /// <summary>
        ///     Set Text of OK,Cancel Button
        /// </summary>
        /// <param name="cancel"></param>
        /// <param name="OK"></param>
        internal void SetText(string cancel, string OK)
        {
            cmdCancel.Text = cancel;
            cmdOK.Text = OK;
        }

        /// <summary>
        ///     Set Message
        /// </summary>
        /// <param name="message"></param>
        internal void SetMessage(string message, string DefaultValue)
        {
            lblMessage.Text = message;
            txtResult.Text = DefaultValue;
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