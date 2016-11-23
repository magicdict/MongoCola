using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;
using ResourceLib.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FunctionForm.Extend
{
    public partial class FrmShardingConfig : Form
    {
        /// <summary>
        ///     Tag和Set的字典
        /// </summary>
        private readonly Dictionary<string, string> _tagSet = new Dictionary<string, string>();

        /// <summary>
        ///     Mongo服务器
        /// </summary>
        private MongoServer _prmSvr;

        /// <summary>
        ///     初期化
        /// </summary>
        public FrmShardingConfig()
        {
            InitializeComponent();
        }


        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddSharding_Load(object sender, EventArgs e)
        {
            GuiConfig.Translateform(this);
            _prmSvr = RuntimeMongoDbContext.GetCurrentServer();
            var mongoDb = _prmSvr.GetDatabase(ConstMgr.DatabaseNameConfig);
            MongoCollection mongoCol = mongoDb.GetCollection("databases");
            foreach (var item in mongoCol.FindAllAs<BsonDocument>())
            {
                if (item.GetValue(ConstMgr.KeyId) != ConstMgr.DatabaseNameAdmin)
                {
                    cmbDataBase.Items.Add(item.GetValue(ConstMgr.KeyId));
                    cmbShardKeyDB.Items.Add(item.GetValue(ConstMgr.KeyId));
                }
            }
            foreach (var lst in Operater.GetShardInfo(_prmSvr, ConstMgr.KeyId))
            {
                lstSharding.Items.Add(lst.Value);
                cmbShard.Items.Add(lst.Value);
            }
            MongoCollection ColShards = mongoDb.GetCollection("shards");
            RefreshShardingZone();
            RefreshShardingRange();
        }

        /// <summary>
        ///     关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Basic

        /// <summary>
        ///     增加Shard的高级选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAdvance_CheckedChanged(object sender, EventArgs e)
        {
            grpAdvanced.Enabled = chkAdvance.Checked;
        }

        /// <summary>
        ///     添加HostList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddHost_Click(object sender, EventArgs e)
        {
            var strHost = string.Empty;
            strHost = txtReplHost.Text;
            if (NumReplPort.Value != 0)
            {
                strHost += ":" + NumReplPort.Value;
            }
            lstHost.Items.Add(strHost);
            cmdAddSharding.Enabled = true;
        }

        /// <summary>
        ///     移除HostList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemoveHost_Click(object sender, EventArgs e)
        {
            lstHost.Items.Remove(lstHost.SelectedItem);
            if (lstHost.Items.Count == 0)
            {
                cmdAddSharding.Enabled = false;
            }
        }

        /// <summary>
        ///     增加分片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddSharding_Click(object sender, EventArgs e)
        {
            var lstAddress = new List<string>();
            foreach (string item in lstHost.Items)
            {
                lstAddress.Add(item.Trim());
            }
            var resultlst = new List<CommandResult>();
            CommandResult result;
            if (chkAdvance.Checked)
            {
                result = DataBaseCommand.AddSharding(_prmSvr, txtReplsetName.Text, lstAddress, txtName.Text,
                    NumMaxSize.Value);
            }
            else
            {
                result = DataBaseCommand.AddSharding(_prmSvr, txtReplsetName.Text, lstAddress, string.Empty, 0);
            }
            resultlst.Add(result);
            MyMessageBox.ShowMessage("Add Sharding", "Result:" + (result.Ok ? "OK" : "Fail"),
                MongoHelper.ConvertCommandResultlstToString(resultlst));
            lstSharding.Items.Clear();
            foreach (var lst in Operater.GetShardInfo(_prmSvr, "_id"))
            {
                lstSharding.Items.Add(lst.Value);
            }
            lstHost.Items.Clear();
        }

        /// <summary>
        ///     移除Sharding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemoveSharding_Click(object sender, EventArgs e)
        {
            foreach (string item in lstSharding.SelectedItems)
            {
                var resultlst = new List<CommandResult> { DataBaseCommand.RemoveSharding(_prmSvr, item) };
                MyMessageBox.ShowMessage("Remove Sharding", "Result",
                    MongoHelper.ConvertCommandResultlstToString(resultlst));
            }
            lstSharding.Items.Clear();
            foreach (var lst in Operater.GetShardInfo(_prmSvr, "_id"))
            {
                lstSharding.Items.Add(lst.Value);
            }
        }

        #endregion

        #region Config

        /// <summary>
        ///     分片配置(数据库)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEnableSharding_Click(object sender, EventArgs e)
        {
            var resultlst = new List<CommandResult> { DataBaseCommand.EnableSharding(_prmSvr, cmbDataBase.Text) };
            MyMessageBox.ShowMessage("EnableSharding", "Result",
                MongoHelper.ConvertCommandResultlstToString(resultlst));
        }

        /// <summary>
        ///     分片配置(数据集)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdShardCollectionSharding_Click(object sender, EventArgs e)
        {
            var resultlst = new List<CommandResult>();
            var result = _prmSvr.GetDatabase(cmbDataBase.Text).GetCollection(cmbCollection.Text).GetIndexes();
            BsonDocument indexDoc = result[cmbIndexList.SelectedIndex].Key;
            resultlst.Add(DataBaseCommand.ShardCollection(_prmSvr, cmbDataBase.Text + "." + cmbCollection.Text, indexDoc));
            MyMessageBox.ShowMessage("EnableSharding", "Result",
                MongoHelper.ConvertCommandResultlstToString(resultlst));
        }

        /// <summary>
        ///     数据库切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var mongoDb = _prmSvr.GetDatabase(cmbDataBase.Text);
                cmbCollection.Items.Clear();
                cmbCollection.Text = string.Empty;
                foreach (var item in mongoDb.GetCollectionNames())
                {
                    cmbCollection.Items.Add(item);
                }
                cmbIndexList.Items.Clear();
                lstExistShardRange.Items.Clear();
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
        }

        /// <summary>
        ///     数据集变换时，实时更新主键列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var mongoDb = _prmSvr.GetDatabase(cmbDataBase.Text);
                cmbIndexList.Items.Clear();
                cmbIndexList.Text = string.Empty;
                //Sharding Must Index
                foreach (var indexitem in mongoDb.GetCollection(cmbCollection.Text).GetIndexes())
                {
                    cmbIndexList.Items.Add(indexitem.Name);
                }
                cmbIndexList.Text = cmbIndexList.Items[0].ToString();
                //Tag和数据集绑定，从系统数据集tags里面读取tag的信息
                var mongoDbConfig = _prmSvr.GetDatabase(ConstMgr.DatabaseNameConfig);
                MongoCollection mongoCol = mongoDbConfig.GetCollection("tags");
                lstExistShardRange.Items.Clear();
                lstExistShardRange.Columns.Add("Tag");
                lstExistShardRange.Columns.Add("NameSpace");
                lstExistShardRange.Columns.Add("Min");
                lstExistShardRange.Columns.Add("Max");
                foreach (var tags in mongoCol.FindAllAs<BsonDocument>())
                {
                    if (tags.GetElement("ns").Value.ToString() != BsonUndefined.Value.ToString())
                    {
                        if (tags.GetElement("ns").Value.ToString() == cmbDataBase.Text + "." + cmbCollection.Text)
                        {
                            var listItem =
                                new ListViewItem(_tagSet[tags.GetElement("tag").Value.ToString()] + "." +
                                                 tags.GetElement("tag").Value);
                            listItem.SubItems.Add(tags.GetElement("ns").Value.ToString());
                            listItem.SubItems.Add(tags.GetElement("min").Value.ToString());
                            listItem.SubItems.Add(tags.GetElement("max").Value.ToString());
                            lstExistShardRange.Items.Add(listItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
        }

        /// <summary>
        ///     为Sharding增加Zone(Tag)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddShardZone_Click(object sender, EventArgs e)
        {
            var resultlst = new List<CommandResult>
            {
                DataBaseCommand.AddShardToZone(_prmSvr, cmbShard.Text, txtShardZone.Text)
            };
            MyMessageBox.ShowMessage("Add Shard Zone", "Result", MongoHelper.ConvertCommandResultlstToString(resultlst));
            RefreshShardingZone();
        }

        #endregion

        /// <summary>
        ///     ShardKey数据库变换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbShardKeyDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var mongoDb = _prmSvr.GetDatabase(cmbShardKeyDB.Text);
                cmbShardKeyCol.Items.Clear();
                cmbShardKeyCol.Text = string.Empty;
                foreach (var item in mongoDb.GetCollectionNames())
                {
                    cmbShardKeyCol.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
        }

        /// <summary>
        ///     ShardKey数据集变换时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbShardKeyCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Col = _prmSvr.GetDatabase(cmbShardKeyDB.Text).GetCollection(cmbShardKeyCol.Text);
            var columnList = MongoHelper.GetCollectionSchame(Col);
            UIAssistant.FillComberWithArray(cmbField, columnList.ToArray(), true);
        }

        /// <summary>
        ///     Add Zone Range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdaddZoneRange_Click(object sender, EventArgs e)
        {
            var resultlst = new List<CommandResult>
            {
                DataBaseCommand.updateZoneKeyRange(_prmSvr, cmbShardKeyDB.Text + "." + cmbShardKeyCol.Text,cmbField.Text, ctlBsonValueShardKeyFrom.GetValue(),
                                          ctlBsonValueShardKeyTo.GetValue(), cmbTagList.Text.Split(".".ToCharArray())[1])
            };
            MyMessageBox.ShowMessage("Add Shard Tag", "Result",
                MongoHelper.ConvertCommandResultlstToString(resultlst));
            RefreshShardingRange();
        }

        /// <summary>
        ///     刷新分片区域
        /// </summary>
        private void RefreshShardingZone()
        {
            var mongoDb = _prmSvr.GetDatabase(ConstMgr.DatabaseNameConfig);
            MongoCollection ColShards = mongoDb.GetCollection("shards");
            //现存Zone的列表
            cmbTagList.Items.Clear();
            lstExistShardZone.Columns.Clear();
            lstExistShardZone.Columns.Add("Shard Name");
            lstExistShardZone.Columns.Add("Zone Name");
            lstExistShardZone.Items.Clear();
            _tagSet.Clear();
            foreach (var mShard in ColShards.FindAllAs<BsonDocument>())
            {
                if (mShard.Contains("tags"))
                {
                    foreach (var tag in mShard.GetElement("tags").Value.AsBsonArray)
                    {
                        //严格意义上说，不应该在同一个路由里面出现两个同名的标签。
                        if (!_tagSet.ContainsKey(tag.ToString()))
                        {
                            _tagSet.Add(tag.ToString(), mShard.GetElement(ConstMgr.KeyId).Value.ToString());
                            cmbTagList.Items.Add(mShard.GetElement(ConstMgr.KeyId).Value + "." + tag);
                            var Item = new ListViewItem(mShard.GetElement(ConstMgr.KeyId).Value.AsString);
                            Item.SubItems.Add(tag.AsString);
                            lstExistShardZone.Items.Add(Item);
                        }
                    }
                }
            }
            UIAssistant.ListViewColumnResize(lstExistShardZone);
        }

        /// <summary>
        ///     刷新分片范围
        /// </summary>
        private void RefreshShardingRange()
        {
            var mongoDb = _prmSvr.GetDatabase(ConstMgr.DatabaseNameConfig);
            MongoCollection ColTags = mongoDb.GetCollection("tags");
            lstExistShardRange.Columns.Clear();
            lstExistShardRange.Columns.Add("Tag");
            lstExistShardRange.Columns.Add("Collection");
            lstExistShardRange.Columns.Add("MinDoc");
            lstExistShardRange.Columns.Add("MaxDoc");
            lstExistShardRange.Items.Clear();
            foreach (var mShard in ColTags.FindAllAs<BsonDocument>())
            {
                var Item = new ListViewItem(mShard.GetElement("tag").Value.AsString);
                Item.SubItems.Add(mShard.GetElement(ConstMgr.KeyId).Value.AsBsonDocument.GetElement("ns").Value.ToString());
                Item.SubItems.Add(mShard.GetElement("min").Value.ToString());
                Item.SubItems.Add(mShard.GetElement("max").Value.ToString());
                lstExistShardRange.Items.Add(Item);
            }
            UIAssistant.ListViewColumnResize(lstExistShardRange);
        }
    }
}