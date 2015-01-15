using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoGUIView;
using MongoUtility.Basic;
using MongoUtility.Core;

namespace PlugInPackage.ExportToExcel
{
    public class ExportToExcel : PlugInBase
    {
        /// <summary>
        ///     内部变量
        /// </summary>
        private static MongoCollection ProcessCollection;

        /// <summary>
        ///     初始化设定
        /// </summary>
        public ExportToExcel()
        {
            RunLv = PathLv.CollectionLV;
            PlugName = "导出到Excel工具";
            PlugFunction = "将数据集导出到Excel";
        }

        /// <summary>
        ///     运行
        /// </summary>
        /// <returns></returns>
        public override int Run()
        {
            ProcessCollection = (MongoCollection) PlugObj;
            Export(null, null);
            MessageBox.Show(ProcessCollection.Name);
            return 0;
        }

        /// <summary>
        ///     导出到Excel
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="filename"></param>
        private static void Export(List<BsonDocument> dataList, String filename)
        {
            var Schame = Utility.GetCollectionSchame(ProcessCollection);
            dynamic excelObj = Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook;
            dynamic worksheet;
            var IsNew = false;
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
            var rowCount = 1;
            var colCount = 1;
            foreach (var item in Schame)
            {
                worksheet.Cells(rowCount, colCount).Value = item;
                colCount++;
            }
            rowCount++;
            foreach (var docItem in dataList)
            {
                colCount = 1;
                var isSystem = OperationHelper.IsSystemCollection(ProcessCollection);
                if (!isSystem)
                {
                    BsonElement id;
                    docItem.TryGetElement(ConstMgr.KEY_ID, out id);
                    worksheet.Cells(rowCount, colCount).Value = id != null
                        ? docItem.GetValue(ConstMgr.KEY_ID).ToString()
                        : "[Empty]";
                }
                else
                {
                    worksheet.Cells(rowCount, colCount).Value = docItem.GetValue(Schame[0]).ToString();
                }
                //OtherItems
                for (var i = isSystem ? 1 : 0; i < Schame.Count; i++)
                {
                    if (Schame[i] == ConstMgr.KEY_ID)
                    {
                        continue;
                    }
                    BsonValue val;
                    docItem.TryGetValue(Schame[i], out val);
                    worksheet.Cells(rowCount, i + 1).Value = val == null ? "" : ViewHelper.ConvertToString(val);
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