using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card.Server
{
    /// <summary>
    /// 服务器 - 客户端 通信协议
    /// </summary>
    public static class Communication
    {
        /// <summary>
        /// 作为消息的前3位传输
        /// </summary>
        public enum MessageHeader
        {
            /// <summary>
            /// 正常
            /// </summary>
            正常 = 100,
            /// <summary>
            /// 异常
            /// </summary>
            异常 = 999,
            /// <summary>
            /// 使用法术
            /// </summary>
            使用法术 = 101,
            /// <summary>
            /// 英雄使用技能
            /// </summary>
            英雄使用技能 = 102,
            /// <summary>
            /// 随从攻击
            /// </summary>
            随从攻击 = 103,
            /// <summary>
            /// 随从出场
            /// </summary>
            随从出场 = 104
        }
    }
}
