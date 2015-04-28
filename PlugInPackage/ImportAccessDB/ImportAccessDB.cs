using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.EventArgs;

namespace PlugInPackage.ImportAccessDB
{
    public class ImportAccessDb : PlugInBase
    {
        /// <summary>
        ///     数据连接字符串
        /// </summary>
        private const string AccessConnectionString =
            @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=@AccessPath;Persist Security Info=True";

        /// <summary>
        ///     通用的ActionDone事件
        /// </summary>
        public static EventHandler<ActionDoneEventArgs> ActionDone;

        /// <summary>
        /// </summary>
        public ImportAccessDb()
        {
            RunLv = PathLv.ConnectionLv;
            PlugName = "从Access导入";
            PlugFunction = "将数据从Access导入";
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override int Run()
        {
            Utility.OpenForm(new FrmSelectTable(), true, true);
            return 0;
        }

        /// <summary>
        ///     OnActionDone
        /// </summary>
        /// <param name="e"></param>
        public static void OnActionDone(ActionDoneEventArgs e)
        {
            e.Raise(null, ref ActionDone);
        }

        //GetOleDbSchemaTable Is Not Supported In MONO

        /// <summary>
        ///     获得数据类型
        /// </summary>
        /// <param name="oleDataType"></param>
        /// <param name="columnSize"></param>
        /// <param name="numericPrecision"></param>
        /// <param name="numericScale"></param>
        /// <returns></returns>
        private static string GetDataType(int oleDataType, long columnSize, int numericPrecision, int numericScale)
        {
            switch (oleDataType)
            {
                case 2:
                    return "Integer";

                case 3:
                    //Long
                    switch (columnSize)
                    {
                        case -1:
                            return "Long";
                        case -2:
                            //AutoNumber
                            return "counter(1,1)";
                        default:
                            return "Long";
                    }
                    //break;

                case 4:
                    return "Single";

                case 5:
                    return "Double";

                case 6:
                    //CURRECY
                    return "Money";

                case 7:
                    return "DATETIME";

                case 11:
                    //Yes/No fields
                    return "BIT";

                case 17:
                    return "BYTE";

                case 72:
                    return "MEMO";

                case 130:
                    if (columnSize == 0)
                    {
                        return "MEMO";
                    }
                    if (columnSize == -1)
                    {
                        return "MEMO";
                    }
                    return "VARCHAR";
                //return "VARCHAR(" + ColumnSize + ")";
                //break;

                case 131:
                    //decimal
                    return "decimal(" + numericPrecision + "," + numericScale + ")";

                case 128:
                    if (columnSize == -1)
                    {
                        return "MEMO";
                    }
                    if (columnSize == 0)
                    {
                        return "MENO";
                        //OLE Object
                    }
                    return "VARCHAR";
                //return "VARCHAR(" + ColumnSize + ")";
                //break;

                default:
                    if (columnSize == -1)
                    {
                        return "MEMO";
                    }
                    return "VARCHAR";
                //return "VARCHAR(" + ColumnSize + ")";
                //break;
            }
            //return null;
        }

        public static List<string> GetTableList(string accessFileName)
        {
            var conn = new OleDbConnection(AccessConnectionString.Replace("@AccessPath", accessFileName));
            var tableList = new List<string>();
            try
            {
                conn.Open();
                var tblTableList = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                    new object[] {null, null, null, "Table"});
                var strCreateTableInfo = string.Empty;
                foreach (DataRow recTable in tblTableList.Rows)
                {
                    tableList.Add(recTable[2].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return tableList;
        }

        /// <summary>
        ///     导入数据
        /// </summary>
        /// <param name="accessFileName"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public static void ImportAccessDataBase(string accessFileName, List<string> table, MongoServer mongoSvr)
        {
            var fileName = accessFileName.Split(@"\".ToCharArray());
            var fileMain = fileName[fileName.Length - 1];
            var insertDbName = fileMain.Split(".".ToCharArray())[0];
            var mongoDb = mongoSvr.GetDatabase(insertDbName);
            var conn = new OleDbConnection(AccessConnectionString.Replace("@AccessPath", accessFileName));
            try
            {
                conn.Open();
                var err = 0;
                var tblTableList = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                    new object[] {null, null, null, "Table"});
                var strCreateTableInfo = string.Empty;
                foreach (DataRow recTable in tblTableList.Rows)
                {
                    var strTableName = recTable[2].ToString();
                    if (!table.Contains(strTableName))
                        continue;
                    try
                    {
                        //不支持UTF....,执行会失败，但是Collection已经添加了
                        string errMsg;
                        mongoDb.IsCollectionNameValid(strTableName, out errMsg);
                        if (errMsg != null)
                        {
                            strCreateTableInfo = strTableName + " Create Error " + Environment.NewLine +
                                                 strCreateTableInfo;
                            OnActionDone(new ActionDoneEventArgs(strTableName + " IsCollectionNameValid Error "));
                            err++;
                            continue;
                        }
                        mongoDb.CreateCollection(strTableName);
                        strCreateTableInfo = strTableName + " Creating " + Environment.NewLine + strCreateTableInfo;
                        OnActionDone(new ActionDoneEventArgs(strTableName + " Creating "));
                    }
                    catch (Exception)
                    {
                        if (mongoDb.CollectionExists(strTableName))
                        {
                            mongoDb.DropCollection(strTableName);
                        }
                        strCreateTableInfo = strTableName + " Create Error " + Environment.NewLine + strCreateTableInfo;
                        OnActionDone(new ActionDoneEventArgs(strTableName + " Creating Error "));
                        err++;
                        continue;
                    }
                    MongoCollection mongoCollection = mongoDb.GetCollection(strTableName);
                    var tblSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns,
                        new object[] {null, null, strTableName, null});
                    var colPro = new Dictionary<string, string>();
                    var colName = new List<string>();
                    foreach (DataRow item in tblSchema.Rows)
                    {
                        long columnWidth;
                        switch ((long) item["COLUMN_FLAGS"])
                        {
                            case 122:
                                columnWidth = -1;
                                break;
                            case 90:
                                //AutoNumber
                                columnWidth = -2;
                                break;
                            default:
                                if (item["CHARACTER_MAXIMUM_LENGTH"] is DBNull)
                                {
                                    columnWidth = -3;
                                }
                                else
                                {
                                    columnWidth = (long) item["CHARACTER_MAXIMUM_LENGTH"];
                                }
                                break;
                        }
                        colName.Add(item["COLUMN_NAME"].ToString());
                        colPro.Add(item["COLUMN_NAME"].ToString(), GetDataType((int) item["DATA_TYPE"], columnWidth,
                            item["NUMERIC_PRECISION"] is DBNull ? 0 : (int) item["NUMERIC_PRECISION"],
                            item["NUMERIC_SCALE"] is DBNull ? 0 : (int) item["NUMERIC_SCALE"]));
                    }
                    var cmd = new OleDbCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Select * from " + strTableName;
                    var adapter = new OleDbDataAdapter();
                    var dateSet = new DataSet();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dateSet, strTableName);
                    var tblAccessData = dateSet.Tables[0];
                    foreach (DataRow itemRow in tblAccessData.Rows)
                    {
                        var insertDoc = new BsonDocument();
                        for (var i = 0; i < colName.Count; i++)
                        {
                            if (!(itemRow[colName[i]] is DBNull))
                            {
                                switch (colPro[colName[i]])
                                {
                                    case "VARCHAR":
                                        insertDoc.Add(colName[i], new BsonString(itemRow[colName[i]].ToString()), true);
                                        break;
                                    case "BIT":
                                        //System.Boolean Can't Cast To BSonBoolean....
                                        //O,My LadyGaga
                                        if ((bool) itemRow[colName[i]])
                                        {
                                            insertDoc.Add(colName[i], BsonBoolean.True, true);
                                        }
                                        else
                                        {
                                            insertDoc.Add(colName[i], BsonBoolean.False, true);
                                        }
                                        break;
                                    case "DATETIME":
                                        //O,My LadyGaga
                                        insertDoc.Add(colName[i], new BsonDateTime((DateTime) itemRow[colName[i]]), true);
                                        break;
                                    case "Integer":
                                        var i32 = Convert.ToInt32(itemRow[colName[i]]);
                                        insertDoc.Add(colName[i], (BsonInt32) i32, true);
                                        break;
                                    case "Long":
                                        //itemRow[ColName[i]] the default is Int32 without convert
                                        var lng = Convert.ToInt64(itemRow[colName[i]]);
                                        insertDoc.Add(colName[i], (BsonInt64) lng, true);
                                        break;
                                }
                            }
                        }
                        mongoCollection.Insert(insertDoc);
                    }
                }
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        ///     列信息
        /// </summary>
        internal enum ColumnInfo
        {
            TableCatalog,
            TableSchema,
            TableName,
            ColumnName,
            ColumnGuid,
            ColumnPropid,
            OrdinalPosition,
            ColumnHasdefault,
            ColumnDefault,
            ColumnFlags,
            IsNullable,
            DataType,
            TypeGuid,
            CharacterMaximumLength,
            CharacterOctetLength,
            NumericPrecision,
            NumericScale,
            DatetimePrecision,
            CharacterSetCatalog,
            CharacterSetSchema,
            CharacterSetName,
            CollationCatalog,
            CollationSchema,
            CollationName,
            DomainCatalog,
            DomainSchema,
            DomainName,
            Description
        }
    }
}