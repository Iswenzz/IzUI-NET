using System;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls.Buttons
{
    public partial class AlphaButton : Button
    {
        public AlphaButton()
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
