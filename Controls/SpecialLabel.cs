using Iswenzz.UI.Data;
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
            using SolidBrush backBrush = new SolidBrush(BackColor);
            using SolidBrush foreBrush = new SolidBrush(ForeColor);

            if (BackColor != Color.Transparent || RoundedCorner != 0)
            {
                GraphicsPath path = rect.GetRoundPath(RoundedCorner);
                Region = new Region(path);
                pe.Graphics.FillPath(backBrush, path);
                path.Dispose();
            }

            using StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };

            sf.LineAlignment = Alignment.GetLineAlignment(TextAlign);
            sf.Alignment = Alignment.GetAlignment(TextAlign);

            if (IsAngleAllowed)
            {
                pe.Graphics.TranslateTransform(Width, 0);
                pe.Graphics.RotateTransform(Angles);
                pe.Graphics.DrawString(Text, Font, foreBrush, new Rectangle(0, 0, Height, Width), sf);
            }
            else
                pe.Graphics.DrawString(Text, Font, foreBrush, rect, sf);
        }
    }
}
