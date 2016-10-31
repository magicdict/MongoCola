using System;
using MongoDB.Bson;

namespace MongoUtility.Basic
{
    /// <summary>
    ///     用于BsonValue的序列化
    /// </summary>
    public class BsonValueEx
    {
        /// <summary>
        ///     Boolean
        /// </summary>
        bool mBsonBoolean;

        /// <summary>
        ///     DateTime
        /// </summary>
        DateTime mBsonDateTime;

        /// <summary>
        ///     Int32
        /// </summary>
        int mBsonInt32;

        /// <summary>
        ///     Long(Int64)
        /// </summary>
        long mBsonInt64;

        /// <summary>
        ///     Decimal
        /// </summary>
        double mBsonDouble;

        /// <summary>
        ///     Decimal128
        /// </summary>
        Decimal128 mBSonDecimal128;

        /// <summary>
        ///     文字值
        /// </summary>
        string mBsonString;

        /// <summary>
        ///     类型
        /// </summary>
        BasicType mBsonType;

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
                mBsonType = BasicType.BsonString;
                mBsonString = value.ToString();
            }
            if (value.IsInt32)
            {
                mBsonType = BasicType.BsonInt32;
                mBsonInt32 = value.AsInt32;
            }

            if (value.IsInt64)
            {
                mBsonType = BasicType.BsonInt64;
                mBSonDecimal128 = value.AsDecimal;
            }

            if (value.IsDecimal128)
            {
                mBsonType = BasicType.BsonDecimal128;
                mBSonDecimal128 = value.AsDecimal;
            }

            if (value.IsDouble)
            {
                mBsonType = BasicType.BsonDouble;
                mBsonDouble = value.AsDouble;
            }

            if (value.IsValidDateTime)
            {
                mBsonType = BasicType.BsonDateTime;
                mBsonDateTime = value.ToUniversalTime();
            }

            if (value.IsBoolean)
            {
                mBsonType = BasicType.BsonBoolean;
                mBsonBoolean = value.AsBoolean;
            }
        }

        /// <summary>
        ///     基本类型枚举
        /// </summary>
        public enum BasicType : int
        {
            BsonString = 0,
            BsonInt32,
            BsonInt64,
            BsonDecimal128,
            BsonDouble,
            BsonDateTime,
            BsonBoolean,
            BsonArray,
            BsonDocument,
            BsonGeo,
            BsonUndefined = 99
        }

        /// <summary>
        ///     还原BsonValue
        /// </summary>
        /// <returns></returns>
        public BsonValue GetBsonValue()
        {
            BsonValue value = new BsonString(string.Empty);
            switch (mBsonType)
            {
                case BasicType.BsonString:
                    value = new BsonString(mBsonString);
                    break;
                case BasicType.BsonInt32:
                    value = new BsonInt32(mBsonInt32);
                    break;
                case BasicType.BsonInt64:
                    value = new BsonInt64(mBsonInt64);
                    break;
                case BasicType.BsonDecimal128:
                    value = new BsonDecimal128(mBSonDecimal128);
                    break;
                case BasicType.BsonDouble:
                    value = new BsonDouble(mBsonDouble);
                    break;
                case BasicType.BsonDateTime:
                    value = new BsonDateTime(mBsonDateTime);
                    break;
                case BasicType.BsonBoolean:
                    value = mBsonBoolean ? BsonBoolean.True : BsonBoolean.False;
                    break;
            }
            return value;
        }

        /// <summary>
        ///     各种基本类型的初始值
        /// </summary>
        /// <param name="DataType"></param>
        /// <returns></returns>
        public static BsonValue GetInitValue(BsonValueEx.BasicType DataType)
        {
            BsonValue InitValue = BsonNull.Value;
            switch (DataType)
            {
                case BasicType.BsonString:
                    InitValue = (new BsonString(string.Empty));
                    break;
                case BasicType.BsonInt32:
                    InitValue = (new BsonInt32(0));
                    break;
                case BasicType.BsonInt64:
                    InitValue = (new BsonInt64(0));
                    break;
                case BasicType.BsonDecimal128:
                    InitValue = (new BsonDecimal128(0));
                    break;
                case BasicType.BsonDouble:
                    InitValue = (new BsonDouble(0));
                    break;
                case BasicType.BsonDateTime:
                    InitValue = (new BsonDateTime(DateTime.Now));
                    break;
                case BasicType.BsonBoolean:
                    InitValue = (BsonBoolean.False);
                    break;
                case BasicType.BsonArray:
                    InitValue = (new BsonArray());
                    break;
                case BasicType.BsonDocument:
                    InitValue = (new BsonDocument());
                    break;
                case BasicType.BsonGeo:
                    InitValue = (new BsonArray() { 0, 0 });
                    break;
                default:
                    break;
            }
            return InitValue;
        }

        /// <summary>
        /// 根据BsonValue推断基本类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static BasicType GetBsonValueBasicType(BsonValue value)
        {
            if (value.IsString) return BasicType.BsonString;
            if (value.IsInt32) return BasicType.BsonInt32;
            if (value.IsInt64) return BasicType.BsonInt64;
            if (value.IsDecimal128) return BasicType.BsonDecimal128;
            if (value.IsDouble) return BasicType.BsonDouble;
            if (value.IsValidDateTime) return BasicType.BsonDateTime;
            if (value.IsBoolean) return BasicType.BsonBoolean;
            //这里也可能是一个地理对象
            if (value.IsBsonArray) return BasicType.BsonArray;
            if (value.IsBsonDocument) return BasicType.BsonDocument;
            return BasicType.BsonString;
        }

    }
}