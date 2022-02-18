using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

using IzUI.WinForms.UI.Data;

namespace IzUI.WinForms.UI.Models.Converter
{
    /// <summary>
    /// Color <see cref="TypeConverter"/>.
    /// </summary>
    public class TCColor : StringConverter
    {
        public TCColor() : base() { }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) => true;
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => true;

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
            (value as string).Convert<EnumColor>();

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) => true;
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) => true;

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            IEnumerable<EnumColor> icolors = Enum.GetValues(typeof(EnumColor)).Cast<EnumColor>();
            List<EnumColor> colors = new(icolors);
            return new StandardValuesCollection(colors);
        }
    }
}
