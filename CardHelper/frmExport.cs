using Microsoft.VisualBasic;
using MongoDB.Driver;
using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace CardHelper
{
    public partial class frmExport : Form
    {
        public frmExport()
        {
            InitializeComponent();
        }
        private static MongoServer innerServer;
        private static MongoDatabase innerDatabase;
        private static MongoCollection innerCollection;
        /// <summary>
        /// 导出到MongoDB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportMongoDB_Click(object sender, EventArgs e)
        {
            innerServer = MongoServer.Create(@"mongodb://localhost:28030");
            innerServer.Connect();
            innerDatabase = innerServer.GetDatabase("HearthStone");
            innerCollection = innerDatabase.GetCollection("Card");
            if (String.IsNullOrEmpty(ExcelPicker.SelectedPathOrFileName)) return;
            Export(TargetType.MongoDB);
            GC.Collect();
            innerServer.Disconnect();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportXml_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ExcelPicker.SelectedPathOrFileName)) return;
            if (String.IsNullOrEmpty(XmlFolderPicker.SelectedPathOrFileName)) return;
            Export(TargetType.Xml);
        }
        /// <summary>
        /// 导出类型
        /// </summary>
        private enum TargetType
        {
            /// <summary>
            /// MongoDataBase
            /// </summary>
            MongoDB,
            /// <summary>
            /// XmlFile
            /// </summary>
            Xml
        }
        /// <summary>
        /// 导入
        /// </summary>
        private void Export(TargetType target)
        {
            dynamic excelObj = Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook;
            dynamic worksheet;
            workbook = excelObj.Workbooks.Open(ExcelPicker.SelectedPathOrFileName);
            for (int i = 1; i < 5; i++)
            {
                Card.CardBasicInfo.稀有程度 Rare;
                Rare = Card.CardBasicInfo.稀有程度.白色;
                worksheet = workbook.Sheets(i);
                switch (i)
                {
                    case 1:
                        Rare = Card.CardBasicInfo.稀有程度.白色;
                        break;
                    case 2:
                        Rare = Card.CardBasicInfo.稀有程度.绿色;
                        break;
                    case 3:
                        Rare = Card.CardBasicInfo.稀有程度.蓝色;
                        break;
                    case 4:
                        Rare = Card.CardBasicInfo.稀有程度.紫色;
                        break;
                    case 5:
                        Rare = Card.CardBasicInfo.稀有程度.橙色;
                        break;
                    default:
                        break;
                }

                int rowCount = 2;
                while (!String.IsNullOrEmpty(worksheet.Cells(rowCount, 1).Text))
                {
                    //名称	说明	职业	种族	花费资源	攻击	生命	类型	来源	稀有程度
                    String CardType = worksheet.Cells(rowCount, 8).Text;
                    String XmlFilename = XmlFolderPicker.SelectedPathOrFileName + "\\" + worksheet.Cells(rowCount, 1).Text + ".xml";
                    switch (CardType)
                    {
                        case "仆从":
                            Card.FollowerCard follower = new Card.FollowerCard();
                            follower.Name = worksheet.Cells(rowCount, 1).Text;
                            follower.Description = worksheet.Cells(rowCount, 2).Text;
                            follower.StandardCostPoint = GetInt(worksheet.Cells(rowCount, 5).Text);
                            follower.StandardAttackPoint = GetInt(worksheet.Cells(rowCount, 6).Text);
                            follower.StandardHealthPoint = GetInt(worksheet.Cells(rowCount, 7).Text);
                            follower.Rare = Rare;
                            switch (target)
                            {
                                case TargetType.MongoDB:
                                    innerCollection.Insert<Card.FollowerCard>(follower);
                                    break;
                                case TargetType.Xml:
                                    XmlSerializer xml = new XmlSerializer(typeof(Card.FollowerCard));
                                    xml.Serialize(new StreamWriter(XmlFilename), follower);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "法术":
                            Card.MagicCard magic = new Card.MagicCard();
                            magic.Name = worksheet.Cells(rowCount, 1).Text;
                            magic.Description = worksheet.Cells(rowCount, 2).Text;
                            magic.StandardCostPoint = GetInt(worksheet.Cells(rowCount, 5).Text);
                            magic.Rare = Rare;
                            switch (target)
                            {
                                case TargetType.MongoDB:
                                    innerCollection.Insert<Card.MagicCard>(magic);
                                    break;
                                case TargetType.Xml:
                                    XmlSerializer xml = new XmlSerializer(typeof(Card.MagicCard));
                                    xml.Serialize(new StreamWriter(XmlFilename), magic);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "武器":
                            Card.WeaponCard weapon = new Card.WeaponCard();
                            weapon.Name = worksheet.Cells(rowCount, 1).Text;
                            weapon.Description = worksheet.Cells(rowCount, 2).Text;
                            weapon.StandardCostPoint = GetInt(worksheet.Cells(rowCount, 5).Text);
                            weapon.Rare = Rare;
                            switch (target)
                            {
                                case TargetType.MongoDB:
                                    innerCollection.Insert<Card.WeaponCard>(weapon);
                                    break;
                                case TargetType.Xml:
                                    XmlSerializer xml = new XmlSerializer(typeof(Card.WeaponCard));
                                    xml.Serialize(new StreamWriter(XmlFilename), weapon);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    rowCount++;
                }
            }
            workbook.Close();
            excelObj.Quit();
            excelObj = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="before"></param>
        /// <returns></returns>
        private int GetInt(String before)
        {
            if (String.IsNullOrEmpty(before)) return -1;
            return int.Parse(before);
        }


    }
}
