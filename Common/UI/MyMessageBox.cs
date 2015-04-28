using System;
using System.Drawing;
using System.Windows.Forms;
using Common.Logic;
using ResourceLib.Utility;

namespace Common.UI
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
        ///     确认信息表示
        /// </summary>
        public static string ShowInput(string Message, string Title, string DefaultValue = "")
        {
            FormatMsgbox(_frmInputBox, Title);
            _frmInputBox.SetMessage(Message, DefaultValue);
            if (_frmInputBox.Visible == false)
            {
                _frmInputBox.ShowDialog();
            }
            return _frmInputBox.Result;
        }

        /// <summary>
        ///     确认信息表示
        /// </summary>
        public static bool ShowConfirm(string Title, string Message)
        {
            FormatMsgbox(_frmConfirm, Title);
            _frmConfirm.SetMessage(Message);
            if (_frmConfirm.Visible == false)
            {
                _frmConfirm.ShowDialog();
            }
            return _frmConfirm.Result;
        }

        private static void FormatMsgbox(Form _frmMsgbox, string Title)
        {
            _frmMsgbox.Text = Title;
            try
            {
                _frmMsgbox.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            }
            catch (Exception)
            {
                //线程间调用出错的屏蔽
            }
            _frmMsgbox.Font = new Font("微软雅黑", 9);
        }

        public static void ShowMessage(string Title, string Message)
        {
            ShowMessage(Title, Message, string.Empty);
        }

        /// <summary>
        ///     消息表示
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Details"></param>
        public static void ShowMessage(string Title, string Message, string Details)
        {
            FormatMsgbox(_frmMessage, Title);
            _frmMessage.SetMessage(Message, Details, false);
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
        public static void ShowMessage(string Title, string Message, string Details, bool IsShowDetail)
        {
            FormatMsgbox(_frmMessage, Title);
            _frmMessage.SetMessage(Message, Details, IsShowDetail);
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
        public static void ShowMessage(string Title, string Message, Image img, string Details)
        {
            FormatMsgbox(_frmMessage, Title);
            _frmMessage.SetMessage(Message, img, Details);
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
        public static void ShowEasyMessage(string Title, string Message)
        {
            FormatMsgbox(_frmEasyMessage, Title);
            _frmEasyMessage.SetMessage(Message);
            if (_frmMessage.Visible == false)
            {
                _frmEasyMessage.ShowDialog();
            }
        }
    }
}