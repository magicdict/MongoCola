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

        private void frmRunSql_Load(object sender, EventArgs e)
        {
            txtSql.Text = "select * from aaa where (Code=1 or Question=\"  A \") AND ID=\" 3 \" order by Code asc,Question des Group by e";
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            DataFilter datafilter = MongoDBHelper.ConvertQuerySql(txtSql.Text);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataFilter NewDataFilter = MongoDBHelper.ConvertQuerySql(txtSql.Text);
                NewDataFilter.SaveFilter(savefile.FileName);
            }
        }
    }
}
