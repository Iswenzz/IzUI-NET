using System.Drawing;
using System.Drawing.Drawing2D;

namespace IzUI.WinForms.UI.Maths
{
    public static class DRectangle
    {
        /// <summary>
        /// Create a <see cref="GraphicsPath"/> from a <see cref="DRectangle"/> with the specified radius.
        /// </summary>
        /// <param name="Rect">The rectangle.</param>
        /// <param name="radius">Rounded radius.</param>
        /// <returns></returns>
        public static GraphicsPath CreateRoundRectPath(this Rectangle rect, Size radius)
        {
            GraphicsPath gp = new();
            gp.AddLine(rect.Left + radius.Width / 2, rect.Top, rect.Right - radius.Width / 2, rect.Top);
            gp.AddArc(rect.Right - radius.Width, rect.Top, radius.Width, radius.Height, 270, 90);

            gp.AddLine(rect.Right, rect.Top + radius.Height / 2, rect.Right, rect.Bottom - radius.Width / 2);
            gp.AddArc(rect.Right - radius.Width, rect.Bottom - radius.Height, radius.Width, radius.Height, 0, 90);

            gp.AddLine(rect.Right - radius.Width / 2, rect.Bottom, rect.Left + radius.Width / 2, rect.Bottom);
            gp.AddArc(rect.Left, rect.Bottom - radius.Height, radius.Width, radius.Height, 90, 90);

            gp.AddLine(rect.Left, rect.Bottom - radius.Height / 2, rect.Left, rect.Top + radius.Height / 2);
            gp.AddArc(rect.Left, rect.Top, radius.Width, radius.Height, 180, 90);

            gp.CloseFigure();
            return gp;
        }

        /// <summary>
        /// Determines whether rectangle contains given point.
        /// </summary>
        /// <param name="pt">The point to test.</param>
        /// <param name="rect">The base rectangle.</param>
        /// <returns>
        /// True if rectangle contains given point.
        /// </returns>
        public static bool ContainsRect(this Point pt, Rectangle rect) =>
            pt.X > rect.Left & pt.X < rect.Right & pt.Y > rect.Top & pt.Y < rect.Bottom;
    }
}
