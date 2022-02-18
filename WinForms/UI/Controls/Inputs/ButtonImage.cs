using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using IzUI.WinForms.UI.Controls.Resources;

namespace IzUI.WinForms.UI.Controls.Inputs
{
    /// <summary>
    /// Button image control.
    /// </summary>
    public class ButtonImage : AbstractText, INotifyPropertyChanged
    {
        /// <summary>
        /// Default background image.
        /// </summary>
        [Browsable(false)]
        protected virtual Image DefaultImage { get; set; }

        /// <summary>
        /// Active background image.
        /// </summary>
        [Category("Appearance"), Description("Change the BackgroundImage on mouse hover.")]
        public virtual Image ActiveImage { get; set; }

        /// <summary>
        /// Initialize a new <see cref="ButtonImage"/> object.
        /// </summary>
        public ButtonImage() : base()
        {
            Size = new Size(125, 40);

            BackColor = Color.Transparent;
            ForeColor = Color.SteelBlue;
            Animations.ColorHover = Color.Transparent;
            Animations.TextColorHover = Color.DarkOrange;

            BackgroundImage = ControlResources.Inputs_PlaceHolder;
            DefaultImage = BackgroundImage;
        }

        /// <summary>
        /// Mouse leave callback.
        /// </summary>
        /// <param name="e">Mouse event.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            BackgroundImage = DefaultImage;
            Invalidate();
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Mouse enter callback.
        /// </summary>
        /// <param name="e">Mouse event.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            DefaultImage = BackgroundImage;
            if (ActiveImage != null)
                BackgroundImage = ActiveImage;
            Invalidate();
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            PaintTransparency(pe);
            if (BackgroundImage != null)
                pe.Graphics.DrawImage(BackgroundImage, ClientRectangle);
            base.OnPaint(pe);
        }
    }
}
