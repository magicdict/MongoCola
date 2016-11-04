using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Common;
using MongoUtility.ToolKit;

namespace PlugInPackage.GenerateConfigIni
{
    public partial class FrmGenerateConfigIni : Form
    {
        /// <summary>
        /// </summary>
        public FrmGenerateConfigIni()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var savefile = new SaveFileDialog { Filter = Utility.ConfFilter };
            if (savefile.ShowDialog() != DialogResult.OK) return;
            var save = new StreamWriter(savefile.FileName);
            save.Write(MongodbDosCommand.GenerateIniFile(ctlGenerateMongod.MongodCommand));
            save.Close();
            Process.Start(savefile.FileName);
        }

        private void lnkRef_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(lnkRef.Text);
        }
    }
}