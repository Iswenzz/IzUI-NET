using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls.Buttons
{
    public partial class FlatButton : Button
    {
        private int angles;
        public int Angles
        {
            get => angles;
            set { angles = value; Invalidate(); }
        }

        private bool isAngleAllowed;
        public bool IsAngleAllowed
        {
            get => isAngleAllowed;
            set { isAngleAllowed = value; Invalidate(); }
        }

        private int roundedCorner;
        public int RoundedCorner
        {
            get => roundedCorner;
            set { roundedCorner = value; Invalidate(); }
        }
        
        private Color hoverColor;
        public Color HoverColor
        {
            get => hoverColor;
            set { hoverColor = value; Invalidate(); }
        }

        private Color hoverColor_leave;
        public Color HoverColorLeave
        {
            get => hoverColor_leave;
            set { hoverColor_leave = value; Invalidate(); }
        }

        private Color hoverColorText;
        public Color HoverColorText
        {
            get => hoverColorText;
            set { hoverColorText = value; Invalidate(); }
        }

        private Color hoverColorText_leave;
        public Color HoverColorTextLeave
        {
            get => hoverColorText_leave;
            set { hoverColorText_leave = value; Invalidate(); }
        }

        public FlatButton()
        {
            InitializeComponent();
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            Size = new Size(125, 40);
            BackColor = Color.SteelBlue;
            ForeColor = Color.WhiteSmoke;
            HoverColor = Color.RoyalBlue;
            HoverColorText = Color.DarkOrange;
            RoundedCorner = 0;
            Angles = 90;
            IsAngleAllowed = false;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = hoverColor_leave;
            ForeColor = hoverColorText_leave;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            hoverColor_leave = BackColor;
            hoverColorText_leave = ForeColor;
            BackColor = hoverColor;
            ForeColor = hoverColorText;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            RectangleF rect = new RectangleF(0, 0, Width, Height);

            if (roundedCorner != 0)
            {
                GraphicsPath path = GetRoundPath(rect, roundedCorner);
                Region = new Region(path);
                pevent.Graphics.FillPath(new SolidBrush(BackColor), path);
            }
            else pevent.Graphics.FillRectangle(new SolidBrush(BackColor), rect);

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
                pevent.Graphics.TranslateTransform(Width, 0);
                pevent.Graphics.RotateTransform(Angles);
                pevent.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(0, 0, Height, Width), sf);
            }
            else
                pevent.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rect, sf);
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
