using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Windows.Forms;
namespace MagicMongoDBTool.UnitTest
{
    public partial class frmUnitTest : Form
    {
        public frmUnitTest()
        {
            InitializeComponent();
        }
        /// <summary>
        /// User类的测试数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFillDataForUser_Click(object sender, EventArgs e)
        {
            if (SystemManager.GetCurrentServer() != null)
            {
                InitTestData.FillDataForUser(SystemManager.GetCurrentServer());
                MessageBox.Show("Complete");
            }
            else
            {
                MessageBox.Show("Please select a server");
            }
        }
        /// <summary>
        /// TTL的测试数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFillDataForTTL_Click(object sender, EventArgs e)
        {
            if (SystemManager.GetCurrentServer() != null)
            {
                InitTestData.FillDataForTTL(SystemManager.GetCurrentServer());
                MessageBox.Show("Complete");
            }
            else
            {
                MessageBox.Show("Please select a server");
            }
        }
        /// <summary>
        /// Geo测试数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFillDataForGeoObject_Click(object sender, EventArgs e)
        {
            if (SystemManager.GetCurrentServer() != null)
            {
                InitTestData.FillDataForGeoObject(SystemManager.GetCurrentServer());
                MessageBox.Show("Complete");
            }
            else
            {
                MessageBox.Show("Please select a server");
            }
        }
        /// <summary>
        /// 聚合测试数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFillDataForAggregation_Click(object sender, EventArgs e)
        {
            if (SystemManager.GetCurrentServer() != null)
            {
                InitTestData.FillDataForAggregation(SystemManager.GetCurrentServer());
                MessageBox.Show("Complete");
            }
            else
            {
                MessageBox.Show("Please select a server");
            }
        }
    }
}
