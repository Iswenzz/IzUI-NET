using System.ComponentModel;
using System.Drawing;

namespace IzUI.WinForms.UI.Controls.Data
{
    /// <summary>
    /// Label control.
    /// </summary>
    public class LabelSpecial : AbstractText, INotifyPropertyChanged
    {
        /// <summary>
        /// Initialize a new <see cref="LabelSpecial"/> object.
        /// </summary>
        public LabelSpecial()
        {
            Size = new Size(125, 40);

            BackColor = Color.Transparent;
            ForeColor = Color.WhiteSmoke;
        }
    }
}
