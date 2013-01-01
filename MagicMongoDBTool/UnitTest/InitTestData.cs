using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using MongoDB.Bson.Serialization.Attributes;

namespace MagicMongoDBTool.Module
{
    public static class InitTestData
    {
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
        }
        internal class Address
        {
            public String street;
            public String City;
            public String state;
            public int Zip;
        }

        internal class TLLObject
        {
            [BsonId]
            public String ID;
            public DateTime CreateDateTime;
            public int Game;
        }
        public static void FillDataForTTL(MongoServer mongosvr)
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

        public static void FillDataForUser(MongoServer mongosvr)
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
                        Zip = Ro.Next(20)
                    }
                });
            }
        }
    }
}
