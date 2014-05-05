using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace CardHelper
{
    public partial class frmImport : Form
    {
        public frmImport()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 导入按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ExcelPicker.SelectedPathOrFileName)) return;
            Import();
            GC.Collect();
        }
        /// <summary>
        /// 导入
        /// </summary>
        private void Import()
        {
            dynamic excelObj = Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook;
            dynamic worksheet;
            workbook = excelObj.Workbooks.Open(ExcelPicker.SelectedPathOrFileName);
            for (int i = 1; i < 5; i++)
            {
                worksheet = workbook.Sheets(i);
                int rowCount = 2;
                while (!String.IsNullOrEmpty(worksheet.Cells(rowCount,1).Text))
                {
                    //名称	说明	职业	种族	花费资源	攻击	生命	类型	来源	稀有程度
                    String CardType = worksheet.Cells(rowCount,8).Text;
                    switch (CardType)
                    {
                        case "仆从":
                            Card.FollowerCard follower = new Card.FollowerCard();
                            follower.Name = worksheet.Cells(rowCount, 1).Text;
                            follower.Description = worksheet.Cells(rowCount, 2).Text;
                            follower.Rare = (byte)(i - 1);
                            break;
                        case "法术":
                            Card.MagicCard magic = new Card.MagicCard();
                            magic.Name = worksheet.Cells(rowCount, 1).Text;
                            magic.Description = worksheet.Cells(rowCount, 2).Text;
                            magic.Rare = (byte)(i - 1);
                            break;
                        case "武器":
                            Card.WeaponCard weapon = new Card.WeaponCard();
                            weapon.Name = worksheet.Cells(rowCount, 1).Text;
                            weapon.Description = worksheet.Cells(rowCount, 2).Text;
                            weapon.Rare = (byte)(i - 1);
                            break;
                        default:
                            break;
                    }
                    rowCount++;
                }                
            }
            workbook.Close();
            excelObj = null;
        }
    }
}
