using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Iswenzz.UI.Data;
using Iswenzz.UI.Maths;
using Iswenzz.UI.Models.Editors;

namespace Iswenzz.UI.Design
{
    /// <summary>
    /// Border styles.
    /// </summary>
    public class Border : AbstractDesign, INotifyPropertyChanged
    {
        /// <summary>
        /// Border corner radius.
        /// </summary>
        [Description("Border radius degree.")]
        public virtual Size Radius { get; set; }

        /// <summary>
        /// Border color.
        /// </summary>
        [DefaultValue(typeof(Color), "SteelBlue")]
        [Description("Change the border color.")]
        public virtual Color Color { get; set; } = Color.SteelBlue;

        /// <summary>
        /// Border width.
        /// </summary>
        [DefaultValue(4f)]
        [Description("Change the border thickness.")]
        public virtual float Width { get; set; } = 4f;

        /// <summary>
        /// Border locations.
        /// </summary>
        [Editor(typeof(FlagEditor), typeof(UITypeEditor))]
        [Description("Draw borders at rectangle locations.")]
        public virtual RectLocation Locations { get; set; }

        /// <summary>
        /// Create a new <see cref="Border"/>.
        /// </summary>
        /// <param name="owner">The <see cref="Control"/> owner.</param>
        public Border(Control owner) : base(owner) { }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        public override void OnPaint(PaintEventArgs pe)
        {
            if (!Renderable) return;

            using SolidBrush backBrush = new(Owner.BackColor);
            using Pen borderPen = new(Color, Width);

            // Borders
            if (Locations.HasFlag(RectLocation.Top))
                pe.Graphics.DrawLine(borderPen, new PointF(0, Width / 2),
                    new PointF(Owner.Width, Width / 2));
            if (Locations.HasFlag(RectLocation.Right))
                pe.Graphics.DrawLine(borderPen, new PointF(Owner.Width - (Width / 2), 0),
                    new PointF(Owner.Width - (Width / 2), Owner.Height));
            if (Locations.HasFlag(RectLocation.Bottom))
                pe.Graphics.DrawLine(borderPen, new PointF(0, Owner.Height - (Width / 2)),
                    new PointF(Owner.Width, Owner.Height - (Width / 2)));
            if (Locations.HasFlag(RectLocation.Left))
                pe.Graphics.DrawLine(borderPen, new PointF(Width / 2, 0),
                    new PointF(Width / 2, Owner.Height));

            // Rounded
            if (Radius.Width > 0 && Radius.Height > 0 && Owner.BackColor != Color.Transparent)
            {
                GraphicsPath path = Owner.ClientRectangle.CreateRoundRectPath(Radius);
                Owner.Region = new Region(path);
                path.Dispose();
            }
        }
    }
}
