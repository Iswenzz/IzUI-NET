using System;
using System.ComponentModel;
using System.Windows.Forms;

using IzUI.WinForms.UI.Design.Data;
using IzUI.WinForms.UI.Design.Layout;

namespace IzUI.WinForms.UI.Controls
{
    /// <summary>
    /// Base text class.
    /// </summary>
    public abstract class AbstractText : AbstractControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance"), Description("Layout alignment and rotation angle.")]
        public virtual TextLayouts TextLayouts { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance"), Description("Icon styles.")]
        public virtual Icon Icon { get; set; }

        /// <summary>
        /// Initialize a new <see cref="AbstractText"/> object.
        /// </summary>
        protected AbstractText() : base()
        {
            TextLayouts = new TextLayouts(this);
            Icon = new Icon(this);
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Icon.OnPaint(pe);
            TextLayouts.OnPaint(pe);
        }

        /// <summary>
        /// Release all resources.
        /// </summary>
        /// <param name="disposing">Should dispose.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            Icon.Dispose();
            TextLayouts.Dispose();
        }
    }
}
