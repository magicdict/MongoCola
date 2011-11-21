using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MagicMongoDBTool.Module;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QLFUI;
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
        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            String strKey = String.Empty;

            foreach (RadioButton item in panColumn.Controls)
            {
                if (item.Checked)
                {
                    strKey = item.Name;
                }
            }
            if (strKey == String.Empty)
            {
                MyMessageBox.ShowMessage("Distinct", "请选择字段");
                return;
            }
            List<BsonValue> result = new List<BsonValue>();
            if (SystemManager.CurrDataFilter.QueryConditionList.Count == 0)
            {
                foreach (BsonValue item in SystemManager.GetCurrentCollection().Distinct(strKey))
                {
                    result.Add(item);
                }
            }
            else
            {
                MongoDB.Driver.IMongoQuery mQuery = MongoDBHelper.GetQuery(SystemManager.CurrDataFilter.QueryConditionList);
                foreach (BsonValue item in SystemManager.GetCurrentCollection().Distinct(strKey, mQuery))
                {
                    result.Add(item);
                }
            }

            String strResult = String.Empty;
            foreach (BsonValue item in result)
            {
                strResult += MongoDBHelper.GetBsonElementText(strKey, item, 0);
            }
            MyMessageBox.ShowMessage("Distinct", "Distinct:" + strKey, strResult, true);

        }
    }
}
