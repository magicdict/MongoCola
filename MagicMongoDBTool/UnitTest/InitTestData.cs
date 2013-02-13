using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;

namespace MagicMongoDBTool.Module
{
    public static class InitTestData
    {
        /// <summary>
        /// User对象
        /// </summary>
        internal class User
        {
            [BsonId]
            public String ID;
            [BsonElementAttribute("fn")]
            public String Name;
            public Byte Age;
            public Byte Age2;
            public Byte Age3;
            public Address address;
            public string[] Pets;
        }
        /// <summary>
        ///地址
        /// </summary>
        internal class Address
        {
            public String street;
            public String City;
            public String state;
            public int Zip;
            public GeoObject[] GeoObj;
        }
        /// <summary>
        /// Geo对象
        /// </summary>
        internal class GeoObject
        {
            [BsonId]
            public String ID;
            public int[] Geo;
        }
        /// <summary>
        /// TLL对象
        /// </summary>
        internal class TLLObject
        {
            [BsonId]
            public String ID;
            public DateTime CreateDateTime;
            public int Game;
        }
        /// <summary>
        /// 聚合对象
        /// </summary>
        internal class AggregationObject
        {
            [BsonId]
            public String SerialID;
            public String Country;
            public String Area;
            public byte Age;
            public Int16 Money;
        }
        /// <summary>
        /// 建立一个随机的聚合对象
        /// </summary>
        /// <param name="mSerialID"></param>
        /// <returns></returns>
        private static AggregationObject CreateAggregationObject(String mSerialID)
        {
            AggregationObject UT = new AggregationObject();
            UT.SerialID = mSerialID;
            Random Ro = new Random();
            int CountryCode = Ro.Next(3);
            int AreaCode = Ro.Next(3);
            UT.Age = (byte)Ro.Next(20, 70);
            UT.Money = (short)Ro.Next(500, 5000);
            switch (CountryCode)
            {
                case 0:
                    UT.Country = "中国";
                    switch (AreaCode)
                    {
                        case 0:
                            UT.Area = "上海";
                            break;
                        case 1:
                            UT.Area = "北京";
                            break;
                        case 2:
                            UT.Area = "广州";
                            break;
                        default:
                            UT.Area = "未知";
                            break;
                    }
                    break;
                case 1:
                    UT.Country = "美国";
                    switch (AreaCode)
                    {
                        case 0:
                            UT.Area = "华盛顿";
                            break;
                        case 1:
                            UT.Area = "纽约";
                            break;
                        case 2:
                            UT.Area = "旧金山";
                            break;
                        default:
                            UT.Area = "未知";
                            break;
                    }
                    break;
                case 2:
                    UT.Country = "日本";
                    switch (AreaCode)
                    {
                        case 0:
                            UT.Area = "东京";
                            break;
                        case 1:
                            UT.Area = "大阪";
                            break;
                        case 2:
                            UT.Area = "札幌";
                            break;
                        default:
                            UT.Area = "未知";
                            break;
                    }
                    break;
                default:
                    UT.Country = "未知";
                    UT.Area = "未知";
                    break;
            }
            return UT;
        }
        /// <summary>
        /// 生成Geo测试数据
        /// </summary>
        /// <param name="mongosvr"></param>
        internal static void FillDataForGeoObject(MongoServer mongosvr)
        {
            MongoDatabase mongodb = mongosvr.GetDatabase("mongodb");
            MongoCollection<User> mongoCol = mongodb.GetCollection<User>("GEO");
            mongoCol.RemoveAll();
            Random Ro = new Random();
            for (int i = 0; i < 1000; i++)
            {
                mongoCol.Insert(new GeoObject()
                {
                    ID = i.ToString(),
                    Geo = new int[2] { Ro.Next() % 180, Ro.Next() % 180 }
                    //[-180,180] 如果已经有索引，则操作这个范围的记录无法插入数据库
                });
            }
            var group = new BsonDocument 
                { 
                    { "$group", 
                        new BsonDocument 
                            { 
                                { "_id", new BsonDocument 
                                             { 
                                                 { 
                                                     "MyUser","$User" 
                                                 } 
                                             } 
                                }, 
                                { 
                                    "Count", new BsonDocument 
                                                 { 
                                                     { 
                                                         "$sum", 1 
                                                     } 
                                                 } 
                                } 
                            } 
                  } 
                };
        }
        /// <summary>
        /// 生成TTL测试数据
        /// </summary>
        /// <param name="mongosvr"></param>
        internal static void FillDataForTTL(MongoServer mongosvr)
        {
            MongoDatabase mongodb = mongosvr.GetDatabase("mongodb");
            MongoCollection<User> mongoCol = mongodb.GetCollection<User>("TTL");
            mongoCol.RemoveAll();
            Random Ro = new Random();
            ///HugeData
            for (int i = 0; i < 1000; i++)
            {
                mongoCol.Insert(new TLLObject()
                {
                    ID = i.ToString(),
                    CreateDateTime = System.DateTime.Now.AddSeconds(i),
                    Game = Ro.Next()
                });
            }
        }
        /// <summary>
        /// 生成User测试数据
        /// </summary>
        /// <param name="mongosvr"></param>
        internal static void FillDataForUser(MongoServer mongosvr)
        {
            MongoDatabase mongodb = mongosvr.GetDatabase("mongodb");

            MongoCollection<BsonDocument> mongoJsCol = mongodb.GetCollection<BsonDocument>("system.js");
            mongoJsCol.Insert<BsonDocument>(
                          new BsonDocument().Add("_id", "sum")
                                            .Add("value", "function (x, y) { return x + y; }"));
            MongoGridFS mongofs = mongodb.GetGridFS(new MongoGridFSSettings());
            MongoCollection<User> mongoCol = mongodb.GetCollection<User>("User");
            mongoCol.RemoveAll();
            Random Ro = new Random();
            ///HugeData
            for (int i = 0; i < 1000; i++)
            {
                mongoCol.Insert(new User()
                {
                    ID = i.ToString(),
                    Name = "Tom",
                    Age = (byte)Ro.Next(100),
                    Age2 = (byte)Ro.Next(100),
                    Age3 = (byte)Ro.Next(100),
                    address = new Address()
                    {
                        street = "123 Main St.",
                        City = "Centerville",
                        state = "PA",
                        Zip = Ro.Next(20),
                        GeoObj = new GeoObject[]{
                            new GeoObject(){
                                ID = "aaaa",
                                Geo = new int[2]{1,1}
                            }
                        },
                    },
                    Pets = new string[] { "Cat", "Dog" },
                });
            }
        }
        /// <summary>
        /// 生成聚合测试数据
        /// </summary>
        /// <param name="mongoServer"></param>
        internal static void FillDataForAggregation(MongoServer mongoServer)
        {
            MongoDatabase mongodb = mongoServer.GetDatabase("mongodb");
            MongoCollection<AggregationObject> mongoCol = mongodb.GetCollection<AggregationObject>("Aggregation");
            mongoCol.RemoveAll();
            for (int i = 0; i < 1000000; i++)
            {
                mongoCol.Insert(CreateAggregationObject(i.ToString()));
            }
        }
    }
}
