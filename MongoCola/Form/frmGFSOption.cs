using System;
using System.IO;
using System.Windows.Forms;
using MongoCola.Module;
using MongoUtility;


namespace MongoCola
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
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_RemoteFileName);
            radFilename.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_OnlyFilename);
            radFullPath.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_FullPath);
            grpFileAlreadyExist.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_FileAlreadyExist);
            radAddIt.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_JustAddIt);
            radOverwrite.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_Overwrite);
            radRenameIt.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_Rename);
            radSkipIt.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_SkipIt);
            radStopIt.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_Stop);
            chkIgnore.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.GFS_Insert_Option_IngoreSubFolder);
            lblSeperateChar.Text =
                SystemManager.guiConfig.MStringResource.GetText(
                    StringResource.TextType.GFS_Insert_Option_DirectorySeparatorChar);
            cmdOK.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_OK);
        }
    }
}