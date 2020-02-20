using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls.Containers
{
    public partial class BorderPanel : Panel
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

        public BorderPanel()
        {
            InitializeComponent();
            BorderColor = Color.DimGray;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using Pen pen = new Pen(BorderColor, Thickness);
            pe.Graphics.DrawRectangle(pen, rect);
        }
    }
}
