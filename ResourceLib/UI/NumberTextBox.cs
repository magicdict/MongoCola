using System.Windows.Forms;

namespace ResourceLib.UI
{
    public static class NumberTextBox
    {
        public static void NumberText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) &&
                 e.KeyChar != 8 &&
                 e.KeyChar != 46 &&
                 e.KeyChar != 45)
            {
                e.Handled = true;
            }
            if (e.KeyChar != 46) return;
            if (((TextBox)sender).Text.Length > 0)
            {
                bool b1, b2;
                b1 = float.TryParse(((TextBox)sender).Text, out float oldf);
                b2 = float.TryParse(((TextBox)sender).Text + e.KeyChar, out float f);
                if (b2 == false)
                {
                    e.Handled = b1;
                }
            }
            else
            {
                e.Handled = true; //小数点不能在第一位
            }
        }

        public static void NumberTextInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}