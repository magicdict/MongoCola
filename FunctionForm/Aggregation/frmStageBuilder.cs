using Common;
using FunctionForm.Operation;
using MongoDB.Bson;
using MongoGUICtl.ClientTree;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;
using ResourceLib.UI;
using System;
using System.Windows.Forms;

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
            GuiConfig.Translateform(this);
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
            var supressAggr = project[0];
            var projectAggr = project[1];
            if (supressAggr[0].AsBsonDocument.ElementCount > 0)
            {
                Aggregation.Add(supressAggr);
            }
            //TODO:需要优化，全项目的时候，不用输出
            if (projectAggr[0].AsBsonDocument.ElementCount > 0)
            {
                Aggregation.Add(projectAggr);
            }

            //match
            var match = ConditionPan.GetMatchDocument();
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
            if (chkIdNull.Checked)
            {
                var id = new BsonDocument
                {
                    new BsonElement("_id", BsonNull.Value)
                };
                id.AddRange(FieldsElement.Value.AsBsonDocument.Elements);
                var group = new BsonDocument("$group", id);
                Aggregation.Add(group);
            }
            else
            {
                if (!string.IsNullOrEmpty(GroupIdElement.Name))
                {
                    var id = new BsonDocument
                    {
                        new BsonElement("_id", GroupIdElement.Value)
                    };
                    id.AddRange(FieldsElement.Value.AsBsonDocument.Elements);
                    var group = new BsonDocument("$group", id);
                    Aggregation.Add(group);
                }
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

        BsonElement GroupIdElement = new BsonElement();
        private void cmdCreateGroupId_Click(object sender, EventArgs e)
        {
            var frmInsertDoc = new frmCreateDocument();
            UIAssistant.OpenModalForm(frmInsertDoc, false, true);
            if (frmInsertDoc.mBsonDocument != null)
            {
                GroupIdElement = new BsonElement("id", frmInsertDoc.mBsonDocument);
                UiHelper.FillDataToTreeView("GroupId", TreeViewGroupId, frmInsertDoc.mBsonDocument);
            }
        }
        BsonElement FieldsElement = new BsonElement();
        private void cmdCreateGroupFields_Click(object sender, EventArgs e)
        {
            var frmInsertDoc = new frmCreateDocument();
            UIAssistant.OpenModalForm(frmInsertDoc, false, true);
            if (frmInsertDoc.mBsonDocument != null)
            {
                FieldsElement = new BsonElement("fields", frmInsertDoc.mBsonDocument);
                UiHelper.FillDataToTreeView("GroupId", TreeViewGroupFields, frmInsertDoc.mBsonDocument);
            }
        }

        #endregion


    }
}