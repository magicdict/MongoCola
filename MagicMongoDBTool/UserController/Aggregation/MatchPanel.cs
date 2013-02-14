using MongoDB.Bson;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class MatchPanel : UserControl
    {
        public MatchPanel()
        {
            InitializeComponent();
            AddMatchItem();
        }
        /// <summary>
        /// MatchItem数量
        /// </summary>
        private byte _conditionCount = 0;
        /// <summary>
        /// MatchItem位置
        /// </summary>
        private Point _conditionPos = new Point(10, 0);
        /// <summary>
        /// 增加MatchItem
        /// </summary>
        public void AddMatchItem()
        {
            _conditionCount++;
            ctlMatchItem newMatchItem = new ctlMatchItem();
            newMatchItem.Location = _conditionPos;
            newMatchItem.Name = "MatchItem" + _conditionCount.ToString();
            Controls.Add(newMatchItem);
            _conditionPos.Y += newMatchItem.Height;
        }
        /// <summary>
        /// 获取Match
        /// </summary>
        /// <returns></returns>
        public BsonDocument GetMatchDocument()
        {
            BsonDocument Matchlist = new BsonDocument();
            foreach (ctlMatchItem item in this.Controls)
            {
                BsonDocument match = item.getMatchItem();
                if (match != null)
                {
                    string MatchName = match.GetElement(0).Name;
                    if (Matchlist.Contains(MatchName))
                    {
                        BsonDocument AddMatch = match.GetElement(0).Value.AsBsonDocument;
                        Matchlist.GetElement(MatchName).Value.AsBsonDocument.Add(AddMatch);
                    }
                    else {
                        Matchlist.Add(match);
                    }
                }
            }
            if (Matchlist.ElementCount > 0)
            {
                return new BsonDocument("$match", Matchlist);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 清除所有MatchItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Clear()
        {
            Controls.Clear();
            _conditionCount = 0;
            _conditionPos = new Point(10, 0);
            AddMatchItem();
        }
    }
}
