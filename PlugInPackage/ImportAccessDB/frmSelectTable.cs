using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;
using MongoDB.Driver;

namespace PlugInPackage.ImportAccessDB
{
    internal partial class FrmSelectTable : Form
    {
        /// <summary>
        ///     必须设定
        /// </summary>
        public MongoServer mServer = null;

        public FrmSelectTable()
        {
            InitializeComponent();
        }

        private void SelectTable_Load(object sender, EventArgs e)
        {
            AccessPicker.FileFilter = Utility.AccessDBFilter;
        }

        private void btnGetTabelList_Click(object sender, EventArgs e)
        {
            foreach (var item in ImportAccessDb.GetTableList(AccessPicker.SelectedPathOrFileName))
            {
                chkTable.Items.Add(item);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            var table = new List<string>();
            foreach (var item in chkTable.CheckedItems)
            {
                table.Add(item.ToString());
            }
            ImportAccessDb.ImportAccessDataBase(AccessPicker.SelectedPathOrFileName, table, mServer);
            MessageBox.Show("Completed");
        }
    }
}