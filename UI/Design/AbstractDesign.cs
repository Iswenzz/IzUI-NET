using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using Iswenzz.UI.Utils;

namespace Iswenzz.UI.Design
{
    /// <summary>
    /// Represent a designer object.
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public abstract class AbstractDesign : INotifyPropertyChanged
    {
        [Browsable(false)] 
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control Owner { get; protected set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DisableRender { get; set; }

        [Browsable(false)] 
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event PropertyChangedEventHandler PropertyChanged;

        [Browsable(false)] public virtual ControlStyles ControlStylesToEnable { get; }
        [Browsable(false)] public virtual ControlStyles ControlStylesToDisable { get; }

        /// <summary>
        /// Create a new <see cref="AbstractDesign"/>.
        /// </summary>
        /// <param name="owner">The <see cref="Control"/> owner.</param>
        protected AbstractDesign(Control owner)
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
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        public abstract void OnPaint(PaintEventArgs pe);

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
