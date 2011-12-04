using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLFUI
{
    public partial class frmInputBox : QLFForm
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public String Result = String.Empty;
        public frmInputBox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设置文字
        /// </summary>
        /// <param name="Cancel"></param>
        /// <param name="OK"></param>
        public void SetText(String Cancel, String OK)
        {
            cmdCancel.Text = Cancel;
            cmdOK.Text = OK;
        }

        internal void SetMessage(string Message)
        {
            lblMessage.Text = Message;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Result = txtResult.Text;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Result = String.Empty;
            this.Close();
        }
    }
}
