using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool.Module
{
    public static partial class UIHelper
    {
        public static TreeNode FillDataBaseInfoToTreeNode(String strDBName, MongoServer mongoSvr, String mongoSvrKey)
        {
            String strShowDBName = strDBName;
            if (!SystemManager.IsUseDefaultLanguage)
            {
                if (SystemManager.MStringResource.LanguageType == "Chinese")
                {
                    switch (strDBName)
                    {
                        case MongoDbHelper.DATABASE_NAME_ADMIN:
                            strShowDBName = "管理员权限(admin)";
                            break;
                        case "local":
                            strShowDBName = "本地(local)";
                            break;
                        case "config":
                            strShowDBName = "配置(config)";
                            break;
                        default:
                            break;
                    }
                }
            }
            var mongoDBNode = new TreeNode(strShowDBName);
            mongoDBNode.Tag = MongoDbHelper.DATABASE_TAG + ":" + mongoSvrKey + "/" + strDBName;
            MongoDatabase mongoDB = mongoSvr.GetDatabase(strDBName);

            var UserNode = new TreeNode("User", (int) GetSystemIcon.MainTreeImageType.UserIcon,
                (int) GetSystemIcon.MainTreeImageType.UserIcon);
            UserNode.Tag = MongoDbHelper.USER_LIST_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + MongoDbHelper.COLLECTION_NAME_USER;
            mongoDBNode.Nodes.Add(UserNode);

            var JsNode = new TreeNode("JavaScript", (int) GetSystemIcon.MainTreeImageType.JavaScriptList,
                (int) GetSystemIcon.MainTreeImageType.JavaScriptList);
            JsNode.Tag = MongoDbHelper.JAVASCRIPT_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" + MongoDbHelper.COLLECTION_NAME_JAVASCRIPT;
            mongoDBNode.Nodes.Add(JsNode);

            var GFSNode = new TreeNode("Grid File System", (int) GetSystemIcon.MainTreeImageType.GFS,
                (int) GetSystemIcon.MainTreeImageType.GFS);
            GFSNode.Tag = MongoDbHelper.GRID_FILE_SYSTEM_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" +
                          MongoDbHelper.COLLECTION_NAME_GFS_FILES;
            mongoDBNode.Nodes.Add(GFSNode);

            var mongoSysColListNode = new TreeNode("Collections(System)",
                (int) GetSystemIcon.MainTreeImageType.SystemCol, (int) GetSystemIcon.MainTreeImageType.SystemCol);
            mongoSysColListNode.Tag = MongoDbHelper.SYSTEM_COLLECTION_LIST_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name;
            mongoDBNode.Nodes.Add(mongoSysColListNode);

            var mongoColListNode = new TreeNode("Collections(General)",
                (int) GetSystemIcon.MainTreeImageType.CollectionList,
                (int) GetSystemIcon.MainTreeImageType.CollectionList);
            mongoColListNode.Tag = MongoDbHelper.COLLECTION_LIST_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name;
            List<String> colNameList = mongoDB.GetCollectionNames().ToList();
            foreach (String strColName in colNameList)
            {
                switch (strColName)
                {
                    case MongoDbHelper.COLLECTION_NAME_USER:
                        //system.users,fs,system.js这几个系统级别的Collection不需要放入
                        break;
                    case MongoDbHelper.COLLECTION_NAME_JAVASCRIPT:
                        foreach (BsonDocument t in mongoDB.GetCollection(MongoDbHelper.COLLECTION_NAME_JAVASCRIPT).FindAll())
                        {
                            var js = new TreeNode(t.GetValue(MongoDbHelper.KEY_ID).ToString());
                            js.ImageIndex = (int) GetSystemIcon.MainTreeImageType.JsDoc;
                            js.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.JsDoc;
                            js.Tag = MongoDbHelper.JAVASCRIPT_DOC_TAG + ":" + mongoSvrKey + "/" + mongoDB.Name + "/" +
                                     MongoDbHelper.COLLECTION_NAME_JAVASCRIPT + "/" + t.GetValue(MongoDbHelper.KEY_ID);
                            JsNode.Nodes.Add(js);
                        }
                        break;
                    default:
                        var mongoColNode = new TreeNode();
                        try
                        {
                            mongoColNode = FillCollectionInfoToTreeNode(strColName, mongoDB, mongoSvrKey);
                        }
                        catch (Exception ex)
                        {
                            mongoColNode = new TreeNode(strColName + "[exception:]");
                            mongoColNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Err;
                            mongoColNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Err;
                            SystemManager.ExceptionDeal(ex);
                        }
                        if (MongoDbHelper.IsSystemCollection(mongoDB.Name, strColName))
                        {
                            switch (strColName)
                            {
                                case MongoDbHelper.COLLECTION_NAME_GFS_CHUNKS:
                                case MongoDbHelper.COLLECTION_NAME_GFS_FILES:
                                    GFSNode.Nodes.Add(mongoColNode);
                                    break;
                                default:
                                    mongoSysColListNode.Nodes.Add(mongoColNode);
                                    break;
                            }
                        }
                        else
                        {
                            mongoColListNode.Nodes.Add(mongoColNode);
                        }
                        break;
                }
            }
            mongoDBNode.Nodes.Add(mongoColListNode);
            mongoDBNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Database;
            mongoDBNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Database;
            return mongoDBNode;
        }

        /// <summary>
        /// </summary>
        /// <param name="strColName"></param>
        /// <param name="mongoDB"></param>
        /// <param name="mongoConnSvrKey"></param>
        /// <returns></returns>
        public static TreeNode FillCollectionInfoToTreeNode(String strColName, MongoDatabase mongoDB,
            String mongoConnSvrKey)
        {
            String strShowColName = strColName;
            if (!SystemManager.IsUseDefaultLanguage)
            {
                switch (strShowColName)
                {
                    case "chunks":
                        if (mongoDB.Name == "config")
                        {
                            strShowColName =
                                SystemManager.MStringResource.GetText(StringResource.TextType.SYSTEMC_COLNAME_chunks) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "collections":
                        if (mongoDB.Name == "config")
                        {
                            strShowColName =
                                SystemManager.MStringResource.GetText(
                                    StringResource.TextType.SYSTEMC_COLNAME_collections) + "(" + strShowColName + ")";
                        }
                        break;
                    case "changelog":
                        if (mongoDB.Name == "config")
                        {
                            strShowColName =
                                SystemManager.MStringResource.GetText(StringResource.TextType.SYSTEMC_COLNAME_changelog) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "databases":
                        if (mongoDB.Name == "config")
                        {
                            strShowColName =
                                SystemManager.MStringResource.GetText(StringResource.TextType.SYSTEMC_COLNAME_databases) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "lockpings":
                        if (mongoDB.Name == "config")
                        {
                            strShowColName =
                                SystemManager.MStringResource.GetText(StringResource.TextType.SYSTEMC_COLNAME_lockpings) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "locks":
                        if (mongoDB.Name == "config")
                        {
                            strShowColName =
                                SystemManager.MStringResource.GetText(StringResource.TextType.SYSTEMC_COLNAME_locks) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "mongos":
                        if (mongoDB.Name == "config")
                        {
                            strShowColName =
                                SystemManager.MStringResource.GetText(StringResource.TextType.SYSTEMC_COLNAME_mongos) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "settings":
                        if (mongoDB.Name == "config")
                        {
                            strShowColName =
                                SystemManager.MStringResource.GetText(StringResource.TextType.SYSTEMC_COLNAME_settings) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "shards":
                        if (mongoDB.Name == "config")
                        {
                            strShowColName =
                                SystemManager.MStringResource.GetText(StringResource.TextType.SYSTEMC_COLNAME_shards) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "tags":
                        //ADD: 2013/01/04 Mongo2.2.2开始支持ShardTag了 
                        if (mongoDB.Name == "config")
                        {
                            strShowColName =
                                SystemManager.MStringResource.GetText(StringResource.TextType.SYSTEMC_COLNAME_tags) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "version":
                        if (mongoDB.Name == "config")
                        {
                            strShowColName =
                                SystemManager.MStringResource.GetText(StringResource.TextType.SYSTEMC_COLNAME_version) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "me":
                        if (mongoDB.Name == "local")
                        {
                            strShowColName =
                                SystemManager.MStringResource.GetText(StringResource.TextType.SYSTEMC_COLNAME_me) + "(" +
                                strShowColName + ")";
                        }
                        break;
                    case "sources":
                        if (mongoDB.Name == "local")
                        {
                            strShowColName =
                                SystemManager.MStringResource.GetText(StringResource.TextType.SYSTEMC_COLNAME_sources) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "slaves":
                        if (mongoDB.Name == "local")
                        {
                            strShowColName =
                                SystemManager.MStringResource.GetText(StringResource.TextType.SYSTEMC_COLNAME_slaves) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case MongoDbHelper.COLLECTION_NAME_GFS_CHUNKS:
                        strShowColName =
                            SystemManager.MStringResource.GetText(StringResource.TextType.COLLECTION_NAME_GFS_CHUNKS) +
                            "(" + strShowColName + ")";
                        break;
                    case MongoDbHelper.COLLECTION_NAME_GFS_FILES:
                        strShowColName =
                            SystemManager.MStringResource.GetText(StringResource.TextType.COLLECTION_NAME_GFS_FILES) +
                            "(" + strShowColName + ")";
                        break;
                    case MongoDbHelper.COLLECTION_NAME_OPERATION_LOG:
                        strShowColName =
                            SystemManager.MStringResource.GetText(StringResource.TextType.COLLECTION_NAME_OPERATION_LOG) +
                            "(" + strShowColName + ")";
                        break;
                    case MongoDbHelper.COLLECTION_NAME_SYSTEM_INDEXES:
                        strShowColName =
                            SystemManager.MStringResource.GetText(StringResource.TextType.COLLECTION_NAME_SYSTEM_INDEXES) +
                            "(" + strShowColName + ")";
                        break;
                    case MongoDbHelper.COLLECTION_NAME_JAVASCRIPT:
                        strShowColName =
                            SystemManager.MStringResource.GetText(StringResource.TextType.COLLECTION_NAME_JAVASCRIPT) +
                            "(" + strShowColName + ")";
                        break;
                    case MongoDbHelper.COLLECTION_NAME_SYSTEM_REPLSET:
                        strShowColName =
                            SystemManager.MStringResource.GetText(StringResource.TextType.COLLECTION_NAME_SYSTEM_REPLSET) +
                            "(" + strShowColName + ")";
                        break;
                    case MongoDbHelper.COLLECTION_NAME_REPLSET_MINVALID:
                        strShowColName =
                            SystemManager.MStringResource.GetText(
                                StringResource.TextType.COLLECTION_NAME_REPLSET_MINVALID) + "(" + strShowColName + ")";
                        break;
                    case MongoDbHelper.COLLECTION_NAME_USER:
                        strShowColName =
                            SystemManager.MStringResource.GetText(StringResource.TextType.COLLECTION_NAME_USER) + "(" +
                            strShowColName + ")";
                        break;
                    case MongoDbHelper.COLLECTION_NAME_ROLE:
                        //New From 2.6 
                        strShowColName =
                            SystemManager.MStringResource.GetText(StringResource.TextType.COLLECTION_NAME_ROLE) + "(" +
                            strShowColName + ")";
                        break;
                    case MongoDbHelper.COLLECTION_NAME_SYSTEM_PROFILE:
                        strShowColName =
                            SystemManager.MStringResource.GetText(StringResource.TextType.COLLECTION_NAME_SYSTEM_PROFILE) +
                            "(" + strShowColName + ")";
                        break;
                    default:
                        break;
                }
            }
            TreeNode mongoColNode;
            mongoColNode = new TreeNode(strShowColName);
            switch (strColName)
            {
                case MongoDbHelper.COLLECTION_NAME_GFS_FILES:
                    mongoColNode.Tag = MongoDbHelper.GRID_FILE_SYSTEM_TAG + ":" + mongoConnSvrKey + "/" + mongoDB.Name + "/" +
                                       strColName;
                    break;
                case MongoDbHelper.COLLECTION_NAME_USER:
                    mongoColNode.Tag = MongoDbHelper.USER_LIST_TAG + ":" + mongoConnSvrKey + "/" + mongoDB.Name + "/" + strColName;
                    break;
                //case COLLECTION_NAME_ROLE:
                //    mongoColNode.Tag = USER_LIST_TAG + ":" + mongoConnSvrKey + "/" + mongoDB.Name + "/" + strColName;
                //    break;
                default:
                    mongoColNode.Tag = MongoDbHelper.COLLECTION_TAG + ":" + mongoConnSvrKey + "/" + mongoDB.Name + "/" + strColName;
                    break;
            }

            MongoCollection mongoCol = mongoDB.GetCollection(strColName);

            //Start ListIndex
            var mongoIndexes = new TreeNode("Indexes");
            GetIndexesResult indexList = mongoCol.GetIndexes();
            foreach (IndexInfo indexDoc in indexList.ToList())
            {
                var mongoIndex = new TreeNode();
                if (!SystemManager.IsUseDefaultLanguage)
                {
                    mongoIndex.Text = (SystemManager.MStringResource.GetText(StringResource.TextType.Index_Name) + ":" +
                                       indexDoc.Name);
                    mongoIndex.Nodes.Add(String.Empty,
                        SystemManager.MStringResource.GetText(StringResource.TextType.Index_Keys) + ":" +
                        GetKeyString(indexDoc.Key), (int) GetSystemIcon.MainTreeImageType.KeyInfo,
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty,
                        SystemManager.MStringResource.GetText(StringResource.TextType.Index_RepeatDel) + ":" +
                        indexDoc.DroppedDups, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty,
                        SystemManager.MStringResource.GetText(StringResource.TextType.Index_Background) + ":" +
                        indexDoc.IsBackground, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty,
                        SystemManager.MStringResource.GetText(StringResource.TextType.Index_Sparse) + ":" +
                        indexDoc.IsSparse, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty,
                        SystemManager.MStringResource.GetText(StringResource.TextType.Index_Unify) + ":" +
                        indexDoc.IsUnique, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty,
                        SystemManager.MStringResource.GetText(StringResource.TextType.Index_NameSpace) + ":" +
                        indexDoc.Namespace, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty,
                        SystemManager.MStringResource.GetText(StringResource.TextType.Index_Version) + ":" +
                        indexDoc.Version, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    if (indexDoc.TimeToLive == TimeSpan.MaxValue)
                    {
                        mongoIndex.Nodes.Add(String.Empty,
                            SystemManager.MStringResource.GetText(StringResource.TextType.Index_ExpireData) + ":Not Set",
                            (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    }
                    else
                    {
                        mongoIndex.Nodes.Add(String.Empty,
                            SystemManager.MStringResource.GetText(StringResource.TextType.Index_ExpireData) + ":" +
                            indexDoc.TimeToLive.TotalSeconds, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
                            (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    }
                }
                else
                {
                    mongoIndex.Text = "IndexName:" + indexDoc.Name;
                    mongoIndex.Nodes.Add(String.Empty, "Keys:" + GetKeyString(indexDoc.Key),
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, "DroppedDups :" + indexDoc.DroppedDups,
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, "IsBackground:" + indexDoc.IsBackground,
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, "IsSparse:" + indexDoc.IsSparse,
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, "IsUnique:" + indexDoc.IsUnique,
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, "NameSpace:" + indexDoc.Namespace,
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, "Version:" + indexDoc.Version,
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    if (indexDoc.TimeToLive == TimeSpan.MaxValue)
                    {
                        mongoIndex.Nodes.Add(String.Empty, "Expire Data:Not Set",
                            (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    }
                    else
                    {
                        mongoIndex.Nodes.Add(String.Empty, "Expire Data(sec):" + indexDoc.TimeToLive.TotalSeconds,
                            (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    }
                }
                if (indexDoc.RawDocument.Contains("default_language"))
                {
                    //TextIndex
                    mongoIndex.Nodes.Add(String.Empty, "weights:" + indexDoc.RawDocument["weights"],
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, "default_language:" + indexDoc.RawDocument["default_language"],
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, "language_override:" + indexDoc.RawDocument["language_override"],
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                    mongoIndex.Nodes.Add(String.Empty, "textIndexVersion:" + indexDoc.RawDocument["textIndexVersion"],
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                }
                mongoIndex.ImageIndex = (int) GetSystemIcon.MainTreeImageType.DBKey;
                mongoIndex.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.DBKey;
                mongoIndex.Tag = MongoDbHelper.INDEX_TAG + ":" + mongoConnSvrKey + "/" + mongoDB.Name + "/" + strColName + "/" +
                                 indexDoc.Name;
                mongoIndexes.Nodes.Add(mongoIndex);
            }
            mongoIndexes.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Keys;
            mongoIndexes.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Keys;
            mongoIndexes.Tag = MongoDbHelper.INDEXES_TAG + ":" + mongoConnSvrKey + "/" + mongoDB.Name + "/" + strColName;
            mongoColNode.Nodes.Add(mongoIndexes);
            //End ListIndex

            mongoColNode.ToolTipText = strColName + Environment.NewLine;
            mongoColNode.ToolTipText += "IsCapped:" + mongoCol.GetStats().IsCapped;

            if (strColName == MongoDbHelper.COLLECTION_NAME_USER)
            {
                mongoColNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.UserIcon;
                mongoColNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.UserIcon;
            }
            else
            {
                mongoColNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Collection;
                mongoColNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Collection;
            }
            //End Data
            return mongoColNode;
        }

        /// <summary>
        ///     Key String
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static string GetKeyString(IndexKeysDocument keys)
        {
            String KeyString = string.Empty;
            foreach (BsonElement key in keys.Elements)
            {
                KeyString += key.Name + ":";
                switch (key.Value.ToString())
                {
                    case "1":
                        KeyString += MongoDbHelper.IndexType.Ascending.ToString();
                        break;
                    case "-1":
                        KeyString += MongoDbHelper.IndexType.Descending.ToString();
                        break;
                    case "2d":
                        KeyString += MongoDbHelper.IndexType.GeoSpatial.ToString();
                        break;
                    case "text":
                        KeyString += MongoDbHelper.IndexType.Text.ToString();
                        break;
                    default:
                        break;
                }
                KeyString += ";";
            }
            KeyString = "[" + KeyString.TrimEnd(";".ToArray()) + "]";
            return KeyString;
        }
    }
}