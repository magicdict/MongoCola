using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class frmDosCommand : Form
    {
        public frmDosCommand()
        {
            InitializeComponent();
        }

        private void frmDosCommand_Load(object sender, EventArgs e)
        {
            this.ctlMongodPanel.CommandChanged += new ctlMongod.CommandChangedEventHandler(ctlMongodPanel_CommandChanged);
        }

        void ctlMongodPanel_CommandChanged(string strCommandLine)
        {
            this.txtDosCommand.Text = strCommandLine;
        }

        private void cmdRunDos_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (this.txtDosCommand.Text != String.Empty) {
                MongodbDosCommand.RunDosCommand(txtDosCommand.Text, sb);
                this.txtDosCommand.Text += System.Environment.NewLine;
                this.txtDosCommand.Text += sb.ToString();       
            }
        }
    }
}
