using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MagicMongoDBTool.Module
{
    public partial class ctlMongoImportExport : UserControl
    {
        public event MagicMongoDBTool.frmDosCommand.CommandChangedEventHandler CommandChanged;
        private MongodbDosCommand.struImportExport MongoImportExportCommand = new MongodbDosCommand.struImportExport();
        public ctlMongoImportExport()
        {
            InitializeComponent();
        }

        private void ctlMongodump_Load(object sender, EventArgs e)
        {
            this.ctllogLvT.LoglvChanged += new ctllogLv.LogLvChangedHandler(ctllogLvT_LoglvChanged);
            this.ctlFilePickerOutput.PathChanged += new ctlFilePicker.PathChangedHandler(ctlFilePickerOutput_PathChanged);
        }
        void ctlFilePickerOutput_PathChanged(string FilePath)
        {
            MongoImportExportCommand.FileName = FilePath;
            CommandChanged(MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExportCommand));
        }
        void ctllogLvT_LoglvChanged(MongodbDosCommand.MongologLevel logLv)
        {
            MongoImportExportCommand.loglv = logLv;
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
            else {
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
