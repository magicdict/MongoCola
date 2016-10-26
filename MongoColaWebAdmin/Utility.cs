using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

namespace MongoColaWebAdmin
{
    public class Utility
    {
        /// <summary>
        /// 
        /// </summary>
        struct BsonElementDesciption
        {
            /// <summary>
            /// 名称
            /// </summary>
            public string name;
            /// <summary>
            /// 值
            /// </summary>
            public string value;
            /// <summary>
            /// 类型
            /// </summary>
            public string type;
            /// <summary>
            /// 子元素
            /// </summary>
            public BsonElementDesciption[] children;
        }

        /// <summary>
        /// BsonDocument转Json字符串
        /// </summary>
        /// <param name="Datalist"></param>
        /// <returns></returns>
        static List<BsonElementDesciption> GetJsonDocList(List<BsonDocument> Datalist, string rootName)
        {
            var rtn = new List<BsonElementDesciption>();
            foreach (var item in Datalist)
            {
                rtn.Add(GetJsonDocument(item, rootName));
            }
            return rtn;
        }

        /// <summary>
        /// 获得一个Doc的Json
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        static BsonElementDesciption GetJsonDocument(BsonDocument doc, string rootName)
        {
            var rtn = new BsonElementDesciption();
            rtn.name = rootName;
            rtn.type = "Document";
            if (doc.Elements.First().Name == MongoUtility.Basic.ConstMgr.KeyId)
            {
                rtn.value = doc.Elements.First().Value.ToString();
            }
            return rtn;
        }
    }
}
