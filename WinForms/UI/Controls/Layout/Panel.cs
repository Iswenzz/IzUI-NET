using IzUI.WinForms.UI.Data;

namespace IzUI.WinForms.UI.Controls.Layout
{
    /// <summary>
    /// Panel control with borders.
    /// </summary>
    public class Panel : AbstractPanel
    {
        /// <summary>
        /// Initialize a new <see cref="Panel"/> object.
        /// </summary>
        public Panel() : base()
        {
            Border.Locations = RectLocation.Top | RectLocation.Left |
                RectLocation.Bottom | RectLocation.Right;
        }
    }
}
