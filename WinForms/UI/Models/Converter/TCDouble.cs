using System;
using System.ComponentModel;
using System.Globalization;

using IzUI.WinForms.UI.Data;

namespace IzUI.WinForms.UI.Models.Converter
{
    /// <summary>
    /// Double <see cref="TypeConverter"/>.
    /// </summary>
    public class TCDouble : TypeConverter
    {
        public TCDouble() : base() { }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) => true;
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => true;

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
            (value as string).Convert<double>();
    }
}
