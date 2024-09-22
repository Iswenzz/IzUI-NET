using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using IzUI.WinForms.UI.Data;
using IzUI.WinForms.UI.Utils;

namespace IzUI.WinForms.UI.Models.Editors
{
    /// <summary>
    /// Represent a color <see cref="UITypeEditor"/>.
    /// </summary>
    public class ColorEditor : UITypeEditor
    {
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Paint value callback.
        /// </summary>
        /// <param name="e">Paint value args.</param>
        public override void PaintValue(PaintValueEventArgs e)
        {
            int index = (int)e.Value;
            EnumColor frameColor = (EnumColor)index;
            Rectangle rect = e.Bounds;

            using SolidBrush brush = new(frameColor.GetBrushesColor());
            e.Graphics.FillRectangle(brush, rect);
        }
    }
}
