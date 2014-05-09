using Microsoft.VisualBasic;
using MongoDB.Driver;
using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using Card;

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
            workbook = excelObj.Workbooks.Open(ExcelPicker.SelectedPathOrFileName);
            Minion(target, workbook);
            Ability(target, workbook);
            workbook.Close();
            excelObj.Quit();
            excelObj = null;
            MessageBox.Show("导出结束");
        }

        private void Minion(TargetType target, dynamic workbook)
        {
            //随从的导入
            dynamic worksheet = workbook.Sheets(1);
            int rowCount = 4;
            while (!String.IsNullOrEmpty(worksheet.Cells(rowCount, 2).Text))
            {
                Card.MinionCard Minion = new Card.MinionCard();
                Minion.SN = worksheet.Cells(rowCount, 2).Text;
                Minion.Name = worksheet.Cells(rowCount, 3).Text;
                Minion.Description = worksheet.Cells(rowCount, 4).Text;
                Minion.StandardCostPoint = CardUtility.GetInt(worksheet.Cells(rowCount, 7).Text);
                Minion.StandardAttackPoint = CardUtility.GetInt(worksheet.Cells(rowCount, 8).Text);
                Minion.StandardHealthPoint = CardUtility.GetInt(worksheet.Cells(rowCount, 9).Text);
                Minion.Rare = CardUtility.GetEnum<Card.CardBasicInfo.稀有程度>(worksheet.Cells(rowCount, 12).Text, CardBasicInfo.稀有程度.白色);

                Minion.Standard嘲讽 = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 14).Text);
                Minion.Standard冲锋 = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 15).Text);
                Minion.Standard连击 = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 16).Text);
                Minion.Standard风怒 = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 17).Text);
                Minion.潜行特性 = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 18).Text);
                Minion.圣盾特性 = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 19).Text);
                Minion.法术免疫特性 = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 20).Text);
                Minion.英雄技能免疫特性 = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 21).Text);

                switch (target)
                {
                    case TargetType.MongoDB:
                        innerCollection.Insert<Card.MinionCard>(Minion);
                        break;
                    case TargetType.Xml:
                        XmlSerializer xml = new XmlSerializer(typeof(Card.MinionCard));
                        String XmlFilename = XmlFolderPicker.SelectedPathOrFileName + "\\Minion\\" + Minion.SN + ".xml";
                        xml.Serialize(new StreamWriter(XmlFilename), Minion);
                        break;
                    default:
                        break;
                }
                rowCount++;
            }
        }

        private void Ability(TargetType target, dynamic workbook)
        {
            //随从的导入
            dynamic worksheet = workbook.Sheets(2);
            int rowCount = 4;
            while (!String.IsNullOrEmpty(worksheet.Cells(rowCount, 2).Text))
            {
                Card.AbilityCard Ability = new Card.AbilityCard();
                Ability.SN = worksheet.Cells(rowCount, 2).Text;
                Ability.Name = worksheet.Cells(rowCount, 3).Text;
                Ability.Description = worksheet.Cells(rowCount, 4).Text;
                Ability.StandardCostPoint = CardUtility.GetInt(worksheet.Cells(rowCount, 7).Text);
                Ability.Rare = CardUtility.GetEnum<Card.CardBasicInfo.稀有程度>(worksheet.Cells(rowCount, 12).Text, CardBasicInfo.稀有程度.白色);
                Card.Effect.EffectDefine effect = new Card.Effect.EffectDefine();
                effect.AbilityEffectType = CardUtility.GetEnum<Card.Effect.CardDeckEffect.AbilityEffectEnum>(worksheet.Cells(rowCount, 14).Text, Card.Effect.CardDeckEffect.AbilityEffectEnum.Attack);
                effect.EffectTargetSelectDirect = CardUtility.GetEnum<Card.CardUtility.TargetSelectDirectEnum>(worksheet.Cells(rowCount, 15).Text, CardUtility.TargetSelectDirectEnum.无限制);
                effect.EffectTargetSelectRole = CardUtility.GetEnum<Card.CardUtility.TargetSelectRoleEnum>(worksheet.Cells(rowCount, 16).Text, CardUtility.TargetSelectRoleEnum.随从);
                effect.EffictTargetSelectMode = CardUtility.GetEnum<Card.CardUtility.TargetSelectModeEnum>(worksheet.Cells(rowCount, 17).Text, CardUtility.TargetSelectModeEnum.全体);
                effect.StandardEffectPoint = CardUtility.GetInt(worksheet.Cells(rowCount, 18).Text);
                effect.EffectCount = CardUtility.GetInt(worksheet.Cells(rowCount, 19).Text);
                effect.AddtionInfo = worksheet.Cells(rowCount, 20).Text;
                Ability.FirstAbilityDefine = effect;
                switch (target)
                {
                    case TargetType.MongoDB:
                        innerCollection.Insert<Card.AbilityCard>(Ability);
                        break;
                    case TargetType.Xml:
                        XmlSerializer xml = new XmlSerializer(typeof(Card.AbilityCard));
                        String XmlFilename = XmlFolderPicker.SelectedPathOrFileName + "\\Ability\\" + Ability.SN + ".xml";
                        xml.Serialize(new StreamWriter(XmlFilename), Ability);
                        break;
                    default:
                        break;
                }
                rowCount++;
            }
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
