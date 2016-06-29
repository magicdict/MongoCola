using System.Collections.Generic;
using System.Windows.Forms;

namespace ResourceLib.UI
{
    public static class UiBinding
    {
        /// <summary>
        ///     String
        /// </summary>
        private const string StringPrefix = "txt";

        /// <summary>
        ///     String
        /// </summary>
        private const string FilePicker = "file";

        /// <summary>
        ///     Integer
        /// </summary>
        private const string IntPrefix = "int";

        /// <summary>
        ///     Double
        /// </summary>
        private const string DoublePrefix = "dbl";

        /// <summary>
        ///     Boolean
        /// </summary>
        private const string BooleanPrefix = "chk";

        /// <summary>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="controls"></param>
        public static void TryUpdateModel(object model, Control.ControlCollection controls)
        {
            var modelType = model.GetType();
            var property = modelType.GetProperties();
            var controlName = string.Empty;
            var controlNameList = new List<string>();
            Control controller = null;
            foreach (var info in property)
            {
                //字符
                if (info.PropertyType == typeof (string))
                {
                    controlNameList.Clear();
                    controlNameList.Add(StringPrefix + info.Name);
                    controlNameList.Add(FilePicker + info.Name);
                    controller = GetUniqueControl(controlNameList, controls);
                    if (controller == null) continue;
                    if (controller.GetType().FullName == typeof (TextBox).FullName)
                    {
                        info.SetValue(model, ((TextBox) controller).Text);
                    }
                    if (controller.GetType().FullName == typeof (CtlFilePicker).FullName)
                    {
                        info.SetValue(model, ((CtlFilePicker) controller).Text);
                    }
                }
                //数字
                if (info.PropertyType == typeof (int))
                {
                    controlName = IntPrefix + info.Name;
                    controller = GetUniqueControl(controlName, controls);
                    if (controller == null) continue;
                    if (controller.GetType().FullName == typeof (NumericUpDown).FullName)
                    {
                        info.SetValue(model, (int) ((NumericUpDown) controller).Value);
                    }
                }
                if (info.PropertyType == typeof (double))
                {
                    controlName = DoublePrefix + info.Name;
                    controller = GetUniqueControl(controlName, controls);
                    if (controller == null) continue;
                    if (controller.GetType().FullName == typeof (NumericUpDown).FullName)
                    {
                        info.SetValue(model, (double) ((NumericUpDown) controller).Value);
                    }
                }
                //布尔
                if (info.PropertyType == typeof (bool))
                {
                    controlName = BooleanPrefix + info.Name;
                    controller = GetUniqueControl(controlName, controls);
                    if (controller == null) continue;
                    if (controller.GetType().FullName == typeof (CheckBox).FullName)
                    {
                        info.SetValue(model, ((CheckBox) controller).Checked);
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="controlName"></param>
        /// <param name="Controls"></param>
        /// <returns></returns>
        public static Control GetUniqueControl(string controlName, Control.ControlCollection Controls)
        {
            var controls = Controls.Find(controlName, true);
            if (controls.Length > 0)
            {
                return controls[0];
            }
            return null;
        }

        public static Control GetUniqueControl(List<string> controlName, Control.ControlCollection Controls)
        {
            foreach (var name in controlName)
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
        /// </summary>
        /// <param name="model"></param>
        /// <param name="controls"></param>
        public static void TryUpdateForm(object model, Control.ControlCollection controls)
        {
            var modelType = model.GetType();
            var property = modelType.GetProperties();
            var controlName = string.Empty;
            Control controller = null;
            foreach (var info in property)
            {
                //字符
                if (info.PropertyType == typeof (string))
                {
                    controlName = StringPrefix + info.Name;
                    controller = GetUniqueControl(controlName, controls);
                    if (controller == null) continue;
                    if (controller.GetType().FullName == typeof (TextBox).FullName)
                    {
                        ((TextBox) controller).Text = (string) info.GetValue(model);
                    }
                }
                //数字
                if (info.PropertyType == typeof (int))
                {
                    controlName = IntPrefix + info.Name;
                    controller = GetUniqueControl(controlName, controls);
                    if (controller == null) continue;
                    if (controller.GetType().FullName == typeof (NumericUpDown).FullName)
                    {
                        ((NumericUpDown) controller).Value = (int) info.GetValue(model);
                    }
                }
                //数字
                if (info.PropertyType == typeof (double))
                {
                    controlName = DoublePrefix + info.Name;
                    controller = GetUniqueControl(controlName, controls);
                    if (controller == null) continue;
                    if (controller.GetType().FullName == typeof (NumericUpDown).FullName)
                    {
                        ((NumericUpDown) controller).Value = (decimal) (double) info.GetValue(model);
                    }
                }
                //布尔
                if (info.PropertyType == typeof (bool))
                {
                    controlName = BooleanPrefix + info.Name;
                    controller = GetUniqueControl(controlName, controls);
                    if (controller == null) continue;
                    if (controller.GetType().FullName == typeof (CheckBox).FullName)
                    {
                        ((CheckBox) controller).Checked = (bool) info.GetValue(model);
                    }
                }
            }
        }
    }
}