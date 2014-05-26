using Card.Client;
using System;
namespace Card
{
    /// <summary>
    /// 卡牌共通
    /// </summary>
    [Serializable]
    public class CardBasicInfo
    {
        #region"基本"
        /// <summary>
        /// 序列号
        /// </summary>
        /// <remarks>
        /// 该卡牌的统一序列号
        /// 该卡牌在整个系统中的唯一序号
        /// </remarks>
        public string SN;
        /// <summary>
        /// 名称
        /// </summary>
        /// <remarks>
        /// 该卡牌的名称。例如：“山岭巨人”。
        /// 人文方面的一个名称
        /// </remarks>
        public string Name;
        /// <summary>
        /// 描述
        /// </summary>
        /// <remarks>
        /// 该卡牌的描述。例如：“女猎手是暗夜精灵的卫士，她们出没于黑夜中”
        ///人文方面的一个描述
        /// </remarks>
        public string Description;
        /// <summary>
        /// 稀有度
        /// </summary>
        public enum 稀有程度 : byte
        {
            白色,
            绿色,
            蓝色,
            紫色,
            橙色
        }
        /// <summary>
        /// 稀有度
        /// </summary>
        ///<remarks>
        /// 该卡牌的稀有度
        /// </remarks>
        public 稀有程度 Rare;
        /// <summary>
        /// 
        /// </summary>
        public CardTypeEnum CardType {
            get {
                switch (SN.Substring(0,1))
                {
                    case "A":
                        return CardTypeEnum.法术;
                    case "W":
                        return CardTypeEnum.武器;
                    case "M":
                        return CardTypeEnum.随从;
                    default:
                        return CardTypeEnum.其他;
                }
            }
        }
        /// <summary>
        /// 是否启用
        /// </summary>
        public Boolean IsCardReady = false;
        #endregion

        #region "炉石专用"
        public enum CardTypeEnum
        {
            /// <summary>
            /// 随从
            /// </summary>
            随从,
            /// <summary>
            /// 法术
            /// </summary>
            法术,
            /// <summary>
            /// 武器
            /// </summary>
            武器,
            /// <summary>
            /// 其他
            /// </summary>
            其他
        }
        /// <summary>
        /// 过载
        /// </summary>
        public int Overload;
        /// <summary>
        /// 职业
        /// </summary>
        public CardUtility.ClassEnum Class;
        /// <summary>
        /// 标准的使用成本
        /// </summary>
        public int StandardCostPoint;
        /// <summary>
        /// 实际的使用成本
        /// </summary>
        ///<remarks>
        /// 有些技能能减少消耗
        /// </remarks>
        public int ActualCostPoint;
        /// <summary>
        /// 检查是否可以使用
        /// </summary>
        /// <returns></returns>
        public Boolean CheckCondition(PlayerBasicInfo info)
        {
            //剩余的法力是否足够实际召唤的法力
            return info.crystal.CurrentRemainPoint >= ActualCostPoint;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Init()
        {
            ActualCostPoint = StandardCostPoint;
        }
        #endregion

    }
}
