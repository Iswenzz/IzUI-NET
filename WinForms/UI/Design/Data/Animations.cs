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
        public virtual Cursor CursorHover { get; set; } = Cursors.Hand;
        protected Cursor PrevCursorHover { get; set; }

        /// <summary>
        /// Color when mouse hover the control.
        /// </summary>
        [TypeConverter(typeof(ColorConverter))]
        [Description("Change the color when mouse hover the control.")]
        public virtual Color ColorHover { get; set; } = Color.Empty;
        protected Color PrevColorHover { get; set; }

        /// <summary>
        /// Text color when mouse hover the control.
        /// </summary>
        [TypeConverter(typeof(ColorConverter))]
        [Description("Change the color when mouse hover the control.")]
        public virtual Color TextColorHover { get; set; } = Color.Empty;
        protected Color PrevTextColorHover { get; set; }

        /// <summary>
        /// Create a new <see cref="Animations"/>.
        /// </summary>
        /// <param name="control">The <see cref="Control"/>.</param>
        public Animations(Control control) : base(control) { }

        /// <summary>
        /// Create a new <see cref="Animations"/>.
        /// </summary>
        /// <param name="control">The <see cref="Control"/>.</param>
        /// <param name="enabled">Is enabled.</param>
        public Animations(Control control, bool enabled) : base(control, enabled) { }

        /// <summary>
        /// Mouse leave callback.
        /// </summary>
        /// <param name="e">Mouse event.</param>
        public void OnMouseLeave(EventArgs e)
        {
            if (!Enabled) return;

            Control.BackColor = PrevColorHover;
            Control.ForeColor = PrevTextColorHover;
            Control.Cursor = PrevCursorHover;

            Control.Invalidate();
        }

        /// <summary>
        /// Mouse enter callback.
        /// </summary>
        /// <param name="e">Mouse event.</param>
        public void OnMouseEnter(EventArgs e)
        {
            if (!Enabled) return;

            PrevCursorHover = Control.Cursor;
            PrevColorHover = Control.BackColor;
            PrevTextColorHover = Control.ForeColor;

            Control.Cursor = CursorHover;
            Control.BackColor = ColorHover;
            Control.ForeColor = TextColorHover;

            Control.Invalidate();
        }
    }
}
