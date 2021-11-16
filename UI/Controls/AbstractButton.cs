using System.ComponentModel;
using System.Windows.Forms;

using Iswenzz.UI.Design;

namespace Iswenzz.UI.Controls
{
    /// <summary>
    /// Base button class.
    /// </summary>
    public abstract class AbstractButton : AbstractControl, INotifyPropertyChanged
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Layouts Layouts { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance"), Description("Layout alignment and rotation angle.")]
        public virtual TextLayouts TextLayouts { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance"), Description("Icon styles.")]
        public virtual Icon Icon { get; set; }

        /// <summary>
        /// Initialize a new <see cref="AbstractButton"/> object.
        /// </summary>
        protected AbstractButton() : base()
        {
            TextLayouts = new TextLayouts(this);
            Icon = new Icon(this);
            Layouts = null;
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Icon?.OnPaint(pe);
            TextLayouts?.OnPaint(pe);
        }

        /// <summary>
        /// Release all resources.
        /// </summary>
        /// <param name="disposing">Should dispose.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            Icon?.Dispose();
            TextLayouts?.Dispose();
        }
    }
}
