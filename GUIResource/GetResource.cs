using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace GUIResource
{
    public class GetResource
    {
        public static Image GetIcon(ImageType theImage) {
            Image micon = null;
            switch (theImage)
            {
                case ImageType.AccessDB:
                    micon = GUIResource.Properties.Resources.AccessDB;
                    break;
                case ImageType.Option:
                    micon = GUIResource.Properties.Resources.Option;
                    break;
                case ImageType.Refresh:
                    micon = GUIResource.Properties.Resources.Refresh;
                    break;
                case ImageType.NextPage:
                    micon = GUIResource.Properties.Resources.NextPage;
                    break;
                case ImageType.PrePage:
                    //水平翻转
                    micon = GUIResource.Properties.Resources.NextPage;
                    micon.RotateFlip(RotateFlipType.Rotate180FlipY);
                    break;
                case ImageType.LastPage:
                    micon = GUIResource.Properties.Resources.LastPage;
                    break;
                case ImageType.FirstPage:
                    //水平翻转
                    micon = GUIResource.Properties.Resources.LastPage;
                    micon.RotateFlip(RotateFlipType.Rotate180FlipY);
                    break;
                case ImageType.Query:
                    micon = GUIResource.Properties.Resources.Query;
                    break;
                default:
                    break;
            }
            return micon;
        }
    }
    public enum ImageType
    { 
        /// <summary>
        /// Access数据库
        /// </summary>
        AccessDB,
        /// <summary>
        /// 选项
        /// </summary>
        NextPage,
        PrePage,
        FirstPage,
        LastPage,
        Option,
        /// <summary>
        /// 刷新
        /// </summary>
        Refresh,
        Query

    } 
}
