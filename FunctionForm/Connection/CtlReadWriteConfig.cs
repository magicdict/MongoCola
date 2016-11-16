using System;
using System.Windows.Forms;
using MongoUtility.Core;

namespace FunctionForm.Connection
{
    public partial class CtlReadWriteConfig : UserControl
    {
        public CtlReadWriteConfig()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     保存配置
        /// </summary>
        public void SaveConfig()
        {
            MongoConnectionConfig.MongoConfig.WtimeoutMs = (double) NumWTimeoutMS.Value;
            MongoConnectionConfig.MongoConfig.WaitQueueSize = (int) NumWaitQueueSize.Value;
            MongoConnectionConfig.MongoConfig.WriteConcern = cmbWriteConcern.Text;
            MongoConnectionConfig.MongoConfig.ReadConcern = cmbReadConcern.Text;
            MongoConnectionConfig.MongoConfig.ReadPreference = cmbReadPreference.Text;
            MongoConnectionConfig.MongoConfig.SaveMongoConfig();
        }

        private void CtlMongoConfig_Load(object sender, EventArgs e)
        {
            NumWTimeoutMS.GotFocus += (x, y) => NumWTimeoutMS.Select(0, 5);
            NumWaitQueueSize.GotFocus += (x, y) => NumWaitQueueSize.Select(0, 5);

            Common.UIAssistant.FillComberWithArray(cmbReadConcern, ReadWrite.ReadConcernList);
            Common.UIAssistant.FillComberWithArray(cmbReadPreference, ReadWrite.ReadPreferenceList);
            Common.UIAssistant.FillComberWithArray(cmbWriteConcern, ReadWrite.WriteConcernList);

            //ReadPreference和WriteConern不是Connection的属性,
            //而是读写策略
            if (MongoConnectionConfig.MongoConfig.ReadPreference != string.Empty)
            {
                cmbReadPreference.Text = MongoConnectionConfig.MongoConfig.ReadPreference;
            }
            if (MongoConnectionConfig.MongoConfig.ReadConcern != string.Empty)
            {
                cmbReadConcern.Text = MongoConnectionConfig.MongoConfig.ReadConcern;
            }
            if (MongoConnectionConfig.MongoConfig.WriteConcern != string.Empty)
            {
                cmbWriteConcern.Text = MongoConnectionConfig.MongoConfig.WriteConcern;
            }
            NumWTimeoutMS.Value = (decimal) MongoConnectionConfig.MongoConfig.WtimeoutMs;
            NumWaitQueueSize.Value = MongoConnectionConfig.MongoConfig.WaitQueueSize;
        }

        private void lnkReadPreference_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.mongodb.com/master/reference/read-preference/");
        }

        private void lnkReadConcern_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.mongodb.com/master/reference/read-concern/");
        }

        private void lnkWriteConcern_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.mongodb.com/master/reference/write-concern/");
        }
    }
}