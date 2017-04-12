using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using MongoGUICtl.ClientTree;
using MongoUtility.Core;
using ResourceLib.UI;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FunctionForm.Aggregation
{
    public partial class frmGeoNear : Form
    {
        public frmGeoNear()
        {
            InitializeComponent();
            NumDistanceMultiplier.KeyPress += NumberTextBox.NumberText_KeyPress;
            NumMaxDistance.KeyPress += NumberTextBox.NumberText_KeyPress;
            lblPoint.Text = "[" + point.X.ToString() + "," + point.Y.ToString() + "]";
        }

        private void lnkGeoNear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://docs.mongodb.com/master/reference/command/nav-geospatial/");
        }

        private void cmdGeoNear_Click(object sender, EventArgs e)
        {
            BsonDocument mGeoNearAs = null;
            bool IsHaystack = chkHaystack.Checked;
            try
            {
                if (IsHaystack)
                {
                    var geoSearchOption = new GeoHaystackSearchArgs()
                    {
                        MaxDistance = double.Parse(NumMaxDistance.Text),
                        Limit = (int)NumResultCount.Value,
                        Near = point
                    };
                    // GeoHaystackSearch
                    mGeoNearAs = RuntimeMongoDbContext.GetCurrentCollection().GeoHaystackSearchAs<BsonDocument>(geoSearchOption).Response;
                }
                else
                {
                    var geoOption = new GeoNearArgs()
                    {
                        DistanceMultiplier = double.Parse(NumDistanceMultiplier.Text),
                        MaxDistance = double.Parse(NumMaxDistance.Text),
                        Spherical = chkSpherical.Checked,
                        Limit = (int)NumResultCount.Value
                    };
                    if (radGeoJSON.Checked)
                    {
                        geoOption.Near = new GeoJsonPoint<GeoJson2DCoordinates>(new GeoJson2DCoordinates(point.X, point.Y));
                    }
                    else
                    {
                        geoOption.Near = point;
                    }
                    //GeoNearAs
                    mGeoNearAs = RuntimeMongoDbContext.GetCurrentCollection().GeoNearAs<BsonDocument>(geoOption).Response;
                }
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
                return;
            }
            UiHelper.FillDataToTreeView("Result", trvGeoResult, mGeoNearAs);
            trvGeoResult.DatatreeView.Nodes[0].Expand();

        }

        /// <summary>
        ///     设置弧度转公里
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRadianToKM_Click(object sender, EventArgs e)
        {
            NumDistanceMultiplier.Text = (6378.137).ToString();
        }

        /// <summary>
        ///     设置弧度转英里
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRadianToMile_Click(object sender, EventArgs e)
        {
            NumDistanceMultiplier.Text = (3963.192).ToString();
        }


        private void btnHelp_Click(object sender, EventArgs e)
        {
            MyMessageBox.ShowMessage("DistanceMultiplier", "About DistanceMultiplier",
                @"distance to radians: divide the distance by the radius of the sphere (e.g. the Earth) in the same units as the distance measurement.
radians to distance: multiply the rad ian measure by the radius of the sphere (e.g. the Earth) in the units system that you want to convert the distance to.
The radius of the Earth is approximately 3963.192 miles or 6378.137 kilometers.", true);
        }


        /// <summary>
        ///     获得一个新BsonArray的委托
        /// </summary>
        public static Func<BsonArray> GetGeo;
        /// <summary>
        ///     坐标
        /// </summary>
        public XYPoint point = new XYPoint(0, 0);
        /// <summary>
        ///     坐标获得方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdGeoJson_Click(object sender, EventArgs e)
        {
            var t = GetGeo();
            if (t != null)
            {
                point = new XYPoint(t[0].AsDouble, t[1].AsDouble);
                lblPoint.Text = "[" + point.X.ToString() + "," + point.Y.ToString() + "]";
            }
        }


    }
}