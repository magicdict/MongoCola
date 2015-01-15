using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common.Utility;
using MongoDB.Driver;

namespace PlugInPackage.ImportAccessDB
{
    internal partial class frmSelectTable : Form
    {
        /// <summary>
        ///     必须设定
        /// </summary>
        public MongoServer mServer = null;

        public frmSelectTable()
        {
            InitializeComponent();
        }

        private void SelectTable_Load(object sender, EventArgs e)
        {
            AccessPicker.FileFilter = Utility.MdbFilter;
        }

        private void btnGetTabelList_Click(object sender, EventArgs e)
        {
            foreach (var item in ImportAccessDB.GetTableList(AccessPicker.SelectedPathOrFileName))
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
            var Table = new List<String>();
            foreach (var item in chkTable.CheckedItems)
            {
                Table.Add(item.ToString());
            }
            ImportAccessDB.ImportAccessDataBase(AccessPicker.SelectedPathOrFileName, Table, mServer);
        }
    }
}