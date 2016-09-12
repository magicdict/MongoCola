/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/6
 * Time: 11:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.ToolKit;

namespace MongoUtility.Aggregation
{
    /// <summary>
    ///     多数据集视图中，每个数据集保留一个DataViewInfo
    /// </summary>
    public class DataViewInfo
    {
        /// <summary>
        ///     数据集总记录数
        /// </summary>
        public int CurrentCollectionTotalCnt;

        /// <summary>
        ///     解释
        /// </summary>
        public string Explain;

        /// <summary>
        ///     是否存在下一页
        /// </summary>
        public bool HasNextPage;

        /// <summary>
        ///     是否存在上一页
        /// </summary>
        public bool HasPrePage;

        /// <summary>
        ///     是否为只读
        /// </summary>
        public bool IsReadOnly;

        /// <summary>
        ///     是否为SafeMode
        /// </summary>
        public bool IsSafeMode;

        /// <summary>
        ///     是否使用过滤器
        /// </summary>
        public bool IsUseFilter;

        /// <summary>
        ///     每页显示数
        /// </summary>
        public int LimitCnt;

        /// <summary>
        ///     数据过滤器
        /// </summary>
        public DataFilter MDataFilter;

        /// <summary>
        ///     查询
        /// </summary>
        public string Query;

        /// <summary>
        ///     Skip记录数
        /// </summary>
        public int SkipCnt;

        /// <summary>
        ///     数据库
        /// </summary>
        public string StrDbTag;

        /// <summary>
        ///     是否为Admin数据库
        /// </summary>
        public bool IsAdminDb
        {
            get
            {
                var strNodeData = StrDbTag.Split(":".ToCharArray())[1];
                var dataList = strNodeData.Split("/".ToCharArray());
                if (dataList[(int) EnumMgr.PathLevel.Database] == ConstMgr.DatabaseNameAdmin)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        ///     是否为系统数据集
        /// </summary>
        public bool IsSystemCollection
        {
            get
            {
                var strNodeData = StrDbTag.Split(":".ToCharArray())[1];
                var dataList = strNodeData.Split("/".ToCharArray());
                return Operater.IsSystemCollection(dataList[(int) EnumMgr.PathLevel.Database],
                    dataList[(int) EnumMgr.PathLevel.Collection]);
            }
        }

        /// <summary>
        ///     获得展示数据
        /// </summary>
        /// <param name="currentDataViewInfo"></param>
        /// <param name="mServer"></param>
        public static List<BsonDocument> GetDataList(ref DataViewInfo currentDataViewInfo, MongoServer mServer)
        {
            var collectionPath = currentDataViewInfo.StrDbTag.Split(":".ToCharArray())[1];
            var cp = collectionPath.Split("/".ToCharArray());
            MongoCollection mongoCol =
                mServer.GetDatabase(cp[(int) EnumMgr.PathLevel.Database])
                    .GetCollection(cp[(int) EnumMgr.PathLevel.Collection]);


            MongoCursor<BsonDocument> cursor;
            //Query condition:
            if (currentDataViewInfo.IsUseFilter)
            {
                cursor = mongoCol.FindAs<BsonDocument>(
                    QueryHelper.GetQuery(currentDataViewInfo.MDataFilter.QueryConditionList))
                    .SetSkip(currentDataViewInfo.SkipCnt)
                    .SetFields(QueryHelper.GetOutputFields(currentDataViewInfo.MDataFilter.QueryFieldList))
                    .SetSortOrder(QueryHelper.GetSort(currentDataViewInfo.MDataFilter.QueryFieldList))
                    .SetLimit(currentDataViewInfo.LimitCnt);
            }
            else
            {
                cursor = mongoCol.FindAllAs<BsonDocument>()
                    .SetSkip(currentDataViewInfo.SkipCnt)
                    .SetLimit(currentDataViewInfo.LimitCnt);
            }
            currentDataViewInfo.Query = cursor.Query != null
                ? cursor.Query.ToJson(MongoHelper.JsonWriterSettings)
                : string.Empty;
            currentDataViewInfo.Explain = cursor.Explain().ToJson(MongoHelper.JsonWriterSettings);
            var dataList = cursor.ToList();
            if (currentDataViewInfo.SkipCnt == 0)
            {
                if (currentDataViewInfo.IsUseFilter)
                {
                    //感谢cnblogs.com 网友Shadower
                    currentDataViewInfo.CurrentCollectionTotalCnt =
                        (int) mongoCol.Count(QueryHelper.GetQuery(currentDataViewInfo.MDataFilter.QueryConditionList));
                }
                else
                {
                    currentDataViewInfo.CurrentCollectionTotalCnt = (int) mongoCol.Count();
                }
            }
            SetPageEnable(ref currentDataViewInfo);
            return dataList;
        }

        /// <summary>
        ///     设置导航状态
        /// </summary>
        /// <param name="mDataViewInfo">Data View Information(Structure,Must By Ref)</param>
        public static void SetPageEnable(ref DataViewInfo mDataViewInfo)
        {
            mDataViewInfo.HasPrePage = mDataViewInfo.SkipCnt != 0;
            mDataViewInfo.HasNextPage = mDataViewInfo.SkipCnt + mDataViewInfo.LimitCnt <
                                        mDataViewInfo.CurrentCollectionTotalCnt;
        }
    }
}