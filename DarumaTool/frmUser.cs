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
        private string UTFilename = string.Empty;

        private void btnSourcePick_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "IDL2ソース(*.TXT)|*.TXT";
            if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                idlFilename = of.FileName;
                lblIDL2File.Text = "ＩＤＬソース：" + idlFilename;
            }
        }
        private void btnAnlyze_Click(object sender, EventArgs e)
        {
            //idlFilename = @"C:\Daruma\WorkShop\01.IDLIIソース_0\AHQM1SH6.TXT";
            //UTFilename = @"C:\Daruma\Tools\XXXXXXXXX_UT試験仕様書(本体＆部品).xls";
            IDL2PgmStruct pgm = new IDL2PgmStruct();
            pgm.PgmID = new FileInfo(idlFilename).Name.TrimEnd(".TXT".ToCharArray());
            pgm.Analyze(idlFilename);
            GenerateUTSheet.GenerateUT(pgm,UTFilename);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            System.GC.Collect();
            this.Close();
        }

        private void btnUTPick_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "ＵＴ仕様書(*.xls)|*.XLS";
            if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UTFilename = of.FileName;
                lblUTFile.Text = "ＵＴ仕様書：" + UTFilename;
            }

        }


    }
}
