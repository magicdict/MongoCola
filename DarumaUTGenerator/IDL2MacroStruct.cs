using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DarumaUTGenerator
{
    class IDL2MacroStruct:IDL2PgmStruct
    {
        /// <summary>
        /// Macro参数
        /// </summary>
        public struct Parm
        {
            /// <summary>
            /// 名称
            /// </summary>
            public String Name;
            /// <summary>
            /// 类型
            /// </summary>
            public String Type;
            /// <summary>
            /// 默认值
            /// </summary>
            public String Default;
        }
        public List<Parm> Parmlst = new List<Parm>();
        /// <summary>
        /// 获得参数
        /// </summary>
        /// <param name="filename"></param>
        public void GetParm(String filename)
        {
            Parmlst = new List<Parm>();
            StreamReader sr = new StreamReader(filename, System.Text.Encoding.GetEncoding(932));
            String source;
            Boolean IsParmPickOn = false;
            while (!sr.EndOfStream)
            {
                source = sr.ReadLine();
                source = source.Trim();
                if (source.Equals("#END-PARAM") || source.Equals("#END-VAR"))
                {
                    IsParmPickOn = false;
                }
                if (IsParmPickOn) {
                    while (source.Contains("  "))
                    {
                        source = source.Replace("  ", " ");
                    }
                    if (!source.StartsWith("#"))
                    Parmlst.Add(new Parm() { Name = source.Split(" ".ToCharArray())[1], Type = source.Split(" ".ToCharArray())[0] , Default = String.Empty});
                }
                if (source.Equals("#PARAM") || source.Equals("#VAR"))
                {
                    IsParmPickOn = true;
                }
            }
            sr.Close();
        }
    }
}
