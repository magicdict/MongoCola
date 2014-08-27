using Common.Database;

namespace Common.Schedule
{
    public class Traffic : DetailInfoBase
    {
        public Traffic()
        {
            InfoClass = InfoClassEnum.Traffic;
        }
        /// <summary>
        /// 添加详细行程
        /// </summary>
        /// <param name="info"></param>
        public static void InsertDetailInfo(Traffic info)
        {
            Operater.InsertRec(CollectionName, info);
        }
    }
}
