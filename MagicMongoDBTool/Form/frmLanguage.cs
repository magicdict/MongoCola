
using System;
using System.Windows.Forms;
using System.IO;
using MagicMongoDBTool.Module;

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
            this.cmbLanguage.Items.Add(String.Empty);
            if (Directory.Exists("Language"))
            {
                foreach (String FileName in Directory.GetFiles("Language"))
                {
                    this.cmbLanguage.Items.Add(new FileInfo(FileName).Name);
                }
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SystemManager.ConfigHelperInstance.LanguageFileName = this.cmbLanguage.Text;
            this.Close();
        }
    }
}
