using System;
using System.IO;
using System.Windows.Forms;

namespace DarumaTool
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }
        private string idlFilename = string.Empty;
        dynamic excelObj = Microsoft.VisualBasic.Interaction.CreateObject("Excel.Application");
        private void btnSourcePick_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "IDL2ソース(*.TXT)|*.TXT";
            if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                idlFilename = of.FileName;
                lblTitle.Text = "ＩＤＬソース：" + idlFilename;
            }
        }
        private void btnAnlyze_Click(object sender, EventArgs e)
        {
            excelObj.Visible = true;
            dynamic workbook = excelObj.Workbooks.Add();
            dynamic worksheet = workbook.Sheets(3);
            worksheet.Select();
            worksheet.Name = "SyntaxSet";
            int rowcount = 1;
            IDL2PgmStruct pgm = new IDL2PgmStruct();
            pgm.PgmID = new FileInfo(idlFilename).Name.TrimEnd(".TXT".ToCharArray());
            pgm.Analyze(idlFilename);
            worksheet.Cells(rowcount, 1).Value = pgm.PgmID;
            rowcount++;
            rowcount = frmMenu.FillSyntaxToExcel(worksheet, rowcount, pgm);
            excelObj = null;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            System.GC.Collect();
            this.Close();
        }
    }
}
