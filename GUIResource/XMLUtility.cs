using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GUIResource
{
    class XMLUtility
    {
        public static string XMLDecode(string str)
        {
            return str.Replace("&amp;","&");
        }
    }
}
