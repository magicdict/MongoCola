using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Driver;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class frmQuery : frmBase
    {
        MongoCollection mongocol = SystemManager.getCurrentCollection();
        public frmQuery()
        {
            InitializeComponent();
        }
        Dictionary<String, MongoDBHelpler.QueryFieldItem> ColDic = new Dictionary<string, MongoDBHelpler.QueryFieldItem>();
        private void frmQuery_Load(object sender, EventArgs e)
        {
            foreach (var item in MongoDBHelpler.columnList)
            {
                MongoDBHelpler.QueryFieldItem mQueryFieldList = new MongoDBHelpler.QueryFieldItem();
                mQueryFieldList.ColName = item;
                mQueryFieldList.IsShow = true;
                mQueryFieldList.IsSort = false;
                mQueryFieldList.QueryList = new List<MongoDBHelpler.QueryCompareItem>();
                ColDic.Add(item, mQueryFieldList);
            }
            RefreshList();
        }

        private void lstColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstColumn.SelectedItems.Count == 1)
            {
                for (int t = 0; t < 5; t++)
                {
                    ((ctlQueryCondition)Controls.Find("ctlQueryCondition" + (t + 1).ToString(), true)[0]).clear();
                }
                lblSelectColName.Text = ColDic[lstColumn.SelectedItems[0].Text].ColName;
                chkIsShow.Checked = ColDic[lstColumn.SelectedItems[0].Text].IsShow;
                int i = 0;
                foreach (var item in ColDic[lstColumn.SelectedItems[0].Text].QueryList)
                {
                    ctlQueryCondition t = (ctlQueryCondition)Controls.Find("ctlQueryCondition" + (i + 1).ToString(), true)[0];
                    t.CompareItem = item;
                    i++;
                }
            }
        }
        private void cmdSaveItem_Click(object sender, EventArgs e)
        {
            if (lstColumn.SelectedItems.Count == 1)
            {
                ColDic[lstColumn.SelectedItems[0].Text].QueryList.Clear();
                for (int i = 0; i < 5; i++)
                {
                    ctlQueryCondition t = (ctlQueryCondition)Controls.Find("ctlQueryCondition" + (i + 1).ToString(), true)[0];
                    if (t.IsSeted)
                    {
                        ColDic[lstColumn.SelectedItems[0].Text].QueryList.Add(t.CompareItem);
                    }
                }
                RefreshList();
            }
        }
        private void RefreshList()
        {
            lstColumn.Items.Clear();
            foreach (var item in MongoDBHelpler.columnList)
            {
                ListViewItem t = new ListViewItem(item);
                t.SubItems.Add(ColDic[item].IsShow ? "是" : "否");
                t.SubItems.Add("默认");
                foreach (var Qitem in ColDic[item].QueryList)
                {
                    t.SubItems.Add(Qitem.comp.ToString() + Qitem.Value.ToString());
                }
                lstColumn.Items.Add(t);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.QueryFieldList.Clear();
            foreach (var item in ColDic.Values)
            {
                MongoDBHelpler.QueryFieldList.Add(item);
            }
            this.Close();
        }
    }
}
