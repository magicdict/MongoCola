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
using MongoUtility.Operation;

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
        public DataFilter mDataFilter;

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
        public string strDBTag;

        /// <summary>
        ///     是否为Admin数据库
        /// </summary>
        public bool IsAdminDB
        {
            get
            {
                var strNodeData = strDBTag.Split(":".ToCharArray())[1];
                var DataList = strNodeData.Split("/".ToCharArray());
                if (DataList[(int) EnumMgr.PathLv.DatabaseLv] == ConstMgr.DATABASE_NAME_ADMIN)
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
                var strNodeData = strDBTag.Split(":".ToCharArray())[1];
                var DataList = strNodeData.Split("/".ToCharArray());
                return OperationHelper.IsSystemCollection(DataList[(int) EnumMgr.PathLv.DatabaseLv],
                    DataList[(int) EnumMgr.PathLv.CollectionLv]);
            }
        }

        /// <summary>
        ///     获得展示数据
        /// </summary>
        /// <param name="CurrentDataViewInfo"></param>
        public static List<BsonDocument> GetDataList(ref DataViewInfo CurrentDataViewInfo, MongoServer mServer)
        {
            var collectionPath = CurrentDataViewInfo.strDBTag.Split(":".ToCharArray())[1];
            var cp = collectionPath.Split("/".ToCharArray());
            MongoCollection mongoCol =
                mServer.GetDatabase(cp[(int) EnumMgr.PathLv.DatabaseLv])
                    .GetCollection(cp[(int) EnumMgr.PathLv.CollectionLv]);


            MongoCursor<BsonDocument> cursor;
            //Query condition:
            if (CurrentDataViewInfo.IsUseFilter)
            {
                cursor = mongoCol.FindAs<BsonDocument>(
                    QueryHelper.GetQuery(CurrentDataViewInfo.mDataFilter.QueryConditionList))
                    .SetSkip(CurrentDataViewInfo.SkipCnt)
                    .SetFields(QueryHelper.GetOutputFields(CurrentDataViewInfo.mDataFilter.QueryFieldList))
                    .SetSortOrder(QueryHelper.GetSort(CurrentDataViewInfo.mDataFilter.QueryFieldList))
                    .SetLimit(CurrentDataViewInfo.LimitCnt);
            }
            else
            {
                cursor = mongoCol.FindAllAs<BsonDocument>()
                    .SetSkip(CurrentDataViewInfo.SkipCnt)
                    .SetLimit(CurrentDataViewInfo.LimitCnt);
            }
            CurrentDataViewInfo.Query = cursor.Query != null
                ? cursor.Query.ToJson(Utility.JsonWriterSettings)
                : string.Empty;
            CurrentDataViewInfo.Explain = cursor.Explain().ToJson(Utility.JsonWriterSettings);
            var dataList = cursor.ToList();
            if (CurrentDataViewInfo.SkipCnt == 0)
            {
                if (CurrentDataViewInfo.IsUseFilter)
                {
                    //感谢cnblogs.com 网友Shadower
                    CurrentDataViewInfo.CurrentCollectionTotalCnt =
                        (int) mongoCol.Count(QueryHelper.GetQuery(CurrentDataViewInfo.mDataFilter.QueryConditionList));
                }
                else
                {
                    CurrentDataViewInfo.CurrentCollectionTotalCnt = (int) mongoCol.Count();
                }
            }
            SetPageEnable(ref CurrentDataViewInfo);
            return dataList;
        }

        /// <summary>
        ///     设置导航状态
        /// </summary>
        /// <param name="mDataViewInfo">Data View Information(Structure,Must By Ref)</param>
        public static void SetPageEnable(ref DataViewInfo mDataViewInfo)
        {
            mDataViewInfo.HasPrePage = mDataViewInfo.SkipCnt != 0;
            mDataViewInfo.HasNextPage = (mDataViewInfo.SkipCnt + mDataViewInfo.LimitCnt) <
                                        mDataViewInfo.CurrentCollectionTotalCnt;
        }
    }
}