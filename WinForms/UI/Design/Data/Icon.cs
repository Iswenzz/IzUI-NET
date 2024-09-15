using System.ComponentModel;
using System.Drawing;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace IzUI.WinForms.UI.Design.Data
{
    /// <summary>
    /// Icon design.
    /// </summary>
    [SupportedOSPlatform("windows10.0")]
    public class Icon : AbstractDesign
    {
        /// <summary>
        /// Button icon.
        /// </summary>
        [Description("Button icon.")]
        public virtual Image IconImage { get; set; }

        /// <summary>
        /// Icon size.
        /// </summary>
        [Description("Button icon size (0 = Auto).")]
        public virtual int IconSize { get; set; }

        /// <summary>
        /// Create a new <see cref="Icon"/>.
        /// </summary>
        /// <param name="control">The <see cref="Control"/>.</param>
        public Icon(Control control) : base(control) { }

        /// <summary>
        /// Create a new <see cref="Icon"/>.
        /// </summary>
        /// <param name="control">The <see cref="Control"/>.</param>
        /// <param name="enabled">Is enabled.</param>
        public Icon(Control control, bool enabled) : base(control, enabled) { }

        /// <summary>
        /// Set button icon.
        /// </summary>
        /// <param name="icon">Icon Image.</param>
        /// <param name="size">Icon size.</param>
        /// <param name="autoPlace">Toggle automatic placement.</param>
        public virtual void SetIcon(Image icon, int size, bool autoPlace)
        {
            IconImage = icon;
            IconSize = size;
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        public override void OnPaint(PaintEventArgs pe)
        {
            if (!Enabled || IconImage == null) return;

            // Icon render
            int size = IconSize > 0 ? IconSize : IconImage.Height;
            pe.Graphics.DrawImage(IconImage, new Rectangle(
                Control.Width / 6 - size / 2,
                Control.Height / 2 - size / 2,
                size, size));
        }
    }
}
