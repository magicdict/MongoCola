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
    public partial class frmDataBaseStatus : Form
    {
        public frmDataBaseStatus()
        {
            InitializeComponent();
        }

        private void frmDataBaseStatus_Load(object sender, EventArgs e)
        {
            MagicMongoDBTool.Module.MongoDBHelpler.FillDBStatusToList(this.lstDBStatus);
        }
    }
}
