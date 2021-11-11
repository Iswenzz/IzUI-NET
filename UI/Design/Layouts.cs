using Iswenzz.UI.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iswenzz.UI.Design
{
    public class Layouts : BaseDesign, INotifyPropertyChanged
    {
        /// <summary>
        /// The angle used to rotate the text.
        /// </summary>
        [Description("Angle rotation degree.")]
        public int Angle { get; set; }

        /// <summary>
        /// The content alignment.
        /// </summary>
        [DefaultValue(ContentAlignment.MiddleCenter)]
        [Description("Content alignment.")]
        public ContentAlignment ContentAlign { get; set; }

        /// <summary>
        /// Create a new <see cref="Layouts"/>.
        /// </summary>
        /// <param name="owner">The <see cref="Control"/> owner.</param>
        public Layouts(Control owner) : base(owner) { }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        public void OnPaint(PaintEventArgs pe)
        {
            RectangleF rect = new(0, 0, Owner.Width, Owner.Height);
            using SolidBrush foreBrush = new(Owner.ForeColor);

            using StringFormat sf = Alignment.GetStringFormat(ContentAlign);
            if (Angle > 0)
            {
                pe.Graphics.TranslateTransform(Owner.Width, 0);
                pe.Graphics.RotateTransform(Angle);
                pe.Graphics.DrawString(Owner.Text, Owner.Font, foreBrush, 
                    new Rectangle(0, 0, Owner.Height, Owner.Width), sf);
            }
            else
                pe.Graphics.DrawString(Owner.Text, Owner.Font, foreBrush, rect, sf);
        }
    }
}
