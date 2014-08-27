using System;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public static class Utility
    {
        /// <summary>
        /// 获得可以插入数据库的Request
        /// </summary>
        /// <param name="org"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRequestString(this string org, int length)
        {
            if (string.IsNullOrEmpty(org)) return string.Empty;
            if (org.Length <= length) return org;
            return org.Substring(0, length);
        }
        /// <summary>
        /// 获得时间戳作为ID
        /// </summary>
        /// <returns></returns>
        public static string GernerateIdByTime()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssff");
        }
        /// <summary>
        /// 通过contentType获得文件扩展名
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static string GetExtendByContentType(String contentType)
        {
            string extension = string.Empty;
            switch (contentType)
            {
                case  "image/jpeg":
                    extension = "JPEG";
                    break;
                case  "image/png":
                    extension = "PNG";
                    break;
                case "image/bmp":
                    extension = "BMP";
                    break;
                case "image/gif":
                    extension = "GIF";
                    break;
            }
            return extension;
        }
        /// <summary>  
        /// MD5 加密字符串  
        /// </summary>  
        /// <param name="rawPass">源字符串</param>  
        /// <returns>加密后字符串</returns>  
        public static string Md5Encoding(string rawPass)
        {
            // 创建MD5类的默认实例：MD5CryptoServiceProvider  
            MD5 md5 = MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(rawPass);
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hs)
            {
                // 以十六进制格式格式化  
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }  
    }
}
