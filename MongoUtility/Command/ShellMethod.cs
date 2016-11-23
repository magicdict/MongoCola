using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;

namespace MongoUtility.Command
{
    public class ShellMethod
    {
        #region"Replset"

        /// <summary>
        ///     增加服务器
        /// </summary>
        /// <param name="mongoSvr">副本组主服务器</param>
        /// <param name="hostPort">服务器信息</param>
        /// <param name="isArb">是否为仲裁服务器</param>
        /// <returns></returns>
        public static CommandResult AddToReplsetServer(MongoServer mongoSvr, string hostPort, int priority, bool isArb)
        {
            var mCommandResult = new CommandResult(new BsonDocument());
            try
            {
                if (!isArb)
                {
                    var code = "rs.add({_id:" + (mongoSvr.Instances.Length + 1) + ",host:'" + hostPort + "',priority:" + priority + "});";
                    mCommandResult = CommandExecute.ExecuteJsShell(code, mongoSvr);
                }
                else
                {
                    //其实addArb最后也只是调用了add方法
                    mCommandResult = CommandExecute.ExecuteJsShell("rs.addArb('" + hostPort + "');", mongoSvr);
                }
            }
            catch (EndOfStreamException)
            {

            }
            return mCommandResult;
        }

        /// <summary>
        ///     删除服务器
        /// </summary>
        /// <param name="mongoSvr">副本组主服务器</param>
        /// <param name="hostPort">服务器信息</param>
        /// <remarks>这个命令C#无法正确执行</remarks>
        /// <returns></returns>
        public static CommandResult RemoveFromReplsetServer(MongoServer mongoSvr, string hostPort)
        {
            var mCommandResult = new CommandResult(new BsonDocument());
            try
            {
                CommandExecute.ExecuteJsShell("rs.remove('" + hostPort + "');", mongoSvr);
            }
            catch (EndOfStreamException)
            {

            }
            return mCommandResult;
        }

        /// <summary>
        ///     重新启动
        /// </summary>
        /// <param name="primarySvr">副本组主服务器</param>
        /// <param name="config">服务器信息</param>
        /// <remarks>这个命令C#无法正确执行</remarks>
        /// <returns></returns>
        public static CommandResult ReconfigReplsetServer(MongoServer primarySvr, BsonDocument config)
        {
            var cmdRtn = new CommandResult(new BsonDocument());
            try
            {
                return CommandExecute.ExecuteJsShell("rs.reconfig(" + config + ",{force : true})", primarySvr);
            }
            catch (EndOfStreamException)
            {

            }
            return cmdRtn;
        }

        #endregion
    }
}
