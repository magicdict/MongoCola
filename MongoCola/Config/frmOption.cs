using System;
using System.IO;
using System.Windows.Forms;
using MongoCola.Config;
using ResourceLib.Method;
using MongoDB.Driver;

namespace MongoCola
{
    public partial class FrmOption : Form
    {
        public FrmOption()
        {
            InitializeComponent();
        }

        private void frmOption_Load(object sender, EventArgs e)
        {
            ctlFilePickerMongoBinPath.SelectedPathOrFileName = SystemManager.SystemConfig.MongoBinPath;
            //this.numLimitCnt.Value = SystemConfig.config.LimitCnt;
            numRefreshForStatus.Value = SystemManager.SystemConfig.RefreshStatusTimer;
            cmbLanguage.Items.Add(StringResource.Language_English);
            if (Directory.Exists("Language"))
            {
                foreach (var fileName in Directory.GetFiles("Language"))
                {
                    cmbLanguage.Items.Add(new FileInfo(fileName).Name.Substring(0,
                        new FileInfo(fileName).Name.Length - 4));
                }
            }

            if (!GuiConfig.IsUseDefaultLanguage)
            {
                if (
                    File.Exists("Language" + Path.DirectorySeparatorChar +
                                SystemManager.SystemConfig.LanguageFileName))
                {
                    cmbLanguage.Text = SystemManager.SystemConfig.LanguageFileName.Substring(0,
                        SystemManager.SystemConfig.LanguageFileName.Length - 4);
                }
                else
                {
                    cmbLanguage.Text = StringResource.Language_English;
                }
            }
            else
            {
                cmbLanguage.Text = StringResource.Language_English;
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
            //cmbWriteConcern.Items.Add(WriteConcern.W4.ToString());
            cmbWriteConcern.Items.Add(WriteConcern.WMajority.ToString());


            //ReadPreference和WriteConern不是Connection的属性,
            //而是读写策略
            if (SystemManager.MongoConfig.ReadPreference != string.Empty)
            {
                cmbReadPreference.Text = SystemManager.MongoConfig.ReadPreference;
            }
            if (SystemManager.MongoConfig.WriteConcern != string.Empty)
            {
                cmbWriteConcern.Text = SystemManager.MongoConfig.WriteConcern;
            }
            NumWTimeoutMS.Value = (decimal)SystemManager.MongoConfig.WtimeoutMs;
            NumWaitQueueSize.Value = SystemManager.MongoConfig.WaitQueueSize;


            if (GuiConfig.IsUseDefaultLanguage) return;
            //国际化
            Text = GuiConfig.GetText(TextType.OptionTitle);
            cmdOK.Text = GuiConfig.GetText(TextType.CommonOk);
            cmdCancel.Text = GuiConfig.GetText(TextType.CommonCancel);
            ctlFilePickerMongoBinPath.Title =
                GuiConfig.GetText(TextType.OptionBinPath);
            lblLanguage.Text = GuiConfig.GetText(TextType.OptionLanguage);
            lblRefreshIntervalForStatus.Text =
                GuiConfig.GetText(TextType.OptionRefreshInterval);
        }

        /// <summary>
        ///     OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            SystemManager.MongoConfig.WtimeoutMs = (double)NumWTimeoutMS.Value;
            SystemManager.MongoConfig.WaitQueueSize = (int)NumWaitQueueSize.Value;
            SystemManager.MongoConfig.WriteConcern = cmbWriteConcern.Text;
            SystemManager.MongoConfig.ReadPreference = cmbReadPreference.Text;

            SystemManager.SystemConfig.MongoBinPath = ctlFilePickerMongoBinPath.SelectedPathOrFileName;
            SystemManager.SystemConfig.RefreshStatusTimer = (int)numRefreshForStatus.Value;
            SystemManager.SystemConfig.LanguageFileName = cmbLanguage.Text + ".xml";

            SystemManager.MongoConfig.SaveMongoConfig(); 
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