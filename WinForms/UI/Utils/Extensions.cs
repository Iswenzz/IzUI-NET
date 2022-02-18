using System;
using System.ComponentModel;

namespace IzUI.WinForms.UI.Data
{
    /// <summary>
    /// Extension methods util class.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Try to convert a string to the specified template class type.
        /// </summary>
        /// <typeparam name="T">Class type to convert to.</typeparam>
        /// <param name="input">The input value to convert.</param>
        /// <returns></returns>
        public static T Convert<T>(this string input)
        {
            try
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    // Cast ConvertFromString(string text) : object to (T)
                    return (T)converter.ConvertFromString(input);
                }
                return default;
            }
            catch (NotSupportedException)
            {
                return default;
            }
        }
    }
}
