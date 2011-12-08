using System;
using System.Windows.Forms;
namespace MagicMongoDBTool
{
    public partial class frmConfirm : Form
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public Boolean Result = false;
        /// <summary>
        /// 初始化
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
            Result = false;
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
