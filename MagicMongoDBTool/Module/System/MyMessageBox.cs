using System;
using System.Drawing;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public static class MyMessageBox
    {
        /// <summary>
        /// 语言切换
        /// </summary>
        /// <param name="mString"></param>
        public static void SwitchLanguage(StringResource mString)
        {
            _frmConfirm.SetText(mString.GetText(StringResource.TextType.Common_Yes), mString.GetText(StringResource.TextType.Common_No));
            _frmMessage.SetText(mString.GetText(StringResource.TextType.Common_Detail), mString.GetText(StringResource.TextType.Common_OK));
            _frmInputBox.SetText(mString.GetText(StringResource.TextType.Common_Cancel), mString.GetText(StringResource.TextType.Common_OK));
            _frmEasyMessage.SetText(mString.GetText(StringResource.TextType.Common_OK));
        }
        /// <summary>
        /// 消息窗体
        /// </summary>
        private static frmMesssage _frmMessage = new frmMesssage();
        /// <summary>
        /// 消息窗体
        /// </summary>
        private static frmEasyMessage _frmEasyMessage = new frmEasyMessage();
        /// <summary>
        /// 确认窗体
        /// </summary>
        private static frmConfirm _frmConfirm = new frmConfirm();
        /// <summary>
        /// 输入
        /// </summary>
        private static frmInputBox _frmInputBox = new frmInputBox();

        /// <summary>
        /// 确认信息表示
        /// </summary>
        public static String ShowInput(String Message, String Title)
        {
            _frmInputBox.Text = Title;
            _frmInputBox.SetMessage(Message);
            if (_frmInputBox.Visible == false)
            {
                _frmInputBox.ShowDialog();
            }
            return _frmInputBox.Result;
        }
        /// <summary>
        /// 确认信息表示
        /// </summary>
        public static Boolean ShowConfirm(String Title, String Message)
        {
            _frmConfirm.Text = Title;
            _frmConfirm.SetMessage(Message);
            if (_frmConfirm.Visible == false)
            {
                _frmConfirm.ShowDialog();
            }
            return _frmConfirm.Result;
        }
        public static void ShowMessage(String Title, String Message) {
            ShowMessage(Title, Message, String.Empty);
        }
        /// <summary>
        /// 消息表示
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Details"></param>
        public static void ShowMessage(String Title, String Message, String Details)
        {
            _frmMessage.Text = Title;
            _frmMessage.SetMessage(Message, Details, false);
            if (_frmMessage.Visible == false)
            {
                _frmMessage.ShowDialog();
            }
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
            if (_frmMessage.Visible == false)
            {
                _frmMessage.ShowDialog();
            }
        }
        /// <summary>
        /// 消息表示
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Details"></param>
        public static void ShowMessage(String Title, String Message, Image img, String Details)
        {
            _frmMessage.Text = Title;
            _frmMessage.SetMessage(Message, img, Details);
            if (_frmMessage.Visible == false)
            {
                _frmMessage.ShowDialog();
            }
        }
        /// <summary>
        /// 消息表示
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Details"></param>
        public static void ShowEasyMessage(String Title, String Message)
        {
            _frmEasyMessage.Text = Title;
            _frmEasyMessage.SetMessage(Message);
            if (_frmMessage.Visible == false)
            {
                _frmEasyMessage.ShowDialog();
            }
        }
    }
}
