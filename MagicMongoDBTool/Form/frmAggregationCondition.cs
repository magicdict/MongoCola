using MongoDB.Bson;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmAggregationCondition : Form
    {
        public BsonArray Aggregation = new BsonArray();
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
            GroupFieldPicker.InitByCurrentCollection(false);
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            //这里必须要考虑一下顺序的问题?
            Aggregation.Add(QueryFieldPicker.GetAggregation());
            if (chkSkip.Checked && int.Parse(txtSkip.Text) > 0)
            {
                Aggregation.Add(new BsonDocument("$skip", int.Parse(txtSkip.Text)));
            }
            if (chkLimit.Checked && int.Parse(txtLimit.Text) > 0)
            {
                Aggregation.Add(new BsonDocument("$limit", int.Parse(txtLimit.Text)));
            }


            this.Close();
        }
    }
}
