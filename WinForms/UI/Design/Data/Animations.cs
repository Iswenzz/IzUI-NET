using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IzUI.WinForms.UI.Design.Data
{
    /// <summary>
    /// Animations on events.
    /// </summary>
    public class Animations : AbstractDesign
    {
        /// <summary>
        /// Cursor style when mouse hover the control.
        /// </summary>
        [Description("Change the cursor when mouse hover the control.")]
        public virtual Cursor CursorHover { get; set; }

        /// <summary>
        /// Cursor style when mouse hover the control.
        /// </summary>
        [Description("Change the cursor when mouse hover the control.")]
        public virtual Cursor CursorHoverLeave { get; set; }

        /// <summary>
        /// Color when mouse hover the control.
        /// </summary>
        [Description("Change the color when mouse hover the control.")]
        public virtual Color ColorHover { get; set; }

        /// <summary>
        /// Color when mouse leave the control.
        /// </summary>
        [Description("Change the color when mouse leave the control.")]
        public virtual Color ColorHoverLeave { get; set; }

        /// <summary>
        /// Text color when mouse hover the control.
        /// </summary>
        [Description("Change the color when mouse hover the control.")]
        public virtual Color TextColorHover { get; set; }

        /// <summary>
        /// Text color when mouse leave the control.
        /// </summary>
        [Description("Change the color when mouse leave the control.")]
        public virtual Color TextColorHoverLeave { get; set; }

        /// <summary>
        /// Create a new <see cref="Animations"/>.
        /// </summary>
        /// <param name="control">The <see cref="Control"/>.</param>
        public Animations(Control control) : base(control) { }

        /// <summary>
        /// Mouse leave callback.
        /// </summary>
        /// <param name="e">Mouse event.</param>
        public void OnMouseLeave(EventArgs e)
        {
            Control.BackColor = ColorHoverLeave;
            Control.ForeColor = TextColorHoverLeave;
            Control.Cursor = CursorHoverLeave;
            Control.Invalidate();
        }

        /// <summary>
        /// Mouse enter callback.
        /// </summary>
        /// <param name="e">Mouse event.</param>
        public void OnMouseEnter(EventArgs e)
        {
            ColorHoverLeave = Control.BackColor;
            TextColorHoverLeave = Control.ForeColor;
            Control.BackColor = ColorHover;
            Control.ForeColor = TextColorHover;
            Control.Cursor = CursorHover;
            Control.Invalidate();
        }
    }
}
