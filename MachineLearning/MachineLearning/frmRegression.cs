using Accord.Statistics.Models.Regression.Linear;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.ToolKit;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace MachineLearning
{
    public partial class frmRegression : Form
    {
        public frmRegression()
        {
            InitializeComponent();
        }

        public MongoCollection mongoCol;

        private void frmRegression_Load(object sender, EventArgs e)
        {
            var mongoColumn = MongoHelper.GetCollectionSchame(mongoCol);
            //加载所有的字段
            foreach (var field in mongoColumn)
            {
                cmbInputField.Items.Add(field);
                cmbOutputField.Items.Add(field);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //将Input放在X轴，OutPut放在Y轴
            var GraphPane = zedGraph.GraphPane;
            GraphPane.CurveList.Clear();
            GraphPane.XAxis.Title.Text = cmbInputField.Text;
            GraphPane.YAxis.Title.Text = cmbOutputField.Text;
            //获得Input，Output列表
            double[] inliersX = new double[mongoCol.Count()];
            double[] inliersY = new double[mongoCol.Count()];
            int Cnt = 0;
            foreach (var item in mongoCol.FindAllAs<BsonDocument>())
            {
                inliersX[Cnt] = item[cmbInputField.Text].AsInt32;
                inliersY[Cnt] = item[cmbOutputField.Text].AsInt32;
                Cnt++;
            }
            var myCurve = GraphPane.AddCurve("Point", new PointPairList(inliersX, inliersY), Color.Blue, SymbolType.Default);
            myCurve.Line.IsVisible = false;
            myCurve.Symbol.Fill = new Fill(Color.Blue);
            //线性回归
            // Create a new simple linear regression
            var regression = new SimpleLinearRegression();
            // Compute the linear regression
            regression.Regress(inliersX, inliersY);

            double[] InputX = new double[2];
            double[] OutputY = new double[2];

            InputX[0] = 0;
            InputX[1] = inliersX.Max();

            OutputY[0] = regression.Compute(0);
            OutputY[1] = regression.Compute(inliersX.Max());
            myCurve = GraphPane.AddCurve("Regression:" + regression.ToString(), new PointPairList(InputX, OutputY), Color.Blue, SymbolType.Default);
            myCurve.Line.IsVisible = true;
            myCurve.Line.Color = Color.Red;

            //更新坐标轴和图表
            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }
    }
}
