using Common;
using MongoCola.Module;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ExportToExcel
{
    public class ExportToExcel : PlugBase
    {
        /// <summary>
        /// 内部变量
        /// </summary>
        private static MongoCollection ProcessCollection;

        /// <summary>
        /// 初始化设定
        /// </summary>
        public ExportToExcel()
        {
            base.RunLv = PathLv.CollectionLV;
            base.PlugName = "导出到Excel工具";
            base.PlugFunction = "将数据集导出到Excel";
        }

        /// <summary>
        /// 运行
        /// </summary>
        /// <returns></returns>
        public override int Run()
        {
            ProcessCollection = (MongoCollection)base.PlugObj;
            MessageBox.Show(ProcessCollection.Name);
            return 0;
        }
        /// <summary>
        ///     导出到Excel
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="filename"></param>
        private static void T(List<BsonDocument> dataList, String filename)
        {
            List<String> Schame = MongoDbHelper.GetCollectionSchame(ProcessCollection);
            dynamic excelObj = Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook;
            dynamic worksheet;
            Boolean IsNew = false;
            if (File.Exists(filename))
            {
                workbook = excelObj.Workbooks.Open(filename);
                worksheet = workbook.Sheets(1);
            }
            else
            {
                IsNew = true;
                workbook = excelObj.WorkBooks.Add();
                worksheet = workbook.Sheets(1);
            }
            worksheet.Select();
            worksheet.Name = ProcessCollection.Name;
            int rowCount = 1;
            int colCount = 1;
            foreach (string item in Schame)
            {
                worksheet.Cells(rowCount, colCount).Value = item;
                colCount++;
            }
            rowCount++;
            foreach (BsonDocument docItem in dataList)
            {
                colCount = 1;
                bool isSystem = MongoDbHelper.IsSystemCollection(ProcessCollection);
                if (!isSystem)
                {
                    BsonElement id;
                    docItem.TryGetElement(MongoDbHelper.KEY_ID, out id);
                    worksheet.Cells(rowCount, colCount).Value = id != null
                        ? docItem.GetValue(MongoDbHelper.KEY_ID).ToString()
                        : "[Empty]";
                }
                else
                {
                    worksheet.Cells(rowCount, colCount).Value = docItem.GetValue(Schame[0]).ToString();
                }
                //OtherItems
                for (int i = isSystem ? 1 : 0; i < Schame.Count; i++)
                {
                    if (Schame[i] == MongoDbHelper.KEY_ID)
                    {
                        continue;
                    }
                    BsonValue val;
                    docItem.TryGetValue(Schame[i], out val);
                    worksheet.Cells(rowCount, i + 1).Value = val == null ? "" : MongoDbHelper.ConvertToString(val);
                }
                rowCount++;
            }
            if (IsNew)
            {
                workbook.SaveAs(filename);
            }
            else
            {
                workbook.Save();
            }
            workbook.Close();
            excelObj = null;
        }
    }
}