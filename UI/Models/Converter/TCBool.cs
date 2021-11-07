using System;
using System.ComponentModel;
using System.Globalization;

using Iswenzz.UI.Data;

namespace Iswenzz.UI.Models.Converter
{
    /// <summary>
    /// Bool <see cref="TypeConverter"/>.
    /// </summary>
    public class TCBool : TypeConverter
    {
        public TCBool() : base() { }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) => true;
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => true;

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
            (value as string).Convert<bool>();
    }
}
