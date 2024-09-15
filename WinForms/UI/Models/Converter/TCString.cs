using System;
using System.ComponentModel;
using System.Globalization;

namespace IzUI.WinForms.UI.Models.Converter
{
    /// <summary>
    /// String <see cref="TypeConverter"/>.
    /// </summary>
    public class TCString : TypeConverter
    {
        public TCString() : base() { }

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
            return (value as string);
        }
    }
}
