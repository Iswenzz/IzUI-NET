using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls
{
    public partial class Separator : AlphaControl
    {
        private float separatorThickness;
        /// <summary>
        /// Separator stroke thickness.
        /// </summary>
        [Description("Separator line thickness.")]
        [DefaultValue(1f)]
        public float SeparatorThickness
        {
            get => separatorThickness;
            set { separatorThickness = value; Invalidate(); }
        }

        /// <summary>
        /// Initialize a new <see cref="Separator"/> object.
        /// </summary>
        public Separator()
        {
            InitializeComponent();
            Size = new Size(125, 25);
            BackColor = Color.Transparent;
            ForeColor = Color.DarkGray;
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            using Pen pen = new Pen(ForeColor, SeparatorThickness);
            pe.Graphics.DrawLine(pen, new Point(0, Height / 2), new Point(Width, Height / 2));
        }
    }
}
