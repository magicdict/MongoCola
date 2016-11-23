using System.Collections.Generic;
using System.IO;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.EventArgs;
using MongoUtility.ToolKit;

namespace MongoUtility.Command
{
    public static class ExportImport
    {
        /// <summary>
        ///     ExportToFile
        /// </summary>
        /// <param name="currentDataViewInfo"></param>
        /// <param name="excelFileName"></param>
        /// <param name="exportType"></param>
        /// <param name="mongoCol"></param>
        public static void ExportToFile(DataViewInfo currentDataViewInfo,
            string excelFileName,
            EnumMgr.ExportType exportType,
            MongoCollection mongoCol)
        {
            MongoCursor<BsonDocument> cursor;
            cursor = mongoCol.FindAllAs<BsonDocument>();
            var dataList = cursor.ToList();
            switch (exportType)
            {
                case EnumMgr.ExportType.Text:
                    ExportToJson(dataList, excelFileName, MongoHelper.JsonWriterSettings);
                    break;
                case EnumMgr.ExportType.Excel:
                case EnumMgr.ExportType.Xml:
                    break;
            }
            MongoHelper.OnActionDone(new ActionDoneEventArgs(" Completed "));
        }

        /// <summary>
        ///     导出到JSON
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="filename"></param>
        /// <param name="settings"></param>
        private static void ExportToJson(List<BsonDocument> dataList, string filename, JsonWriterSettings settings)
        {
            var file = new FileStream(filename, FileMode.Create);
            var sw = new StreamWriter(file);
            sw.Write(dataList.ToJson(settings));
            sw.Flush();
        }
    }
}