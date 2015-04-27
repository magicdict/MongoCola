using System;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Extend;
using ResourceLib.Utility;
using Utility = Common.Logic.Utility;
using MongoDB.Bson;


namespace MongoGUICtl
{
    public static partial class UIHelper
    {
        /// <summary>
        /// 将数据库放入Node
        /// </summary>
        /// <param name="strDBName"></param>
        /// <param name="mongoSvrKey"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public static TreeNode FillDataBaseInfoToTreeNode(string strDBName, string mongoSvrKey, MongoClient client = null)
        {
            var strShowDBName = strDBName;
            if (!configuration.guiConfig.IsUseDefaultLanguage)
            {
                if (configuration.guiConfig.MStringResource.LanguageType == "Chinese")
                {
                    switch (strDBName)
                    {
                        case ConstMgr.DATABASE_NAME_ADMIN:
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
            mongoDBNode.Tag = ConstMgr.DATABASE_TAG + ":" + mongoSvrKey + "/" + strDBName;
            //var mongoDB = mongoSvr.GetDatabase(strDBName);

            var UserNode = new TreeNode("User", (int)GetSystemIcon.MainTreeImageType.UserIcon,
                (int)GetSystemIcon.MainTreeImageType.UserIcon);
            UserNode.Tag = ConstMgr.USER_LIST_TAG + ":" + mongoSvrKey + "/" + strDBName + "/" +
                           ConstMgr.COLLECTION_NAME_USER;
            mongoDBNode.Nodes.Add(UserNode);

            var JsNode = new TreeNode("JavaScript", (int)GetSystemIcon.MainTreeImageType.JavaScriptList,
                (int)GetSystemIcon.MainTreeImageType.JavaScriptList);
            JsNode.Tag = ConstMgr.JAVASCRIPT_TAG + ":" + mongoSvrKey + "/" + strDBName + "/" +
                         ConstMgr.COLLECTION_NAME_JAVASCRIPT;
            mongoDBNode.Nodes.Add(JsNode);

            var GFSNode = new TreeNode("Grid File System", (int)GetSystemIcon.MainTreeImageType.GFS,
                (int)GetSystemIcon.MainTreeImageType.GFS);
            GFSNode.Tag = ConstMgr.GRID_FILE_SYSTEM_TAG + ":" + mongoSvrKey + "/" + strDBName + "/" +
                          ConstMgr.COLLECTION_NAME_GFS_FILES;
            mongoDBNode.Nodes.Add(GFSNode);

            var mongoSysColListNode = new TreeNode("Collections(System)",
                (int)GetSystemIcon.MainTreeImageType.SystemCol, (int)GetSystemIcon.MainTreeImageType.SystemCol);
            mongoSysColListNode.Tag = ConstMgr.SYSTEM_COLLECTION_LIST_TAG + ":" + mongoSvrKey + "/" + strDBName;
            mongoDBNode.Nodes.Add(mongoSysColListNode);

            var mongoColListNode = new TreeNode("Collections(General)",
                (int)GetSystemIcon.MainTreeImageType.CollectionList,
                (int)GetSystemIcon.MainTreeImageType.CollectionList);
            mongoColListNode.Tag = ConstMgr.COLLECTION_LIST_TAG + ":" + mongoSvrKey + "/" + strDBName;
            var colNameList = MongoUtility.NewUtility.GetConnectionInfo.GetCollectionList(client, strDBName);
            foreach (BsonDocument ColDoc in colNameList)
            {
                var strColName = ColDoc.GetElement("name").Value.ToString();
                switch (strColName)
                {
                    case ConstMgr.COLLECTION_NAME_USER:
                        //system.users,fs,system.js这几个系统级别的Collection不需要放入
                        break;
                    case ConstMgr.COLLECTION_NAME_JAVASCRIPT:
                        //foreach (var doc in  MongoUtility.NewUtility.GetConnectionInfo.GetCollectionInfo(client, strDBName, ConstMgr.COLLECTION_NAME_JAVASCRIPT).Find<BsonDocument>(null,null))
                        //{
                        //    var js = new TreeNode(doc.GetValue(ConstMgr.KEY_ID).ToString());
                        //    js.ImageIndex = (int) GetSystemIcon.MainTreeImageType.JsDoc;
                        //    js.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.JsDoc;
                        //    js.Tag = ConstMgr.JAVASCRIPT_DOC_TAG + ":" + mongoSvrKey + "/" + strDBName + "/" +
                        //             ConstMgr.COLLECTION_NAME_JAVASCRIPT + "/" + doc.GetValue(ConstMgr.KEY_ID);
                        //    JsNode.Nodes.Add(js);
                        //}
                        break;
                    default:
                        var mongoColNode = new TreeNode();
                        try
                        {
                            var ICol = MongoUtility.NewUtility.GetConnectionInfo.GetCollectionInfo(client, strDBName, strColName);
                            mongoColNode = FillCollectionInfoToTreeNode(ICol, mongoSvrKey);
                        }
                        catch (Exception ex)
                        {
                            mongoColNode = new TreeNode(strColName + "[exception:]");
                            mongoColNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Err;
                            mongoColNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Err;
                            Utility.ExceptionDeal(ex);
                        }
                        if (OperationHelper.IsSystemCollection(strDBName, strColName))
                        {
                            switch (strColName)
                            {
                                case ConstMgr.COLLECTION_NAME_GFS_CHUNKS:
                                case ConstMgr.COLLECTION_NAME_GFS_FILES:
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
            mongoDBNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
            mongoDBNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
            return mongoDBNode;
        }

    }
}
