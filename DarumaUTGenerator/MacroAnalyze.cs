using System;
using System.IO;
using System.Windows.Forms;

namespace DarumaUTGenerator
{
    public partial class MacroAnalyze : Form
    {
        public MacroAnalyze()
        {
            InitializeComponent();
        }
        private string idlFilename = string.Empty;

        private void btnRun_Click(object sender, EventArgs e)
        {
            IDL2MacroStruct pgm = new IDL2MacroStruct();
            pgm.PgmID = new FileInfo(idlFilename).Name.TrimEnd(".TXT".ToCharArray());
            pgm.GetParm(idlFilename);
            lstParm.Items.Clear();
            lstBranch.Clear();
            lstBranch.Columns.Add("種類");
            lstBranch.Columns.Add("ネスト");
            lstBranch.Columns.Add("行番号");
            lstBranch.Columns.Add("条件");

            lstKeySet.Columns.Add("№");
            foreach (var item in pgm.Parmlst)
            {
                ListViewItem parm = new ListViewItem(item.Name);
                parm.SubItems.Add(item.Type);
                parm.SubItems.Add(item.Speics);
                lstParm.Items.Add(parm);
                lstBranch.Columns.Add(item.Name);
                lstKeySet.Columns.Add(item.Name);
            }
            pgm.Analyze(idlFilename, true);
            foreach (var TopSyntaxItem in pgm.TopSyntax)
            {
                foreach (var SyntaxItem in TopSyntaxItem)
                {
                    if (SyntaxItem.SyntaxType != "#ELSE")
                    {
                        ListViewItem parm = new ListViewItem(SyntaxItem.SyntaxType);
                        parm.SubItems.Add(SyntaxItem.NestLv.ToString());
                        parm.SubItems.Add(SyntaxItem.LineNo.ToString());
                        if (SyntaxItem.Cond == null)
                        {
                            parm.SubItems.Add(String.Empty);
                        }
                        else
                        {
                            parm.SubItems.Add(SyntaxItem.Cond.OrgCondition);
                            foreach (var parmI in pgm.Parmlst)
                            {
                                if (SyntaxItem.Cond.OrgCondition.Equals("&" + parmI.Name) || SyntaxItem.Cond.OrgCondition.StartsWith("&" + parmI.Name + " "))
                                {
                                    parm.SubItems.Add("○");
                                }
                                else
                                {
                                    parm.SubItems.Add(String.Empty);
                                }
                            }
                        }
                        lstBranch.Items.Add(parm);
                    }
                }
            }
            lstBranch.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            pgm.Pattern();
            int No = 1;
            foreach (var Keys in pgm.PattenList)
            {
                ListViewItem parmViewItem = new ListViewItem(No.ToString());
                String Value = String.Empty;
                foreach (var parm in pgm.Parmlst)
                {
                    foreach (var item in Keys)
                    {
                        if (parm.Name == item.Key) Value = item.Value;
                    }
                    parmViewItem.SubItems.Add(Value);
                }
                lstKeySet.Items.Add(parmViewItem);
                No++;
            }
            //GenerateUTSheet.GenerateUT(pgm, @"C:\Daruma\Tools\模板\UT試験仕様書(条件分岐確認).xls");
        }

        private void btnSourcePick_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "IDL2ソース(*.TXT)|*.TXT|すべて(*.*)|*.*";
            if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                idlFilename = of.FileName;
                lblIDL2File.Text = "ＩＤＬソース：" + idlFilename;
            }
        }
    }
}
