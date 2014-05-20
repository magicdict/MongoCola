using Card.Server;
using System;
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
        private Timer WaitTimer = new Timer();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BattleField_Load(object sender, System.EventArgs e)
        {
            WaitTimer.Interval = 3000;
            WaitTimer.Tick += WaitFor;
            DisplayMyInfo();
            GameManager.IsMyTurn = GameManager.IsFirst;
            StartNewTurn();
        }
        /// <summary>
        /// 显示我方状态
        /// </summary>
        private void DisplayMyInfo()
        {
            //抽手牌,先手3张，后手4张，后手还有幸运币，不公平啊
            StringBuilder Status = new StringBuilder();
            Status.AppendLine("==============");
            Status.AppendLine("System：");
            Status.AppendLine("GameId：" + GameManager.GameId);
            Status.AppendLine("PlayerNickName：" + GameManager.PlayerNickName);
            Status.AppendLine("IsHost：" + GameManager.IsHost);
            Status.AppendLine("IsFirst：" + GameManager.IsFirst);
            Status.AppendLine("==============");
            Status.AppendLine("Role：");
            Status.AppendLine("Crystal：" + GameManager.SelfInfo.role.crystal.CurrentRemainPoint + "/" + GameManager.SelfInfo.role.crystal.CurrentFullPoint);
            Status.AppendLine("HealthPoint：" + GameManager.SelfInfo.role.HealthPoint);
            Status.AppendLine("RemainCardDeckCount：" + GameManager.SelfInfo.role.RemainCardDeckCount);
            Status.AppendLine("==============");
            Status.AppendLine("Battle：");
            for (int i = 0; i < GameManager.SelfInfo.role.myBattleField.BattleMinions.Length; i++)
            {
                Status.AppendLine("Position" + i.ToString() + "：" +
                    (GameManager.SelfInfo.role.myBattleField.BattleMinions[i] == null ? "[NULL]" : GameManager.SelfInfo.role.myBattleField.BattleMinions[i].Name));
            }
            Status.AppendLine("==============");
            lblStatus.Text = Status.ToString();
            lstHandCard.Items.Clear();
            foreach (var handCard in GameManager.SelfInfo.handCards)
            {
                lstHandCard.Items.Add(Card.CardUtility.GetCardNameBySN(handCard) + "[" + handCard + "]");
            }
        }
        /// <summary>
        /// 新的回合
        /// </summary>
        private void StartNewTurn()
        {
            GameManager.NewTurn();
            if (GameManager.IsMyTurn)
            {
                DisplayMyInfo();
                btnEndTurn.Enabled = true;
                btnUseHandCard.Enabled = true;
                lblEnemyBattle.Text = "你的回合";
            }
            else
            {
                btnEndTurn.Enabled = false;
                btnUseHandCard.Enabled = false;
                lblEnemyBattle.Text = "对手回合";
                WaitTimer.Start();
            }
        }
        /// <summary>
        /// 读取
        /// </summary>
        private void WaitFor(object sender, System.EventArgs e)
        {
            var Actions = Card.Server.ClientUtlity.ReadAction(GameManager.GameId.ToString(GameServer.GameIdFormat));
            if (String.IsNullOrEmpty(Actions)) return;
            var ActionList = Actions.Split("|".ToCharArray());
            foreach (var item in ActionList)
            {
                lstAction.Items.Add("[" + item + "]");
            }
            if (ActionList[ActionList.Length - 1] == Card.CardUtility.strEndTurn)
            {
                WaitTimer.Stop();
                btnEndTurn.Enabled = true;
                GameManager.IsMyTurn = true;
                StartNewTurn();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstHandCard_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lstHandCard.SelectedItems.Count != 1) return;
            var CardSn = lstHandCard.SelectedItem.ToString().Substring(lstHandCard.SelectedItem.ToString().IndexOf("[") + 1, 7);
            if (Card.CardUtility.GetCardInfoBySN(CardSn) != null)
            {
                Card.CardBasicInfo info = Card.CardUtility.GetCardInfoBySN(CardSn);
                StringBuilder Status = new StringBuilder();
                Status.AppendLine("==============");
                Status.AppendLine("Description" + info.Description);
                Status.AppendLine("StandardCostPoint" + info.StandardCostPoint);
                Status.AppendLine("Type：" + info.CardType.ToString());
                switch (CardSn.Substring(0, 1))
                {
                    case "A":
                        break;
                    case "M":
                        Status.AppendLine("标准攻击力：" + ((Card.MinionCard)info).StandardAttackPoint.ToString());
                        Status.AppendLine("标准生命值：" + ((Card.MinionCard)info).StandardHealthPoint.ToString());
                        break;
                    case "W":
                        Status.AppendLine("标准攻击力：" + ((Card.WeaponCard)info).StandardAttackPoint.ToString());
                        Status.AppendLine("标准耐久度：" + ((Card.WeaponCard)info).标准耐久度.ToString());
                        break;
                    default:
                        break;
                }

                lblSelectedHandCardInfo.Text = Status.ToString();
            }
        }
        /// <summary>
        /// 结束回合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndTurn_Click(object sender, System.EventArgs e)
        {
            Card.Server.ClientUtlity.TurnEnd(GameManager.GameId.ToString(GameServer.GameIdFormat));
            GameManager.IsMyTurn = false;
            StartNewTurn();
            WaitTimer.Start();
        }
        /// <summary>
        /// 读取对方行动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadAction_Click(object sender, EventArgs e)
        {
            var Actions = Card.Server.ClientUtlity.ReadAction(GameManager.GameId.ToString(GameServer.GameIdFormat));
            MessageBox.Show("[" + Actions + "]");
        }
        /// <summary>
        /// 使用手牌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUseHandCard_Click(object sender, EventArgs e)
        {
            if (lstHandCard.SelectedItems.Count != 1) return;
            var CardSn = lstHandCard.SelectedItem.ToString().Substring(lstHandCard.SelectedItem.ToString().IndexOf("[") + 1, 7);
            if (Card.CardUtility.GetCardInfoBySN(CardSn) != null)
            {
                Card.CardBasicInfo card = Card.CardUtility.GetCardInfoBySN(CardSn);
                if (GameManager.SelfInfo.role.crystal.CurrentRemainPoint >= card.ActualCostPoint)
                {
                    GameManager.SelfInfo.role.crystal.CurrentRemainPoint -= card.ActualCostPoint;
                    GameManager.SelfInfo.handCards.Remove(CardSn);
                }
                else
                {
                    MessageBox.Show("水晶不够");
                    return;
                }
                String strActionCode = String.Empty;
                switch (CardSn.Substring(0, 1))
                {
                    case "A":
                        strActionCode = ActionCode.UseAbility(CardSn, new string[] { });
                        break;
                    case "M":
                        int MinionPos = GameManager.SelfInfo.role.myBattleField.MinionCount + 1;
                        strActionCode = ActionCode.UseMinion(CardSn, MinionPos);
                        GameManager.SelfInfo.role.myBattleField.PutToBattle(MinionPos, (Card.MinionCard)card);
                        break;
                    case "W":
                        strActionCode = ActionCode.UseWeapon(CardSn);
                        GameManager.SelfInfo.role.Weapon = (Card.WeaponCard)card;
                        break;
                    default:
                        break;
                }
                Card.Server.ClientUtlity.WriteAction(GameManager.GameId.ToString(GameServer.GameIdFormat), strActionCode);
            }
            DisplayMyInfo();
        }
    }
}
