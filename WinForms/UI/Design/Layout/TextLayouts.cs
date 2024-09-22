using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using IzUI.WinForms.UI.Data;

namespace IzUI.WinForms.UI.Design.Layout
{
    /// <summary>
    /// Texts layout.
    /// </summary>
    public class TextLayouts : Layouts
    {
        /// <summary>
        /// The content alignment.
        /// </summary>
        [Description("Content alignment.")]
        public virtual ContentAlignment ContentAlign { get; set; } = ContentAlignment.MiddleCenter;

        /// <summary>
        /// Create a new <see cref="TextLayouts"/>.
        /// </summary>
        /// <param name="control">The <see cref="Control"/>.</param>
        public TextLayouts(Control control) : base(control) { }

        /// <summary>
        /// Create a new <see cref="TextLayouts"/>.
        /// </summary>
        /// <param name="control">The <see cref="Control"/>.</param>
        /// <param name="enabled">Is enabled.</param>
        public TextLayouts(Control control, bool enabled) : base(control, enabled) { }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        public override void OnPaint(PaintEventArgs pe)
        {
            if (!Enabled) return;
            base.OnPaint(pe);

            using SolidBrush foreBrush = new(Control.ForeColor);
            using StringFormat sf = Alignment.GetStringFormat(ContentAlign);

            Rectangle clientRectangle = Control.ClientRectangle;
            Rectangle clientRectangleReverse = new(0, 0, Control.Height, Control.Width);
            pe.Graphics.DrawString(Control.Text, Control.Font, foreBrush,
                Angle > 0 ? clientRectangleReverse : clientRectangle, sf);
        }
    }
}
