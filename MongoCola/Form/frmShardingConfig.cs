using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SystemUtility;
using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.Operation;
using ResourceLib;
using Utility = MongoUtility.Basic.Utility;

namespace MongoCola
{
    public partial class frmShardingConfig : Form
    {
        /// <summary>
        ///     Tag和Set的字典
        /// </summary>
        private readonly Dictionary<String, String> TagSet = new Dictionary<string, string>();

        /// <summary>
        ///     Mongo服务器
        /// </summary>
        private MongoServer _prmSvr;

        /// <summary>
        ///     初期化
        /// </summary>
        public frmShardingConfig()
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
            if (!SystemConfig.IsUseDefaultLanguage)
            {
                cmdClose.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Close);
                cmdAddHost.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.AddConnection_Region_AddHost);
                cmdRemoveHost.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(
                        StringResource.TextType.AddConnection_Region_RemoveHost);
                lblReplHost.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Host);
                lblReplPort.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Port);

                Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.ShardingConfig_Title);
                tabAddSharding.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.ShardingConfig_AddSharding);
                lblMainReplsetName.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.ShardingConfig_ReplsetName);
                cmdAddSharding.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Add);
                chkAdvance.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Advance_Option);
                tabShardingConfig.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.ShardingConfig_EnableSharding);
                lblDBName.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.ShardingConfig_DBName);
                lblCollection.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.ShardingConfig_CollectionName);
                lblIndexLName.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.ShardingConfig_FieldName);
                cmdEnableCollectionSharding.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(
                        StringResource.TextType.ShardingConfig_Action_CollectionSharding);
                cmdEnableDBSharding.Text =
                    SystemConfig.guiConfig.MStringResource.GetText(
                        StringResource.TextType.ShardingConfig_Action_DBSharding);
            }
            _prmSvr = RuntimeMongoDBContext.GetCurrentServer();
            var mongoDB = _prmSvr.GetDatabase(ConstMgr.DATABASE_NAME_CONFIG);
            MongoCollection mongoCol = mongoDB.GetCollection("databases");
            foreach (var item in mongoCol.FindAllAs<BsonDocument>())
            {
                if (item.GetValue(ConstMgr.KEY_ID) != ConstMgr.DATABASE_NAME_ADMIN)
                {
                    cmbDataBase.Items.Add(item.GetValue(ConstMgr.KEY_ID));
                    cmbShardKeyDB.Items.Add(item.GetValue(ConstMgr.KEY_ID));
                }
            }
            foreach (var lst in OperationHelper.GetShardInfo(_prmSvr, ConstMgr.KEY_ID))
            {
                lstSharding.Items.Add(lst.Value);
            }
            mongoCol = mongoDB.GetCollection("shards");
            cmbTagList.Items.Clear();
            foreach (var mShard in mongoCol.FindAllAs<BsonDocument>())
            {
                if (mShard.Contains("tags"))
                {
                    foreach (var tag in mShard.GetElement("tags").Value.AsBsonArray)
                    {
                        //严格意义上说，不应该在同一个路由里面出现两个同名的标签。
                        if (!TagSet.ContainsKey(tag.ToString()))
                        {
                            TagSet.Add(tag.ToString(), mShard.GetElement(ConstMgr.KEY_ID).Value.ToString());
                            cmbTagList.Items.Add(mShard.GetElement(ConstMgr.KEY_ID).Value + "." + tag);
                        }
                    }
                }
            }
        }

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
            var strHost = String.Empty;
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
            var lstAddress = new List<String>();
            foreach (String item in lstHost.Items)
            {
                lstAddress.Add(item.Trim());
            }
            var Resultlst = new List<CommandResult>();
            CommandResult Result;
            if (chkAdvance.Checked)
            {
                Result = CommandHelper.AddSharding(_prmSvr, txtReplsetName.Text, lstAddress, txtName.Text,
                    NumMaxSize.Value);
            }
            else
            {
                Result = CommandHelper.AddSharding(_prmSvr, txtReplsetName.Text, lstAddress, String.Empty, 0);
            }
            Resultlst.Add(Result);
            MyMessageBox.ShowMessage("Add Sharding", "Result:" + (Result.Ok ? "OK" : "Fail"),
                Utility.ConvertCommandResultlstToString(Resultlst));
            lstSharding.Items.Clear();
            foreach (var lst in OperationHelper.GetShardInfo(_prmSvr, "_id"))
            {
                lstSharding.Items.Add(lst.Value);
            }
            lstHost.Items.Clear();
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
                var mongoDB = _prmSvr.GetDatabase(cmbDataBase.Text);
                cmbCollection.Items.Clear();
                cmbCollection.Text = String.Empty;
                foreach (var item in mongoDB.GetCollectionNames())
                {
                    cmbCollection.Items.Add(item);
                }
                cmbIndexList.Items.Clear();
                lstExistShardTag.Items.Clear();
            }
            catch (Exception ex)
            {
                Common.Utility.ExceptionDeal(ex);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbShardKeyDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var mongoDB = _prmSvr.GetDatabase(cmbShardKeyDB.Text);
                cmbShardKeyCol.Items.Clear();
                cmbShardKeyCol.Text = String.Empty;
                foreach (var item in mongoDB.GetCollectionNames())
                {
                    cmbShardKeyCol.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Common.Utility.ExceptionDeal(ex);
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
                var mongoDB = _prmSvr.GetDatabase(cmbDataBase.Text);
                cmbIndexList.Items.Clear();
                cmbIndexList.Text = String.Empty;
                //Sharding Must Index
                foreach (var Indexitem in mongoDB.GetCollection(cmbCollection.Text).GetIndexes())
                {
                    cmbIndexList.Items.Add(Indexitem.Name);
                }
                cmbIndexList.Text = cmbIndexList.Items[0].ToString();
                //Tag和数据集绑定，从系统数据集tags里面读取tag的信息
                var mongoDBConfig = _prmSvr.GetDatabase(ConstMgr.DATABASE_NAME_CONFIG);
                MongoCollection mongoCol = mongoDBConfig.GetCollection("tags");
                lstExistShardTag.Items.Clear();
                lstExistShardTag.Columns.Add("Tag");
                lstExistShardTag.Columns.Add("NameSpace");
                lstExistShardTag.Columns.Add("Min");
                lstExistShardTag.Columns.Add("Max");
                foreach (var tags in mongoCol.FindAllAs<BsonDocument>())
                {
                    if (tags.GetElement("ns").Value.ToString() != BsonUndefined.Value.ToString())
                    {
                        if (tags.GetElement("ns").Value.ToString() == cmbDataBase.Text + "." + cmbCollection.Text)
                        {
                            var ListItem =
                                new ListViewItem(TagSet[tags.GetElement("tag").Value.ToString()] + "." +
                                                 tags.GetElement("tag").Value);
                            ListItem.SubItems.Add(tags.GetElement("ns").Value.ToString());
                            ListItem.SubItems.Add(tags.GetElement("min").Value.ToString());
                            ListItem.SubItems.Add(tags.GetElement("max").Value.ToString());
                            lstExistShardTag.Items.Add(ListItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Utility.ExceptionDeal(ex);
            }
        }

        /// <summary>
        ///     分片配置(数据库)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEnableSharding_Click(object sender, EventArgs e)
        {
            var Resultlst = new List<CommandResult> {CommandHelper.EnableSharding(_prmSvr, cmbDataBase.Text)};
            MyMessageBox.ShowMessage("EnableSharding", "Result",
                Utility.ConvertCommandResultlstToString(Resultlst));
        }

        /// <summary>
        ///     分片配置(数据集)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEnableCollectionSharding_Click(object sender, EventArgs e)
        {
            var Resultlst = new List<CommandResult>();
            var Result =
                _prmSvr.GetDatabase(cmbDataBase.Text).GetCollection(cmbCollection.Text).GetIndexes();
            BsonDocument IndexDoc = Result[cmbIndexList.SelectedIndex].Key;
            Resultlst.Add(CommandHelper.ShardCollection(_prmSvr, cmbDataBase.Text + "." + cmbCollection.Text, IndexDoc));
            MyMessageBox.ShowMessage("EnableSharding", "Result",
                Utility.ConvertCommandResultlstToString(Resultlst));
        }

        /// <summary>
        ///     移除Sharding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemoveSharding_Click(object sender, EventArgs e)
        {
            foreach (String item in lstSharding.SelectedItems)
            {
                var Resultlst = new List<CommandResult> {CommandHelper.RemoveSharding(_prmSvr, item)};
                MyMessageBox.ShowMessage("Remove Sharding", "Result",
                    Utility.ConvertCommandResultlstToString(Resultlst));
            }
            lstSharding.Items.Clear();
            foreach (var lst in OperationHelper.GetShardInfo(_prmSvr, "_id"))
            {
                lstSharding.Items.Add(lst.Value);
            }
        }

        /// <summary>
        ///     为Sharding增加Tag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddShardTag_Click(object sender, EventArgs e)
        {
            var Resultlst = new List<CommandResult>
            {
                CommandHelper.AddShardTag(_prmSvr, txtShardName.Text, txtTagShard.Text)
            };
            MyMessageBox.ShowMessage("Add Shard Tag", "Result", Utility.ConvertCommandResultlstToString(Resultlst));
        }

        /// <summary>
        ///     Add Tag Range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdaddTagRange_Click(object sender, EventArgs e)
        {
            var Resultlst = new List<CommandResult>
            {
                CommandHelper.AddTagRange(_prmSvr, cmbShardKeyDB.Text + "." + cmbShardKeyCol.Text,
                    ctlBsonValueShardKeyFrom.getValue(),
                    ctlBsonValueShardKeyTo.getValue(), cmbTagList.Text.Split(".".ToCharArray())[1])
            };
            MyMessageBox.ShowMessage("Add Shard Tag", "Result", Utility.ConvertCommandResultlstToString(Resultlst));
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
    }
}