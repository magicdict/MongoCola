using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MagicMongoDBTool
{
    public partial class frmCollectionIndex : Form
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
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCollectionIndex_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage)
            {
                this.Text = SystemManager.mStringResource.GetText(StringResource.TextType.CollectionIndex_Title);
                tabCurrentIndex.Text = SystemManager.mStringResource.GetText(StringResource.TextType.CollectionIndex_Tab_Current);
                cmdDelIndex.Text = SystemManager.mStringResource.GetText(StringResource.TextType.CollectionIndex_Tab_Current_Del);
                tabIndexManager.Text = SystemManager.mStringResource.GetText(StringResource.TextType.CollectionIndex_Tab_Manager);
                cmdAddIndex.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Add);

                chkIsDroppedDups.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_RepeatDel);
                chkIsBackground.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_Background);
                chkIsSparse.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_Sparse);
                chkIsUnique.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_Unify);

                lblIndexName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.CollectionIndex_TabMangt_IndexName);

                lstIndex.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Index_Name));
                lstIndex.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Index_Version));
                lstIndex.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Index_Keys));
                lstIndex.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Index_NameSpace));

                lstIndex.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Index_Background));
                lstIndex.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Index_Sparse));
                lstIndex.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Index_Unify));
                lstIndex.Columns.Add(SystemManager.mStringResource.GetText(StringResource.TextType.Index_RepeatDel));

            }
            else
            {
                lstIndex.Columns.Add("Name");
                lstIndex.Columns.Add("Version");
                lstIndex.Columns.Add("IndexKey");
                lstIndex.Columns.Add("NameSpace");
                lstIndex.Columns.Add("BackGround");
                lstIndex.Columns.Add("Sparse");
                lstIndex.Columns.Add("Unify");
                lstIndex.Columns.Add("DroppedDups");
            }
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
                if (lstIndex.CheckedItems[0].Index == 0)
                {
                    MessageBox.Show("Can't Delete Default Index!");
                    return;
                }
                foreach (ListViewItem item in lstIndex.CheckedItems)
                {
                    MongoDBHelper.DropMongoIndex(item.SubItems[0].Text.ToString());
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
                    if (ctl.IsAscendingKey)
                    {
                        AscendingKey.Add(ctl.KeyName);
                    }
                    else
                    {
                        DescendingKey.Add(ctl.KeyName);
                    }
                }
            }
            IndexOptionsBuilder option = new IndexOptionsBuilder();
            option.SetBackground(chkIsBackground.Checked);
            option.SetDropDups(chkIsDroppedDups.Checked);
            option.SetSparse(chkIsSparse.Checked);
            option.SetUnique(chkIsUnique.Checked);
            if (txtIndexName.Text != String.Empty && !SystemManager.GetCurrentCollection().IndexExists(txtIndexName.Text))
            {
                option.SetName(txtIndexName.Text);
            }
            MongoDBHelper.CreateMongoIndex(AscendingKey.ToArray(), DescendingKey.ToArray(), option);
            RefreshList();
            MessageBox.Show("Index Add Completed!");
        }
        /// <summary>
        /// 刷新索引列表
        /// </summary>
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
