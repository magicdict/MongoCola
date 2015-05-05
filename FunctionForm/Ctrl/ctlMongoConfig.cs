using System;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoUtility.Core;

namespace FunctionForm
{
    public partial class CtlMongoConfig : UserControl
    {
        public CtlMongoConfig()
        {
            InitializeComponent();
        }

        private void ctlMongoConfig_Load(object sender, EventArgs e)
        {
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
    }
}