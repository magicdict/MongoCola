using System;
using System.Security.Cryptography;
using System.Text;
using Memcached.ClientLibrary;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
namespace ConsoleApplication1
{

    class Program
    {

        static void Main(string[] args)
        {
            Bloom_Filter();
            Console.WriteLine();
            BitMap();
            Console.WriteLine();
            MongoDB();
            memcache();
            Console.ReadLine();
        }

        static void memcache()
        {

            string[] serverlist = { "127.0.0.1:11211" };

            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(serverlist);

            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 5;

            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;

            pool.MaintenanceSleep = 30;
            pool.Failover = true;

            pool.Nagle = false;
            pool.Initialize();


            // 获得客户端实例
            MemcachedClient mc = new MemcachedClient();
            mc.EnableCompression = false;



            Console.WriteLine("------------测  试-----------");
            Boolean isSucceed = mc.Set("test", "my value");  //存储数据到缓存服务器，这里将字符串"my value"缓存，key 是"test"
            Console.WriteLine("isSucceed:" + isSucceed.ToString());
            if (mc.KeyExists("test"))   //测试缓存存在key为test的项目
            {
                Console.WriteLine("test is Exists");
                Console.WriteLine(mc.Get("test").ToString());  //在缓存中获取key为test的项目
            }
            else
            {
                Console.WriteLine("test not Exists");
            }

            Console.ReadLine();

            mc.Delete("test");  //移除缓存中key为test的项目

            if (mc.KeyExists("test"))
            {
                Console.WriteLine("test is Exists");
                Console.WriteLine(mc.Get("test").ToString());
            }
            else
            {
                Console.WriteLine("test not Exists");
            }
            Console.ReadLine();

            SockIOPool.GetInstance().Shutdown();  //关闭池， 关闭sockets
        }



        internal class User
        {
            [BsonId]
            public String ID;
            [BsonElementAttribute("fn")]
            public String Name;
            public Byte Age;
            public Byte Age2;
            public Byte Age3;
        }
        static void MongoDB()
        {
            MongoServerSettings mongosvrsetting = new MongoServerSettings();
            mongosvrsetting.ConnectionMode = ConnectionMode.Direct;
            mongosvrsetting.Server = new MongoServerAddress("localhost", 28018);

            MongoServer mongosvr = new MongoServer(mongosvrsetting);
            mongosvr.Connect();
            MongoDatabase mongodb = mongosvr.GetDatabase("mongodb");
            //MongoCollection<BsonDocument> mongoCol = mongodb.GetCollection<BsonDocument>("log");

            //Console.WriteLine("Db count " + mongoCol.FindAll().Count());
            //foreach (BsonDocument item in mongoCol.FindAll())
            //{
            //    Console.WriteLine(item.ToString());
            //}



            MongoCollection<BsonDocument> mongoJsCol = mongodb.GetCollection<BsonDocument>("system.js");
            mongoJsCol.Insert<BsonDocument>(new BsonDocument().Add("_id", "sum")
                                                              .Add("value", "function (x, y) { return x + y; }")
                                            );

            MongoGridFS mongofs = mongodb.GetGridFS(new MongoGridFSSettings());
            //mongofs.Create("text.txt", new MongoGridFSCreateOptions());
            //mongofs.Upload(@"C:\cf.txt");
            //mongofs.Upload(@"C:\Career Framework.doc");


            MongoCollection<User> mongoCol = mongodb.GetCollection<User>("User");
            mongoCol.RemoveAll();
            Random Ro = new Random();
            for (int i = 0; i < 100000; i++)
            {
                mongoCol.Insert(new User()
                {
                    ID = i.ToString(),
                    Name = "Tom",
                    Age = (byte)Ro.Next(20),
                    Age2 = (byte)Ro.Next(20),
                    Age3 = (byte)Ro.Next(20)
                });
            }
            //for (int i = 0; i < 100; i++)
            //{
            //    BsonDocument nested = new BsonDocument {
            //          { "name", "John Doe" },
            //          { "address", new BsonDocument {
            //                 { "street", "123 Main St." },
            //                 { "city", "Centerville" },
            //                 { "state", "PA" },
            //                 { "zip", Ro.Next(20)}
            //              }
            //          }
            //    };
            //    mongoCol.Insert(nested);
            //}

            mongosvr.Disconnect();
        }

        static Boolean[] Bloom = new Boolean[256];
        static void Bloom_Filter()
        {

            //Bloom Filter
            String strTest = "Hello VisualBasic";
            Console.WriteLine("Add String:" + strTest);
            addString(strTest);
            Console.Write("strTest:" + strTest);
            Console.WriteLine("IsMatch:" + IsContain(strTest));


            strTest = "Hello C#";
            Console.WriteLine("Add String:" + strTest);
            addString(strTest);
            Console.Write("strTest:" + strTest);
            Console.WriteLine("IsMatch:" + IsContain(strTest));

            strTest = "Hello C++";
            Console.WriteLine("strTest:" + strTest);
            Console.WriteLine("IsMatch:" + IsContain(strTest));
        }
        static void addString(String strTest)
        {
            for (byte i = 0; i < 8; i++)
            {
                Bloom[GetHashIndex(i, strTest)] = true;
            }
            Console.WriteLine("");
        }
        static Boolean IsContain(String strTest)
        {
            Boolean IsMatch = true;
            for (byte i = 0; i < 8; i++)
            {
                if (Bloom[GetHashIndex(i, strTest)] != true)
                {
                    IsMatch = false;
                };
            }
            Console.WriteLine("");
            return IsMatch;
        }
        static private byte GetHashIndex(Byte MethodId, String HashString)
        {
            byte HashIndex = 0;
            SHA1Managed sha1M = new SHA1Managed();
            byte[] buffer = Encoding.UTF8.GetBytes(HashString);
            byte[] hashBytes = sha1M.ComputeHash(buffer);
            HashIndex = hashBytes[MethodId];
            Console.Write("[" + HashIndex + "]");
            return HashIndex;
        }


        static void HashLinkedTable()
        {

        }



        static void BitMap()
        {
            Boolean[] SortArray = new Boolean[256];
            byte[] SortList = new byte[] { 31, 52, 13, 65, 232, 65, 12, 5, 77, 12, 78, 32, 231 };
            foreach (byte item in SortList)
            {
                SortArray[item - 1] = true;
            }
            for (int i = 0; i < SortArray.Length; i++)
            {
                if (SortArray[i] == true)
                {
                    Console.Write("[" + (i + 1).ToString() + "]");
                }
            }

        }

    }

}
