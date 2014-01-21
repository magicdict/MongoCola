using System;
using System.IO;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmGFSOption : Form
    {
        public Char DirectorySeparatorChar = Path.PathSeparator;
        public MongoDbHelper.enumGFSFileName filename;
        public Boolean ignoreSubFolder;
        public MongoDbHelper.enumGFSAlready option;

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
            filename = radFilename.Checked ? MongoDbHelper.enumGFSFileName.Filename : MongoDbHelper.enumGFSFileName.Path;
            if (radAddIt.Checked)
            {
                option = MongoDbHelper.enumGFSAlready.JustAddIt;
            }
            if (radOverwrite.Checked)
            {
                option = MongoDbHelper.enumGFSAlready.OverwriteIt;
            }
            if (radRenameIt.Checked)
            {
                option = MongoDbHelper.enumGFSAlready.RenameIt;
            }
            if (radSkipIt.Checked)
            {
                option = MongoDbHelper.enumGFSAlready.SkipIt;
            }
            if (radStopIt.Checked)
            {
                option = MongoDbHelper.enumGFSAlready.Stop;
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
                SystemManager.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_RemoteFileName);
            radFilename.Text =
                SystemManager.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_OnlyFilename);
            radFullPath.Text =
                SystemManager.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_FullPath);
            grpFileAlreadyExist.Text =
                SystemManager.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_FileAlreadyExist);
            radAddIt.Text =
                SystemManager.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_JustAddIt);
            radOverwrite.Text =
                SystemManager.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_Overwrite);
            radRenameIt.Text =
                SystemManager.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_Rename);
            radSkipIt.Text = SystemManager.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_SkipIt);
            radStopIt.Text = SystemManager.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_Stop);
            chkIgnore.Text =
                SystemManager.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_IngoreSubFolder);
            lblSeperateChar.Text =
                SystemManager.MStringResource.GetText(
                    StringResource.TextType.GFS_Insert_Option_DirectorySeparatorChar);
            cmdOK.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Common_OK);
        }
    }
}