using IzUI.WinForms.UI.Data;
using System.Runtime.Versioning;

namespace IzUI.WinForms.UI.Controls.Layout
{
    /// <summary>
    /// Panel control with borders.
    /// </summary>
    [SupportedOSPlatform("windows10.0")]
    public class PanelBorder : AbstractPanel
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
