using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        static public string[] getGroupOpt(){
            return new string[]{
                "$addToSet",
                "$first",
                "$last",
                "$max",
                "$min",
                "$avg",
                "$push",
                "$sum"
            };
        }
    }
}
