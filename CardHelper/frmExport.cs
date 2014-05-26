using Card;
using Microsoft.VisualBasic;
//using MongoDB.Driver;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CardHelper
{
    public partial class frmExport : Form
    {
        public frmExport()
        {
            InitializeComponent();
        }
        //private static MongoServer innerServer;
        //private static MongoDatabase innerDatabase;
        //private static MongoCollection innerCollection;
        /// <summary>
        /// 导出到MongoDB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportMongoDB_Click(object sender, EventArgs e)
        {
            //innerServer = MongoServer.Create(@"mongodb://localhost:28030");
            //innerServer.Connect();
            //innerDatabase = innerServer.GetDatabase("HearthStone");
            //innerCollection = innerDatabase.GetCollection("Card");
            if (String.IsNullOrEmpty(ExcelPicker.SelectedPathOrFileName)) return;
            Export(TargetType.MongoDB);
            GC.Collect();
            //innerServer.Disconnect();
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
            Weapon(target, workbook);
            workbook.Close();
            excelObj.Quit();
            excelObj = null;
            MessageBox.Show("导出结束");
        }
        /// <summary>
        /// 随从的导入
        /// </summary>
        /// <param name="target"></param>
        /// <param name="workbook"></param>
        private void Minion(TargetType target, dynamic workbook)
        {
            if (Directory.Exists(XmlFolderPicker.SelectedPathOrFileName + "\\Minion\\"))
            {
                Directory.Delete(XmlFolderPicker.SelectedPathOrFileName + "\\Minion\\", true);
            }
            Directory.CreateDirectory(XmlFolderPicker.SelectedPathOrFileName + "\\Minion\\");
            //随从的导入
            dynamic worksheet = workbook.Sheets(1);
            int rowCount = 4;
            while (!String.IsNullOrEmpty(worksheet.Cells(rowCount, 2).Text))
            {
                Card.MinionCard Minion = new Card.MinionCard();
                Minion.SN = worksheet.Cells(rowCount, 2).Text;
                Minion.Name = worksheet.Cells(rowCount, 3).Text;
                Minion.Description = worksheet.Cells(rowCount, 4).Text;
                Minion.Class = CardUtility.GetEnum<Card.CardUtility.ClassEnum>(worksheet.Cells(rowCount, 5).Text, Card.CardUtility.ClassEnum.中立);
                Minion.StandardCostPoint = CardUtility.GetInt(worksheet.Cells(rowCount, 7).Text);
                Minion.ActualCostPoint = Minion.StandardCostPoint;

                Minion.StandardAttackPoint = CardUtility.GetInt(worksheet.Cells(rowCount, 8).Text);
                Minion.StandardHealthPoint = CardUtility.GetInt(worksheet.Cells(rowCount, 9).Text);
                Minion.Rare = CardUtility.GetEnum<Card.CardBasicInfo.稀有程度>(worksheet.Cells(rowCount, 12).Text, CardBasicInfo.稀有程度.白色);
                Minion.IsCardReady = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 13).Text);

                Minion.Standard嘲讽 = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 14).Text);
                Minion.Standard冲锋 = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 15).Text);
                Minion.Standard连击 = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 16).Text);
                Minion.Standard风怒 = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 17).Text);
                Minion.潜行特性 = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 18).Text);
                Minion.圣盾特性 = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 19).Text);
                Minion.法术免疫特性 = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 20).Text);
                Minion.英雄技能免疫特性 = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 21).Text);

                Boolean HasBuff = false;
                for (int i = 22; i < 25; i++)
                {
                    if (!String.IsNullOrEmpty(worksheet.Cells(rowCount, i).Text))
                    {
                        HasBuff = true;
                        break;
                    }
                }
                if (HasBuff)
                {
                    Minion.光环效果.Scope = CardUtility.GetEnum<Card.MinionCard.光环范围>(worksheet.Cells(rowCount, 22).Text, Card.MinionCard.光环范围.随从全体);
                    Minion.光环效果.EffectType = CardUtility.GetEnum<Card.MinionCard.光环类型>(worksheet.Cells(rowCount, 23).Text, Card.MinionCard.光环类型.增加攻防);
                    Minion.光环效果.BuffInfo = worksheet.Cells(rowCount, 24).Text;
                }
                switch (target)
                {
                    case TargetType.MongoDB:
                        //innerCollection.Insert<Card.MinionCard>(Minion);
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
        /// <summary>
        /// 法术的导入
        /// </summary>
        /// <param name="target"></param>
        /// <param name="workbook"></param>
        private void Ability(TargetType target, dynamic workbook)
        {
            if (Directory.Exists(XmlFolderPicker.SelectedPathOrFileName + "\\Ability\\"))
            {
                Directory.Delete(XmlFolderPicker.SelectedPathOrFileName + "\\Ability\\", true);
            }
            Directory.CreateDirectory(XmlFolderPicker.SelectedPathOrFileName + "\\Ability\\");
            //法术的导入
            dynamic worksheet = workbook.Sheets(2);
            int rowCount = 4;
            while (!String.IsNullOrEmpty(worksheet.Cells(rowCount, 2).Text))
            {
                Card.AbilityCard Ability = new Card.AbilityCard();
                Ability.SN = worksheet.Cells(rowCount, 2).Text;
                Ability.Name = worksheet.Cells(rowCount, 3).Text;
                Ability.Description = worksheet.Cells(rowCount, 4).Text;
                Ability.Class = CardUtility.GetEnum<Card.CardUtility.ClassEnum>(worksheet.Cells(rowCount, 5).Text, Card.CardUtility.ClassEnum.中立);
                Ability.StandardCostPoint = CardUtility.GetInt(worksheet.Cells(rowCount, 7).Text);
                Ability.ActualCostPoint = Ability.StandardCostPoint;

                Ability.Rare = CardUtility.GetEnum<Card.CardBasicInfo.稀有程度>(worksheet.Cells(rowCount, 12).Text, CardBasicInfo.稀有程度.白色);
                Ability.IsCardReady = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 13).Text);

                Card.Effect.EffectDefine effect = new Card.Effect.EffectDefine();
                effect.Description = String.IsNullOrEmpty(worksheet.Cells(rowCount, 14).Text) ? String.Empty : worksheet.Cells(rowCount, 14).Text;
                effect.AbilityEffectType = CardUtility.GetEnum<Card.Effect.CardDeckEffect.AbilityEffectEnum>(worksheet.Cells(rowCount, 15).Text, Card.Effect.CardDeckEffect.AbilityEffectEnum.未知);
                effect.EffictTargetSelectMode = CardUtility.GetEnum<Card.CardUtility.TargetSelectModeEnum>(worksheet.Cells(rowCount, 16).Text, CardUtility.TargetSelectModeEnum.不用选择);
                effect.EffectTargetSelectDirect = CardUtility.GetEnum<Card.CardUtility.TargetSelectDirectEnum>(worksheet.Cells(rowCount, 17).Text, CardUtility.TargetSelectDirectEnum.双方);
                effect.EffectTargetSelectRole = CardUtility.GetEnum<Card.CardUtility.TargetSelectRoleEnum>(worksheet.Cells(rowCount, 18).Text, CardUtility.TargetSelectRoleEnum.随从);
                effect.StandardEffectPoint = CardUtility.GetInt(worksheet.Cells(rowCount, 19).Text);
                effect.EffectCount = CardUtility.GetInt(worksheet.Cells(rowCount, 20).Text);
                effect.AddtionInfo = worksheet.Cells(rowCount, 21).Text;
                Ability.CardAbility.FirstAbilityDefine = effect;
                Ability.CardAbility.JoinType = CardUtility.GetEnum<Card.CardUtility.EffectJoinType>(worksheet.Cells(rowCount, 22).Text, Card.CardUtility.EffectJoinType.None);
                Boolean HasSecond = false;
                for (int i = 23; i < 31; i++)
                {
                    if (!String.IsNullOrEmpty(worksheet.Cells(rowCount, i).Text))
                    {
                        HasSecond = true;
                        break;
                    }
                }
                if (HasSecond)
                {
                    Card.Effect.EffectDefine effect2 = new Card.Effect.EffectDefine();
                    effect2.Description = String.IsNullOrEmpty(worksheet.Cells(rowCount, 23).Text) ? String.Empty : worksheet.Cells(rowCount, 23).Text;
                    effect2.AbilityEffectType = CardUtility.GetEnum<Card.Effect.CardDeckEffect.AbilityEffectEnum>(worksheet.Cells(rowCount, 24).Text, Card.Effect.CardDeckEffect.AbilityEffectEnum.未知);
                    effect2.EffictTargetSelectMode = CardUtility.GetEnum<Card.CardUtility.TargetSelectModeEnum>(worksheet.Cells(rowCount, 25).Text, CardUtility.TargetSelectModeEnum.不用选择);
                    effect2.EffectTargetSelectDirect = CardUtility.GetEnum<Card.CardUtility.TargetSelectDirectEnum>(worksheet.Cells(rowCount, 26).Text, CardUtility.TargetSelectDirectEnum.双方);
                    effect2.EffectTargetSelectRole = CardUtility.GetEnum<Card.CardUtility.TargetSelectRoleEnum>(worksheet.Cells(rowCount, 27).Text, CardUtility.TargetSelectRoleEnum.随从);
                    effect2.StandardEffectPoint = CardUtility.GetInt(worksheet.Cells(rowCount, 28).Text);
                    effect2.EffectCount = CardUtility.GetInt(worksheet.Cells(rowCount, 29).Text);
                    effect2.AddtionInfo = worksheet.Cells(rowCount, 30).Text;
                    Ability.CardAbility.SecondAbilityDefine = effect2;
                }
                switch (target)
                {
                    case TargetType.MongoDB:
                        //innerCollection.Insert<Card.AbilityCard>(Ability);
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
        /// 武器的导入
        /// </summary>
        /// <param name="target"></param>
        /// <param name="workbook"></param>
        private void Weapon(TargetType target, dynamic workbook)
        {
            if (Directory.Exists(XmlFolderPicker.SelectedPathOrFileName + "\\Weapon\\"))
            {
                Directory.Delete(XmlFolderPicker.SelectedPathOrFileName + "\\Weapon\\", true);
            }
            Directory.CreateDirectory(XmlFolderPicker.SelectedPathOrFileName + "\\Weapon\\");
            //武器的导入
            dynamic worksheet = workbook.Sheets(3);
            int rowCount = 4;
            while (!String.IsNullOrEmpty(worksheet.Cells(rowCount, 2).Text))
            {
                Card.WeaponCard Weapon = new Card.WeaponCard();
                Weapon.SN = worksheet.Cells(rowCount, 2).Text;
                Weapon.Name = worksheet.Cells(rowCount, 3).Text;
                Weapon.Description = worksheet.Cells(rowCount, 4).Text;
                Weapon.Class = CardUtility.GetEnum<Card.CardUtility.ClassEnum>(worksheet.Cells(rowCount, 5).Text, Card.CardUtility.ClassEnum.中立);
                Weapon.StandardCostPoint = CardUtility.GetInt(worksheet.Cells(rowCount, 7).Text);
                Weapon.ActualCostPoint = Weapon.StandardCostPoint;

                Weapon.StandardAttackPoint = CardUtility.GetInt(worksheet.Cells(rowCount, 8).Text);
                Weapon.标准耐久度 = CardUtility.GetInt(worksheet.Cells(rowCount, 9).Text);
                Weapon.Rare = CardUtility.GetEnum<Card.CardBasicInfo.稀有程度>(worksheet.Cells(rowCount, 12).Text, CardBasicInfo.稀有程度.白色);
                Weapon.IsCardReady = !String.IsNullOrEmpty(worksheet.Cells(rowCount, 13).Text);

                switch (target)
                {
                    case TargetType.MongoDB:
                        //innerCollection.Insert<Card.WeaponCard>(Weapon);
                        break;
                    case TargetType.Xml:
                        XmlSerializer xml = new XmlSerializer(typeof(Card.WeaponCard));
                        String XmlFilename = XmlFolderPicker.SelectedPathOrFileName + "\\Weapon\\" + Weapon.SN + ".xml";
                        xml.Serialize(new StreamWriter(XmlFilename), Weapon);
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
            Card.CardUtility.Init(@"C:\MagicMongoDBTool\CardHelper\CardXML");
        }
        private void frmExport_Load(object sender, EventArgs e)
        {
            Card.CardUtility.CardXmlFolder = @"C:\MagicMongoDBTool\CardHelper\CardXML";
            XmlFolderPicker.SelectedPathOrFileName = Card.CardUtility.CardXmlFolder;
            ExcelPicker.SelectedPathOrFileName = @"C:\MagicMongoDBTool\DesignDocument\炉石设计\卡牌整理版本.xls";
        }
    }
}
