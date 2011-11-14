using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GUIResource
{
    public partial class GetResource
    {
        /// <summary>
        /// 语言国际化
        /// </summary>
        /// <param name="theText">语言标签</param>
        /// <param name="theLanguage">语种</param>
        /// <returns></returns>
        public static String GetText(TextType theText, Language theLanguage)
        {
            String rtnString = String.Empty;
            switch (theLanguage)
            {
                case Language.Chinese:
                    rtnString = GetChineseText(theText);
                    break;
                case Language.English:
                    rtnString = GetEnglishText(theText);
                    break;
                case Language.Japanese:
                    rtnString = GetJapaneseText(theText);
                    break;
                default:
                    rtnString = GetChineseText(theText);
                    break;
            }
            return rtnString;
        }
        /// <summary>
        /// 简体中文
        /// </summary>
        /// <param name="theText"></param>
        /// <returns></returns>
        public static String GetChineseText(TextType theText)
        {
            String rtnString = String.Empty;
            switch (theText)
            {
                case TextType.Expand:
                    rtnString = "展开";
                    break;
                case TextType.Collapse:
                    rtnString = "折叠";
                    break;

                case TextType.PrePage:
                    rtnString = "前一页";
                    break;
                case TextType.NextPage:
                    rtnString = "后一页";
                    break;
                case TextType.FirstPage:
                    rtnString = "第一页";
                    break;
                case TextType.LastPage:
                    rtnString = "最末页";
                    break;
                case TextType.QueryData:
                    rtnString = "数据查询";
                    break;

                case TextType.CreateDataBase:
                    rtnString = "新建数据库";
                    break;
                case TextType.InitGFS:
                    rtnString = "初始化GFS";
                    break;

                case TextType.Tools:
                    rtnString = "工具";
                    break;
                case TextType.DosCommand:
                    rtnString = "Dos命令";
                    break;
                case TextType.ImportDataFromAccess:
                    rtnString = "导入Access数据";
                    break;
                case TextType.Option:
                    rtnString = "选项";
                    break;

                case TextType.Distributed:
                    rtnString = "分布式";
                    break;
                case TextType.ReplicaSet:
                    rtnString = "副本管理";
                    break;
                case TextType.ShardingConfig:
                    rtnString = "分片管理";
                    break;
                case TextType.MapReduce:
                    rtnString = "MapReduce";
                    break;

                case TextType.Help:
                    rtnString = "帮助";
                    break;
                case TextType.About:
                    rtnString = "关于";
                    break;
                case TextType.Thanks:
                    rtnString = "感谢";
                    break;
                default:
                    break;
            }
            return rtnString;
        }
        /// <summary>
        /// 英文
        /// </summary>
        /// <param name="theText"></param>
        /// <returns></returns>
        public static String GetEnglishText(TextType theText)
        {
            String rtnString = String.Empty;
            switch (theText)
            {
                case TextType.Expand:
                    rtnString = "Expand";
                    break;
                case TextType.Collapse:
                    rtnString = "Collapse";
                    break;

                case TextType.PrePage:
                    rtnString = "Previous Page";
                    break;
                case TextType.NextPage:
                    rtnString = "Next Page";
                    break;
                case TextType.FirstPage:
                    rtnString = "First Page";
                    break;
                case TextType.LastPage:
                    rtnString = "Last Page";
                    break;
                case TextType.QueryData:
                    rtnString = "Query Data";
                    break;

                case TextType.CreateDataBase:
                    rtnString = "Create MongoDB";
                    break;
                case TextType.InitGFS:
                    rtnString = "Initialize GFS";
                    break;

                case TextType.Tools:
                    rtnString = "Tools";
                    break;
                case TextType.DosCommand:
                    rtnString = "Dos Command";
                    break;
                case TextType.ImportDataFromAccess:
                    rtnString = "ImportDataFromAccess";
                    break;
                case TextType.Option:
                    rtnString = "Option";
                    break;


                case TextType.Distributed:
                    rtnString = "Distributed";
                    break;
                case TextType.ReplicaSet:
                    rtnString = "Replica Config";
                    break;
                case TextType.ShardingConfig:
                    rtnString = "Sharding Server";
                    break;
                case TextType.MapReduce:
                    rtnString = "MapReduce";
                    break;

                case TextType.Help:
                    rtnString = "Help";
                    break;
                case TextType.About:
                    rtnString = "About MagicMongoDBTool";
                    break;
                case TextType.Thanks:
                    rtnString = "Thanks";
                    break;
                default:
                    break;
            }
            return rtnString;
        }
        /// <summary>
        /// 日本语
        /// </summary>
        /// <param name="theText"></param>
        /// <returns></returns>
        public static String GetJapaneseText(TextType theText)
        {
            String rtnString = String.Empty;
            switch (theText)
            {

                case TextType.Expand:
                    rtnString = "展開";
                    break;
                case TextType.Collapse:
                    rtnString = "折り畳む";
                    break;
 
                case TextType.PrePage:
                    rtnString = "前のページ";
                    break;
                case TextType.NextPage:
                    rtnString = "次のページ";
                    break;
                case TextType.FirstPage:
                    rtnString = "先頭ページ";
                    break;
                case TextType.LastPage:
                    rtnString = "最後ページ";
                    break;
                case TextType.QueryData:
                    rtnString = "データ検索";
                    break;

                case TextType.CreateDataBase:
                    rtnString = "新規データベース";
                    break;
                case TextType.InitGFS:
                    rtnString = "GFS初期化";
                    break;

                case TextType.Tools:
                    rtnString = "ツール";
                    break;
                case TextType.DosCommand:
                    rtnString = "Dos コマンド";
                    break;
                case TextType.ImportDataFromAccess:
                    rtnString = "ACCESSから導入";
                    break;
                case TextType.Option:
                    rtnString = "設定";
                    break;

                case TextType.Distributed:
                    rtnString = "分散型";
                    break;
                case TextType.ReplicaSet:
                    rtnString = "レプリケーション";
                    break;
                case TextType.ShardingConfig:
                    rtnString = "Shardingサーバー";
                    break;
                case TextType.MapReduce:
                    rtnString = "マップリデュース";
                    break;

                case TextType.Help:
                    rtnString = "ヘルプ";
                    break;
                case TextType.About:
                    rtnString = "MagicMongoDBToolについて";
                    break;
                case TextType.Thanks:
                    rtnString = "感謝";
                    break;
                default:
                    break;
            }
            return rtnString;
        }

    }
    /// <summary>
    /// 字符枚举
    /// </summary>
    public enum TextType
    {
        /// <summary>
        /// 共通
        /// </summary>
        Expand,
        Collapse,
        

        ///数据视图
        PrePage,
        NextPage,
        FirstPage,
        LastPage,
        QueryData,

        /// <summary>
        /// 操作
        /// </summary>
        CreateDataBase,
        InitGFS,


        /// <summary>
        /// 工具
        /// </summary>
        Tools,
        DosCommand,
        ImportDataFromAccess,
        Option,

        /// <summary>
        /// 分布式
        /// </summary>
        Distributed,
        ReplicaSet,
        ShardingConfig,
        MapReduce,
        /// <summary>
        /// 帮助
        /// </summary>
        Help,
        About,
        Thanks,
    }
    /// <summary>
    /// 语言
    /// </summary>
    public enum Language
    {
        Chinese,
        English,
        Japanese
    }
}
