using System;

namespace Card
{
    /// <summary>
    /// 卡牌共通
    /// </summary>
    public class CardBasicInfo
    {
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
        /// 图片
        /// </summary>
        /// <remarks>
        /// 该卡牌的图案。
        /// 人文方面的图案
        /// </remarks>
        public string ImagePath;
        /// <summary>
        /// 稀有度
        /// </summary>
        ///<remarks>
        /// 该卡牌的稀有度
        /// </remarks>
        public Byte Rare;
        /// <summary>
        /// 获得稀有度表示名称
        /// </summary>
        /// <remarks>
        /// 通过设置SystemManager.RareNameDic自定义稀有度表示名称
        /// </remarks>
        /// <returns></returns>
        public String GetRareName() {
            if (SystemManager.RareNameDic.Length - 1 < Rare) {
                return "<Err>";
            }
            else { 
               return SystemManager.RareNameDic[Rare];
            }
        }
    }
}
