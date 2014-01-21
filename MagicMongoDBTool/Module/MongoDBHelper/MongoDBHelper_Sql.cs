using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDbHelper
    {
        //http://www.mongodb.org/display/DOCS/SQL+to+Mongo+Mapping+Chart(旧网址)
        //http://docs.mongodb.org/manual/reference/sql-comparison/

        /// <summary>
        ///     Convert Query Sql To DataFilter
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public static DataFilter ConvertQuerySql(String Sql)
        {
            var rtnQuery = new DataFilter();
            Sql = Sql.Trim();
            //引号中的空格用&nbsp;代替，引号以外的东西小写
            Sql = Regular(Sql);
            //先将字符串里面的空格统一成单个空格
            //Select    A,B  From   C ->
            //Select A,B From C
            while (Sql.Contains("  "))
            {
                Sql = Sql.Replace("  ", " ");
            }
            //找出Select ，From ， Group 
            String[] SqlToken = Sql.Split(" ".ToCharArray());

            int SelectStartIndex = -1;
            int FromStartIndex = -1;
            int WhereStartIndex = -1;
            int GroupByStartIndex = -1;
            int OrderByStartIndex = -1;

            for (int i = 0; i < SqlToken.Length; i++)
            {
                switch (SqlToken[i].ToLower())
                {
                    case "select":
                        SelectStartIndex = i;
                        break;
                    case "from":
                        FromStartIndex = i;
                        break;
                    case "where":
                        WhereStartIndex = i;
                        break;
                    case "group":
                        GroupByStartIndex = i;
                        break;
                    case "order":
                        OrderByStartIndex = i;
                        break;
                    default:
                        break;
                }
            }

            String[] KeyWords = {"select", "from", "where", "group", "order"};

            //From - > CollectionName
            GetKeyContent(FromStartIndex, SqlToken, KeyWords);
            MongoCollection mongoCol;
            //if ((strFrom != String.Empty) & SystemManager.GetCurrentDataBase().CollectionExists(strFrom))
            //{
            //    mongoCol = SystemManager.GetCurrentDataBase().GetCollection(strFrom);
            //}
            //else
            //{
            //    return null;
            //}
            //From:由于当前肯定是从固定表里面取数据
            mongoCol = SystemManager.GetCurrentCollection();

            //Select 设定 必须项
            //Select - > FieldList
            String strSelect = GetKeyContent(SelectStartIndex, SqlToken, KeyWords);
            if (strSelect == String.Empty)
            {
                return null;
            }
            List<String> ColumnNameLst = GetCollectionSchame(mongoCol);
            if (strSelect == "*")
            {
                //Select * 
                foreach (String item in ColumnNameLst)
                {
                    var field = new DataFilter.QueryFieldItem();
                    field.ColName = item;
                    field.IsShow = true;
                    field.sortType = DataFilter.SortType.NoSort;
                    rtnQuery.QueryFieldList.Add(field);
                }
            }
            else
            {
                //Select A,B,C 
                foreach (String item in strSelect.Split(",".ToCharArray()))
                {
                    var field = new DataFilter.QueryFieldItem();
                    field.ColName = item;
                    field.IsShow = true;
                    field.sortType = DataFilter.SortType.NoSort;
                    rtnQuery.QueryFieldList.Add(field);
                }
            }

            //Where 设定,可选项
            String strWhere = GetKeyContent(WhereStartIndex, SqlToken, KeyWords);
            if (strWhere != String.Empty)
            {
                rtnQuery.QueryConditionList = SetQueryCondition(strWhere, ColumnNameLst);
            }

            //Order 设定,可选项
            String strOrder = GetKeyContent(OrderByStartIndex, SqlToken, KeyWords);
            if (strOrder != String.Empty)
            {
                SetQueryOrder(rtnQuery, strOrder);
            }


            //Group 设定,可选项
            String strGroup = GetKeyContent(GroupByStartIndex, SqlToken, KeyWords);
            if (strGroup != String.Empty)
            {
                //TODO:Group
            }

            return rtnQuery;
        }

        /// <summary>
        ///     Group
        /// </summary>
        /// <param name="KeyWordStartIndex"></param>
        /// <param name="SqlToken"></param>
        /// <param name="KeyWords"></param>
        /// <returns></returns>
        private static String GetKeyContent(int KeyWordStartIndex, String[] SqlToken, String[] KeyWords)
        {
            String strSelect = String.Empty;
            if (KeyWordStartIndex != -1)
            {
                for (int i = KeyWordStartIndex + 1; i < SqlToken.Length; i++)
                {
                    if (KeyWords.Contains(SqlToken[i].ToLower()))
                    {
                        break;
                    }
                    strSelect += SqlToken[i] + " ";
                }
                strSelect = strSelect.Trim();
            }
            return strSelect;
        }

        /// <summary>
        ///     引号中的空格用&nbsp;代替，引号以外的东西小写
        /// </summary>
        /// <param name="SqlContent"></param>
        /// <returns></returns>
        private static String Regular(String SqlContent)
        {
            Boolean IsInQuote = false;
            String LowerSql = String.Empty;
            for (int i = 0; i < SqlContent.Length; i++)
            {
                if (SqlContent[i].ToString() == "\"")
                {
                    IsInQuote = !IsInQuote;
                    LowerSql += SqlContent[i];
                }
                else
                {
                    if (IsInQuote)
                    {
                        if (SqlContent[i].ToString() == " ")
                        {
                            //权宜之计，如果真的有&nbsp;。。。
                            LowerSql += "&nbsp;";
                        }
                        else
                        {
                            LowerSql += SqlContent[i];
                        }
                    }
                    else
                    {
                        LowerSql += SqlContent[i].ToString().ToLower();
                    }
                }
            }
            return LowerSql;
        }

        /// <summary>
        ///     Order 的设置
        /// </summary>
        /// <param name="CurrentDataFilter"></param>
        /// <param name="SqlContent"></param>
        private static void SetQueryOrder(DataFilter CurrentDataFilter, String SqlContent)
        {
            //如果获得了内容，应该是这个样子的 By A ASC,B DES
            //1.删除By By A ASC,B DES -> A Asc,B Des
            SqlContent = SqlContent.Substring(3);
            //2.通过逗号分隔列表
            //A Asc , B Des ->  A Asc
            //                  B Des
            String[] SortFieldLst = SqlContent.Split(",".ToCharArray());
            //3.分出 Field 和 Order
            foreach (String SortField in SortFieldLst)
            {
                String[] Sortfld = SortField.Trim().Split(" ".ToCharArray());
                for (int i = 0; i < CurrentDataFilter.QueryFieldList.Count; i++)
                {
                    if (CurrentDataFilter.QueryFieldList[i].ColName.ToLower() == Sortfld[0].ToLower())
                    {
                        //无参数时候，默认是升序[Can't Modify]QueryFieldList是一个结构体
                        DataFilter.QueryFieldItem queryfld = CurrentDataFilter.QueryFieldList[i];
                        if (Sortfld.Length == 1)
                        {
                            queryfld.sortType = DataFilter.SortType.Ascending;
                        }
                        else
                        {
                            queryfld.sortType = Sortfld[1].ToLower().StartsWith("d") ? DataFilter.SortType.Descending : DataFilter.SortType.Ascending;
                        }
                        CurrentDataFilter.QueryFieldList[i] = queryfld;
                        break;
                    }
                }
            }
        }

        /// <summary>
        ///     通过Sql文的Where条件和列名称来获取Query条件
        /// </summary>
        /// <param name="SqlContent">Where条件</param>
        /// <param name="ColumnNameLst">列名称</param>
        /// <returns></returns>
        private static List<DataFilter.QueryConditionInputItem> SetQueryCondition(String SqlContent,
            List<String> ColumnNameLst)
        {
            var Conditionlst = new List<DataFilter.QueryConditionInputItem>();
            // (a=1 or b="A") AND c="3" => ( a = 1 or b = "A" ) and c = "3"  
            //1. 除了引号里面的文字，全部小写
            String[] KeyWord = {"(", ")", "=", "or", "and", ">", ">=", "<", "<=", "<>"};
            foreach (String Keyitem in KeyWord)
            {
                SqlContent = SqlContent.Replace(Keyitem, " " + Keyitem + " ");
            }
            while (SqlContent.Contains("  "))
            {
                SqlContent = SqlContent.Replace("  ", " ");
            }
            SqlContent = SqlContent.Trim();
            //从左到右  ( a = 1 or 
            //           b = "A" ) and 
            //           c = "3"  
            String[] Token = SqlContent.Split(" ".ToCharArray());
            var mQueryConditionInputItem = new DataFilter.QueryConditionInputItem();
            mQueryConditionInputItem.StartMark = String.Empty;
            mQueryConditionInputItem.EndMark = String.Empty;

            for (int i = 0; i < Token.Length; i++)
            {
                String strToken = Token[i].Replace("&nbsp;", " ");
                switch (strToken)
                {
                    case "(":
                        mQueryConditionInputItem.StartMark = "(";
                        break;
                    case "=":
                        mQueryConditionInputItem.Compare = DataFilter.CompareEnum.EQ;
                        break;
                    case ">":
                        mQueryConditionInputItem.Compare = DataFilter.CompareEnum.GT;
                        break;
                    case "<":
                        mQueryConditionInputItem.Compare = DataFilter.CompareEnum.LT;
                        break;
                    case ">=":
                        mQueryConditionInputItem.Compare = DataFilter.CompareEnum.GTE;
                        break;
                    case "<=":
                        mQueryConditionInputItem.Compare = DataFilter.CompareEnum.LTE;
                        break;
                    case "<>":
                        mQueryConditionInputItem.Compare = DataFilter.CompareEnum.NE;
                        break;
                    case "or":
                        mQueryConditionInputItem.EndMark = EndMark_OR;
                        Conditionlst.Add(mQueryConditionInputItem);
                        mQueryConditionInputItem = new DataFilter.QueryConditionInputItem();
                        mQueryConditionInputItem.StartMark = String.Empty;
                        mQueryConditionInputItem.EndMark = String.Empty;

                        break;
                    case "and":
                        mQueryConditionInputItem.EndMark = EndMark_AND;
                        Conditionlst.Add(mQueryConditionInputItem);
                        mQueryConditionInputItem = new DataFilter.QueryConditionInputItem();
                        mQueryConditionInputItem.StartMark = String.Empty;
                        mQueryConditionInputItem.EndMark = String.Empty;

                        break;
                    case ")":
                        mQueryConditionInputItem.EndMark = ")";

                        if (i == Token.Length - 1)
                        {
                            mQueryConditionInputItem.EndMark = EndMark_T;
                        }
                        else
                        {
                            if (Token[i + 1] == "or")
                            {
                                mQueryConditionInputItem.EndMark = EndMark_OR_T;
                                i++;
                            }
                            else
                            {
                                if (Token[i + 1] == "and")
                                {
                                    mQueryConditionInputItem.EndMark = EndMark_AND_T;
                                    i++;
                                }
                            }
                        }

                        Conditionlst.Add(mQueryConditionInputItem);
                        mQueryConditionInputItem = new DataFilter.QueryConditionInputItem();
                        mQueryConditionInputItem.StartMark = String.Empty;
                        mQueryConditionInputItem.EndMark = String.Empty;

                        break;
                    default:
                        if (mQueryConditionInputItem.ColName == null)
                        {
                            foreach (String ColName in ColumnNameLst)
                            {
                                if (ColName.ToLower() == strToken.ToLower())
                                {
                                    //小写的复原
                                    mQueryConditionInputItem.ColName = ColName;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            //类型设置
                            if (strToken.StartsWith("\"") & strToken.EndsWith("\""))
                            {
                                mQueryConditionInputItem.Value =
                                    new BsonValueEx(new BsonString(strToken.Replace("\"", "")));
                            }
                            else
                            {
                                mQueryConditionInputItem.Value =
                                    new BsonValueEx(new BsonInt32(Convert.ToInt16(strToken)));
                            }
                        }
                        break;
                }
            }
            if (Token[Token.Length - 1] != ")")
            {
                Conditionlst.Add(mQueryConditionInputItem);
            }
            return Conditionlst;
        }
    }
}