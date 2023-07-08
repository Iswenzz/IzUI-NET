using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IzUI.WinForms.UI.Design.Layout
{
    /// <summary>
    /// Layout settings.
    /// </summary>
    public class Layouts : AbstractDesign
    {
        /// <summary>
        /// The angle used to rotate the text.
        /// </summary>
        [Description("Angle rotation degree.")]
        public virtual int Angle { get; set; }

        /// <summary>
        /// Create a new <see cref="Layouts"/>.
        /// </summary>
        /// <param name="control">The <see cref="Control"/>.</param>
        public Layouts(Control control) : base(control) { }

        /// <summary>
        /// Create a new <see cref="Layouts"/>.
        /// </summary>
        /// <param name="control">The <see cref="Control"/>.</param>
        /// <param name="enabled">Is enabled.</param>
        public Layouts(Control control, bool enabled) : base(control, enabled) { }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        public override void OnPaint(PaintEventArgs pe)
        {
            if (!Enabled || Angle <= 0) return;

            pe.Graphics.TranslateTransform(Control.Width, 0);
            pe.Graphics.RotateTransform(Angle);
        }
    }
}
