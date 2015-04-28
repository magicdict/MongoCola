using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoGUICtl;
using MongoUtility.Core;
using ResourceLib;

namespace MongoCola.Aggregation
{
    public partial class frmMapReduce : Form
    {
        /// <summary>
        ///     初始化
        /// </summary>
        public frmMapReduce()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMapReduce_Load(object sender, EventArgs e)
        {
            if (!GUIConfig.IsUseDefaultLanguage)
            {
                ctlMapFunction.Title =
                    GUIConfig.GetText(TextType.MapReduce_MapFunction);
                ctlReduceFunction.Title =
                    GUIConfig.GetText(TextType.MapReduce_ReduceFunction);
                lblResult.Text = GUIConfig.GetText(TextType.MapReduce_Result);
                cmdRun.Text = GUIConfig.GetText(TextType.MapReduce_Run);
                cmdClose.Text = GUIConfig.GetText(TextType.Common_Close);
            }
            ctlMapFunction.Context =
                @"function Map(){
    emit(this.Age,1);
}";
            ctlReduceFunction.Context =
                @"function Reduce(key, arr_values) {
     var total = 0;
     for(var i in arr_values){
         temp = arr_values[i];
         total += temp;
     }
     return total;
}";
        }

        /// <summary>
        ///     运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRun_Click(object sender, EventArgs e)
        {
            var map = new BsonJavaScript(ctlMapFunction.Context);
            var reduce = new BsonJavaScript(ctlReduceFunction.Context);
            //TODO:这里可能会超时，失去响应
            //需要设置SocketTimeOut
            var args = new MapReduceArgs();
            args.MapFunction = map;
            args.ReduceFunction = reduce;
            var mMapReduceResult = RuntimeMongoDBContext.GetCurrentCollection().MapReduce(args);
            UIHelper.FillDataToTreeView("MapReduce Result", trvResult, mMapReduceResult.Response);
            trvResult.DatatreeView.BeginUpdate();
            trvResult.DatatreeView.ExpandAll();
            trvResult.DatatreeView.EndUpdate();
        }

        /// <summary>
        ///     关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}