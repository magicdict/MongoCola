using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GUIResource
{
    /// <summary>
    /// XML工具
    /// </summary>
    class XMLUtility
    {
        /// <summary>
        /// XML解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string XMLDecode(string str)
        {
            return str.Replace("&amp;","&");
        }
    }
}
