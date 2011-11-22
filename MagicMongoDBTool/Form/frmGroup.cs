using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;
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
        /// Group条件
        /// </summary>
        public List<DataFilter.QueryConditionInputItem> GroupConditionList = new List<DataFilter.QueryConditionInputItem>();
        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            MongoCollection mongoCol = SystemManager.GetCurrentCollection();
            IMongoQuery query = MongoDBHelper.GetQuery(GroupConditionList);
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
                //防止错误的条件造成的海量数据
                int Count = 0;
                foreach (var item in Result)
                {
                    if (Count == 1000)
                    {
                        break;
                    }
                    resultlst.Add(item);
                    Count++;
                };
                MongoDBHelper.FillDataToTextBox(this.txtResult, resultlst);
                if (Count == 1001)
                {
                    this.txtResult.Text = "显示前1000条记录" + "\r\n" + this.txtResult.Text;
                }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdQuery_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataFilter NewDataFilter = DataFilter.LoadFilter(openFile.FileName);
                GroupConditionList = NewDataFilter.QueryConditionList;
            }
        }
    }
}
