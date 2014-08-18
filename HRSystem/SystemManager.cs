using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HRSystem
{
    public class SystemManager
    {
        /// <summary>
        /// 应用名称
        /// </summary>
        public static string AppName = "GMC DL Hiring system";
        /// <summary>
        /// 
        /// </summary>
        public static string strTotal = "Total";
        /// <summary>
        /// Hiring Tracking Xml Filename
        /// </summary>
        public static string HiringTrackingXmlFilename = Application.StartupPath + "\\Data\\HiringTracking.xml";
        /// <summary>
        /// Position BasicInfo Xml Filename
        /// </summary>
        public static string PositionBasicInfoXmlFilename = Application.StartupPath + "\\Data\\PositionBasicInfo.xml";
        /// <summary>
        /// Hiring Tracking Xml Filename
        /// </summary>
        public static string CustomViewXmlFilename = Application.StartupPath + "\\Data\\CustomView.xml";
        /// <summary>
        /// DataTime Format String
        /// </summary>
        public static string DataTimeFormat = "yyyy/MM/dd";
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            //View的初始化
            ViewControl.ResetHiringTrackingField();
            ViewControl.ResetPositionField();
            //Folder Check
            if (!Directory.Exists(Application.StartupPath + "\\Data")) Directory.CreateDirectory(Application.StartupPath + "\\Data");
            if (!Directory.Exists(Application.StartupPath + "\\Resume")) Directory.CreateDirectory(Application.StartupPath + "\\Resume");
            if (File.Exists(HiringTrackingXmlFilename))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<HiringTracking>));
                List<HiringTracking> HiringTrackingList = (List<HiringTracking>)xml.Deserialize(new StreamReader(HiringTrackingXmlFilename));
                DataCenter.HiringTrackingDataSet = HiringTrackingList;
            }
            if (File.Exists(PositionBasicInfoXmlFilename))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<PositionBasicInfo>));
                List<PositionBasicInfo> PositionBasicList = (List<PositionBasicInfo>)xml.Deserialize(new StreamReader(PositionBasicInfoXmlFilename));
                DataCenter.PositionBasicDataSet  = PositionBasicList;
            }
            ///Init UI
            DataCenter.ReCompute();
        }
    }
}
