using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Windows.Forms;
namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelpler
    {
        const String AccessConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=@AccessPath;Persist Security Info=True";
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
        private static string GetDataType(int OLEDataType, long ColumnSize, int NumericPrecision, int NumericScale)
        {

            switch (OLEDataType)
            {

                case 2:
                    return "Integer";

                case 3:
                    //Long
                    switch (ColumnSize)
                    {
                        case -1:
                            return "Long";
                        case -2:
                            //AutoNumber
                            return "counter(1,1)";
                        default:
                            return "Long";
                    }
                    break;

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
                    if (ColumnSize == 0)
                    {
                        return "MEMO";
                    }
                    else if (ColumnSize == -1)
                    {
                        return "MEMO";
                    }
                    else
                    {
                        return "VARCHAR";
                        //return "VARCHAR(" + ColumnSize + ")";
                    }
                    break;

                case 131:
                    //decimal
                    return "decimal(" + NumericPrecision + "," + NumericScale + ")";

                case 128:
                    if (ColumnSize == -1)
                    {
                        return "MEMO";
                    }
                    else if (ColumnSize == 0)
                    {
                        return "MENO";
                        //OLE Object
                    }
                    else
                    {
                        return "VARCHAR";
                        //return "VARCHAR(" + ColumnSize + ")";
                    }
                    break;

                default:
                    if (ColumnSize == -1)
                    {
                        return "MEMO";
                    }
                    else
                    {
                        return "VARCHAR";
                        //return "VARCHAR(" + ColumnSize + ")";
                    }
                    break;

            }
            return null;
        }
        public static Boolean ImportAccessDataBase(String Accessfilename, String strSvrPath,TreeNode CurrentTreeNode)
        {
            Boolean rtnCode = false;

            MongoServer Mongosrv = GetMongoServerBySvrPath(strSvrPath);
            String[] FileName = Accessfilename.Split(@"\".ToCharArray());
            String FileMain = FileName[FileName.Length - 1];
            String InsertDBName = FileMain.Split(".".ToCharArray())[0];
            MongoDatabase mongodb = Mongosrv.GetDatabase(InsertDBName);
            OleDbConnection conn = new OleDbConnection(AccessConnectionString.Replace("@AccessPath", Accessfilename));
            try
            {
            conn.Open();
            DataTable tblTableList = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
            foreach (DataRow recTable in tblTableList.Rows)
            {
                String strTableName = recTable[2].ToString();
                try
                {
                    //不支持UTF....,执行会失败，但是Collection已经添加了
                    mongodb.CreateCollection(strTableName);

                }
                catch (Exception ex)
                {
                    if (mongodb.CollectionExists(strTableName))
                    {
                        mongodb.DropCollection(strTableName);
                    }
                    continue;                      
                }

                MongoCollection mongoCollection = mongodb.GetCollection(strTableName);
                DataTable tblSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, strTableName, null });
                Dictionary<String, String> ColPro = new Dictionary<String, String>();
                List<String> ColName = new List<string>();
                foreach (DataRow item in tblSchema.Rows)
                {
                    long ColumnWidth;
                    switch ((long)item["COLUMN_FLAGS"])
                    {
                        case 122:
                            ColumnWidth = -1;
                            break;
                        case 90:
                            //AutoNumber
                            ColumnWidth = -2;
                            break;
                        default:
                            if (item["CHARACTER_MAXIMUM_LENGTH"] is DBNull)
                            {
                                ColumnWidth = -3;
                            }
                            else
                            {
                                ColumnWidth = (long)item["CHARACTER_MAXIMUM_LENGTH"];
                            }
                            break;
                    }
                    ColName.Add(item["COLUMN_NAME"].ToString());
                    ColPro.Add(item["COLUMN_NAME"].ToString(), GetDataType((int)item["DATA_TYPE"], ColumnWidth,
                               item["NUMERIC_PRECISION"] is DBNull ? 0 : (int)item["NUMERIC_PRECISION"],
                               item["NUMERIC_SCALE"] is DBNull ? 0 : (int)item["NUMERIC_SCALE"]));
                }
                OleDbCommand mCommand = new OleDbCommand();
                mCommand.Connection = conn;
                mCommand.CommandText = "Select * from " + strTableName;
                OleDbDataAdapter mAdapter = new OleDbDataAdapter();
                DataSet mDataSet = new DataSet();
                mAdapter.SelectCommand = mCommand;
                mAdapter.Fill(mDataSet, strTableName);
                DataTable tblAccessData = mDataSet.Tables[0];
                foreach (DataRow itemRow in tblAccessData.Rows)
                {
                    BsonDocument InsertDoc = new BsonDocument();
                    for (int i = 0; i < ColName.Count; i++)
                    {
                        if (!(itemRow[ColName[i]] is DBNull))
                        {
                            switch (ColPro[ColName[i]])
                            {
                                case "VARCHAR":
                                    InsertDoc.Add(ColName[i], new BsonString(itemRow[ColName[i]].ToString()), true);
                                    break;
                                case "BIT":
                                    //System.Boolean Can't Cast To BSonBoolean....
                                    //O,My LadyGaga
                                    if ((Boolean)itemRow[ColName[i]])
                                    {
                                        InsertDoc.Add(ColName[i], BsonBoolean.True, true);

                                    }
                                    else
                                    {
                                        InsertDoc.Add(ColName[i], BsonBoolean.False, true);
                                    }
                                    break;
                                case "DATETIME":
                                    //O,My LadyGaga
                                    InsertDoc.Add(ColName[i], new BsonDateTime((DateTime)itemRow[ColName[i]]), true);
                                    break;
                                case "Integer":
                                    InsertDoc.Add(ColName[i], (BsonInt32)itemRow[ColName[i]], true);
                                    break;
                                case "Long":
                                    InsertDoc.Add(ColName[i], (BsonInt64)itemRow[ColName[i]], true);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    mongoCollection.Insert<BsonDocument>(InsertDoc);
                }
            }
            CurrentTreeNode.Nodes.Add(FillDataBaseInfoToTreeNode(InsertDBName, Mongosrv, strSvrPath.Split("/".ToCharArray())[0]));
            rtnCode = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
            conn.Close();
            }
            
            return rtnCode;
        }
    }
}
