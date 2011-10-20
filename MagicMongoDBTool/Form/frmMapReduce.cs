using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class frmMapReduce : frmBase
    {
        public frmMapReduce()
        {
            InitializeComponent();
        }
        MongoCollection mongocol = SystemManager.getCurrentCollection();
        private void frmMapReduce_Load(object sender, EventArgs e)
        {
//            //Start Test
//            txtMapJs.Text = @"function Map(){
//                                emit(this.Age,1);
//                            }";
//            txtReduceJs.Text = @"function Reduce(key, arr_values) {
//                        var total = 0;
//                        for(var i in arr_values){
//                            temp = arr_values[i];
//                            total += temp;
//                        }
//                        return total;
//                }";
//            //End Test
            cmbForMap.SelectedIndexChanged+=new EventHandler(
                (x, y) => { txtMapJs.Text = MongoDBHelpler.LoadJavascript(cmbForMap.Text); }
            );
            cmbForReduce.SelectedIndexChanged += new EventHandler(
                (x, y) => { txtReduceJs.Text = MongoDBHelpler.LoadJavascript(cmbForReduce.Text); }
            );

            foreach (var item in SystemManager.getJsNameList())
            {
                cmbForMap.Items.Add(item);
                cmbForReduce.Items.Add(item);
            }
        }

        private void cmdRun_Click(object sender, EventArgs e)
        {
            BsonJavaScript map = new BsonJavaScript(txtMapJs.Text);
            BsonJavaScript reduce = new BsonJavaScript(txtReduceJs.Text);
            //TODO:这里可能会超时，失去响应
            //需要设置SocketTimeOut
            MapReduceResult rtn = mongocol.MapReduce(map, reduce);
            
            List<BsonDocument> Result = new List<BsonDocument>();
            Result.Add(rtn.Response);
            MongoDBHelpler.FillDataToTreeView("MapReduce Result", trvResult, Result);
            trvResult.ExpandAll();
        }
        private void cmdSaveMapJs_Click(object sender, EventArgs e)
        {
            if(txtMapJs.Text != string.Empty){
                String strJsName = Microsoft.VisualBasic.Interaction.InputBox("请输入Javascript名称：", "保存Javascript");
                MongoDBHelpler.SaveJavascript(strJsName, txtMapJs.Text);
            }
        }
        private void cmdSaveReduceJs_Click(object sender, EventArgs e)
        {
            if (this.txtReduceJs.Text != string.Empty)
            {
                String strJsName = Microsoft.VisualBasic.Interaction.InputBox("请输入Javascript名称：", "保存Javascript");
                MongoDBHelpler.SaveJavascript(strJsName, txtReduceJs.Text);
            }
        }
    }
}
