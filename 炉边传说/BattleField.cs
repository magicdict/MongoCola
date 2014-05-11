using System.Text;
using System.Windows.Forms;

namespace 炉边传说
{
    public partial class BattleField : Form
    {
        public BattleField()
        {
            InitializeComponent();
        }
        private void BattleField_Load(object sender, System.EventArgs e)
        {
            StringBuilder Status = new StringBuilder();
            Status.AppendLine("GameId：" + GameManager.GameId);
            Status.AppendLine("PlayerNickName：" + GameManager.PlayerNickName);
            Status.AppendLine("IsHost：" + GameManager.IsHost);
            Status.AppendLine("IsFirst：" + GameManager.IsFirst);
            //抽手牌,先手3张，后手4张，后手还有幸运币，不公平啊
            var HandCard = Card.Server.ClientUtlity.DrawCard(GameManager.GameId.ToString("D5"), GameManager.IsFirst, GameManager.IsFirst ? 3 : 4);
            if (!GameManager.IsFirst) HandCard.Add(Card.CardUtility.SN幸运币);
            GameManager.SelfInfo.handCards = HandCard;

            Status.AppendLine("IsFirst：" + GameManager.IsFirst);
            foreach (var item in HandCard)
            {
                Status.AppendLine(item + Card.CardUtility.GetCardNameBySN(item));
            }
            lblStatus.Text = Status.ToString();
        }
    }
}
