using System;
using System.Windows.Forms;

namespace CardHelper
{
    public partial class RunMagic : Form
    {
        public RunMagic()
        {
            InitializeComponent();
        }

        Card.MagicCard 奥术飞弹 = new Card.MagicCard();
        Card.BattleFieldInfo 敌方战场 = new Card.BattleFieldInfo();
        Card.RoleInfo 敌人 = new Card.RoleInfo();

        private void btnCreate奥术飞弹_Click(object sender, EventArgs e)
        {
            奥术飞弹.SN = "T000001";
            奥术飞弹.Name = "奥术飞弹";
            奥术飞弹.Description = "造成3点伤害，随机分配给敌方角色。";
            奥术飞弹.Rare = Card.CardBasicInfo.稀有程度.绿色;
            //使用成本
            奥术飞弹.ActualCostPoint = 1;
            奥术飞弹.StandardCostPoint = 1;
            //3回1点攻击
            奥术飞弹.StandardAttackPoint = 1;
            奥术飞弹.ActualAttackPoint = 1;
            奥术飞弹.AttackCount = 3;
            奥术飞弹.AttackMode = Card.MagicCard.AttackModeEnum.随机;
        }
        /// <summary>
        /// 重置对手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetEenmey_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 敌方战场.BattleFollowers.Length; i++)
            {
                敌方战场.BattleFollowers[i] = Get狼骑兵();
            }
        }

        private Card.FollowerCard Get狼骑兵()
        {
            Card.FollowerCard 狼骑兵 = new Card.FollowerCard();
            狼骑兵.SN = "T000002";
            狼骑兵.Name = "狼骑兵";
            狼骑兵.Description = "冲锋";
            狼骑兵.Rare = Card.CardBasicInfo.稀有程度.绿色;
            //属性
            狼骑兵.ActualAttackPoint = 1;
            狼骑兵.ActualCostPoint = 3;
            狼骑兵.ActualHealthPoint = 1;
            狼骑兵.Actual冲锋 = true;
            狼骑兵.Actual嘲讽 = false;
            狼骑兵.StandardAttackPoint = 1;
            狼骑兵.StandardCostPoint = 3;
            狼骑兵.StandardHealthPoint = 1;
            狼骑兵.Standard冲锋 = true;
            狼骑兵.Standard嘲讽 = false;
            return 狼骑兵;
        }
        /// <summary>
        /// 使用魔法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserMagic_Click(object sender, EventArgs e)
        {
            
        }
    }
}
