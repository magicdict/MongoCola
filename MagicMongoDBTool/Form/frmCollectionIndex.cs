using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
using System.Collections.Generic;
namespace MagicMongoDBTool
{
    public partial class frmCollectionIndex : QLFUI.QLFForm
    {
        /// <summary>
        /// 当前数据集名称
        /// </summary>
        private MongoCollection _mongoCollection = SystemManager.GetCurrentCollection();
        /// <summary>
        /// 
        /// </summary>
        public frmCollectionIndex()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCollectionIndex_Load(object sender, EventArgs e)
        {
            this.tabIndexMgr.SelectedIndexChanged += new EventHandler(
                //初始的时候，不能原因的问题，界面的背景色不正确，强制刷新背景色
                (x, y) => { tabIndexMgr.SelectedTab.Invalidate(); }
              );
            lstIndex.Columns.Add("名称");
            lstIndex.Columns.Add("版本");
            lstIndex.Columns.Add("索引键");
            lstIndex.Columns.Add("名字空间");
            lstIndex.Columns.Add("背景索引");
            lstIndex.Columns.Add("稀疏索引");
            lstIndex.Columns.Add("统一索引");
            lstIndex.Columns.Add("删除重复索引");
            RefreshList();
        }
        /// <summary>
        /// 删除索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDelIndex_Click(object sender, EventArgs e)
        {
            if (lstIndex.CheckedItems.Count > 0)
            {
                if (lstIndex.CheckedItems[0].Index == 0) {
                    MessageBox.Show("无法删除默认索引");
                    return;
                }
                foreach (ListViewItem item in lstIndex.CheckedItems)
                {
                    MongoDBHelpler.DropMongoIndex(item.SubItems[0].Text.ToString());
                }
                RefreshList();
            }
        }
        /// <summary>
        /// 增加索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddIndex_Click(object sender, EventArgs e)
        {
            List<String> AscendingKey = new List<String>();
            List<String> DescendingKey = new List<String>();

            for (int i = 0; i < 5; i++)
            {
                ctlIndexCreate ctl = (ctlIndexCreate)Controls.Find("ctlIndexCreate" + (i + 1).ToString(), true)[0];
                if (ctl.KeyName != String.Empty)
                {
                    if (ctl.IsAscendingKey) {
                        AscendingKey.Add(ctl.KeyName);
                    } else {
                        DescendingKey.Add(ctl.KeyName);
                    }
                }
            }
            MongoDBHelpler.CreateMongoIndex(AscendingKey.ToArray(), DescendingKey.ToArray(),
                chkIsBackground.Checked,chkDroppedDups.Checked,chkIsSparse.Checked,chkIsUnique.Checked,txtIndexName.Text);
            RefreshList();
            MessageBox.Show("添加索引操作完毕");    
        }
        private void RefreshList()
        {
            lstIndex.Items.Clear();
            foreach (IndexInfo item in _mongoCollection.GetIndexes())
            {
                ListViewItem lst = new ListViewItem(item.Name);
                lst.SubItems.Add(item.Version.ToString());
                lst.SubItems.Add(item.Key.ToString());
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
