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
        public delegate void LogLvChangedHandler(MongodbDosCommand.MongologLevel logLV);
        public event LogLvChangedHandler LoglvChanged;

        private void trbLogLv_Scroll(object sender, EventArgs e)
        {
            lblLogLv.Text = "日志等级：";
            switch (trbLogLv.Value)
            {
                case (int)MongodbDosCommand.MongologLevel.Quiet:
                    lblLogLv.Text += "最少";
                    break;
                case (int)MongodbDosCommand.MongologLevel.V:
                    lblLogLv.Text += "1级";
                    break;
                case (int)MongodbDosCommand.MongologLevel.VV:
                    lblLogLv.Text += "2级";
                    break;
                case (int)MongodbDosCommand.MongologLevel.VVV:
                    lblLogLv.Text += "3级";
                    break;
                case (int)MongodbDosCommand.MongologLevel.VVVV:
                    lblLogLv.Text += "4级";
                    break;
                case (int)MongodbDosCommand.MongologLevel.VVVVV:
                    lblLogLv.Text += "最多";
                    break;
                default:
                    break;
            }
            LoglvChanged((MongodbDosCommand.MongologLevel)trbLogLv.Value);
        }

        private void ctllogLv_Load(object sender, EventArgs e)
        {
            trbLogLv.Minimum = (int)MongodbDosCommand.MongologLevel.Quiet;
            trbLogLv.Maximum = (int)MongodbDosCommand.MongologLevel.VVVVV;
        }
    }
}
