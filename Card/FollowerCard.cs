using System;

namespace Card
{
    /// <summary>
    /// 随从卡牌
    /// </summary>
    public class FollowerCard : CardBasicInfo
    {
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
        public Boolean Can潜行 = false;
        /// <summary>
        /// 是否初始为圣盾状态
        /// </summary>
        public Boolean Can圣盾 = false;
        /// <summary>
        /// 法术免疫
        /// </summary>
        public Boolean Can法术免疫 = false;
        /// <summary>
        /// 英雄技能免疫
        /// </summary>
        public Boolean Can英雄技能免疫 = false;
        /// <summary>
        /// 亡语
        /// </summary>
        public EffectDefine 亡语;
        /// <summary>
        /// 战吼
        /// </summary>
        public EffectDefine 战吼;
        /// <summary>
        /// 激怒
        /// </summary>
        public EffectDefine 激怒;
        /// <summary>
        /// 战地效果
        /// </summary>
        public EffectDefine 战地效果;
        #endregion

        #region"运行时状态"
        /// <summary>
        /// 攻击力（实际）
        /// </summary>
        public int ActualAttackPoint = -1;
        /// <summary>
        /// 体力（实际）
        /// </summary>
        public int ActualHealthPoint = -1;
        /// <summary>
        /// 是否为潜行状态
        /// </summary>
        public Boolean Is潜行Status = false;
        /// <summary>
        /// 是否为沉默状态
        /// </summary>
        public Boolean Is沉默Status = false;
        /// <summary>
        /// 是否为激怒状态
        /// </summary>
        public Boolean Is激怒Status = false;
        /// <summary>
        /// 嘲讽(实际)
        /// </summary>
        public Boolean Actual嘲讽 = false;
        /// <summary>
        /// 冲锋(实际)
        /// </summary>
        public Boolean Actual冲锋 = false;
        /// <summary>
        /// 是否为冰冻状态
        /// </summary>
        public Boolean Is冰冻Status = false;
        /// <summary>
        /// 剩余攻击次数
        /// </summary>
        /// <remarks>
        /// 风怒的时候，回合开始为2次
        /// 刚放到战场时，冲锋的单位为1次，其余为0次
        /// </remarks>
        public int RemainAttactTimes = 1;
        #endregion

        /// <summary>
        /// 设置初始状态
        /// </summary>
        public void Init()
        {
            //将运行时状态设置为设计时状态
            this.ActualAttackPoint = this.StandardAttackPoint;
            this.ActualCostPoint = this.StandardCostPoint;
            this.ActualHealthPoint = this.StandardHealthPoint;
            this.Actual冲锋 = this.Standard冲锋;
            this.Actual嘲讽 = this.Standard嘲讽;
            //初始状态
            this.Is潜行Status = this.Can潜行;
            this.Is冰冻Status = false;
            this.Is沉默Status = false;
        }

        #endregion
    }
}
