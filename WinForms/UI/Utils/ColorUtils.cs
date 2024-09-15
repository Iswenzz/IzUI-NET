using System.Drawing;
using System.Reflection;
using System.Runtime.Versioning;
using System.Windows.Forms;

using IzUI.WinForms.UI.Data;

namespace IzUI.WinForms.UI.Utils
{
    [SupportedOSPlatform("windows10.0")]
    public static class ColorUtils
    {
        /// <summary>
        /// Desaturates colors from given array.
        /// </summary>
        /// <param name="colorsToDesaturate">The colors to be desaturated.</param>
        /// <returns></returns>
        public static Color[] DesaturateColors(params Color[] colorsToDesaturate)
        {
            Color[] colorsToReturn = new Color[colorsToDesaturate.Length];
            for (int i = 0; i < colorsToDesaturate.Length; i++)
            {
                // Use NTSC weighted avarage
                int gray = (int)(colorsToDesaturate[i].R * 0.3 + colorsToDesaturate[i].G * 0.6
                    + colorsToDesaturate[i].B * 0.1);
                colorsToReturn[i] = Color.FromArgb(-0x010101 * (255 - gray) - 1);
            }
            return colorsToReturn;
        }

        /// <summary>
        /// Lightens colors from given array.
        /// </summary>
        /// <param name="colorsToLighten">The colors to lighten.</param>
        /// <returns></returns>
        public static Color[] LightenColors(params Color[] colorsToLighten)
        {
            Color[] colorsToReturn = new Color[colorsToLighten.Length];
            for (int i = 0; i < colorsToLighten.Length; i++)
                colorsToReturn[i] = ControlPaint.Light(colorsToLighten[i]);
            return colorsToReturn;
        }

        /// <summary>
        /// Get the brush color of an <see cref="EnumColor"/>.
        /// </summary>
        /// <param name="color">The color value.</param>
        /// <returns></returns>
        public static Color GetBrushesColor(this EnumColor color)
        {
            PropertyInfo propertyInfo = typeof(Color).GetProperty(color.ToString());
            return (Color)propertyInfo.GetValue(null);
        }
    }
}
