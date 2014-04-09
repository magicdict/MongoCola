using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
namespace UnitTest
{
    public static class SystemManager
    {
        private static MongoServer innerServer;
        public static void Init() { 
            innerServer = MongoServer.Create(@"mongodb://localhost:28030");
            innerServer.Connect();
        }
        public static MongoServer GetCurrentServer() {
            return innerServer;
        }
    }
}
