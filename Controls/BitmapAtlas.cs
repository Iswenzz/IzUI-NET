using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iswenzz.UI.Controls
{
    public sealed class BitmapAtlas : IDisposable
    {
        public InterpolationMode InterpolationMode { get; set; } = InterpolationMode.NearestNeighbor;
        public Bitmap Bitmap { get; set; }
        public Size Size { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public BitmapAtlas(int mx, int my)
        {
            MaxX = mx;
            MaxY = my;
        }

        public Bitmap GetBitmapFromIndex(int index) => 
            GetBitmapFromRowCol(index / MaxX, index % MaxX);

        public Bitmap GetBitmapFromRowCol(int x, int y)
        {
            if (Bitmap == null)
                return null;

            Rectangle r = new Rectangle(x * (Size.Width / MaxX), y * (Size.Height / MaxY), 
                Size.Width / MaxX, Size.Height / MaxY);
            Bitmap nb = new Bitmap(r.Width, r.Height);

            using Graphics g = Graphics.FromImage(nb);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImage(Bitmap, new RectangleF(PointF.Empty, nb.Size), r, GraphicsUnit.Pixel);
            return nb;
        }

        public void Dispose()
        {
            Bitmap?.Dispose();
        }
    }
}
