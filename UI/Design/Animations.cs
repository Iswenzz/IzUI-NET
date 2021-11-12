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
        /// Color when mouse hover the button.
        /// </summary>
        [Description("Change the color when mouse hover the button.")]
        public virtual Color HoverColor { get; set; }

        /// <summary>
        /// Color when mouse leave the button.
        /// </summary>
        [Description("Change the color when mouse leave the button.")]
        public virtual Color HoverColorLeave { get; set; }

        /// <summary>
        /// Text color when mouse hover the button.
        /// </summary>
        [Description("Change the color when mouse hover the button.")]
        public virtual Color HoverColorText { get; set; }

        /// <summary>
        /// Text color when mouse leave the button.
        /// </summary>
        [Description("Change the color when mouse leave the button.")]
        public virtual Color HoverColorTextLeave { get; set; }

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
            Owner.BackColor = HoverColorLeave;
            Owner.ForeColor = HoverColorTextLeave;
            Owner.Invalidate();
        }

        /// <summary>
        /// Mouse enter callback.
        /// </summary>
        /// <param name="e">Mouse event.</param>
        public void OnMouseEnter(EventArgs e)
        {
            HoverColorLeave = Owner.BackColor;
            HoverColorTextLeave = Owner.ForeColor;
            Owner.BackColor = HoverColor;
            Owner.ForeColor = HoverColorText;
            Owner.Invalidate();
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        public override void OnPaint(PaintEventArgs pe) { }
    }
}
