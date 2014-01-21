using System;
using System.Diagnostics;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace MagicMongoDBTool
{
    public partial class ctlGeoNear : UserControl
    {
        public ctlGeoNear()
        {
            InitializeComponent();
            NumGeoX.KeyPress += MongoDbHelper.NumberText_KeyPress;
            NumGeoY.KeyPress += MongoDbHelper.NumberText_KeyPress;
            NumDistanceMultiplier.KeyPress += MongoDbHelper.NumberText_KeyPress;
            NumMaxDistance.KeyPress += MongoDbHelper.NumberText_KeyPress;
        }

        private void lnkGeoNear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://docs.mongodb.org/manual/reference/commands/#geoNear");
        }

        private void cmdGeoNear_Click(object sender, EventArgs e)
        {
            var GeoOption = new GeoNearOptionsBuilder();
            GeoOption.SetDistanceMultiplier(double.Parse(NumDistanceMultiplier.Text));
            GeoOption.SetMaxDistance(double.Parse(NumMaxDistance.Text));
            GeoOption.SetSpherical(chkSpherical.Checked);
            try
            {
                BsonDocument mGeoNearAs = SystemManager.GetCurrentCollection().GeoNearAs<BsonDocument>
                    (null, double.Parse(NumGeoX.Text), double.Parse(NumGeoY.Text), (int) NumResultCount.Value, GeoOption)
                    .Response;
                MongoDbHelper.FillDataToTreeView("Result", trvGeoResult, mGeoNearAs);
                trvGeoResult.DatatreeView.Nodes[0].Expand();
            }
            catch (Exception ex)
            {
                SystemManager.ExceptionDeal(ex);
            }
        }

        /// <summary>
        ///     设置公里
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKM_Click(object sender, EventArgs e)
        {
            NumDistanceMultiplier.Text = (1/6378.137).ToString();
        }

        /// <summary>
        ///     设置英里
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMile_Click(object sender, EventArgs e)
        {
            NumDistanceMultiplier.Text = (1/3963.192).ToString();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MyMessageBox.ShowMessage("Convert", "About Convert",
                @"distance to radians: divide the distance by the radius of the sphere (e.g. the Earth) in the same units as the distance measurement.
radians to distance: multiply the rad ian measure by the radius of the sphere (e.g. the Earth) in the units system that you want to convert the distance to.
The radius of the Earth is approximately 3963.192 miles or 6378.137 kilometers.", true);
        }
    }
}