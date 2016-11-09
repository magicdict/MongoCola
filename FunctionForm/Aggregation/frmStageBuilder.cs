using System;
using System.Windows.Forms;
using MongoDB.Bson;
using ResourceLib.UI;
using MongoUtility.ToolKit;
using MongoUtility.Core;
using ResourceLib.Method;

namespace FunctionForm.Aggregation
{
    public partial class FrmStageBuilder : Form
    {
        /// <summary>
        ///     聚合数组
        /// </summary>
        public BsonArray Aggregation = new BsonArray();

        public FrmStageBuilder()
        {
            InitializeComponent();
            txtLimit.Enabled = chkLimit.Checked;
            txtSkip.Enabled = chkSkip.Checked;
            txtSample.Enabled = chkSample.Checked;

            txtLimit.KeyPress += NumberTextBox.NumberTextInt_KeyPress;
            txtSkip.KeyPress += NumberTextBox.NumberTextInt_KeyPress;
            txtSample.KeyPress += NumberTextBox.NumberTextInt_KeyPress;

            var columnList = MongoHelper.GetCollectionSchame(RuntimeMongoDbContext.GetCurrentCollection());
            foreach (var fieldname in columnList)
            {
                cmbSortByCount.Items.Add("$" + fieldname);
                cmbUnwind.Items.Add("$" + fieldname);
            }

            chkSkip.CheckedChanged += (x, y) => { txtSkip.Enabled = chkSkip.Checked; };
            chkLimit.CheckedChanged += (x, y) => { txtLimit.Enabled = chkLimit.Checked; };
            chkSample.CheckedChanged += (x, y) => { txtSample.Enabled = chkSample.Checked; };

        }

        /// <summary>
        ///     加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAggregationCondition_Load(object sender, EventArgs e)
        {
            QueryFieldPicker.InitByCurrentCollection(true);
            GroupFieldPicker.InitByCurrentCollection(false);

            if (!GuiConfig.IsUseDefaultLanguage)
            {
                Text = GuiConfig.GetText("Stage Builder", "StageBuilder");
                btnOK.Text = GuiConfig.GetText(TextType.CommonOk);
                btnCancel.Text = GuiConfig.GetText(TextType.CommonCancel);
            }

        }

        /// <summary>
        ///     OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //Project
            var project = QueryFieldPicker.GetAggregation();
            if (project[0].AsBsonDocument.ElementCount > 0)
            {
                Aggregation.Add(project);
            }

            //match
            var match = MatchListPanel.GetMatchDocument();
            if (match != null)
            {
                Aggregation.Add(match);
            }

            //Sort
            var sort = SortPanel.GetSortDocument();
            if (sort != null)
            {
                Aggregation.Add(sort);
            }

            //Group
            var groupDetail = GroupFieldPicker.GetGroupId();
            if (groupDetail.GetElement(0).Value.AsBsonDocument.ElementCount != 0)
            {
                foreach (var item in groupPanelCreator.GetGroup())
                {
                    groupDetail.Add(item);
                }
                var group = new BsonDocument("$group", groupDetail);
                Aggregation.Add(group);
            }


            //Skip
            if (chkSkip.Checked && int.Parse(txtSkip.Text) > 0)
            {
                Aggregation.Add(new BsonDocument("$skip", int.Parse(txtSkip.Text)));
            }
            //Limit
            if (chkLimit.Checked && int.Parse(txtLimit.Text) > 0)
            {
                Aggregation.Add(new BsonDocument("$limit", int.Parse(txtLimit.Text)));
            }
            //IndexStats
            if (chkIndexStats.Checked)
            {
                Aggregation.Add(new BsonDocument("$indexStats", new BsonDocument()));
            }
            //sortByCount
            if (chkSortByCount.Checked)
            {
                Aggregation.Add(new BsonDocument("$sortByCount", cmbSortByCount.Text));
            }
            //Sample
            if (chkSample.Checked)
            {
                var size = new BsonDocument("size", (int.Parse(txtSample.Text)));
                Aggregation.Add(new BsonDocument("$sample", size));
            }
            //unwind
            if (chkUnwind.Checked)
            {
                if (!chkPreserveNullAndEmptyArrays.Checked && string.IsNullOrEmpty(txtincludeArrayIndex.Text))
                {
                    Aggregation.Add(new BsonDocument("$unwind", cmbUnwind.Text));
                }
                else
                {
                    var UnwindDoc = new BsonDocument();
                    var field = new BsonElement("path", cmbUnwind.Text);
                    UnwindDoc.Add(field);
                    if (chkPreserveNullAndEmptyArrays.Checked)
                    {
                        var preserveNullAndEmptyArrays = new BsonElement("preserveNullAndEmptyArrays", BsonBoolean.True);
                        UnwindDoc.Add(preserveNullAndEmptyArrays);
                    }
                    if (!string.IsNullOrEmpty(txtincludeArrayIndex.Text))
                    {
                        var includeArrayIndex = new BsonElement("includeArrayIndex", txtincludeArrayIndex.Text);
                        UnwindDoc.Add(includeArrayIndex);
                    }
                    Aggregation.Add(new BsonDocument("$unwind", UnwindDoc));
                }
            }
            Close();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region"Group"

        /// <summary>
        ///     添加一个Group项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddGroupItem_Click(object sender, EventArgs e)
        {
            groupPanelCreator.AddGroupItem();
        }

        /// <summary>
        ///     清除所有Group项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearGroupItem_Click(object sender, EventArgs e)
        {
            groupPanelCreator.Clear();
        }

        #endregion
    }
}