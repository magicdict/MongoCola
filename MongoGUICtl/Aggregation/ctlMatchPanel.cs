using MongoDB.Bson;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MongoGUICtl.Aggregation
{
    public partial class ctlMatchPanel : UserControl
    {
        /// <summary>
        ///     MatchItem数量
        /// </summary>
        private byte MatchItemCount;

        /// <summary>
        ///     MatchItem位置
        /// </summary>
        private Point CurrentPos = new Point(10, 40);

        public ctlMatchPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     获取Match
        /// </summary>
        /// <returns></returns>
        public BsonDocument GetMatchDocument()
        {
            var matchlist = new BsonDocument();
            foreach (Control item in Controls)
            {
                if (item.GetType().FullName == typeof(Button).FullName) continue;
                var match = ((CtlMatchItem)item).GetMatchItem();
                if (match != null)
                {
                    var matchName = match.GetElement(0).Name;
                    if (matchlist.Contains(matchName))
                    {
                        var addMatch = match.GetElement(0).Value.AsBsonDocument;
                        matchlist.GetElement(matchName).Value.AsBsonDocument.AddRange(addMatch);
                    }
                    else
                    {
                        matchlist.AddRange(match);
                    }
                }
            }
            if (matchlist.ElementCount > 0)
            {
                return new BsonDocument("$match", matchlist);
            }
            return null;
        }


        /// <summary>
        ///     新增MatchItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMatch_Click(object sender, EventArgs e)
        {
            MatchItemCount++;
            var newMatchItem = new CtlMatchItem()
            {
                Location = CurrentPos,
                Name = "MatchItem" + MatchItemCount
            };
            Controls.Add(newMatchItem);
            CurrentPos.Y += newMatchItem.Height;
        }
        /// <summary>
        ///     清除MatchItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearMatch_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            MatchItemCount = 0;
            CurrentPos = new Point(10, 40);
        }
    }
}