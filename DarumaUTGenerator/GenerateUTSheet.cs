using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DarumaUTGenerator
{
    public static class GenerateUTSheet
    {
        const int xlToRight = -4161;
        const int xlFormatFromLeftOrAbove = 0;
        const int xlLeft = -4131;
        const int xlNone = -4142;
        const int xlContinuous = 1;
        const int xlEdgeLeft = 7;
        const int xlEdgeTop = 8;
        const int xlEdgeBottom = 9;
        const int xlEdgeRight = 10;
        const int xlInsideVertical = 11;
        const int xlInsideHorizontal = 12;
        const int xlLightYellow = 6750207;
        const int xlOrange = 49407;
        static int MaxLv;
        static Dictionary<String, String> MoudleNameList = new Dictionary<string, string>();
        static Dictionary<String, String> MacroNameList = new Dictionary<string, string>();

        public static void GenerateUT(IDL2PgmStruct pgm, String UTFilename)
        {
            foreach (var item in pgm.TopSyntax)
            {
                foreach (var item2 in item)
                {
                    System.Diagnostics.Debug.WriteLine("NestLv" + item2.NestLv + " LineNo" + item2.LineNo);
                }
            }

            
            MoudleNameList.Clear();
            MacroNameList.Clear();

            dynamic excelObj = Microsoft.VisualBasic.Interaction.CreateObject("Excel.Application");
            int RowCount;
            excelObj.Visible = true;
            dynamic workbook = excelObj.Workbooks.Open(UTFilename);
            GetJpNameList(workbook);
            dynamic ActiveSheet = workbook.Sheets(3);
            ActiveSheet.Select();
            ///L1实际上是用来标明分歧号的，所以必须多加一列
            MaxLv = pgm.MaxNestLv + 1;


            if (MaxLv > 5)
            {
                ActiveSheet.Cells(4, 1).Select();
                excelObj.Selection.UnMerge();
                ActiveSheet.Columns(5).Select();
                for (int i = 0; i < MaxLv - 5; i++)
                {
                    excelObj.Selection.Insert(Shift: xlToRight, CopyOrigin: xlFormatFromLeftOrAbove);
                }
                excelObj.Range(ActiveSheet.Cells(4, 1), ActiveSheet.Cells(4, MaxLv)).Select();
                excelObj.Selection.Merge();
                for (int i = 1; i < MaxLv + 1; i++)
                {
                    ActiveSheet.Cells(5, i).Value = "L" + i;
                }
            }
            else
            {
                MaxLv = 5;
            }
            RowCount = 6;

            int BranchNo;
            if (pgm.SectionList.Count == 0) {
                IDL2PgmStruct.Section section = new IDL2PgmStruct.Section();
                section.SectionName = pgm.PgmID;
                section.SyntaxList = new List<List<IDL2PgmStruct.Syntax>>();
                foreach (var item in pgm.TopSyntax)
                {
                    section.SyntaxList.Add(item);
                }
                pgm.SectionList.Add(section);
            }
            foreach (var section in pgm.SectionList)
            {
                CreateSectionHeader(RowCount, section.SectionName, excelObj, ActiveSheet);
                RowCount = RowCount + 1;
                BranchNo = 1;
                foreach (var Syntax in section.SyntaxList)
                {
                    ActiveSheet.Cells(RowCount, 1).Value = BranchNo;
                    int StartRow = RowCount;
                    int EndRow;
                    IDL2PgmStruct.Syntax CaseSyntax = new IDL2PgmStruct.Syntax();
                    String KeyWord;
                    int WhenNo = 0;
                    for (int i = 0; i < Syntax.Count; i++)
                    {
                        var SyntaxItem = Syntax[i];
                        KeyWord = SyntaxItem.SyntaxType;
                        if (SyntaxItem.SyntaxType == "WHEN")
                        {
                            WhenNo = 1;
                            //寻找最近的父CASE语句
                            for (int j = i - 1; j >= 0; j--)
                            {
                                if (Syntax[j].SyntaxType == "CASE")
                                {
                                    CaseSyntax = Syntax[j];
                                    break;
                                }
                                if (Syntax[j].SyntaxType == "WHEN")
                                {
                                    WhenNo++;
                                }
                            }
                        }
                        if (IDL2PgmStruct.isStartSyntax(SyntaxItem) || IDL2PgmStruct.isMidSyntax(SyntaxItem))
                        {
                            //LineNo
                            ActiveSheet.Cells(RowCount, MaxLv + 1).Value = SyntaxItem.LineNo;
                            //测试内容
                            String TestString = String.Empty;
                            if (SyntaxItem.Cond != null)
                            {
                                foreach (var item in SyntaxItem.Cond.TestItemLst)
                                {
                                    TestString += "「" + item + "」、";
                                }
                            }
                            TestString = TestString.TrimEnd("、".ToCharArray());
                            switch (SyntaxItem.SyntaxType)
                            {
                                case "IF":
                                    if (String.IsNullOrEmpty(SyntaxItem.ExtendInfo))
                                    {
                                        if (SyntaxItem.Cond.OrgCondition.IndexOf(">") > 0 || SyntaxItem.Cond.OrgCondition.IndexOf("<") > 0)
                                        {
                                            TestString += "の臨界値チェック";
                                            PolishRow(RowCount, excelObj, ActiveSheet);
                                        }
                                        else
                                        {
                                            TestString += "の分岐判定処理";
                                        }
                                        ActiveSheet.Cells(RowCount, MaxLv + 4).Value = TestString;
                                    }
                                    else
                                    {
                                        ActiveSheet.Cells(RowCount, MaxLv + 4).Value = GetTestContext(SyntaxItem.ExtendInfo);
                                    }
                                    break;
                                case "ELSE":
                                    ActiveSheet.Cells(RowCount, MaxLv + 5).Value = "上記以外";
                                    break;
                                case "WHILE":
                                case "REPEAT":
                                case "FOR":
                                    TestString += "終了条件まで繰り返す";
                                    ActiveSheet.Cells(RowCount, MaxLv + 4).Value = TestString;
                                    break;
                                case "LOOP":
                                    ActiveSheet.Cells(RowCount, MaxLv + 4).Value = "ループをBREAKまで繰り返す";
                                    break;
                                case "WHEN":
                                    if (CaseSyntax.ExtendInfo == IDL2PgmStruct.TrueFlg)
                                    {
                                        ActiveSheet.Cells(RowCount, MaxLv + 4).Value = "判定" + WhenNo;
                                        ActiveSheet.Cells(RowCount, MaxLv + 5).Value = SyntaxItem.ExtendInfo;
                                    }
                                    else
                                    {
                                        if (WhenNo == 1)
                                        {
                                            if (String.IsNullOrEmpty(CaseSyntax.ExtendInfo))
                                            {
                                                if (CaseSyntax.Cond != null)
                                                {
                                                    foreach (var item in CaseSyntax.Cond.TestItemLst)
                                                    {
                                                        TestString += "「" + item + "」、";
                                                    }
                                                }
                                                TestString = TestString.TrimEnd("、".ToCharArray());
                                                TestString += "の多分岐判定処理";
                                                ActiveSheet.Cells(RowCount, MaxLv + 4).Value = TestString;
                                            }
                                            else
                                            {
                                                ActiveSheet.Cells(RowCount, MaxLv + 4).Value = GetTestContext(CaseSyntax.ExtendInfo);
                                            }
                                        }
                                        ActiveSheet.Cells(RowCount, MaxLv + 5).Value = SyntaxItem.ExtendInfo;
                                    }
                                    break;
                                case "GET":
                                    ActiveSheet.Cells(RowCount, MaxLv + 4).Value = "入力ファイル読込処理（" + SyntaxItem.ExtendInfo + "）の終了判定";
                                    PolishRow(RowCount, excelObj, ActiveSheet);
                                    break;
                                case "CHECK":
                                    PolishRow(RowCount, excelObj, ActiveSheet);
                                    break;
                                default:
                                    break;
                            }
                            //分歧条件
                            if (SyntaxItem.Cond != null)
                            {
                                ActiveSheet.Cells(RowCount, MaxLv + 5).Value = SyntaxItem.Cond.OrgCondition.Replace("^=","≠");
                            }
                            //迁移情报
                            ActiveSheet.Cells(RowCount, MaxLv + 6).Value = GetJump(SyntaxItem.JumpInfo);
                            //KeyWord
                            switch (KeyWord)
                            {
                                case "IF":
                                    ActiveSheet.Cells(RowCount, MaxLv + 2).Value = KeyWord;
                                    ActiveSheet.Cells(RowCount, MaxLv + 3).Value = "THEN";
                                    break;
                                case "CASE":
                                    ActiveSheet.Cells(RowCount, MaxLv + 2).Value = KeyWord;
                                    break;
                                case "ELSE":
                                case "WHEN":
                                    ActiveSheet.Cells(RowCount, MaxLv + 3).Value = KeyWord;
                                    break;
                                case "BLOCK":
                                    ActiveSheet.Cells(RowCount, MaxLv + 2).Value = KeyWord;
                                    ActiveSheet.Cells(RowCount, MaxLv + 3).Value = SyntaxItem.ExtendInfo;
                                    break;
                                default:
                                    ActiveSheet.Cells(RowCount, MaxLv + 2).Value = KeyWord;
                                    break;
                            }
                            //Nest Lv
                            if (KeyWord == "ELSE")
                            {
                                ActiveSheet.Cells(RowCount, SyntaxItem.NestLv + 1).Value = "2";
                            }
                            else
                            {
                                if (KeyWord == "WHEN")
                                {
                                    ActiveSheet.Cells(RowCount, SyntaxItem.NestLv + 1).Value = WhenNo;
                                }
                                else
                                {
                                    ActiveSheet.Cells(RowCount, SyntaxItem.NestLv + 1).Value = "1";
                                }
                            }
                            if (SyntaxItem.SyntaxType != "CASE") RowCount = RowCount + 1;
                        }
                    }
                    EndRow = RowCount - 1;
                    ActiveSheet.Range(ActiveSheet.Cells(StartRow, 1), ActiveSheet.Cells(EndRow, 1)).Select();
                    excelObj.Selection.Borders(xlEdgeLeft).LineStyle = xlContinuous;
                    excelObj.Selection.Borders(xlEdgeTop).LineStyle = xlContinuous;
                    excelObj.Selection.Borders(xlEdgeRight).LineStyle = xlContinuous;
                    excelObj.Selection.Borders(xlEdgeBottom).LineStyle = xlContinuous;
                    DrawNestLine(StartRow, EndRow, excelObj, ActiveSheet);
                    ActiveSheet.Range(ActiveSheet.Cells(StartRow, MaxLv + 1), ActiveSheet.Cells(EndRow, MaxLv + 6)).Select();
                    excelObj.Selection.Borders(xlEdgeLeft).LineStyle = xlContinuous;
                    excelObj.Selection.Borders(xlEdgeTop).LineStyle = xlContinuous;
                    excelObj.Selection.Borders(xlEdgeRight).LineStyle = xlContinuous;
                    excelObj.Selection.Borders(xlEdgeBottom).LineStyle = xlContinuous;
                    excelObj.Selection.Borders(xlInsideVertical).LineStyle = xlContinuous;
                    excelObj.Selection.Borders(xlInsideHorizontal).LineStyle = xlContinuous;

                    BranchNo++;
                }
            }
            ///印刷设定
            RowCount--;
            ActiveSheet.PageSetup.PrintArea = "$A$1:$R$" + RowCount;
        }

        private static void GetJpNameList(dynamic workbook)
        {
            Assembly asm = Assembly.GetExecutingAssembly();//读取嵌入式资源
            String Rec = String.Empty;
            String Key = string.Empty;
            String Value = String.Empty;

            System.IO.StreamReader txtStream = new System.IO.StreamReader(asm.GetManifestResourceStream("DarumaUTGenerator.Module.txt"), Encoding.Unicode);
            Rec = txtStream.ReadLine();
            while (!txtStream.EndOfStream) {
                Key = Rec.Substring(0, Rec.IndexOf("|"));
                Value = Rec.Substring(Rec.IndexOf("|") + 1);
                if (!MoudleNameList.ContainsKey(Key))
                {
                    MoudleNameList.Add(Key, Value);
                }
                Rec = txtStream.ReadLine();
            }
            txtStream.Close();


            txtStream = new System.IO.StreamReader(asm.GetManifestResourceStream("DarumaUTGenerator.Macro.txt"), Encoding.Unicode);
            Rec = txtStream.ReadLine();
            while (!txtStream.EndOfStream)
            {
                Key = Rec.Substring(0, Rec.IndexOf("|"));
                Value = Rec.Substring(Rec.IndexOf("|") + 1);
                if (!MacroNameList.ContainsKey(Key))
                {
                    MacroNameList.Add(Key, Value);
                }
                Rec = txtStream.ReadLine();
            }
            txtStream.Close();

        }

        private static String GetTestContext(string ExtendInfo)
        {
            String TestString = String.Empty;
            if (ExtendInfo.StartsWith("CALL:"))
            {
                String ModuleName = ExtendInfo.Substring("CALL:".Length);
                if (MoudleNameList.ContainsKey(ModuleName))
                {
                    TestString = ModuleName + "(" + MoudleNameList[ModuleName] + ")の戻り値の判定処理";
                }
                else
                {
                    TestString = "「" + ModuleName + "」の戻り値の判定処理";
                }
            }
            if (ExtendInfo.StartsWith("MACRO:"))
            {
                String MacroName = ExtendInfo.Substring("MACRO:".Length);
                if (MacroName.IndexOf("(") > 0)
                {
                    MacroName = MacroName.Substring(0, MacroName.IndexOf("("));
                }
                switch (MacroName)
                {
                    case "ZGISTDOPN":
                        TestString = "ファイルオープン処理(" + ExtendInfo.Substring("MACRO:ZGISTDOPN(".Length, 8) + ")分岐の判定";
                        break;
                    case "ZGISTDCLS":
                        TestString = "ファイルクローズ処理(" + ExtendInfo.Substring("MACRO:ZGISTDCLS(".Length, 8) + ")分岐の判定";
                        break;
                    case "ZGISTDGET":
                        TestString = "入力ファイル読込処理(" + ExtendInfo.Substring("MACRO:ZGISTDGET(".Length, 8) + ")分岐の判定";
                        break;
                    case "ZGISTDPUT":
                        TestString = "出力ファイル書込処理(" + ExtendInfo.Substring("MACRO:ZGISTDPUT(".Length, 8) + ")分岐の判定";
                        break;
                    case "ZGIVSAOPN":
                        TestString = "マスターオープン処理(" + ExtendInfo.Substring("MACRO:ZGIVSAOPN(".Length, 8) + ")分岐の判定";
                        break;
                    case "ZGIVSACLS":
                        TestString = "マスタークローズ処理(" + ExtendInfo.Substring("MACRO:ZGIVSACLS(".Length, 8) + ")分岐の判定";
                        break;
                    case "ZGIVSAGET":
                        TestString = "マスター読込処理(" + ExtendInfo.Substring("MACRO:ZGIVSAGET(".Length, 8) + ")分岐の判定";
                        break;
                    case "ZGIVSAPUT":
                        TestString = "マスター書込処理(" + ExtendInfo.Substring("MACRO:ZGIVSAPUT(".Length, 8) + ")分岐の判定";
                        break;
                    default:
                        TestString = MacroName + "の戻り値の判定処理";
                        break;
                }
            }
            return TestString;
        }

        private static dynamic GetJump(List<IDL2PgmStruct.Syntax> list)
        {
            String strJumpInfo = String.Empty;
            if (list == null || list.Count == 0)
            {
                strJumpInfo = "次の処理へ";
            }
            else
            {
                foreach (var JumpItem in list)
                {
                    switch (JumpItem.SyntaxType)
                    {
                        case "ASSIGN":
                            strJumpInfo += JumpItem.ExtendInfo + "#";
                            break;
                        case "BREAK":
                            if (string.IsNullOrEmpty(JumpItem.ExtendInfo))
                            {
                                strJumpInfo += "ブロックから抜ける#";
                            }
                            else
                            {
                                strJumpInfo += JumpItem.ExtendInfo + " で指定されたブロックから抜ける#";
                            }
                            break;
                        default:
                            strJumpInfo += "「" + JumpItem.ExtendInfo + "」に移る#";
                            break;
                    }
                }
                strJumpInfo = strJumpInfo.TrimEnd("#".ToCharArray()).Replace("#", System.Environment.NewLine);
            }
            return strJumpInfo;
        }
        /// <summary>
        /// 画Nest构造
        /// </summary>
        /// <param name="StartRow"></param>
        /// <param name="EndRow"></param>
        /// <param name="excelObj"></param>
        /// <param name="ActiveSheet"></param>
        private static void DrawNestLine(int StartRow, int EndRow, dynamic excelObj, dynamic ActiveSheet)
        {
            for (int i = StartRow; i < EndRow + 1; i++)
            {
                for (int j = 2; j < MaxLv + 1; j++)
                {
                    if (ActiveSheet.Cells(i, j).Text != "")
                    {
                        //向左和向下的线
                        ActiveSheet.Range(ActiveSheet.Cells(i, j), ActiveSheet.Cells(EndRow, MaxLv)).Select();
                        excelObj.Selection.Borders(xlEdgeLeft).LineStyle = xlContinuous;
                        excelObj.Selection.Borders(xlEdgeTop).LineStyle = xlContinuous;
                        excelObj.Selection.Borders(xlEdgeRight).LineStyle = xlContinuous;
                        excelObj.Selection.Borders(xlEdgeBottom).LineStyle = xlContinuous;
                    }
                }
            }
            for (int i = StartRow; i < EndRow + 1; i++)
            {
                for (int j = 2; j < MaxLv + 1; j++)
                {
                    if (ActiveSheet.Cells(i, j).Text != "")
                    {
                        //去除右边的多余线
                        ActiveSheet.Range(ActiveSheet.Cells(i, j), ActiveSheet.Cells(i, MaxLv)).Select();
                        excelObj.Selection.Borders(xlInsideVertical).LineStyle = xlNone;
                    }

                }
            }
        }
        private static void PolishRow(int RowCount, dynamic excelObj, dynamic ActiveSheet)
        {
            ActiveSheet.Range(ActiveSheet.Cells(RowCount, MaxLv + 1), ActiveSheet.Cells(RowCount, MaxLv + 6)).Select();
            excelObj.Selection.Interior.Color = xlOrange;
        }
        /// <summary>
        /// 画Section块
        /// </summary>
        /// <param name="RowCount"></param>
        /// <param name="SectionName"></param>
        private static void CreateSectionHeader(int RowCount, string SectionName, dynamic excelObj, dynamic ActiveSheet)
        {
            ActiveSheet.Range(ActiveSheet.Cells(RowCount, 1), ActiveSheet.Cells(RowCount, MaxLv + 6)).Select();
            excelObj.Selection.Merge();
            excelObj.Selection.HorizontalAlignment = xlLeft;
            excelObj.Selection.Interior.Color = xlLightYellow;
            excelObj.Selection.Borders(xlEdgeLeft).LineStyle = xlContinuous;
            excelObj.Selection.Borders(xlEdgeTop).LineStyle = xlContinuous;
            excelObj.Selection.Borders(xlEdgeRight).LineStyle = xlContinuous;
            excelObj.Selection.Borders(xlEdgeBottom).LineStyle = xlContinuous;
            ActiveSheet.Cells(RowCount, 1).Value = SectionName;

        }
    }
}
