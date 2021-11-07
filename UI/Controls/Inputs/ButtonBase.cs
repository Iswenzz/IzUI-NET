using System;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls.Inputs
{
    /// <summary>
    /// Base button component class that supports alpha.
    /// </summary>
    public partial class ButtonBase : System.Windows.Forms.Button
    {
        /// <summary>
        /// Initialize a new <see cref="ButtonBase"/> object.
        /// </summary>
        public ButtonBase()
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
        //protected override CreateParams CreateParams // not supported with rounded corner?
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x20;
        //        return cp;
        //    }
        //}
    }
}
