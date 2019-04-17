using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

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

        public SeparatorPanel()
        {
            InitializeComponent();
            BorderColor = Color.DimGray;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            pe.Graphics.DrawLine(new Pen(BorderColor, Thickness),
                new Point(0, 0), new Point(Width, 0));
            pe.Graphics.DrawLine(new Pen(BorderColor, Thickness), 
                new Point(0, Height - 1), new Point(Width, Height - 1));
        }
    }
}
