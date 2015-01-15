using System;
using System.Windows.Forms;
using MongoUtility.Basic;
using MongoUtility.Core;
using ResourceLib.Utility;

namespace MongoGUICtl
{
    public partial class ctlMongodump : UserControl
    {
        private readonly MongodbDosCommand.StruMongoDump MongodumpCommand = new MongodbDosCommand.StruMongoDump();
        public EventHandler<TextChangeEventArgs> CommandChanged;

        public ctlMongodump(GUIConfig GUIConfig = null)
        {
            InitializeComponent();
            if (GUIConfig == null)
                return;
            if (!configuration.guiConfig.IsUseDefaultLanguage)
            {
                lblCollectionName.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.DosCommand_Tab_Backup_DCName);
                lblDBName.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.DosCommand_Tab_Backup_DBName);
                lblHostAddr.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.DosCommand_Tab_Backup_Server);
                lblPort.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.DosCommand_Tab_Backup_Port);
                ctlFilePickerOutput.Title =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.DosCommand_Tab_Backup_Path);
            }
        }

        private void ctlMongodump_Load(object sender, EventArgs e)
        {
            ctllogLvT.LoglvChanged += ctllogLvT_LoglvChanged;
            ctlFilePickerOutput.PathChanged += ctlFilePickerOutput_PathChanged;
        }

        protected virtual void OnCommandChange(TextChangeEventArgs e)
        {
            e.Raise(this, ref CommandChanged);
        }

        private void ctlFilePickerOutput_PathChanged(String FilePath)
        {
            MongodumpCommand.OutPutPath = FilePath;
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand)));
        }

        private void ctllogLvT_LoglvChanged(MongodbDosCommand.MongologLevel logLv)
        {
            MongodumpCommand.LogLV = logLv;
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand)));
        }

        private void txtHostAddr_TextChanged(object sender, EventArgs e)
        {
            MongodumpCommand.HostAddr = txtHostAddr.Text;
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand)));
        }

        private void txtDBName_TextChanged(object sender, EventArgs e)
        {
            MongodumpCommand.DBName = txtDBName.Text;
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand)));
        }

        private void txtCollectionName_TextChanged(object sender, EventArgs e)
        {
            MongodumpCommand.CollectionName = txtCollectionName.Text;
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand)));
        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            MongodumpCommand.Port = (int) numPort.Value;
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand)));
        }
    }
}