using System;
using System.Globalization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace UnitTestLagacy.Lagacy
{
    public static class InitTestData
    {
        /// <summary>
        ///     建立一个随机的聚合对象
        /// </summary>
        /// <param name="mSerialID"></param>
        /// <returns></returns>
        private static AggregationObject CreateAggregationObject(String mSerialID)
        {
            var UT = new AggregationObject();
            UT.SerialID = mSerialID;
            var Ro = new Random();
            var CountryCode = Ro.Next(3);
            var AreaCode = Ro.Next(3);
            UT.Age = (byte) Ro.Next(20, 70);
            UT.Money = (short) Ro.Next(500, 5000);
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
        ///     生成Geo测试数据
        /// </summary>
        /// <param name="mongosvr"></param>
        internal static void FillDataForGeoObject(MongoServer mongosvr)
        {
            var mongodb = mongosvr.GetDatabase("mongodb");
            var mongoCol = mongodb.GetCollection<User>("GEO");
            mongoCol.RemoveAll();
            var Ro = new Random();
            for (var i = 0; i < 1000; i++)
            {
                mongoCol.Insert(new GeoObject
                {
                    ID = i.ToString(),
                    Geo = new int[2] {Ro.Next()%180, Ro.Next()%180}
                    //[-180,180] 如果已经有索引，则操作这个范围的记录无法插入数据库
                });
            }
        }

        /// <summary>
        ///     生成TTL测试数据
        /// </summary>
        /// <param name="mongosvr"></param>
        internal static void FillDataForTTL(MongoServer mongosvr)
        {
            var mongodb = mongosvr.GetDatabase("mongodb");
            var mongoCol = mongodb.GetCollection<User>("TTL");
            mongoCol.RemoveAll();
            var Ro = new Random();
            ///HugeData
            for (var i = 0; i < 1000; i++)
            {
                mongoCol.Insert(new TLLObject
                {
                    ID = i.ToString(),
                    CreateDateTime = DateTime.Now.AddSeconds(i),
                    Game = Ro.Next()
                });
            }
        }

        /// <summary>
        ///     生成User测试数据
        /// </summary>
        /// <param name="mongosvr"></param>
        internal static void FillDataForUser(MongoServer mongosvr)
        {
            var mongodb = mongosvr.GetDatabase("mongodb");

            var mongoJsCol = mongodb.GetCollection<BsonDocument>("system.js");
            mongoJsCol.RemoveAll();
            mongoJsCol.Insert<BsonDocument>(
                new BsonDocument().Add("_id", "sum")
                    .Add("value", "function (x, y) { return x + y; }"));
            mongodb.GetGridFS(new MongoGridFSSettings());
            var mongoCol = mongodb.GetCollection<User>("User");
            mongoCol.RemoveAll();
            var Ro = new Random();
            ///HugeData
            for (var i = 0; i < 1000; i++)
            {
                mongoCol.Insert(new User
                {
                    ID = i.ToString(CultureInfo.InvariantCulture),
                    Name = "Tom",
                    Age = (byte) Ro.Next(100),
                    Age2 = (byte) Ro.Next(100),
                    Age3 = (byte) Ro.Next(100),
                    address = new Address
                    {
                        street = "123 Main St.",
                        City = "Centerville",
                        state = "PA",
                        Zip = Ro.Next(20),
                        GeoObj = new[]
                        {
                            new GeoObject
                            {
                                ID = "aaaa",
                                Geo = new int[2] {1, 1}
                            }
                        }
                    },
                    Pets = new[] {"Cat", "Dog"}
                });
            }
        }

        /// <summary>
        ///     生成聚合测试数据
        /// </summary>
        /// <param name="mongoServer"></param>
        internal static void FillDataForAggregation(MongoServer mongoServer)
        {
            var mongodb = mongoServer.GetDatabase("mongodb");
            var mongoCol = mongodb.GetCollection<AggregationObject>("Aggregation");
            mongoCol.RemoveAll();
            for (var i = 0; i < 100000; i++)
            {
                mongoCol.Insert(CreateAggregationObject(i.ToString()));
            }
        }

        internal static void FillDateForMapReduce(MongoServer mongoServer)
        {
            var mongodb = mongoServer.GetDatabase("mongodb");
            var mongoCol = mongodb.GetCollection<Book>("Book");
            mongoCol.RemoveAll();
            for (var i = 0; i < 1000; i++)
            {
                mongoCol.Insert(new Book {BookID = i.ToString(), UserID = i.ToString()});
            }
        }

        /// <summary>
        ///     地址
        /// </summary>
        internal class Address
        {
            public String City;
            public GeoObject[] GeoObj;
            public String state;
            public String street;
            public int Zip;
        }

        /// <summary>
        ///     聚合对象
        /// </summary>
        internal class AggregationObject
        {
            public byte Age;
            public String Area;
            public String Country;
            public Int16 Money;
            [BsonId] public String SerialID;
        }

        internal class Book
        {
            public String BookID;
            public String UserID;
        }

        /// <summary>
        ///     Geo对象
        /// </summary>
        internal class GeoObject
        {
            public int[] Geo;
            [BsonId] public String ID;
        }

        /// <summary>
        ///     TLL对象
        /// </summary>
        internal class TLLObject
        {
            public DateTime CreateDateTime;
            public int Game;
            [BsonId] public String ID;
        }

        /// <summary>
        ///     User对象
        /// </summary>
        internal class User
        {
            public Address address;
            public Byte Age;
            public Byte Age2;
            public Byte Age3;
            [BsonId] public String ID;
            [BsonElement("fn")] public String Name;
            public string[] Pets;
        }
    }
}