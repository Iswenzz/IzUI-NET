using IzUI.WinForms.UI.Data;

namespace IzUI.WinForms.UI.Controls.Layout
{
    /// <summary>
    /// Panel with separators borders.
    /// </summary>
    public class PanelSeparator : AbstractPanel
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
