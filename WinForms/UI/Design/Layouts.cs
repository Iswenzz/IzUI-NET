using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IzUI.WinForms.UI.Design
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
        /// The content alignment.
        /// </summary>
        [DefaultValue(ContentAlignment.MiddleCenter)]
        [Description("Content alignment.")]
        public virtual ContentAlignment ContentAlign { get; set; } = ContentAlignment.MiddleCenter;

        /// <summary>
        /// Create a new <see cref="Layouts"/>.
        /// </summary>
        /// <param name="control">The <see cref="Control"/>.</param>
        public Layouts(Control control) : base(control) { }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        public override void OnPaint(PaintEventArgs pe)
        {
            if (!Renderable) return;

            if (Angle > 0)
            {
                pe.Graphics.TranslateTransform(Control.Width, 0);
                pe.Graphics.RotateTransform(Angle);
            }
        }
    }
}
