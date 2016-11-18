using MongoDB.Bson;
using MongoGUICtl.ClientTree;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FunctionForm.Status
{
    public partial class frmDataView : Form
    {

        public frmDataView()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     待展示数据
        /// </summary>
        public List<BsonDocument> ShowData = new List<BsonDocument>();

        /// <summary>
        ///     待展示数据
        /// </summary>
        public BsonDocument ShowDocument
        {
            set
            {
                ShowData.Add(value);
            }
        }

        /// <summary>
        ///     标题
        /// </summary>
        public string Title = string.Empty;

        /// <summary>
        ///     Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDataView_Load(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(Title))
            {
                Text = Title;
            }
            UiHelper.FillDataToTreeView(Title, trvStatus, ShowData, 0);
            trvStatus.DatatreeView.Nodes[0].ExpandAll();
        }
    }
}
