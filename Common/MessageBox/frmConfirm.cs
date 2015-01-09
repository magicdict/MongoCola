using System;
using System.Windows.Forms;

namespace MongoCola
{
    public partial class frmConfirm : Form
    {
        /// <summary>
        ///     Return Result
        /// </summary>
        internal Boolean Result = false;

        /// <summary>
        ///     Init Form
        /// </summary>
        public frmConfirm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Yes is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdYes_Click(object sender, EventArgs e)
        {
            Result = true;
            Close();
        }

        /// <summary>
        ///     No is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdNo_Click(object sender, EventArgs e)
        {
            Result = false;
            Close();
        }

        /// <summary>
        ///     set the message
        /// </summary>
        /// <param name="strMessage"></param>
        internal void SetMessage(String strMessage)
        {
            Result = false;
            lblMessage.Text = strMessage;
        }

        /// <summary>
        ///     set the text of yes no button
        /// </summary>
        /// <param name="Yes"></param>
        /// <param name="No"></param>
        internal void SetText(String Yes, String No)
        {
            cmdYes.Text = Yes;
            cmdNo.Text = No;
        }
    }
}