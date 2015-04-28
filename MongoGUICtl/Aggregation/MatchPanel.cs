using System.Drawing;
using System.Windows.Forms;
using MongoDB.Bson;

namespace MongoGUICtl.Aggregation
{
    public partial class MatchPanel : UserControl
    {
        /// <summary>
        ///     MatchItem数量
        /// </summary>
        private byte _conditionCount;

        /// <summary>
        ///     MatchItem位置
        /// </summary>
        private Point _conditionPos = new Point(10, 0);

        public MatchPanel()
        {
            InitializeComponent();
            AddMatchItem();
        }

        /// <summary>
        ///     增加MatchItem
        /// </summary>
        public void AddMatchItem()
        {
            _conditionCount++;
            var newMatchItem = new CtlMatchItem();
            newMatchItem.Location = _conditionPos;
            newMatchItem.Name = "MatchItem" + _conditionCount;
            Controls.Add(newMatchItem);
            _conditionPos.Y += newMatchItem.Height;
        }

        /// <summary>
        ///     获取Match
        /// </summary>
        /// <returns></returns>
        public BsonDocument GetMatchDocument()
        {
            var matchlist = new BsonDocument();
            foreach (CtlMatchItem item in Controls)
            {
                var match = item.GetMatchItem();
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
        ///     清除所有MatchItem
        /// </summary>
        public void Clear()
        {
            Controls.Clear();
            _conditionCount = 0;
            _conditionPos = new Point(10, 0);
            AddMatchItem();
        }
    }
}