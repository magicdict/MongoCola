using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace MongoUtility.Basic
{
    /// <summary>
    ///     用于BsonValue的序列化
    /// </summary>
    [Serializable]
    public class BsonValueEx
    {
        // TODO:Check the new driver if the function is ready.

        /// <summary>
        ///     Boolean
        /// </summary>
        public Boolean mBsonBoolean;

        /// <summary>
        ///     DateTime
        /// </summary>
        public DateTime mBsonDateTime;

        /// <summary>
        ///     Int32
        /// </summary>
        public Int32 mBsonInt32;

        /// <summary>
        ///     文字值
        /// </summary>
        public string mBsonString;

        /// <summary>
        ///     类型
        /// </summary>
        public string mBsonType;

        /// <summary>
        ///     为了序列化，必须要写这个方法
        /// </summary>
        public BsonValueEx()
        {
        }

        /// <summary>
        ///     初始化
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
            if (value.IsValidDateTime)
            {
                mBsonType = "BsonDateTime";
                mBsonDateTime = value.ToUniversalTime();
            }
            if (value.IsBoolean)
            {
                mBsonType = "BsonBoolean";
                mBsonBoolean = value.AsBoolean;
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static List<string> GetBasicTypeList()
        {
            var typelst = new List<string>();
            typelst.Add("BsonString");
            typelst.Add("BsonInt32");
            typelst.Add("BsonDateTime");
            typelst.Add("BsonBoolean");
            typelst.Add("BsonArray");
            typelst.Add("BsonDocument");
            return typelst;
        }

        /// <summary>
        ///     还原BsonValue
        /// </summary>
        /// <returns></returns>
        public BsonValue GetBsonValue()
        {
            BsonValue Value = new BsonString(string.Empty);
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
                    Value = mBsonBoolean ? BsonBoolean.True : BsonBoolean.False;
                    break;
                default:
                    break;
            }
            return Value;
        }
    }
}