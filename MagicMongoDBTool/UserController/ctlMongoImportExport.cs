using System;
using System.Windows.Forms;

namespace MagicMongoDBTool.Module
{
    public partial class ctlMongoImportExport : UserControl
    {
        public event MagicMongoDBTool.frmDosCommand.CommandChangedEventHandler CommandChanged;
        private MongodbDosCommand.StruImportExport MongoImportExportCommand = new MongodbDosCommand.StruImportExport();
        public ctlMongoImportExport()
        {
            InitializeComponent();
        }

        private void ctlMongodump_Load(object sender, EventArgs e)
        {
            this.ctllogLvT.LoglvChanged += new ctllogLv.LogLvChangedHandler(ctllogLvT_LoglvChanged);
            this.ctlFilePickerOutput.PathChanged += new ctlFilePicker.PathChangedHandler(ctlFilePickerOutput_PathChanged);
            if (!SystemManager.IsUseDefaultLanguage())
            {
                lblCollectionName.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Collection_Status_CollectionName);
                lblDBName.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.AddConnection_DBName);
                lblHost.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Host);
                lblFieldList.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Tab_ExIn_ColumnList);
                lblPort.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Port);
                grpDirect.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Tab_ExIn_Operation);
                radImport.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Tab_ExIn_Import);
                radExport.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Tab_ExIn_Export);
                ctlFilePickerOutput.Title = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_Tab_ExIn_Workfile);
            }
        }
        void ctlFilePickerOutput_PathChanged(string FilePath)
        {
            MongoImportExportCommand.FileName = FilePath;
            CommandChanged(MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand));
        }
        void ctllogLvT_LoglvChanged(MongodbDosCommand.MongologLevel logLv)
        {
            MongoImportExportCommand.LogLV = logLv;
            CommandChanged(MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand));
        }
        private void txtHostAddr_TextChanged(object sender, EventArgs e)
        {
            MongoImportExportCommand.HostAddr = txtHostAddr.Text;
            CommandChanged(MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand));
        }

        private void txtDBName_TextChanged(object sender, EventArgs e)
        {
            MongoImportExportCommand.DBName = txtDBName.Text;
            CommandChanged(MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand));
        }

        private void txtCollectionName_TextChanged(object sender, EventArgs e)
        {
            MongoImportExportCommand.CollectionName = txtCollectionName.Text;
            CommandChanged(MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand));
        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            MongoImportExportCommand.Port = (int)numPort.Value;
            CommandChanged(MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand));
        }

        private void txtFieldList_TextChanged(object sender, EventArgs e)
        {
            MongoImportExportCommand.FieldList = txtFieldList.Text;
            CommandChanged(MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand));
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
        }
    }
}
