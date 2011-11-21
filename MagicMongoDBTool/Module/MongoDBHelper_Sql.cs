using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        public static DataFilter ConvertFromSql(String Sql)
        {
            DataFilter rtnQuery = new DataFilter();
            //先将字符串里面的空格统一成单个空格
            //Select    A,B  From   C ->
            //Select A,B From C
            Sql = Sql.Trim();
            while (Sql.Contains("  "))
            {
                Sql = Sql.Replace("  ", " ");
            }
            //找出Select ，From ， Group 
            String[] SqlToken = Sql.Split(" ".ToCharArray());

            int StartIndex = 0;

            //Select
            String strSelect = String.Empty;
            if (SqlToken[StartIndex].ToLower() == "select")
            {
                for (int i = StartIndex; i < SqlToken.Length; i++)
                {
                    switch (SqlToken[i].ToLower())
                    {
                        case "select":
                            break;
                        case "from":
                            StartIndex = i;
                            i = SqlToken.Length;
                            break;
                        default:
                            strSelect += SqlToken[i] + " ";
                            break;
                    }
                }
            }

            //from
            String StrFrom = String.Empty;
            if (SqlToken[StartIndex].ToLower() == "from")
            {
                for (int i = StartIndex; i < SqlToken.Length; i++)
                {
                    switch (SqlToken[i].ToLower())
                    {
                        case "from":
                            break;
                        case "where":
                            StartIndex = i;
                            i = SqlToken.Length;
                            break;
                        default:
                            StrFrom += SqlToken[i] + " ";
                            break;
                    }
                }
            }

            //where
            String StrWhere = String.Empty;
            if (SqlToken[StartIndex].ToLower() == "where")
            {
                for (int i = StartIndex; i < SqlToken.Length; i++)
                {
                    switch (SqlToken[i].ToLower())
                    {
                        case "where":
                            break;
                        case "groupby":
                            StartIndex = i;
                            i = SqlToken.Length;
                            break;
                        default:
                            StrWhere += SqlToken[i] + " ";
                            break;
                    }
                }
            }

            //groupby
            String StrGroupby = String.Empty;
            if (SqlToken[StartIndex].ToLower() == "groupby")
            {
                for (int i = StartIndex; i < SqlToken.Length; i++)
                {
                    switch (SqlToken[i].ToLower())
                    {
                        case "groupby":
                            break;
                        default:
                            StrGroupby += SqlToken[i] + " ";
                            break;
                    }
                }
            }

            strSelect = strSelect.Trim();
            StrFrom = StrFrom.Trim();
            StrWhere = StrWhere.Trim();
            StrGroupby = StrGroupby.Trim();

            //From - > CollectionName
            if (StrFrom == String.Empty) { 
                return null;            
            }
            MongoCollection mongoCol = SystemManager.GetCurrentDataBase().GetCollection(StrFrom);

            //Select 设定
            if (strSelect == "*")
            {
                foreach (String item in MongoDBHelper.GetCollectionSchame(mongoCol))
                {
                    DataFilter.QueryFieldItem t = new DataFilter.QueryFieldItem();
                    t.ColName = item;
                    t.IsShow = true;
                    t.sortType = DataFilter.SortType.NoSort;
                    rtnQuery.QueryFieldList.Add(t);
                }
            }
            else
            {
                foreach (String item in strSelect.Split(",".ToCharArray()))
                {
                    DataFilter.QueryFieldItem t = new DataFilter.QueryFieldItem();
                    t.ColName = item;
                    t.IsShow = true;
                    t.sortType = DataFilter.SortType.NoSort;
                    rtnQuery.QueryFieldList.Add(t);
                }

            }

            
            return rtnQuery;
        }

        public static List<DataFilter.QueryConditionInputItem> GetQueryCondition(String Sql)
        {
            List<DataFilter.QueryConditionInputItem> Conditionlst = new List<DataFilter.QueryConditionInputItem>();

            return Conditionlst;
        }
    }
}