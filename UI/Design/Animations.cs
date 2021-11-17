using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iswenzz.UI.Design
{
    /// <summary>
    /// Animations on events.
    /// </summary>
    public class Animations : AbstractDesign, INotifyPropertyChanged
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
        /// <param name="owner">The <see cref="Control"/> owner.</param>
        public Animations(Control owner) : base(owner) { }

        /// <summary>
        /// Mouse leave callback.
        /// </summary>
        /// <param name="e">Mouse event.</param>
        public void OnMouseLeave(EventArgs e)
        {
            Owner.BackColor = ColorHoverLeave;
            Owner.ForeColor = TextColorHoverLeave;
            Owner.Cursor = CursorHoverLeave;
            Owner.Invalidate();
        }

        /// <summary>
        /// Mouse enter callback.
        /// </summary>
        /// <param name="e">Mouse event.</param>
        public void OnMouseEnter(EventArgs e)
        {
            ColorHoverLeave = Owner.BackColor;
            TextColorHoverLeave = Owner.ForeColor;
            Owner.BackColor = ColorHover;
            Owner.ForeColor = TextColorHover;
            Owner.Cursor = CursorHover;
            Owner.Invalidate();
        }
    }
}
