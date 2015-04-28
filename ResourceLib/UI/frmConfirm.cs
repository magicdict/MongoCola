using System;
using System.Windows.Forms;
using ResourceLib.Method;

namespace ResourceLib.UI
{
    public partial class FrmConfirm : Form
    {
        /// <summary>
        ///     Return Result
        /// </summary>
        internal bool Result;

        /// <summary>
        ///     Init Form
        /// </summary>
        public FrmConfirm()
        {
            InitializeComponent();
            GuiConfig.Translateform(this);
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
        internal void SetMessage(string strMessage)
        {
            Result = false;
            lblMessage.Text = strMessage;
        }
    }
}