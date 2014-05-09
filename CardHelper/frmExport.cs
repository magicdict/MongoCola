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
            worksheet = workbook.Sheets(1);
            int rowCount = 2;
            String strRare = String.Empty;
            String CardType = String.Empty;
            Card.CardBasicInfo.稀有程度 Rare;
            Rare = Card.CardBasicInfo.稀有程度.白色;
            while (!String.IsNullOrEmpty(worksheet.Cells(rowCount, 1).Text))
            {
                //序列号1  名称2	说明3	职业4	种族5	花费资源6	攻击7	生命8	类型9	来源10	稀有程度11
                strRare = worksheet.Cells(rowCount, 11).Text;
                CardType = worksheet.Cells(rowCount, 9).Text;
                switch (strRare)
                {
                    case "白色":
                        Rare = Card.CardBasicInfo.稀有程度.白色;
                        break;
                    case "绿色":
                        Rare = Card.CardBasicInfo.稀有程度.绿色;
                        break;
                    case "蓝色":
                        Rare = Card.CardBasicInfo.稀有程度.蓝色;
                        break;
                    case "紫色":
                        Rare = Card.CardBasicInfo.稀有程度.紫色;
                        break;
                    case "橙色":
                        Rare = Card.CardBasicInfo.稀有程度.橙色;
                        break;
                    default:
                        break;
                }
                switch (CardType)
                {
                    case "仆从":
                        Card.FollowerCard follower = new Card.FollowerCard();
                        follower.SN = worksheet.Cells(rowCount, 1).Text;
                        follower.Name = worksheet.Cells(rowCount, 2).Text;
                        follower.Description = worksheet.Cells(rowCount, 3).Text;
                        follower.StandardCostPoint = GetInt(worksheet.Cells(rowCount, 6).Text);
                        follower.StandardAttackPoint = GetInt(worksheet.Cells(rowCount, 7).Text);
                        follower.StandardHealthPoint = GetInt(worksheet.Cells(rowCount, 8).Text);
                        follower.Rare = Rare;
                        switch (target)
                        {
                            case TargetType.MongoDB:
                                innerCollection.Insert<Card.FollowerCard>(follower);
                                break;
                            case TargetType.Xml:
                                XmlSerializer xml = new XmlSerializer(typeof(Card.FollowerCard));
                                String XmlFilename = XmlFolderPicker.SelectedPathOrFileName + "\\Follower\\" + worksheet.Cells(rowCount, 1).Text + ".xml";
                                xml.Serialize(new StreamWriter(XmlFilename), follower);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "法术":
                        Card.MagicCard magic = new Card.MagicCard();
                        magic.SN = worksheet.Cells(rowCount, 1).Text;
                        magic.Name = worksheet.Cells(rowCount, 2).Text;
                        magic.Description = worksheet.Cells(rowCount, 3).Text;
                        magic.StandardCostPoint = GetInt(worksheet.Cells(rowCount, 6).Text);
                        magic.Rare = Rare;
                        switch (target)
                        {
                            case TargetType.MongoDB:
                                innerCollection.Insert<Card.MagicCard>(magic);
                                break;
                            case TargetType.Xml:
                                XmlSerializer xml = new XmlSerializer(typeof(Card.MagicCard));
                                String XmlFilename = XmlFolderPicker.SelectedPathOrFileName + "\\Magic\\" + worksheet.Cells(rowCount, 1).Text + ".xml";
                                xml.Serialize(new StreamWriter(XmlFilename), magic);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "武器":
                        Card.WeaponCard weapon = new Card.WeaponCard();
                        weapon.SN = worksheet.Cells(rowCount, 1).Text;
                        weapon.Name = worksheet.Cells(rowCount, 2).Text;
                        weapon.Description = worksheet.Cells(rowCount, 3).Text;
                        weapon.StandardCostPoint = GetInt(worksheet.Cells(rowCount, 6).Text);
                        weapon.Rare = Rare;
                        switch (target)
                        {
                            case TargetType.MongoDB:
                                innerCollection.Insert<Card.WeaponCard>(weapon);
                                break;
                            case TargetType.Xml:
                                XmlSerializer xml = new XmlSerializer(typeof(Card.WeaponCard));
                                String XmlFilename = XmlFolderPicker.SelectedPathOrFileName + "\\Weapon\\" + worksheet.Cells(rowCount, 1).Text + ".xml";
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
            workbook.Close();
            excelObj.Quit();
            excelObj = null;
            MessageBox.Show("导出结束");
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportXML_Click(object sender, EventArgs e)
        {
            Card.CardUtility.Init();
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            XmlFolderPicker.SelectedPathOrFileName = Card.CardUtility.CardXmlFolder;
            ExcelPicker.SelectedPathOrFileName = @"C:\MagicMongoDBTool\DesignDocument\炉石设计\卡牌整理版本.xlsx";
        }
    }
}
