using System;
using System.Windows.Forms;
using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoGUICtl.ClientTree;
using MongoUtility.Core;
using ResourceLib.Method;

namespace FunctionForm.Aggregation
{
    public partial class FrmMapReduce : Form
    {
        /// <summary>
        ///     初始化
        /// </summary>
        public FrmMapReduce()
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
            GuiConfig.Translateform(this);
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
            try
            {
                var mMapReduceResult = RuntimeMongoDbContext.GetCurrentCollection().MapReduce(args);
                UiHelper.FillDataToTreeView("MapReduce Result", trvResult, mMapReduceResult.Response);
                trvResult.DatatreeView.BeginUpdate();
                trvResult.DatatreeView.ExpandAll();
                trvResult.DatatreeView.EndUpdate();
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
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