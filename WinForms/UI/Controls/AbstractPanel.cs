﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

using IzUI.WinForms.UI.Design.Background;
using IzUI.WinForms.UI.Design.Data;
using IzUI.WinForms.UI.Design.Layout;

namespace IzUI.WinForms.UI.Controls
{
    /// <summary>
    /// Base panel class.
    /// </summary>
    public abstract class AbstractPanel : Panel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected CreateParams BaseCreateParams => base.CreateParams;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance"), Description("Layout alignment and rotation angle.")]
        public virtual Layouts Layouts { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance"), Description("Border styles.")]
        public virtual Border Border { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance"), Description("Animations styles.")]
        public virtual Animations Animations { get; set; }

        /// <summary>
        /// Initialize a new <see cref="AbstractPanel"/> object.
        /// </summary>
        protected AbstractPanel() : base()
        {
            Animations = new Animations(this, false);
            Layouts = new Layouts(this);
            Border = new Border(this);

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);
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
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            Animations.OnPaint(pe);
            Border.OnPaint(pe);
            Layouts.OnPaint(pe);
            base.OnPaint(pe);
        }

        /// <summary>
        /// Release all resources.
        /// </summary>
        /// <param name="disposing">Should dispose.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Animations.Dispose();
            Border.Dispose();
            Layouts.Dispose();
        }

        /// <summary>
        /// Invalidate on class property changes.
        /// </summary>
        /// <param name="eventArgs">Property event args.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            Invalidate();
        }
    }
}
