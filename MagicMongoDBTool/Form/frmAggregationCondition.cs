using MongoDB.Bson;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmAggregationCondition : Form
    {
        public BsonDocument Aggregation = new BsonDocument();
        public frmAggregationCondition()
        {
            InitializeComponent();
            txtLimit.Enabled = chkLimit.Checked;
            txtSkip.Enabled = chkSkip.Checked;
            txtLimit.KeyPress +=  MongoDBHelper.NumberTextInt_KeyPress;
            txtSkip.KeyPress += MongoDBHelper.NumberTextInt_KeyPress;

            chkSkip.CheckedChanged += (x, y) =>
            {
                txtSkip.Enabled = chkSkip.Checked;
            };
            chkLimit.CheckedChanged += (x, y) =>
            {
                txtLimit.Enabled = chkLimit.Checked;
            };
        }

        private void frmAggregationCondition_Load(object sender, System.EventArgs e)
        {
            QueryFieldPicker.InitByCurrentCollection(false);
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (chkSkip.Checked && int.Parse(txtSkip.Text) > 0)
            {
                Aggregation.Add(new BsonElement("$skip", int.Parse(txtSkip.Text)));
            }
            if (chkLimit.Checked && int.Parse(txtLimit.Text) > 0)
            {
                Aggregation.Add(new BsonElement("$limit", int.Parse(txtLimit.Text)));
            }
            Aggregation.Add(QueryFieldPicker.GetAggregation());
            this.Close();
        }
    }
}
