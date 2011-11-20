using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace QLFUI
{
    [DefaultEvent("Click")]
    internal partial class BaseButton : UserControl
    {

        #region 属性

        [Category("QLFUI")]
        public Image NormalImage
        {
            get;
            set;
        }

        [Category("QLFUI")]
        public Image DownImage
        {
            get;
            set;
        }

        [Category("QLFUI")]
        public Image MoveImage
        {
            get;
            set;
        }

        [Category("QLFUI"), Description("需要过滤的颜色值")]
        public Color TranskeyColor
        {
            get;
            set;
        }

        [Browsable(false)]
        public int XOffset { get; set; }  //右边距的偏移量

        #endregion

        public BaseButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        private void BaseButton_MouseDown(object sender, MouseEventArgs e)
        {
            BackgroundImage = DownImage;
        }

        private void BaseButton_MouseEnter(object sender, EventArgs e)
        {
            BackgroundImage = MoveImage;
        }

        private void buttonControl_MouseLeave(object sender, EventArgs e)
        {
            BackgroundImage = NormalImage;
        }

        public void ReadButtonImage(string normalImagePath, string moveImagePath, string downImagePath)
        {
            if (!CheckFileExist(normalImagePath) || !CheckFileExist(moveImagePath) || !CheckFileExist(downImagePath))
            {
                throw new FileNotFoundException("图片路径不存在");
            }

            NormalImage = Image.FromFile(normalImagePath);
            MoveImage = Image.FromFile(moveImagePath);
            DownImage = Image.FromFile(downImagePath);

            BackgroundImage = NormalImage;
        }

        public void ReadButtonImage(Image normal,Image move,Image down)
        {
            NormalImage = normal;
            MoveImage = move;
            DownImage = down;

            BackgroundImage = NormalImage;
        }

        private bool CheckFileExist(string filePath)
        {
            return File.Exists(filePath);
        }


    }


}
