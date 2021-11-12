using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace Iswenzz.UI.Data
{
    /// <summary>
    /// Extension methods util class.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Try to convert a string to the specified template class type.
        /// </summary>
        /// <typeparam name="T">Class type to convert to.</typeparam>
        /// <param name="input">The input value to convert.</param>
        /// <returns></returns>
        public static T Convert<T>(this string input)
        {
            try
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    // Cast ConvertFromString(string text) : object to (T)
                    return (T)converter.ConvertFromString(input);
                }
                return default;
            }
            catch (NotSupportedException)
            {
                return default;
            }
        }

        /// <summary>
        /// Get the brush color of an <see cref="EnumColor"/>.
        /// </summary>
        /// <param name="color">The color value.</param>
        /// <returns></returns>
        public static Color GetBrushesColor(this EnumColor color)
        {
            PropertyInfo propertyInfo = typeof(Color).GetProperty(color.ToString());
            return (Color)propertyInfo.GetValue(null);
        }

        /// <summary>
        /// Create a <see cref="GraphicsPath"/> from a <see cref="Rectangle"/> with the specified radius.
        /// </summary>
        /// <param name="Rect">The rectangle.</param>
        /// <param name="radius">Rounded radius.</param>
        /// <returns></returns>
        public static GraphicsPath GetRoundPath(this Rectangle Rect, int radius)
        {
            GraphicsPath path = new();

            float r2 = radius / 2f;
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
