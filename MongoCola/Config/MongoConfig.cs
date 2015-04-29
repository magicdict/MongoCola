using MongoUtility.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MongoCola.Config
{
    [Serializable]
    public class MongoConfig
    {
        #region"Mongo Config"
        /// <summary>
        ///     连接配置列表(管理用）
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, MongoConnectionConfig> ConnectionList =
            new Dictionary<string, MongoConnectionConfig>();
        /// <summary>
        ///     连接配置列表(保存用）
        /// </summary>
        public List<MongoConnectionConfig> SerializableConnectionList = new List<MongoConnectionConfig>();
        /// <summary>
        ///     ReadPreference
        /// </summary>
        public string ReadPreference;
        /// <summary>
        ///     WriteConcern
        /// </summary>
        public string WriteConcern;
        /// <summary>
        ///     WaitQueueSize;
        /// </summary>
        /// <remarks></remarks>
        public int WaitQueueSize;
        /// <summary>
        ///     wtimeoutMS
        /// </summary>
        /// <remarks>The driver adds { wtimeout : ms } to the getlasterror command. Implies safe=true.</remarks>
        public double WtimeoutMs;
        #endregion
    }
}
