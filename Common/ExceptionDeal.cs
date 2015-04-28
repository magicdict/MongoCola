using System;
using System.IO;
using ResourceLib.UI;

namespace Common
{
    public static partial class Utility
    {
        #region"异常处理"

        public static string ExceptionAppendInfo = string.Empty;

        /// <summary>
        ///     异常处理
        /// </summary>
        /// <param name="ex">异常</param>
        public static void ExceptionDeal(Exception ex)
        {
            ExceptionDeal(ex, "Exception", "Exception");
        }

        /// <summary>
        ///     异常处理
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="message">消息</param>
        public static void ExceptionDeal(Exception ex, string message)
        {
            try
            {
                ExceptionDeal(ex, "Exception", message);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        /// <summary>
        ///     异常处理
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="title">标题</param>
        /// <param name="message">消息</param>
        public static void ExceptionDeal(Exception ex, string title, string message)
        {
            var exceptionString = string.Empty;
            if (!string.IsNullOrEmpty(ExceptionAppendInfo))
                exceptionString = ExceptionAppendInfo;
            exceptionString += ex.ToString();
            MyMessageBox.ShowMessage(title, message, exceptionString, true);
            ExceptionLog(exceptionString);
        }

        /// <summary>
        ///     错误日志
        /// </summary>
        /// <param name="exceptionString">异常文字</param>
        public static void ExceptionLog(string exceptionString)
        {
            var exLog = new StreamWriter("Exception.log", true);
            exLog.WriteLine("DateTime:" + DateTime.Now);
            exLog.WriteLine(exceptionString);
            exLog.Close();
        }

        /// <summary>
        ///     错误日志
        /// </summary>
        /// <param name="ex">异常对象</param>
        public static void ExceptionLog(Exception ex)
        {
            var exceptionString = string.Empty;
            //			ExceptionString = "MongoDB.Driver.DLL:" + MongoDbDriverVersion + Environment.NewLine;
            //			ExceptionString += "MongoDB.Bson.DLL:" + MongoDbBsonVersion + Environment.NewLine;
            exceptionString += ex.ToString();
            ExceptionLog(exceptionString);
        }

        #endregion
    }
}