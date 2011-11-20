using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUIResource;
namespace QLFUI
{
    public partial class frmConfirm : QLFForm
    {
        public Boolean Result;        
        public frmConfirm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Yes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdYes_Click(object sender, EventArgs e)
        {
            Result = true;
            this.Close();
        }
        /// <summary>
        /// No
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdNo_Click(object sender, EventArgs e)
        {
            Result = false;
            this.Close();
        }
        private void frmconfirm_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 设定消息
        /// </summary>
        /// <param name="strMessage"></param>
        public void SetMessage(String strMessage)
        {
            this.lblMessage.Text = strMessage;
        }
    }
}
