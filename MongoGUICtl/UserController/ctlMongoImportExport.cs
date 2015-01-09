using System;
using System.Windows.Forms;
using MongoCola;
using MongoCola.Module;
using MongoUtility.ExteneralTool;

namespace MongoGUICtl.Module
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
            if (!configuration.guiConfig.IsUseDefaultLanguage)
            {
                lblCollectionName.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Collection_Status_CollectionName);
                lblDBName.Text = configuration.guiConfig.MStringResource.GetText(StringResource.TextType.AddConnection_DBName);
                lblHost.Text = configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Host);
                lblFieldList.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.DosCommand_Tab_ExIn_ColumnList);
                lblPort.Text = configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Port);
                grpDirect.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.DosCommand_Tab_ExIn_Operation);
                radImport.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.DosCommand_Tab_ExIn_Import);
                radExport.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.DosCommand_Tab_ExIn_Export);
                ctlFilePickerOutput.Title =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.DosCommand_Tab_ExIn_Workfile);
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
            MongoImportExportCommand.Direct = radExport.Checked
                ? MongodbDosCommand.ImprotExport.Export
                : MongodbDosCommand.ImprotExport.Import;
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand)));
        }

        private void radImport_CheckedChanged(object sender, EventArgs e)
        {
            MongoImportExportCommand.Direct = radExport.Checked
                ? MongodbDosCommand.ImprotExport.Export
                : MongodbDosCommand.ImprotExport.Import;
            OnCommandChange(new TextChangeEventArgs(String.Empty,
                MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand)));
        }
    }
}