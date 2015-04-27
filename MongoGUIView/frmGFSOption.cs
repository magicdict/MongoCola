using System;
using System.IO;
using System.Windows.Forms;
using MongoUtility.Basic;
using ResourceLib.Utility;

namespace MongoGUIView
{
    public partial class frmGFSOption : Form
    {
        public Char DirectorySeparatorChar = Path.PathSeparator;
        public GFS.enumGFSFileName filename;
        public Boolean ignoreSubFolder;
        public GFS.enumGFSAlready option;

        public frmGFSOption()
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
            filename = radFilename.Checked ? GFS.enumGFSFileName.Filename : GFS.enumGFSFileName.Path;
            if (radAddIt.Checked)
            {
                option = GFS.enumGFSAlready.JustAddIt;
            }
            if (radOverwrite.Checked)
            {
                option = GFS.enumGFSAlready.OverwriteIt;
            }
            if (radRenameIt.Checked)
            {
                option = GFS.enumGFSAlready.RenameIt;
            }
            if (radSkipIt.Checked)
            {
                option = GFS.enumGFSAlready.SkipIt;
            }
            if (radStopIt.Checked)
            {
                option = GFS.enumGFSAlready.Stop;
            }
            if (txtSeperateChar.Text != string.Empty)
            {
                DirectorySeparatorChar = txtSeperateChar.Text.ToCharArray()[0];
            }
            ignoreSubFolder = chkIgnore.Checked;
            Close();
        }

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGFSOption_Load(object sender, EventArgs e)
        {
           GUIConfig.Translateform(this);
        }
    }
}