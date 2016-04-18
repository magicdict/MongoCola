using System;
using System.Windows.Forms;
using Common;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;

namespace MongoGUICtl.ClientTree
{
    public static partial class UiHelper
    {
        /// <summary>
        ///     将数据库放入Node
        /// </summary>
        /// <param name="strDbName"></param>
        /// <param name="mongoSvrKey"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public static TreeNode FillDataBaseInfoToTreeNode(string strDbName, string mongoSvrKey,
            MongoClient client = null)
        {
            var strShowDbName = strDbName;
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                if (StringResource.LanguageType == "Chinese")
                {
                    switch (strDbName)
                    {
                        case ConstMgr.DatabaseNameAdmin:
                            strShowDbName = "管理员权限(admin)";
                            break;
                        case "local":
                            strShowDbName = "本地(local)";
                            break;
                        case "config":
                            strShowDbName = "配置(config)";
                            break;
                    }
                }
            }
            var mongoDbNode = new TreeNode(strShowDbName);
            mongoDbNode.Tag = TagInfo.CreateTagInfo(mongoSvrKey, strDbName);

            var userNode = new TreeNode("User", (int) GetSystemIcon.MainTreeImageType.UserIcon,
                (int) GetSystemIcon.MainTreeImageType.UserIcon);
            userNode.Tag = ConstMgr.UserListTag + ":" + mongoSvrKey + "/" + strDbName + "/" +
                           ConstMgr.CollectionNameUser;
            mongoDbNode.Nodes.Add(userNode);

            var jsNode = new TreeNode("JavaScript", (int) GetSystemIcon.MainTreeImageType.JavaScriptList,
                (int) GetSystemIcon.MainTreeImageType.JavaScriptList);
            jsNode.Tag = ConstMgr.JavascriptTag + ":" + mongoSvrKey + "/" + strDbName + "/" +
                         ConstMgr.CollectionNameJavascript;
            mongoDbNode.Nodes.Add(jsNode);

            var gfsNode = new TreeNode("Grid File System", (int) GetSystemIcon.MainTreeImageType.Gfs,
                (int) GetSystemIcon.MainTreeImageType.Gfs);
            gfsNode.Tag = ConstMgr.GridFileSystemTag + ":" + mongoSvrKey + "/" + strDbName + "/" +
                          ConstMgr.CollectionNameGfsFiles;
            mongoDbNode.Nodes.Add(gfsNode);

            var mongoSysColListNode = new TreeNode("Collections(System)",
                (int) GetSystemIcon.MainTreeImageType.SystemCol, (int) GetSystemIcon.MainTreeImageType.SystemCol);
            mongoSysColListNode.Tag = ConstMgr.SystemCollectionListTag + ":" + mongoSvrKey + "/" + strDbName;
            mongoDbNode.Nodes.Add(mongoSysColListNode);

            var mongoColListNode = new TreeNode("Collections(General)",
                (int) GetSystemIcon.MainTreeImageType.CollectionList,
                (int) GetSystemIcon.MainTreeImageType.CollectionList);
            mongoColListNode.Tag = ConstMgr.CollectionListTag + ":" + mongoSvrKey + "/" + strDbName;
            var colNameList = GetConnectionInfo.GetCollectionList(client, strDbName);
            //Collection按照名称排序
            colNameList.Sort((x, y) => {
                return x.GetElement("name").Value.ToString().CompareTo(y.GetElement("name").Value.ToString());
            });
            foreach (var colDoc in colNameList)
            {
                var strColName = colDoc.GetElement("name").Value.ToString();
                switch (strColName)
                {
                    case ConstMgr.CollectionNameUser:
                        //system.users,fs,system.js这几个系统级别的Collection不需要放入
                        break;
                    case ConstMgr.CollectionNameJavascript:
                        //foreach (var doc in  MongoHelper.NewUtility.GetConnectionInfo.GetCollectionInfo(client, strDBName, ConstMgr.COLLECTION_NAME_JAVASCRIPT).Find<BsonDocument>(null,null))
                        //{
                        //    var js = new TreeNode(doc.GetValue(ConstMgr.KEY_ID).ToString());
                        //    js.ImageIndex = (int) GetSystemIcon.MainTreeImageType.JsDoc;
                        //    js.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.JsDoc;
                        //    js.Tag = ConstMgr.JAVASCRIPT_DOC_TAG + ":" + mongoSvrKey + "/" + strDBName + "/" +
                        //             ConstMgr.COLLECTION_NAME_JAVASCRIPT + "/" + doc.GetValue(ConstMgr.KEY_ID);
                        //    JsNode.Nodes.Add(js);
                        //}

                        FillJavaScriptInfoToTreeNode(jsNode,
                            GetConnectionInfo.GetCollectionInfo(client, strDbName, strColName), mongoSvrKey, strDbName);

                        break;
                    default:
                        TreeNode mongoColNode;
                        try
                        {
                            var col = GetConnectionInfo.GetCollectionInfo(client, strDbName, strColName);
                            mongoColNode = FillCollectionInfoToTreeNode(col, mongoSvrKey);
                        }
                        catch (Exception ex)
                        {
                            mongoColNode = new TreeNode(strColName + "[exception:]");
                            mongoColNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Err;
                            mongoColNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Err;
                            Utility.ExceptionDeal(ex);
                        }
                        if (Operater.IsSystemCollection(strDbName, strColName))
                        {
                            switch (strColName)
                            {
                                case ConstMgr.CollectionNameGfsChunks:
                                case ConstMgr.CollectionNameGfsFiles:
                                    gfsNode.Nodes.Add(mongoColNode);
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
            mongoDbNode.Nodes.Add(mongoColListNode);
            mongoDbNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Database;
            mongoDbNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Database;
            return mongoDbNode;
        }
    }
}