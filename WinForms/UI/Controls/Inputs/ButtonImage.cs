using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using IzUI.WinForms.UI.Controls.Resources;

namespace IzUI.WinForms.UI.Controls.Inputs
{
    /// <summary>
    /// Button image control.
    /// </summary>
    public class ButtonImage : AbstractText
    {
        /// <summary>
        /// The previous background image.
        /// </summary>
        protected virtual Image PrevImage { get; set; }

        /// <summary>
        /// Background image on hover.
        /// </summary>
        [Category("Appearance"), Description("Change the BackgroundImage on mouse hover.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public virtual Image ImageHover { get; set; }

        /// <summary>
        /// Initialize a new <see cref="ButtonImage"/> object.
        /// </summary>
        public ButtonImage() : base()
        {
            Size = new Size(125, 40);

            BackColor = Color.Transparent;
            ForeColor = Color.SteelBlue;

            Animations.Enable();
            Animations.ColorHover = Color.Transparent;
            Animations.TextColorHover = Color.DarkOrange;

            BackgroundImage = ControlResources.Inputs_PlaceHolder;
            PrevImage = BackgroundImage;
        }

        /// <summary>
        /// Mouse leave callback.
        /// </summary>
        /// <param name="e">Mouse event.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackgroundImage = PrevImage;
            Invalidate();
        }

        /// <summary>
        /// Mouse enter callback.
        /// </summary>
        /// <param name="e">Mouse event.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            PrevImage = BackgroundImage;
            if (ImageHover != null)
                BackgroundImage = ImageHover;
            Invalidate();
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
