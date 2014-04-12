using System;
using System.Collections.Generic;

namespace Common.Security
{
    /// <summary>
    /// 
    /// </summary>
    public static class Action
    {
        //http://docs.mongodb.org/master/reference/privilege-actions/#security-user-actions
        /// <summary>
        /// Queryand Write Actions
        /// </summary>
        public enum ActionType
        {
            //Query
            QueryandWriteActions_find,
            QueryandWriteActions_insert,
            QueryandWriteActions_remove,
            QueryandWriteActions_update,
            
            //Database Management
            DatabaseManagementActions_changeCustomData,
            DatabaseManagementActions_changeOwnCustomData,
            DatabaseManagementActions_changeOwnPassword,
            DatabaseManagementActions_changePassword,
            DatabaseManagementActions_createCollection,
            DatabaseManagementActions_createIndex,
            DatabaseManagementActions_createRole,
            DatabaseManagementActions_createUser,
            DatabaseManagementActions_dropCollection,
            DatabaseManagementActions_dropRole,
            DatabaseManagementActions_dropUser,
            DatabaseManagementActions_emptycapped,
            DatabaseManagementActions_enableProfiler,
            DatabaseManagementActions_grantRole,
            DatabaseManagementActions_killCursors,
            DatabaseManagementActions_revokeRole,
            DatabaseManagementActions_unlock,
            DatabaseManagementActions_viewRole,
            DatabaseManagementActions_viewUser,

            //Deployment Management
            DeploymentManagementActions_storageDetails,
            DeploymentManagementActions_planCacheWrite,
            DeploymentManagementActions_planCacheRead,
            DeploymentManagementActions_killop,
            DeploymentManagementActions_invalidateUserCache,
            DeploymentManagementActions_inprog,
            DeploymentManagementActions_cpuProfiler,
            DeploymentManagementActions_cleanupOrphaned,
            DeploymentManagementActions_authSchemaUpgrade,

            //Replication
            ReplicationActions_appendOplogNote,
            ReplicationActions_replSetConfigure,
            ReplicationActions_replSetGetStatus,
            ReplicationActions_replSetHeartbeat,
            ReplicationActions_replSetStateChange,
            ReplicationActions_resync,

            //Sharding
            ShardingActions_addShard,
            ShardingActions_enableSharding,
            ShardingActions_flushRouterConfig,
            ShardingActions_getShardMap,
            ShardingActions_getShardVersion,
            ShardingActions_listShards,
            ShardingActions_moveChunk,
            ShardingActions_removeShard,
            ShardingActions_shardingState,
            ShardingActions_splitChunk,
            ShardingActions_splitVector,

            //Diagnostic
            DiagnosticActions_collStats,
            DiagnosticActions_connPoolStats,
            DiagnosticActions_cursorInfo,
            DiagnosticActions_dbHash,
            DiagnosticActions_dbStats,
            DiagnosticActions_diagLogging,
            DiagnosticActions_getCmdLineOpts,
            DiagnosticActions_getLog,
            DiagnosticActions_indexStats,
            DiagnosticActions_listDatabases,
            DiagnosticActions_netstat,
            DiagnosticActions_serverStatus,
            DiagnosticActions_top,
            DiagnosticActions_validate,

            //Server Administration Actions
            ServerAdministrationActions_applicationMessage,
            ServerAdministrationActions_closeAllDatabases,
            ServerAdministrationActions_collMod,
            ServerAdministrationActions_compact,
            ServerAdministrationActions_connPoolSync,
            ServerAdministrationActions_convertToCapped,
            ServerAdministrationActions_dropDatabase,
            ServerAdministrationActions_dropIndex,
            ServerAdministrationActions_fsync,
            ServerAdministrationActions_getParameter,
            ServerAdministrationActions_hostInfo,
            ServerAdministrationActions_logRotate,
            ServerAdministrationActions_reIndex,
            ServerAdministrationActions_renameCollectionSameDB,
            ServerAdministrationActions_repairDatabase,
            ServerAdministrationActions_setParameter,
            ServerAdministrationActions_shutdown,
            ServerAdministrationActions_touch,

            //Internal
            InternalActions_anyAction,
            InternalActions_internal,

            //Tool Defined
            Misc_InitGFS,
            Misc_EvalJS,
        }
        /// <summary>
        /// 
        /// </summary>
        public enum ActionGroup {
            Query_and_Write_Actions,
            Database_Management_Actions,
            Deployment_Management_Actions,
            Replication_Actions,
            Sharding_Actions,
            Server_Administration_Actions,
            Diagnostic_Actions,
            Internal_Actions
        }
        /// <summary>
        /// GetActionListJs
        /// </summary>
        /// <param name="ActionList"></param>
        /// <returns></returns>
        public static String GetActionListJs(ActionType[] ActionList)
        {
            String Result = String.Empty;
            Result = "actions: [ ";
            for (int i = 0; i < ActionList.Length; i++)
            {
                Result += "'" + ActionList[i].ToString().Substring(ActionList[i].ToString().IndexOf("_") + 1) + "'" + ((i == ActionList.Length - 1) ? "" : ",");
            }
            Result += " ]";
            return Result;
        }
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
    }
}
