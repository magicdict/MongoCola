using System;

namespace Common.Destination
{
    /// <summary>
    /// 台湾
    /// </summary>
    public class TaiWan : DestinationBase
    {
        /// <summary>
        /// 初始化
        /// </summary>
	    public TaiWan()
	    {
            Language = "中文";
            Currency = "新台币";
            ExchangeRate = 5.00;
            EntryExitPort = new string[2] {"台北桃园机场", "高雄国际机场" };
        }
    }
}