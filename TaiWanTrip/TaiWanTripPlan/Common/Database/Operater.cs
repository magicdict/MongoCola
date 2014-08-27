using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Common.Database
{
    /// <summary>
    /// Summary description for Operater
    /// </summary>
    public static class Operater
    {
        /// <summary>
        /// 服务器
        /// </summary>
        static MongoServer innerServer;
        /// <summary>
        /// 数据库
        /// </summary>
        static MongoDatabase innerDatabase;
        /// <summary>
        /// 链接字符串
        /// </summary>
        static string connectionstring = @"mongodb://localhost:28030";
        /// <summary>
        /// 初始化MongoDB
        /// </summary>
        /// <returns></returns>
        public static bool Init()
        {
            innerServer = MongoServer.Create(connectionstring);
            innerServer.Connect();
            innerDatabase = innerServer.GetDatabase("Trip");
            return true;
        }
        /// <summary>
        /// 插入记录
        /// </summary>
        /// <typeparam name="T">继承与EntityBase的类</typeparam>
        /// <param name="CollectionName"></param>
        /// <param name="obj"></param>
        public static void InsertRec<T>(string CollectionName, T obj,string createUser = EnumAndConst.SystemAdmin) where T : EntityBase
        {
            obj.CreateDateTime = System.DateTime.Now;
            obj.UpdateDateTime = System.DateTime.Now;
            obj.CreateUser = createUser;
            obj.UpdateUser = createUser;
            obj.IsDel = false;
            MongoCollection TargetCollection = innerDatabase.GetCollection(CollectionName);
            TargetCollection.Insert<T>(obj);
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CollectionName"></param>
        /// <param name="obj"></param>
        /// <param name="updateUser"></param>
        public static void UpdateRec<T>(string CollectionName, T obj, string updateUser = EnumAndConst.SystemAdmin) where T : EntityBase
        {
            MongoCollection TargetCollection = innerDatabase.GetCollection(CollectionName);
            obj.UpdateDateTime = System.DateTime.Now;
            obj.UpdateUser = updateUser;
            //Remove Old
            TargetCollection.Remove(Query.EQ("_id", obj._id), WriteConcern.Acknowledged);
            //Insert New
            TargetCollection.Insert<T>(obj);
        }
        /// <summary>
        /// 物理删除一条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CollectionName"></param>
        /// <param name="query"></param>
        public static void DeleteRec<T>(string CollectionName, T obj,string updateUser = EnumAndConst.SystemAdmin) where T : EntityBase
        {
            obj.IsDel = true;
            UpdateRec<T>(CollectionName, obj, updateUser);
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetFirstRec<T>(string CollectionName, IMongoQuery query) where T : EntityBase
        {
            MongoCollection TargetCollection = innerDatabase.GetCollection(CollectionName);
            var NotDeletequery = Query.EQ("IsDel", false);
            query = Query.And(query, NotDeletequery);
            T rec = (T)TargetCollection.FindOneAs(typeof(T), query);
            return rec;
        }
    }
}