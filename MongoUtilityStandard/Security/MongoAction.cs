using MongoDB.Bson;
using System.Collections.Generic;

namespace MongoUtility.Security
{
    /// <summary>
    ///     
    /// </summary>
    public static class MongoAction
    {
        //http://docs.mongodb.org/master/reference/privilege-actions/#security-user-actions

        /// <summary>
        ///     Action Group
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

        /// <summary>
        ///     Queryand Write Actions
        /// </summary>
        public enum ActionType
        {
            //Query
            QueryAndWriteActionsFind = 0,
            QueryAndWriteActionsInsert,
            QueryAndWriteActionsRemove,
            QueryAndWriteActionsUpdate,
            QueryAndWriteActionsBypassDocumentValidation,

            //Database Management
            DatabaseManagementActionsChangeCustomData = 100,
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
            DeploymentManagementActionsAuthSchemaUpgrade = 200,
            DeploymentManagementActionsCleanupOrphaned,
            DeploymentManagementActionsCpuProfiler,
            DeploymentManagementActionsInprog,
            DeploymentManagementActionsInvalidateUserCache,
            DeploymentManagementActionsKillop,
            DeploymentManagementActionsPlanCacheRead,
            DeploymentManagementActionsPlanCacheWrite,
            DeploymentManagementActionsStorageDetails,

            //Replication
            ReplicationActionsAppendOplogNote = 300,
            ReplicationActionsReplSetConfigure,
            ReplicationActionsReplSetGetStatus,
            ReplicationActionsReplSetHeartbeat,
            ReplicationActionsReplSetStateChange,
            ReplicationActionsResync,

            //Sharding
            ShardingActionsAddShard = 400,
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

            //Server Administration Actions
            ServerAdministrationActionsApplicationMessage = 500,
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

            //Diagnostic
            DiagnosticActionsCollStats = 600,
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

            //Internal
            InternalActionsAnyAction = 700,
            InternalActionsInternal,

            //Tool Defined
            MiscActionsInitGfs = 900,
            MiscActionsEvalJs
        }

        /// <summary>
        ///     GetActionArray
        /// </summary>
        /// <param name="actionList"></param>
        /// <returns></returns>
        public static BsonArray GetActionArray(List<string> actionList)
        {
            var result = new BsonArray();
            result.AddRange(actionList);
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
                case ActionType.MiscActionsEvalJs:
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
                case ActionType.MiscActionsInitGfs:
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