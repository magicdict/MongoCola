using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Common;
using MongoUtility.ToolKit;
using ResourceLib.Method;

namespace PlugInPackage.DosCommand
{
    public partial class FrmDosCommand : Form
    {
        public string StrSaveText = string.Empty;

        public FrmDosCommand()
        {
            InitializeComponent();
        }

        private void frmDosCommand_Load(object sender, EventArgs e)
        {
            //命令参数变化
            ctlMongodPanel.CommandChanged += (x, y) => CommandChanged(y.NewString);
            ctlMongodumpPanel.CommandChanged += (x, y) => CommandChanged(y.NewString);
            ctlMongoImportExportPanel.CommandChanged += (x, y) => CommandChanged(y.NewString);
            if (GuiConfig.IsUseDefaultLanguage)
                return;
            cmdSave.Text = GuiConfig.GetText(TextType.CommonSave);
            cmdRunDos.Text = GuiConfig.GetText(TextType.DosCommandRun);
            tabMongod.Text = GuiConfig.GetText(TextType.DosCommandTabDeploy);
            tabMongoDump.Text = GuiConfig.GetText(TextType.DosCommandTabBackup);
            tabMongoImportExport.Text =
                GuiConfig.GetText(TextType.DosCommandTabExIn);
        }

        /// <summary>
        ///     //命令参数变化
        /// </summary>
        /// <param name="strCommandLine"></param>
        private void CommandChanged(string strCommandLine)
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
            if (txtDosCommand.Text == string.Empty)
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