using System;
using System.ComponentModel;
using System.Globalization;

using IzUI.WinForms.UI.Data;

namespace IzUI.WinForms.UI.Models.Converter
{
    /// <summary>
    /// Bool <see cref="TypeConverter"/>.
    /// </summary>
    public class TCBool : TypeConverter
    {
        public TCBool() : base() { }

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
            return (value as string).Convert<bool>();
        }
    }
}
