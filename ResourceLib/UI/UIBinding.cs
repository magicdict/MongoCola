using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace ResourceLib.UI
{
    public static class UIBinding
    {
        /// <summary>
        /// String
        /// </summary>
        private const string StringPrefix = "txt";
        /// <summary>
        /// String
        /// </summary>
        private const string FilePicker = "file";
        /// <summary>
        /// Integer
        /// </summary>
        private const string IntPrefix = "int";
        /// <summary>
        /// Double
        /// </summary>
        private const string DoublePrefix = "dbl";
        /// <summary>
        /// Boolean 
        /// </summary>
        private const string BooleanPrefix = "chk";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Controls"></param>
        public static void TryUpdateModel(Object model, Control.ControlCollection Controls)
        {
            Type modelType = model.GetType();
            PropertyInfo[] property = modelType.GetProperties();
            string ControlName = string.Empty;
            List<string> ControlNameList = new List<string>();
            Control Controller = null;
            foreach (PropertyInfo info in property)
            {
                //字符
                if (info.PropertyType == typeof(string))
                {
                    ControlNameList.Clear();
                    ControlNameList.Add(StringPrefix + info.Name);
                    ControlNameList.Add(FilePicker + info.Name);
                    Controller = GetUniqueControl(ControlNameList,Controls);
                    if (Controller == null) continue;
                    if (Controller.GetType().FullName == typeof(TextBox).FullName)
                    {
                        info.SetValue(model, ((TextBox)Controller).Text); 
                    }
                    if (Controller.GetType().FullName == typeof(CtlFilePicker).FullName)
                    {
                        info.SetValue(model, ((CtlFilePicker)Controller).Text);
                    }
                }
                //数字
                if (info.PropertyType == typeof(int))
                {
                    ControlName = IntPrefix + info.Name;
                    Controller = GetUniqueControl(ControlName, Controls);
                    if (Controller == null) continue;
                    if (Controller.GetType().FullName == typeof(NumericUpDown).FullName)
                    {
                        info.SetValue(model, (int)((NumericUpDown)Controller).Value);
                    }
                }
                if (info.PropertyType == typeof(double))
                {
                    ControlName = DoublePrefix + info.Name;
                    Controller = GetUniqueControl(ControlName, Controls);
                    if (Controller == null) continue;
                    if (Controller.GetType().FullName == typeof(NumericUpDown).FullName)
                    {
                        info.SetValue(model, (double)((NumericUpDown)Controller).Value);
                    }
                }
                //布尔
                if (info.PropertyType == typeof(bool))
                {
                    ControlName = BooleanPrefix + info.Name;
                    Controller = GetUniqueControl(ControlName, Controls);
                    if (Controller == null) continue;
                    if (Controller.GetType().FullName == typeof(CheckBox).FullName)
                    {
                        info.SetValue(model, ((CheckBox)Controller).Checked);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ControlName"></param>
        /// <param name="Controls"></param>
        /// <returns></returns>
        public static Control GetUniqueControl(string ControlName, Control.ControlCollection Controls)
        {
             var controls = Controls.Find(ControlName, true);
             if (controls.Length > 0)
             {
                 return controls[0];
             }
             return null;
        }

        public static Control GetUniqueControl(List<string> ControlName, Control.ControlCollection Controls)
        {
            foreach (var name in ControlName)
            {
                var controls = Controls.Find(name, true);
                if (controls.Length > 0)
                {
                    return controls[0];
                }
            }
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Controls"></param>
        public static void TryUpdateForm(Object model, Control.ControlCollection Controls)
        {
            Type modelType = model.GetType();
            PropertyInfo[] property = modelType.GetProperties();
            string ControlName = string.Empty;
            Control Controller = null;
            foreach (PropertyInfo info in property)
            {
                //字符
                if (info.PropertyType == typeof(string))
                {
                    ControlName = StringPrefix + info.Name;
                    Controller = GetUniqueControl(ControlName, Controls);
                    if (Controller == null) continue;
                    if (Controller.GetType().FullName == typeof(TextBox).FullName)
                    {
                        ((TextBox)Controller).Text = (string)info.GetValue(model);
                    }
                }
                //数字
                if (info.PropertyType == typeof(int))
                {
                    ControlName = IntPrefix + info.Name;
                    Controller = GetUniqueControl(ControlName, Controls);
                    if (Controller == null) continue;
                    if (Controller.GetType().FullName == typeof(NumericUpDown).FullName)
                    {
                        ((NumericUpDown)Controller).Value = (int)info.GetValue(model);
                    }
                }
                if (info.PropertyType == typeof(double))
                {
                    ControlName = DoublePrefix + info.Name;
                    Controller = GetUniqueControl(ControlName, Controls);
                    if (Controller == null) continue;
                    if (Controller.GetType().FullName == typeof(NumericUpDown).FullName)
                    {
                        ((NumericUpDown)Controller).Value = (decimal)((double)info.GetValue(model));
                    }
                }
                //布尔
                if (info.PropertyType == typeof(bool))
                {
                    ControlName = BooleanPrefix + info.Name;
                    Controller = GetUniqueControl(ControlName, Controls);
                    if (Controller == null) continue;
                    if (Controller.GetType().FullName == typeof(CheckBox).FullName)
                    {
                        ((CheckBox)Controller).Checked = (bool)info.GetValue(model);
                    }
                }

            }
        }
    }
}
