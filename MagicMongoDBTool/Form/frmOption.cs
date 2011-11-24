using System;
using System.IO;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class frmOption : QLFUI.QLFForm
    {
        public frmOption()
        {
            InitializeComponent();
        }
        private void frmOption_Load(object sender, EventArgs e)
        {
            this.ctlFilePickerMongoBinPath.SelectedPath = SystemManager.ConfigHelperInstance.MongoBinPath;
            this.numLimitCnt.Value = SystemManager.ConfigHelperInstance.LimitCnt;
            this.numRefreshForStatus.Value = SystemManager.ConfigHelperInstance.RefreshStatusTimer;
            this.cmbLanguage.Items.Add(String.Empty);
            if (Directory.Exists("Language"))
            {
                foreach (String FileName in Directory.GetFiles("Language"))
                {
                    this.cmbLanguage.Items.Add(new FileInfo(FileName).Name);
                }
            }
            if (File.Exists("Language\\" + SystemManager.ConfigHelperInstance.LanguageFileName))
            {
                this.cmbLanguage.Text = SystemManager.ConfigHelperInstance.LanguageFileName;
            }
            else
            {
                this.cmbLanguage.Text = "";
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            SystemManager.ConfigHelperInstance.MongoBinPath = ctlFilePickerMongoBinPath.SelectedPath;
            SystemManager.ConfigHelperInstance.LimitCnt = (int)this.numLimitCnt.Value;
            SystemManager.ConfigHelperInstance.RefreshStatusTimer = (int)this.numRefreshForStatus.Value;
            SystemManager.ConfigHelperInstance.LanguageFileName = this.cmbLanguage.Text;
            SystemManager.ConfigHelperInstance.SaveToConfigFile();
            this.Close();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
