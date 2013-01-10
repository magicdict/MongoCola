using System;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmInputBox : Form
    {
        /// <summary>
        /// return result
        /// </summary>
        internal String Result = String.Empty;
        /// <summary>
        /// Init
        /// </summary>
        internal frmInputBox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Set Text of OK,Cancel Button
        /// </summary>
        /// <param name="Cancel"></param>
        /// <param name="OK"></param>
        internal void SetText(String Cancel, String OK)
        {
            cmdCancel.Text = Cancel;
            cmdOK.Text = OK;
        }
        /// <summary>
        /// Set Message
        /// </summary>
        /// <param name="Message"></param>
        internal void SetMessage(String Message,String DefaultValue)
        {
            lblMessage.Text = Message;
            this.txtResult.Text = DefaultValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            Result = txtResult.Text;
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Result = String.Empty;
            this.Close();
        }
    }
}
