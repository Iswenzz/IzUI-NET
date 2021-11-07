using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Iswenzz.UI.Data;

namespace Iswenzz.UI.Controls.Data
{
    public partial class LabelSpecial : AlphaControl
    {
        private int angle;
        /// <summary>
        /// The angle used to rotate the text.
        /// </summary>
        [Description("Angle rotation degree.")]
        public int Angle
        {
            get => angle;
            set { angle = value; Invalidate(); }
        }

        private int roundedCorner;
        /// <summary>
        /// Rounded corner radius.
        /// </summary>
        [Description("Curved corner amount.")]
        public int RoundedCorner
        {
            get => roundedCorner;
            set { roundedCorner = value; Invalidate(); }
        }

        private ContentAlignment textAlign;
        /// <summary>
        /// Text alignment.
        /// </summary>
        [DefaultValue(ContentAlignment.MiddleCenter)]
        [Description("Text allignement.")]
        public ContentAlignment TextAlign
        {
            get => textAlign;
            set { textAlign = value; Invalidate(); }
        }

        /// <summary>
        /// Initialize a new <see cref="LabelSpecial"/> object.
        /// </summary>
        public LabelSpecial()
        {
            InitializeComponent();
            Size = new Size(125, 40);
            BackColor = Color.Transparent;
            ForeColor = Color.WhiteSmoke;
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            RectangleF rect = new(0, 0, Width, Height);
            using SolidBrush backBrush = new(BackColor);
            using SolidBrush foreBrush = new(ForeColor);

            pe.Graphics.FillRectangle(backBrush, rect);
            if (RoundedCorner > 0 && BackColor != Color.Transparent)
            {
                GraphicsPath path = rect.GetRoundPath(RoundedCorner);
                Region = new Region(path);
                pe.Graphics.FillPath(backBrush, path);
                path.Dispose();
            }

            using StringFormat sf = new();
            sf.LineAlignment = Alignment.GetLineAlignment(TextAlign);
            sf.Alignment = Alignment.GetAlignment(TextAlign);

            if (Angle > 0)
            {
                pe.Graphics.TranslateTransform(Width, 0);
                pe.Graphics.RotateTransform(Angle);
                pe.Graphics.DrawString(Text, Font, foreBrush, new Rectangle(0, 0, Height, Width), sf);
            }
            else
                pe.Graphics.DrawString(Text, Font, foreBrush, rect, sf);
        }
    }
}
