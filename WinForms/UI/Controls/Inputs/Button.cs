using System.Drawing;
using System.Windows.Forms;

namespace IzUI.WinForms.UI.Controls.Inputs
{
    /// <summary>
    /// Button control.
    /// </summary>
    public class Button : AbstractText
    {
        /// <summary>
        /// Initialize a new <see cref="Button"/> object.
        /// </summary>
        public Button() : base()
        {
            Size = new Size(125, 40);

            BackColor = Color.DodgerBlue;
            ForeColor = Color.WhiteSmoke;

            Animations.Enable();
            Animations.ColorHover = Color.RoyalBlue;
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            PaintTransparency(pe);
            using SolidBrush backBrush = new(BackColor);
            pe.Graphics.FillRectangle(backBrush, ClientRectangle);

            if (BackgroundImage != null)
                pe.Graphics.DrawImage(BackgroundImage, ClientRectangle);

            base.OnPaint(pe);
        }
    }
}
