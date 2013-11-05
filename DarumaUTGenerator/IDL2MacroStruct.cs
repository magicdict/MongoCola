using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DarumaUTGenerator
{
    class IDL2MacroStruct : IDL2PgmStruct
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
            /// 分类
            /// </summary>
            public String Speics;
        }
        public List<List<KeyValue>> PattenList = new List<List<KeyValue>>();
        public struct KeyValue
        {
            public String Key;
            public String Value;
        }
        public List<Parm> Parmlst = new List<Parm>();
        /// <summary>
        /// 模式分析
        /// </summary>
        public void Pattern()
        {
            PattenList = new List<List<KeyValue>>();
            StreamReader sr = new StreamReader(@"C:\Daruma\Tools\Garb2\パラメータ有_部品呼出し一覧_20130724.txt", System.Text.Encoding.GetEncoding(932));
            String source = string.Empty;
            while (!sr.EndOfStream)
            {
                source = sr.ReadLine();
                source = source.Trim();
                if (source.StartsWith("@ZGIMSCHK") || source.StartsWith("#ZGIMSCHK"))
                {
                    String strPattern = String.Empty;
                    strPattern = source.Substring(source.IndexOf("(") + 1, source.Length - source.IndexOf("(") - 2);
                    List<KeyValue> Pattern = new List<KeyValue>();
                    String[] Keylst = strPattern.Split(",".ToCharArray());
                    foreach (var keySet in Keylst)
                    {
                        if (keySet.Contains("="))
                        {
                            Pattern.Add(new KeyValue() { Key = keySet.Substring(0, keySet.IndexOf("=")), Value = keySet.Substring(keySet.IndexOf("=") + 1) });
                        }
                    }
                    PattenList.Add(Pattern);
                }
            }
            sr.Close();
        }
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
            String Sp = String.Empty;
            while (!sr.EndOfStream)
            {
                source = sr.ReadLine();
                source = source.Trim();
                if (source.Equals("#END-PARAM") || source.Equals("#END-VAR") || source.Equals("#END-KEYPARAM"))
                {
                    IsParmPickOn = false;
                }
                if (IsParmPickOn)
                {
                    while (source.Contains("  "))
                    {
                        source = source.Replace("  ", " ");
                    }
                    if (!source.StartsWith("#"))
                        Parmlst.Add(new Parm() { Name = source.Split(" ".ToCharArray())[1], Type = source.Split(" ".ToCharArray())[0], Speics = Sp });
                }
                switch (source)
                {
                    case "#PARAM":
                        IsParmPickOn = true;
                        Sp = source;
                        break;
                    case "#VAR":
                        IsParmPickOn = true;
                        Sp = source;
                        break;
                    case "#KEYPARAM":
                        IsParmPickOn = true;
                        Sp = source;
                        break;
                }
            }
            sr.Close();
        }
    }
}
