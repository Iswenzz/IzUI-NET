using System;
using System.ComponentModel;
using System.Windows.Forms;

using Iswenzz.UI.Design;
using Iswenzz.UI.Utils;

namespace Iswenzz.UI.Controls
{
    /// <summary>
    /// Base control class.
    /// </summary>
    public partial class BaseButton : Button, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected override CreateParams CreateParams { get => Alpha.CreateParams(base.CreateParams); }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Transparency settings.")]
        public Alpha Alpha { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Layout alignment and rotation angle.")]
        public Layouts Layouts { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Border styles.")]
        public Border Border { get; set; }

        /// <summary>
        /// Initialize a new <see cref="BaseButton"/> object.
        /// </summary>
        public BaseButton()
        {
            Layouts = new Layouts(this);
            Alpha = new Alpha(this);
            Border = new Border(this);

            SetStyle(Alpha.ControlStylesToEnable, true);
       }

        /// <summary>
        /// Callback when back color changes.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnParentBackColorChanged(EventArgs e)
        {
            Alpha.OnParentBackColorChanged(e);
            base.OnParentBackColorChanged(e);
        }

        /// <summary>
        /// Update the parent when back color changes.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnBackColorChanged(EventArgs e)
        {
            Alpha.OnBackColorChanged(e);
            base.OnBackColorChanged(e);
        }

        /// <summary>
        /// Invalidate on class property changes.
        /// </summary>
        /// <param name="eventArgs">Property event args.</param>
        protected void OnPropertyChanged(PropertyChangedEventArgs eventArgs) =>
            NotifyProperty.Callback(this, PropertyChanged, eventArgs);
    }
}
