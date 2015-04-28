using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Common;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoGUICtl;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using ResourceLib.Method;
using ResourceLib.UI;

namespace MongoCola.Operation
{
    public partial class FrmCollectionIndex : Form
    {
        /// <summary>
        ///     当前数据集名称
        /// </summary>
        private readonly MongoCollection _mongoCollection = RuntimeMongoDbContext.GetCurrentCollection();

        /// <summary>
        /// </summary>
        public FrmCollectionIndex()
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
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                Text = GuiConfig.GetText(TextType.CollectionIndexTitle);
                tabCurrentIndex.Text =
                    GuiConfig.GetText(TextType.CollectionIndexTabCurrent);
                cmdDelIndex.Text =
                    GuiConfig.GetText(
                        TextType.CollectionIndexTabCurrentDel);
                tabIndexManager.Text =
                    GuiConfig.GetText(TextType.CollectionIndexTabManager);
                cmdAddIndex.Text = GuiConfig.GetText(TextType.CommonAdd);

                chkIsDroppedDups.Text =
                    GuiConfig.GetText(TextType.IndexRepeatDel);
                chkIsBackground.Text =
                    GuiConfig.GetText(TextType.IndexBackground);
                chkIsSparse.Text = GuiConfig.GetText(TextType.IndexSparse);
                chkIsUnique.Text = GuiConfig.GetText(TextType.IndexUnify);

                lblIndexName.Text = GuiConfig.GetText(TextType.IndexName);
                chkExpireData.Text =
                    GuiConfig.GetText(TextType.IndexExpireData);

                lstIndex.Columns.Add(GuiConfig.GetText(TextType.IndexName));
                lstIndex.Columns.Add(
                    GuiConfig.GetText(TextType.IndexVersion));
                lstIndex.Columns.Add(GuiConfig.GetText(TextType.IndexKeys));
                lstIndex.Columns.Add(
                    GuiConfig.GetText(TextType.IndexNameSpace));

                lstIndex.Columns.Add(
                    GuiConfig.GetText(TextType.IndexBackground));
                lstIndex.Columns.Add(GuiConfig.GetText(TextType.IndexSparse));
                lstIndex.Columns.Add(GuiConfig.GetText(TextType.IndexUnify));
                lstIndex.Columns.Add(
                    GuiConfig.GetText(TextType.IndexRepeatDel));
                lstIndex.Columns.Add(
                    GuiConfig.GetText(TextType.IndexExpireData));
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
            if (RuntimeMongoDbContext.GetCurrentServer().BuildInfo.Version < new Version(2, 2, 2, 0))
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
                OperationHelper.DropMongoIndex(item.SubItems[0].Text, RuntimeMongoDbContext.GetCurrentCollection());
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
            var ascendingKey = new List<string>();
            var descendingKey = new List<string>();
            var geoSpatialKey = string.Empty;
            var firstKey = string.Empty;
            var textKey = string.Empty;
            for (var i = 0; i < 5; i++)
            {
                var ctl = (CtlIndexCreate) Controls.Find("ctlIndexCreate" + (i + 1), true)[0];
                if (ctl.KeyName == string.Empty) continue;
                firstKey = ctl.KeyName.Trim();
                switch (ctl.IndexKeyType)
                {
                    case EnumMgr.IndexType.Ascending:
                        ascendingKey.Add(ctl.KeyName.Trim());
                        break;
                    case EnumMgr.IndexType.Descending:
                        descendingKey.Add(ctl.KeyName.Trim());
                        break;
                    case EnumMgr.IndexType.GeoSpatial:
                        geoSpatialKey = ctl.KeyName.Trim();
                        break;
                    case EnumMgr.IndexType.Text:
                        textKey = ctl.KeyName.Trim();
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
                var canUseTtl = true;
                if ((ascendingKey.Count + descendingKey.Count + (string.IsNullOrEmpty(geoSpatialKey) ? 0 : 1)) != 1)
                {
                    MyMessageBox.ShowMessage("Can't Set TTL",
                        "the TTL index may not be compound (may not have multiple fields).");
                    canUseTtl = false;
                }
                else
                {
                    //不能是_id
                    if (firstKey == ConstMgr.KeyId)
                    {
                        MyMessageBox.ShowMessage("Can't Set TTL",
                            "you cannot create this index on the _id field, or a field that already has an index.");
                        canUseTtl = false;
                    }
                }
                if (RuntimeMongoDbContext.GetCurrentCollection().IsCapped())
                {
                    MyMessageBox.ShowMessage("Can't Set TTL",
                        "you cannot use a TTL index on a capped collection, because MongoDB cannot remove documents from a capped collection.");
                    canUseTtl = false;
                }
                if (canUseTtl)
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
                !RuntimeMongoDbContext.GetCurrentCollection().IndexExists(txtIndexName.Text) &&
                (ascendingKey.Count + descendingKey.Count +
                 (string.IsNullOrEmpty(geoSpatialKey) ? 0 : 1) +
                 (string.IsNullOrEmpty(textKey) ? 0 : 1)) != 0)
            {
                option.SetName(txtIndexName.Text);
                try
                {
                    //暂时要求只能一个TextKey
                    if (!string.IsNullOrEmpty(textKey))
                    {
                        var textKeysDoc = new IndexKeysDocument {{textKey, "text"}};
                        RuntimeMongoDbContext.GetCurrentCollection().CreateIndex(textKeysDoc, option);
                    }
                    else
                    {
                        OperationHelper.CreateMongoIndex(ascendingKey.ToArray(), descendingKey.ToArray(), geoSpatialKey,
                            option, RuntimeMongoDbContext.GetCurrentCollection());
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
                var listItem = new ListViewItem(item.Name);
                listItem.SubItems.Add(item.Version.ToString(CultureInfo.InvariantCulture));
                listItem.SubItems.Add(EnumMgr.GetKeyString(item.Key));
                listItem.SubItems.Add(item.Namespace);
                listItem.SubItems.Add(item.IsBackground.ToString());
                listItem.SubItems.Add(item.IsSparse.ToString());
                listItem.SubItems.Add(item.IsUnique.ToString());
                listItem.SubItems.Add(item.DroppedDups.ToString());
                listItem.SubItems.Add(item.TimeToLive != TimeSpan.MaxValue
                    ? item.TimeToLive.TotalSeconds.ToString(CultureInfo.InvariantCulture)
                    : "Not Set");
                lstIndex.Items.Add(listItem);
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