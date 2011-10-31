using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class ctlMongod : UserControl
    {
        
        public event MagicMongoDBTool.frmDosCommand.CommandChangedEventHandler CommandChanged;
        private MongodbDosCommand.struMongod MongodCommand = new  MongodbDosCommand.struMongod();
        public ctlMongod()
        {
            InitializeComponent();
        }

        private void ctlMongod_Load(object sender, EventArgs e)
        {
            ctllogLvT.LoglvChanged += new ctllogLv.LogLvChangedHandler(ctllogLvT_LoglvChanged);
            ctlFilePickerLogPath.PathChanged += new ctlFilePicker.PathChangedHandler(ctlFilePickerT_PathChanged);
            ctlFilePickerDBPath.PathChanged += new ctlFilePicker.PathChangedHandler(ctlFilePickerDBPath_PathChanged);
        }

        void ctlFilePickerDBPath_PathChanged(string FilePath)
        {
            MongodCommand.dbpath = FilePath;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }

        void ctlFilePickerT_PathChanged(string FilePath)
        {
            MongodCommand.logpath = FilePath;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }

        void ctllogLvT_LoglvChanged(MongodbDosCommand.MongologLevel logLv)
        {
            MongodCommand.loglv = logLv;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }

        private void chkIsAppend_CheckedChanged(object sender, EventArgs e)
        {
            MongodCommand.Islogappend = chkIsAppend.Checked;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }
        private void chkIsMaster_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsMaster.Checked) { chkIsSlave.Checked = false; }
            MongodCommand.IsMaster = chkIsMaster.Checked;
            MongodCommand.IsSlave = chkIsSlave.Checked;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }
        private void chkIsSlave_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsSlave.Checked) { chkIsMaster.Checked = false; }
            MongodCommand.IsMaster = chkIsMaster.Checked;
            MongodCommand.IsSlave = chkIsSlave.Checked;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }
        private void chkAuth_CheckedChanged(object sender, EventArgs e)
        {
            MongodCommand.IsAuth = chkAuth.Checked;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            MongodCommand.Port = (int)numPort.Value;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }

        private void txtSource_TextChanged(string strNewText)
        {
            MongodCommand.Source = strNewText;
            if (MongodCommand != null)
            {
                CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
            }
        }
    }
}
