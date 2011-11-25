using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GUIResource;
using MagicMongoDBTool.Module;
using MongoDB.Driver;

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
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCollectionIndex_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage())
            {
                this.Text = SystemManager.mStringResource.GetText(StringResource.TextType.CollectionIndex_Title);
                tabCurrentIndex.Text = SystemManager.mStringResource.GetText(StringResource.TextType.CollectionIndex_Tab_Current);
                cmdDelIndex.Text = SystemManager.mStringResource.GetText(StringResource.TextType.CollectionIndex_Tab_Current_Del);
                tabIndexManager.Text = SystemManager.mStringResource.GetText(StringResource.TextType.CollectionIndex_Tab_Manager);
                cmdAddIndex.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Add);

                chkDroppedDups.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_RepeatDel);
                chkIsBackground.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_Background);
                chkIsSparse.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_Sparse);
                chkIsUnique.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_Unify);

                lblIndexName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.CollectionIndex_TabMangt_IndexName);
                txtIndexName.WaterMark = SystemManager.mStringResource.GetText(StringResource.TextType.CollectionIndex_TabMangt_IndexName_Description);


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

                lstIndex.Columns.Add("名称");
                lstIndex.Columns.Add("版本");
                lstIndex.Columns.Add("索引键");
                lstIndex.Columns.Add("名字空间");
                lstIndex.Columns.Add("背景索引");
                lstIndex.Columns.Add("稀疏索引");
                lstIndex.Columns.Add("唯一索引");
                lstIndex.Columns.Add("删除重复索引");

            }

            this.tabIndexMgr.SelectedIndexChanged += new EventHandler(
                //初始的时候，原因不明的问题造成界面的背景色不正确，所以强制刷新背景色
                (x, y) => { tabIndexMgr.SelectedTab.Invalidate(); }
              );
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
                    MessageBox.Show("无法删除默认索引");
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
            MongoDBHelper.CreateMongoIndex(AscendingKey.ToArray(),
                                            DescendingKey.ToArray(),
                                            chkIsBackground.Checked,
                                            chkDroppedDups.Checked,
                                            chkIsSparse.Checked,
                                            chkIsUnique.Checked,
                                            txtIndexName.Text);
            RefreshList();
            MessageBox.Show("添加索引操作完毕");
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
