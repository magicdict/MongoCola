using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public static String CardXmlFolder = @"C:\MagicMongoDBTool\CardHelper\CardXML"; 
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            //从配置文件中获得卡牌的SN和名称的联系
            GetCardInfoFromXml();
            //序列号 名称
            SnVsName.Clear();
            foreach (CardBasicInfo card in CardCollections)
            {
                SnVsName.Add(card.SN,card.Name);
            }
        }
        /// <summary>
        /// 序列号和卡牌名称对应关系表格
        /// </summary>
        private static Dictionary<String, String> SnVsName = new Dictionary<string, string>();
        /// <summary>
        /// 通过卡牌序列号获得卡牌名称
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public static String GetCardNameBySN(String SN){
            if (SnVsName.ContainsKey(SN)) return SnVsName[SN];
            return "UnKnow";
        }
        /// <summary>
        /// 卡牌组合
        /// </summary>
        public static List<CardBasicInfo> CardCollections = new List<CardBasicInfo>();
        /// <summary>
        /// 从XML文件读取
        /// </summary>
        public static void GetCardInfoFromXml()
        {
            foreach (var magicXml in Directory.GetFiles(CardXmlFolder + "\\Magic\\"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Card.MagicCard));
                CardCollections.Add((MagicCard)xml.Deserialize(new StreamReader(magicXml)));
            }
            foreach (var FollowerXml in Directory.GetFiles(CardXmlFolder + "\\Follower\\"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Card.FollowerCard));
                CardCollections.Add((FollowerCard)xml.Deserialize(new StreamReader(FollowerXml)));
            }
            foreach (var WeaponXml in Directory.GetFiles(CardXmlFolder + "\\Weapon\\"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Card.WeaponCard));
                CardCollections.Add((WeaponCard)xml.Deserialize(new StreamReader(WeaponXml)));
            }
        }
        /// <summary>
        /// 职业
        /// </summary>
        public enum OccupationEnum
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
            无限制
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
            /// 全体
            /// </summary>
            全体,
            /// <summary>
            /// 武器，例如：潜行者，对武器喂毒
            /// </summary>
            武器
        }
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
            Random rand = Seed ==0?new Random():new Random(Seed);
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
        /// 位置
        /// </summary>
        public struct TargetPosition{
            /// <summary>
            /// 是否为先手的对象
            /// </summary>
            public Boolean IsFirst;
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
        /// 抽牌委托
        /// </summary>
        /// <param name="IsFirst">先后手区分</param>
        /// <param name="magic">法术定义</param>
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
        public delegate TargetPosition deleteGetTargetPosition();
        #endregion
    }
}
