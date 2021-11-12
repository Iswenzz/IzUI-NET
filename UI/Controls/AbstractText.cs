using System;
using System.ComponentModel;
using System.Windows.Forms;

using Iswenzz.UI.Design;
using Iswenzz.UI.Utils;

namespace Iswenzz.UI.Controls
{
    /// <summary>
    /// Base text class.
    /// </summary>
    public abstract partial class AbstractText : Control, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected CreateParams BaseCreateParams { get => base.CreateParams; }
        protected override CreateParams CreateParams { get => Alpha.CreateParams(base.CreateParams); }
        protected bool BasePainting { get; set; } = true;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance"), Description("Transparency settings.")]
        public virtual Alpha Alpha { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance"), Description("Layout alignment and rotation angle.")]
        public virtual TextLayouts TextLayouts { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance"), Description("Border styles.")]
        public virtual Border Border { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance"), Description("Animations styles.")]
        public virtual Animations Animations { get; set; }

        /// <summary>
        /// Initialize a new <see cref="AbstractText"/> object.
        /// </summary>
        protected AbstractText()
        {
            InitializeComponent();
            TextLayouts = new TextLayouts(this);
            Alpha = new Alpha(this);
            Border = new Border(this);
            Animations = new Animations(this);

            SetStyle(Alpha.ControlStylesToEnable, true);
        }

        /// <summary>
        /// Mouse leave callback.
        /// </summary>
        /// <param name="e">Mouse event.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Animations.OnMouseLeave(e);
        }

        /// <summary>
        /// Mouse enter callback.
        /// </summary>
        /// <param name="e">Mouse event.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Animations.OnMouseEnter(e);
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
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            if (BasePainting)
                base.OnPaint(pe);

            Border.OnPaint(pe);
            Animations.OnPaint(pe);
            TextLayouts.OnPaint(pe);
        }

        /// <summary>
        /// Invalidate on class property changes.
        /// </summary>
        /// <param name="eventArgs">Property event args.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs eventArgs) =>
            NotifyProperty.Callback(this, PropertyChanged, eventArgs);
    }
}
