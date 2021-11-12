using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls.Layout
{
    /// <summary>
    /// Separator line control.
    /// </summary>
    public class Separator : AbstractControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Separator stroke thickness.
        /// </summary>
        [DefaultValue(1f)]
        [Category("Appearance"), Description("Separator line thickness.")]
        public virtual float Thickness { get; set; } = 1f;

        [Browsable(false)]
        public override string Text { get => string.Empty; set => base.Text = string.Empty; }

        /// <summary>
        /// Initialize a new <see cref="Separator"/> object.
        /// </summary>
        public Separator() : base()
        {
            Size = new Size(125, 25);

            BackColor = Color.Transparent;
            ForeColor = Color.DarkGray;
            Text = string.Empty;
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            using Pen pen = new(ForeColor, Thickness);
            pe.Graphics.DrawLine(pen, new Point(0, Height / 2), new Point(Width, Height / 2));

            base.OnPaint(pe);
        }
    }
}
