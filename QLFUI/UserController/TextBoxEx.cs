using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace QLFUI
{
    [DefaultEvent("TextChanged")]
    public partial class TextBoxEx : UserControl
    {
        #region - 变量 -

        private Color _borderColor = Color.FromArgb(166, 208, 226);
        private Color _shadowColor = Color.FromArgb(175, 212, 228);
        private Image _foreImage = null;
        private bool _isFouse = false;
        private Color _backColor = Color.Transparent;
        private string _waterMark = null;
        private Color _waterMarkColor = Color.Silver;
        private Color _foreColor = Color.Black;
        private int _radius = 3;
        public delegate void TextChangedHandler(String strNewText);
        public new event TextChangedHandler TextChanged;
        #endregion

        #region - 属性 -

        [Category("QLFUI"), Description("边框颜色,BorderStyle为FixedSingle有效")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }

        [Category("QLFUI"), Description("边框阴影颜色,BorderStyle为FixedSingle有效")]
        public Color ShadowColor
        {
            get { return _shadowColor; }
            set
            {
                _shadowColor = value;
                this.Invalidate();
            }
        }

        [Category("QLFUI"), Description("显示的前端的图片")]
        public Image ForeImage
        {
            get { return pic.Image; }
            set
            {
                _foreImage = value;
                pic.Image = _foreImage;
                Invalidate();
            }
        }
 
        [Category("QLFUI"), Description("文字")]
        public new String Text
        {
            get
            {
                if (txt.Text == WaterMark)
                {
                    return String.Empty;
                }
                else
                {
                    return txt.Text;
                }
            }
            set
            {
                txt.Text = value;
                SetWaterMark();
                Invalidate();
            }
        }

        [Category("行为"), Description("是否多行显示")]
        public bool Multiline
        {
            get { return txt.Multiline; }
            set
            {
                txt.Multiline = value;
            }
        }

        [Category("行为"), Description("是否以密码形式显示字符")]
        public bool UseSystemPasswordChar
        {
            get { return txt.UseSystemPasswordChar; }
            set
            {
                txt.UseSystemPasswordChar = value;
            }
        }

        [Category("QLFUI"), Description("水印文字")]
        public string WaterMark
        {
            get { return _waterMark; }
            set
            {
                _waterMark = value;
                Invalidate();
            }
        }

        [Category("QLFUI"), Description("水印颜色")]
        public Color WaterMarkColor
        {
            get { return _waterMarkColor; }
            set
            {
                _waterMarkColor = value;
                Invalidate();
            }
        }

        #region 需要被隐藏的属性

        [Browsable(false)]
        public new BorderStyle BorderStyle
        {
            get { return BorderStyle.None; }
        }

        [Browsable(false)]
        public new Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        [Browsable(false)]
        public new Image BackgroundImage
        {
            get { return null; }
        }

        [Browsable(false)]
        public new ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; }
        }

        #endregion

        [Category("QLFUI"), Description("边角弯曲的角度(1-10),数值越大越弯曲")]
        public int Radius
        {
            get { return _radius; }
            set
            {
                if (value > 10)
                {
                    value = 10;
                }
                if (value < 0)
                {
                    value = 0;
                }
                _radius = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("外观"), Description("文本颜色")]
        public new Color ForeColor
        {
            get { return _foreColor; }
            set { _foreColor = value; }
        }

        [Browsable(true)]
        [Category("外观"), Description("鼠标形状")]
        public new Cursor Cursor
        {
            get { return txt.Cursor; }
            set { txt.Cursor = value; }
        }

        //[Category("行为"), Description("自动提示方式")]
        //public AutoCompleteMode AutoCompleteMode
        //{
        //    get { return txt.AutoCompleteMode; }
        //    set { txt.AutoCompleteMode = value; }
        //}

        //[Category("行为"), Description("自动提示类型")]
        //public AutoCompleteSource AutoCompleteSource
        //{
        //    get { return txt.AutoCompleteSource; }
        //    set { txt.AutoCompleteSource = value; }
        //}

        #endregion

        #region - 构造函数 -

        public TextBoxEx()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();

            BackColor = Color.Transparent;

            //下面的图片和文本框的大小位置必须设置，否则首次启动时
            //会出现莫名其妙的断痕
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.BorderStyle = BorderStyle.None;
            pic.Height = pic.Width = 16;//图片大小固定为16
            pic.Left = -40;  //隐藏图片
            txt.Width = Width - 9;
            txt.Location = new Point(3, 6);

            txt.MouseEnter += new EventHandler(TextBoxEx2_MouseEnter);
            txt.MouseLeave += new EventHandler(TextBoxEx2_MouseLeave);
            pic.MouseEnter += new EventHandler(TextBoxEx2_MouseEnter);
            pic.MouseLeave += new EventHandler(TextBoxEx2_MouseLeave);
            txt.LostFocus += new EventHandler(Txt_LostFocus);
            txt.GotFocus += new EventHandler(Txt_GotFocus);
            pic.BackColor = Color.White;  //不设置成白色则边框会一同加阴影
           
        }

        #endregion

        #region - 事件 -
        private Boolean IsEndLoad =false;
        private void TextBoxEx_Load(object sender, EventArgs e)
        {
            SetWaterMark();
            this.Invalidate();
            IsEndLoad = true;
        }

        private void TextBoxEx2_MouseEnter(object sender, EventArgs e)
        {
            _isFouse = true;
            this.Invalidate();
        }

        private void TextBoxEx2_MouseLeave(object sender, EventArgs e)
        {
            _isFouse = false;
            this.Invalidate();
        }

        private void Txt_GotFocus(object sender, EventArgs e)
        {
            if (txt.Text == WaterMark)
            {
                //获得焦点，切换正常文字等待填写
                txt.ForeColor = ForeColor;
                txt.Text = String.Empty;
            }
        }

        private void Txt_LostFocus(object sender, EventArgs e)
        {
            SetWaterMark();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;

            CalculateSizeAndPosition();
            Draw(this.ClientRectangle, e.Graphics);

            base.OnPaint(e);
        }

        #endregion

        #region - 帮助方法 -

        private void SetWaterMark()
        {
            if (_waterMark != null && (txt.Text == String.Empty || txt.Text ==  WaterMark))   //用户没有输入
            {
                txt.ForeColor = _waterMarkColor;
                txt.Text = WaterMark;
            }
            else
            {
                txt.ForeColor = ForeColor;
            }
        }

        private void CalculateSizeAndPosition()
        {
            if (ForeImage != null)
            {
                pic.Top = pic.Left = 3;
                txt.Width = Width - pic.Width - 12;
                txt.Location = new Point(16 + 3 + 3, 6);
            }
            else
            {
                pic.Left = -40;  //隐藏图片
                txt.Width = Width - 9;
                txt.Location = new Point(3, 6);
            }

            //单行
            if (!txt.Multiline)
            {
                Height = txt.Height + 9;
            }
            else
            {
                txt.Height = Height - 9;
            }
        }
        internal class DrawHelper
        {
            public static GraphicsPath DrawRoundRect(int x, int y, int width, int height, int radius)
            {
                GraphicsPath gp = new GraphicsPath();
                gp.AddArc(x, y, radius, radius, 180, 90);
                gp.AddArc(width - radius, y, radius, radius, 270, 90);
                gp.AddArc(width - radius, height - radius, radius, radius, 0, 90);
                gp.AddArc(x, height - radius, radius, radius, 90, 90);
                gp.CloseAllFigures();
                return gp;
            }

            /// <summary>
            /// 绘制圆角矩形
            /// </summary>
            /// <param name="rect">矩形</param>
            /// <param name="radius">弯曲程度(0-10)，越大越弯曲</param>
            /// <returns></returns>
            public static GraphicsPath DrawRoundRect(Rectangle rect, int radius)
            {
                int x = rect.X;
                int y = rect.Y;
                int width = rect.Width;
                int height = rect.Height;
                return DrawRoundRect(x, y, width - 2, height - 1, radius);
            }

            /// <summary>
            /// 得到两种颜色的过渡色（1代表开始色，100表示结束色）
            /// </summary>
            /// <param name="c">开始色</param>
            /// <param name="c2">结束色</param>
            /// <param name="value">需要获得的度</param>
            /// <returns></returns>
            public static Color GetIntermediateColor(Color c, Color c2, int value)
            {
                float pc = value * 1.0F / 100;

                int ca = c.A, cr = c.R, cg = c.G, cb = c.B;
                int c2a = c2.A, c2r = c2.R, c2g = c2.G, c2b = c2.B;

                int a = (int)Math.Abs(ca + (ca - c2a) * pc);
                int r = (int)Math.Abs(cr - ((cr - c2r) * pc));
                int g = (int)Math.Abs(cg - ((cg - c2g) * pc));
                int b = (int)Math.Abs(cb - ((cb - c2b) * pc));

                if (a > 255) { a = 255; }
                if (r > 255) { r = 255; }
                if (g > 255) { g = 255; }
                if (b > 255) { b = 255; }

                return (Color.FromArgb(a, r, g, b));
            }

            public static StringFormat StringFormatAlignment(ContentAlignment textalign)
            {
                StringFormat sf = new StringFormat();
                switch (textalign)
                {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.TopRight:
                        sf.LineAlignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.MiddleRight:
                        sf.LineAlignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.BottomCenter:
                    case ContentAlignment.BottomRight:
                        sf.LineAlignment = StringAlignment.Far;
                        break;
                }
                switch (textalign)
                {
                    case ContentAlignment.TopLeft:
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.BottomLeft:
                        sf.Alignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.TopCenter:
                    case ContentAlignment.MiddleCenter:
                    case ContentAlignment.BottomCenter:
                        sf.Alignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.TopRight:
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.BottomRight:
                        sf.Alignment = StringAlignment.Far;
                        break;
                }
                return sf;
            }
        }
        private void Draw(Rectangle rectangle, Graphics g)
        {

            #region 画背景
            using (SolidBrush backgroundBrush = new SolidBrush(Color.White))
            {
                g.FillRectangle(backgroundBrush, 2, 2, this.Width - 5, this.Height - 4);
            }
            #endregion

            #region 画阴影(外边框)

            Color drawShadowColor = _shadowColor;
            if (!_isFouse)    //判断是否获得焦点
            {
                drawShadowColor = Color.Transparent;
            }
            using (Pen shadowPen = new Pen(drawShadowColor))
            {
                if (_radius == 0)
                {
                    g.DrawRectangle(shadowPen, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width - 1, rectangle.Height - 1));
                }
                else
                {
                    g.DrawPath(shadowPen, DrawHelper.DrawRoundRect(rectangle.X, rectangle.Y, rectangle.Width - 2, rectangle.Height - 1, _radius));
                }
            }
            #endregion

            #region 画边框
            using (Pen borderPen = new Pen(_borderColor))
            {
                if (_radius == 0)
                {
                    g.DrawRectangle(borderPen, new Rectangle(rectangle.X + 1, rectangle.Y + 1, rectangle.Width - 3, rectangle.Height - 3));
                }
                else
                {
                    g.DrawPath(borderPen, DrawHelper.DrawRoundRect(rectangle.X + 1, rectangle.Y + 1, rectangle.Width - 3, rectangle.Height - 2, _radius));
                }
            }
            #endregion
        }

        #endregion

        private void txt_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
            {
                if (IsEndLoad) { TextChanged(this.Text); }
            }
        }
    }
}
