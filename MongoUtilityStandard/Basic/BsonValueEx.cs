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
        ///     二进制
        /// </summary>
        byte[] mBsonBinary;

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
        ///     基本类型枚举
        /// </summary>
        /// <remarks>
        ///     和MongoDB.Bson.BsonType不同,这里还会附带一些功能性的，包装的类型
        ///     例如BsonGeo这样表示地理坐标的类型
        /// </remarks>
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
            /// <summary>
            ///     XYPoint的坐标
            /// </summary>
            BsonLegacyPoint,
            /// <summary>
            ///     GeoJSON对象
            /// </summary>
            BsonGeoJSON,
            BsonMinKey,
            BsonMaxKey,
            BsonBinary,
            BsonUndefined = 99
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
                mBsonInt64 = value.AsInt64;
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

            if (value.IsBsonMaxKey)
            {
                mBsonType = BasicType.BsonMaxKey;
            }
            if (value.IsBsonMinKey)
            {
                mBsonType = BasicType.BsonMinKey;
            }

            if (value.IsBsonBinaryData)
            {
                mBsonType = BasicType.BsonBinary;
                mBsonBinary = value.AsBsonBinaryData.Bytes;
            }
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

                case BasicType.BsonMaxKey:
                    value = BsonMaxKey.Value;
                    break;
                case BasicType.BsonMinKey:
                    value = BsonMinKey.Value;
                    break;
                case BasicType.BsonBinary:
                    value = new BsonBinaryData(mBsonBinary);
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
                    InitValue = new BsonString(string.Empty);
                    break;
                case BasicType.BsonInt32:
                    InitValue = new BsonInt32(0);
                    break;
                case BasicType.BsonInt64:
                    InitValue = new BsonInt64(0);
                    break;
                case BasicType.BsonDecimal128:
                    InitValue = new BsonDecimal128(0);
                    break;
                case BasicType.BsonDouble:
                    InitValue = new BsonDouble(0);
                    break;
                case BasicType.BsonDateTime:
                    InitValue = new BsonDateTime(DateTime.Now);
                    break;
                case BasicType.BsonBoolean:
                    InitValue = BsonBoolean.False;
                    break;
                case BasicType.BsonArray:
                    InitValue = new BsonArray();
                    break;
                case BasicType.BsonDocument:
                    InitValue = new BsonDocument();
                    break;
                case BasicType.BsonLegacyPoint:
                    InitValue = new BsonArray() { 0, 0 };
                    break;
                case BasicType.BsonGeoJSON:
                    InitValue = new BsonDocument("type", "Point");
                    InitValue.AsBsonDocument.Add("coordinates", new BsonArray() { 0, 0 });
                    break;
                case BasicType.BsonMaxKey:
                    InitValue = BsonMaxKey.Value;
                    break;
                case BasicType.BsonMinKey:
                    InitValue = BsonMinKey.Value;
                    break;
                case BasicType.BsonBinary:
                    InitValue = new BsonBinaryData(new byte[0]);
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
            //这里也可能是一个LegacyPoint
            if (value.IsBsonArray) return BasicType.BsonArray;
            //这里也可能是一个GeoJson
            if (value.IsBsonDocument) return BasicType.BsonDocument;

            if (value.IsBsonMaxKey) return BasicType.BsonMaxKey;
            if (value.IsBsonMinKey) return BasicType.BsonMinKey;

            if (value.IsBsonBinaryData) return BasicType.BsonBinary;

            return BasicType.BsonString;
        }

    }
}