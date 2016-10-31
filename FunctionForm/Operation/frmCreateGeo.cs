using System;
using System.Windows.Forms;
using MongoDB.Bson;

namespace FunctionForm.Operation
{
    public partial class frmCreateGeo : Form
    {
        public BsonArray mBsonArray;

        public frmCreateGeo()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //Always list coordinates in longitude, latitude order.
            double longitude;
            if (!double.TryParse(txtLongitude.Text, out longitude))
            {
                return;
            }
            double latitude;
            if (!double.TryParse(txtLatitude.Text, out latitude))
            {
                return;
            }
            if (rad2dSphere.Checked)
            {
                //WGS48
                if (longitude > 180 || longitude < -180)
                {
                    //经度
                    return;
                }
                if (latitude > 90 || latitude < 90)
                {
                    //维度
                    return;
                }
            }
            mBsonArray = new BsonArray();
            mBsonArray.Add(longitude);
            mBsonArray.Add(latitude);
            Close();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
