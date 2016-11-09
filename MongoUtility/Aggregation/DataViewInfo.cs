
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
        ///     是否为View
        /// </summary>
        public bool IsView;

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
        ///     聚合数组(使用聚合框架获取数据)
        /// </summary>
        private BsonArray stages = new BsonArray();

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
        public string strCollectionPath;

        /// <summary>
        ///     是否为Admin数据库
        /// </summary>
        public bool IsAdminDb
        {
            get
            {
                var strNodeData = strCollectionPath.Split(":".ToCharArray())[1];
                var dataList = strNodeData.Split("/".ToCharArray());
                if (dataList[(int)EnumMgr.PathLevel.Database] == ConstMgr.DatabaseNameAdmin)
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
                var strNodeData = strCollectionPath.Split(":".ToCharArray())[1];
                var dataList = strNodeData.Split("/".ToCharArray());
                return Operater.IsSystemCollection(dataList[(int)EnumMgr.PathLevel.Database],
                    dataList[(int)EnumMgr.PathLevel.CollectionAndView]);
            }
        }

        /// <summary>
        ///     获得展示数据
        /// </summary>
        /// <param name="currentDataViewInfo"></param>
        /// <param name="mServer"></param>
        public static List<BsonDocument> GetDataList(ref DataViewInfo currentDataViewInfo, MongoServer mServer)
        {
            var PathArray = currentDataViewInfo.strCollectionPath.Split(":".ToCharArray())[1].Split("/".ToCharArray());
            MongoCollection mongoCol = mServer.GetDatabase(PathArray[(int)EnumMgr.PathLevel.Database]).GetCollection(PathArray[(int)EnumMgr.PathLevel.CollectionAndView]);
            //由于Tab页的关系，这里当前数据集并非DataViewInfo的数据集，所以不能写成下面这个样子
            //var mongoCol = RuntimeMongoDbContext.GetCurrentCollection();
            MongoCursor<BsonDocument> cursor;
            //Query condition:
            //View 不使用自定义过滤器
            if (currentDataViewInfo.IsUseFilter && !currentDataViewInfo.IsView)
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

            if (!currentDataViewInfo.IsView)
            {
                currentDataViewInfo.Explain = cursor.Explain().ToJson(MongoHelper.JsonWriterSettings);
            }

            var dataList = cursor.ToList();

            //https://jira.mongodb.org/browse/SERVER-26802
            //在非正常Shutdown的时候，这个统计结果可能出现错误
            //这个时候需要执行验证数据集命令

            if (currentDataViewInfo.SkipCnt == 0)
            {
                if (currentDataViewInfo.IsUseFilter)
                {
                    //感谢cnblogs.com 网友Shadower
                    currentDataViewInfo.CurrentCollectionTotalCnt =
                        (int)mongoCol.Count(QueryHelper.GetQuery(currentDataViewInfo.MDataFilter.QueryConditionList));
                }
                else
                {
                    currentDataViewInfo.CurrentCollectionTotalCnt = (int)mongoCol.Count();
                }
            }
            SetPageEnable(ref currentDataViewInfo);
            return dataList;
        }

        /// <summary>
        ///     使用聚合框架获得数据
        /// </summary>
        /// <param name="currentDataViewInfo"></param>
        /// <param name="mServer"></param>
        public static List<BsonDocument> GetDataListByAggregation(ref DataViewInfo currentDataViewInfo, MongoServer mServer)
        {
            var PathArray = currentDataViewInfo.strCollectionPath.Split(":".ToCharArray())[1].Split("/".ToCharArray());
            MongoCollection mongoCol = mServer.GetDatabase(PathArray[(int)EnumMgr.PathLevel.Database]).GetCollection(PathArray[(int)EnumMgr.PathLevel.CollectionAndView]);

            var db = PathArray[(int)EnumMgr.PathLevel.Database];
            var col = PathArray[(int)EnumMgr.PathLevel.CollectionAndView];
            //增加Skip和Limit
            currentDataViewInfo.stages.Add(new BsonDocument("$skip", currentDataViewInfo.SkipCnt));
            currentDataViewInfo.stages.Add(new BsonDocument("$limit", currentDataViewInfo.LimitCnt));
            var mCommandResult = CommandHelper.Aggregate(currentDataViewInfo.stages, db, col);
            var mResult = mCommandResult.Response.GetElement("result").Value.AsBsonArray;
            //删除Skip和Limit
            currentDataViewInfo.stages.RemoveAt(currentDataViewInfo.stages.Count() - 1);
            currentDataViewInfo.stages.RemoveAt(currentDataViewInfo.stages.Count() - 1);


            //https://jira.mongodb.org/browse/SERVER-26802
            //在非正常Shutdown的时候，这个统计结果可能出现错误
            //这个时候需要执行验证数据集命令

            if (currentDataViewInfo.SkipCnt == 0)
            {
                if (currentDataViewInfo.IsUseFilter)
                {
                    var cnt = BsonDocument.Parse(" { $group: { _id: null, count: { $sum: 1 } } } ");
                    currentDataViewInfo.stages.Add(cnt);
                    mCommandResult = CommandHelper.Aggregate(currentDataViewInfo.stages, db, col);
                    currentDataViewInfo.CurrentCollectionTotalCnt = mCommandResult.Response.GetElement("result").Value.AsBsonArray[0].AsBsonDocument.GetElement("count").Value.AsInt32;
                    currentDataViewInfo.stages.RemoveAt(currentDataViewInfo.stages.Count() - 1);
                }
                else
                {
                    currentDataViewInfo.CurrentCollectionTotalCnt = (int)mongoCol.Count();
                }
            }
            SetPageEnable(ref currentDataViewInfo);


            return mResult.Select(x => x.AsBsonDocument).ToList();
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