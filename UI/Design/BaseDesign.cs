using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using Iswenzz.UI.Utils;

namespace Iswenzz.UI.Design
{
    /// <summary>
    /// Represent an object in a <see cref="Control"/> designer.
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public abstract class BaseDesign : INotifyPropertyChanged
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)] 
        public Control Owner { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)] 
        public event PropertyChangedEventHandler PropertyChanged;

        [Browsable(false)] public virtual ControlStyles ControlStylesToEnable { get; }
        [Browsable(false)] public virtual ControlStyles ControlStylesToDisable { get; }

        /// <summary>
        /// Create a new <see cref="BaseDesign"/>.
        /// </summary>
        /// <param name="owner">The <see cref="Control"/> owner.</param>
        protected BaseDesign(Control owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// Invalidate on class property changes.
        /// </summary>
        /// <param name="eventArgs">Property event args.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs eventArgs) =>
            NotifyProperty.Callback(this, PropertyChanged, eventArgs);

        /// <summary>
        /// Override the grid view display value.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            IEnumerable<PropertyInfo> properties = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .OrderBy(p => p.Name);

            List<string> propertyValues = new();
            foreach (PropertyInfo property in properties)
            {
                BrowsableAttribute atr = property.GetCustomAttribute<BrowsableAttribute>();
                if (atr != null && !atr.Browsable)
                    continue;
                propertyValues.Add(property.GetValue(this).ToString());
            }
            return string.Join(", ", propertyValues);
        }
    }
}
