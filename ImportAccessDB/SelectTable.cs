using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImportAccessDB
{
    public partial class SelectTable : Form
    {
        public SelectTable()
        {
            InitializeComponent();
        }

        private void SelectTable_Load(object sender, EventArgs e)
        {
            AccessPicker.FileFilter = MongoCola.Module.MongoDbHelper.MdbFilter;
        }

        private void btnGetTabelList_Click(object sender, EventArgs e)
        {
            foreach (var item in ImportAccessDB.GetTableList(AccessPicker.SelectedPathOrFileName))
            {
                chkTable.Items.Add(item);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var Table = new List<String>();
            foreach (var item in chkTable.CheckedItems)
            {
                Table.Add(item.ToString());
            }
            ImportAccessDB.ImportAccessDataBase(AccessPicker.SelectedPathOrFileName, Table);
        }
    }
}
