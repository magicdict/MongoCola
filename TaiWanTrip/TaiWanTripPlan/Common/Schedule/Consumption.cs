using System;

namespace Common.Schedule
{
    /// <summary>
    /// 消费记录
    /// </summary>
    public class Consumption : Database.EntityBase
    {
        /// <summary>
        /// 描述说明
        /// </summary>
        public string Description = string.Empty;
        /// <summary>
        /// 是否为综合项目
        /// </summary>
        public bool IsComprehensive
        {
            get
            {
                return PayClass == PayClassEnum.Comprehensive;
            }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public double Price = 0;
        /// <summary>
        /// 数量
        /// </summary>
        public int Count = 0;
        /// <summary>
        /// 总额
        /// </summary>
        /// <returns></returns>
        public double Total
        {
            get
            {
                return Price * Count;
            }
        }
        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime PayTime = DateTime.MinValue;
        /// <summary>
        /// 支付币种
        /// </summary>
        public CurrencyEnum PayCurrency = CurrencyEnum.RMB;
        /// <summary>
        /// 货币枚举
        /// </summary>
        public enum CurrencyEnum
        {
            /// <summary>
            /// 人民币
            /// </summary>
            RMB,
            /// <summary>
            /// 新台币
            /// </summary>
            NTD
        }
        /// <summary>
        /// 支付方法
        /// </summary>
        public PayMethodEnum PayMethod = PayMethodEnum.CreditCard;
        /// <summary>
        /// 支付方法枚举
        /// </summary>
        public enum PayMethodEnum
        {
            /// <summary>
            /// 现金
            /// </summary>
            Cash,
            /// <summary>
            /// 信用卡
            /// </summary>
            CreditCard,
            /// <summary>
            /// 携程旅行卡（礼品卡）
            /// </summary>
            GiftCard
        }
        /// <summary>
        /// 支付分类
        /// </summary>
        public PayClassEnum PayClass = PayClassEnum.Other;
        /// <summary>
        /// 支付分类
        /// </summary>
        public enum PayClassEnum
        {
            /// <summary>
            /// 交通
            /// </summary>
            Traffic,
            /// <summary>
            /// 饮食
            /// </summary>
            Catering,
            /// <summary>
            /// 门票
            /// </summary>
            Ticket,
            /// <summary>
            /// 购物
            /// </summary>
            Shopping,
            /// <summary>
            /// 饭店
            /// </summary>
            Hotel,
            /// <summary>
            /// 证件
            /// </summary>
            Certificates,
            /// <summary>
            /// 综合
            /// </summary>
            Comprehensive,
            /// <summary>
            /// 其他
            /// </summary>
            Other
        }

    }
}
