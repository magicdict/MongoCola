using System.Drawing;
using ResourceLib.Properties;
namespace MongoCola.Module
{
    public class GetResource
    {
        public static Icon GetIcon(IconType theIcon)
        {
            Icon micon = null;

            switch (theIcon)
            {
                case IconType.Yes:
                    micon = Resources.ok;
                    break;
                case IconType.No:
                    micon = Resources.DELETE;
                    break;
                case IconType.UserGuide:
                    micon = Resources.books;
                    break;
            }
            return micon;
        }

        public static Image GetImage(ImageType theImage)
        {
            Image micon = null;
            switch (theImage)
            {
                case ImageType.Blank:
                    micon = Resources.Blank;
                    break;
                case ImageType.AccessDB:
                    micon = Resources.AccessDB;
                    break;
                case ImageType.ShutDown:
                    micon = Resources.ShutDown;
                    break;
                case ImageType.Option:
                    micon = Resources.Option;
                    break;
                case ImageType.Refresh:
                    micon = Resources.Refresh;
                    break;
                case ImageType.NextPage:
                    micon = Resources.NextPage;
                    break;
                case ImageType.PrePage:
                    //水平翻转
                    micon = Resources.NextPage;
                    micon.RotateFlip(RotateFlipType.Rotate180FlipY);
                    break;
                case ImageType.LastPage:
                    micon = Resources.LastPage;
                    break;
                case ImageType.FirstPage:
                    //水平翻转
                    micon = Resources.LastPage;
                    micon.RotateFlip(RotateFlipType.Rotate180FlipY);
                    break;
                case ImageType.Query:
                    micon = Resources.Query;
                    break;
                case ImageType.Filter:
                    micon = Resources.Filter;
                    break;
                case ImageType.WebServer:
                    micon = Resources.WebServer;
                    break;
                case ImageType.Database:
                    micon = Resources.Database;
                    break;
                case ImageType.Collection:
                    micon = Resources.Collection;
                    break;
                case ImageType.Keys:
                    micon = Resources.Keys;
                    break;
                case ImageType.KeyInfo:
                    micon = Resources.KeyInfo;
                    break;
                case ImageType.DBKey:
                    micon = Resources.DBkey;
                    break;
                case ImageType.Document:
                    micon = Resources.Document;
                    break;
                case ImageType.Smile:
                    micon = Resources.Smile;
                    break;
                case ImageType.User:
                    micon = Resources.User;
                    break;
                default:
                    break;
            }
            return micon;
        }
    }

    public enum IconType
    {
        Yes,
        No,
        UserGuide
    }

    public enum ImageType
    {
        Blank,

        /// <summary>
        ///     Access数据库
        /// </summary>
        AccessDB,
        ShutDown,
        NextPage,
        PrePage,
        FirstPage,
        LastPage,
        Query,
        Filter,

        /// <summary>
        ///     选项
        /// </summary>
        Option,

        /// <summary>
        ///     刷新
        /// </summary>
        Refresh,

        WebServer,
        Database,
        Collection,

        Keys,
        KeyInfo,
        DBKey,
        Document,
        User,
        Smile
    }
}