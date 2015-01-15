using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using Utility = Common.Utility;

namespace PlugInPackage
{
    public class ImportAccessDB : PlugInBase
    {
        /// <summary>
        ///     数据连接字符串
        /// </summary>
        private const string ACCESS_CONNECTION_STRING =
            @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=@AccessPath;Persist Security Info=True";

        /// <summary>
        ///     通用的ActionDone事件
        /// </summary>
        public static EventHandler<ActionDoneEventArgs> ActionDone;

        /// <summary>
        /// </summary>
        public ImportAccessDB()
        {
            RunLv = PathLv.ConnectionLV;
            PlugName = "从Access导入";
            PlugFunction = "将数据从Access导入";
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override int Run()
        {
            Utility.OpenForm(new frmSelectTable(), true, true);
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
            var conn = new OleDbConnection(ACCESS_CONNECTION_STRING.Replace("@AccessPath", accessFileName));
            var TableList = new List<string>();
            try
            {
                conn.Open();
                var tblTableList = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                    new object[] {null, null, null, "Table"});
                var strCreateTableInfo = string.Empty;
                foreach (DataRow recTable in tblTableList.Rows)
                {
                    TableList.Add(recTable[2].ToString());
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
            return TableList;
        }

        /// <summary>
        ///     导入数据
        /// </summary>
        /// <param name="accessFileName"></param>
        /// <param name="Table"></param>
        /// <returns></returns>
        public static void ImportAccessDataBase(string accessFileName, List<string> Table, MongoServer mongoSvr)
        {
            var fileName = accessFileName.Split(@"\".ToCharArray());
            var fileMain = fileName[fileName.Length - 1];
            var insertDBName = fileMain.Split(".".ToCharArray())[0];
            var mongoDB = mongoSvr.GetDatabase(insertDBName);
            var conn = new OleDbConnection(ACCESS_CONNECTION_STRING.Replace("@AccessPath", accessFileName));
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
                    if (!Table.Contains(strTableName))
                        continue;
                    try
                    {
                        //不支持UTF....,执行会失败，但是Collection已经添加了
                        string ErrMsg;
                        mongoDB.IsCollectionNameValid(strTableName, out ErrMsg);
                        if (ErrMsg != null)
                        {
                            strCreateTableInfo = strTableName + " Create Error " + Environment.NewLine +
                                                 strCreateTableInfo;
                            OnActionDone(new ActionDoneEventArgs(strTableName + " IsCollectionNameValid Error "));
                            err++;
                            continue;
                        }
                        mongoDB.CreateCollection(strTableName);
                        strCreateTableInfo = strTableName + " Creating " + Environment.NewLine + strCreateTableInfo;
                        OnActionDone(new ActionDoneEventArgs(strTableName + " Creating "));
                    }
                    catch (Exception)
                    {
                        if (mongoDB.CollectionExists(strTableName))
                        {
                            mongoDB.DropCollection(strTableName);
                        }
                        strCreateTableInfo = strTableName + " Create Error " + Environment.NewLine + strCreateTableInfo;
                        OnActionDone(new ActionDoneEventArgs(strTableName + " Creating Error "));
                        err++;
                        continue;
                    }
                    MongoCollection mongoCollection = mongoDB.GetCollection(strTableName);
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
            TABLE_CATALOG,
            TABLE_SCHEMA,
            TABLE_NAME,
            COLUMN_NAME,
            COLUMN_GUID,
            COLUMN_PROPID,
            ORDINAL_POSITION,
            COLUMN_HASDEFAULT,
            COLUMN_DEFAULT,
            COLUMN_FLAGS,
            IS_NULLABLE,
            DATA_TYPE,
            TYPE_GUID,
            CHARACTER_MAXIMUM_LENGTH,
            CHARACTER_OCTET_LENGTH,
            NUMERIC_PRECISION,
            NUMERIC_SCALE,
            DATETIME_PRECISION,
            CHARACTER_SET_CATALOG,
            CHARACTER_SET_SCHEMA,
            CHARACTER_SET_NAME,
            COLLATION_CATALOG,
            COLLATION_SCHEMA,
            COLLATION_NAME,
            DOMAIN_CATALOG,
            DOMAIN_SCHEMA,
            DOMAIN_NAME,
            DESCRIPTION
        }
    }
}