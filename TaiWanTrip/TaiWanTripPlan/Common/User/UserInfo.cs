using Common.Database;
using MongoDB.Driver.Builders;

namespace Common.User
{
    public class UserInfo : EntityBase
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName;
        /// <summary>
        /// MD5密码
        /// </summary>
        public string Md5Password;
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email;
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        public static void InsertUser(UserInfo user)
        {
            Operater.InsertRec("Account",user);
        }
        /// <summary>
        /// 通过用户名获得用户实体
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static UserInfo GetUserByName(string userName)
        {
            var query = Query.EQ("UserName", userName);
            return Operater.GetFirstRec<UserInfo>("Account", query);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public static void  DeleteUser(string userName)
        {
            var query = Query.EQ("UserName", userName);
            Operater.DeleteRec("Account", GetUserByName(userName));
        }
    }
}
