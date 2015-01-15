using System;
using System.Windows.Forms;
using MongoUtility.ExteneralTool;
using ResourceLib;

namespace MongoGUICtl.Module
{
    public partial class ctllogLv : UserControl
    {
        public delegate void LogLvChangedHandler(MongodbDosCommand.MongologLevel logLV);

        public ctllogLv()
        {
            InitializeComponent();
        }

        public event LogLvChangedHandler LoglvChanged;

        private void ctllogLv_Load(object sender, EventArgs e)
        {
            if (!configuration.guiConfig.IsUseDefaultLanguage)
            {
                lblLogLv.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.DosCommand_LogLevel);
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
            LoglvChanged((MongodbDosCommand.MongologLevel) cmbLogLevel.SelectedIndex);
        }
    }
}