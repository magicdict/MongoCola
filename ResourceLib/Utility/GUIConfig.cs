/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/6
 * Time: 10:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace ResourceLib.Utility
{
    /// <summary>
    ///     Description of UIConfig.
    /// </summary>
    public class GUIConfig
    {
        /// <summary>
        ///     是否使用默认语言
        /// </summary>
        public Boolean IsUseDefaultLanguage = false;

        /// <summary>
        ///     字符串
        /// </summary>
        public StringResource MStringResource = new StringResource();

        /// <summary>
        ///     获得文字
        /// </summary>
        /// <param name="DefaultText"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public string GetText(string DefaultText,
            StringResource.TextType tag = StringResource.TextType.UseDefaultLanguage)
        {
            if (IsUseDefaultLanguage || tag == StringResource.TextType.UseDefaultLanguage) return DefaultText;
            return MStringResource.GetText(tag);
        }
    }
}