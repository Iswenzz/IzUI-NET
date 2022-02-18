using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace IzUI.WinForms.UI.Data
{
    /// <summary>
    /// Represent a bitmap atlas.
    /// </summary>
    public sealed class BitmapAtlas : IDisposable
    {
        public InterpolationMode InterpolationMode { get; set; } = InterpolationMode.NearestNeighbor;
        public Bitmap Bitmap { get; set; }
        public Size Size { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        /// <summary>
        /// Create a new <see cref="BitmapAtlas"/> object.
        /// </summary>
        /// <param name="mx">The max X index.</param>
        /// <param name="my">The max Y index.</param>
        public BitmapAtlas(int mx, int my)
        {
            MaxX = mx;
            MaxY = my;
        }

        /// <summary>
        /// Get a <see cref="Bitmap"/> at the specified index.
        /// </summary>
        /// <param name="index">The index to retrieve the <see cref="Bitmap"/>.</param>
        /// <returns></returns>
        public Bitmap GetBitmapFromIndex(int index) => 
            GetBitmapFromRowCol(index / MaxX, index % MaxX);

        /// <summary>
        /// Get a <see cref="Bitmap"/> from X and Y index.
        /// </summary>
        /// <param name="x">The X index.</param>
        /// <param name="y">The Y index.</param>
        /// <returns></returns>
        public Bitmap GetBitmapFromRowCol(int x, int y)
        {
            if (Bitmap == null)
                return null;

            Rectangle r = new(x * (Size.Width / MaxX), y * (Size.Height / MaxY), 
                Size.Width / MaxX, Size.Height / MaxY);
            Bitmap nb = new(r.Width, r.Height);

            using Graphics g = Graphics.FromImage(nb);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImage(Bitmap, new RectangleF(PointF.Empty, nb.Size), r, GraphicsUnit.Pixel);
            return nb;
        }

        /// <summary>
        /// Dispose resources.
        /// </summary>
        public void Dispose()
        {
            Bitmap?.Dispose();
        }
    }
}
