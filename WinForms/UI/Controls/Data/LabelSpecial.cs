using System.Drawing;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace IzUI.WinForms.UI.Controls.Data
{
    /// <summary>
    /// Label control.
    /// </summary>
    [SupportedOSPlatform("windows10.0")]
    public class LabelSpecial : AbstractText
    {
        /// <summary>
        /// Initialize a new <see cref="LabelSpecial"/> object.
        /// </summary>
        public LabelSpecial() : base()
        {
            Size = new Size(125, 40);

            BackColor = Color.Transparent;
            ForeColor = Color.WhiteSmoke;
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            PaintTransparency(pe);
            base.OnPaint(pe);
        }
    }
}
