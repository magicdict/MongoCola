//using MongoDB.Driver;
using System;
using System.Windows.Forms;
namespace CardHelper
{
    public partial class CardUnit : Form
    {
        public CardUnit()
        {
            InitializeComponent();
        }
        //private static MongoServer innerServer;
        //private static MongoDatabase innerDatabase;
        //private static MongoCollection innerCollection;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Card.CardUtility.Init(@"C:\MagicMongoDBTool\CardHelper\CardXML");
            //innerServer = MongoServer.Create(@"mongodb://localhost:28030");
            //innerServer.Connect();
            //innerDatabase = innerServer.GetDatabase("HearthStone");
            //innerCollection = innerDatabase.GetCollection("Card");
        }
        /// <summary>
        /// 新建卡牌:奥术飞弹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate奥术飞弹_Click(object sender, EventArgs e)
        {
            //innerCollection.Insert<Card.AbilityCard>(HelperUtility.Get奥术飞弹());
        }
        /// <summary>
        /// 新建卡牌:狼骑兵
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate狼骑兵_Click(object sender, EventArgs e)
        {
            //innerCollection.Insert<Card.MinionCard>(HelperUtility.Get狼骑兵());
        }
        /// <summary>
        /// 新建卡牌:角斗士的长弓
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate角斗士的长弓_Click(object sender, EventArgs e)
        {
            //innerCollection.Insert<Card.WeaponCard>(HelperUtility.Get角斗士的长弓());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate鱼人猎潮者_Click(object sender, EventArgs e)
        {
            //innerCollection.Insert<Card.MinionCard>(HelperUtility.Get鱼人猎潮者());
        }
        /// <summary>
        /// 鲜血小鬼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate鲜血小鬼_Click(object sender, EventArgs e)
        {
            //innerCollection.Insert<Card.MinionCard>(HelperUtility.Get鲜血小鬼());
        }
    }
}
