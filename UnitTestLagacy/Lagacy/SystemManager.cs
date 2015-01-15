using MongoDB.Driver;

namespace UnitTestLagacy.Lagacy
{
    public static class SystemManager
    {
        private static MongoServer innerServer;

        public static void Init()
        {
            innerServer = MongoServer.Create(@"mongodb://localhost:28030");
            innerServer.Connect();
        }

        public static MongoServer GetCurrentServer()
        {
            return innerServer;
        }
    }
}