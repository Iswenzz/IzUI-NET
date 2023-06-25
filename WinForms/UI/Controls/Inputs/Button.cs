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

            BackColor = Color.SteelBlue;
            ForeColor = Color.WhiteSmoke;
            Animations.ColorHover = Color.RoyalBlue;
            Animations.TextColorHover = Color.DarkOrange;
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            using SolidBrush backBrush = new(BackColor);
            pe.Graphics.FillRectangle(backBrush, ClientRectangle);

            base.OnPaint(pe);
        }
    }
}
