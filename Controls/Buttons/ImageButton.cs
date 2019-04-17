using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls.Buttons
{
    public partial class ImageButton : Button
    {
        private int roundedCorner;
        public int RoundedCorner
        {
            get => roundedCorner;
            set { roundedCorner = value; Invalidate(); }
        }

        private Image currentImage;
        [Description("Current Image")]
        public Image CurrentImage
        {
            get => currentImage;
            set { currentImage = value; Invalidate(); }
        }

        private Image activeImage;
        [Description("Change the BackgroundImage when MouseHover")]
        public Image ActiveImage
        {
            get => activeImage;
            set { activeImage = value; Invalidate(); }
        }

        public ImageButton()
        {
            InitializeComponent();
            FlatStyle = FlatStyle.Flat;
            Size = new Size(60, 60);
            BackColor = Color.Transparent;
            ForeColor = Color.WhiteSmoke;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            RoundedCorner = 0;
            Text = "";
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackgroundImage = CurrentImage;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            CurrentImage = BackgroundImage;
            BackgroundImage = ActiveImage;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            RectangleF rect = new RectangleF(0, 0, Width, Height);

            if (roundedCorner != 0)
            {
                GraphicsPath path = GetRoundPath(rect, RoundedCorner);
                Region = new Region(path);
                pevent.Graphics.FillPath(new SolidBrush(BackColor), path);
            }
            else pevent.Graphics.FillRectangle(new SolidBrush(BackColor), rect);

            TextFormatFlags flag;
            switch (TextAlign)
            {
                case ContentAlignment.BottomCenter: flag = TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter; break;
                case ContentAlignment.BottomLeft: flag = TextFormatFlags.Bottom | TextFormatFlags.Left; break;
                case ContentAlignment.BottomRight: flag = TextFormatFlags.Bottom | TextFormatFlags.Right; break;
                case ContentAlignment.MiddleCenter: flag = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter; break;
                case ContentAlignment.MiddleLeft: flag = TextFormatFlags.VerticalCenter | TextFormatFlags.Left; break;
                case ContentAlignment.MiddleRight: flag = TextFormatFlags.VerticalCenter | TextFormatFlags.Right; break;
                case ContentAlignment.TopCenter: flag = TextFormatFlags.Top | TextFormatFlags.HorizontalCenter; break;
                case ContentAlignment.TopLeft: flag = TextFormatFlags.Top | TextFormatFlags.Left; break;
                case ContentAlignment.TopRight: flag = TextFormatFlags.Top | TextFormatFlags.Right; break;
                default: flag = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter; break;
            }
            TextRenderer.DrawText(pevent.Graphics, Text, Font, new Point(Width + 3, Height / 2), ForeColor, flag);
        }

        private GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            path.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
            path.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            path.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
            path.AddArc(Rect.X + Rect.Width - radius, Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            path.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
            path.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            path.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);
            path.CloseFigure();
            return path;
        }
    }
}
