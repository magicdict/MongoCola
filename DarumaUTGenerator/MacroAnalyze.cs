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
            IDL2PgmStruct pgm = new IDL2PgmStruct();
            pgm.PgmID = new FileInfo(idlFilename).Name.TrimEnd(".TXT".ToCharArray());
            pgm.Analyze(idlFilename);
        }

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
    }
}
