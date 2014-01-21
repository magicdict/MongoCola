using System;
using System.Windows.Forms;

namespace MagicMongoDBTool.Module
{
    public partial class ctlMongoImportExport : UserControl
    {
        private readonly MongodbDosCommand.StruImportExport MongoImportExportCommand =
            new MongodbDosCommand.StruImportExport();

        public EventHandler<TextChangeEventArgs> CommandChanged;

        public ctlMongoImportExport()
        {
            InitializeComponent();
        }

        private void ctlMongodump_Load(object sender, EventArgs e)
        {
            ctllogLvT.LoglvChanged += ctllogLvT_LoglvChanged;
            ctlFilePickerOutput.PathChanged += ctlFilePickerOutput_PathChanged;
            if (!SystemManager.IsUseDefaultLanguage)
            {
                lblCollectionName.Text =
                    SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Status_CollectionName);
                lblDBName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_DBName);
                lblHost.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Host);
                lblFieldList.Text =
                    SystemManager.mStringResource.GetText(StringResource.TextType.DosCommand_Tab_ExIn_ColumnList);
                lblPort.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Port);
                grpDirect.Text =
                    SystemManager.mStringResource.GetText(StringResource.TextType.DosCommand_Tab_ExIn_Operation);
                radImport.Text =
                    SystemManager.mStringResource.GetText(StringResource.TextType.DosCommand_Tab_ExIn_Import);
                radExport.Text =
                    SystemManager.mStringResource.GetText(StringResource.TextType.DosCommand_Tab_ExIn_Export);
                ctlFilePickerOutput.Title =
                    SystemManager.mStringResource.GetText(StringResource.TextType.DosCommand_Tab_ExIn_Workfile);
            }
        }

        protected virtual void OnCommandChange(TextChangeEventArgs e)
        {
            e.Raise(this, ref CommandChanged);
        }

        private void ctlFilePickerOutput_PathChanged(String FilePath)
        {
            MongoImportExportCommand.FileName = FilePath;
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand)));
        }

        private void ctllogLvT_LoglvChanged(MongodbDosCommand.MongologLevel logLv)
        {
            MongoImportExportCommand.LogLV = logLv;
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand)));
        }

        private void txtHostAddr_TextChanged(object sender, EventArgs e)
        {
            MongoImportExportCommand.HostAddr = txtHostAddr.Text;
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand)));
        }

        private void txtDBName_TextChanged(object sender, EventArgs e)
        {
            MongoImportExportCommand.DBName = txtDBName.Text;
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand)));
        }

        private void txtCollectionName_TextChanged(object sender, EventArgs e)
        {
            MongoImportExportCommand.CollectionName = txtCollectionName.Text;
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand)));
        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            MongoImportExportCommand.Port = (int) numPort.Value;
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand)));
        }

        private void txtFieldList_TextChanged(object sender, EventArgs e)
        {
            MongoImportExportCommand.FieldList = txtFieldList.Text;
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand)));
        }

        private void radExport_CheckedChanged(object sender, EventArgs e)
        {
            if (radExport.Checked)
            {
                MongoImportExportCommand.Direct = MongodbDosCommand.ImprotExport.Export;
            }
            else
            {
                MongoImportExportCommand.Direct = MongodbDosCommand.ImprotExport.Import;
            }
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand)));
        }

        private void radImport_CheckedChanged(object sender, EventArgs e)
        {
            if (radExport.Checked)
            {
                MongoImportExportCommand.Direct = MongodbDosCommand.ImprotExport.Export;
            }
            else
            {
                MongoImportExportCommand.Direct = MongodbDosCommand.ImprotExport.Import;
            }
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand)));
        }
    }
}