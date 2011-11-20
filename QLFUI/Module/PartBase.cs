using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace QLFUI
{
    /// <summary>
    /// 窗体上各个部分的基类
    /// </summary>
    class PartBase
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Bitmap BackgroundBitmap { get; set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle(X, Y, Width, Height); }
        }

        public void DrawSelf(Graphics g,ImageAttributes attribute)
        {
            if (attribute != null)
            {
                g.DrawImage(BackgroundBitmap, Rectangle, 0, 0, Width, Height, GraphicsUnit.Pixel, attribute);
            }
            else
            {
                g.DrawImage(BackgroundBitmap, Rectangle);
            }
        }
    }
}
