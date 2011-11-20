using System;
using System.Collections.Generic;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
using MongoDB.Bson;
using QLFUI;

namespace MagicMongoDBTool
{
    public partial class frmShardingConfig : QLFUI.QLFForm
    {
        /// <summary>
        /// 初期化
        /// </summary>
        public frmShardingConfig()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Mongo服务器
        /// </summary>
        private MongoServer _prmSvr;
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddSharding_Load(object sender, EventArgs e)
        {
            _prmSvr = SystemManager.GetCurrentService();

            MongoDatabase mongoDB = _prmSvr.GetDatabase("config");
            MongoCollection mongoCol = mongoDB.GetCollection("databases");
            foreach (var item in mongoCol.FindAllAs<BsonDocument>())
            {
                if (item.GetValue("_id") != "admin")
                {
                    cmbDataBase.Items.Add(item.GetValue("_id"));
                };
            }
            cmbReplsetName.SelectedIndexChanged += new EventHandler(
                (x, y) => { RefreshSrv(); }
                );
            string strPrmKey = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            foreach (var item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
            {
                if (item.ReplSetName != null)
                {
                    if (!cmbReplsetName.Items.Contains(item.ReplSetName))
                    {
                        cmbReplsetName.Items.Add(item.ReplSetName);
                    }
                }
            }
        }
        /// <summary>
        /// 刷新服务器
        /// </summary>
        private void RefreshSrv()
        {
            lstShard.Items.Clear();
            foreach (var item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
            {
                if (item.ReplSetName != null)
                {
                    if (item.ReplSetName == cmbReplsetName.Text)
                    {
                        lstShard.Items.Add(item.ConnectionName);
                    }
                }
            }
        }
        /// <summary>
        /// 增加分片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddSharding_Click(object sender, EventArgs e)
        {
            List<string> srvKeys = new List<string>();
            if (lstShard.SelectedItems.Count > 0)
            {
                foreach (string item in lstShard.SelectedItems)
                {
                    srvKeys.Add(item);
                }
            }
            List<CommandResult> Resultlst = new List<CommandResult>();
            Resultlst.Add(MongoDBHelper.AddSharding(_prmSvr, cmbReplsetName.Text, srvKeys));
        }
        /// <summary>
        /// 数据库切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MongoDatabase mongoDB = _prmSvr.GetDatabase(cmbDataBase.Text);
                cmbCollection.Items.Clear();
                cmbCollection.Text = String.Empty;
                foreach (var item in mongoDB.GetCollectionNames())
                {
                    cmbCollection.Items.Add(item);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 数据集变换时，实时更新主键列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MongoDatabase mongoDB = _prmSvr.GetDatabase(cmbDataBase.Text);
                cmbKeyList.Items.Clear();
                cmbKeyList.Text = string.Empty;
                foreach (var Indexitem in mongoDB.GetCollection(cmbCollection.Text).GetIndexes())
                {
                    cmbKeyList.Items.Add(Indexitem.Name);
                }
                cmbKeyList.Text = cmbKeyList.Items[0].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 分片配置(数据库)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEnableSharding_Click(object sender, EventArgs e)
        {
            List<CommandResult> Resultlst = new List<CommandResult>();
            Resultlst.Add(MongoDBHelper.EnableSharding(_prmSvr, cmbDataBase.Text));
            MyMessageBox.ShowMessage("添加分片", "执行结果", MongoDBHelper.ConvertCommandResultlstToString(Resultlst));
        }
        /// <summary>
        /// 分片配置(数据集)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCollectionSharding_Click(object sender, EventArgs e)
        {
            List<CommandResult> Resultlst = new List<CommandResult>();
            Resultlst.Add(MongoDBHelper.ShardCollection(_prmSvr, cmbDataBase.Text + "." + cmbCollection.Text, cmbKeyList.SelectedItem.ToBsonDocument()));
            MyMessageBox.ShowMessage("添加分片", "执行结果", MongoDBHelper.ConvertCommandResultlstToString(Resultlst));
        }
    }
}
