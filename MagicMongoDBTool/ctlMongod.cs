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
        public delegate void CommandChangedEventHandler(string strCommandLine);
        public event CommandChangedEventHandler CommandChanged;
        private MongodbDosCommand.struMongod MongodCommand = new  MongodbDosCommand.struMongod();
        public ctlMongod()
        {
            InitializeComponent();
        }

        private void ctlMongod_Load(object sender, EventArgs e)
        {
            trbLogLv.Minimum = (int)MongodbDosCommand.MongologLevel.quiet;
            trbLogLv.Maximum = (int)MongodbDosCommand.MongologLevel.vvvvv;
        }

        private void trbLogLv_Scroll(object sender, EventArgs e)
        {
            lblLogLv.Text = "日志等级：";
            switch (trbLogLv.Value)
            {
                case (int)MongodbDosCommand.MongologLevel.quiet:
                    lblLogLv.Text += "最少";
                    break;
                case (int)MongodbDosCommand.MongologLevel.v:
                    lblLogLv.Text += "1级";
                    break;
                case (int)MongodbDosCommand.MongologLevel.vv:
                    lblLogLv.Text += "2级";
                    break;
                case (int)MongodbDosCommand.MongologLevel.vvv:
                    lblLogLv.Text += "3级";
                    break;
                case (int)MongodbDosCommand.MongologLevel.vvvv:
                    lblLogLv.Text += "4级";
                    break;
                case (int)MongodbDosCommand.MongologLevel.vvvvv:
                    lblLogLv.Text += "最多";
                    break;
                default:
                    break;
            }
            MongodCommand.loglv = (MongodbDosCommand.MongologLevel)trbLogLv.Value;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }

        private void chkIsAppend_CheckedChanged(object sender, EventArgs e)
        {
            MongodCommand.Islogappend = chkIsAppend.Checked;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }

        private void cmdLogPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtLogPath.Text = fd.FileName;
            }
            MongodCommand.logpath = txtLogPath.Text;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }

        private void cmdClearLogPath_Click(object sender, EventArgs e)
        {
            txtLogPath.Text = "";
            MongodCommand.logpath = txtLogPath.Text;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }

        private void cmdDBPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.txtDBPath.Text = fd.SelectedPath;
            }
            MongodCommand.dbpath = txtDBPath.Text;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }

        private void chkIsMaster_CheckedChanged(object sender, EventArgs e)
        {
            MongodCommand.IsMaster = chkIsMaster.Checked;
            CommandChanged(MongodbDosCommand.GetMongodCommandLine(MongodCommand));
        }
    }
}
