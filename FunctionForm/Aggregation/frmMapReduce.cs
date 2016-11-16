using Common;
using FunctionForm.Operation;
using FunctionForm.Status;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoGUICtl.ClientTree;
using MongoUtility.Core;
using ResourceLib.Method;
using System;
using System.Windows.Forms;

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
            UIAssistant.FillComberWithEnum(cmbOutputMode, typeof(MapReduceOutputMode));
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
            if (!string.IsNullOrEmpty(ctlFinalizeFunction.Context))
            {
                args.FinalizeFunction = new BsonJavaScript(ctlFinalizeFunction.Context);
            }
            args.OutputMode = (MapReduceOutputMode)cmbOutputMode.SelectedIndex;
            if (!string.IsNullOrEmpty(txtOutputCollectionName.Text)) args.OutputCollectionName = txtOutputCollectionName.Text;
            if (NumLimit.Value != 0) args.Limit = (long)NumLimit.Value;
            args.JsMode = chkjsMode.Checked;
            args.Verbose = chkverbose.Checked;
            args.BypassDocumentValidation = chkbypassDocumentValidation.Checked;
            if (QueryDoc != null) args.Query = new QueryDocument(QueryDoc);
            try
            {
                var mMapReduceResult = RuntimeMongoDbContext.GetCurrentCollection().MapReduce(args);
                var frm = new frmDataView();
                frm.ShowDocument = mMapReduceResult.Response;
                frm.Title = "MapReduce Result";
                UIAssistant.OpenModalForm(frm, true, true);
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
        }

        /// <summary>
        ///     QueryDoc
        /// </summary>
        BsonDocument QueryDoc = null;

        /// <summary>
        ///     CreateQuery
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateQueryDocument_Click(object sender, EventArgs e)
        {
            var frmInsertDoc = new frmCreateDocument();
            UIAssistant.OpenModalForm(frmInsertDoc, false, true);
            QueryDoc = frmInsertDoc.mBsonDocument;
            UiHelper.FillDataToTreeView("Query", QueryTreeView, frmInsertDoc.mBsonDocument);
        }

        /// <summary>
        ///     Clear Query
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClearQuery_Click(object sender, EventArgs e)
        {
            QueryDoc = null;
            QueryTreeView.Clear();
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