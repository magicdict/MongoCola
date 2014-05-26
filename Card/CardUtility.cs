using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Card
{
    /// <summary>
    /// 系统管理
    /// </summary>
    public static class CardUtility
    {
        /// <summary>
        /// CardXML文件夹
        /// </summary>
        public static String CardXmlFolder = String.Empty;
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init(String mCardXmlFolder)
        {
            CardXmlFolder = mCardXmlFolder;
            //从配置文件中获得卡牌的SN和名称的联系
            GetCardInfoFromXml();
            //序列号 名称
            ReadyCardDic.Clear();
            foreach (CardBasicInfo card in CardCollections.Values)
            {
                if (card.IsCardReady) ReadyCardDic.Add(card.SN, card.Name);
            }
        }
        /// <summary>
        /// 序列号和卡牌名称对应关系表格(可用状态)
        /// </summary>
        public static Dictionary<String, String> ReadyCardDic = new Dictionary<string, string>();
        /// <summary>
        /// 通过卡牌序列号获得卡牌名称
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public static String GetCardNameBySN(String SN)
        {
            if (ReadyCardDic.ContainsKey(SN)) return ReadyCardDic[SN];
            return "UnKnow";
        }
        /// <summary>
        /// 获得卡牌信息
        /// </summary>
        /// <param name="CardSn"></param>
        /// <returns></returns>
        public static String GetCardInfo(String CardSn)
        {
            StringBuilder Status = new StringBuilder();
            if (Card.CardUtility.GetCardInfoBySN(CardSn) != null)
            {
                Card.CardBasicInfo info = Card.CardUtility.GetCardInfoBySN(CardSn);
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
                Status.AppendLine("==============");
            }
            return Status.ToString();
        }

        /// <summary>
        /// 卡牌组合
        /// </summary>
        public static Dictionary<String, CardBasicInfo> CardCollections = new Dictionary<String, CardBasicInfo>();
        /// <summary>
        /// 通过卡牌序列号获得卡牌名称
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public static CardBasicInfo GetCardInfoBySN(String SN)
        {
            if (CardCollections.ContainsKey(SN))
            {
                var c = CardCollections[SN];
                c.Init();
                if (c.CardType == CardBasicInfo.CardTypeEnum.随从) ((Card.MinionCard)c).Init();
                return c;
            }
            return null;
        }
        /// <summary>
        /// 从XML文件读取
        /// </summary>
        public static void GetCardInfoFromXml()
        {
            //调用侧的NET版本3.5会引发错误。。。
            CardCollections.Clear();
            foreach (var AbilityXml in Directory.GetFiles(CardXmlFolder + "\\Ability\\"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Card.AbilityCard));
                Card.AbilityCard ability = (AbilityCard)xml.Deserialize(new StreamReader(AbilityXml));
                ability.ActualCostPoint = ability.StandardCostPoint;
                CardCollections.Add(ability.SN,ability);
            }
            foreach (var MinionXml in Directory.GetFiles(CardXmlFolder + "\\Minion\\"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Card.MinionCard));
                Card.MinionCard Minio = (MinionCard)xml.Deserialize(new StreamReader(MinionXml));
                Minio.ActualCostPoint = Minio.StandardCostPoint;
                CardCollections.Add(Minio.SN, Minio);
            }
            foreach (var WeaponXml in Directory.GetFiles(CardXmlFolder + "\\Weapon\\"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Card.WeaponCard));
                Card.WeaponCard Weapon = (WeaponCard)xml.Deserialize(new StreamReader(WeaponXml));
                Weapon.ActualCostPoint = Weapon.StandardCostPoint;
                CardCollections.Add(Weapon.SN, Weapon);
            }
        }

        #region"常数"
        /// <summary>
        /// 真
        /// </summary>
        public const String strTrue = "1";
        /// <summary>
        /// 假
        /// </summary>
        public const String strFalse = "0";
        /// <summary>
        /// 幸运币
        /// </summary>
        public const String SN幸运币 = "A900001";
        /// <summary>
        /// 表示本方
        /// </summary>
        public const String strMe = "ME";
        /// <summary>
        /// 表示对方
        /// </summary>
        public const String strYou = "YOU";
        /// <summary>
        /// 分隔符号
        /// </summary>
        public const String strSplitMark = "#";
        #endregion
        #region"枚举值"
        /// <summary>
        /// 职业
        /// </summary>
        public enum ClassEnum
        {
            猎人,
            盗贼,
            中立,
            德鲁伊,
            术士,
            圣骑士,
            萨满,
            牧师,
            法师,
            战士,
        }
        /// <summary>
        /// 目标选择模式
        /// </summary>
        public enum TargetSelectModeEnum
        {
            /// <summary>
            /// 无需选择
            /// </summary>
            不用选择,
            /// <summary>
            /// 随机
            /// </summary>
            随机,
            /// <summary>
            /// 全体
            /// </summary>
            全体,
            /// <summary>
            /// 指定
            /// </summary>
            指定,
        }
        /// <summary>
        /// 目标选择方向
        /// </summary>
        public enum TargetSelectDirectEnum
        {
            /// <summary>
            /// 本方
            /// </summary>
            本方,
            /// <summary>
            /// 对方
            /// </summary>
            对方,
            /// <summary>
            /// 无限制
            /// </summary>
            双方
        }
        /// <summary>
        /// 目标选择角色
        /// </summary>
        public enum TargetSelectRoleEnum
        {
            /// <summary>
            /// 随从
            /// </summary>
            随从,
            /// <summary>
            /// 英雄
            /// </summary>
            英雄,
            /// <summary>
            /// 全体（随从+英雄）
            /// </summary>
            所有角色,
            /// <summary>
            /// 武器，例如：潜行者，对武器喂毒
            /// </summary>
            武器
        }
        /// <summary>
        /// 多个效果的连接方式
        /// </summary>
        public enum EffectJoinType
        {
            /// <summary>
            /// 两个效果是并且的关系：副作用
            /// 例如：造成4点伤害，随机弃一张牌。
            /// </summary>
            AND,
            /// <summary>
            /// 两个效果是或者的关系：抉择
            /// 例如：抉择: 对一个随从造成3点伤害；或者造成1点伤害并抽一张牌。
            /// </summary>
            OR,
            /// <summary>
            /// 无需
            /// </summary>
            None
        }
        /// <summary>
        /// 返回值
        /// </summary>
        public enum CommandResult
        {
            /// <summary>
            /// 
            /// </summary>
            正常,
            /// <summary>
            /// 
            /// </summary>
            异常
        }
        #endregion
        /// <summary>
        /// 随机打算数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] RandomSort<T>(T[] array, int Seed)
        {
            int len = array.Length;
            System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
            T[] ret = new T[len];
            Random rand = Seed == 0 ? new Random() : new Random(Seed);
            int i = 0;
            while (list.Count < len)
            {
                int iter = rand.Next(0, len);
                if (!list.Contains(iter))
                {
                    list.Add(iter);
                    ret[i] = array[iter];
                    i++;
                }
            }
            return ret;
        }
        /// <summary>
        /// 获得字符枚举值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strEnum"></param>
        /// <returns></returns>
        public static T GetEnum<T>(String strEnum, T Default)
        {
            if (String.IsNullOrEmpty(strEnum)) return Default;
            try
            {
                T EnumValue = (T)Enum.Parse(typeof(T), strEnum);
                return EnumValue;
            }
            catch (Exception)
            {
                return Default;
            }
        }
        /// <summary>
        /// 数字字符转数字，错误则返回默认值
        /// </summary>
        /// <param name="StringInt"></param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static int GetInt(String StringInt, int DefaultValue = 0)
        {
            if (String.IsNullOrEmpty(StringInt)) return DefaultValue;
            return int.Parse(StringInt);
        }
        /// <summary>
        /// 用户指定位置
        /// </summary>
        public struct TargetPosition
        {
            /// <summary>
            /// 本方/对方
            /// </summary>
            public Boolean MeOrYou;
            /// <summary>
            /// 0 - 英雄，1-7 随从位置
            /// </summary>
            public int Postion;
        }
        /// <summary>
        /// 获得卡牌的图案（需要外部程序具体实现）
        /// </summary>
        public static delegateGetImage GetCardImage;
        /// <summary>
        /// 抽牌魔法(服务器方法)
        /// </summary>
        public static delegateDrawCard DrawCard;
        #region"委托"
        /// <summary>
        /// 抉择
        /// </summary>
        /// <param name="First">第一效果</param>
        /// <param name="Second">第二效果</param>
        /// <returns>是否为第一效果</returns>
        public delegate Boolean delegatePickEffect(String First, String Second);
        /// <summary>
        /// 抽牌委托
        /// </summary>
        /// <param name="IsFirst">先后手区分</param>
        /// <param name="Ability">法术定义</param>
        public delegate List<String> delegateDrawCard(Boolean IsFirst, int DrawCount);
        /// <summary>
        /// 获得图片
        /// </summary>
        /// <returns></returns>
        public delegate Image delegateGetImage(String ImageKey);
        /// <summary>
        /// 获得位置
        /// </summary>
        /// <returns></returns>
        public delegate TargetPosition deleteGetTargetPosition(TargetSelectDirectEnum t1,TargetSelectRoleEnum t2);
        #endregion
    }
}
