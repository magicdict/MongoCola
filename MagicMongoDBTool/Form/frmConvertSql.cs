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
    public partial class frmConvertSql : QLFForm 
    {
        public frmConvertSql()
        {
            InitializeComponent();
        }
        private void frmRunSql_Load(object sender, EventArgs e)
        {
            txtSql.Text = "select * from CollectionName where FieldName=1 order by FieldName asc";
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataFilter NewDataFilter = MongoDBHelper.ConvertQuerySql(txtSql.Text);
                NewDataFilter.SaveFilter(savefile.FileName);
            }
            this.Close();
        }
    }
}
