﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IzUI.WinForms.UI.Design
{
    /// <summary>
    /// Base design class that supports alpha.
    /// </summary>
    [Browsable(false)]
    public class Alpha : AbstractDesign
    {
        public const int WS_EX_TRANSPARENT = 0x20;

        protected virtual bool IsTransparent { get; set; }

        public override ControlStyles ControlStylesToEnable 
        {
            get => ControlStyles.SupportsTransparentBackColor | 
                ControlStyles.Opaque;
        }

        /// <summary>
        /// Create a new <see cref="Alpha"/>.
        /// </summary>
        /// <param name="control">The <see cref="Control"/>.</param>
        public Alpha(Control control) : base(control) { }

        /// <summary>
        /// Allow components to be transparent.
        /// </summary>
        /// <param name="controlParams">The <see cref="System.Windows.Forms.CreateParams"/>.</param>
        /// <returns></returns>
        public virtual CreateParams CreateParams(CreateParams controlParams)
        {
            if (IsTransparent)
                controlParams.ExStyle |= WS_EX_TRANSPARENT;
            return controlParams;
        }

        /// <summary>
        /// Update the transparency when parent back color changes.
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnParentBackColorChanged(EventArgs e)
        {
            if (IsTransparent)
                Control.Invalidate();
        }

        /// <summary>
        /// Update the parent when back color changes.
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnBackColorChanged(EventArgs e)
        {
            IsTransparent = Control.BackColor == Color.Transparent;
            if (IsTransparent && Control.Parent != null)
                Control.Parent.Invalidate(Control.Bounds, true);
        }
    }
}
