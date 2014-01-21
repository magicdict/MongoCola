using System;
using System.IO;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmOption : Form
    {
        public frmOption()
        {
            InitializeComponent();
        }

        private void frmOption_Load(object sender, EventArgs e)
        {
            ctlFilePickerMongoBinPath.SelectedPathOrFileName = SystemManager.ConfigHelperInstance.MongoBinPath;
            //this.numLimitCnt.Value = SystemManager.ConfigHelperInstance.LimitCnt;
            numRefreshForStatus.Value = SystemManager.ConfigHelperInstance.RefreshStatusTimer;
            cmbLanguage.Items.Add("English");
            if (Directory.Exists("Language"))
            {
                foreach (String FileName in Directory.GetFiles("Language"))
                {
                    cmbLanguage.Items.Add(new FileInfo(FileName).Name.Substring(0,
                        new FileInfo(FileName).Name.Length - 4));
                }
            }

            if (!SystemManager.IsUseDefaultLanguage)
            {
                if (
                    File.Exists("Language" + Path.DirectorySeparatorChar +
                                SystemManager.ConfigHelperInstance.LanguageFileName))
                {
                    cmbLanguage.Text = SystemManager.ConfigHelperInstance.LanguageFileName.Substring(0,
                        SystemManager.ConfigHelperInstance.LanguageFileName.Length - 4);
                }
                else
                {
                    cmbLanguage.Text = "English";
                }
            }
            else
            {
                cmbLanguage.Text = "English";
            }

            if (SystemManager.IsUseDefaultLanguage) return;
            //国际化
            Text = SystemManager.mStringResource.GetText(StringResource.TextType.Option_Title);
            cmdOK.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_OK);
            cmdCancel.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Cancel);
            ctlFilePickerMongoBinPath.Title =
                SystemManager.mStringResource.GetText(StringResource.TextType.Option_BinPath);
            lblLanguage.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Option_Language);
            lblRefreshIntervalForStatus.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Option_RefreshInterval);
        }

        /// <summary>
        ///     OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            SystemManager.ConfigHelperInstance.MongoBinPath = ctlFilePickerMongoBinPath.SelectedPathOrFileName;
            SystemManager.ConfigHelperInstance.RefreshStatusTimer = (int) numRefreshForStatus.Value;
            SystemManager.ConfigHelperInstance.LanguageFileName = cmbLanguage.Text + ".xml";
            SystemManager.ConfigHelperInstance.SaveToConfigFile();
            Close();
        }

        /// <summary>
        ///     Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}