using System.Drawing;
using System.Windows.Forms;
using MongoDB.Bson;

namespace MongoCola
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
            var newMatchItem = new ctlMatchItem();
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
            var Matchlist = new BsonDocument();
            foreach (ctlMatchItem item in Controls)
            {
                BsonDocument match = item.getMatchItem();
                if (match != null)
                {
                    string MatchName = match.GetElement(0).Name;
                    if (Matchlist.Contains(MatchName))
                    {
                        BsonDocument AddMatch = match.GetElement(0).Value.AsBsonDocument;
                        Matchlist.GetElement(MatchName).Value.AsBsonDocument.AddRange(AddMatch);
                    }
                    else
                    {
                        Matchlist.AddRange(match);
                    }
                }
            }
            if (Matchlist.ElementCount > 0)
            {
                return new BsonDocument("$match", Matchlist);
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