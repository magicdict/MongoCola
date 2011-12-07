using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool.Module
{
    /// <summary>
    ///数据库命令 
    ///http://www.mongodb.org/display/DOCS/List+of+Database+Commands
    /// </summary>
    public static partial class MongoDBHelper
    {
        /// <summary>
        /// 修复数据库
        /// http://www.mongodb.org/display/DOCS/Durability+and+Repair
        /// </summary>
        public static MongoCommand repairDatabase_Command = new MongoCommand("repairDatabase", PathLv.DatabaseLV);
    }
}
