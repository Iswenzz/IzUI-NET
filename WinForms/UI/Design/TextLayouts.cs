using IzUI.WinForms.UI.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IzUI.WinForms.UI.Design
{
    /// <summary>
    /// Texts layout.
    /// </summary>
    public class TextLayouts : Layouts, INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new <see cref="TextLayouts"/>.
        /// </summary>
        /// <param name="owner">The <see cref="Control"/> owner.</param>
        public TextLayouts(Control owner) : base(owner) { }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        public override void OnPaint(PaintEventArgs pe)
        {
            if (!Renderable) return;
            base.OnPaint(pe);

            using SolidBrush foreBrush = new(Owner.ForeColor);
            using StringFormat sf = Alignment.GetStringFormat(ContentAlign);

            Rectangle clientRectangle = Owner.ClientRectangle;
            Rectangle clientRectangleReverse = new(0, 0, Owner.Height, Owner.Width);
            pe.Graphics.DrawString(Owner.Text, Owner.Font, foreBrush, 
                Angle > 0 ? clientRectangleReverse : clientRectangle, sf);
        }
    }
}
