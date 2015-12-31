using System;
using System.Windows.Forms;
using MongoUtility.ToolKit;
using ResourceLib.Method;

namespace PlugInPackage.DosCommand
{
    public partial class CtllogLv : UserControl
    {
        public delegate void LogLvChangedHandler(MongodbDosCommand.MongologLevel logLv);

        public CtllogLv()
        {
            InitializeComponent();
        }

        public event LogLvChangedHandler LoglvChanged;

        private void ctllogLv_Load(object sender, EventArgs e)
        {
            GuiConfig.Translateform(Controls);
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