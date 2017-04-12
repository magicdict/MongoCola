using Common;
using FunctionForm.Aggregation;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoGUICtl.ClientTree;
using MongoUtility.Core;
using ResourceLib.Method;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FunctionForm.Operation
{
    public partial class frmCreateView : Form
    {
        public frmCreateView()
        {
            InitializeComponent();
        }

        private void frmCreateView_Load(object sender, EventArgs e)
        {
            GuiConfig.Translateform(this);
            cmbViewOn.Items.Clear();
            var ColList = RuntimeMongoDbContext.GetCurrentIMongoDataBase().ListCollections();
            var viewlist = RuntimeMongoDbContext.GetCurrentDBViewNameList();
            foreach (var item in ColList.ToList())
            {
                var ColName = item.GetElement("name").Value.ToString();
                if (!viewlist.Contains(ColName))
                {
                    cmbViewOn.Items.Add(ColName);
                }
            }
        }

        /// <summary>
        ///     确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                var pipeline = new BsonDocumentStagePipelineDefinition<BsonDocument, BsonDocument>(stages.Values.Select(x => (BsonDocument)x));
                CreateViewOptions<BsonDocument> OptionalDoc = null;
                if (mCollation != null)
                {
                    OptionalDoc = new CreateViewOptions<BsonDocument>()
                    {
                        Collation = mCollation
                    };
                }
                RuntimeMongoDbContext.GetCurrentIMongoDataBase().CreateView(txtViewName.Text, cmbViewOn.Text, pipeline, OptionalDoc);
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
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     聚合数组
        /// </summary>
        private BsonArray stages = new BsonArray();

        /// <summary>
        ///     生成管道
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAggrBuilder_Click(object sender, EventArgs e)
        {
            if (cmbViewOn.SelectedIndex == -1)
            {
                //必须先选中Collection
                return;
            }
            RuntimeMongoDbContext.SetCurrentCollection(cmbViewOn.Text);
            var frmAggregationBuilder = new FrmStageBuilder();
            UIAssistant.OpenModalForm(frmAggregationBuilder, false, true);
            foreach (var item in frmAggregationBuilder.Aggregation)
            {
                stages.Add(item);
            }
            UiHelper.FillDataToTreeView("stages", trvNewStage, stages.Values.ToList().Select(x => (BsonDocument)x).ToList(), 0);
        }

        /// <summary>
        ///     排序规则
        /// </summary>
        Collation mCollation = null;

        private void btnCollation_Click(object sender, EventArgs e)
        {
            var frm = new frmCreateCollation();
            UIAssistant.OpenModalForm(frm, false, true);
            if (frm.mCollation != null)
            {
                mCollation = frm.mCollation;
                UiHelper.FillDataToTreeView("Collation", trvCollation, mCollation.ToBsonDocument());

            }
        }
    }
}
