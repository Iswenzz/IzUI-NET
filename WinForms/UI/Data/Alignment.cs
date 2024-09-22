using System.Drawing;

namespace IzUI.WinForms.UI.Data
{
    /// <summary>
    /// Alignment util class.
    /// </summary>
    public static class Alignment
    {
        /// <summary>
        /// Get vertical alignment.
        /// </summary>
        /// <param name="align">Content alignment.</param>
        /// <returns></returns>
        public static StringAlignment GetAlignment(ContentAlignment align)
        {
            return align switch
            {
                ContentAlignment.BottomCenter => StringAlignment.Center,
                ContentAlignment.BottomLeft => StringAlignment.Near,
                ContentAlignment.BottomRight => StringAlignment.Far,
                ContentAlignment.MiddleCenter => StringAlignment.Center,
                ContentAlignment.MiddleLeft => StringAlignment.Near,
                ContentAlignment.MiddleRight => StringAlignment.Far,
                ContentAlignment.TopCenter => StringAlignment.Center,
                ContentAlignment.TopLeft => StringAlignment.Near,
                ContentAlignment.TopRight => StringAlignment.Far,
                _ => StringAlignment.Center
            };
        }

        /// <summary>
        /// Get horizontal alignment.
        /// </summary>
        /// <param name="align">Content alignment.</param>
        /// <returns></returns>
        public static StringAlignment GetLineAlignment(ContentAlignment align)
        {
            return align switch
            {
                ContentAlignment.BottomCenter => StringAlignment.Far,
                ContentAlignment.BottomLeft => StringAlignment.Far,
                ContentAlignment.BottomRight => StringAlignment.Far,
                ContentAlignment.MiddleCenter => StringAlignment.Center,
                ContentAlignment.MiddleLeft => StringAlignment.Center,
                ContentAlignment.MiddleRight => StringAlignment.Center,
                ContentAlignment.TopCenter => StringAlignment.Near,
                ContentAlignment.TopLeft => StringAlignment.Near,
                ContentAlignment.TopRight => StringAlignment.Near,
                _ => StringAlignment.Center
            };
        }

        /// <summary>
        /// Get string format from <see cref="ContentAlignment"/>.
        /// </summary>
        /// <param name="align">The content alignment.</param>
        /// <param name="flags">The string format flags.</param>
        /// <returns></returns>
        public static StringFormat GetStringFormat(ContentAlignment align, StringFormatFlags flags = default)
        {
            return new(flags)
            {
                Alignment = GetAlignment(align),
                LineAlignment = GetLineAlignment(align)
            };
        }
    }
}
