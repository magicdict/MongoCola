using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MagicMongoDBTool.Module;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace MagicMongoDBTool
{
    public partial class frmDistinct : QLFUI.QLFForm
    {
        public frmDistinct()
        {
            InitializeComponent();
        }
        private void frmSelectKey_Load(object sender, EventArgs e)
        {
            MongoCollection mongoCol = SystemManager.GetCurrentCollection();
            List<String> MongoColumn = MongoDBHelper.GetCollectionSchame(mongoCol);
            Point _conditionPos = new Point(50, 20);
            foreach (String item in MongoColumn)
            {
                //动态加载控件
                RadioButton ctrItem = new RadioButton();
                ctrItem.Name = item;
                ctrItem.Location = _conditionPos;
                ctrItem.Text = item;
                this.panColumn.Controls.Add(ctrItem);
                //纵向位置的累加
                _conditionPos.Y += ctrItem.Height;
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            String strKey = String.Empty;

            foreach (RadioButton item in panColumn.Controls)
            {
                if (item.Checked) {
                    strKey = item.Name;
                }
            }
            if (strKey == String.Empty) {
                SystemManager.ShowMessage("Distinct", "请选择字段");
                return;
            }
            if (SystemManager.CurrDataFilter.QueryConditionList.Count == 0)
            {
                SystemManager.ShowMessage("Distinct", "Distinct:" + SystemManager.GetCurrentCollection().Distinct(strKey).ToString());
            }
            else
            {
                MongoDB.Driver.IMongoQuery mQuery = MongoDBHelper.GetQuery(SystemManager.CurrDataFilter.QueryConditionList);
                SystemManager.ShowMessage("Distinct",
                "Distinct:" + SystemManager.GetCurrentCollection().Distinct(strKey, mQuery).ToString(),
                mQuery.ToString(), true);
            }
        }
    }
}
