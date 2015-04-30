using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.ToolKit;

namespace MongoUtility.Aggregation
{
    public static class SqlHelper
    {
        //http://www.mongodb.org/display/DOCS/SQL+to+Mongo+Mapping+Chart(旧网址)
        //http://docs.mongodb.org/manual/reference/sql-comparison/

        /// <summary>
        ///     Convert Query SqlHelper To DataFilter
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="mongoCol"></param>
        /// <returns></returns>
        public static DataFilter ConvertQuerySql(string sql, MongoCollection mongoCol)
        {
            var rtnQuery = new DataFilter();
            sql = sql.Trim();
            //引号中的空格用&nbsp;代替，引号以外的东西小写
            sql = Regular(sql);
            //先将字符串里面的空格统一成单个空格
            //Select    A,B  From   C ->
            //Select A,B From C
            while (sql.Contains("  "))
            {
                sql = sql.Replace("  ", " ");
            }
            //找出Select ，From ， Group 
            var sqlToken = sql.Split(" ".ToCharArray());

            var selectStartIndex = -1;
            var fromStartIndex = -1;
            var whereStartIndex = -1;
            var groupByStartIndex = -1;
            var orderByStartIndex = -1;

            for (var i = 0; i < sqlToken.Length; i++)
            {
                switch (sqlToken[i].ToLower())
                {
                    case "select":
                        selectStartIndex = i;
                        break;
                    case "from":
                        fromStartIndex = i;
                        break;
                    case "where":
                        whereStartIndex = i;
                        break;
                    case "group":
                        groupByStartIndex = i;
                        break;
                    case "order":
                        orderByStartIndex = i;
                        break;
                }
            }

            string[] keyWords = {"select", "from", "where", "group", "order"};

            //From - > CollectionName
            GetKeyContent(fromStartIndex, sqlToken, keyWords);

            //Select 设定 必须项
            //Select - > FieldList
            var strSelect = GetKeyContent(selectStartIndex, sqlToken, keyWords);
            if (strSelect == string.Empty)
            {
                return null;
            }
            var columnNameLst = MongoHelper.GetCollectionSchame(mongoCol);
            if (strSelect == "*")
            {
                //Select * 
                foreach (var item in columnNameLst)
                {
                    var field = new DataFilter.QueryFieldItem
                    {
                        ColName = item,
                        IsShow = true,
                        SortType = DataFilter.SortType.NoSort
                    };
                    rtnQuery.QueryFieldList.Add(field);
                }
            }
            else
            {
                //Select A,B,C 
                foreach (var item in strSelect.Split(",".ToCharArray()))
                {
                    var field = new DataFilter.QueryFieldItem
                    {
                        ColName = item,
                        IsShow = true,
                        SortType = DataFilter.SortType.NoSort
                    };
                    rtnQuery.QueryFieldList.Add(field);
                }
            }

            //Where 设定,可选项
            var strWhere = GetKeyContent(whereStartIndex, sqlToken, keyWords);
            if (strWhere != string.Empty)
            {
                rtnQuery.QueryConditionList = SetQueryCondition(strWhere, columnNameLst);
            }

            //Order 设定,可选项
            var strOrder = GetKeyContent(orderByStartIndex, sqlToken, keyWords);
            if (strOrder != string.Empty)
            {
                SetQueryOrder(rtnQuery, strOrder);
            }


            //Group 设定,可选项
            var strGroup = GetKeyContent(groupByStartIndex, sqlToken, keyWords);
            if (strGroup != string.Empty)
            {
                //TODO:Group
            }

            return rtnQuery;
        }

        /// <summary>
        ///     Group
        /// </summary>
        /// <param name="keyWordStartIndex"></param>
        /// <param name="sqlToken"></param>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        private static string GetKeyContent(int keyWordStartIndex, string[] sqlToken, string[] keyWords)
        {
            var strSelect = string.Empty;
            if (keyWordStartIndex != -1)
            {
                for (var i = keyWordStartIndex + 1; i < sqlToken.Length; i++)
                {
                    if (keyWords.Contains(sqlToken[i].ToLower()))
                    {
                        break;
                    }
                    strSelect += sqlToken[i] + " ";
                }
                strSelect = strSelect.Trim();
            }
            return strSelect;
        }

        /// <summary>
        ///     引号中的空格用代替，引号以外的东西小写
        /// </summary>
        /// <param name="sqlContent"></param>
        /// <returns></returns>
        private static string Regular(string sqlContent)
        {
            var isInQuote = false;
            var lowerSql = string.Empty;
            for (var i = 0; i < sqlContent.Length; i++)
            {
                if (sqlContent[i].ToString() == "\"")
                {
                    isInQuote = !isInQuote;
                    lowerSql += sqlContent[i];
                }
                else
                {
                    if (isInQuote)
                    {
                        if (sqlContent[i].ToString() == " ")
                        {
                            //权宜之计，如果真的有&nbsp;。。。
                            lowerSql += "&nbsp;";
                        }
                        else
                        {
                            lowerSql += sqlContent[i];
                        }
                    }
                    else
                    {
                        lowerSql += sqlContent[i].ToString().ToLower();
                    }
                }
            }
            return lowerSql;
        }

        /// <summary>
        ///     Order 的设置
        /// </summary>
        /// <param name="currentDataFilter"></param>
        /// <param name="sqlContent"></param>
        private static void SetQueryOrder(DataFilter currentDataFilter, string sqlContent)
        {
            //如果获得了内容，应该是这个样子的 By A ASC,B DES
            //1.删除By By A ASC,B DES -> A Asc,B Des
            sqlContent = sqlContent.Substring(3);
            //2.通过逗号分隔列表
            //A Asc , B Des ->  A Asc
            //                  B Des
            var sortFieldLst = sqlContent.Split(",".ToCharArray());
            //3.分出 Field 和 Order
            foreach (var sortField in sortFieldLst)
            {
                var sortfld = sortField.Trim().Split(" ".ToCharArray());
                for (var i = 0; i < currentDataFilter.QueryFieldList.Count; i++)
                {
                    if (currentDataFilter.QueryFieldList[i].ColName.ToLower() == sortfld[0].ToLower())
                    {
                        //无参数时候，默认是升序[Can't Modify]QueryFieldList是一个结构体
                        var queryfld = currentDataFilter.QueryFieldList[i];
                        if (sortfld.Length == 1)
                        {
                            queryfld.SortType = DataFilter.SortType.Ascending;
                        }
                        else
                        {
                            queryfld.SortType = sortfld[1].ToLower().StartsWith("d")
                                ? DataFilter.SortType.Descending
                                : DataFilter.SortType.Ascending;
                        }
                        currentDataFilter.QueryFieldList[i] = queryfld;
                        break;
                    }
                }
            }
        }

        /// <summary>
        ///     通过Sql文的Where条件和列名称来获取Query条件
        /// </summary>
        /// <param name="sqlContent">Where条件</param>
        /// <param name="columnNameLst">列名称</param>
        /// <returns></returns>
        private static List<DataFilter.QueryConditionInputItem> SetQueryCondition(string sqlContent,
            List<string> columnNameLst)
        {
            var conditionlst = new List<DataFilter.QueryConditionInputItem>();
            // (a=1 or b="A") AND c="3" => ( a = 1 or b = "A" ) and c = "3"  
            //1. 除了引号里面的文字，全部小写
            string[] keyWord = {"(", ")", "=", "or", "and", ">", ">=", "<", "<=", "<>"};
            foreach (var keyitem in keyWord)
            {
                sqlContent = sqlContent.Replace(keyitem, " " + keyitem + " ");
            }
            while (sqlContent.Contains("  "))
            {
                sqlContent = sqlContent.Replace("  ", " ");
            }
            sqlContent = sqlContent.Trim();
            //从左到右  ( a = 1 or 
            //           b = "A" ) and 
            //           c = "3"  
            var token = sqlContent.Split(" ".ToCharArray());
            var mQueryConditionInputItem = new DataFilter.QueryConditionInputItem
            {
                StartMark = string.Empty,
                EndMark = string.Empty
            };

            for (var i = 0; i < token.Length; i++)
            {
                var strToken = token[i].Replace("&nbsp;", " ");
                switch (strToken)
                {
                    case "(":
                        mQueryConditionInputItem.StartMark = "(";
                        break;
                    case "=":
                        mQueryConditionInputItem.Compare = DataFilter.CompareEnum.Eq;
                        break;
                    case ">":
                        mQueryConditionInputItem.Compare = DataFilter.CompareEnum.Gt;
                        break;
                    case "<":
                        mQueryConditionInputItem.Compare = DataFilter.CompareEnum.Lt;
                        break;
                    case ">=":
                        mQueryConditionInputItem.Compare = DataFilter.CompareEnum.Gte;
                        break;
                    case "<=":
                        mQueryConditionInputItem.Compare = DataFilter.CompareEnum.Lte;
                        break;
                    case "<>":
                        mQueryConditionInputItem.Compare = DataFilter.CompareEnum.Ne;
                        break;
                    case "or":
                        mQueryConditionInputItem.EndMark = ConstMgr.EndMarkOr;
                        conditionlst.Add(mQueryConditionInputItem);
                        mQueryConditionInputItem = new DataFilter.QueryConditionInputItem
                        {
                            StartMark = string.Empty,
                            EndMark = string.Empty
                        };

                        break;
                    case "and":
                        mQueryConditionInputItem.EndMark = ConstMgr.EndMarkAnd;
                        conditionlst.Add(mQueryConditionInputItem);
                        mQueryConditionInputItem = new DataFilter.QueryConditionInputItem
                        {
                            StartMark = string.Empty,
                            EndMark = string.Empty
                        };

                        break;
                    case ")":
                        mQueryConditionInputItem.EndMark = ")";

                        if (i == token.Length - 1)
                        {
                            mQueryConditionInputItem.EndMark = ConstMgr.EndMarkT;
                        }
                        else
                        {
                            if (token[i + 1] == "or")
                            {
                                mQueryConditionInputItem.EndMark = ConstMgr.EndMarkOrT;
                                i++;
                            }
                            else
                            {
                                if (token[i + 1] == "and")
                                {
                                    mQueryConditionInputItem.EndMark = ConstMgr.EndMarkAndT;
                                    i++;
                                }
                            }
                        }

                        conditionlst.Add(mQueryConditionInputItem);
                        mQueryConditionInputItem = new DataFilter.QueryConditionInputItem
                        {
                            StartMark = string.Empty,
                            EndMark = string.Empty
                        };

                        break;
                    default:
                        if (mQueryConditionInputItem.ColName == null)
                        {
                            foreach (var colName in columnNameLst)
                            {
                                if (colName.ToLower() == strToken.ToLower())
                                {
                                    //小写的复原
                                    mQueryConditionInputItem.ColName = colName;
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
            if (token[token.Length - 1] != ")")
            {
                conditionlst.Add(mQueryConditionInputItem);
            }
            return conditionlst;
        }
    }
}