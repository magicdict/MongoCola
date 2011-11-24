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
        /// <summary>
        /// 返回结果
        /// </summary>
        public Boolean Result;
        /// <summary>
        /// 
        /// </summary>
        public frmConfirm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Yes按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdYes_Click(object sender, EventArgs e)
        {
            Result = true;
            this.Close();
        }
        /// <summary>
        /// No按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdNo_Click(object sender, EventArgs e)
        {
            Result = false;
            this.Close();
        }
        /// <summary>
        /// 设定消息
        /// </summary>
        /// <param name="strMessage"></param>
        public void SetMessage(String strMessage)
        {
            this.lblMessage.Text = strMessage;
        }
        /// <summary>
        /// 设置YES NO 文字
        /// </summary>
        /// <param name="Yes"></param>
        /// <param name="No"></param>
        public void SetText(String Yes,String No) {
            cmdYes.Text = Yes;
            cmdNo.Text = No;
        }
    }
}
