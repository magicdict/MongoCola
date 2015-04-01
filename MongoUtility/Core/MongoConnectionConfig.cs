/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/8
 * Time: 9:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MongoUtility.Basic;

namespace MongoUtility.Core
{
    /// <summary>
    ///     连接结构体
    /// </summary>
    [Serializable]
    public class MongoConnectionConfig
    {
        #region"固有属性"

        /// <summary>
        ///     连接名称
        /// </summary>
        public String ConnectionName;

        /// <summary>
        ///     存储引擎
        /// </summary>
        public EnumMgr.StorageEngineType StorageEngine;

        /// <summary>
        ///     连接字符串
        /// </summary>
        public String ConnectionString;

        /// <summary>
        ///     数据库名称
        /// </summary>
        public String DataBaseName;

        /// <summary>
        ///     副本名称
        /// </summary>
        public String ReplSetName;

        /// <summary>
        ///     副本服务器列表
        /// </summary>
        public List<String> ReplsetList;

        /// <summary>
        ///     IP地址
        /// </summary>
        public String Host;

        /// <summary>
        ///     端口号
        /// </summary>
        public int Port;

        /// <summary>
        ///     使用SSL初始化连接
        /// </summary>
        public Boolean UseSsl;

        /// <summary>
        ///     用户名
        /// </summary>
        public String UserName;

        /// <summary>
        ///     密码
        /// </summary>
        public String Password;

        /// <summary>
        ///     VerifySslCertificate
        /// </summary>
        public Boolean VerifySslCertificate;

        /// <summary>
        ///     connect TimeOut (Sec)
        /// </summary>
        public double connectTimeoutMS;

        /// <summary>
        ///     Socket TimeOut (Sec)
        /// </summary>
        public double socketTimeoutMS;

        /// <summary>
        ///     fsync
        /// </summary>
        /// <remarks>
        ///     true: the driver adds { fsync : true } to the getlasterror command. Implies safe=true.
        ///     false: the driver does not not add fsync to the getlasterror command.
        /// </remarks>
        public bool fsync;

        /// <summary>
        ///     journal
        /// </summary>
        public bool journal;

        #endregion

        #region"运行时属性"

        /// <summary>
        ///     服务器类型
        /// </summary>
        public enum SvrRoleType
        {
            /// <summary>
            ///     数据服务器[mongod]
            /// </summary>
            DataSvr,

            /// <summary>
            ///     Sharding服务器[mongos]
            /// </summary>
            ShardSvr,

            /// <summary>
            ///     副本服务器[Virtul]
            /// </summary>
            ReplsetSvr,

            /// <summary>
            ///     Master主服务器
            /// </summary>
            MasterSvr,

            /// <summary>
            ///     Slave从属服务器
            /// </summary>
            SlaveSvr
        }

        /// <summary>
        ///     只读[这个属性是运行时决定的]
        /// </summary>
        [XmlIgnore] public Boolean IsReadOnly;

        /// <summary>
        ///     当前连接是否可以使用[这个属性是运行时决定的]
        /// </summary>
        [XmlIgnore] public Boolean Health;

        /// <summary>
        ///     作为Admin登陆[这个属性是运行时决定的]
        /// </summary>
        [XmlIgnore] public bool LoginAsAdmin;

        /// <summary>
        ///     当前连接的MongoDB版本[这个属性是运行时决定的]
        /// </summary>
        [XmlIgnore] public Version MongoDBVersion;

        /// <summary>
        ///     认证模式[这个属性是运行时决定的]
        /// </summary>
        [XmlIgnore] public Boolean AuthMode;

        /// <summary>
        ///     服务器角色[这个属性是运行时决定的]
        /// </summary>
        [XmlIgnore] public SvrRoleType ServerRole;

        #endregion

        #region"Default ReadWrite"

        public Boolean IsUseDefaultSetting;

        /// <summary>
        ///     ReadPreference
        /// </summary>
        public String ReadPreference;

        /// <summary>
        ///     WriteConcern
        /// </summary>
        public String WriteConcern;

        /// <summary>
        ///     WaitQueueSize;
        /// </summary>
        /// <remarks></remarks>
        public int WaitQueueSize;

        /// <summary>
        ///     wtimeoutMS
        /// </summary>
        /// <remarks>The driver adds { wtimeout : ms } to the getlasterror command. Implies safe=true.</remarks>
        public double wtimeoutMS;

        #endregion
    }
}