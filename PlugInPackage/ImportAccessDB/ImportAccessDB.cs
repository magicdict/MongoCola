using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.EventArgs;
using PlugInPrj;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace PlugInPackage.ImportAccessDB
{
    public class ImportAccessDb : PlugInBase
    {
        /// <summary>
        ///     数据连接字符串(MDB)
        /// </summary>
        private const string MDBConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=@AccessPath;Persist Security Info=True";

        /// <summary>
        ///     数据连接字符串(ACCDB)
        /// </summary>
        private const string ACCDBConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=@AccessPath;Persist Security Info=True";

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
            var frm = new FrmSelectTable();
            frm.mServer = (MongoServer)PlugObj;
            UIAssistant.OpenModalForm(frm, true, true);
            return Success;
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
        //https://support.microsoft.com/en-us/kb/320435
        //ID:Integer
        //备注:WChar
        //货币:Currency
        //日期时间:Date
        //是否:Boolean
        //数字（长整形）:Integer
        //数字（单精度）:Single
        //数字（双精度）:Double
        //数字（同步复制ID）:Guid
        //数字（小数）:Numeric
        //数字（整型）:SmallInt
        //数字（字节）:UnsignedTinyInt
        //文本:WChar

        /// <summary>
        ///     获得数据类型
        /// </summary>
        /// <param name="oleDataType"></param>
        /// <param name="columnSize"></param>
        /// <param name="numericPrecision"></param>
        /// <param name="numericScale"></param>
        /// <returns></returns>
        private static string GetDataType(OleDbType oleDataType, long columnSize, int numericPrecision, int numericScale)
        {
            switch (oleDataType)
            {
                case OleDbType.SmallInt:
                    return "Integer";
                case OleDbType.Integer:
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
                case OleDbType.Single:
                    return "Single";
                case OleDbType.Double:
                    return "Double";
                case OleDbType.Numeric:
                    return "Numeric";
                case OleDbType.UnsignedTinyInt:
                    return "Byte";
                case OleDbType.Currency:
                    //CURRECY
                    return "Currency";
                case OleDbType.Date:
                    return "Date";
                case OleDbType.Boolean:
                    //Yes/No fields
                    return "Boolean";
                case OleDbType.Decimal:
                    //decimal
                    return "Decimal";
                case OleDbType.Guid:
                    //同步复制ID
                    return "Guid";
                case OleDbType.WChar:
                    return "Memo";
                default:
                    if (columnSize == -1) return "Memo";
                    return "VARCHAR";
            }
        }
        /// <summary>
        ///     获得字段列表
        /// </summary>
        /// <param name="accessFileName"></param>
        /// <returns></returns>
        public static List<string> GetTableList(string accessFileName)
        {
            var connectionstring = string.Empty;
            if (accessFileName.EndsWith("accdb"))
            {
                connectionstring = ACCDBConnectionString.Replace("@AccessPath", accessFileName);
            }
            else
            {
                connectionstring = MDBConnectionString.Replace("@AccessPath", accessFileName);
            }
            var conn = new OleDbConnection(connectionstring);
            var tableList = new List<string>();
            try
            {
                conn.Open();
                var tblTableList = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "Table" });
                var strCreateTableInfo = string.Empty;
                foreach (DataRow recTable in tblTableList.Rows)
                {
                    tableList.Add(recTable[2].ToString());
                }
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
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
            var connectionstring = string.Empty;
            if (accessFileName.EndsWith("accdb"))
            {
                connectionstring = ACCDBConnectionString.Replace("@AccessPath", accessFileName);
            }
            else
            {
                connectionstring = MDBConnectionString.Replace("@AccessPath", accessFileName);
            }
            var conn = new OleDbConnection(connectionstring);
            try
            {
                conn.Open();
                var err = 0;
                var tblTableList = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "Table" });
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
                        if (mongoDb.CollectionExists(strTableName))
                        {
                            mongoDb.GetCollection(strTableName).RemoveAll();
                        }
                        else
                        {
                            mongoDb.CreateCollection(strTableName);
                        }
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
                        new object[] { null, null, strTableName, null });
                    var colPro = new Dictionary<string, string>();
                    var colName = new List<string>();
                    var Debug = string.Empty;
                    foreach (DataRow item in tblSchema.Rows)
                    {
                        long columnWidth;
                        //VS15可以不用这个转换
                        switch ((long)item["COLUMN_FLAGS"])
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
                                    columnWidth = (long)item["CHARACTER_MAXIMUM_LENGTH"];
                                }
                                break;
                        }
                        colName.Add(item["COLUMN_NAME"].ToString());
                        colPro.Add(item["COLUMN_NAME"].ToString(), GetDataType((OleDbType)item["DATA_TYPE"], columnWidth,
                            item["NUMERIC_PRECISION"] is DBNull ? 0 : (int)item["NUMERIC_PRECISION"],
                            item["NUMERIC_SCALE"] is DBNull ? 0 : (short)item["NUMERIC_SCALE"]));

                        Debug += item["COLUMN_NAME"].ToString() + ":" + ((OleDbType)item["DATA_TYPE"]).ToString() + System.Environment.NewLine;
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
                                    case "Memo":
                                        insertDoc.Add(colName[i], new BsonString(itemRow[colName[i]].ToString()), true);
                                        break;
                                    case "Boolean":
                                        if ((bool)itemRow[colName[i]])
                                        {
                                            insertDoc.Add(colName[i], BsonBoolean.True, true);
                                        }
                                        else
                                        {
                                            insertDoc.Add(colName[i], BsonBoolean.False, true);
                                        }
                                        break;
                                    case "Date":
                                        insertDoc.Add(colName[i], new BsonDateTime((DateTime)itemRow[colName[i]]), true);
                                        break;
                                    case "Integer":
                                    case "Guid":
                                        var i32 = Convert.ToInt32(itemRow[colName[i]]);
                                        insertDoc.Add(colName[i], (BsonInt32)i32, true);
                                        break;
                                    case "Single":
                                        var sgl = Convert.ToSingle(itemRow[colName[i]]);
                                        insertDoc.Add(colName[i], sgl, true);
                                        break;
                                    case "Long":
                                        var lng = Convert.ToInt64(itemRow[colName[i]]);
                                        insertDoc.Add(colName[i], (BsonInt64)lng, true);
                                        break;
                                    case "Decimal":
                                        var dec = Convert.ToDecimal(itemRow[colName[i]]);
                                        insertDoc.Add(colName[i], dec, true);
                                        break;
                                    case "Double":
                                        var dou = Convert.ToDouble(itemRow[colName[i]]);
                                        insertDoc.Add(colName[i], dou, true);
                                        break;
                                    case "Numeric":
                                        var num = Convert.ToDouble(itemRow[colName[i]]);
                                        insertDoc.Add(colName[i], num, true);
                                        break;
                                    case "Currency":
                                        var cur = Convert.ToDouble(itemRow[colName[i]]);
                                        insertDoc.Add(colName[i], cur, true);
                                        break;
                                    case "Byte":
                                        var byt = Convert.ToByte(itemRow[colName[i]]);
                                        insertDoc.Add(colName[i], byt, true);
                                        break;
                                }
                            }
                            else
                            {
                                insertDoc.Add(colName[i], BsonNull.Value, true);
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
    }
}