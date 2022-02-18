using System.ComponentModel;

using IzUI.WinForms.UI.Data;

namespace IzUI.WinForms.UI.Controls.Layout
{
    /// <summary>
    /// Panel control with borders.
    /// </summary>
    public class PanelBorder : AbstractPanel, INotifyPropertyChanged
    {
        /// <summary>
        /// Initialize a new <see cref="PanelBorder"/> object.
        /// </summary>
        public PanelBorder() : base()
        {
            Border.Locations = RectLocation.Top | RectLocation.Left |
                RectLocation.Bottom | RectLocation.Right;
        }
    }
}
