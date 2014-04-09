using Common;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        ///     主键
        /// </summary>
        public const String KEY_ID = "_id";
        /// <summary>
        ///     通过读取N条记录来确定数据集结构
        /// </summary>
        /// <param name="mongoCol">数据集</param>
        /// <returns></returns>
        public static List<String> GetCollectionSchame(MongoCollection mongoCol)
        {
            int CheckRecordCnt = 100;
            var _ColumnList = new List<String>();
            var _dataList = new List<BsonDocument>();
            _dataList = mongoCol.FindAllAs<BsonDocument>()
                .SetLimit(CheckRecordCnt)
                .ToList();
            foreach (BsonDocument doc in _dataList)
            {
                foreach (string item in getBsonNameList(String.Empty, doc))
                {
                    if (!_ColumnList.Contains(item))
                    {
                        _ColumnList.Add(item);
                    }
                }
            }
            return _ColumnList;
        }
        /// <summary>
        ///     取得名称列表[递归获得嵌套]
        /// </summary>
        /// <param name="docName"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static List<String> getBsonNameList(String docName, BsonDocument doc)
        {
            var _ColumnList = new List<String>();
            foreach (String strName in doc.Names)
            {
                if (doc.GetValue(strName).IsBsonDocument)
                {
                    //包含子文档的时候
                    _ColumnList.Add(strName);
                    foreach (string item in getBsonNameList(strName, doc.GetValue(strName).AsBsonDocument))
                    {
                        _ColumnList.Add(item);
                    }
                }
                else
                {
                    _ColumnList.Add(docName + (docName != String.Empty ? "." : String.Empty) + strName);
                }
            }
            return _ColumnList;
        }
        /// <summary>
        ///     是否为系统数据集[无法删除]
        /// </summary>
        /// <param name="mongoCol"></param>
        /// <returns></returns>
        public static Boolean IsSystemCollection(MongoCollection mongoCol)
        {
            //系统
            if (mongoCol.Name.StartsWith("system."))
            {
                return true;
            }
            //文件
            if (mongoCol.Name.StartsWith("fs."))
            {
                return true;
            }
            //local数据库,默认为系统
            if (mongoCol.Database.Name == "local")
            {
                return true;
            }
            //config数据库,默认为系统
            if (mongoCol.Database.Name == "config")
            {
                return true;
            }

            return false;
        }
        /// <summary>
        ///     BsonValue转展示用字符
        /// </summary>
        /// <param name="bsonValue"></param>
        /// <returns></returns>
        public static String ConvertToString(BsonValue bsonValue)
        {
            //二进制数据
            if (bsonValue.IsBsonBinaryData)
            {
                return "[Binary]";
            }
            //空值
            if (bsonValue.IsBsonNull)
            {
                return "[Empty]";
            }
            //文档
            if (bsonValue.IsBsonDocument)
            {
                return bsonValue + "[Contains" + bsonValue.ToBsonDocument().ElementCount + "Documents]";
            }
            //时间
            if (bsonValue.IsBsonDateTime)
            {
                DateTime bsonData = bsonValue.ToUniversalTime();
                //@flydreamer提出的本地化时间要求
                return bsonData.ToLocalTime().ToString();
            }

            //字符
            if (bsonValue.IsString)
            {
                //只有在字符的时候加上""
                return "\"" + bsonValue + "\"";
            }

            //其他
            return bsonValue.ToString();
        }

        /// <summary>
        ///     导出到Excel
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="filename"></param>
        private static void T(List<BsonDocument> dataList, String filename)
        {
            List<String> Schame = GetCollectionSchame(ProcessCollection);
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
                bool isSystem = IsSystemCollection(ProcessCollection);
                if (!isSystem)
                {
                    BsonElement id;
                    docItem.TryGetElement(KEY_ID, out id);
                    worksheet.Cells(rowCount, colCount).Value = id != null
                        ? docItem.GetValue(KEY_ID).ToString()
                        : "[Empty]";
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
                    worksheet.Cells(rowCount, i + 1).Value = val == null ? "" : ConvertToString(val);
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