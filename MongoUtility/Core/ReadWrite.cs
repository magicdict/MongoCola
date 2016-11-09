using MongoDB.Driver;

namespace MongoUtility.Core
{
    public class ReadWrite
    {
        //http://docs.mongodb.org/manual/reference/connection-string/#read-preference-options
        //https://github.com/mongodb/mongo-csharp-driver/blob/master/src/MongoDB.Driver.Core/ReadConcern.cs
        //http://docs.mongodb.org/manual/reference/connection-string/#write-concern-options
        //https://github.com/mongodb/mongo-csharp-driver/blob/master/src/MongoDB.Driver.Core/WriteConcern.cs
        //https://yq.aliyun.com/articles/60553

        //readPreference 主要控制客户端 Driver 从复制集的哪个节点读取数据，这个特性可方便的实现读写分离、就近读取等策略。
        //readConcern 决定在某个读取数据时，能读到什么样的数据。

        /// <summary>
        ///     读策略
        /// </summary>
        public static string[] ReadPreferenceList =
        {
            "Primary",
            "PrimaryPreferred",
            "Secondary",
            "SecondaryPreferred",
            "Nearest"
        };

        /// <summary>
        ///     读确认
        /// </summary>
        public static string[] ReadConcernList =
        {
            "Local",
            "Majority",
            "Linearizable",
        };

        /// <summary>
        ///     写确认
        /// </summary>
        public static string[] WriteConcernList =
        {
            "Unacknowledged",
            "Acknowledged",
            "W1",
            "W2",
            "W3",
            "WMajority"
        };


        /// <summary>
        ///     Set ReadPreference And WriteConcern
        /// </summary>
        /// <param name="clientsettings"></param>
        /// <param name="config"></param>
        public static void SetReadPreferenceWriteConcern(MongoClientSettings clientsettings, MongoConnectionConfig config)
        {
            //Default ReadPreference is Primary
            if (config.ReadPreference == "Primary")
            {
                clientsettings.ReadPreference = ReadPreference.Primary;
            }
            if (config.ReadPreference == "PrimaryPreferred")
            {
                clientsettings.ReadPreference = ReadPreference.PrimaryPreferred;
            }
            if (config.ReadPreference == "Secondary")
            {
                clientsettings.ReadPreference = ReadPreference.Secondary;
            }
            if (config.ReadPreference == "SecondaryPreferred")
            {
                clientsettings.ReadPreference = ReadPreference.SecondaryPreferred;
            }
            if (config.ReadPreference == "Nearest")
            {
                clientsettings.ReadPreference = ReadPreference.Nearest;
            }


            //Default ReadConcern is Local
            if (config.ReadConcern == "Local")
            {
                clientsettings.ReadConcern = ReadConcern.Local;
            }
            if (config.ReadConcern == "Majority")
            {
                clientsettings.ReadConcern = ReadConcern.Majority;
            }
            if (config.ReadConcern == "Linearizable")
            {
                clientsettings.ReadConcern = ReadConcern.Linearizable;
            }


            //Default WriteConcern is Unacknowledged
            if (config.WriteConcern == "Unacknowledged")
            {
                clientsettings.WriteConcern = WriteConcern.Unacknowledged;
            }
            if (config.WriteConcern == "Acknowledged")
            {
                clientsettings.WriteConcern = WriteConcern.Acknowledged;
            }
            if (config.WriteConcern == "W1")
            {
                clientsettings.WriteConcern = WriteConcern.W1;
            }
            if (config.WriteConcern == "W2")
            {
                clientsettings.WriteConcern = WriteConcern.W2;
            }
            if (config.WriteConcern == "W3")
            {
                clientsettings.WriteConcern = WriteConcern.W3;
            }
            if (config.WriteConcern == "WMajority")
            {
                clientsettings.WriteConcern = WriteConcern.WMajority;
            }
        }

    }
}