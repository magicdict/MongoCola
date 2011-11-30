using System;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmElement : QLFUI.QLFForm
    {
        /// <summary>
        /// 是否为更新模式
        /// </summary>
        private Boolean _IsUpdateMode = false;
        /// <summary>
        /// 路径
        /// </summary>
        private String _FullPath = String.Empty;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsUpdateMode"></param>
        /// <param name="FullPath"></param>
        public frmElement(Boolean IsUpdateMode, String FullPath)
        {
            InitializeComponent();
            _IsUpdateMode = IsUpdateMode;
            _FullPath = FullPath;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmElement_Load(object sender, EventArgs e)
        {
            if (_IsUpdateMode)
            {
                AddBsonElement.switchToUpdateMode();
                AddBsonElement.Element = MongoDBHelper.GetElementFromPath(_FullPath); 
            }
            if (!SystemManager.IsUseDefaultLanguage())
            {
                cmdOK.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_OK);
                cmdCancel.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_Cancel);
            }
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (_IsUpdateMode)
            {
                MongoDBHelper.ModifyElement(_FullPath, AddBsonElement.Element.Value);
            }
            else
            {
                MongoDBHelper.AddElement(_FullPath, AddBsonElement.Element);
            }
            this.Close();
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
