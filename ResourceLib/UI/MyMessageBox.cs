using System;
using System.Drawing;
using System.Windows.Forms;

namespace ResourceLib.UI
{
    public static class MyMessageBox
    {
        /// <summary>
        ///     消息窗体
        /// </summary>
        private static readonly frmMesssage FrmMessage = new frmMesssage();

        /// <summary>
        ///     消息窗体
        /// </summary>
        private static readonly FrmEasyMessage FrmEasyMessage = new FrmEasyMessage();

        /// <summary>
        ///     确认窗体
        /// </summary>
        private static readonly FrmConfirm FrmConfirm = new FrmConfirm();

        /// <summary>
        ///     输入
        /// </summary>
        private static readonly FrmInputBox FrmInputBox = new FrmInputBox();


        /// <summary>
        ///     密码输入
        /// </summary>
        private static readonly frmPasswordInputBox FrmPasswordInputBox = new frmPasswordInputBox();

        /// <summary>
        ///     输入表示
        /// </summary>
        public static string ShowInput(string message, string title, string defaultValue = "")
        {
            FormatMsgbox(FrmInputBox, title);
            FrmInputBox.SetMessage(message, defaultValue);
            if (FrmInputBox.Visible == false)
            {
                FrmInputBox.ShowDialog();
            }
            return FrmInputBox.Result;
        }

        /// <summary>
        ///     密码输入表示
        /// </summary>
        public static string ShowPasswordInput(string message, string title, string defaultValue = "")
        {
            FormatMsgbox(FrmPasswordInputBox, title);
            FrmPasswordInputBox.SetMessage(message, defaultValue);
            if (FrmPasswordInputBox.Visible == false)
            {
                FrmPasswordInputBox.ShowDialog();
            }
            return FrmPasswordInputBox.Result;
        }

        /// <summary>
        ///     确认信息表示
        /// </summary>
        public static bool ShowConfirm(string title, string message)
        {
            FormatMsgbox(FrmConfirm, title);
            FrmConfirm.SetMessage(message);
            if (FrmConfirm.Visible == false)
            {
                FrmConfirm.ShowDialog();
            }
            return FrmConfirm.Result;
        }

        private static void FormatMsgbox(Form frmMsgbox, string title)
        {
            frmMsgbox.Text = title;
            try
            {
                frmMsgbox.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            }
            catch (Exception)
            {
                //线程间调用出错的屏蔽
            }
            frmMsgbox.Font = new Font("微软雅黑", 9);
        }

        public static void ShowMessage(string title, string message)
        {
            ShowMessage(title, message, string.Empty);
        }

        /// <summary>
        ///     消息表示
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public static void ShowMessage(string title, string message, string details)
        {
            FormatMsgbox(FrmMessage, title);
            FrmMessage.SetMessage(message, details, false);
            if (!FrmMessage.Visible)
            {
                FrmMessage.ShowDialog();
            }
        }

        /// <summary>
        ///     消息表示
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public static void ShowMessage(string title, string message, string details, bool isShowDetail)
        {
            FormatMsgbox(FrmMessage, title);
            FrmMessage.SetMessage(message, details, isShowDetail);
            if (!FrmMessage.Visible)
            {
                FrmMessage.ShowDialog();
            }
        }

        /// <summary>
        ///     消息表示
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public static void ShowMessage(string title, string message, Image img, string details)
        {
            FormatMsgbox(FrmMessage, title);
            FrmMessage.SetMessage(message, img, details);
            if (!FrmMessage.Visible)
            {
                FrmMessage.ShowDialog();
            }
        }

        /// <summary>
        ///     消息表示
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        public static void ShowEasyMessage(string title, string message)
        {
            FormatMsgbox(FrmEasyMessage, title);
            FrmEasyMessage.SetMessage(message);
            if (!FrmMessage.Visible)
            {
                FrmEasyMessage.ShowDialog();
            }
        }
    }
}