using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Common;
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

            var option = new Operater.IndexOption();
            option.IsBackground = chkIsBackground.Checked;
            option.IsDropDups = chkIsDroppedDups.Checked;
            option.IsSparse = chkIsSparse.Checked;
            option.IsUnique = chkIsUnique.Checked;
            option.IsExpireData = chkExpireData.Checked;
            option.TTL = (int)numTTL.Value;
            option.ascendingKey = ascendingKey;
            option.descendingKey = descendingKey;
            option.geoSpatialKey = geoSpatialKey;
            option.firstKey = firstKey;
            option.textKey = textKey;
            option.IndexName = txtIndexName.Text;
            var strMessageTitle = string.Empty;
            var strMessageContent = string.Empty;
            if (Operater.CreateIndex(option, ref strMessageTitle, ref strMessageTitle)) { 
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