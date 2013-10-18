using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
namespace DarumaTool
{
    public partial class frmMenu : Form
    {
        //TODO:可配置
        private const string idwFolder = @"C:\Daruma\WorkShop\idw";
        private const string idl2MacroFolder = @"C:\Daruma\WorkShop\id@";
        private const string idl2MainFolder = @"C:\Daruma\WorkShop\01.IDLIIソース";
        //private const string idl2MainFolder = @"C:\Daruma\WorkShop\01.IDLIIソース_0";
        private const String ExcelList = @"C:\Daruma\Tools\H2504_PGM別STEP数(20130617).xls";
        private const String MacroCallPatten = @"C:\Daruma\Tools\パラメータ有_部品呼出し一覧_20130724.txt";
        internal class IDL2Program
        {
            [BsonId]
            public String PgmID;
            public Boolean IsMacro;
            public int line;
        }
        internal class IDL2ProgramLinkage
        {
            [BsonId]
            public String PgmID;
            public List<String> Linkage;
        }
        internal class CopyBook
        {
            [BsonId]
            public String PgmID;
            public HashSet<String> Copy;
        }
        internal class DarumaProgram
        {
            [BsonId]
            public String PgmID;
            public String Name;
            public String Type;
        }
        internal class ModuleCall
        {
            [BsonId]
            public String PgmID;
            public List<String> CalledModuleIDList;
            public List<String> CalledMacroList;
        }
        MongoServer DarumaDBServer;
        MongoDatabase DarumaDB;
        public frmMenu()
        {
            InitializeComponent();
        }
        private void frmMenu_Load(object sender, EventArgs e)
        {
            MongoClient Client = new MongoClient("mongodb://localhost:28040");
            DarumaDBServer = Client.GetServer();
            if (DarumaDBServer.State == MongoServerState.Disconnected)
            {
                this.btnStartUpMongoDB_Click(sender, e);
            }
            DarumaDB = DarumaDBServer.GetDatabase("Daruma");
            btnClose.Click += (x, y) => { this.Close(); };
        }
        /// <summary>
        /// 系统设定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSystemConfig_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 程序ID-COPY句
        /// </summary>
        Dictionary<String, HashSet<String>> PgmCopy = new Dictionary<string, HashSet<string>>();
        /// <summary>
        /// COPY句一览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIDW_Click(object sender, EventArgs e)
        {
            PgmCopy.Clear();
            if (DarumaDB.CollectionExists("CopyBook"))
            {
                DarumaDB.DropCollection("CopyBook");
            }
            MongoCollection DarumaCol = DarumaDB.GetCollection("CopyBook");
            if (Directory.Exists(idwFolder))
            {
                foreach (String filename in Directory.GetFiles(idwFolder))
                {
                    FileInfo pgm = new FileInfo(filename);
                    HashSet<String> CopyHash = new HashSet<string>();
                    GetCopy(filename, pgm.Name.Replace(".idw", string.Empty), false, CopyHash);
                    DarumaCol.Insert<CopyBook>(
                        new CopyBook() { Copy = CopyHash, PgmID = pgm.Name.Replace(".idw", string.Empty) });
                }
            }
            if (DarumaDB.CollectionExists("CopyBook_A"))
            {
                DarumaDB.DropCollection("CopyBook_A");
            }
            DarumaCol = DarumaDB.GetCollection("CopyBook_A");
            foreach (var item in PgmCopy)
            {
                DarumaCol.Insert<CopyBook>(
                       new CopyBook() { Copy = item.Value, PgmID = item.Key });
            }
        }
        /// <summary>
        /// 获得文本文件的行数
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private int getLines(string filename)
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
        /// IDL2代码分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIDL2Source_Click(object sender, EventArgs e)
        {
            if (DarumaDB.CollectionExists("Pgmlst"))
            {
                DarumaDB.DropCollection("Pgmlst");
            }
            MongoCollection DarumaCol = DarumaDB.GetCollection("Pgmlst");
            ///获得部品的信息
            if (Directory.Exists(idl2MacroFolder))
            {
                foreach (String filename in Directory.GetFiles(idl2MacroFolder))
                {
                    FileInfo pgm = new FileInfo(filename);
                    DarumaCol.Insert<IDL2Program>(new IDL2Program()
                    {
                        PgmID = pgm.Name.Replace(".id@", string.Empty),
                        IsMacro = true,
                        line = getLines(filename)
                    });
                }
            }
            ///获得本体的信息
            if (Directory.Exists(idl2MainFolder))
            {
                foreach (String filename in Directory.GetFiles(idl2MainFolder))
                {
                    FileInfo pgm = new FileInfo(filename);
                    DarumaCol.Insert<IDL2Program>(new IDL2Program()
                    {
                        PgmID = pgm.Name.Replace(".id@", string.Empty),
                        IsMacro = false,
                        line = getLines(filename)
                    });
                }
            }
            MessageBox.Show("Completed!");
        }
        /// <summary>
        /// 从《H2504_PGM別STEP数》获得所有Module名字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadFromExcel_Click(object sender, EventArgs e)
        {
            dynamic excelObj = Microsoft.VisualBasic.Interaction.CreateObject("Excel.Application");
            dynamic workbook = excelObj.Workbooks.Open(ExcelList);
            dynamic worksheet = workbook.Sheets(2);
            int rowcount = 3;
            if (DarumaDB.CollectionExists("Excel-PGM"))
            {
                DarumaDB.DropCollection("Excel-PGM");
            }
            MongoCollection DarumaCol = DarumaDB.GetCollection("Excel-PGM");
            while (worksheet.Cells(rowcount, 1).Text != String.Empty)
            {
                DarumaCol.Insert<DarumaProgram>(new DarumaProgram()
                {
                    PgmID = worksheet.Cells(rowcount, 1).Text,
                    Name = worksheet.Cells(rowcount, 2).Text,
                    Type = worksheet.Cells(rowcount, 3).Text
                });
                rowcount++;
            }
            //TODO:关闭Excel
        }
        private void btnWriteToExcel_Click(object sender, EventArgs e)
        {
            dynamic excelObj = Microsoft.VisualBasic.Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook = excelObj.Workbooks.Open(@"C:\Daruma\Tools\PgmList.xlsx");
            dynamic worksheet = workbook.Sheets(1);
            worksheet.Name = "ModuleCall";
            int rowcount = 1;
            int ColCount = 1;
            if (DarumaDB.CollectionExists("ModuleCall"))
            {
                MongoCollection DarumaCol = DarumaDB.GetCollection("ModuleCall");
                //数据库数据导入Excel
                foreach (ModuleCall item in DarumaCol.FindAllAs<ModuleCall>())
                {
                    worksheet.Cells(rowcount, 1).Value = item.PgmID;
                    rowcount++;
                    if (item.CalledModuleIDList != null)
                    {
                        worksheet.Cells(rowcount, 1).Value = "Module";
                        ColCount = 2;
                        foreach (var Module in item.CalledModuleIDList)
                        {
                            worksheet.Cells(rowcount, ColCount).Value = Module;
                            ColCount++;
                        }
                        rowcount++;
                    }
                    if (item.CalledMacroList != null)
                    {
                        worksheet.Cells(rowcount, 1).Value = "Macro";
                        ColCount = 2;
                        foreach (var Macro in item.CalledMacroList)
                        {
                            worksheet.Cells(rowcount, ColCount).Value = Macro;
                            ColCount++;
                        }
                        rowcount++;
                    }
                }
            }
        }
        private String GetArrayString(List<string> list)
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
        private void btnModuleCall_Click(object sender, EventArgs e)
        {
            if (DarumaDB.CollectionExists("ModuleCall"))
            {
                DarumaDB.DropCollection("ModuleCall");
            }
            MongoCollection DarumaCol = DarumaDB.GetCollection("ModuleCall");
            ///获得部品的信息
            if (Directory.Exists(idl2MainFolder))
            {
                foreach (String filename in Directory.GetFiles(idl2MainFolder))
                {
                    FileInfo pgm = new FileInfo(filename);
                    DarumaCol.Insert<ModuleCall>(new ModuleCall()
                    {
                        PgmID = pgm.Name.Replace(".TXT", string.Empty),
                        CalledModuleIDList = getCallModule(filename),
                        CalledMacroList = getCallMacro(filename)
                    });
                }
            }
            if (Directory.Exists(idl2MacroFolder))
            {
                foreach (String filename in Directory.GetFiles(idl2MacroFolder))
                {
                    FileInfo pgm = new FileInfo(filename);
                    DarumaCol.Insert<ModuleCall>(new ModuleCall()
                    {
                        PgmID = pgm.Name.Replace(".id@", string.Empty),
                        CalledModuleIDList = getCallModule(filename)
                        //不需要Macro信息
                    });
                }
            }
            MessageBox.Show("Completed!");
        }
        private List<String> getCallModule(String filename)
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
                    IsModuleName(lstModule, source);
                }
                else
                {
                    //END-OUTPUT : PROC KHXJYUUP(ＫＨＸＪＹＵＵＰ入出力域) .
                    if (source.Contains(" : PROC "))
                    {
                        source = source.Substring(source.IndexOf(" : PROC ") + 8).Trim();
                        IsModuleName(lstModule, source);
                    }
                }
            }
            return lstModule;
        }
        private static void IsModuleName(List<String> lstModule, String source)
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
        private List<String> getCallMacro(String filename)
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            DarumaDBServer.Disconnect();
        }
        private void btnGetBranch_Click(object sender, EventArgs e)
        {
            if (DarumaDB.CollectionExists("PmgStructure"))
            {
                DarumaDB.DropCollection("PmgStructure");
            }
            MongoCollection DarumaCol = DarumaDB.GetCollection("PmgStructure");

            dynamic excelObj = Microsoft.VisualBasic.Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook = excelObj.Workbooks.Open(@"C:\Daruma\Tools\PgmList.xlsx");
            dynamic worksheet = workbook.Sheets(3);
            worksheet.Select();
            worksheet.Name = "SyntaxSet";
            int rowcount = 1;
            int pgmcount = 0;
            if (Directory.Exists(idl2MainFolder))
            {
                //IDL2PgmStruct.NestInfo = new Dictionary<int, int>();
                foreach (String filename in Directory.GetFiles(idl2MainFolder))
                {
                    IDL2PgmStruct pgm = new IDL2PgmStruct();
                    pgm.PgmID = new FileInfo(filename).Name.TrimEnd(".TXT".ToCharArray());
                    pgm.Analyze(filename);
                    DarumaCol.Insert<IDL2PgmStruct>(pgm);
                    worksheet.Cells(rowcount, 1).Value = pgm.PgmID;
                    rowcount++;
                    rowcount = FillSyntaxToExcel(worksheet, rowcount, pgm);
                    pgmcount++;
                    if (pgmcount % 100 == 0) { workbook.Save(); }
                }
                //IDL2PgmStruct.ShowNestInfo();
            }
            MessageBox.Show("Complete!!PgmCount:" + pgmcount);
        }
        /// <summary>
        /// 语法树放入Excel
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="rowcount"></param>
        /// <param name="pgm"></param>
        /// <returns></returns>
        public static int FillSyntaxToExcel(dynamic worksheet, int rowcount, IDL2PgmStruct pgm)
        {
            foreach (var section in pgm.SectionList)
            {
                if (section.SyntaxList.Count != 0)
                {
                    foreach (var SyntaxLst in section.SyntaxList)
                    {
                        int colcount = 3;
                        worksheet.Cells(rowcount, 1).Value = pgm.PgmID;
                        worksheet.Cells(rowcount, 2).Value = section.SectionName;
                        foreach (var syntax in SyntaxLst)
                        {
                            //第一个CASE不需要出现在列表中
                            worksheet.Cells(rowcount, colcount).Value = syntax.SyntaxType;
                            colcount++;
                            worksheet.Cells(rowcount, colcount).Value = syntax.LineNo;
                            colcount++;
                            worksheet.Cells(rowcount, colcount).Value = syntax.NestLv;
                            colcount++;
                        }
                        rowcount++;
                    }
                }
                else {
                    worksheet.Cells(rowcount, 1).Value = pgm.PgmID;
                    worksheet.Cells(rowcount, 2).Value = section.SectionName;
                    rowcount++;
                }
            }
            return rowcount;
        }

        /// <summary>
        /// 语法树放入Excel
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="rowcount"></param>
        /// <param name="pgm"></param>
        /// <returns></returns>
        private static int FillSyntaxToExcel_OLD(dynamic worksheet, int rowcount, IDL2PgmStruct pgm)
        {
            foreach (var section in pgm.SectionList_OLD)
            {
                if (section.SyntaxSetList.Count != 0)
                {
                    foreach (var syntaxset in section.SyntaxSetList)
                    {
                        if (syntaxset.BranchNo == 0) continue;
                        worksheet.Cells(rowcount, 1).Value = pgm.PgmID;
                        worksheet.Cells(rowcount, 2).Value = section.SectionName;
                        worksheet.Cells(rowcount, 3).Value = syntaxset.SyntaxSetType +
                            (string.IsNullOrEmpty(syntaxset.ExtendInfo) ? String.Empty : "@" + syntaxset.ExtendInfo);
                        int colcount = 5;
                        HashSet<String> TestItem = new HashSet<string>();
                        foreach (var syntax in syntaxset.SyntaxList)
                        {
                            if (syntax.Cond != null)
                            {
                                foreach (var item in syntax.Cond.TestItemLst)
                                {
                                    if (!TestItem.Contains(item))
                                    {
                                        TestItem.Add(item);
                                    };
                                }
                            }
                            if (syntax.SyntaxType != "CASE")
                            {
                                //第一个CASE不需要出现在列表中
                                worksheet.Cells(rowcount, colcount).Value = syntax.SyntaxType;
                                colcount++;
                                worksheet.Cells(rowcount, colcount).Value = syntax.LineNo;
                                colcount++;
                                worksheet.Cells(rowcount, colcount).Value = syntax.NestLv;
                                //if (syntax.NestLv > 7) {
                                //    System.Diagnostics.Debug.WriteLine(syntax.NestLv);
                                //}
                                colcount++;
                                worksheet.Cells(rowcount, colcount).Value = String.IsNullOrEmpty(syntax.ExtendInfo) ? "" : syntax.ExtendInfo.Trim();
                                colcount++;
                                worksheet.Cells(rowcount, colcount).Value = String.IsNullOrEmpty(syntax.Result) ? "" : syntax.Result.Trim();
                                colcount++;
                            }
                        }
                        //实验项目
                        Boolean IsSpec = false;
                        if (syntaxset.SyntaxSetType == "CASE" && syntaxset.SyntaxList[0].ExtendInfo.Equals("#TRUE#"))
                        {
                            worksheet.Cells(rowcount, 4).Value = "CASEの子条件分岐";
                            IsSpec = true;
                        }
                        if (TestItem.Count == 0)
                        {
                            switch (syntaxset.SyntaxSetType)
                            {
                                case "FOR":
                                case "LOOP":
                                case "WHILE":
                                case "REPEAT":
                                    worksheet.Cells(rowcount, 4).Value = "無限ループ";
                                    IsSpec = true;
                                    break;
                                case "GET":
                                    worksheet.Cells(rowcount, 4).Value = "ファイルの読み込む終了";
                                    IsSpec = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (!IsSpec)
                        {
                            String strTestItem = String.Empty;
                            foreach (var item in TestItem)
                            {
                                strTestItem += "[ " + item + " ]、";
                            }
                            strTestItem = strTestItem.Substring(0, strTestItem.Length - 1);
                            switch (syntaxset.SyntaxSetType)
                            {
                                case "IF":
                                    strTestItem += " の条件分岐判定";
                                    break;
                                case "CASE":
                                    strTestItem += " の多条件分岐判定";
                                    break;
                                case "FOR":
                                case "LOOP":
                                case "WHILE":
                                case "REPEAT":
                                    strTestItem += " のループ処理の判定";
                                    break;
                                default:
                                    break;
                            }
                            worksheet.Cells(rowcount, 4).Value = strTestItem;
                        }
                        rowcount++;
                    }
                }
                else
                {
                    worksheet.Cells(rowcount, 1).Value = pgm.PgmID;
                    worksheet.Cells(rowcount, 2).Value = section.SectionName;
                    rowcount++;
                }
            }
            return rowcount;
        }

        internal class MarcoPatter
        {
            [BsonId]
            public String MacroName;
            public List<MacroPatterDetail> MacroPatterDetailList;
            public int count;
            public int MaxParaCount;
        }
        internal class MacroPatterDetail
        {
            public string Pattern;
            public List<String> Para;
            public String PatternKey;
        }
        private void GetCopy(String IDWFile, String PgmID, Boolean HasLineNo, HashSet<String> CopyHash)
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
        private void btnWriteToExcelPatternList_Click(object sender, EventArgs e)
        {
            dynamic excelObj = Microsoft.VisualBasic.Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook = excelObj.Workbooks.Open(@"C:\Daruma\Tools\PgmList.xlsx");
            dynamic worksheet = workbook.Sheets(2);
            worksheet.Select();
            worksheet.Name = "PatternList";
            int rowcount = 1;
            if (DarumaDB.CollectionExists("MacroPattenList"))
            {
                MongoCollection DarumaCol = DarumaDB.GetCollection("MacroPattenList");
                //数据库数据导入Excel
                foreach (MarcoPatter item in DarumaCol.FindAllAs<MarcoPatter>())
                {
                    //if (item.MacroPatterDetailList.Count < 2000)
                    //{
                    //    continue;
                    //}
                    worksheet.Cells(rowcount, 1).Value = item.MacroName;
                    worksheet.Cells(rowcount, 2).Value = item.MaxParaCount;
                    rowcount++;
                    if (rowcount % 10000 == 0) { workbook.Save(); }
                    foreach (var pattern in item.MacroPatterDetailList)
                    {
                        worksheet.Cells(rowcount, 1).Value = item.MacroName;
                        worksheet.Cells(rowcount, 2).Value = pattern.PatternKey;
                        worksheet.Cells(rowcount, 3).Value = pattern.Pattern;
                        for (int i = 0; i < pattern.Para.Count; i++)
                        {
                            if (!String.IsNullOrEmpty(pattern.Para[i]))
                            {
                                worksheet.Cells(rowcount, i + 4).Value = pattern.Para[i];
                            }
                        }
                        rowcount++;
                        if (rowcount % 10000 == 0) { workbook.Save(); }
                    }
                }
            }
            workbook.Save();
            MessageBox.Show("OK");
        }
        private void btnMarcoPatten_Click(object sender, EventArgs e)
        {
            if (DarumaDB.CollectionExists("MacroPattenList"))
            {
                DarumaDB.DropCollection("MacroPattenList");
            }
            MongoCollection DarumaCol = DarumaDB.GetCollection("MacroPattenList");
            StreamReader sr = new StreamReader(MacroCallPatten, System.Text.Encoding.Default);
            String source;
            String LastMarcoName = String.Empty;
            String CurrentMarcoName = String.Empty;
            MarcoPatter t = new MarcoPatter();
            while (!sr.EndOfStream)
            {
                source = sr.ReadLine();
                CurrentMarcoName = source.Substring(0, source.IndexOf("("));
                if (CurrentMarcoName != LastMarcoName)
                {
                    if (!String.IsNullOrEmpty(LastMarcoName))
                    {
                        t.count = t.MacroPatterDetailList.Count;
                        t.MaxParaCount = SortParm(t.MacroPatterDetailList);
                        DarumaCol.Insert<MarcoPatter>(t);
                    }
                    t.MacroName = CurrentMarcoName;
                    t.MacroPatterDetailList = new List<MacroPatterDetail>();
                    LastMarcoName = CurrentMarcoName;
                }
                List<String> paralst = new List<string>();
                String SortKey = String.Empty;
                source = source.Trim();
                source = source.Replace("( )", "()");
                String[] Para = source.Substring(source.IndexOf("(") + 1)
                                                               .TrimEnd(")".ToCharArray())
                                                               .Split(",".ToCharArray());
                foreach (String para in Para)
                {
                    if (String.IsNullOrWhiteSpace(para))
                    {
                        paralst.Add(String.Empty);
                        SortKey = SortKey + "0";
                    }
                    else
                    {
                        paralst.Add(para);
                        SortKey = SortKey + "1";
                    }
                }

                t.MacroPatterDetailList.Add(new MacroPatterDetail()
                {
                    Pattern = source,
                    Para = paralst,
                    PatternKey = SortKey
                });
            }
            t.count = t.MacroPatterDetailList.Count;
            t.MaxParaCount = SortParm(t.MacroPatterDetailList);
            DarumaCol.Insert<MarcoPatter>(t);
            sr.Close();
        }
        private int SortParm(List<MacroPatterDetail> Patternlst)
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
        private void btnStartUpMongoDB_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\MagicMongoDBTool\MagicMongoDBTool\ServerLoader\Daruma.bat");
        }
        private void btnLinkage_Click(object sender, EventArgs e)
        {
            if (DarumaDB.CollectionExists("Linkage"))
            {
                DarumaDB.DropCollection("Linkage");
            }
            MongoCollection DarumaCol = DarumaDB.GetCollection("Linkage");

            dynamic excelObj = Microsoft.VisualBasic.Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook = excelObj.Workbooks.Open(@"C:\Daruma\Tools\PgmList.xlsx");
            dynamic worksheet = workbook.Sheets(4);
            worksheet.Select();
            worksheet.Name = "Linkage";
            int rowcount = 1;
            int colcount = 1;

            ///获得部品的信息
            if (Directory.Exists(idwFolder))
            {
                foreach (String filename in Directory.GetFiles(idwFolder))
                {
                    FileInfo pgm = new FileInfo(filename);
                    IDL2ProgramLinkage t = new IDL2ProgramLinkage()
                    {
                        PgmID = pgm.Name.Replace(".idw", string.Empty),
                        Linkage = getLinkage(filename)
                    };
                    if (t.Linkage.Count != 0)
                    {
                        colcount = 1;
                        DarumaCol.Insert<IDL2ProgramLinkage>(t);
                        worksheet.Cells(rowcount, colcount).Value = t.PgmID;
                        foreach (var item in t.Linkage)
                        {
                            colcount++;
                            worksheet.Cells(rowcount, colcount).Value = item;
                        }
                        rowcount++;
                    }
                }
            }
        }
        private List<string> getLinkage(string filename)
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
    }
}
