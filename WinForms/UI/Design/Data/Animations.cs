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
        /// Background image when mouse hover the control.
        /// </summary>
        [Description("Change the BackgroundImage when mouse hover the control.")]
        public virtual Image BackgroundImageHover { get; set; }
        protected Image PrevBackgroundImage { get; set; }

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

            if (PrevCursorHover != null)
                Control.Cursor = PrevCursorHover;

            if (!PrevColorHover.IsEmpty)
                Control.BackColor = PrevColorHover;

            if (!PrevTextColorHover.IsEmpty)
                Control.ForeColor = PrevTextColorHover;

            if (BackgroundImageHover != null)
                Control.BackgroundImage = PrevBackgroundImage;

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
            PrevBackgroundImage = Control.BackgroundImage;

            if (CursorHover != null)
                Control.Cursor = CursorHover;

            if (!ColorHover.IsEmpty)
                Control.BackColor = ColorHover;

            if (!TextColorHover.IsEmpty)
                Control.ForeColor = TextColorHover;

            if (BackgroundImageHover != null)
                Control.BackgroundImage = BackgroundImageHover;

            Control.Invalidate();
        }
    }
}
