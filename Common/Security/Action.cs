using System;
using System.Collections.Generic;

namespace Common.Security
{
    /// <summary>
    /// 
    /// </summary>
    public static class Action
    {
        /// <summary>
        ///     根据内置角色判断能否执行操作
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static Boolean JudgeRightByBuildInRole(List<String> roles, ActionType action)
        {
            Boolean CanDoIt = false;
            switch (action)
            {
                case ActionType.DatabaseManagementActions_dropCollection:
                case ActionType.ServerAdministrationActions_repairDatabase:
                    if (roles.Contains(Role.UserRole_clusterAdmin))
                    {
                        CanDoIt = true;
                    }
                    break;
                case ActionType.Misc_EvalJS:
                    //http://docs.mongodb.org/manual/reference/user-privileges/
                    //Combined Access
                    //Requires readWriteAnyDatabase, userAdminAnyDatabase, dbAdminAnyDatabase and clusterAdmin (on the admin database.)
                    if (roles.Contains(Role.UserRole_readWriteAnyDatabase) &&
                        roles.Contains(Role.UserRole_userAdminAnyDatabase) &&
                        roles.Contains(Role.UserRole_dbAdminAnyDatabase) &&
                        roles.Contains(Role.UserRole_clusterAdmin))
                    {
                        CanDoIt = true;
                    }
                    break;
                case ActionType.DatabaseManagementActions_createCollection:
                case ActionType.Misc_InitGFS:
                    if (roles.Contains(Role.UserRole_readWrite) ||
                        roles.Contains(Role.UserRole_readWriteAnyDatabase) ||
                        roles.Contains(Role.UserRole_dbAdmin))
                    {
                        CanDoIt = true;
                    }
                    break;
                case ActionType.DatabaseManagementActions_createUser:
                    if (roles.Contains(Role.UserRole_userAdmin) ||
                        roles.Contains(Role.UserRole_userAdminAnyDatabase))
                    {
                        CanDoIt = true;
                    }
                    break;
                default:
                    break;
            }
            return CanDoIt;
        }
        //http://docs.mongodb.org/master/reference/privilege-actions/#security-user-actions
        /// <summary>
        /// Queryand Write Actions
        /// </summary>
        public enum ActionType
        {
            QueryandWriteActions_find,
            QueryandWriteActions_insert,
            QueryandWriteActions_remove,
            QueryandWriteActions_update,

            DatabaseManagementActions_createCollection,
            DatabaseManagementActions_createUser,
            DatabaseManagementActions_dropCollection,

            ServerAdministrationActions_dropDatabase,
            ServerAdministrationActions_repairDatabase,

            Misc_InitGFS,
            Misc_EvalJS,
        }
    }
}
