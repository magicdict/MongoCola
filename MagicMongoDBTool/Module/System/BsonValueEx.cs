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
        /// <summary>
        /// 类型
        /// </summary>
        public String mBsonType;
        /// <summary>
        /// 文字值
        /// </summary>
        public String mBsonString;
        /// <summary>
        /// Int32
        /// </summary>
        public Int32 mBsonInt32;
        /// <summary>
        /// DateTime
        /// </summary>
        public DateTime mBsonDateTime;
        /// <summary>
        /// Boolean
        /// </summary>
        public Boolean mBsonBoolean;

        public static List<String> GetBasicTypeList(){
            List<String> typelst = new List<String>();
            typelst.Add("BsonString");
            typelst.Add("BsonInt32");
            typelst.Add("BsonDateTime");
            typelst.Add("BsonBoolean");
            return typelst;
        }
        public static List<String> GetExtendTypeList()
        {
            List<String> typelst = new List<String>();
            typelst.Add("BsonArray");
            typelst.Add("BsonDocument");
            return typelst;
        }
        /// <summary>
        /// 为了序列化，必须要写这个方法
        /// </summary>
        public BsonValueEx()
        {

        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="value"></param>
        public BsonValueEx(BsonValue value)
        {
            if (value.IsString)
            {
                mBsonType = "BsonString";
                mBsonString = value.ToString();
            }
            if (value.IsInt32)
            {
                mBsonType = "BsonInt32";
                mBsonInt32 = value.AsInt32;
            }
            if (value.IsDateTime)
            {
                mBsonType = "BsonDateTime";
                mBsonDateTime = value.AsDateTime;
            }
            if (value.IsBoolean)
            {
                mBsonType = "BsonBoolean";
                mBsonBoolean = value.AsBoolean;
            }
        }
        /// <summary>
        /// 还原BsonValue
        /// </summary>
        /// <returns></returns>
        public BsonValue GetBsonValue()
        {
            BsonValue Value = new BsonString("");
            switch (mBsonType)
            {
                case "BsonString":
                    Value = new BsonString(mBsonString);
                    break;
                case "BsonInt32":
                    Value = new BsonInt32(mBsonInt32);
                    break;
                case "BsonDateTime":
                    Value = new BsonDateTime(mBsonDateTime);
                    break;
                case "BsonBoolean":
                    if (mBsonBoolean)
                    {
                        Value = BsonBoolean.True;
                    }
                    else
                    {
                        Value = BsonBoolean.False;
                    }
                    break;
                default:
                    break;
            }
            return Value;
        }
    }
}
