using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        public static void ExportToFile(DataViewInfo CurrentDataViewInfo, String ExcelFileName, ExportType exportType)
        {
            MongoCollection mongoCol;
            if (CurrentDataViewInfo == null)
            {
                mongoCol = SystemManager.GetCurrentCollection();
            }
            else
            {
                String collectionPath = CurrentDataViewInfo.strDBTag.Split(":".ToCharArray())[1];
                String[] cp = collectionPath.Split("/".ToCharArray());
                MongoServer mServer = SystemManager.GetCurrentServer();
                mongoCol = mServer.GetDatabase(cp[(int) PathLv.DatabaseLV]).GetCollection(cp[(int) PathLv.CollectionLV]);
            }
            MongoCursor<BsonDocument> cursor;
            //Query condition:
            if (CurrentDataViewInfo != null && CurrentDataViewInfo.IsUseFilter)
            {
                cursor = mongoCol.FindAs<BsonDocument>(GetQuery(CurrentDataViewInfo.mDataFilter.QueryConditionList))
                    .SetFields(GetOutputFields(CurrentDataViewInfo.mDataFilter.QueryFieldList))
                    .SetSortOrder(GetSort(CurrentDataViewInfo.mDataFilter.QueryFieldList));
            }
            else
            {
                cursor = mongoCol.FindAllAs<BsonDocument>();
            }
            List<BsonDocument> dataList = cursor.ToList();
            switch (exportType)
            {
                case ExportType.Excel:
                    ExportToExcel(dataList, ExcelFileName);
                    GC.Collect();
                    break;
                case ExportType.Text:
                    ExportToJson(dataList, ExcelFileName);
                    break;
                case ExportType.XML:
                    break;
                default:
                    break;
            }
            OnActionDone(new ActionDoneEventArgs(" Completeed "));
        }

        /// <summary>
        ///     导出到TEXT
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="filename"></param>
        private static void ExportToJson(List<BsonDocument> dataList, String filename)
        {
            var sw = new StreamWriter(filename, false);
            sw.Write(dataList.ToJson(SystemManager.JsonWriterSettings));
            sw.Close();
        }

        /// <summary>
        ///     导出到Excel
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="filename"></param>
        private static void ExportToExcel(List<BsonDocument> dataList, String filename)
        {
            List<String> Schame = GetCollectionSchame(SystemManager.GetCurrentCollection());
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
            worksheet.Name = SystemManager.GetCurrentCollection().Name;
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
                bool isSystem = IsSystemCollection(SystemManager.GetCurrentCollection());
                if (!isSystem)
                {
                    BsonElement id;
                    docItem.TryGetElement(KEY_ID, out id);
                    if (id != null)
                    {
                        worksheet.Cells(rowCount, colCount).Value = docItem.GetValue(KEY_ID).ToString();
                    }
                    else
                    {
                        worksheet.Cells(rowCount, colCount).Value = "[Empty]";
                    }
                }
                else
                {
                    worksheet.Cells(rowCount, colCount).Value = docItem.GetValue(Schame[0]).ToString();
                }
                //OtherItems
                for (int i = isSystem ? 1 : 0; i < Schame.Count; i++)
                {
                    if (Schame[i] == KEY_ID)
                    {
                        continue;
                    }
                    BsonValue val;
                    docItem.TryGetValue(Schame[i], out val);
                    if (val == null)
                    {
                        worksheet.Cells(rowCount, i + 1).Value = "";
                    }
                    else
                    {
                        worksheet.Cells(rowCount, i + 1).Value = ConvertToString(val);
                    }
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
            //workbook.Close();
            excelObj = null;
        }
    }
}