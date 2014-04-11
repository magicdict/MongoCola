using System;
using System.IO;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Driver;

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


            NumWTimeoutMS.GotFocus += (x, y) => NumWTimeoutMS.Select(0, 5);
            NumWaitQueueSize.GotFocus += (x, y) => NumWaitQueueSize.Select(0, 5);

            //读策略
            //http://docs.mongodb.org/manual/reference/connection-string/#read-preference-options
            //https://github.com/mongodb/mongo-csharp-driver/blob/master/MongoDB.Driver/ReadPreference.cs
            cmbReadPreference.Items.Add(ReadPreference.Primary.ToString());
            cmbReadPreference.Items.Add(ReadPreference.PrimaryPreferred.ToString());
            cmbReadPreference.Items.Add(ReadPreference.Secondary.ToString());
            cmbReadPreference.Items.Add(ReadPreference.SecondaryPreferred.ToString());
            cmbReadPreference.Items.Add(ReadPreference.Nearest.ToString());

            //写确认
            //http://docs.mongodb.org/manual/reference/connection-string/#write-concern-options
            //https://github.com/mongodb/mongo-csharp-driver/blob/master/MongoDB.Driver/WriteConcern.cs
            //-1 – The driver will not acknowledge write operations and will suppress all network or socket errors.
            cmbWriteConcern.Items.Add(WriteConcern.Unacknowledged.ToString());
            //1   -  Provides basic acknowledgment of write operations.
            cmbWriteConcern.Items.Add(WriteConcern.Acknowledged.ToString());
            cmbWriteConcern.Items.Add(WriteConcern.W2.ToString());
            cmbWriteConcern.Items.Add(WriteConcern.W3.ToString());
            cmbWriteConcern.Items.Add(WriteConcern.W4.ToString());
            cmbWriteConcern.Items.Add(WriteConcern.WMajority.ToString());


            //ReadPreference和WriteConern不是Connection的属性,
            //而是读写策略
            if (SystemManager.ConfigHelperInstance.ReadPreference != string.Empty)
            {
                cmbReadPreference.Text = SystemManager.ConfigHelperInstance.ReadPreference;
            }
            if (SystemManager.ConfigHelperInstance.WriteConcern != string.Empty)
            {
                cmbWriteConcern.Text = SystemManager.ConfigHelperInstance.WriteConcern;
            }
            NumWTimeoutMS.Value = (decimal)SystemManager.ConfigHelperInstance.wtimeoutMS;
            NumWaitQueueSize.Value = SystemManager.ConfigHelperInstance.WaitQueueSize;


            if (SystemManager.IsUseDefaultLanguage) return;
            //国际化
            Text = SystemManager.MStringResource.GetText(StringResource.TextType.Option_Title);
            cmdOK.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Common_OK);
            cmdCancel.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Common_Cancel);
            ctlFilePickerMongoBinPath.Title =
                SystemManager.MStringResource.GetText(StringResource.TextType.Option_BinPath);
            lblLanguage.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Option_Language);
            lblRefreshIntervalForStatus.Text =
                SystemManager.MStringResource.GetText(StringResource.TextType.Option_RefreshInterval);
        }

        /// <summary>
        ///     OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            SystemManager.ConfigHelperInstance.wtimeoutMS = (double)NumWTimeoutMS.Value;
            SystemManager.ConfigHelperInstance.WaitQueueSize = (int)NumWaitQueueSize.Value;
            SystemManager.ConfigHelperInstance.WriteConcern = cmbWriteConcern.Text;
            SystemManager.ConfigHelperInstance.ReadPreference = cmbReadPreference.Text;
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