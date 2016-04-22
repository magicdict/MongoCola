using System;
using System.Windows.Forms;
using MongoDB.Bson;
using ResourceLib.UI;

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
            txtLimit.KeyPress += NumberTextBox.NumberTextInt_KeyPress;
            txtSkip.KeyPress += NumberTextBox.NumberTextInt_KeyPress;

            chkSkip.CheckedChanged += (x, y) => { txtSkip.Enabled = chkSkip.Checked; };
            chkLimit.CheckedChanged += (x, y) => { txtLimit.Enabled = chkLimit.Checked; };
        }

        /// <summary>
        ///     加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAggregationCondition_Load(object sender, EventArgs e)
        {
            QueryFieldPicker.InitByCurrentCollection(false);
            GroupFieldPicker.InitByCurrentCollection(false);
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
        private void btnClear_Click(object sender, EventArgs e)
        {
            groupPanelCreator.Clear();
        }

        #endregion

        #region"Match"

        /// <summary>
        ///     新增MatchItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMatch_Click(object sender, EventArgs e)
        {
            MatchListPanel.AddMatchItem();
        }

        /// <summary>
        ///     清除MatchItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearMatch_Click(object sender, EventArgs e)
        {
            MatchListPanel.Clear();
        }

        #endregion
    }
}