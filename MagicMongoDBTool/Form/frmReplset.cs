using System;
using System.Collections.Generic;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
namespace MagicMongoDBTool
{
    public partial class frmReplset : QLFUI.QLFForm
    {
        public frmReplset()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Master服务器
        /// </summary>
        private MongoServer _prmSvr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmReplset_Load(object sender, EventArgs e)
        {
            _prmSvr = SystemManager.GetCurrentService();
            ConfigHelper.MongoConnectionConfig prmKeyPro = SystemManager.GetSelectedSvrProByName();
            lblPrmInfo.Text = "主机为:" + prmKeyPro.HostName + "  副本名：" + prmKeyPro.ReplSetName;
            foreach (var item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
            {
                if ((prmKeyPro.HostName != item.HostName) & (prmKeyPro.ReplSetName == item.ReplSetName))
                {
                    lstShard.Items.Add(item.HostName);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdInitReplset_Click(object sender, EventArgs e)
        {
            List<String> svrKeys = new List<string>();
            if (lstShard.SelectedItems.Count > 0)
            {
                foreach (String item in lstShard.SelectedItems)
                {
                    svrKeys.Add(item);
                }
            }
            //初始化副本，将多个服务器组合成一个副本组
            MongoDBHelpler.InitReplicaSet(_prmSvr, SystemManager.GetSelectedSvrProByName().ReplSetName, svrKeys);
        }
    }
}
