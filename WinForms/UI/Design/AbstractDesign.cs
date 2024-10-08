﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace IzUI.WinForms.UI.Design
{
    /// <summary>
    /// Represent a designer object.
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public abstract class AbstractDesign : IDisposable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control Control { get; protected set; }

        [Browsable(true)]
        public virtual bool Enabled { get; set; } = true;

        [Browsable(false)]
        public virtual ControlStyles ControlStylesToEnable { get; }

        [Browsable(false)]
        public virtual ControlStyles ControlStylesToDisable { get; }

        /// <summary>
        /// Create a new <see cref="AbstractDesign"/>.
        /// </summary>
        /// <param name="control">The <see cref="System.Windows.Forms.Control"/>.</param>
        protected AbstractDesign(Control control)
        {
            Control = control;
        }

        /// <summary>
        /// Create a new <see cref="AbstractDesign"/>.
        /// </summary>
        /// <param name="control">The <see cref="System.Windows.Forms.Control"/>.</param>
        /// <param name="enabled">Is enabled</param>
        protected AbstractDesign(Control control, bool enabled)
        {
            Control = control;
            Enabled = enabled;
        }

        /// <summary>
        /// Disable rendering.
        /// </summary>
        public virtual void Disable()
        {
            Enabled = false;
        }

        /// <summary>
        /// Enable rendering.
        /// </summary>
        public virtual void Enable()
        {
            Enabled = true;
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        public virtual void OnPaint(PaintEventArgs pe) { }

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

        /// <summary>
        /// Dispose all resources.
        /// </summary>
        public virtual void Dispose() { }

        /// <summary>
        /// Invalidate on class property changes.
        /// </summary>
        /// <param name="eventArgs">Property event args.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            Control.Invalidate();
        }
    }
}
