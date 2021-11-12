using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iswenzz.UI.Design
{
    /// <summary>
    /// Icon design.
    /// </summary>
    public class Icon : AbstractDesign, INotifyPropertyChanged
    {
        /// <summary>
        /// Button icon.
        /// </summary>
        [Description("Button icon.")]
        public virtual Image IconImage { get; set; }

        /// <summary>
        /// Icon placement.
        /// </summary>
        [Description("Button icon placement.")]
        public virtual bool IconAutoPlacement { get; set; }

        /// <summary>
        /// Icon size.
        /// </summary>
        [Description("Button icon size (0 = Auto).")]
        public virtual int IconSize { get; set; }

        /// <summary>
        /// Create a new <see cref="Icon"/>.
        /// </summary>
        /// <param name="owner">The <see cref="Control"/> owner.</param>
        public Icon(Control owner) : base(owner) { }
        
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
            IconAutoPlacement = autoPlace;
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        public override void OnPaint(PaintEventArgs pe)
        {
            if (!Renderable || IconImage == null) return;

            // Icon render
            if (IconSize == 0 && IconAutoPlacement)
                pe.Graphics.DrawImage(IconImage,
                    new Rectangle((Owner.Width / 2 / 2) - Owner.Height / 2, 0, Owner.Height, Owner.Height));
            if (IconSize != 0 && IconAutoPlacement)
                pe.Graphics.DrawImage(IconImage,
                    new Rectangle((Owner.Width / 2 / 2) - IconSize / 2, 0, IconSize, IconSize));
            if (IconSize == 0 && !IconAutoPlacement)
                pe.Graphics.DrawImage(IconImage,
                    new Rectangle(10, 0, Owner.Height, Owner.Height));
            if (IconSize != 0 && !IconAutoPlacement)
                pe.Graphics.DrawImage(IconImage,
                    new Rectangle(10, 0, IconSize, IconSize));
        }
    }
}
