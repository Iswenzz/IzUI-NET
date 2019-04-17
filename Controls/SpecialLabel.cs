using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls
{
    public partial class SpecialLabel : AlphaControl
    {
        private int angles;
        [Description("Angle rotation degree.")]
        public int Angles
        {
            get => angles;
            set { angles = value; Invalidate(); }
        }

        private bool isAngleAllowed;
        [DefaultValue(false)]
        [Description("Allows angled graphics render.")]
        public bool IsAngleAllowed
        {
            get => isAngleAllowed;
            set { isAngleAllowed = value; Invalidate(); }
        }

        private int roundedCorner;
        [Description("Curved corner amount.")]
        public int RoundedCorner
        {
            get => roundedCorner;
            set { roundedCorner = value; Invalidate(); }
        }

        private ContentAlignment textAlign;
        [DefaultValue(ContentAlignment.MiddleCenter)]
        [Description("Text allignement.")]
        public ContentAlignment TextAlign
        {
            get => textAlign;
            set { textAlign = value; Invalidate(); }
        }

        public SpecialLabel()
        {
            InitializeComponent();
            Size = new Size(125, 40);
            BackColor = Color.Transparent;
            ForeColor = Color.WhiteSmoke;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            RectangleF rect = new RectangleF(0, 0, Width, Height);

            if (BackColor != Color.Transparent || roundedCorner != 0)
            {
                GraphicsPath path = GetRoundPath(rect, roundedCorner);
                Region = new Region(path);
                pe.Graphics.FillPath(new SolidBrush(BackColor), path);
                path.Dispose();
            }

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };

            switch (TextAlign)
            {
                case ContentAlignment.BottomCenter: sf.LineAlignment = StringAlignment.Far; sf.Alignment = StringAlignment.Center;      break;
                case ContentAlignment.BottomLeft:   sf.LineAlignment = StringAlignment.Far; sf.Alignment = StringAlignment.Near;        break;
                case ContentAlignment.BottomRight:  sf.LineAlignment = StringAlignment.Far; sf.Alignment = StringAlignment.Far;         break;
                case ContentAlignment.MiddleCenter: sf.LineAlignment = StringAlignment.Center; sf.Alignment = StringAlignment.Center;   break;
                case ContentAlignment.MiddleLeft:   sf.LineAlignment = StringAlignment.Center; sf.Alignment = StringAlignment.Near;     break;
                case ContentAlignment.MiddleRight:  sf.LineAlignment = StringAlignment.Center; sf.Alignment = StringAlignment.Far;      break;
                case ContentAlignment.TopCenter:    sf.LineAlignment = StringAlignment.Near; sf.Alignment = StringAlignment.Center;     break;
                case ContentAlignment.TopLeft:      sf.LineAlignment = StringAlignment.Near; sf.Alignment = StringAlignment.Near;       break;
                case ContentAlignment.TopRight:     sf.LineAlignment = StringAlignment.Near; sf.Alignment = StringAlignment.Far;        break;
            }

            if (IsAngleAllowed)
            {
                pe.Graphics.TranslateTransform(Width, 0);
                pe.Graphics.RotateTransform(Angles);
                pe.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(0, 0, Height, Width), sf);
            }
            else
                pe.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rect, sf);
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
