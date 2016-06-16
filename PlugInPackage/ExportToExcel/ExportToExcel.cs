using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoGUIView;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PlugInPackage.ExportToExcel
{
    public class ExportToExcel : PlugInBase
    {
        /// <summary>
        ///     内部变量
        /// </summary>
        private static MongoCollection _processCollection;

        /// <summary>
        ///     初始化设定
        /// </summary>
        public ExportToExcel()
        {
            RunLv = PathLv.CollectionLv;
            PlugName = "导出到Excel工具";
            PlugFunction = "将数据集导出到Excel";
        }

        /// <summary>
        ///     运行
        /// </summary>
        /// <returns></returns>
        public override int Run()
        {
            _processCollection = (MongoCollection)PlugObj;
            if (RuntimeMongoDbContext.CollectionFilter.ContainsKey(_processCollection.Name))
            {
                var filter = RuntimeMongoDbContext.CollectionFilter[_processCollection.Name].QueryConditionList;
                Export(_processCollection.FindAs<BsonDocument>(QueryHelper.GetQuery(filter)).ToList(), _processCollection.Name);
            }
            else
            {
                Export(_processCollection.FindAllAs<BsonDocument>().ToList(), _processCollection.Name);
            }
            MessageBox.Show(_processCollection.Name);
            return 0;
        }

        /// <summary>
        ///     导出到Excel
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="filename"></param>
        private static void Export(List<BsonDocument> dataList, string filename,bool IsAutoClose = false)
        {
            var schame = MongoHelper.GetCollectionSchame(_processCollection);
            dynamic excelObj = Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook;
            dynamic worksheet;
            var isNew = false;
            if (File.Exists(filename))
            {
                workbook = excelObj.Workbooks.Open(filename);
                worksheet = workbook.Sheets(1);
            }
            else
            {
                isNew = true;
                workbook = excelObj.WorkBooks.Add();
                worksheet = workbook.Sheets(1);
            }
            worksheet.Select();
            worksheet.Name = _processCollection.Name;
            var rowCount = 1;
            var colCount = 1;
            foreach (var item in schame)
            {
                worksheet.Cells(rowCount, colCount).Value = item;
                colCount++;
            }
            rowCount++;
            foreach (var docItem in dataList)
            {
                colCount = 1;
                var isSystem = Operater.IsSystemCollection(_processCollection);
                if (!isSystem)
                {
                    BsonElement id;
                    docItem.TryGetElement(ConstMgr.KeyId, out id);
                    worksheet.Cells(rowCount, colCount).Value = !(id.Value is BsonNull)
                        ? docItem.GetValue(ConstMgr.KeyId).ToString()
                        : "[Empty]";
                }
                else
                {
                    worksheet.Cells(rowCount, colCount).Value = docItem.GetValue(schame[0]).ToString();
                }
                //OtherItems
                for (var i = isSystem ? 1 : 0; i < schame.Count; i++)
                {
                    if (schame[i] == ConstMgr.KeyId)
                    {
                        continue;
                    }
                    BsonValue val;
                    docItem.TryGetValue(schame[i], out val);
                    worksheet.Cells(rowCount, i + 1).Value = val == null
                        ? string.Empty
                        : ViewHelper.ConvertToString(val);
                }
                rowCount++;
            }

            if (IsAutoClose)
            {
                if (isNew)
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
}