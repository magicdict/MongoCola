using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
namespace DarumaUTGenerator
{
    public partial class IDL2PgmStruct
    {
        public string PgmID = String.Empty;
        /// <summary>
        /// Section列表
        /// </summary>
        public List<Section> SectionList = new List<Section>();
        /// <summary>
        /// Section
        /// </summary>
        public struct Section
        {
            public String SectionName;
            public List<List<Syntax>> SyntaxList;
        }
        /// <summary>
        /// 语法点
        /// </summary>
        public struct Syntax
        {
            /// <summary>
            /// 命令类型
            /// </summary>
            public String SyntaxType;
            /// <summary>
            /// 行号
            /// </summary>
            public int LineNo;
            /// <summary>
            /// 嵌套深度
            /// </summary>
            public byte NestLv;
            /// <summary>
            /// 附加情报
            /// </summary>
            public String ExtendInfo;
            /// <summary>
            /// 条件式的分析
            /// </summary>
            public clsCondition Cond;
            /// <summary>
            /// SectionName
            /// </summary>
            public String SectionName;
            /// <summary>
            /// 迁移情报
            /// </summary>
            public List<Syntax> JumpInfo;
        }
        /// <summary>
        /// SyntaxSet
        /// </summary>
        public struct SyntaxSet
        {
            public String SyntaxSetType;
            /// <summary>
            /// 子分支
            /// </summary>
            public List<Syntax> SyntaxList;
            /// <summary>
            /// Section名称
            /// </summary>
            public String SectionName;
            /// <summary>
            /// 分歧点号码
            /// </summary>
            public int BranchNo;
            /// <summary>
            /// 附加情报
            /// </summary>
            public String ExtendInfo;
        }
        /// <summary>
        /// TRUE
        /// </summary>
        public const string TrueFlg = "#TRUE#";
        /// <summary>
        /// 最大嵌套数
        /// </summary>
        public int MaxNestLv = 0;
        /// <summary>
        /// 上一个句子
        /// </summary>
        static String PreSource = String.Empty;
        /// <summary>
        /// 分析
        /// </summary>
        /// <param name="filename"></param>
        public void Analyze(String filename,Boolean IsMacro = false)
        {
            List<Syntax> SyntaxList = new List<Syntax>();
            SyntaxList = new List<Syntax>();
            StreamReader sr = new StreamReader(filename, System.Text.Encoding.GetEncoding(932));
            String source;
            byte NestLV = 1;
            int LineNo = 1;
            String sectionName = String.Empty;
            while (!sr.EndOfStream)
            {
                source = sr.ReadLine();
                source = FormatSource(source);
                IsSection(filename, ref source, NestLV, ref sectionName);
                if (IsMacro) {
                    NestLV = IsMacroControl(SyntaxList, source, NestLV, LineNo, sectionName);
                }
                else
                {
                    NestLV = IsSyntax(SyntaxList, source, NestLV, LineNo, sectionName);
                }
                IsCommonOpr(SyntaxList, source, NestLV, LineNo, sectionName);
                LineNo++;
                if (SyntaxList.Count > 0 && isStartSyntax(SyntaxList[SyntaxList.Count - 1]))
                {
                    //开始文法作为统计对象，开始文法的时候，层号已经为下级的层号，所以需要 -1
                    if (NestLV - 1 > MaxNestLv)
                    {
                        MaxNestLv = NestLV - 1;
                    }
                }
                PreSource = source;
            }
            sr.Close();
            //GetNestInfo(SyntaxList);
            ReSyntax(SyntaxList);
            //Debug.WriteLine(PgmID + ":" + TopSyntax.Count);
            //ReplaceLineNo();
        }


        #region"统计"
        public static Dictionary<int, int> NestInfo = new Dictionary<int, int>();
        private static void GetNestInfo(List<Syntax> SyntaxList)
        {
            int MaxNest = 1;
            foreach (var syntax in SyntaxList)
            {
                if (syntax.NestLv == 1 && isEndSyntax(syntax))
                {
                    if (NestInfo.ContainsKey(MaxNest))
                    {
                        NestInfo[MaxNest] += 1;
                    }
                    else
                    {
                        NestInfo.Add(MaxNest, 1);
                    }
                    MaxNest = 1;
                }
                else
                {
                    if (isStartSyntax(syntax) && syntax.NestLv > MaxNest)
                    {
                        MaxNest = syntax.NestLv;
                    }
                }
                //Debug.WriteLine(syntax.SyntaxType + ":" + syntax.NestLv);
            }
        }
        public static void ShowNestInfo()
        {
            int total = 0;
            foreach (var item in NestInfo.Values)
            {
                total = total + item;
            }
            foreach (var item in NestInfo.Keys)
            {
                Debug.WriteLine(item + ":" + NestInfo[item] + "(" + (NestInfo[item] * 100) / total + "%)");
            }
        }
        #endregion
        
        private byte IsMacroControl(List<Syntax> SyntaxList, string source, byte NestLV, int LineNo, string sectionName)
        {
            //Macro控制文
            if (source.StartsWith("#IF "))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "#IF",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    Cond = new clsCondition(source.Substring("#IF ".Length)),
                });
                NestLV++;
            }
            if (source.StartsWith("#IFNOT "))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "#IFNOT",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    Cond = new clsCondition(source.Substring("#IFNOT ".Length)),
                });
                NestLV++;
            }
            if (source.StartsWith("#ELSE"))
            {
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "#ELSE",
                    LineNo = LineNo,
                    NestLv = NestLV
                });
                NestLV++;
            }
            if (source.StartsWith("#END-IF"))
            {
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "#END-IF",
                    LineNo = LineNo,
                    NestLv = NestLV
                });
            }
            return NestLV;
        }
        /// <summary>
        /// 执行语句
        /// </summary>
        /// <param name="SyntaxList"></param>
        /// <param name="source"></param>
        /// <param name="NestLV"></param>
        /// <param name="LineNo"></param>
        /// <param name="sectionName"></param>
        private void IsCommonOpr(List<Syntax> SyntaxList, string source, byte NestLV, int LineNo, string sectionName)
        {
            //Assign
            if (source.Contains(" := "))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "ASSIGN",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    //条件分歧的填写用
                    ExtendInfo = "「" + source.Substring(0, source.IndexOf(" := ")) + "」へ「" +
                                        source.Substring(source.IndexOf(" := ") + 4).TrimEnd(".".ToCharArray()) + "」を設定する",
                    //ExtendInfo = source.Substring(0, source.IndexOf(" := ")).Trim(),
                    SectionName = sectionName
                });
            }
            //BREAK
            if (source.Equals("BREAK."))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "BREAK",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    SectionName = sectionName
                });
            }
            if (source.StartsWith("BREAK "))
            {
                String Label = source.Substring("BREAK ".Length);
                Label = Label.TrimEnd(".".ToCharArray()).Trim();
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "BREAK",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    ExtendInfo = Label,
                    SectionName = sectionName
                });
            }
            //共通部品
            if (source.StartsWith("@"))
            {
                    SyntaxList.Add(new Syntax()
                    {
                        SyntaxType = "MACRO",
                        LineNo = LineNo,
                        NestLv = NestLV,
                        ExtendInfo = source.Substring(1),
                        SectionName = sectionName
                    });
            }
            //新增了DERIVE 2013/10/07
            //新增了PROC   2013/10/08
            if (source.StartsWith("CALL ") || 
                source.StartsWith("DERIVE ") ||
                source.StartsWith("PROC ") ||
                source.StartsWith("CHECK "))
            {
                String CallObj = source.Substring(source.IndexOf(" ") + 1).Trim().Trim(".".ToCharArray());
                char t = CallObj.ToCharArray()[0];
                if (t >= "A".ToCharArray()[0] && t <= "Z".ToCharArray()[0])
                {
                    SyntaxList.Add(new Syntax()
                    {
                        SyntaxType = "CALL",
                        LineNo = LineNo,
                        NestLv = NestLV,
                        ExtendInfo = CallObj.Contains("(") ? CallObj.Substring(0, CallObj.IndexOf("(")) : CallObj,
                        SectionName = sectionName
                    });
                }
                else
                {
                        SyntaxList.Add(new Syntax()
                        {
                            SyntaxType = "PERFORM",
                            LineNo = LineNo,
                            NestLv = NestLV,
                            ExtendInfo = CallObj.Contains("(") ? CallObj.Substring(0, CallObj.IndexOf("(")) : CallObj,
                            SectionName = sectionName
                        });
                }
            }
        }
        /// <summary>
        /// 进行初步的整理
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static string FormatSource(String source)
        {
            source = source.Trim();
            //将尾部的" ." 换成"."
            if (source.EndsWith(" ."))
            {
                source = source.Substring(0, source.Length - 2) + ".";
            }
            if (source.EndsWith(" ;"))
            {
                source = source.Substring(0, source.Length - 2) + ";";
            }
            if (source.EndsWith(" :"))
            {
                source = source.Substring(0, source.Length - 2) + ":";
            }
            return source;
        }
        /// <summary>
        /// 是否为Section
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="source"></param>
        /// <param name="NestLV"></param>
        /// <param name="sectionName"></param>
        private void IsSection(String filename, ref String source, byte NestLV, ref String sectionName)
        {
            //CASE  (  -> CASE (
            //IF  ( -> IF (
            if (source.Contains("  (")) { source = source.Replace("  (", " ("); }
            //SECTION,PROC
            if (source.Equals("MAIN PROC."))
            {
                sectionName = "MAIN";
                SectionList.Add(new Section() { SectionName = sectionName, SyntaxList = new List<List<Syntax>>() });
                if (NestLV != 1) Debug.WriteLine(filename + ":" + sectionName + " NestLV" + NestLV);
            }
            if (source.StartsWith("SUB PROC "))
            {
                sectionName = source.Substring("SUB PROC ".Length).TrimEnd(".".ToCharArray());
                SectionList.Add(new Section() { SectionName = sectionName, SyntaxList = new List<List<Syntax>>() });
                if (NestLV != 1) Debug.WriteLine(filename + ":" + sectionName + " NestLV" + NestLV);
            }
            if (source.StartsWith("OUTPUT "))
            {
                sectionName = source.Split(" ".ToCharArray())[1];
                SectionList.Add(new Section() { SectionName = sectionName, SyntaxList = new List<List<Syntax>>() });
                if (NestLV != 1) Debug.WriteLine(filename + ":" + sectionName + " NestLV" + NestLV);
            }
            if (source.StartsWith("INPUT "))
            {
                sectionName = source.Split(" ".ToCharArray())[1];
                SectionList.Add(new Section() { SectionName = sectionName, SyntaxList = new List<List<Syntax>>() });
                if (NestLV != 1) Debug.WriteLine(filename + ":" + sectionName + " NestLV" + NestLV);
            }
            if (source.StartsWith("ERROR PROC FOR FILE"))
            {
                sectionName = "作業ファイルエラー処理";
                SectionList.Add(new Section() { SectionName = sectionName, SyntaxList = new List<List<Syntax>>() });
                if (NestLV != 1) Debug.WriteLine(filename + ":" + sectionName + " NestLV" + NestLV);
            }

            

        }
        /// <summary>
        /// 是否为Syntax
        /// </summary>
        /// <param name="SyntaxList"></param>
        /// <param name="source"></param>
        /// <param name="NestLV"></param>
        /// <param name="LineNo"></param>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        private static byte IsSyntax(List<Syntax> SyntaxList, String source, byte NestLV, int LineNo, String sectionName)
        {
            //0.BLOCK
            if (source.Equals("BLOCK") || source.StartsWith("BLOCK "))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "BLOCK",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    ExtendInfo = isEndSyntax(PreSource.Trim(".".ToCharArray()))?String.Empty:PreSource.Trim(".".ToCharArray()),
                    SectionName = sectionName,
                    JumpInfo = new List<Syntax>()
                });
                NestLV++;
            }
            if (source.Equals("END-BLOCK."))
            {
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "END-BLOCK",
                    LineNo = LineNo,
                    NestLv = NestLV
                });
            }

            //2.IF & MACRO
            if (source.StartsWith("IF "))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "IF",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    //条件分歧的填写用
                    //ExtendInfo = source.Substring("IF ".Length),
                    Cond = new clsCondition(source.Substring("IF ".Length)),
                    SectionName = sectionName,
                    JumpInfo = new List<Syntax>()
                });
                NestLV++;
            }
            if (source.StartsWith("ELSE"))
            {
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "ELSE",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    SectionName = sectionName,
                    JumpInfo = new List<Syntax>()

                });
                NestLV++;
            }
            if (source.StartsWith("END-IF.") || (source == "END-IF"))
            {
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "END-IF",
                    LineNo = LineNo,
                    NestLv = NestLV
                });
            }
            //8.GET
            if (source.StartsWith("GET "))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "GET",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    ExtendInfo = source.Substring("GET ".Length),
                    SectionName = sectionName,
                    JumpInfo = new List<Syntax>()
                });
                NestLV++;
            }
            if (source.StartsWith("END-GET."))
            {
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "END-GET",
                    LineNo = LineNo,
                    NestLv = NestLV
                });
            }

            //13.WHILE
            if (source.StartsWith("WHILE "))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "WHILE",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    //条件分歧的填写用
                    //ExtendInfo = source.Substring("WHILE ".Length),
                    Cond = new clsCondition(source.Substring("WHILE ".Length)),
                    SectionName = sectionName,
                    JumpInfo = new List<Syntax>()
                });
                NestLV++;
            }
            if (source.StartsWith("END-WHILE."))
            {
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "END-WHILE",
                    LineNo = LineNo,
                    NestLv = NestLV
                });
            }

            //14.REPEAT
            if (source.StartsWith("REPEAT"))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "REPEAT",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    SectionName = sectionName,
                    JumpInfo = new List<Syntax>()
                });
                NestLV++;
            }
            if (source.StartsWith("UNTIL "))
            {
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "END-REPEAT",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    SectionName = sectionName,
                    JumpInfo = new List<Syntax>()
                });
            }
            //20.CHECK
            if (source.StartsWith("CHECK(") || source.IndexOf("-> CHECK(") > 0)
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "CHECK",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    SectionName = sectionName,
                    //条件分歧的填写用
                    //CHECK( RANGE(☆東京) FALSE(SET(☆キーイン・エラー:エラーコード OF ＬＣ業務系共通)) ) .
                    //RANGE(☆東京) 到第一个 ）为止？暂时不做精确堆栈计算
                    ExtendInfo = source.Substring(source.IndexOf("(") + 1, source.IndexOf(")") - source.IndexOf("(")) + ((source.Contains("TRUE(SET")) ? ":TRUE" : ":FALSE"),
                    //测试项目
                    Cond = new clsCondition((source.IndexOf("-> CHECK(") > 0) ? source.Substring(0, source.IndexOf("-> CHECK(")) : "判断子不明"),
                    JumpInfo = new List<Syntax>()
                });
                //单条语句，不存在嵌套！
                //NestLV++;
            }
            //28.CASE
            if (source.StartsWith("CASE(") || source.StartsWith("CASE ("))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "CASE",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    SectionName = sectionName,
                    //测试项目
                    Cond = new clsCondition(source.Substring(source.IndexOf("(") + 1, source.LastIndexOf(")") - source.IndexOf("(") - 1)),
                    JumpInfo = new List<Syntax>()
                });
                //保持 CASE->WHEN->END-CASE同级别
                NestLV++;
            }
            // <- CASE ;
            if (source.EndsWith(" <- CASE;") || source.EndsWith(" -> CASE;")
                || (source.Contains(" -> CASE") && source.EndsWith(");")) || (source.Contains(" <- CASE") && source.EndsWith(");")))
            {
                String CaseCondition = String.Empty;
                String InputItem = String.Empty;
                //同時入力証書記号番号(2) -> CASE(受入データ請求件数 OF ＲＫＩＯＪ０８２－０３) ;
                if (source.Contains(" CASE("))
                {
                    CaseCondition = source.Substring(source.IndexOf(" CASE(") + 6,
                                                     source.Length - source.IndexOf(" CASE(") - 6 - 2);

                }
                else
                {
                    CaseCondition = TrueFlg;
                }
                if (source.EndsWith(" <- CASE;"))
                {
                    //郵政局コード <- CASE ;
                    InputItem = source.Substring(0, source.IndexOf(" <- CASE;")).Trim();
                }
                if (CaseCondition == TrueFlg)
                {
                    SyntaxList.Add(new Syntax()
                    {
                        SyntaxType = "CASE",
                        LineNo = LineNo,
                        NestLv = NestLV,
                        SectionName = sectionName,
                        ExtendInfo = TrueFlg,
                        JumpInfo = new List<Syntax>()
                    });
                }
                else
                {
                    SyntaxList.Add(new Syntax()
                    {
                        SyntaxType = "CASE",
                        LineNo = LineNo,
                        NestLv = NestLV,
                        SectionName = sectionName,
                        //测试项目
                        Cond = (String.IsNullOrEmpty(CaseCondition)) ? null : new clsCondition(CaseCondition),
                        //Input
                        JumpInfo = new List<Syntax>()
                    });
                }
                //保持 CASE->WHEN->END-CASE同级别
                NestLV++;
            }

            if (source.StartsWith("CASE;"))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "CASE",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    SectionName = sectionName,
                    ExtendInfo = TrueFlg
                });
                //保持 CASE->WHEN->END-CASE同级别
                NestLV++;
            }
            if (source.StartsWith("(") && (source.EndsWith("):")))
            {
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "WHEN",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    ExtendInfo = source.Substring(1, source.Length - 3),
                    JumpInfo = new List<Syntax>(),
                    SectionName = sectionName,
                });
                NestLV++;
            }
            if (source.StartsWith("END-CASE."))
            {
                //保持 CASE->WHEN->END-CASE同级别
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "END-CASE",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    SectionName = sectionName
                });
            }

            //36 FOR
            if (source.StartsWith("FOR "))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "FOR",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    SectionName = sectionName,
                    //条件分歧的填写用
                    ExtendInfo = source.Substring("FOR ".Length),
                    //测试项目
                    Cond = new clsCondition(source.Substring(source.IndexOf(" ") + 1, source.LastIndexOf(":") - source.IndexOf(" ") - 1).Trim()),
                    JumpInfo = new List<Syntax>()
                });
                NestLV++;
            }
            if (source.StartsWith("END-FOR."))
            {
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "END-FOR",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    SectionName = sectionName
                });
            }
            //37.LOOP
            if (source.StartsWith("LOOP ") || source.StartsWith("LOOP"))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "LOOP",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    SectionName = sectionName,
                    JumpInfo = new List<Syntax>()
                });
                NestLV++;
            }
            if (source.StartsWith("END-LOOP."))
            {
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "END-LOOP",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    SectionName = sectionName,
                });
            }
            return NestLV;
        }
    }
}
