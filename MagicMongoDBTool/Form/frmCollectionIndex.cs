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
            lstIndex.Columns.Add("IsBackground");
            lstIndex.Columns.Add("IsSparse");
            lstIndex.Columns.Add("IsUnique");
            lstIndex.Columns.Add("DroppedDups");
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
            foreach (IndexInfo item in _mongoCollection.GetIndexes())
            {
                ListViewItem lst = new ListViewItem(item.Name);
                lst.SubItems.Add(item.Version.ToString());
                lst.SubItems.Add(item.Key.GetElement(0).Name);
                lst.SubItems.Add(item.Key.GetElement(0).Value == 1 ? "升序" : "降序");
                lst.SubItems.Add(item.Namespace.ToString());
                lst.SubItems.Add(item.IsBackground.ToString());
                lst.SubItems.Add(item.IsSparse.ToString());
                lst.SubItems.Add(item.IsUnique.ToString());
                lst.SubItems.Add(item.DroppedDups.ToString());
                lstIndex.Items.Add(lst);
            }
        }
    }
}
