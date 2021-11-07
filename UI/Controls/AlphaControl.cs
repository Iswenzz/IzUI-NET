using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls
{
    /// <summary>
    /// Base component class that supports alpha.
    /// </summary>
    public partial class AlphaControl : Control
    {
        public const int WS_EX_TRANSPARENT = 0x20;

        [Browsable(false)] public bool IsTransparent { get; set; }

        /// <summary>
        /// Allow components to be transparent.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (IsTransparent)
                    cp.ExStyle |= WS_EX_TRANSPARENT;
                return cp;
            }
        }

        /// <summary>
        /// Initialize a new <see cref="AlphaControl"/> object.
        /// </summary>
        public AlphaControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);

            BackColor = Color.Transparent;
        }

        /// <summary>
        /// Update the transparency when parent back color changes.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnParentBackColorChanged(EventArgs e)
        {
            if (IsTransparent)
                Invalidate();
            base.OnParentBackColorChanged(e);
        }

        /// <summary>
        /// Update the parent when back color changes.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnBackColorChanged(EventArgs e)
        {
            IsTransparent = BackColor == Color.Transparent;
            if (IsTransparent && Parent != null)
                Parent.Invalidate(Bounds, true);
            base.OnBackColorChanged(e);
        }
    }
}
