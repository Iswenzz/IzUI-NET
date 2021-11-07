using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Iswenzz.UI.Data;

namespace Iswenzz.UI.Controls.Inputs
{
    public partial class Button : ButtonBase
    {
        private Image icon;
        /// <summary>
        /// Button icon.
        /// </summary>
        [Description("Button icon.")]
        public Image Icon
        {
            get => icon;
            set { icon = value; Invalidate(); }
        }

        private bool iconAutoPlacement;
        /// <summary>
        /// Icon placement.
        /// </summary>
        [Description("Button icon placement (true = auto, false = stuck).")]
        public bool IconAutoPlacement
        {
            get => iconAutoPlacement;
            set { iconAutoPlacement = value; Invalidate(); }
        }

        private int iconSize;
        /// <summary>
        /// Icon size.
        /// </summary>
        [Description("Button icon size (0 = Auto).")]
        public int IconSize
        {
            get => iconSize;
            set { iconSize = value; Invalidate(); }
        }

        private int angles;
        /// <summary>
        /// Rotation angle.
        /// </summary>
        [Description("Angle rotation degree.")]
        public int Angles
        {
            get => angles;
            set { angles = value; Invalidate(); }
        }

        private bool isAngleAllowed;
        /// <summary>
        /// Toggle rotation.
        /// </summary>
        [DefaultValue(false)]
        [Description("Allows angled graphics render.")]
        public bool IsAngleAllowed
        {
            get => isAngleAllowed;
            set { isAngleAllowed = value; Invalidate(); }
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

        private Color hoverColor;
        /// <summary>
        /// Color when mouse hover the button.
        /// </summary>
        [Description("Change the color when mouse hover the button.")]
        public Color HoverColor
        {
            get => hoverColor;
            set { hoverColor = value; Invalidate(); }
        }

        private Color hoverColor_leave;
        /// <summary>
        /// Color when mouse leave the button.
        /// </summary>
        [Description("Change the color when mouse leave the button.")]
        public Color HoverColorLeave
        {
            get => hoverColor_leave;
            set { hoverColor_leave = value; Invalidate(); }
        }

        private Color hoverColorText;
        /// <summary>
        /// Text color when mouse hover the button.
        /// </summary>
        [Description("Change the color when mouse hover the button.")]
        public Color HoverColorText
        {
            get => hoverColorText;
            set { hoverColorText = value; Invalidate(); }
        }

        private Color hoverColorText_leave;
        /// <summary>
        /// Text color when mouse leave the button.
        /// </summary>
        [Description("Change the color when mouse leave the button.")]
        public Color HoverColorTextLeave
        {
            get => hoverColorText_leave;
            set { hoverColorText_leave = value; Invalidate(); }
        }

        /// <summary>
        /// Initialize a new <see cref="Button"/> object.
        /// </summary>
        public Button()
        {
            InitializeComponent();
            TextAlign = ContentAlignment.MiddleCenter;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            Size = new Size(125, 40);
            BackColor = Color.SteelBlue;
            ForeColor = Color.WhiteSmoke;
            HoverColor = Color.RoyalBlue;
            HoverColorText = Color.DarkOrange;
        }

        /// <summary>
        /// Set button icon.
        /// </summary>
        /// <param name="icon">Icon Image</param>
        /// <param name="size">Icon size</param>
        /// <param name="autoPlace">Toggle automatic placement</param>
        public virtual void SetIcon(Image icon, int size, bool autoPlace)
        {
            Icon = icon;
            IconSize = size;
            IconAutoPlacement = autoPlace;
        }

        /// <summary>
        /// Mouse leave callback.
        /// </summary>
        /// <param name="e">Mouse event</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = hoverColor_leave;
            ForeColor = hoverColorText_leave;
            Invalidate();
        }

        /// <summary>
        /// Mouse enter callback
        /// </summary>
        /// <param name="e">Mouse event</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            hoverColor_leave = BackColor;
            hoverColorText_leave = ForeColor;
            BackColor = hoverColor;
            ForeColor = hoverColorText;
            Invalidate();
        }

        /// <summary>
        /// Render callback
        /// </summary>
        /// <param name="pevent">Render data</param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            RectangleF rect = new RectangleF(0, 0, Width, Height);

            using SolidBrush backColorBrush = new SolidBrush(BackColor);
            using SolidBrush foreColorBrush = new SolidBrush(ForeColor);

            if (roundedCorner != 0)
            {
                using GraphicsPath path = rect.GetRoundPath(roundedCorner);
                Region = new Region(path);
                pevent.Graphics.FillPath(backColorBrush, path);
            }
            else pevent.Graphics.FillRectangle(backColorBrush, rect);

            using StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };

            sf.LineAlignment = Alignment.GetLineAlignment(TextAlign);
            sf.Alignment = Alignment.GetAlignment(TextAlign);

            if (IsAngleAllowed)
            {
                pevent.Graphics.TranslateTransform(Width, 0);
                pevent.Graphics.RotateTransform(Angles);
                pevent.Graphics.DrawString(Text, Font, foreColorBrush, new Rectangle(0, 0, Height, Width), sf);
            }
            else
                pevent.Graphics.DrawString(Text, Font, foreColorBrush, rect, sf);

            if (Icon != null)
            {
                switch (true)
                {
                    case true when IconSize == 0 && IconAutoPlacement:
                        pevent.Graphics.DrawImage(Icon,
                            new Rectangle(((Width / 2) / 2) - Height / 2, 0, Height, Height));
                        break;
                    case true when IconSize != 0 && IconAutoPlacement:
                        pevent.Graphics.DrawImage(Icon,
                            new Rectangle(((Width / 2) / 2) - IconSize / 2, 0, IconSize, IconSize));
                        break;

                    case true when IconSize == 0 && !IconAutoPlacement:
                        pevent.Graphics.DrawImage(Icon,
                            new Rectangle(10, 0, Height, Height));
                        break;
                    case true when IconSize != 0 && !IconAutoPlacement:
                        pevent.Graphics.DrawImage(Icon,
                            new Rectangle(10, 0, IconSize, IconSize));
                        break;
                }
            }
        }
    }
}
