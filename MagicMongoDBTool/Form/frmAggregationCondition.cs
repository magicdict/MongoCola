using MongoDB.Bson;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmAggregationCondition : Form
    {
        public BsonDocument Aggregation = new BsonDocument();
        public frmAggregationCondition()
        {
            InitializeComponent();
            btnOK.Click += (x, y) => {
                Aggregation = QueryFieldPicker.GetAggregation();
                this.Close();
            };
        }
        private void frmAggregationCondition_Load(object sender, System.EventArgs e)
        {
            QueryFieldPicker.InitByCurrentCollection(false);
        }
    }
}
