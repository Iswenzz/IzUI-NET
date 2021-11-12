using System.ComponentModel;

using Iswenzz.UI.Data;

namespace Iswenzz.UI.Controls.Layout
{
    /// <summary>
    /// Panel with separators borders.
    /// </summary>
    public class PanelSeparator : AbstractPanel, INotifyPropertyChanged
    {
        /// <summary>
        /// Initialize a new <see cref="PanelSeparator"/> object.
        /// </summary>
        public PanelSeparator() : base() 
        {
            Border.Locations = RectLocation.Left | RectLocation.Right;
        }
    }
}
