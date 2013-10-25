using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.IO;

namespace DarumaTool
{
    public static class Utilty
    {
        /// <summary>
        /// 判断并且将ModuleName放入列表
        /// </summary>
        /// <param name="lstModule"></param>
        /// <param name="source"></param>
        public static void IsModuleName(List<String> lstModule, String source)
        {
            char t = source.Substring(0, 1).ToCharArray()[0];
            if (t >= "A".ToCharArray()[0] && t <= "Z".ToCharArray()[0])
            {
                if (!lstModule.Contains(source.Substring(0, 8)))
                {
                    lstModule.Add(source.Substring(0, 8));
                }
            }
        }
        /// <summary>
        /// 将字符列表转成字符数组
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static String GetArrayString(List<string> list)
        {
            String ArrayString = String.Empty;
            foreach (var item in list)
            {
                ArrayString += item + "|";
            }
            if (ArrayString != String.Empty)
            {
                ArrayString.TrimEnd("|".ToCharArray());
            }
            return ArrayString;
        }
        /// <summary>
        /// 获得文本文件的行数
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static int getLines(string filename)
        {
            StreamReader sr = new StreamReader(filename, System.Text.Encoding.Default);
            int i = 0;
            while (sr.ReadLine() != null)
            {
                i++;
            }
            return i;
        }
        /// <summary>
        /// 获得Module一览列表
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static List<String> getCallModule(String filename)
        {
            List<String> lstModule = new List<string>();
            StreamReader sr = new StreamReader(filename, System.Text.Encoding.Default);
            String source;
            while (!sr.EndOfStream)
            {
                source = sr.ReadLine();
                source = source.Trim();
                if (source.StartsWith("CALL ") || source.StartsWith("PROC "))
                {
                    //CALL AAA  是程序
                    //CALL 日本语  不是程序
                    source = source.Substring(4).Trim();
                    Utilty.IsModuleName(lstModule, source);
                }
                else
                {
                    //END-OUTPUT : PROC KHXJYUUP(ＫＨＸＪＹＵＵＰ入出力域) .
                    if (source.Contains(" : PROC "))
                    {
                        source = source.Substring(source.IndexOf(" : PROC ") + 8).Trim();
                        Utilty.IsModuleName(lstModule, source);
                    }
                }
            }
            return lstModule;
        }
        /// <summary>
        /// 获得Macro一览列表
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static List<String> getCallMacro(String filename)
        {
            List<String> lstMacro = new List<string>();
            StreamReader sr = new StreamReader(filename, System.Text.Encoding.Default);
            String source;
            while (!sr.EndOfStream)
            {
                source = sr.ReadLine();
                source = source.Trim();
                if (source.StartsWith("@"))
                {
                    if (source.Contains("("))
                    {
                        if (!lstMacro.Contains(source.Substring(0, source.IndexOf("("))))
                        {
                            lstMacro.Add(source.Substring(0, source.IndexOf("(")));
                        }
                    }
                    else
                    {
                        if (!lstMacro.Contains(source))
                        {
                            lstMacro.Add(source);
                        }
                    }
                }
            }
            return lstMacro;
        }
        public class MarcoPatter
        {
            [BsonId]
            public String MacroName;
            public List<MacroPatterDetail> MacroPatterDetailList;
            public int count;
            public int MaxParaCount;
        }
        public class MacroPatterDetail
        {
            public string Pattern;
            public List<String> Para;
            public String PatternKey;
        }
        /// <summary>
        /// 参数排序
        /// </summary>
        /// <param name="Patternlst"></param>
        /// <returns></returns>
        public static int SortParm(List<MacroPatterDetail> Patternlst)
        {
            //Found the MaxLength
            int MaxLength = 0;
            foreach (var item in Patternlst)
            {
                if (item.PatternKey.Length > MaxLength)
                {
                    if (item.PatternKey != "0")
                    {
                        MaxLength = item.PatternKey.Length;
                    }
                }
            }
            foreach (var item in Patternlst)
            {
                item.PatternKey = (item.PatternKey + "0000000000000000000000").Substring(0, MaxLength);
            }
            Patternlst.Sort(new Comparison<MacroPatterDetail>((x, y) =>
            {
                if (x != y)
                {
                    return x.PatternKey.CompareTo(y.PatternKey);
                }
                else
                {
                    return x.Pattern.CompareTo(y.Pattern);
                }
            }));
            return MaxLength;
        }
        /// <summary>
        /// Linkage获得
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static List<string> getLinkage(string filename)
        {
            StreamReader sr = new StreamReader(filename, System.Text.Encoding.Default);
            String SourceLine = String.Empty;
            List<string> linkage = new List<string>();
            Boolean InLink = false;
            while (!sr.EndOfStream)
            {
                if (SourceLine == " LINKAGE. ")
                {
                    InLink = true;
                }
                if (SourceLine == " WORK. ")
                {
                    break;
                }
                if (InLink)
                {
                    SourceLine = SourceLine.Trim();
                    //01  バッチジョブ制御共通情報.
                    if (SourceLine.StartsWith("01 "))
                    {
                        SourceLine = SourceLine.Substring(4, SourceLine.Length - 5);
                        if (SourceLine.Contains(" "))
                        {
                            SourceLine = SourceLine.Substring(0, SourceLine.IndexOf(" "));
                        }
                        linkage.Add(SourceLine);
                    }
                }
                SourceLine = sr.ReadLine();
            }
            sr.Close();
            return linkage;
        }
        /// <summary>
        /// Copy句的获得
        /// </summary>
        /// <param name="PgmCopy"></param>
        /// <param name="IDWFile"></param>
        /// <param name="PgmID"></param>
        /// <param name="HasLineNo"></param>
        /// <param name="CopyHash"></param>
        public static void GetCopy(Dictionary<String, HashSet<String>> PgmCopy, String IDWFile, String PgmID, Boolean HasLineNo, HashSet<String> CopyHash)
        {
            String strREC = string.Empty;
            String MacroName = string.Empty;
            String CopyName = string.Empty;
            Stack<String> CallModuleStack = new Stack<string>();
            const String CopyMark = "*--C STA-COPY";
            const String MacroStartMark = "*--M STA-MAC";
            const String MacroEndMark = "*--M END-MAC";
            const String SubMacroStartMark = "*--M #";
            const String SubMacroEndMark = "*--M**IPO-MACRO-END----------------------------------- ";
            const String MacroStartMark_Data = "*==M DATA STA-MAC  ";
            const String MacroEndMark_Data = "*==M DATA END-MAC  ";
            const String MacroStartMark_WorkData = "*==  WORK DATA FROM MAC=";
            const String MacroEndMark_WorkData = "*==  WORK DATA END";
            CallModuleStack.Push(PgmID);
            StreamReader sr = new StreamReader(IDWFile, System.Text.Encoding.Default);
            while (!sr.EndOfStream)
            {
                //READ
                strREC = sr.ReadLine();
                if (HasLineNo)
                {
                    strREC = strREC.Substring(8);
                }
                //*--C STA-COPY MC_RK_IDN_FIX
                if (strREC.StartsWith(CopyMark))
                {
                    CopyName = strREC.Substring(CopyMark.Length + 1);
                    if (CopyName.Contains(" "))
                    {
                        //*--C STA-COPY MC_RK_TAN_FIX option= PREFIX(ＺＧ)
                        CopyName = CopyName.Substring(0, CopyName.IndexOf(" "));
                    }
                    MacroName = CallModuleStack.Peek();
                    if (!CopyHash.Contains(MacroName + ":" + CopyName))
                    {
                        if (PgmCopy.ContainsKey(MacroName))
                        {
                            if (!PgmCopy[MacroName].Contains(CopyName))
                            {
                                PgmCopy[MacroName].Add(CopyName);
                            }
                        }
                        else
                        {
                            PgmCopy.Add(MacroName, new HashSet<string>());
                            PgmCopy[MacroName].Add(CopyName);
                        }
                        CopyHash.Add(MacroName + ":" + CopyName);
                    }
                }
                //*--M STA-MAC      @ZGPPTINF(ZGPTCSR1,R000)
                if (strREC.StartsWith(MacroStartMark))
                {
                    if (strREC.Contains("@"))
                    {
                        MacroName = strREC.Substring(strREC.IndexOf("@"));
                    }
                    else
                    {
                        MacroName = strREC.Substring(strREC.IndexOf("#"));
                    }
                    if (MacroName.Contains("("))
                    {
                        MacroName = MacroName.Substring(0, MacroName.IndexOf("("));
                    }
                    CallModuleStack.Push(MacroName);
                }
                if (strREC.StartsWith(MacroStartMark_Data) || strREC.StartsWith(SubMacroStartMark))
                {
                    MacroName = strREC.Substring(strREC.IndexOf("#") + 1);
                    if (MacroName.Contains("("))
                    {
                        MacroName = MacroName.Substring(0, MacroName.IndexOf("("));
                    }
                    CallModuleStack.Push(MacroName);
                }
                if (strREC.StartsWith(MacroStartMark_WorkData))
                {
                    MacroName = strREC.Substring(MacroStartMark_WorkData.Length);
                    CallModuleStack.Push(MacroName);
                }
                //'*--M #ZGPPTINF(ZGPTCSR1,R000)
                if (strREC.StartsWith(MacroEndMark) || strREC.StartsWith(MacroEndMark_Data) || strREC.StartsWith(SubMacroEndMark) || strREC.StartsWith(MacroEndMark_WorkData))
                {
                    CallModuleStack.Pop();
                }
            }
            sr.Close();
        }
    }

}
