using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Design;

using Iswenzz.UI.Data;
using Iswenzz.UI.Models.Editors;

namespace Iswenzz.UI.Controls.Layout
{
    public partial class PanelSeparator : Panel
    {
        private Color borderColor;
        /// <summary>
        /// Panel border color.
        /// </summary>
        [Description("Change the border color.")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        private float thickness;
        /// <summary>
        /// Panel border thickness.
        /// </summary>
        [DefaultValue(1f)]
        [Description("Change the border thickness.")]
        public float Thickness
        {
            get => thickness;
            set { thickness = value; Invalidate(); }
        }

        private RectLocation separatorLocation;
        /// <summary>
        /// Separator location flags.
        /// </summary>
        [Editor(typeof(FlagEditor), typeof(UITypeEditor))]
        [DefaultValue(RectLocation.Bottom | RectLocation.Top)]
        [Description("Draw separator line at the location.")]
        public RectLocation SeparatorLocation
        {
            get => separatorLocation;
            set { separatorLocation = value; Invalidate(); }
        }

        /// <summary>
        /// Initialize a new <see cref="PanelSeparator"/> object.
        /// </summary>
        public PanelSeparator()
        {
            InitializeComponent();
            BorderColor = Color.DimGray;
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Render data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            using Pen pen = new(BorderColor, Thickness);

            if (SeparatorLocation.HasFlag(RectLocation.Top))
                pe.Graphics.DrawLine(pen, new Point(0, 0), new Point(Width - 1, 0));
            if (SeparatorLocation.HasFlag(RectLocation.Right))
                pe.Graphics.DrawLine(pen, new Point(Width - 1, 0), new Point(Width - 1, Height - 1));
            if (SeparatorLocation.HasFlag(RectLocation.Bottom))
                pe.Graphics.DrawLine(pen, new Point(0, Height - 1), new Point(Width - 1, Height - 1));
            if (SeparatorLocation.HasFlag(RectLocation.Left))
                pe.Graphics.DrawLine(pen, new Point(0, 0), new Point(0, Height - 1));
        }
    }
}
