using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        /// <summary>
        /// ActionDone
        /// </summary>
        public static EventHandler<ActionDoneEventArgs> ActionDone;
        /// <summary>
        /// OnActionDone
        /// </summary>
        /// <param name="e"></param>
        public static void OnActionDone(ActionDoneEventArgs e)
        {
            e.Raise(null, ref ActionDone);
        }
        //GetOleDbSchemaTable Is Not Supported In MONO
        /// <summary>
        /// 数据连接字符串
        /// </summary>
        private const String ACCESS_CONNECTION_STRING = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=@AccessPath;Persist Security Info=True";
        /// <summary>
        /// 列信息
        /// </summary>
        enum ColumnInfo
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
        /// <summary>
        /// 获得数据类型
        /// </summary>
        /// <param name="oleDataType"></param>
        /// <param name="columnSize"></param>
        /// <param name="numericPrecision"></param>
        /// <param name="numericScale"></param>
        /// <returns></returns>
        private static String GetDataType(int oleDataType, long columnSize, int numericPrecision, int numericScale)
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
                    else if (columnSize == -1)
                    {
                        return "MEMO";
                    }
                    else
                    {
                        return "VARCHAR";
                        //return "VARCHAR(" + ColumnSize + ")";
                    }
                //break;

                case 131:
                    //decimal
                    return "decimal(" + numericPrecision + "," + numericScale + ")";

                case 128:
                    if (columnSize == -1)
                    {
                        return "MEMO";
                    }
                    else if (columnSize == 0)
                    {
                        return "MENO";
                        //OLE Object
                    }
                    else
                    {
                        return "VARCHAR";
                        //return "VARCHAR(" + ColumnSize + ")";
                    }
                //break;

                default:
                    if (columnSize == -1)
                    {
                        return "MEMO";
                    }
                    else
                    {
                        return "VARCHAR";
                        //return "VARCHAR(" + ColumnSize + ")";
                    }
                //break;

            }
            //return null;
        }


        public struct ImportAccessPara
        {
            public String accessFileName;
            public String strSvrPathWithTag;
            public TreeNode currentTreeNode;
        }
        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public static void ImportAccessDataBase(Object obj)
        {
            ImportAccessPara parm = (ImportAccessPara)obj;
            MongoServer mongoSvr = GetMongoServerBySvrPath(parm.strSvrPathWithTag);
            String[] fileName = parm.accessFileName.Split(@"\".ToCharArray());
            String fileMain = fileName[fileName.Length - 1];
            String insertDBName = fileMain.Split(".".ToCharArray())[0];
            MongoDatabase mongoDB = mongoSvr.GetDatabase(insertDBName);
            OleDbConnection conn = new OleDbConnection(ACCESS_CONNECTION_STRING.Replace("@AccessPath", parm.accessFileName));
            try
            {
                conn.Open();
                int err = 0;
                DataTable tblTableList = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
                String strCreateTableInfo = String.Empty;
                foreach (DataRow recTable in tblTableList.Rows)
                {
                    String strTableName = recTable[2].ToString();
                    try
                    {
                        //不支持UTF....,执行会失败，但是Collection已经添加了
                        String ErrMsg;
                        mongoDB.IsCollectionNameValid(strTableName, out ErrMsg);
                        if (ErrMsg != null)
                        {
                            strCreateTableInfo = strTableName + " Create Error " + System.Environment.NewLine + strCreateTableInfo;
                            OnActionDone(new ActionDoneEventArgs(strTableName + " IsCollectionNameValid Error "));
                            err++;
                            continue;
                        }
                        mongoDB.CreateCollection(strTableName);
                        strCreateTableInfo = strTableName + " Creating " + System.Environment.NewLine + strCreateTableInfo;
                        OnActionDone(new ActionDoneEventArgs(strTableName + " Creating "));
                    }
                    catch (Exception)
                    {
                        if (mongoDB.CollectionExists(strTableName))
                        {
                            mongoDB.DropCollection(strTableName);
                        }
                        strCreateTableInfo = strTableName + " Create Error " + System.Environment.NewLine + strCreateTableInfo;
                        OnActionDone(new ActionDoneEventArgs(strTableName + " Creating Error "));
                        err++;
                        continue;
                    }
                    MongoCollection mongoCollection = mongoDB.GetCollection(strTableName);
                    DataTable tblSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, strTableName, null });
                    Dictionary<String, String> colPro = new Dictionary<String, String>();
                    List<String> colName = new List<String>();
                    foreach (DataRow item in tblSchema.Rows)
                    {
                        long columnWidth;
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
                        colPro.Add(item["COLUMN_NAME"].ToString(), GetDataType((int)item["DATA_TYPE"], columnWidth,
                                   item["NUMERIC_PRECISION"] is DBNull ? 0 : (int)item["NUMERIC_PRECISION"],
                                   item["NUMERIC_SCALE"] is DBNull ? 0 : (int)item["NUMERIC_SCALE"]));
                    }
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Select * from " + strTableName;
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    DataSet dateSet = new DataSet();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dateSet, strTableName);
                    DataTable tblAccessData = dateSet.Tables[0];
                    foreach (DataRow itemRow in tblAccessData.Rows)
                    {
                        BsonDocument insertDoc = new BsonDocument();
                        for (int i = 0; i < colName.Count; i++)
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
                                        if ((bool)itemRow[colName[i]])
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
                                        insertDoc.Add(colName[i], new BsonDateTime((DateTime)itemRow[colName[i]]), true);
                                        break;
                                    case "Integer":
                                        Int32 i32 = Convert.ToInt32(itemRow[colName[i]]);
                                        insertDoc.Add(colName[i], (BsonInt32)i32, true);
                                        break;
                                    case "Long":
                                        //itemRow[ColName[i]] the default is Int32 without convert
                                        long lng = Convert.ToInt64(itemRow[colName[i]]);
                                        insertDoc.Add(colName[i], (BsonInt64)lng, true);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        mongoCollection.Insert<BsonDocument>(insertDoc);
                    }
                }
                String strSvrPath = SystemManager.GetTagData(parm.strSvrPathWithTag);
                String strKey = strSvrPath.Split("/".ToCharArray())[(int)MongoDBHelper.PathLv.ConnectionLV] + "/" +
                                strSvrPath.Split("/".ToCharArray())[(int)MongoDBHelper.PathLv.InstanceLV];
                parm.currentTreeNode.Nodes.Add(FillDataBaseInfoToTreeNode(insertDBName, mongoSvr, strKey));
                MyMessageBox.ShowMessage("Import Message", (tblTableList.Rows.Count - err).ToString() + "Created   " + err + "failed", strCreateTableInfo, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

