using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls.Layout
{
    /// <summary>
    /// Separator line control.
    /// </summary>
    public partial class Separator : BaseControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Separator stroke thickness.
        /// </summary>
        [DefaultValue(1f)]
        [Description("Separator line thickness.")]
        public float Thickness { get; set; }

        /// <summary>
        /// Initialize a new <see cref="Separator"/> object.
        /// </summary>
        public Separator() : base()
        {
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

            using Pen pen = new(ForeColor, Thickness);
            pe.Graphics.DrawLine(pen, new Point(0, Height / 2), new Point(Width, Height / 2));
        }
    }
}
