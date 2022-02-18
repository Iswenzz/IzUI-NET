using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace IzUI.WinForms.UI.Models.Converter
{
    /// <summary>
    /// Enum <see cref="TypeConverter"/>.
    /// </summary>
    public class TCEnum : TypeConverter
    {
        public TCEnum() : base() { }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) => true;
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => true;

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            try
            {
                string[] enumTypeAndValue = (value as string).Split('.');
                if (enumTypeAndValue.Length < 2) throw new Exception();

                string enumTypeName = string.Concat(enumTypeAndValue.Take(enumTypeAndValue.Length - 2));
                string enumValue = enumTypeAndValue.Last();

                Type enumType = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(asm => !asm.IsDynamic)
                    .SelectMany(t => t.GetTypes())
                    .FirstOrDefault(n => n.FullName.Equals(enumTypeName));

                string qualifiedEnumTypeName = Enum.Parse(
                    Type.GetType(enumType.AssemblyQualifiedName), enumValue)
                    .GetType().FullName;

                return $"{qualifiedEnumTypeName}.{enumValue}";
            }
            catch 
            { 
                return string.Empty; 
            }
        }
    }
}
