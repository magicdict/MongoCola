using System;
using System.Windows.Forms;
using MongoUtility.Basic;
using MongoUtility.EventArgs;
using ResourceLib;

namespace MongoGUICtl
{
    public partial class ctlMongodump : UserControl
    {
        private readonly MongodbDosCommand.StruMongoDump MongodumpCommand = new MongodbDosCommand.StruMongoDump();
        public EventHandler<TextChangeEventArgs> CommandChanged;

        public ctlMongodump()
        {
            InitializeComponent();
            if (!GUIConfig.IsUseDefaultLanguage)
            {
                lblCollectionName.Text =
                    GUIConfig.MStringResource.GetText(TextType.DosCommand_Tab_Backup_DCName);
                lblDBName.Text =
                    GUIConfig.MStringResource.GetText(TextType.DosCommand_Tab_Backup_DBName);
                lblHostAddr.Text =
                    GUIConfig.MStringResource.GetText(TextType.DosCommand_Tab_Backup_Server);
                lblPort.Text =
                    GUIConfig.MStringResource.GetText(TextType.DosCommand_Tab_Backup_Port);
                ctlFilePickerOutput.Title =
                    GUIConfig.MStringResource.GetText(TextType.DosCommand_Tab_Backup_Path);
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

        private void ctlFilePickerOutput_PathChanged(string FilePath)
        {
            MongodumpCommand.OutPutPath = FilePath;
            OnCommandChange(new TextChangeEventArgs(string.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand)));
        }

        private void ctllogLvT_LoglvChanged(MongodbDosCommand.MongologLevel logLv)
        {
            MongodumpCommand.LogLV = logLv;
            OnCommandChange(new TextChangeEventArgs(string.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand)));
        }

        private void txtHostAddr_TextChanged(object sender, EventArgs e)
        {
            MongodumpCommand.HostAddr = txtHostAddr.Text;
            OnCommandChange(new TextChangeEventArgs(string.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand)));
        }

        private void txtDBName_TextChanged(object sender, EventArgs e)
        {
            MongodumpCommand.DBName = txtDBName.Text;
            OnCommandChange(new TextChangeEventArgs(string.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand)));
        }

        private void txtCollectionName_TextChanged(object sender, EventArgs e)
        {
            MongodumpCommand.CollectionName = txtCollectionName.Text;
            OnCommandChange(new TextChangeEventArgs(string.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand)));
        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            MongodumpCommand.Port = (int) numPort.Value;
            OnCommandChange(new TextChangeEventArgs(string.Empty,
                MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand)));
        }
    }
}