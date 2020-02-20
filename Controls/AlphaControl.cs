using System;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls
{
    /// <summary>
    /// Base component class that supports alpha.
    /// </summary>
    public partial class AlphaControl : Control
    {
        /// <summary>
        /// Initialize a new <see cref="AlphaControl"/> object.
        /// </summary>
        public AlphaControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            Invalidate();
            base.OnParentBackColorChanged(e);
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            if (Parent != null)
                Parent.Invalidate(Bounds, true);
            base.OnBackColorChanged(e);
        }

        /// <summary>
        /// Allow components to be transparent.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }
    }
}
