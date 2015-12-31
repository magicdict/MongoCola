using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using MongoGUICtl;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.UI;

namespace FunctionForm.Operation
{
    public partial class FrmCollectionIndex : Form
    {
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
            GuiConfig.Translateform(this);
            lstIndex.Columns.Add(GuiConfig.GetText("Name", TextType.IndexName));
            lstIndex.Columns.Add(GuiConfig.GetText("Version", TextType.IndexVersion));
            lstIndex.Columns.Add(GuiConfig.GetText("IndexKey", TextType.IndexKeys));
            lstIndex.Columns.Add(GuiConfig.GetText("NameSpace", TextType.IndexNameSpace));
            lstIndex.Columns.Add(GuiConfig.GetText("BackGround", TextType.IndexBackground));
            lstIndex.Columns.Add(GuiConfig.GetText("Sparse", TextType.IndexSparse));
            lstIndex.Columns.Add(GuiConfig.GetText("Unify", TextType.IndexUnify));
            lstIndex.Columns.Add(GuiConfig.GetText("DroppedDups", TextType.IndexRepeatDel));
            lstIndex.Columns.Add(GuiConfig.GetText("Expire Data", TextType.IndexExpireData));
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
                Operater.DropMongoIndex(item.SubItems[0].Text, RuntimeMongoDbContext.GetCurrentCollection());
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
            //Index UIOption
            var uiOption = new Operater.IndexOption();
            uiOption.IsBackground = chkIsBackground.Checked;
            uiOption.IsDropDups = chkIsDroppedDups.Checked;
            uiOption.IsSparse = chkIsSparse.Checked;
            uiOption.IsUnique = chkIsUnique.Checked;
            uiOption.IsExpireData = chkExpireData.Checked;
            //Partial Indexes
            uiOption.IsPartial = chkPartialIndexes.Checked;
            uiOption.Ttl = (int) numTTL.Value;
            uiOption.AscendingKey = ascendingKey;
            uiOption.DescendingKey = descendingKey;
            uiOption.GeoSpatialKey = geoSpatialKey;
            uiOption.FirstKey = firstKey;
            uiOption.TextKey = textKey;
            uiOption.IndexName = txtIndexName.Text;
            //Partial Indexes
            uiOption.PartialCondition = txtPartialIndexes.Text;
            var strMessageTitle = string.Empty;
            var strMessageContent = string.Empty;
            if (Operater.CreateIndex(uiOption, ref strMessageTitle, ref strMessageContent))
            {
                RefreshList();
            }
            MyMessageBox.ShowEasyMessage(strMessageTitle, strMessageContent);
        }

        /// <summary>
        ///     刷新索引列表
        /// </summary>
        private void RefreshList()
        {
            lstIndex.Items.Clear();
            foreach (var item in RuntimeMongoDbContext.GetCurrentCollection().GetIndexes())
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