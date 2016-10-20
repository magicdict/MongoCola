using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace MongoUtility.Basic
{
    /// <summary>
    ///     用于BsonValue的序列化
    /// </summary>
    public class BsonValueEx
    {
        // TODO:Check the new driver if the function is ready.

        /// <summary>
        ///     Boolean
        /// </summary>
        public bool MBsonBoolean;

        /// <summary>
        ///     DateTime
        /// </summary>
        public DateTime MBsonDateTime;

        /// <summary>
        ///     Int32
        /// </summary>
        public int MBsonInt32;

        /// <summary>
        ///     Long(Int64)
        /// </summary>
        public long MBsonInt64;

        /// <summary>
        ///     Decimal
        /// </summary>
        //public Decimal MBSonDecimal;

        /// <summary>
        ///     Decimal128
        /// </summary>
        public Decimal128 MBSonDecimal128;

        /// <summary>
        ///     文字值
        /// </summary>
        public string MBsonString;

        /// <summary>
        ///     类型
        /// </summary>
        public string MBsonType;

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
                MBsonType = "BsonString";
                MBsonString = value.ToString();
            }
            if (value.IsInt32)
            {
                MBsonType = "BsonInt32";
                MBsonInt32 = value.AsInt32;
            }

            if (value.IsInt64)
            {
                MBsonType = "BsonInt64";
                MBSonDecimal128 = value.AsDecimal;
            }

            if (value.IsDecimal128)
            {
                MBsonType = "BsonDecimal128";
                MBSonDecimal128 = value.AsDecimal;
            }

            if (value.IsValidDateTime)
            {
                MBsonType = "BsonDateTime";
                MBsonDateTime = value.ToUniversalTime();
            }
            if (value.IsBoolean)
            {
                MBsonType = "BsonBoolean";
                MBsonBoolean = value.AsBoolean;
            }
        }

        /// <summary>
        ///     基本类型
        /// </summary>
        /// <returns></returns>
        public static List<string> GetBasicTypeList()
        {
            var typelst = new List<string>();
            typelst.Add("BsonString");
            typelst.Add("BsonInt32");
            typelst.Add("BsonInt64");
            typelst.Add("BsonDecimal128");
            typelst.Add("BsonDateTime");
            typelst.Add("BsonBoolean");
            typelst.Add("BsonArray");
            typelst.Add("BsonDocument");
            return typelst;
        }
        /// <summary>
        ///     基本类型枚举
        /// </summary>
        public enum BasicType : int
        {
            BsonString = 0,
            BsonInt32 ,
            BsonInt64,
            BsonDecimal128,
            BsonDateTime,
            BsonBoolean,
            BsonArray,
            BsonDocument
        }

        /// <summary>
        ///     还原BsonValue
        /// </summary>
        /// <returns></returns>
        public BsonValue GetBsonValue()
        {
            BsonValue value = new BsonString(string.Empty);
            switch (MBsonType)
            {
                case "BsonString":
                    value = new BsonString(MBsonString);
                    break;
                case "BsonInt32":
                    value = new BsonInt32(MBsonInt32);
                    break;
                case "BsonInt64":
                    value = new BsonInt64(MBsonInt64);
                    break;
                case "BsonDecimal128":
                    value = new BsonDecimal128(MBSonDecimal128);
                    break;
                case "BsonDateTime":
                    value = new BsonDateTime(MBsonDateTime);
                    break;
                case "BsonBoolean":
                    value = MBsonBoolean ? BsonBoolean.True : BsonBoolean.False;
                    break;
            }
            return value;
        }   
    }
}