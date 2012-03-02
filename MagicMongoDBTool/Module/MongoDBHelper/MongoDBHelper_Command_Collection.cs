using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        /// <summary>
        /// Compact
        /// http://www.mongodb.org/display/DOCS/Compact+Command
        /// </summary>
        public static MongoCommand Compact_Command = new MongoCommand("compact", PathLv.CollectionLV);

    }
}
