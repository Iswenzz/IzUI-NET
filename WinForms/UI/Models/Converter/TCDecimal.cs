using System;
using System.ComponentModel;
using System.Globalization;

using IzUI.WinForms.UI.Data;

namespace IzUI.WinForms.UI.Models.Converter
{
    /// <summary>
    /// Decimal <see cref="TypeConverter"/>.
    /// </summary>
    public class TCDecimal : TypeConverter
    {
        public TCDecimal() : base() { }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return true;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return true;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return (value as string).Convert<decimal>();
        }
    }
}
