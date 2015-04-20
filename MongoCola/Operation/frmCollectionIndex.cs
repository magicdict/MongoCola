using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using SystemUtility;
using Common.UI;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoGUICtl;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using ResourceLib.Utility;
using Utility = Common.Logic.Utility;

namespace MongoCola.Operation
{
    public partial class frmCollectionIndex : Form
    {
        /// <summary>
        ///     当前数据集名称
        /// </summary>
        private readonly MongoCollection _mongoCollection = RuntimeMongoDBContext.GetCurrentCollection();

        /// <summary>
        /// </summary>
        public frmCollectionIndex()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCollectionIndex_Load(object sender, EventArgs e)
        {
            if (!SystemConfig.IsUseDefaultLanguage)
            {
                Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.CollectionIndex_Title);
                tabCurrentIndex.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.CollectionIndex_Tab_Current);
                cmdDelIndex.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(
                        StringResource.TextType.CollectionIndex_Tab_Current_Del);
                tabIndexManager.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.CollectionIndex_Tab_Manager);
                cmdAddIndex.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Add);

                chkIsDroppedDups.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Index_RepeatDel);
                chkIsBackground.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Index_Background);
                chkIsSparse.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Index_Sparse);
                chkIsUnique.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Index_Unify);

                lblIndexName.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Index_Name);
                chkExpireData.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Index_ExpireData);

                lstIndex.Columns.Add(SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Index_Name));
                lstIndex.Columns.Add(
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Index_Version));
                lstIndex.Columns.Add(SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Index_Keys));
                lstIndex.Columns.Add(
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Index_NameSpace));

                lstIndex.Columns.Add(
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Index_Background));
                lstIndex.Columns.Add(SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Index_Sparse));
                lstIndex.Columns.Add(SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Index_Unify));
                lstIndex.Columns.Add(
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Index_RepeatDel));
                lstIndex.Columns.Add(
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Index_ExpireData));
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
                lstIndex.Columns.Add("Expire Data");
            }
            //2.2.2 开始支持TTL索引
            if (RuntimeMongoDBContext.GetCurrentServer().BuildInfo.Version < new Version(2, 2, 2, 0))
            {
                chkExpireData.Enabled = false;
                numTTL.Enabled = false;
            }
            RefreshList();
        }

        /// <summary>
        ///     删除索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDelIndex_Click(object sender, EventArgs e)
        {
            if (lstIndex.CheckedItems.Count <= 0) return;
            if (lstIndex.CheckedItems[0].Index == 0)
            {
                MessageBox.Show("Can't Delete Default Index!");
                return;
            }
            foreach (ListViewItem item in lstIndex.CheckedItems)
            {
                OperationHelper.DropMongoIndex(item.SubItems[0].Text, RuntimeMongoDBContext.GetCurrentCollection());
            }
            RefreshList();
        }

        /// <summary>
        ///     增加索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddIndex_Click(object sender, EventArgs e)
        {
            var AscendingKey = new List<string>();
            var DescendingKey = new List<string>();
            var GeoSpatialKey = string.Empty;
            var FirstKey = string.Empty;
            var TextKey = string.Empty;
            for (var i = 0; i < 5; i++)
            {
                var ctl = (ctlIndexCreate) Controls.Find("ctlIndexCreate" + (i + 1), true)[0];
                if (ctl.KeyName == string.Empty) continue;
                FirstKey = ctl.KeyName.Trim();
                switch (ctl.IndexKeyType)
                {
                    case EnumMgr.IndexType.Ascending:
                        AscendingKey.Add(ctl.KeyName.Trim());
                        break;
                    case EnumMgr.IndexType.Descending:
                        DescendingKey.Add(ctl.KeyName.Trim());
                        break;
                    case EnumMgr.IndexType.GeoSpatial:
                        GeoSpatialKey = ctl.KeyName.Trim();
                        break;
                    case EnumMgr.IndexType.Text:
                        TextKey = ctl.KeyName.Trim();
                        break;
                    default:
                        break;
                }
            }
            var option = new IndexOptionsBuilder();
            option.SetBackground(chkIsBackground.Checked);
            option.SetDropDups(chkIsDroppedDups.Checked);
            option.SetSparse(chkIsSparse.Checked);
            option.SetUnique(chkIsUnique.Checked);
            if (chkExpireData.Checked)
            {
                //TTL的限制条件很多
                //http://docs.mongodb.org/manual/tutorial/expire-data/
                //不能是组合键
                var CanUseTTL = true;
                if ((AscendingKey.Count + DescendingKey.Count + (string.IsNullOrEmpty(GeoSpatialKey) ? 0 : 1)) != 1)
                {
                    MyMessageBox.ShowMessage("Can't Set TTL",
                        "the TTL index may not be compound (may not have multiple fields).");
                    CanUseTTL = false;
                }
                else
                {
                    //不能是_id
                    if (FirstKey == ConstMgr.KEY_ID)
                    {
                        MyMessageBox.ShowMessage("Can't Set TTL",
                            "you cannot create this index on the _id field, or a field that already has an index.");
                        CanUseTTL = false;
                    }
                }
                if (RuntimeMongoDBContext.GetCurrentCollection().IsCapped())
                {
                    MyMessageBox.ShowMessage("Can't Set TTL",
                        "you cannot use a TTL index on a capped collection, because MongoDB cannot remove documents from a capped collection.");
                    CanUseTTL = false;
                }
                if (CanUseTTL)
                {
                    MyMessageBox.ShowMessage("Constraints", "Constraints Of TimeToLive",
                        "the indexed field must be a date BSON type. If the field does not have a date type, the data will not expire." +
                        Environment.NewLine +
                        "if the field holds an array, and there are multiple date-typed data in the index, the document will expire when the lowest (i.e. earliest) matches the expiration threshold.",
                        true);
                    option.SetTimeToLive(new TimeSpan(0, 0, (int) numTTL.Value));
                }
            }
            if (txtIndexName.Text != string.Empty &&
                !RuntimeMongoDBContext.GetCurrentCollection().IndexExists(txtIndexName.Text) &&
                (AscendingKey.Count + DescendingKey.Count +
                 (string.IsNullOrEmpty(GeoSpatialKey) ? 0 : 1) +
                 (string.IsNullOrEmpty(TextKey) ? 0 : 1)) != 0)
            {
                option.SetName(txtIndexName.Text);
                try
                {
                    //暂时要求只能一个TextKey
                    if (!string.IsNullOrEmpty(TextKey))
                    {
                        var TextKeysDoc = new IndexKeysDocument {{TextKey, "text"}};
                        RuntimeMongoDBContext.GetCurrentCollection().CreateIndex(TextKeysDoc, option);
                    }
                    else
                    {
                        OperationHelper.CreateMongoIndex(AscendingKey.ToArray(), DescendingKey.ToArray(), GeoSpatialKey,
                            option, RuntimeMongoDBContext.GetCurrentCollection());
                    }
                    MyMessageBox.ShowMessage("Index Add Completed!",
                        "IndexName:" + txtIndexName.Text + " is add to collection.");
                }
                catch (Exception ex)
                {
                    Utility.ExceptionDeal(ex, "Index Add Failed!", "IndexName:" + txtIndexName.Text);
                }
                RefreshList();
            }
            else
            {
                MyMessageBox.ShowMessage("Index Add Failed!", "Please Check the index information.");
            }
        }

        /// <summary>
        ///     刷新索引列表
        /// </summary>
        private void RefreshList()
        {
            lstIndex.Items.Clear();
            foreach (var item in _mongoCollection.GetIndexes())
            {
                var ListItem = new ListViewItem(item.Name);
                ListItem.SubItems.Add(item.Version.ToString(CultureInfo.InvariantCulture));
                ListItem.SubItems.Add(UIHelper.GetKeyString(item.Key));
                ListItem.SubItems.Add(item.Namespace);
                ListItem.SubItems.Add(item.IsBackground.ToString());
                ListItem.SubItems.Add(item.IsSparse.ToString());
                ListItem.SubItems.Add(item.IsUnique.ToString());
                ListItem.SubItems.Add(item.DroppedDups.ToString());
                ListItem.SubItems.Add(item.TimeToLive != TimeSpan.MaxValue
                    ? item.TimeToLive.TotalSeconds.ToString(CultureInfo.InvariantCulture)
                    : "Not Set");
                lstIndex.Items.Add(ListItem);
            }
        }

        /// <summary>
        ///     TTL Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTTL_CheckedChanged(object sender, EventArgs e)
        {
            numTTL.Enabled = chkExpireData.Checked;
        }
    }
}