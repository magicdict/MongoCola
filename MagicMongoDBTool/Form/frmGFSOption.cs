using System;
using System.IO;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmGFSOption : Form
    {
        public Char DirectorySeparatorChar = Path.PathSeparator;
        public MongoDBHelper.enumGFSFileName filename;
        public Boolean ignoreSubFolder;
        public MongoDBHelper.enumGFSAlready option;

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
            if (radFilename.Checked)
            {
                filename = MongoDBHelper.enumGFSFileName.filename;
            }
            else
            {
                filename = MongoDBHelper.enumGFSFileName.path;
            }
            if (radAddIt.Checked)
            {
                option = MongoDBHelper.enumGFSAlready.JustAddIt;
            }
            if (radOverwrite.Checked)
            {
                option = MongoDBHelper.enumGFSAlready.OverwriteIt;
            }
            if (radRenameIt.Checked)
            {
                option = MongoDBHelper.enumGFSAlready.RenameIt;
            }
            if (radSkipIt.Checked)
            {
                option = MongoDBHelper.enumGFSAlready.SkipIt;
            }
            if (radStopIt.Checked)
            {
                option = MongoDBHelper.enumGFSAlready.Stop;
            }
            if (txtSeperateChar.Text != String.Empty)
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
            if (SystemManager.IsUseDefaultLanguage) return;
            grpFilename.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_RemoteFileName);
            radFilename.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_OnlyFilename);
            radFullPath.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_FullPath);
            grpFileAlreadyExist.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_FileAlreadyExist);
            radAddIt.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_JustAddIt);
            radOverwrite.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_Overwrite);
            radRenameIt.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_Rename);
            radSkipIt.Text = SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_SkipIt);
            radStopIt.Text = SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_Stop);
            chkIgnore.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.GFS_Insert_Option_IngoreSubFolder);
            lblSeperateChar.Text =
                SystemManager.mStringResource.GetText(
                    StringResource.TextType.GFS_Insert_Option_DirectorySeparatorChar);
            cmdOK.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_OK);
        }
    }
}