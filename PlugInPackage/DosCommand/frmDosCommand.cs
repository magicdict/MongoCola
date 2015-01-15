using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Common;
using MongoUtility.ExteneralTool;
using ResourceLib;

namespace PlugInPackage
{
    public partial class frmDosCommand : Form
    {
        public String StrSaveText = String.Empty;

        public frmDosCommand()
        {
            InitializeComponent();
        }

        private void frmDosCommand_Load(object sender, EventArgs e)
        {
            //命令参数变化
            ctlMongodPanel.CommandChanged += (x, y) => CommandChanged(y.NewString);
            ctlMongodumpPanel.CommandChanged += (x, y) => CommandChanged(y.NewString);
            ctlMongoImportExportPanel.CommandChanged += (x, y) => CommandChanged(y.NewString);
            if (PlugIn.guiConfig.IsUseDefaultLanguage)
                return;
            cmdSave.Text = PlugIn.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Save);
            cmdRunDos.Text = PlugIn.guiConfig.MStringResource.GetText(StringResource.TextType.DosCommand_Run);
            tabMongod.Text = PlugIn.guiConfig.MStringResource.GetText(StringResource.TextType.DosCommand_Tab_Deploy);
            tabMongoDump.Text = PlugIn.guiConfig.MStringResource.GetText(StringResource.TextType.DosCommand_Tab_Backup);
            tabMongoImportExport.Text =
                PlugIn.guiConfig.MStringResource.GetText(StringResource.TextType.DosCommand_Tab_ExIn);
        }

        /// <summary>
        ///     //命令参数变化
        /// </summary>
        /// <param name="strCommandLine"></param>
        private void CommandChanged(String strCommandLine)
        {
            txtDosCommand.Text = strCommandLine;
            StrSaveText = strCommandLine;
        }

        /// <summary>
        ///     运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRunDos_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            if (txtDosCommand.Text == String.Empty)
                return;
            MongodbDosCommand.RunDosCommand(txtDosCommand.Text, sb);
            txtDosCommand.Text += Environment.NewLine;
            txtDosCommand.Text += sb.ToString();
        }

        /// <summary>
        ///     保存配置文件内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            var savefile = new SaveFileDialog {Filter = Utility.ConfFilter};
            if (savefile.ShowDialog() != DialogResult.OK)
                return;
            var save = new StreamWriter(savefile.FileName);
            save.Write(StrSaveText);
            save.Close();
        }
    }
}