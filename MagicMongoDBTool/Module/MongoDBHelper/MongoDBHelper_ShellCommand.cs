using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {

        //Replica Set Commands
        //http://www.mongodb.org/display/DOCS/Replica+Set+Commands
        //rs.help()                       show help
        //rs.status()                     { replSetGetStatus : 1 }
        //rs.initiate()                   { replSetInitiate : null } initiate
        //                                    with default settings
        //rs.initiate(cfg)                { replSetInitiate : cfg }
        //rs.add(hostportstr)             add a new member to the set
        //rs.add(membercfgobj)            add a new member to the set
        //rs.addArb(hostportstr)          add a new member which is arbiterOnly:true
        //rs.remove(hostportstr)          remove a member (primary, secondary, or arbiter) from the set
        //rs.stepDown()                   { replSetStepDown : true }
        //rs.conf()                       return configuration from local.system.replset
        //db.isMaster()                   check who is primary

        /// <summary>
        /// 增加服务器
        /// </summary>
        /// <param name="mongoSvr">副本组主服务器</param>
        /// <param name="HostPort">服务器信息</param>
        /// <param name="IsArb">是否为仲裁服务器</param>
        /// <returns></returns>
        public static CommandResult AddToReplsetServer(MongoServer mongoSvr, String HostPort, Boolean IsArb = false)
        {
            if (!IsArb)
            {
                return ExecuteJsShell("rs.add('" + HostPort + "');", mongoSvr);
            }
            else
            {
                //其实addArb最后也只是调用了add方法
                return ExecuteJsShell("rs.addArb('" + HostPort + "');", mongoSvr);
            }
        }
        /// <summary>
        /// 删除服务器
        /// </summary>
        /// <param name="mongoSvr">副本组主服务器</param>
        /// <param name="HostPort">服务器信息</param>
        /// <returns></returns>
        public static CommandResult RemoveFromReplsetServer(MongoServer mongoSvr, String HostPort)
        {
            return ExecuteJsShell("rs.remove('" + HostPort + "');", mongoSvr);
        }
        /// <summary>
        /// 使用Shell Helper命令
        /// </summary>
        /// <param name="JsShell"></param>
        /// <param name="mongoSvr"></param>
        /// <returns></returns>
        public static CommandResult ExecuteJsShell(String JsShell, MongoServer mongoSvr)
        {
            BsonDocument cmd = new BsonDocument();
            cmd.Add("$eval", new BsonJavaScript(JsShell));
            //必须nolock
            cmd.Add("nolock", true);
            CommandDocument mongoCmd = new CommandDocument() { cmd };
            return ExecuteMongoSvrCommand(mongoCmd, mongoSvr);
        }

    }
}
