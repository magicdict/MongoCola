
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.ToolKit;
using System.Collections.Generic;
using System.Linq;

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
        ///     每页显示数
        /// </summary>
        public int LimitCnt;

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
            cursor = mongoCol.FindAllAs<BsonDocument>()
                .SetSkip(currentDataViewInfo.SkipCnt)
                .SetLimit(currentDataViewInfo.LimitCnt);
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
                currentDataViewInfo.CurrentCollectionTotalCnt = (int)mongoCol.Count();
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