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
            ctlFilePickerMongoBinPath.SelectedPathOrFileName = SystemConfig.Config.MongoBinPath;
            //this.numLimitCnt.Value = SystemConfig.config.LimitCnt;
            numRefreshForStatus.Value = SystemConfig.Config.RefreshStatusTimer;
            cmbLanguage.Items.Add("English");
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
                                SystemConfig.Config.LanguageFileName))
                {
                    cmbLanguage.Text = SystemConfig.Config.LanguageFileName.Substring(0,
                        SystemConfig.Config.LanguageFileName.Length - 4);
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
            //cmbWriteConcern.Items.Add(WriteConcern.W4.ToString());
            cmbWriteConcern.Items.Add(WriteConcern.WMajority.ToString());


            //ReadPreference和WriteConern不是Connection的属性,
            //而是读写策略
            if (SystemConfig.Config.ReadPreference != string.Empty)
            {
                cmbReadPreference.Text = SystemConfig.Config.ReadPreference;
            }
            if (SystemConfig.Config.WriteConcern != string.Empty)
            {
                cmbWriteConcern.Text = SystemConfig.Config.WriteConcern;
            }
            NumWTimeoutMS.Value = (decimal) SystemConfig.Config.WtimeoutMs;
            NumWaitQueueSize.Value = SystemConfig.Config.WaitQueueSize;


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
            SystemConfig.Config.WtimeoutMs = (double) NumWTimeoutMS.Value;
            SystemConfig.Config.WaitQueueSize = (int) NumWaitQueueSize.Value;
            SystemConfig.Config.WriteConcern = cmbWriteConcern.Text;
            SystemConfig.Config.ReadPreference = cmbReadPreference.Text;

            SystemConfig.Config.MongoBinPath = ctlFilePickerMongoBinPath.SelectedPathOrFileName;

            SystemConfig.Config.RefreshStatusTimer = (int) numRefreshForStatus.Value;
            SystemConfig.Config.LanguageFileName = cmbLanguage.Text + ".xml";

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