using MagicMongoDBTool.Module;
using System;
using System.IO;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmLanguage : Form
    {
        public frmLanguage()
        {
            InitializeComponent();
        }
        private void frmLanguage_Load(object sender, System.EventArgs e)
        {
            this.cmbLanguage.Text = "English";
            this.cmbLanguage.Items.Add("English");
            if (Directory.Exists("Language"))
            {
                foreach (String FileName in Directory.GetFiles("Language"))
                {
                    this.cmbLanguage.Items.Add(new FileInfo(FileName).Name.Substring(0, new FileInfo(FileName).Name.Length - 4));
                }
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            SystemManager.ConfigHelperInstance.LanguageFileName = this.cmbLanguage.Text + ".xml";
            SystemManager.ConfigHelperInstance.SaveToConfigFile();
            this.Close();
        }
    }
}
