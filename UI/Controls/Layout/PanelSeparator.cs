using System.ComponentModel;
using System.Windows.Forms;

using Iswenzz.UI.Data;

namespace Iswenzz.UI.Controls.Layout
{
    /// <summary>
    /// Panel with separators borders.
    /// </summary>
    public partial class PanelSeparator : BasePanel, INotifyPropertyChanged
    {
        /// <summary>
        /// Initialize a new <see cref="PanelSeparator"/> object.
        /// </summary>
        public PanelSeparator() : base() 
        {
            Border.Locations = RectLocation.Left | RectLocation.Right;
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Render data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Border.OnPaint(pe);
        }
    }
}
