using System;
using MongoDB.Driver;
using MagicMongoDBTool.Module;
using MongoDB.Bson;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using QLFUI;

namespace MagicMongoDBTool
{
    public partial class frmGroup : QLFUI.QLFForm
    {
        public frmGroup()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            MongoCollection mongoCol = SystemManager.GetCurrentCollection();
            IMongoQuery query = MongoDBHelper.GetQuery(SystemManager.CurrDataFilter.QueryConditionList);
            GroupByDocument groupdoc = new GroupByDocument();
            foreach (CheckBox item in panColumn.Controls)
            {
                if (item.Checked)
                {
                    groupdoc.Add(item.Name, true);
                }
            }
            BsonDocument Initial = new BsonDocument();
            for (int i = 0; i < _conditionCount; i++)
            {
                ctlAddBsonEl ctl = (ctlAddBsonEl)Controls.Find("BsonEl" + (i + 1).ToString(), true)[0];
                if (ctl.IsSetted)
                {
                    Initial.Add(ctl.Element);
                }
            }

            BsonJavaScript reduce = new BsonJavaScript(txtReduceJs.Text);
            BsonJavaScript finalize = new BsonJavaScript(txtfinalizeJs.Text);
            List<BsonDocument> resultlst = new List<BsonDocument>();
            try
            {
                var Result = mongoCol.Group(query, groupdoc, Initial, reduce, finalize);

                foreach (var item in Result)
                {
                    resultlst.Add(item);
                };
                MongoDBHelper.FillDataToTextBox(this.txtResult, resultlst);
                this.txtResult.Select(0, 0);
                tabGroup.SelectedIndex = 4;
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowMessage("异常", "发生异常", ex.ToString(), true);
            }
        }
        /// <summary>
        /// 条件输入器数量
        /// </summary>
        private byte _conditionCount = 1;
        /// <summary>
        /// 条件输入器位置
        /// </summary>
        private Point _conditionPos = new Point(50, 20);

        private void frmGroup_Load(object sender, EventArgs e)
        {
            this.cmbForfinalize.SelectedIndexChanged += new EventHandler(
                 (x, y) => { this.txtfinalizeJs.Text = MongoDBHelper.LoadJavascript(cmbForfinalize.Text); }
            );
            cmbForReduce.SelectedIndexChanged += new EventHandler(
                (x, y) => { txtReduceJs.Text = MongoDBHelper.LoadJavascript(cmbForReduce.Text); }
            );
            foreach (var item in SystemManager.GetJsNameList())
            {
                cmbForfinalize.Items.Add(item);
                cmbForReduce.Items.Add(item);
            }

            MongoCollection mongoCol = SystemManager.GetCurrentCollection();
            List<String> MongoColumn = MongoDBHelper.GetCollectionSchame(mongoCol);
            Point _conditionPos = new Point(50, 20);
            foreach (String item in MongoColumn)
            {
                //动态加载控件
                CheckBox ctrItem = new CheckBox();
                ctrItem.Name = item;
                ctrItem.Location = _conditionPos;
                ctrItem.Text = item;
                this.panColumn.Controls.Add(ctrItem);
                //纵向位置的累加
                _conditionPos.Y += ctrItem.Height;
            }
            _conditionPos = new Point(50, 20);
            ctlAddBsonEl firstAddBsonElCtl = new ctlAddBsonEl();
            firstAddBsonElCtl.Location = _conditionPos;
            firstAddBsonElCtl.Name = "BsonEl" + _conditionCount.ToString();
            BsonElement el = new BsonElement("count", new BsonInt32(0));
            firstAddBsonElCtl.Element = el;
            panBsonEl.Controls.Add(firstAddBsonElCtl);

        }
        /// <summary>
        /// 保存Reduce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveReduceJs_Click(object sender, EventArgs e)
        {
            if (this.txtReduceJs.Text != string.Empty)
            {
                String strJsName = Microsoft.VisualBasic.Interaction.InputBox("请输入Javascript名称：", "保存Javascript");
                MongoDBHelper.SaveJavascript(strJsName, txtReduceJs.Text);
            }
        }
        /// <summary>
        /// 保存finalize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdForSavefinalize_Click(object sender, EventArgs e)
        {
            if (this.txtfinalizeJs.Text != string.Empty)
            {
                String strJsName = Microsoft.VisualBasic.Interaction.InputBox("请输入Javascript名称：", "保存Javascript");
                MongoDBHelper.SaveJavascript(strJsName, txtfinalizeJs.Text);
            }
        }

        /// <summary>
        /// 添加初始化字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddFld_Click(object sender, EventArgs e)
        {
            _conditionCount++;
            ctlAddBsonEl newCondition = new ctlAddBsonEl();
            _conditionPos.Y += newCondition.Height;
            newCondition.Location = _conditionPos;
            newCondition.Name = "BsonEl" + _conditionCount.ToString();
            panBsonEl.Controls.Add(newCondition);
        }
    }
}
