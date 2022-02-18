using System;
using System.ComponentModel;
using System.Globalization;

using IzUI.WinForms.UI.Data;

namespace IzUI.WinForms.UI.Models.Converter
{
    /// <summary>
    /// Integer <see cref="TypeConverter"/>.
    /// </summary>
    public class TCInt : TypeConverter
    {
        public TCInt() : base() { }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) => true;
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => true;

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
            (value as string).Convert<int>();
    }
}
