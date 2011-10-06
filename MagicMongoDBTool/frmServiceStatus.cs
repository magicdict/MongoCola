using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmServiceStatus : Form
    {
        public frmServiceStatus()
        {
            InitializeComponent();
        }

        private void frmServiceStatus_Load(object sender, EventArgs e)
        {

            MagicMongoDBTool.Module.MongoDBHelpler.FillSrvStatusToList(this.lstSrvStatus);

        }
    }
}
