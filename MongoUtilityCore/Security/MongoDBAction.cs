using System.Collections.Generic;

namespace MongoUtility.Security
{
    /// <summary>
    /// </summary>
    public static class MongoDbAction
    {
        /// <summary>
        /// </summary>
        public enum ActionGroup
        {
            QueryAndWriteActions,
            DatabaseManagementActions,
            DeploymentManagementActions,
            ReplicationActions,
            ShardingActions,
            ServerAdministrationActions,
            DiagnosticActions,
            InternalActions
        }

        //http://docs.mongodb.org/master/reference/privilege-actions/#security-user-actions

        /// <summary>
        ///     Queryand Write Actions
        /// </summary>
        public enum ActionType
        {
            //Query
            QueryandWriteActionsFind,
            QueryandWriteActionsInsert,
            QueryandWriteActionsRemove,
            QueryandWriteActionsUpdate,

            //Database Management
            DatabaseManagementActionsChangeCustomData,
            DatabaseManagementActionsChangeOwnCustomData,
            DatabaseManagementActionsChangeOwnPassword,
            DatabaseManagementActionsChangePassword,
            DatabaseManagementActionsCreateCollection,
            DatabaseManagementActionsCreateIndex,
            DatabaseManagementActionsCreateRole,
            DatabaseManagementActionsCreateUser,
            DatabaseManagementActionsDropCollection,
            DatabaseManagementActionsDropRole,
            DatabaseManagementActionsDropUser,
            DatabaseManagementActionsEmptycapped,
            DatabaseManagementActionsEnableProfiler,
            DatabaseManagementActionsGrantRole,
            DatabaseManagementActionsKillCursors,
            DatabaseManagementActionsRevokeRole,
            DatabaseManagementActionsUnlock,
            DatabaseManagementActionsViewRole,
            DatabaseManagementActionsViewUser,

            //Deployment Management
            DeploymentManagementActionsStorageDetails,
            DeploymentManagementActionsPlanCacheWrite,
            DeploymentManagementActionsPlanCacheRead,
            DeploymentManagementActionsKillop,
            DeploymentManagementActionsInvalidateUserCache,
            DeploymentManagementActionsInprog,
            DeploymentManagementActionsCpuProfiler,
            DeploymentManagementActionsCleanupOrphaned,
            DeploymentManagementActionsAuthSchemaUpgrade,

            //Replication
            ReplicationActionsAppendOplogNote,
            ReplicationActionsReplSetConfigure,
            ReplicationActionsReplSetGetStatus,
            ReplicationActionsReplSetHeartbeat,
            ReplicationActionsReplSetStateChange,
            ReplicationActionsResync,

            //Sharding
            ShardingActionsAddShard,
            ShardingActionsEnableSharding,
            ShardingActionsFlushRouterConfig,
            ShardingActionsGetShardMap,
            ShardingActionsGetShardVersion,
            ShardingActionsListShards,
            ShardingActionsMoveChunk,
            ShardingActionsRemoveShard,
            ShardingActionsShardingState,
            ShardingActionsSplitChunk,
            ShardingActionsSplitVector,

            //Diagnostic
            DiagnosticActionsCollStats,
            DiagnosticActionsConnPoolStats,
            DiagnosticActionsCursorInfo,
            DiagnosticActionsDbHash,
            DiagnosticActionsDbStats,
            DiagnosticActionsDiagLogging,
            DiagnosticActionsGetCmdLineOpts,
            DiagnosticActionsGetLog,
            DiagnosticActionsIndexStats,
            DiagnosticActionsListDatabases,
            DiagnosticActionsNetstat,
            DiagnosticActionsServerStatus,
            DiagnosticActionsTop,
            DiagnosticActionsValidate,

            //Server Administration Actions
            ServerAdministrationActionsApplicationMessage,
            ServerAdministrationActionsCloseAllDatabases,
            ServerAdministrationActionsCollMod,
            ServerAdministrationActionsCompact,
            ServerAdministrationActionsConnPoolSync,
            ServerAdministrationActionsConvertToCapped,
            ServerAdministrationActionsDropDatabase,
            ServerAdministrationActionsDropIndex,
            ServerAdministrationActionsFsync,
            ServerAdministrationActionsGetParameter,
            ServerAdministrationActionsHostInfo,
            ServerAdministrationActionsLogRotate,
            ServerAdministrationActionsReIndex,
            ServerAdministrationActionsRenameCollectionSameDb,
            ServerAdministrationActionsRepairDatabase,
            ServerAdministrationActionsSetParameter,
            ServerAdministrationActionsShutdown,
            ServerAdministrationActionsTouch,

            //Internal
            InternalActionsAnyAction,
            InternalActionsInternal,

            //Tool Defined
            MiscInitGfs,
            MiscEvalJs
        }

        /// <summary>
        ///     GetActionListJs
        /// </summary>
        /// <param name="actionList"></param>
        /// <returns></returns>
        public static string GetActionListJs(ActionType[] actionList)
        {
            var result = string.Empty;
            result = "actions: [ ";
            for (var i = 0; i < actionList.Length; i++)
            {
                result += "'" + actionList[i].ToString().Substring(actionList[i].ToString().IndexOf("_") + 1) + "'" +
                          (i == actionList.Length - 1 ? "" : ",");
            }
            result += " ]";
            return result;
        }

        /// <summary>
        ///     根据内置角色判断能否执行操作
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        /// <param name="action"></param>
        public static bool JudgeRightByBuildInRole(List<string> roles, ActionType action)
        {
            var canDoIt = false;
            switch (action)
            {
                case ActionType.DatabaseManagementActionsDropCollection:
                case ActionType.ServerAdministrationActionsRepairDatabase:
                    if (roles.Contains(Role.UserRoleClusterAdmin))
                    {
                        canDoIt = true;
                    }
                    break;
                case ActionType.MiscEvalJs:
                    //http://docs.mongodb.org/manual/reference/user-privileges/
                    //Combined Access
                    //Requires readWriteAnyDatabase, userAdminAnyDatabase, dbAdminAnyDatabase and clusterAdmin (on the admin database.)
                    if (roles.Contains(Role.UserRoleReadWriteAnyDatabase) &&
                        roles.Contains(Role.UserRoleUserAdminAnyDatabase) &&
                        roles.Contains(Role.UserRoleDbAdminAnyDatabase) &&
                        roles.Contains(Role.UserRoleClusterAdmin))
                    {
                        canDoIt = true;
                    }
                    break;
                case ActionType.DatabaseManagementActionsCreateCollection:
                case ActionType.MiscInitGfs:
                    if (roles.Contains(Role.UserRoleReadWrite) ||
                        roles.Contains(Role.UserRoleReadWriteAnyDatabase) ||
                        roles.Contains(Role.UserRoleDbAdmin))
                    {
                        canDoIt = true;
                    }
                    break;
                case ActionType.DatabaseManagementActionsCreateUser:
                    if (roles.Contains(Role.UserRoleUserAdmin) ||
                        roles.Contains(Role.UserRoleUserAdminAnyDatabase))
                    {
                        canDoIt = true;
                    }
                    break;
                default:
                    break;
            }
            return canDoIt;
        }
    }
}