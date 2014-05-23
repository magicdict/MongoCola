using Card;
using Card.Player;
using Card.Server;
using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
namespace 炉边传说
{
    public partial class BattleField : Form
    {
        public BattleField()
        {
            InitializeComponent();
        }
        public GameManager game;
        /// <summary>
        /// Timer
        /// </summary>
        private Timer WaitTimer = new Timer();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BattleField_Load(object sender, System.EventArgs e)
        {
            game.GetSelectTarget = SelectPanel;
            game.PickEffect = PickEffect;
            WaitTimer.Interval = 3000;
            WaitTimer.Tick += WaitFor;
            DisplayMyInfo();
            game.IsMyTurn = game.IsFirst;
            StartNewTurn();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private CardUtility.TargetPosition SelectPanel()
        {
            CardUtility.TargetPosition t = new Card.CardUtility.TargetPosition();
            TargetSelect frm = new TargetSelect();
            frm.ShowDialog();
            t = frm.pos;
            return t;
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
            Status.AppendLine("GameId：" + game.GameId);
            Status.AppendLine("PlayerNickName：" + game.PlayerNickName);
            Status.AppendLine("IsHost：" + game.IsHost);
            Status.AppendLine("IsFirst：" + game.IsFirst);

            Status.AppendLine("==============");
            Status.AppendLine("Role：");
            lstMyMinion.Items.Add("本方英雄");
            Status.AppendLine("Crystal：" + game.MySelf.RoleInfo.crystal.CurrentRemainPoint + "/" + game.MySelf.RoleInfo.crystal.CurrentFullPoint);
            Status.AppendLine("HealthPoint：" + game.MySelf.RoleInfo.HealthPoint);
            if (game.MySelf.RoleInfo.Weapon != null)
            {
                Status.AppendLine("Weapon：" + game.MySelf.RoleInfo.Weapon.StandardAttackPoint);
            }
            else
            {
                Status.AppendLine("Weapon：Null");
            }
            Status.AppendLine("RemainCardDeckCount：" + game.MySelf.RoleInfo.RemainCardDeckCount);
            Status.AppendLine("==============");
            Status.AppendLine("Battle：");
            lstMyMinion.Items.Clear();
            for (int i = 0; i < game.MySelf.RoleInfo.BattleField.BattleMinions.Length; i++)
            {
                lstMyMinion.Items.Add("本方位置" + i.ToString() + "：" +
                    (game.MySelf.RoleInfo.BattleField.BattleMinions[i] == null ? "[NULL]" : game.MySelf.RoleInfo.BattleField.BattleMinions[i].Name));
            }

            Status.AppendLine("==============");
            Status.AppendLine("Role：");
            lstMyMinion.Items.Add("对方英雄");
            Status.AppendLine("Crystal：" + game.AgainstInfo.crystal.CurrentRemainPoint + "/" + game.AgainstInfo.crystal.CurrentFullPoint);
            Status.AppendLine("HealthPoint：" + game.AgainstInfo.HealthPoint);
            if (game.AgainstInfo.Weapon != null)
            {
                Status.AppendLine("Weapon：" + game.AgainstInfo.Weapon.StandardAttackPoint);
            }
            else
            {
                Status.AppendLine("Weapon：Null");
            }
            Status.AppendLine("RemainCardDeckCount：" + game.AgainstInfo.RemainCardDeckCount);
            Status.AppendLine("==============");
            Status.AppendLine("Battle：");
            for (int i = 0; i < game.AgainstInfo.BattleField.BattleMinions.Length; i++)
            {
                lstMyMinion.Items.Add("对方位置" + i.ToString() + "：" +
                    (game.AgainstInfo.BattleField.BattleMinions[i] == null ? "[NULL]" : game.AgainstInfo.BattleField.BattleMinions[i].Name));
            }
            Status.AppendLine("==============");
            lblStatus.Text = Status.ToString();
            lstHandCard.Items.Clear();
            foreach (var handCard in game.MySelf.handCards)
            {
                lstHandCard.Items.Add(Card.CardUtility.GetCardNameBySN(handCard) + "[" + handCard + "]");
            }
        }
        /// <summary>
        /// 新的回合
        /// </summary>
        private void StartNewTurn()
        {
            game.NewTurn();
            if (game.IsMyTurn)
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
            var Actions = Card.Server.ClientUtlity.ReadAction(game.GameId.ToString(GameServer.GameIdFormat));
            if (String.IsNullOrEmpty(Actions)) return;
            var ActionList = Actions.Split("|".ToCharArray());
            foreach (var item in ActionList)
            {
                lstAction.Items.Add("[" + item + "]");
                if (ActionCode.GetActionType(item) != ActionCode.ActionType.EndTurn)
                {
                    ActionCode.ProcessAction(item, game);
                }
                else
                {
                    WaitTimer.Stop();
                    btnEndTurn.Enabled = true;
                    game.IsMyTurn = true;
                    StartNewTurn();
                    break;
                }
            }
            DisplayMyInfo();
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
            Card.Server.ClientUtlity.TurnEnd(game.GameId.ToString(GameServer.GameIdFormat));
            game.IsMyTurn = false;
            StartNewTurn();
            WaitTimer.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FirstEffect"></param>
        /// <param name="SecondEffect"></param>
        /// <returns></returns>
        private Boolean PickEffect(String FirstEffect, String SecondEffect)
        {
            Boolean IsFirst = false;
            EffectSelect t = new EffectSelect();
            t.FirstEffect = FirstEffect;
            t.SecondEffect = SecondEffect;
            t.ShowDialog();
            IsFirst = t.IsFirstEffect;
            t = null;
            return IsFirst;
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
                if (game.MySelf.RoleInfo.crystal.CurrentRemainPoint >= card.ActualCostPoint)
                {
                    game.MySelf.RoleInfo.crystal.CurrentRemainPoint -= card.ActualCostPoint;
                    game.MySelf.handCards.Remove(CardSn);
                }
                else
                {
                    MessageBox.Show("水晶不够");
                    return;
                }
                var actionlst = ActionCode.StartAction(game, CardSn);
                foreach (var action in actionlst)
                {
                    Card.Server.ClientUtlity.WriteAction(game.GameId.ToString(GameServer.GameIdFormat), action);
                }
            }
            DisplayMyInfo();
        }
    }
}
