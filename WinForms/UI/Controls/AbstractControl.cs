using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using IzUI.WinForms.UI.Design;

namespace IzUI.WinForms.UI.Controls
{
    /// <summary>
    /// Base control class.
    /// </summary>
    public abstract partial class AbstractControl : Control
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected CreateParams BaseCreateParams { get => base.CreateParams; }
        protected override CreateParams CreateParams { get => Alpha.CreateParams(base.CreateParams); }

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
            InitializeComponent();

            Label a;

            Layouts = new Layouts(this);
            Alpha = new Alpha(this);
            Border = new Border(this);
            Animations = new Animations(this);

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
            base.OnPaint(pe);

            Alpha?.OnPaint(pe);
            Border?.OnPaint(pe);
            Animations?.OnPaint(pe);
            Layouts?.OnPaint(pe);
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
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);

            Alpha?.Dispose();
            Border?.Dispose();
            Animations?.Dispose();
            Layouts?.Dispose();
        }
    }
}
