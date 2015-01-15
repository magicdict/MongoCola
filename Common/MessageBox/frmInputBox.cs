using System;
using System.Windows.Forms;

namespace Common
{
    public partial class frmInputBox : Form
    {
        /// <summary>
        ///     return result
        /// </summary>
        internal String Result = String.Empty;

        /// <summary>
        ///     Init
        /// </summary>
        internal frmInputBox()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Set Text of OK,Cancel Button
        /// </summary>
        /// <param name="cancel"></param>
        /// <param name="OK"></param>
        internal void SetText(String cancel, String OK)
        {
            cmdCancel.Text = cancel;
            cmdOK.Text = OK;
        }

        /// <summary>
        ///     Set Message
        /// </summary>
        /// <param name="message"></param>
        internal void SetMessage(String message, String DefaultValue)
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
            Result = String.Empty;
            Close();
        }
    }
}