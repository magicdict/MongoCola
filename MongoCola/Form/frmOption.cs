using System;
using System.IO;
using System.Windows.Forms;
using SystemUtility;
using MongoDB.Driver;
using ResourceLib;

namespace MongoCola
{
    public partial class frmOption : Form
    {
        public frmOption()
        {
            InitializeComponent();
        }

        private void frmOption_Load(object sender, EventArgs e)
        {
            ctlFilePickerMongoBinPath.SelectedPathOrFileName = SystemConfig.config.MongoBinPath;
            //this.numLimitCnt.Value = SystemConfig.config.LimitCnt;
            numRefreshForStatus.Value = SystemConfig.config.RefreshStatusTimer;
            cmbLanguage.Items.Add("English");
            if (Directory.Exists("Language"))
            {
                foreach (var FileName in Directory.GetFiles("Language"))
                {
                    cmbLanguage.Items.Add(new FileInfo(FileName).Name.Substring(0,
                        new FileInfo(FileName).Name.Length - 4));
                }
            }

            if (!SystemConfig.IsUseDefaultLanguage)
            {
                if (
                    File.Exists("Language" + Path.DirectorySeparatorChar +
                                SystemConfig.config.LanguageFileName))
                {
                    cmbLanguage.Text = SystemConfig.config.LanguageFileName.Substring(0,
                        SystemConfig.config.LanguageFileName.Length - 4);
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
            if (SystemConfig.config.ReadPreference != string.Empty)
            {
                cmbReadPreference.Text = SystemConfig.config.ReadPreference;
            }
            if (SystemConfig.config.WriteConcern != string.Empty)
            {
                cmbWriteConcern.Text = SystemConfig.config.WriteConcern;
            }
            NumWTimeoutMS.Value = (decimal) SystemConfig.config.wtimeoutMS;
            NumWaitQueueSize.Value = SystemConfig.config.WaitQueueSize;


            if (SystemConfig.IsUseDefaultLanguage) return;
            //国际化
            Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Option_Title);
            cmdOK.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_OK);
            cmdCancel.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Cancel);
            ctlFilePickerMongoBinPath.Title =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Option_BinPath);
            lblLanguage.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Option_Language);
            lblRefreshIntervalForStatus.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Option_RefreshInterval);
        }

        /// <summary>
        ///     OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            SystemConfig.config.wtimeoutMS = (double) NumWTimeoutMS.Value;
            SystemConfig.config.WaitQueueSize = (int) NumWaitQueueSize.Value;
            SystemConfig.config.WriteConcern = cmbWriteConcern.Text;
            SystemConfig.config.ReadPreference = cmbReadPreference.Text;

            SystemConfig.config.MongoBinPath = ctlFilePickerMongoBinPath.SelectedPathOrFileName;

            SystemConfig.config.RefreshStatusTimer = (int) numRefreshForStatus.Value;
            SystemConfig.config.LanguageFileName = cmbLanguage.Text + ".xml";

            ConfigHelper.SaveToConfigFile();
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