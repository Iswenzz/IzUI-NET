using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Versioning;
using System.Windows.Forms;

using IzUI.WinForms.UI.Design.Background;
using IzUI.WinForms.UI.Design.Data;
using IzUI.WinForms.UI.Design.Layout;

namespace IzUI.WinForms.UI.Controls
{
    /// <summary>
    /// Base control class.
    /// </summary>
    [SupportedOSPlatform("windows10.0")]
    public abstract class AbstractControl : Control, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected CreateParams BaseCreateParams => base.CreateParams;
        protected override CreateParams CreateParams => Alpha.CreateParams(base.CreateParams);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance"), Description("Transparency settings.")]
        public virtual Alpha Alpha { get; set; }

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
        /// Initialize a new <see cref="AbstractControl"/> object.
        /// </summary>
        protected AbstractControl()
        {
            Animations = new Animations(this, false);
            Layouts = new Layouts(this);
            Alpha = new Alpha(this);
            Border = new Border(this);

            SetStyle(Alpha.ControlStylesToEnable, true);
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
        /// Callback when back color changes.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnParentBackColorChanged(EventArgs e)
        {
            Alpha.OnParentBackColorChanged(e);
            base.OnParentBackColorChanged(e);
        }

        /// <summary>
        /// Update the parent when back color changes.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnBackColorChanged(EventArgs e)
        {
            Alpha.OnBackColorChanged(e);
            base.OnBackColorChanged(e);
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            Alpha.OnPaint(pe);
            Animations.OnPaint(pe);
            Border.OnPaint(pe);
            Layouts.OnPaint(pe);
            base.OnPaint(pe);
        }

        /// <summary>
        /// Paint the transparency background.
        /// </summary>
        /// <param name="pe">Paint data.</param>
        protected void PaintTransparency(PaintEventArgs pe)
        {
            GraphicsContainer cstate = pe.Graphics.BeginContainer();
            pe.Graphics.TranslateTransform(-Left, -Top);
            Rectangle clip = pe.ClipRectangle;
            clip.Offset(Left, Top);
            PaintEventArgs peArgs = new(pe.Graphics, clip);

            InvokePaintBackground(Parent, peArgs);
            InvokePaint(Parent, peArgs);
            pe.Graphics.EndContainer(cstate);
        }

        /// <summary>
        /// Release all resources.
        /// </summary>
        /// <param name="disposing">Should dispose.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Alpha.Dispose();
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
