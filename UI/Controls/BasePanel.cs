using System;
using System.ComponentModel;
using System.Windows.Forms;

using Iswenzz.UI.Design;
using Iswenzz.UI.Utils;

namespace Iswenzz.UI.Controls
{
    /// <summary>
    /// Base panel class.
    /// </summary>
    public partial class BasePanel : Panel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Layout alignment and rotation angle.")]
        public Layouts Layouts { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Border styles.")]
        public Border Border { get; set; }

        /// <summary>
        /// Initialize a new <see cref="BasePanel"/> object.
        /// </summary>
        public BasePanel() : base()
        {
            Layouts = new Layouts(this);
            Border = new Border(this);
        }

        /// <summary>
        /// Invalidate on class property changes.
        /// </summary>
        /// <param name="eventArgs">Property event args.</param>
        protected void OnPropertyChanged(PropertyChangedEventArgs eventArgs) =>
            NotifyProperty.Callback(this, PropertyChanged, eventArgs);
    }
}
