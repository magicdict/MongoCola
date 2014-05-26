using Card.Effect;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Card
{
    /// <summary>
    /// 随从卡牌
    /// </summary>
    [Serializable]
    public class MinionCard : CardBasicInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public enum 光环范围
        {
            /// <summary>
            /// 随从全体
            /// </summary>
            随从全体,
            /// <summary>
            /// 相邻随从
            /// </summary>
            相邻随从,
            /// <summary>
            /// 英雄
            /// </summary>
            英雄
        }
        /// <summary>
        /// 
        /// </summary>
        public enum 光环类型
        {
            增加攻防,
            减少施法成本,
            增加法术效果
        }
        /// <summary>
        /// 效果
        /// </summary>
        public struct Buff
        {
            /// <summary>
            /// 范围
            /// </summary>
            public 光环范围 Scope;
            /// <summary>
            /// 效果
            /// </summary>
            public 光环类型 EffectType;
            /// <summary>
            /// 信息
            /// </summary>
            public String BuffInfo;
        }

        #region"属性"

        #region"设计时状态"
        /// <summary>
        /// 攻击力（标准）
        /// </summary>
        public int StandardAttackPoint = -1;
        /// <summary>
        /// 体力（标准）
        /// </summary>
        public int StandardHealthPoint = -1;
        /// <summary>
        /// 嘲讽(标准)
        /// </summary>
        public Boolean Standard嘲讽 = false;
        /// <summary>
        /// 冲锋(标准)
        /// </summary>
        public Boolean Standard冲锋 = false;
        /// <summary>
        /// 连击(标准)
        /// </summary>
        public Boolean Standard连击 = false;
        /// <summary>
        /// 风怒(标准)
        /// </summary>
        public Boolean Standard风怒 = false;
        /// <summary>
        /// 是否初始为潜行状态
        /// </summary>
        public Boolean 潜行特性 = false;
        /// <summary>
        /// 是否初始为圣盾状态
        /// </summary>
        public Boolean 圣盾特性 = false;
        /// <summary>
        /// 法术免疫
        /// </summary>
        public Boolean 法术免疫特性 = false;
        /// <summary>
        /// 英雄技能免疫
        /// </summary>
        public Boolean 英雄技能免疫特性 = false;
        /// <summary>
        /// 亡语
        /// </summary>
        public Ability 亡语效果;
        /// <summary>
        /// 战吼
        /// </summary>
        public Ability 战吼效果;
        /// <summary>
        /// 激怒
        /// </summary>
        public Ability 激怒效果;
        /// <summary>
        /// 该单位在战地时的效果
        /// </summary>
        public Buff 光环效果;
        #endregion

        #region"运行时状态"
        /// <summary>
        /// 攻击力（实际、不包含光环效果）
        /// </summary>
        [XmlIgnore]
        public int ActualAttackPoint = -1;
        /// <summary>
        /// 体力（实际）
        /// </summary>
        [XmlIgnore]
        public int ActualHealthPoint = -1;
        /// <summary>
        /// 嘲讽(实际)
        /// </summary>
        [XmlIgnore]
        public Boolean Actual嘲讽 = false;
        /// <summary>
        /// 冲锋(实际)
        /// </summary>
        [XmlIgnore]
        public Boolean Actual冲锋 = false;
        /// <summary>
        /// 连击(实际)
        /// </summary>
        [XmlIgnore]
        public Boolean Actual连击 = false;
        /// <summary>
        /// 风怒(实际)
        /// </summary>
        [XmlIgnore]
        public Boolean Actual风怒 = false;
        /// <summary>
        /// 是否为潜行状态
        /// </summary>
        [XmlIgnore]
        public Boolean Is潜行Status = false;
        /// <summary>
        /// 是否为圣盾状态
        /// </summary>
        [XmlIgnore]
        public Boolean Is圣盾Status = false;
        /// <summary>
        /// 是否为法术免疫状态
        /// </summary>
        [XmlIgnore]
        public Boolean Is法术免疫Status = false;
        /// <summary>
        /// 是否为英雄技能免疫状态
        /// </summary>
        [XmlIgnore]
        public Boolean Is英雄技能免疫Status = false;
        /// <summary>
        /// 是否为激怒状态
        /// </summary>
        [XmlIgnore]
        public Boolean Is激怒Status = false;
        /// <summary>
        /// 是否为沉默状态
        /// </summary>
        [XmlIgnore]
        public Boolean Is沉默Status = false;
        /// <summary>
        /// 是否为冰冻状态
        /// </summary>
        [XmlIgnore]
        public Boolean Is冰冻Status = false;
        /// <summary>
        /// 剩余攻击次数
        /// </summary>
        /// <remarks>
        /// 风怒的时候，回合开始为2次
        /// 刚放到战场时，冲锋的单位为1次，其余为0次
        /// </remarks>
        [XmlIgnore]
        public int RemainAttactTimes = 1;
        /// <summary>
        /// 该单位受到战地的效果
        /// </summary>
        [XmlIgnore]
        public List<Buff> 受战地效果 = new List<Buff>();
        #endregion
        /// <summary>
        /// 设置初始状态
        /// </summary>
        public new void Init()
        {
            //将运行时状态设置为设计时状态
            this.ActualAttackPoint = this.StandardAttackPoint;
            this.ActualCostPoint = this.StandardCostPoint;
            this.ActualHealthPoint = this.StandardHealthPoint;
            this.Actual冲锋 = this.Standard冲锋;
            this.Actual嘲讽 = this.Standard嘲讽;
            this.Actual连击 = this.Standard连击;
            this.Actual风怒 = this.Standard风怒;
            this.Is潜行Status = this.潜行特性;
            this.Is圣盾Status = this.圣盾特性;
            this.Is英雄技能免疫Status = this.英雄技能免疫特性;
            this.Is法术免疫Status = this.法术免疫特性;
            //初始状态
            this.Is冰冻Status = false;
            this.Is沉默Status = false;
            this.Is激怒Status = false;
            //攻击次数
            if (Actual冲锋)
            {
                if (Actual风怒)
                {
                    RemainAttactTimes = 2;
                }
                else
                {
                    RemainAttactTimes = 1;
                }
            }
            else
            {
                RemainAttactTimes = 0;
            }
        }
        /// <summary>
        /// 重置可攻击次数
        /// </summary>
        public void ResetAttackTimes()
        {
            if (Actual风怒)
            {
                RemainAttactTimes = 2;
            }
            else
            {
                RemainAttactTimes = 1;
            }
        }
        /// <summary>
        /// 实际输出效果
        /// </summary>
        /// <returns>包含了光环效果</returns>
        public int TotalAttack()
        {
            int BuffAct = 0;
            foreach (var buff in 受战地效果)
            {
                BuffAct += int.Parse(buff.BuffInfo.Split("/".ToCharArray())[0]);
            }
            return ActualAttackPoint + BuffAct;
        }
        /// <summary>
        /// 实际输出效果
        /// </summary>
        /// <returns>包含了光环效果</returns>
        public int TotalHealth()
        {
            int BuffAct = 0;
            foreach (var buff in 受战地效果)
            {
                BuffAct += int.Parse(buff.BuffInfo.Split("/".ToCharArray())[1]);
            }
            return ActualHealthPoint + BuffAct;
        }
        /// <summary>
        /// 生存状态
        /// </summary>
        /// <returns></returns>
        public bool IsLive()
        {
            return ActualHealthPoint > 0;
        }
        /// <summary>
        /// 攻击后
        /// </summary>
        public void AfterAttack()
        {
            //失去潜行
            Is潜行Status = false;
        }
        /// <summary>
        /// 被攻击后
        /// </summary>
        public void AfterBeAttack(int AttackPoint)
        {
            if (!Is圣盾Status) ActualHealthPoint -= AttackPoint;
            //失去圣盾
            Is圣盾Status = false;
        }
        /// <summary>
        /// 获得信息
        /// </summary>
        /// <returns></returns>
        public String GetInfo() {
            StringBuilder Status = new StringBuilder();
            Status.AppendLine(Name);
            Status.AppendLine("[实际]攻：" + ActualAttackPoint.ToString() + " 血：" + ActualHealthPoint.ToString());
            Status.AppendLine("[光环]攻：" + TotalAttack().ToString() + " 血：" + TotalHealth().ToString());
            return Status.ToString();
        }
        #endregion
    }
}
