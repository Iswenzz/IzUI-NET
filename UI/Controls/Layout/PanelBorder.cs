using System.ComponentModel;
using System.Windows.Forms;

using Iswenzz.UI.Data;

namespace Iswenzz.UI.Controls.Layout
{
    /// <summary>
    /// Panel control with borders.
    /// </summary>
    public partial class PanelBorder : BasePanel, INotifyPropertyChanged
    {
        /// <summary>
        /// Initialize a new <see cref="PanelBorder"/> object.
        /// </summary>
        public PanelBorder() : base()
        {
            Border.Locations = RectLocation.Top | RectLocation.Left |
                RectLocation.Bottom | RectLocation.Right;
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
