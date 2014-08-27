using System;

namespace Common.Destination
{
    /// <summary>
    /// 旅行目的地
    /// </summary>
    public class DestinationBase
    {
        /// <summary>
        /// 语言
        /// </summary>
        public string Language = string.Empty;
        /// <summary>
        /// 货币
        /// </summary>
        public string Currency = string.Empty;
        /// <summary>
        /// 汇率
        /// (例如 1RMB = X NTD)
        /// </summary>
        public double ExchangeRate = 0;
        /// <summary>
        /// 出入境口岸
        /// </summary>
        public string[] EntryExitPort = new string[] { };
        /// <summary>
        /// 外国货币转换为RMB
        /// </summary>
        /// <param name="Amount">外币金额</param>
        /// <returns></returns>
        public double ExchangeToRMB(double Amount)
        {
            if (ExchangeRate == 0) return 0;
            return Amount / ExchangeRate;
        }
        /// <summary>
        /// RMB转换为外国货币
        /// </summary>
        /// <param name="Amount"></param>
        /// <returns></returns>
        public double ExchangeFromRMB(double Amount)
        {
            if (ExchangeRate == 0) return 0;
            return Amount * ExchangeRate;
        }
    }
}
