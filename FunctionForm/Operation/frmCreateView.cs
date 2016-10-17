using Common;
using FunctionForm.Aggregation;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoGUICtl.ClientTree;
using MongoUtility.Core;
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
            cmbViewOn.Items.Clear();
            var c = RuntimeMongoDbContext.GetCurrentIMongoDataBase().ListCollections();
            foreach (var item in c.ToList())
            {
                cmbViewOn.Items.Add(item.GetElement("name").Value.ToString());
            }
        }


        /// <summary>
        ///     确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            var pipeline = new BsonDocumentStagePipelineDefinition<BsonDocument, BsonDocument>(stages.Values.Select(x => (BsonDocument)x));
            RuntimeMongoDbContext.GetCurrentIMongoDataBase().CreateView(txtViewName.Text, cmbViewOn.Text, pipeline);
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
            RuntimeMongoDbContext.SetCurrentCollection(cmbViewOn.Text);
            var frmAggregationBuilder = new FrmStageBuilder();
            Utility.OpenForm(frmAggregationBuilder, false, true);
            foreach (var item in frmAggregationBuilder.Aggregation)
            {
                stages.Add(item);
            }
            UiHelper.FillDataToTreeView("stages", trvNewStage, stages.Values.ToList().Select(x => (BsonDocument)x).ToList(), 0);
        }
    }
}
