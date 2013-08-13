using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
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
            this.ctlMongodPanel.CommandChanged += new EventHandler<TextChangeEventArgs>(
                (x, y) => { CommandChanged(y.NewString); }
            );
            this.ctlMongodumpPanel.CommandChanged += new EventHandler<TextChangeEventArgs>(
                (x, y) => { CommandChanged(y.NewString); }
            );
            this.ctlMongoImportExportPanel.CommandChanged += new EventHandler<TextChangeEventArgs>(
                (x, y) => { CommandChanged(y.NewString); }
            );
            if (!SystemManager.IsUseDefaultLanguage)
            {
                cmdSave.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Save);
                cmdRunDos.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Run);
                tabMongod.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Tab_Deploy);
                tabMongoDump.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Tab_Backup);
                tabMongoImportExport.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Tab_ExIn);
            }
        }
        /// <summary>
        /// //命令参数变化
        /// </summary>
        /// <param name="strCommandLine"></param>
        void CommandChanged(String strCommandLine)
        {
            this.txtDosCommand.Text = strCommandLine;
            StrSaveText = strCommandLine;
        }
        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRunDos_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (this.txtDosCommand.Text != String.Empty)
            {
                MongodbDosCommand.RunDosCommand(txtDosCommand.Text, sb);
                this.txtDosCommand.Text += System.Environment.NewLine;
                this.txtDosCommand.Text += sb.ToString();
            }
        }
        /// <summary>
        /// 保存配置文件内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = MongoDBHelper.ConfFilter;
            if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter save = new StreamWriter(savefile.FileName);
                save.Write(StrSaveText);
                save.Close();
            }
        }
    }
}
