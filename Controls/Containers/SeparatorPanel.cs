using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Design;

using Iswenzz.UI.TEditor;
using Iswenzz.UI.Data;

namespace Iswenzz.UI.Controls.Containers
{
    public partial class SeparatorPanel : Panel
    {
        private Color borderColor;
        [Description("Change the border color.")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        private float thickness;
        [DefaultValue(1f)]
        [Description("Change the border thickness.")]
        public float Thickness
        {
            get => thickness;
            set { thickness = value; Invalidate(); }
        }

        private RectLocation separatorLocation;
        [Editor(typeof(FlagUIEditor), typeof(UITypeEditor))]
        [DefaultValue(RectLocation.Bottom | RectLocation.Top)]
        [Description("Draw separator line at the location.")]
        public RectLocation SeparatorLocation
        {
            get => separatorLocation;
            set { separatorLocation = value; Invalidate(); }
        }

        public SeparatorPanel()
        {
            InitializeComponent();
            BorderColor = Color.DimGray;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            using Pen pen = new Pen(BorderColor, Thickness);

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
