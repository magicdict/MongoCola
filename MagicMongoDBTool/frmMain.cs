using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;

namespace MagicMongoDBTool
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.trvsrvlst.NodeMouseClick += new TreeNodeMouseClickEventHandler(trvsrvlst_NodeMouseClick);
        }
        void trvsrvlst_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            lstData.Clear();
            if (e.Node.Tag != null)
            {
                switch (e.Node.Tag.ToString().Split(":".ToCharArray())[0])
                {
                    case MongoDBHelpler.DocumentTag:
                        //BsonDocument
                        MongoDBHelpler.FillDataToListView(e.Node.Tag.ToString(), lstData);
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中数据:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelpler.GridFileSystemTag:
                        //BsonDocument
                        MongoDBHelpler.FillDataToListView(e.Node.Tag.ToString(), lstData);
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "文件系统:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelpler.UserListTag:
                        statusStripMain.Items[0].Text = "用户列表:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelpler.ServiceTag:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中服务器:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelpler.DataBaseTag:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中数据库:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelpler.CollectionTag:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中数据集:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    default:
                        SystemManager.SelectObjectTag = "";
                        break;
                }
            }
        }
        /// <summary>
        /// 添加数据库连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConnect mfrm = new frmConnect();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
            MongoDBHelpler.FillMongodbToTreeView(trvsrvlst);
            lstData.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.FillMongodbToTreeView(trvsrvlst);
            lstData.Clear();
        }
        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOption mfrm = new frmOption();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }
        /// <summary>
        /// DOS控制台
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DosCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDosCommand mfrm = new frmDosCommand();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }

        private void DataBaseStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataBaseStatus mfrm = new frmDataBaseStatus();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }

        private void SrvStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServiceStatus mfrm = new frmServiceStatus();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }
    }
}
