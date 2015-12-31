using System;
using System.IO;
using System.Windows.Forms;
using MongoUtility.Command;
using ResourceLib.Method;

namespace MongoGUIView
{
    public partial class FrmGfsOption : Form
    {
        public char DirectorySeparatorChar = Path.PathSeparator;
        public Gfs.EnumGfsFileName Filename;
        public bool IgnoreSubFolder;
        public Gfs.EnumGfsAlready Option;

        public FrmGfsOption()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            Filename = radFilename.Checked ? Gfs.EnumGfsFileName.Filename : Gfs.EnumGfsFileName.Path;
            if (radAddIt.Checked)
            {
                Option = Gfs.EnumGfsAlready.JustAddIt;
            }
            if (radOverwrite.Checked)
            {
                Option = Gfs.EnumGfsAlready.OverwriteIt;
            }
            if (radRenameIt.Checked)
            {
                Option = Gfs.EnumGfsAlready.RenameIt;
            }
            if (radSkipIt.Checked)
            {
                Option = Gfs.EnumGfsAlready.SkipIt;
            }
            if (radStopIt.Checked)
            {
                Option = Gfs.EnumGfsAlready.Stop;
            }
            if (txtSeperateChar.Text != string.Empty)
            {
                DirectorySeparatorChar = txtSeperateChar.Text.ToCharArray()[0];
            }
            IgnoreSubFolder = chkIgnore.Checked;
            Close();
        }

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGFSOption_Load(object sender, EventArgs e)
        {
            GuiConfig.Translateform(this);
        }
    }
}