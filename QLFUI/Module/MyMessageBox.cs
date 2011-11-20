using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MongoDB.Driver;

namespace QLFUI
{
    public static class MyMessageBox
    {
        /// <summary>
        /// 消息窗体
        /// </summary>
        private static frmMesssage _frmMessage;
        /// <summary>
        /// 消息窗体
        /// </summary>
        private static frmConfirm _frmConfirm;

        /// <summary>
        /// 确认信息
        /// </summary>
        public static Boolean ShowConfirm(String Title, String Message)
        {
            if (_frmConfirm == null)
            {
                _frmConfirm = new frmConfirm();
            }
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
            if (_frmMessage == null)
            {
                _frmMessage = new frmMesssage();
            }
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
            if (_frmMessage == null)
            {
                _frmMessage = new frmMesssage();
            }
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
            if (_frmMessage == null)
            {
                _frmMessage = new frmMesssage();
            }
            _frmMessage.Text = Title;
            _frmMessage.SetMessage(Message, img, Details);
            _frmMessage.ShowDialog();
        }
        /// <summary>
        /// 消息表示
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Details"></param>
        public static void ShowMessage(String Title, String Message, List<CommandResult> Resultlst)
        {
            if (_frmMessage == null)
            {
                _frmMessage = new frmMesssage();
            }
            _frmMessage.Text = Title;
            String Details = String.Empty;
            foreach (CommandResult item in Resultlst)
            {
                Details += item.ToString() + "\r\n";
            }
            _frmMessage.SetMessage(Message, Details);
            _frmMessage.ShowDialog();
        }
    }
}
