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
    public partial class ctllogLv : UserControl
    {
        public ctllogLv()
        {
            InitializeComponent();
        }
        public delegate void LogLvChangedHandler(MongodbDosCommand.MongologLevel logLv);
        public event LogLvChangedHandler LoglvChanged;

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
            LoglvChanged((MongodbDosCommand.MongologLevel)trbLogLv.Value);
        }

        private void ctllogLv_Load(object sender, EventArgs e)
        {
            trbLogLv.Minimum = (int)MongodbDosCommand.MongologLevel.quiet;
            trbLogLv.Maximum = (int)MongodbDosCommand.MongologLevel.vvvvv;
        }
    }
}
