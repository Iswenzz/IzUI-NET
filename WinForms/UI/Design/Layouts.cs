using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IzUI.WinForms.UI.Design
{
    /// <summary>
    /// Layout settings.
    /// </summary>
    public class Layouts : AbstractDesign, INotifyPropertyChanged
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
        /// <param name="owner">The <see cref="Control"/> owner.</param>
        public Layouts(Control owner) : base(owner) { }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        public override void OnPaint(PaintEventArgs pe)
        {
            if (!Renderable) return;

            if (Angle > 0)
            {
                pe.Graphics.TranslateTransform(Owner.Width, 0);
                pe.Graphics.RotateTransform(Angle);
            }
        }
    }
}
