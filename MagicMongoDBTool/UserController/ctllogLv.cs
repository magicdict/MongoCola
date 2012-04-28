using System;
using System.Windows.Forms;

namespace MagicMongoDBTool.Module
{
    public partial class ctllogLv : UserControl
    {
        public delegate void LogLvChangedHandler(MongodbDosCommand.MongologLevel logLV);
        public event LogLvChangedHandler LoglvChanged;
        public ctllogLv()
        {
            InitializeComponent();
        }
        private void ctllogLv_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage)
            {
                lblLogLv.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.DosCommand_LogLevel);
            }
            cmbLogLevel.Items.Add("Quiet");
            cmbLogLevel.Items.Add("V");
            cmbLogLevel.Items.Add("VV");
            cmbLogLevel.Items.Add("VVV");
            cmbLogLevel.Items.Add("VVVV");
            cmbLogLevel.Items.Add("VVVVV");
        }
        private void cmbLogLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoglvChanged((MongodbDosCommand.MongologLevel)cmbLogLevel.SelectedIndex);
        }
    }
}
