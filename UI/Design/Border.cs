using Iswenzz.UI.Data;
using Iswenzz.UI.Models.Editors;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Iswenzz.UI.Design
{
    public class Border : BaseDesign, INotifyPropertyChanged
    {
        /// <summary>
        /// Border corner radius.
        /// </summary>
        [Description("Border radius degree.")]
        public int Radius { get; set; }

        /// <summary>
        /// Border color.
        /// </summary>
        [DefaultValue(typeof(Color), "SteelBlue")]
        [Description("Change the border color.")]
        public Color Color { get; set; }

        /// <summary>
        /// Border width.
        /// </summary>
        [DefaultValue(4f)]
        [Description("Change the border thickness.")]
        public float Width { get; set; }

        /// <summary>
        /// Border locations.
        /// </summary>
        [Editor(typeof(FlagEditor), typeof(UITypeEditor))]
        [Description("Draw borders at rectangle locations.")]
        public RectLocation Locations { get; set; }

        /// <summary>
        /// Create a new <see cref="Border"/>.
        /// </summary>
        /// <param name="owner">The <see cref="Control"/> owner.</param>
        public Border(Control owner) : base(owner) { }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        public void OnPaint(PaintEventArgs pe)
        {
            RectangleF rect = new(0, 0, Owner.Width, Owner.Height);
            using SolidBrush backBrush = new(Owner.BackColor);
            using Pen borderPen = new(Color, Width);
            pe.Graphics.FillRectangle(backBrush, rect);

            // Borders
            if (Locations.HasFlag(RectLocation.Top))
                pe.Graphics.DrawLine(borderPen, new Point(0, 0),
                    new Point(Owner.Width - 1, 0));
            if (Locations.HasFlag(RectLocation.Right))
                pe.Graphics.DrawLine(borderPen, new Point(Owner.Width - 1, 0),
                    new Point(Owner.Width - 1, Owner.Height - 1));
            if (Locations.HasFlag(RectLocation.Bottom))
                pe.Graphics.DrawLine(borderPen, new Point(0, Owner.Height - 1),
                    new Point(Owner.Width - 1, Owner.Height - 1));
            if (Locations.HasFlag(RectLocation.Left))
                pe.Graphics.DrawLine(borderPen, new Point(0, 0),
                    new Point(0, Owner.Height - 1));

            // Rounded
            if (Radius > 0 && Owner.BackColor != Color.Transparent)
            {
                GraphicsPath path = rect.GetRoundPath(Radius);
                Owner.Region = new Region(path);
                pe.Graphics.FillPath(backBrush, path);
                path.Dispose();
            }
        }
    }
}
