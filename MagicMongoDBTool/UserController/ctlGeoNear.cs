using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class ctlGeoNear : UserControl
    {
        public ctlGeoNear()
        {
            InitializeComponent();
        }
        private void lnkGeoNear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://docs.mongodb.org/manual/reference/commands/#geoNear");
        }

        private void cmdGeoNear_Click(object sender, EventArgs e)
        {
            GeoNearOptionsBuilder GeoOption = new GeoNearOptionsBuilder();
            GeoOption.SetDistanceMultiplier(double.Parse(NumDistanceMultiplier.Text));
            GeoOption.SetMaxDistance(double.Parse(NumMaxDistance.Text));
            GeoOption.SetSpherical(chkSpherical.Checked);
            try
            {
                BsonDocument mGeoNearAs = SystemManager.GetCurrentCollection().GeoNearAs<BsonDocument>
                    (null, double.Parse(NumGeoX.Text), double.Parse(NumGeoY.Text), (int)NumResultCount.Value, GeoOption).Response;
                MongoDBHelper.FillDataToTreeView("Result", this.trvGeoResult, mGeoNearAs);
                this.trvGeoResult.DatatreeView.Nodes[0].Expand();
            }
            catch (Exception ex)
            {
                SystemManager.ExceptionDeal(ex);
            }
        }

        private void NumberText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 46)                       //小数点
            {
                if (((TextBox)sender).Text.Length <= 0)
                    e.Handled = true;           //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(((TextBox)sender).Text, out oldf);
                    b2 = float.TryParse(((TextBox)sender).Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }
        /// <summary>
        /// 设置公里
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKM_Click(object sender, EventArgs e)
        {
            NumDistanceMultiplier.Text = (1 / 6378.137).ToString();
        }
        /// <summary>
        /// 设置英里
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMile_Click(object sender, EventArgs e)
        {
            NumDistanceMultiplier.Text = (1 / 3963.192).ToString();
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
