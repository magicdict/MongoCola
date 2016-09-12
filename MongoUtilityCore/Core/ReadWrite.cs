using MongoDB.Driver;

namespace MongoUtility.Core
{
    public class ReadWrite
    {
        //读策略
        //http://docs.mongodb.org/manual/reference/connection-string/#read-preference-options
        //https://github.com/mongodb/mongo-csharp-driver/blob/master/MongoDB.Driver/ReadPreference.cs

        /// <summary>
        /// </summary>
        public static string[] ReadPreferenceList =
        {
            ReadPreference.Primary.ToString(),
            ReadPreference.PrimaryPreferred.ToString(),
            ReadPreference.Secondary.ToString(),
            ReadPreference.SecondaryPreferred.ToString(),
            ReadPreference.Nearest.ToString()
        };

        //写确认
        //http://docs.mongodb.org/manual/reference/connection-string/#write-concern-options
        //https://github.com/mongodb/mongo-csharp-driver/blob/master/MongoDB.Driver/WriteConcern.cs

        public static string[] WriteConcernList =
        {
            WriteConcern.Unacknowledged.ToString(),
            WriteConcern.Acknowledged.ToString(),
            WriteConcern.W2.ToString(),
            WriteConcern.W3.ToString(),
            WriteConcern.WMajority.ToString()
        };
    }
}