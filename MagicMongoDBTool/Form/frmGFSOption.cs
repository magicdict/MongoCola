using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmGFSOption : Form
    {
        public MongoDBHelper.enumGFSFileName filename;
        public MongoDBHelper.enumGFSAlready option;
        public Boolean ignoreSubFolder;
        public Char DirectorySeparatorChar = System.IO.Path.PathSeparator;
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
            if (this.txtSeperateChar.Text != String.Empty)
            {
                DirectorySeparatorChar = this.txtSeperateChar.Text.ToCharArray()[0];
            }
            ignoreSubFolder = chkIgnore.Checked;
            this.Close();
        }

        private void frmGFSOption_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage)
            {
                grpFilename.Text = SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_RemoteFileName);
                radFilename.Text = SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_OnlyFilename);
                radFullPath.Text = SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_FullPath);
                grpFileAlreadyExist.Text = SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_FileAlreadyExist);
                radAddIt.Text = SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_JustAddIt);
                radOverwrite.Text = SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_Overwrite);
                radRenameIt.Text = SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_Rename);
                radSkipIt.Text = SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_SkipIt);
                radStopIt.Text = SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_Stop);
                chkIgnore.Text = SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_IngoreSubFolder);
                lblSeperateChar.Text = SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_DirectorySeparatorChar);
                cmdOK.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_OK);
            }
        }

    }
}
