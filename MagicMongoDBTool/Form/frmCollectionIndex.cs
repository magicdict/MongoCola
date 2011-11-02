using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
namespace MagicMongoDBTool
{
    public partial class frmCollectionIndex : QLFUI.QLFForm
    {
        public frmCollectionIndex()
        {
            InitializeComponent();
        }
        private MongoCollection _mongoCollection = SystemManager.GetCurrentCollection();
        private void frmCollectionIndex_Load(object sender, EventArgs e)
        {
            lstIndex.Columns.Add("名称");
            lstIndex.Columns.Add("版本");
            lstIndex.Columns.Add("索引键");
            lstIndex.Columns.Add("升降序");
            lstIndex.Columns.Add("名字空间");
            RefreshList();
        }
        /// <summary>
        /// 删除索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDelIndex_Click(object sender, EventArgs e)
        {
            if (lstIndex.SelectedItems.Count > 0)
            {
                if (lstIndex.SelectedIndices[0] == 0) {
                    MessageBox.Show("无法删除默认索引");
                    return;
                }
                MongoDBHelpler.DropMongoIndex(lstIndex.SelectedItems[0].SubItems[0].Text.ToString());
                lstIndex.Items.Remove(lstIndex.SelectedItems[0]);
            }
        }
        /// <summary>
        /// 增加索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddIndex_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.CreateMongoIndex(txtIndexKey.Text, chkAsc.Checked);
            RefreshList();
        }
        private void RefreshList()
        {
            lstIndex.Items.Clear();
            foreach (var item in _mongoCollection.GetIndexes())
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
