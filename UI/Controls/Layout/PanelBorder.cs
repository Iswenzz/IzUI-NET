using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls.Layout
{
    public partial class PanelBorder : Panel
    {
        private Color borderColor;
        /// <summary>
        /// Panel border color.
        /// </summary>
        [Description("Change the border color.")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        private float thickness;
        /// <summary>
        /// Panel border thickness.
        /// </summary>
        [DefaultValue(1f)]
        [Description("Change the border thickness.")]
        public float Thickness
        {
            get => thickness;
            set { thickness = value; Invalidate(); }
        }

        /// <summary>
        /// Initialize a new <see cref="PanelBorder"/> object.
        /// </summary>
        public PanelBorder()
        {
            InitializeComponent();
            BorderColor = Color.DimGray;
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Render data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using Pen pen = new Pen(BorderColor, Thickness);
            pe.Graphics.DrawRectangle(pen, rect);
        }
    }
}
