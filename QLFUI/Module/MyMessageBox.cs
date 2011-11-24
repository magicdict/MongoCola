using System;
using System.Drawing;
using GUIResource;
namespace QLFUI
{
    public static class MyMessageBox
    {
        /// <summary>
        /// 语言切换
        /// </summary>
        /// <param name="mString"></param>
        public static void SwitchLanguage(StringResource mString) {
            _frmConfirm.SetText(mString.GetText(StringResource.TextType.Common_Yes), mString.GetText(StringResource.TextType.Common_No));
            _frmMessage.SetText(mString.GetText(StringResource.TextType.Common_Detail), mString.GetText(StringResource.TextType.Common_OK));
        }
        /// <summary>
        /// 消息窗体
        /// </summary>
        private static frmMesssage _frmMessage = new frmMesssage();
        /// <summary>
        /// 消息窗体
        /// </summary>
        private static frmConfirm _frmConfirm = new frmConfirm();
        /// <summary>
        /// 确认信息
        /// </summary>
        public static Boolean ShowConfirm(String Title, String Message)
        {
            _frmConfirm.Text = Title;
            _frmConfirm.SetMessage(Message);
            _frmConfirm.ShowDialog();
            return _frmConfirm.Result;
        }
        /// <summary>
        /// 消息表示
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Details"></param>
        public static void ShowMessage(String Title, String Message, String Details = "")
        {
            _frmMessage.Text = Title;
            _frmMessage.SetMessage(Message, Details, false);
            _frmMessage.ShowDialog();
        }
        /// <summary>
        /// 消息表示
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Details"></param>
        public static void ShowMessage(String Title, String Message, String Details, Boolean IsShowDetail)
        {
            _frmMessage.Text = Title;
            _frmMessage.SetMessage(Message, Details, IsShowDetail);
            _frmMessage.ShowDialog();
        }
        /// <summary>
        /// 消息表示
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Details"></param>
        public static void ShowMessage(String Title, String Message, Image img, String Details = "")
        {
            _frmMessage.Text = Title;
            _frmMessage.SetMessage(Message, img, Details);
            _frmMessage.ShowDialog();
        }
    }
}
