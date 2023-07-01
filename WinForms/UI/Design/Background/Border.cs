using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using IzUI.WinForms.UI.Data;
using IzUI.WinForms.UI.Maths;
using IzUI.WinForms.UI.Models.Editors;

namespace IzUI.WinForms.UI.Design.Background
{
    /// <summary>
    /// Border styles.
    /// </summary>
    public class Border : AbstractDesign
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
        /// <param name="control">The <see cref="Control"/>.</param>
        public Border(Control control) : base(control) { }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        public override void OnPaint(PaintEventArgs pe)
        {
            if (!Enabled) return;

            using SolidBrush backBrush = new(Control.BackColor);
            using Pen borderPen = new(Color, Width);

            // Borders
            if (Locations.HasFlag(RectLocation.Top))
                pe.Graphics.DrawLine(borderPen, new PointF(0, Width / 2),
                    new PointF(Control.Width, Width / 2));
            if (Locations.HasFlag(RectLocation.Right))
                pe.Graphics.DrawLine(borderPen, new PointF(Control.Width - Width / 2, 0),
                    new PointF(Control.Width - Width / 2, Control.Height));
            if (Locations.HasFlag(RectLocation.Bottom))
                pe.Graphics.DrawLine(borderPen, new PointF(0, Control.Height - Width / 2),
                    new PointF(Control.Width, Control.Height - Width / 2));
            if (Locations.HasFlag(RectLocation.Left))
                pe.Graphics.DrawLine(borderPen, new PointF(Width / 2, 0),
                    new PointF(Width / 2, Control.Height));

            // Rounded
            if (Radius.Width > 0 && Radius.Height > 0 && Control.BackColor != Color.Transparent)
            {
                GraphicsPath path = Control.ClientRectangle.CreateRoundRectPath(Radius);
                Control.Region = new Region(path);
                path.Dispose();
            }
        }
    }
}
