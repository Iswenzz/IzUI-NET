﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

using Iswenzz.UI.Design;
using Iswenzz.UI.Utils;

namespace Iswenzz.UI.Controls
{
    /// <summary>
    /// Base control class.
    /// </summary>
    public abstract class AbstractButton : Button, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected CreateParams BaseCreateParams { get => base.CreateParams; }
        protected bool BasePainting { get; set; } = true;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)] public override System.Drawing.ContentAlignment TextAlign { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance"), Description("Layout alignment and rotation angle.")]
        public virtual TextLayouts TextLayouts { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance"), Description("Border styles.")]
        public virtual Border Border { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance"), Description("Icon styles.")]
        public virtual Icon Icon { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance"), Description("Animations styles.")]
        public virtual Animations Animations { get; set; }

        /// <summary>
        /// Initialize a new <see cref="AbstractButton"/> object.
        /// </summary>
        protected AbstractButton()
        {
            TextLayouts = new TextLayouts(this);
            Border = new Border(this);
            Icon = new Icon(this);
            Animations = new Animations(this);
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
            if (BasePainting)
                base.OnPaint(pe);

            Border?.OnPaint(pe);
            Icon?.OnPaint(pe);
            Animations?.OnPaint(pe);
            TextLayouts?.OnPaint(pe);
        }

        /// <summary>
        /// Release all resources.
        /// </summary>
        /// <param name="disposing">Should dispose.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            Border?.Dispose();
            Icon?.Dispose();
            Animations?.Dispose();
            TextLayouts?.Dispose();
        }

        /// <summary>
        /// Invalidate on class property changes.
        /// </summary>
        /// <param name="eventArgs">Property event args.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs eventArgs) =>
            NotifyProperty.Callback(this, PropertyChanged, eventArgs);
    }
}
