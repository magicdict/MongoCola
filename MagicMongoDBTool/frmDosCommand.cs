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
        public delegate void CommandChangedEventHandler(string strCommandLine);
        public frmDosCommand()
        {
            InitializeComponent();
        }

        private void frmDosCommand_Load(object sender, EventArgs e)
        {
            //命令参数变化
            this.ctlMongodPanel.CommandChanged += new CommandChangedEventHandler(CommandChanged);
            this.ctlMongodumpPanel.CommandChanged += new CommandChangedEventHandler(CommandChanged);
            this.ctlMongoImportExportPanel.CommandChanged += new CommandChangedEventHandler(CommandChanged);
        }
        /// <summary>
        /// //命令参数变化
        /// </summary>
        /// <param name="strCommandLine"></param>
        void CommandChanged(string strCommandLine)
        {
            this.txtDosCommand.Text = strCommandLine;
        }
        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
