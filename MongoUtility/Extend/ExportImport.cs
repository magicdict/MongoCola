using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.EventArgs;

namespace MongoUtility.Extend
{
    public static class ExportImport
    {
        /// <summary>
        ///     ExportToFile
        /// </summary>
        /// <param name="CurrentDataViewInfo"></param>
        /// <param name="ExcelFileName"></param>
        /// <param name="exportType"></param>
        /// <param name="mongoCol"></param>
        public static void ExportToFile(DataViewInfo CurrentDataViewInfo,
            String ExcelFileName,
            EnumMgr.ExportType exportType,
            MongoCollection mongoCol)
        {
            MongoCursor<BsonDocument> cursor;
            //Query condition:
            if (CurrentDataViewInfo != null && CurrentDataViewInfo.IsUseFilter)
            {
                cursor = mongoCol.FindAs<BsonDocument>(
                    QueryHelper.GetQuery(CurrentDataViewInfo.mDataFilter.QueryConditionList))
                    .SetFields(QueryHelper.GetOutputFields(CurrentDataViewInfo.mDataFilter.QueryFieldList))
                    .SetSortOrder(QueryHelper.GetSort(CurrentDataViewInfo.mDataFilter.QueryFieldList));
            }
            else
            {
                cursor = mongoCol.FindAllAs<BsonDocument>();
            }
            var dataList = cursor.ToList();
            switch (exportType)
            {
                case EnumMgr.ExportType.Excel:
                    //ExportToExcel(dataList, ExcelFileName);
                    GC.Collect();
                    break;
                case EnumMgr.ExportType.Text:
                    ExportToJson(dataList, ExcelFileName, Utility.JsonWriterSettings);
                    break;
                case EnumMgr.ExportType.Xml:
                    break;
            }
            Utility.OnActionDone(new ActionDoneEventArgs(" Completed "));
        }

        /// <summary>
        ///     导出到JSON
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="filename"></param>
        /// <param name="settings"></param>
        private static void ExportToJson(List<BsonDocument> dataList, String filename, JsonWriterSettings settings)
        {
            var sw = new StreamWriter(filename, false);
            sw.Write(dataList.ToJson(settings));
            sw.Close();
        }
    }
}