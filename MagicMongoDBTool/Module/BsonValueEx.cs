using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace MagicMongoDBTool.Module
{
    /// <summary>
    /// 用于BsonValue的序列化
    /// </summary>
    [Serializable()]
    public class BsonValueEx
    {
        public String mBsonType;
        public String mBsonValue;
        public BsonValueEx() { 
        
        }
        public BsonValueEx(BsonValue value)
        {
            if (value.IsString)
            {
                mBsonType = "String";
                mBsonValue = value.ToString();
            }
            if (value.IsInt32) {
                mBsonType = "Int32";
                mBsonValue = value.ToString();
            }
        }
        public BsonValue GetBsonValue()
        {
            BsonValue Value = new BsonString("");
            switch (mBsonType)
            {
                case "String":
                    Value = new BsonString(mBsonValue);
                    break;
                case "Int32":
                    Value = new BsonInt32(Convert.ToInt32(mBsonValue));
                    break;
                default:
                    break;
            }
            return Value;
        }
    }
}
