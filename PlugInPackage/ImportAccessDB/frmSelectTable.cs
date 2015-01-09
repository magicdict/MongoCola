using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MongoUtility.Basic;

namespace PlugInPackage
{
    internal partial class frmSelectTable : Form
    {
        public frmSelectTable()
        {
            InitializeComponent();
        }
		
        private void SelectTable_Load(object sender, EventArgs e)
        {
            AccessPicker.FileFilter = Common.Utility.MdbFilter;
        }
		
        private void btnGetTabelList_Click(object sender, EventArgs e)
        {
            foreach (var item in ImportAccessDB.GetTableList(AccessPicker.SelectedPathOrFileName))
            {
                chkTable.Items.Add(item);
            }
        }
        /// <summary>
        /// 必须设定
        /// </summary>
        public MongoDB.Driver.MongoServer mServer  = null;
        /// <summary>
        /// 
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
            ImportAccessDB.ImportAccessDataBase(AccessPicker.SelectedPathOrFileName, Table,mServer);
        }
    }
}
