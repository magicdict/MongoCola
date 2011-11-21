using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLFUI;
using MongoDB.Driver;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmRunSql : QLFForm 
    {
        public frmRunSql()
        {
            InitializeComponent();
        }

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {
            MongoCollection mongoCol = SystemManager.GetCurrentCollection();
            txtSql.Text = "select * from " + mongoCol.Name;

        }

        private void frmRunSql_Load(object sender, EventArgs e)
        {

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            DataFilter datafilter = MongoDBHelper.ConvertFromSql(txtSql.Text);
        }
    }
}
