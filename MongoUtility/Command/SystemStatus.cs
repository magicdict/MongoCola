using MongoDB.Bson;
using System.Collections.Generic;

namespace MongoUtility.Command
{
    public static class SystemStatus
    {
        /// <summary>
        /// 状态字典
        /// </summary>
        public static Dictionary<string, string> StatusNameDic = new Dictionary<string, string>();

        public static void FillStatusDicName()
        {
            //opcounters
            StatusNameDic.Add("opcounters.Query", "opcounters.query");
            StatusNameDic.Add("opcounters.Insert", "opcounters.insert");
            StatusNameDic.Add("opcounters.Update", "opcounters.update");
            StatusNameDic.Add("opcounters.Delete", "opcounters.delete");

            //asserts
            StatusNameDic.Add("asserts.msg", "asserts.msg");
            StatusNameDic.Add("asserts.regular", "asserts.regular");
            StatusNameDic.Add("asserts.rollovers", "asserts.rollovers");
            StatusNameDic.Add("asserts.user", "asserts.user");
            StatusNameDic.Add("asserts.warning", "asserts.warning");

            //mem
            StatusNameDic.Add("mem.bits", "mem.bits");
            StatusNameDic.Add("mem.resident", "mem.resident");
            StatusNameDic.Add("mem.virtual", "mem.virtual");
            StatusNameDic.Add("mem.mapped", "mem.mapped");

            //connections(available的数字十分巨大，放在一起的话，图表则无法清楚表示)
            StatusNameDic.Add("connections1.available", "connections.available");
            StatusNameDic.Add("connections2.current", "connections.current");
            StatusNameDic.Add("connections2.totalCreated", "connections.totalCreated");

            //network
            StatusNameDic.Add("network.bytesIn", "network.bytesIn");
            StatusNameDic.Add("network.bytesOut", "network.bytesOut");
            StatusNameDic.Add("network.numRequests", "network.numRequests");
            StatusNameDic.Add("network.physicalBytesIn", "network.physicalBytesIn");
            StatusNameDic.Add("network.physicalBytesOut", "network.physicalBytesOut");

        }

        /// <summary>
        ///     获得值
        /// </summary>
        /// <param name="Doc"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static BsonValue GetValue(BsonDocument Doc, string Path)
        {
            var PathArray = Path.Split(".".ToCharArray());
            return Doc.GetElement(PathArray[0]).Value.AsBsonDocument.GetElement(PathArray[1]).Value;
        }

        public static Dictionary<string, string> GetCatalogDic(string CatalogName)
        {
            var  CatalogDic = new Dictionary<string, string>();
            foreach (var strKey in StatusNameDic.Keys)
            {
                if (strKey.StartsWith(CatalogName + "."))
                {
                    CatalogDic.Add(strKey, StatusNameDic[strKey]);
                }
            }
            return CatalogDic;
        }

        public static List<string> GetCatalog()
        {
            var lst = new List<string>();
            foreach (var item in StatusNameDic.Keys)
            {
                var Catalog = item.Split(".".ToCharArray())[0];
                if (!lst.Contains(Catalog)) lst.Add(Catalog);
            }
            return lst;
        }
    }
}
