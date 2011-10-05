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
        }
        /// <summary>
        /// 节点被选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvsrvlst_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvsrvlst.SelectedNode.Tag != null) {
                MongoDBHelpler.FillDataToListView(trvsrvlst.SelectedNode.Tag.ToString(), lstData);
            }
        }
        /// <summary>
        /// 添加链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConnect mfrm = new frmConnect();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
            MongoDBHelpler.FillDBToTreeView(trvsrvlst);
            lstData.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.FillDBToTreeView(trvsrvlst);
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
    }
}
