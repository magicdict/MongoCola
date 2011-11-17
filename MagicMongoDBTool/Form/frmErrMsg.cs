using System;

namespace MagicMongoDBTool
{
    public partial class frmErrMsg : QLFUI.QLFForm
    {
        /// <summary>
        /// 是否显示细节
        /// </summary>
        Boolean _ShowDetails = false;
        /// <summary>
        /// 表示信息
        /// </summary>
        /// <param name="Message">信息</param>
        /// <param name="Details">细节</param>
        /// <param name="IsShowDetails">是否显示细节</param>
        public void SetMessage(String Message,String Details,Boolean IsShowDetails = true) {
            this.lblMessage.Text = Message;
            this.txtException.Text = Details;
            this.txtException.Select(0, 0);
            if (Details == String.Empty) {
                IsShowDetails = false;
            }
            _ShowDetails = IsShowDetails;
            if (_ShowDetails)
            {
                this.Height = 350;
            }
            else
            {
                this.Height = 168;
            }
        }
        public frmErrMsg()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 切换细节
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDetails_Click(object sender, EventArgs e)
        {
            if (_ShowDetails)
            {
                this.Height = 168;
            }
            else {
                this.Height = 350;
            }
            _ShowDetails = !_ShowDetails;
        }

        internal void SetMessage(string Message, System.Drawing.Image img, string Details)
        {
            this.picImage.Image = img;
            SetMessage(Message, Details);
        }
    }
}
