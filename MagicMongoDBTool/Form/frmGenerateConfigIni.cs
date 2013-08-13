using System;
using System.IO;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class frmGenerateConfigIni : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public frmGenerateConfigIni()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = MongoDBHelper.ConfFilter;
            if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter save = new StreamWriter(savefile.FileName);
                save.Write(MongodbDosCommand.GenerateIniFile(ctlGenerateMongod.MongodCommand));
                save.Close();
                System.Diagnostics.Process.Start(savefile.FileName);
            }
        }

        private void lnkRef_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(lnkRef.Text);
        }
    }
}
