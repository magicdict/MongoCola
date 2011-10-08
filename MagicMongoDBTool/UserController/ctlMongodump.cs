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
    public partial class ctlMongodump : UserControl
    {
        public event MagicMongoDBTool.frmDosCommand.CommandChangedEventHandler CommandChanged;
        private MongodbDosCommand.struMongodump MongodumpCommand = new MongodbDosCommand.struMongodump();
        public ctlMongodump()
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
            MongodumpCommand.OutPutPath = FilePath;
            CommandChanged(MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand));
        }
        void ctllogLvT_LoglvChanged(MongodbDosCommand.MongologLevel logLv)
        {
            MongodumpCommand.loglv = logLv;
            CommandChanged(MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand));
        }
        private void txtHostAddr_TextChanged(object sender, EventArgs e)
        {
            MongodumpCommand.HostAddr = txtHostAddr.Text;
            CommandChanged(MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand));
        }

        private void txtDBName_TextChanged(object sender, EventArgs e)
        {
            MongodumpCommand.DBName = txtDBName.Text;
            CommandChanged(MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand));
        }

        private void txtCollectionName_TextChanged(object sender, EventArgs e)
        {
            MongodumpCommand.CollectionName = txtCollectionName.Text;
            CommandChanged(MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand));
        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {
            MongodumpCommand.Port = (int)numPort.Value;
            CommandChanged(MongodbDosCommand.GetMongodumpCommandLine(MongodumpCommand));
        }
    }
}
