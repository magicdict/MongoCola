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
        /// <summary>
        /// </summary>
        public static MongoConfig MongoConfig = new MongoConfig();

        #region Basic

        /// <summary>
        ///     连接名称
        /// </summary>
        public string ConnectionName { set; get; }

        /// <summary>
        ///     IP地址
        /// </summary>
        public string Host { set; get; }

        /// <summary>
        ///     端口号
        /// </summary>
        public int Port { set; get; }

        /// <summary>
        ///     用户名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        ///     密码
        /// </summary>
        public string Password { set; get; }

        /// <summary>
        ///     数据库名称
        /// </summary>
        public string DataBaseName { set; get; }

        #endregion

        #region Advance

        /// <summary>
        ///     存储引擎
        /// </summary>
        public EnumMgr.StorageEngineType StorageEngine;

        /// <summary>
        ///     副本名称
        /// </summary>
        public string ReplSetName;

        /// <summary>
        ///     副本服务器列表
        /// </summary>
        public List<string> ReplsetList;


        /// <summary>
        ///     连接字符串
        /// </summary>
        public string ConnectionString;

        /// <summary>
        ///     VerifySslCertificate
        /// </summary>
        public bool VerifySslCertificate;

        /// <summary>
        ///     connect TimeOut (Sec)
        /// </summary>
        public double ConnectTimeoutMs;

        /// <summary>
        ///     Socket TimeOut (Sec)
        /// </summary>
        public double SocketTimeoutMs;

        /// <summary>
        ///     fsync
        /// </summary>
        /// <remarks>
        ///     true: the driver adds { fsync : true } to the getlasterror command. Implies safe=true.
        ///     false: the driver does not not add fsync to the getlasterror command.
        /// </remarks>
        public bool Fsync;

        /// <summary>
        ///     journal
        /// </summary>
        public bool Journal;

        #endregion

        #region Certificate

        /// <summary>
        ///     使用SSL初始化连接
        /// </summary>
        public bool UseSsl { set; get; }

        /// <summary>
        ///     SSL认证文件
        /// </summary>
        public string SslCertificateFile;

        /// <summary>
        /// </summary>
        public bool UseSsh { set; get; }

        /// <summary>
        /// </summary>
        public string SshHost { set; get; }

        /// <summary>
        /// </summary>
        public int SshPort { set; get; }

        /// <summary>
        /// </summary>
        public string SshUser { set; get; }

        /// <summary>
        /// </summary>
        public string SshPassword { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string SshPrivateKeyFile;

        /// <summary>
        /// 验证机制
        /// </summary>
        public string AuthMechanism;

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
        [XmlIgnore] public bool IsReadOnly;

        /// <summary>
        ///     当前连接是否可以使用[这个属性是运行时决定的]
        /// </summary>
        [XmlIgnore] public bool Health;

        /// <summary>
        ///     作为Admin登陆[这个属性是运行时决定的]
        /// </summary>
        [XmlIgnore] public bool LoginAsAdmin;

        /// <summary>
        ///     当前连接的MongoDB版本[这个属性是运行时决定的]
        /// </summary>
        [XmlIgnore] public Version MongoDbVersion;

        /// <summary>
        ///     认证模式[这个属性是运行时决定的]
        /// </summary>
        [XmlIgnore] public bool AuthMode;

        /// <summary>
        ///     服务器角色[这个属性是运行时决定的]
        /// </summary>
        [XmlIgnore] public SvrRoleType ServerRole;

        #endregion

        #region"Default ReadWrite"

        public bool IsUseDefaultSetting;

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