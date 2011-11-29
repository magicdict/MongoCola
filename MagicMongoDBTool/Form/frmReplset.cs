using System;
using System.Collections.Generic;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
using System.Windows.Forms;
using QLFUI;
namespace MagicMongoDBTool
{
    public partial class frmReplset : QLFUI.QLFForm
    {
        public frmReplset()
        {
            InitializeComponent();
        }

        private void frmReplset_Load(object sender, EventArgs e)
        {
            RefreshSvr();
            if (!SystemManager.IsUseDefaultLanguage())
            {
                this.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Replset_Title);
                tabAddSvr.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Replset_AddServer);
                tabRemoveSvr.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Replset_RemoveServer);
                cmdAddSvr.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_Add);
                cmdRemove.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Replset_Remove);
            }
        }
        MongoServer _prmSvr = SystemManager.GetCurrentService();
        /// <summary>
        /// 刷新服务器
        /// </summary>
        private void RefreshSvr()
        {
            //刷新连接信息
            _prmSvr.Reconnect();
            List<String> HostPortList = new List<string>();
            lstServerInReplset.Items.Clear();
            lstServerOutReplset.Items.Clear();
            foreach (MongoServerInstance srv in _prmSvr.Instances)
            {
                lstServerInReplset.Items.Add(SystemManager.ConfigHelperInstance.GetCollectionNameByHost(srv.Address.Host, srv.Address.Port));
                HostPortList.Add(srv.Address.Host + ":" + srv.Address.Port);
            }
            foreach (ConfigHelper.MongoConnectionConfig item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
            {
                if (item.MainReplSetName == _prmSvr.ReplicaSetName)
                {
                    if (!HostPortList.Contains(item.IpAddr + ":" + item.Port))
                    {
                        lstServerOutReplset.Items.Add(item.ConnectionName);
                    }
                }
            }
        }
        /// <summary>
        /// 添加服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddSvr_Click(object sender, EventArgs e)
        {
            List<CommandResult> Resultlst = new List<CommandResult>();
            foreach (String item in lstServerOutReplset.SelectedItems)
            {
                ConfigHelper.MongoConnectionConfig config = SystemManager.ConfigHelperInstance.ConnectionList[item];
                Resultlst.Add(MongoDBHelper.AddToReplsetServer(_prmSvr, config.IpAddr + ":" + config.Port, config.ServerType == ConfigHelper.SvrType.ArbiterSvr));
            }
            MyMessageBox.ShowMessage("添加服务器", "执行结果", MongoDBHelper.ConvertCommandResultlstToString(Resultlst));
            RefreshSvr();
        }
        /// <summary>
        /// 删除服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            List<CommandResult> Resultlst = new List<CommandResult>();
            foreach (String item in lstServerInReplset.SelectedItems)
            {
                ConfigHelper.MongoConnectionConfig config = SystemManager.ConfigHelperInstance.ConnectionList[item];
                Resultlst.Add(MongoDBHelper.RemoveFromReplsetServer(_prmSvr, config.IpAddr + ":" + config.Port));
            }
            MyMessageBox.ShowMessage("删除服务器", "执行结果", MongoDBHelper.ConvertCommandResultlstToString(Resultlst));
            RefreshSvr();
        }
    }
}
