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
                    Utilty.GetCopy(PgmCopy, filename, pgm.Name.Replace(".idw", string.Empty), false, CopyHash);
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
                        line = Utilty.getLines(filename)
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
                        line = Utilty.getLines(filename)
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
            //关闭Excel
            excelObj = null;
        }
        /// <summary>
        /// 每本程序使用的Module和Macro的输出Excel方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            excelObj = null;
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
                        CalledModuleIDList = Utilty.getCallModule(filename),
                        CalledMacroList = Utilty.getCallMacro(filename)
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
                        CalledModuleIDList = Utilty.getCallModule(filename)
                        //不需要Macro信息
                    });
                }
            }
            MessageBox.Show("Completed!");
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
                    worksheet.Cells(rowcount, 2).Value = pgm.MaxNestLv;
                    rowcount++;
                    rowcount = FillSyntaxToExcel(worksheet, rowcount, pgm);
                    pgmcount++;
                    if (pgmcount % 100 == 0) { workbook.Save(); }
                }
                //IDL2PgmStruct.ShowNestInfo();
            }
            MessageBox.Show("Complete!!PgmCount:" + pgmcount);
            excelObj = null;
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
                //为了便于填写，每个Section都有独立标示行
                worksheet.Cells(rowcount, 1).Value = pgm.PgmID;
                worksheet.Cells(rowcount, 2).Value = section.SectionName;
                rowcount++;
                foreach (var SyntaxLst in section.SyntaxList)
                {
                    worksheet.Cells(rowcount, 1).Value = pgm.PgmID;
                    worksheet.Cells(rowcount, 2).Value = section.SectionName;
                    int colcount = 3;
                    foreach (var syntax in SyntaxLst)
                    {
                        //第一个CASE不需要出现在列表中
                        worksheet.Cells(rowcount, colcount).Value = syntax.SyntaxType;
                        colcount++;
                        worksheet.Cells(rowcount, colcount).Value = syntax.LineNo;
                        colcount++;
                        worksheet.Cells(rowcount, colcount).Value = syntax.NestLv;
                        colcount++;
                        worksheet.Cells(rowcount, colcount).Value = syntax.ExtendInfo;
                        colcount++;
                    }
                    rowcount++;
                }
            }
            return rowcount;
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
                foreach (Utilty.MarcoPatter item in DarumaCol.FindAllAs<Utilty.MarcoPatter>())
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
            Utilty.MarcoPatter t = new Utilty.MarcoPatter();
            while (!sr.EndOfStream)
            {
                source = sr.ReadLine();
                CurrentMarcoName = source.Substring(0, source.IndexOf("("));
                if (CurrentMarcoName != LastMarcoName)
                {
                    if (!String.IsNullOrEmpty(LastMarcoName))
                    {
                        t.count = t.MacroPatterDetailList.Count;
                        t.MaxParaCount = Utilty.SortParm(t.MacroPatterDetailList);
                        DarumaCol.Insert<DarumaTool.Utilty.MarcoPatter>(t);
                    }
                    t.MacroName = CurrentMarcoName;
                    t.MacroPatterDetailList = new List<DarumaTool.Utilty.MacroPatterDetail>();
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

                t.MacroPatterDetailList.Add(new DarumaTool.Utilty.MacroPatterDetail()
                {
                    Pattern = source,
                    Para = paralst,
                    PatternKey = SortKey
                });
            }
            t.count = t.MacroPatterDetailList.Count;
            t.MaxParaCount = Utilty.SortParm(t.MacroPatterDetailList);
            DarumaCol.Insert<DarumaTool.Utilty.MarcoPatter>(t);
            sr.Close();
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
                        Linkage = Utilty.getLinkage(filename)
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
            excelObj = null;
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
        /// 启动MongoDB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartUpMongoDB_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\MagicMongoDBTool\MagicMongoDBTool\ServerLoader\Daruma.bat");
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            GC.Collect();
            DarumaDBServer.Disconnect();
        }
        #region"废止"
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
                        if (syntaxset.SyntaxSetType == "CASE" && syntaxset.SyntaxList[0].ExtendInfo.Equals(IDL2PgmStruct.TrueFlg))
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
        #endregion
    }
}
