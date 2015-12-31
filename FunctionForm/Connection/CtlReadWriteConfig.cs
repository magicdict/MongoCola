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
            MongoConnectionConfig.MongoConfig.ReadPreference = cmbReadPreference.Text;
            MongoConnectionConfig.MongoConfig.SaveMongoConfig();
        }

        private void CtlMongoConfig_Load(object sender, EventArgs e)
        {
            NumWTimeoutMS.GotFocus += (x, y) => NumWTimeoutMS.Select(0, 5);
            NumWaitQueueSize.GotFocus += (x, y) => NumWaitQueueSize.Select(0, 5);

            foreach (var readPreferenceItem in ReadWrite.ReadPreferenceList)
            {
                cmbReadPreference.Items.Add(readPreferenceItem);
            }

            foreach (var writeConcernItem in ReadWrite.WriteConcernList)
            {
                cmbWriteConcern.Items.Add(writeConcernItem);
            }

            //ReadPreference和WriteConern不是Connection的属性,
            //而是读写策略
            if (MongoConnectionConfig.MongoConfig.ReadPreference != string.Empty)
            {
                cmbReadPreference.Text = MongoConnectionConfig.MongoConfig.ReadPreference;
            }
            if (MongoConnectionConfig.MongoConfig.WriteConcern != string.Empty)
            {
                cmbWriteConcern.Text = MongoConnectionConfig.MongoConfig.WriteConcern;
            }
            NumWTimeoutMS.Value = (decimal) MongoConnectionConfig.MongoConfig.WtimeoutMs;
            NumWaitQueueSize.Value = MongoConnectionConfig.MongoConfig.WaitQueueSize;
        }
    }
}