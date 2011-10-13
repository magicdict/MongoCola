using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Driver;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class frmCollectionIndex : frmBase
    {
        public frmCollectionIndex()
        {
            InitializeComponent();
        }
        MongoCollection mongoCollection = SystemManager.getCurrentCollection();
        private void frmCollectionIndex_Load(object sender, EventArgs e)
        {
            lstIndex.Columns.Add("名称");
            lstIndex.Columns.Add("版本");
            lstIndex.Columns.Add("索引键");
            lstIndex.Columns.Add("升降序");
            lstIndex.Columns.Add("名字空间");
            RefreshList();
        }

        private void cmdDelIndex_Click(object sender, EventArgs e)
        {
            if (lstIndex.SelectedItems.Count > 0) {
                MongoDBHelpler.DropMongoIndex(lstIndex.SelectedItems[0].SubItems[0].Text.ToString());
                lstIndex.Items.Remove(lstIndex.SelectedItems[0]);
            }
        }

        private void cmdAddIndex_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.CreateMongoIndex(txtIndexKey.Text, chkAsc.Checked);
            RefreshList();
        }
        private void RefreshList() {

            lstIndex.Items.Clear();
            foreach (var item in mongoCollection.GetIndexes())
            {
                ListViewItem lst = new ListViewItem(item.GetValue("name").ToString());
                lst.SubItems.Add(item.GetValue("v").ToString());
                lst.SubItems.Add(item.GetValue("key").AsBsonDocument.GetElement(0).Name);
                lst.SubItems.Add(item.GetValue("key").AsBsonDocument.GetElement(0).Value.ToInt32() == 1 ? "升序" : "降序");
                lst.SubItems.Add(item.GetValue("ns").ToString());
                lstIndex.Items.Add(lst);
            }
        }
    }
}
