using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
namespace DarumaTool
{
    public partial class IDL2PgmStruct
    {
        [BsonId]
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
            /// 期待结果
            /// </summary>
            public String Result;
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
        /// Section列表
        /// </summary>
        [BsonIgnore]
        public List<Section_OLD> SectionList_OLD = new List<Section_OLD>();
        /// <summary>
        /// Section
        /// </summary>
        public struct Section_OLD
        {
            public String SectionName;
            public List<SyntaxSet> SyntaxSetList;
        }
        /// <summary>
        /// 在IF后面，获取至少一个Assign文
        /// </summary>
        private static Boolean IsNeedAssign;
        /// <summary>
        /// XXX <- CASE;
        /// </summary>
        private static Boolean IsNeedValue;
        /// <summary>
        /// TRUE
        /// </summary>
        public const string TrueFlg = "#TRUE#";
        /// <summary>
        /// 分析
        /// </summary>
        /// <param name="filename"></param>
        public void Analyze(String filename)
        {
            List<Syntax> SyntaxList = new List<Syntax>();
            SyntaxList = new List<Syntax>();
            StreamReader sr = new StreamReader(filename, System.Text.Encoding.Default);
            String source;
            byte NestLV = 1;
            int LineNo = 1;
            String sectionName = String.Empty;
            IsNeedAssign = false;
            while (!sr.EndOfStream)
            {
                source = sr.ReadLine();
                source = FormatSource(source);
                ///必须放在WHEN之前
                if (IsNeedValue)
                {
                    Syntax t = SyntaxList[SyntaxList.Count - 1];
                    t.Result = "「 " + t.Result.Substring("INPUT:".Length) + " 」に 「 " + source.TrimEnd(".".ToCharArray()) + " 」を設定します";
                    SyntaxList.RemoveAt(SyntaxList.Count - 1);
                    SyntaxList.Add(t);
                    IsNeedValue = false;
                }
                IsSection(filename, ref source, NestLV, ref sectionName);
                NestLV = IsSyntax(SyntaxList, source, NestLV, LineNo, sectionName);
                //IsCall 的文件操作，Master操作Macro需要被后面的操作覆盖，所以，这里需要注意调用的顺序
                IsCall(SyntaxList, source, NestLV, LineNo, sectionName);
                IsFileOpr(SyntaxList, source, NestLV, LineNo, sectionName);
                IsMasterOpr(SyntaxList, source, NestLV, LineNo, sectionName);
                if (IsNeedAssign) IsAssignOpr(SyntaxList, source, NestLV, LineNo, sectionName);
                LineNo++;
            }
            sr.Close();
            //GetNestInfo(SyntaxList);
            ReSyntax(SyntaxList);
            Debug.WriteLine(PgmID + ":" + TopSyntax.Count);
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

        /// <summary>
        /// 替换行号为分支号
        /// </summary>
        private void ReplaceLineNo()
        {
            List<Section_OLD> newSectionList = new List<Section_OLD>();
            foreach (var section in SectionList_OLD)
            {
                Section_OLD newsec = section;
                ReSyntaxSet(ref newsec);
                newSectionList.Add(newsec);
            }
            SectionList_OLD = newSectionList;

            Dictionary<int, int> LineNoVsBranch = new Dictionary<int, int>();
            foreach (var section in SectionList_OLD)
            {
                foreach (var syntaxSet in section.SyntaxSetList)
                {
                    foreach (var syntax in syntaxSet.SyntaxList)
                    {
                        if (!LineNoVsBranch.ContainsKey(syntax.LineNo))
                        {
                            LineNoVsBranch.Add(syntax.LineNo, syntaxSet.BranchNo);
                        }
                    }
                }
            }
            newSectionList = new List<Section_OLD>();
            //替换Result%line%
            foreach (var section in SectionList_OLD)
            {
                Section_OLD newSection = new Section_OLD();
                newSection = section;
                newSection.SyntaxSetList = new List<SyntaxSet>();
                foreach (var syntaxSet in section.SyntaxSetList)
                {
                    SyntaxSet newSyntaxSet = new SyntaxSet();
                    newSyntaxSet = syntaxSet;
                    newSyntaxSet.SyntaxList = new List<Syntax>();
                    foreach (var syntax in syntaxSet.SyntaxList)
                    {
                        Syntax newSyntax = new Syntax();
                        newSyntax = syntax;
                        int CurrentLineNo = 0;
                        if (newSyntax.Result != null)
                        {
                            String[] lstResult = newSyntax.Result.Split("&".ToCharArray());
                            newSyntax.Result = String.Empty;
                            foreach (var subResult in lstResult)
                            {
                                if (subResult.StartsWith("%"))
                                {
                                    CurrentLineNo = int.Parse((subResult.Substring(0, subResult.LastIndexOf("%")).Trim("%".ToCharArray())));
                                    newSyntax.Result += LineNoVsBranch[CurrentLineNo] + subResult.Substring(subResult.LastIndexOf("%") + 1) + System.Environment.NewLine;
                                }
                                else
                                {
                                    newSyntax.Result += subResult + System.Environment.NewLine;
                                }
                            }
                            newSyntax.Result = newSyntax.Result.TrimEnd(System.Environment.NewLine.ToCharArray());
                        }
                        newSyntaxSet.SyntaxList.Add(newSyntax);
                    }
                    newSection.SyntaxSetList.Add(newSyntaxSet);
                }
                newSectionList.Add(newSection);
            }
            SectionList_OLD = newSectionList;
        }
        /// <summary>
        /// 是否为赋值
        /// </summary>
        /// <param name="SyntaxList"></param>
        /// <param name="source"></param>
        /// <param name="NestLV"></param>
        /// <param name="LineNo"></param>
        /// <param name="sectionName"></param>
        private void IsAssignOpr(List<Syntax> SyntaxList, string source, byte NestLV, int LineNo, string sectionName)
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
                    Result = "「" + source.Substring(0, source.IndexOf(" := ")) + "」に「" + 
                                    source.Substring(source.IndexOf(" := ") + 4).TrimEnd(".".ToCharArray()) + "」を設定します",
                    ExtendInfo = source.Substring(0, source.IndexOf(" := ")).Trim(),
                    SectionName = sectionName
                });
                IsNeedAssign = false;
            }
        }
        /// <summary>
        /// 是否为呼出子程序或者调用子过程
        /// </summary>
        /// <param name="SyntaxList"></param>
        /// <param name="source"></param>
        /// <param name="NestLV"></param>
        /// <param name="LineNo"></param>
        /// <param name="sectionName"></param>
        private static void IsCall(List<Syntax> SyntaxList, String source, byte NestLV, int LineNo, String sectionName)
        {
            //共通部品
            if (source.StartsWith("@"))
            {
                if (source == "@ZGIAPABRT")
                {
                    SyntaxList.Add(new Syntax()
                    {
                        SyntaxType = "ABORT",
                        LineNo = LineNo,
                        NestLv = NestLV,
                        ExtendInfo = "@ZGIAPABRT",
                        SectionName = sectionName
                    });
                }
                else
                {
                    SyntaxList.Add(new Syntax()
                    {
                        SyntaxType = "MACRO",
                        LineNo = LineNo,
                        NestLv = NestLV,
                        ExtendInfo = source.Contains("(") ?
                                     source.Substring(1, source.IndexOf("(") - 1) :
                                     source.Substring(1).Trim(".".ToCharArray()),
                        SectionName = sectionName
                    });
                }
            }
            //新增了DERIVE 2013/10/07
            //新增了PROC   2013/10/08
            if (source.StartsWith("CALL ") || source.StartsWith("DERIVE ") || source.StartsWith("PROC "))
            {
                char t = source.Substring(source.IndexOf(" ") + 1, 1).ToCharArray()[0];
                if (t >= "A".ToCharArray()[0] && t <= "Z".ToCharArray()[0])
                {
                    SyntaxList.Add(new Syntax()
                    {
                        SyntaxType = "CALL",
                        LineNo = LineNo,
                        NestLv = NestLV,
                        ExtendInfo = source.Contains("(") ?
                                     source.Substring(source.IndexOf(" ") + 1, source.Length - source.IndexOf(" ") - 1 - source.IndexOf("(") - 2) :
                                     source.Substring(source.IndexOf(" ") + 1).Trim(".".ToCharArray()),
                        SectionName = sectionName
                    });
                }
                else
                {
                    String PerformSectionName = source.Substring(source.IndexOf(" ") + 1).Trim(".".ToCharArray());
                    switch (PerformSectionName)
                    {
                        //错误处理
                        case "エラー処理":
                        case "異常終了処理":
                            SyntaxList.Add(new Syntax()
                            {
                                SyntaxType = "ERROR",
                                LineNo = LineNo,
                                NestLv = NestLV,
                                ExtendInfo = PerformSectionName,
                                SectionName = sectionName
                            });
                            break;
                        default:
                            SyntaxList.Add(new Syntax()
                            {
                                SyntaxType = "PERFORM",
                                LineNo = LineNo,
                                NestLv = NestLV,
                                ExtendInfo = PerformSectionName,
                                SectionName = sectionName
                            });
                            break;
                    }
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
                SectionList.Add(new Section() { SectionName = sectionName,  SyntaxList = new List<List<Syntax>>()});
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
                sectionName = source.Substring("OUTPUT ".Length).TrimEnd(".".ToCharArray());
                SectionList.Add(new Section() { SectionName = sectionName, SyntaxList = new List<List<Syntax>>() });
                if (NestLV != 1) Debug.WriteLine(filename + ":" + sectionName + " NestLV" + NestLV);
            }
            if (source.StartsWith("INPUT "))
            {
                sectionName = source.Substring("INPUT ".Length).TrimEnd(".".ToCharArray());
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
            //2.IF & MACRO
            if (source.StartsWith("IF "))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "IF",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    //条件分歧的填写用
                    ExtendInfo = source.Substring("IF ".Length),
                    Cond = new clsCondition(source.Substring("IF ".Length)),
                    SectionName = sectionName
                });
                NestLV++;
                IsNeedAssign = true;
            }
            if (source.StartsWith("ELSE"))
            {
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "ELSE",
                    LineNo = LineNo,
                    NestLv = NestLV
                });
                NestLV++;
                IsNeedAssign = true;
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
            //Macro控制文
            if (source.StartsWith("#IF "))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "#IF",
                    LineNo = LineNo,
                    NestLv = NestLV
                });
                NestLV++;
                IsNeedAssign = true;
            }
            if (source.StartsWith("#IFNOT "))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "#IF",
                    LineNo = LineNo,
                    NestLv = NestLV
                });
                NestLV++;
                IsNeedAssign = true;
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
                IsNeedAssign = true;
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
            //8.GET
            if (source.StartsWith("GET "))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "GET",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    SectionName = sectionName
                });
                NestLV++;
                IsNeedAssign = true;
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
                    ExtendInfo = source.Substring("WHILE ".Length),
                    Cond = new clsCondition(source.Substring("WHILE ".Length)),
                    SectionName = sectionName
                });
                NestLV++;
                IsNeedAssign = true;
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
                });
                NestLV++;
                IsNeedAssign = true;
            }
            if (source.StartsWith("UNTIL "))
            {
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "END-REPEAT",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    SectionName = sectionName
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
                    Result = source.Substring(source.IndexOf("SET"), source.LastIndexOf(")") - source.IndexOf("SET"))
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
                    //条件分歧的填写用
                    ExtendInfo = source.Substring(source.IndexOf("(") + 1, source.LastIndexOf(")") - source.IndexOf("(") - 1),
                    //测试项目
                    Cond = new clsCondition(source.Substring(source.IndexOf("(") + 1, source.LastIndexOf(")") - source.IndexOf("(") - 1))
                });
                //保持 CASE->WHEN->END-CASE同级别
                NestLV++;
                IsNeedAssign = true;
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
                        Result = (String.IsNullOrEmpty(InputItem)) ? null : "INPUT:" + InputItem
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
                        //条件分歧的填写用
                        ExtendInfo = CaseCondition,
                        //测试项目
                        Cond = (String.IsNullOrEmpty(CaseCondition)) ? null : new clsCondition(CaseCondition),
                        //Input
                        Result = (String.IsNullOrEmpty(InputItem)) ? null : "INPUT:" + InputItem
                    });
                }
                //保持 CASE->WHEN->END-CASE同级别
                NestLV++;
                IsNeedAssign = true;
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
                IsNeedAssign = true;
            }
            if (source.StartsWith("(") && (source.EndsWith("):")))
            {
                String HasInput = String.Empty;
                for (int i = SyntaxList.Count - 1; i >= 0; i--)
                {
                    if (SyntaxList[i].SyntaxType == "CASE")
                    {
                        HasInput = SyntaxList[i].Result;
                        break;
                    }
                }
                if (!String.IsNullOrEmpty(HasInput))
                {
                    if (HasInput.StartsWith("INPUT:"))
                    {
                        IsNeedValue = true;
                    }
                }
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "WHEN",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    ExtendInfo = source.Substring(1, source.Length - 3),
                    Result = HasInput
                });
                NestLV++;
                IsNeedAssign = true;
            }
            if (source.StartsWith("END-CASE."))
            {
                //保持 CASE->WHEN->END-CASE同级别
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "END-CASE",
                    LineNo = LineNo,
                    NestLv = NestLV
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
                    Cond = new clsCondition(source.Substring(source.IndexOf(" ") + 1, source.LastIndexOf(":") - source.IndexOf(" ") - 1).Trim())
                });
                NestLV++;
                IsNeedAssign = true;
            }
            if (source.StartsWith("END-FOR."))
            {
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "END-FOR",
                    LineNo = LineNo,
                    NestLv = NestLV
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
                });
                NestLV++;
                IsNeedAssign = true;
            }
            if (source.StartsWith("END-LOOP."))
            {
                NestLV--;
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "END-LOOP",
                    LineNo = LineNo,
                    NestLv = NestLV
                });
            }
            return NestLV;
        }
        /// <summary>
        /// 是否为Master操作
        /// </summary>
        /// <param name="SyntaxList"></param>
        /// <param name="source"></param>
        /// <param name="NestLV"></param>
        /// <param name="LineNo"></param>
        /// <param name="sectionName"></param>
        private static void IsMasterOpr(List<Syntax> SyntaxList, String source, byte NestLV, int LineNo, String sectionName)
        {
            //@ZGIVSAPUT(CKOITIM0,キー部 OF 新地公体一次登録７３,削除)
            //Master操作
            //OPEN
            if (source.StartsWith("@ZGIVSAOPN("))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "ZGIVSAOPN",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    ExtendInfo = source.Substring("@ZGIVSAOPN(".Length, 8),
                    SectionName = sectionName
                });
            }
            //GET
            if (source.StartsWith("@ZGIVSAGET("))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "ZGIVSAGET",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    ExtendInfo = source.Substring("@ZGIVSAGET(".Length, 8),
                    SectionName = sectionName
                });
            }
            if (source.StartsWith("@ZGIVSAPUT("))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "ZGIVSAPUT",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    ExtendInfo = source.Substring("@ZGIVSAPUT(".Length, 8),
                    SectionName = sectionName
                });
            }
            //CLOSE
            if (source.StartsWith("@ZGIVSACLS("))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "ZGIVSACLS",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    ExtendInfo = source.Substring("@ZGIVSACLS(".Length, 8),
                    SectionName = sectionName
                });
            }
        }
        /// <summary>
        /// 是否为文件操作命令
        /// </summary>
        /// <param name="SyntaxList"></param>
        /// <param name="source"></param>
        /// <param name="NestLV"></param>
        /// <param name="LineNo"></param>
        /// <param name="sectionName"></param>
        private static void IsFileOpr(List<Syntax> SyntaxList, String source, byte NestLV, int LineNo, String sectionName)
        {
            //@ZGISTDOPN(FILENAME) -FILENAME = 8Byte
            //文件操作
            //OPEN
            if (source.StartsWith("@ZGISTDOPN("))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "ZGISTDOPN",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    ExtendInfo = source.Substring("@ZGISTDOPN(".Length, 8),
                    SectionName = sectionName
                });
            }
            //GET
            if (source.StartsWith("@ZGISTDGET("))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "ZGISTDGET",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    ExtendInfo = source.Substring("@ZGISTDGET(".Length, 8),
                    SectionName = sectionName
                });
            }
            if (source.StartsWith("@ZGISTDPUT("))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "ZGISTDPUT",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    ExtendInfo = source.Substring("@ZGISTDPUT(".Length, 8),
                    SectionName = sectionName
                });
            }
            //CLOSE
            if (source.StartsWith("@ZGISTDCLS("))
            {
                SyntaxList.Add(new Syntax()
                {
                    SyntaxType = "ZGISTDCLS",
                    LineNo = LineNo,
                    NestLv = NestLV,
                    ExtendInfo = source.Substring("@ZGISTDCLS(".Length, 8),
                    SectionName = sectionName
                });
            }
        }
    }
}
