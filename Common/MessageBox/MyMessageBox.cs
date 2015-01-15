using System;
using System.Drawing;
using System.Windows.Forms;
using ResourceLib;

namespace Common
{
    public static class MyMessageBox
    {
        /// <summary>
        ///     消息窗体
        /// </summary>
        private static readonly frmMesssage _frmMessage = new frmMesssage();

        /// <summary>
        ///     消息窗体
        /// </summary>
        private static readonly frmEasyMessage _frmEasyMessage = new frmEasyMessage();

        /// <summary>
        ///     确认窗体
        /// </summary>
        private static readonly frmConfirm _frmConfirm = new frmConfirm();

        /// <summary>
        ///     输入
        /// </summary>
        private static readonly frmInputBox _frmInputBox = new frmInputBox();

        /// <summary>
        ///     语言切换
        /// </summary>
        public static void SwitchLanguage()
        {
            _frmConfirm.SetText(Utility.guiconfig.GetText("Yes", StringResource.TextType.Common_Yes),
                Utility.guiconfig.GetText("No", StringResource.TextType.Common_No));
            _frmMessage.SetText(Utility.guiconfig.GetText("Detail", StringResource.TextType.Common_Detail),
                Utility.guiconfig.GetText("OK", StringResource.TextType.Common_OK));
            _frmInputBox.SetText(Utility.guiconfig.GetText("Cancel", StringResource.TextType.Common_Cancel),
                Utility.guiconfig.GetText("OK", StringResource.TextType.Common_OK));
            _frmEasyMessage.SetText(Utility.guiconfig.GetText("OK", StringResource.TextType.Common_OK));
        }

        /// <summary>
        ///     确认信息表示
        /// </summary>
        public static String ShowInput(String Message, String Title, String DefaultValue = "")
        {
            _frmInputBox.Text = Title;
            _frmInputBox.SetMessage(Message, DefaultValue);
            _frmInputBox.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (_frmInputBox.Visible == false)
            {
                _frmInputBox.ShowDialog();
            }
            return _frmInputBox.Result;
        }

        /// <summary>
        ///     确认信息表示
        /// </summary>
        public static Boolean ShowConfirm(String Title, String Message)
        {
            _frmConfirm.Text = Title;
            _frmConfirm.SetMessage(Message);
            _frmConfirm.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (_frmConfirm.Visible == false)
            {
                _frmConfirm.ShowDialog();
            }
            return _frmConfirm.Result;
        }

        public static void ShowMessage(String Title, String Message)
        {
            ShowMessage(Title, Message, String.Empty);
        }

        /// <summary>
        ///     消息表示
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Details"></param>
        public static void ShowMessage(String Title, String Message, String Details)
        {
            _frmMessage.Text = Title;
            _frmMessage.SetMessage(Message, Details, false);
            _frmMessage.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (_frmMessage.Visible == false)
            {
                _frmMessage.ShowDialog();
            }
        }

        /// <summary>
        ///     消息表示
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Details"></param>
        public static void ShowMessage(String Title, String Message, String Details, Boolean IsShowDetail)
        {
            _frmMessage.Text = Title;
            _frmMessage.SetMessage(Message, Details, IsShowDetail);
            _frmMessage.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (_frmMessage.Visible == false)
            {
                _frmMessage.ShowDialog();
            }
        }

        /// <summary>
        ///     消息表示
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Details"></param>
        public static void ShowMessage(String Title, String Message, Image img, String Details)
        {
            _frmMessage.Text = Title;
            _frmMessage.SetMessage(Message, img, Details);
            _frmMessage.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (_frmMessage.Visible == false)
            {
                _frmMessage.ShowDialog();
            }
        }

        /// <summary>
        ///     消息表示
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Message"></param>
        public static void ShowEasyMessage(String Title, String Message)
        {
            _frmEasyMessage.Text = Title;
            _frmEasyMessage.SetMessage(Message);
            _frmEasyMessage.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (_frmMessage.Visible == false)
            {
                _frmEasyMessage.ShowDialog();
            }
        }
    }
}