using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class frmGFSOption : Form
    {
        public MongoDBHelper.enumGFSFileName filename;
        public MongoDBHelper.enumGFSAlready option;

        public frmGFSOption()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (radFilename.Checked)
            {
                filename = MongoDBHelper.enumGFSFileName.filename;
            }
            else
            {
                filename = MongoDBHelper.enumGFSFileName.path;
            }
            if (this.radAddIt.Checked) { option = MongoDBHelper.enumGFSAlready.JustAddIt; }
            if (this.radOverwrite.Checked) { option = MongoDBHelper.enumGFSAlready.OverwriteIt; }
            if (this.radRenameIt.Checked) { option = MongoDBHelper.enumGFSAlready.RenameIt; }
            if (this.radSkipIt.Checked) { option = MongoDBHelper.enumGFSAlready.SkipIt; }
            if (this.radStopIt.Checked) { option = MongoDBHelper.enumGFSAlready.Stop; }
            this.Close();
        }

    }
}
