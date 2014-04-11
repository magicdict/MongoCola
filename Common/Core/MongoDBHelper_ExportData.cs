using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using Common.Aggregation;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDbHelper
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
                mongoCol = mServer.GetDatabase(cp[(int) PathLv.DatabaseLv]).GetCollection(cp[(int) PathLv.CollectionLv]);
            }
            MongoCursor<BsonDocument> cursor;
            //Query condition:
            if (CurrentDataViewInfo != null && CurrentDataViewInfo.IsUseFilter)
            {
                cursor = mongoCol.FindAs<BsonDocument>(QueryHelper.GetQuery(CurrentDataViewInfo.mDataFilter.QueryConditionList))
                    .SetFields(QueryHelper.GetOutputFields(CurrentDataViewInfo.mDataFilter.QueryFieldList))
                    .SetSortOrder(QueryHelper.GetSort(CurrentDataViewInfo.mDataFilter.QueryFieldList));
            }
            else
            {
                cursor = mongoCol.FindAllAs<BsonDocument>();
            }
            List<BsonDocument> dataList = cursor.ToList();
            switch (exportType)
            {
                case ExportType.Excel:
                    //ExportToExcel(dataList, ExcelFileName);
                    GC.Collect();
                    break;
                case ExportType.Text:
                    ExportToJson(dataList, ExcelFileName);
                    break;
                case ExportType.Xml:
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
    }
}