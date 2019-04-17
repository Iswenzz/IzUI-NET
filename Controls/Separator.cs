using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls
{
    public partial class Separator : AlphaControl
    {
        private float separatorThickness;
        [Description("Separator line thickness.")]
        [DefaultValue(1f)]
        public float SeparatorThickness
        {
            get => separatorThickness;
            set { separatorThickness = value; Invalidate(); }
        }

        public Separator()
        {
            InitializeComponent();
            Size = new Size(125, 25);
            BackColor = Color.Transparent;
            ForeColor = Color.DarkGray;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Rectangle rect = new Rectangle(0, 0, Width, Height);

            pe.Graphics.DrawLine(new Pen(ForeColor, SeparatorThickness), 
                new Point(0, Height / 2), new Point(Width, Height / 2));
        }
    }
}
