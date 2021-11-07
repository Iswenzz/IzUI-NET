using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls.Inputs
{
    public partial class ButtonImage : Button
    {
        private Image currentImage;
        /// <summary>
        /// Default background image.
        /// </summary>
        [Browsable(false)]
        private Image CurrentImage
        {
            get => currentImage;
            set { currentImage = value; Invalidate(); }
        }

        private Image activeImage;
        /// <summary>
        /// Active background image.
        /// </summary>
        [Description("Change the BackgroundImage when MouseHover")]
        public Image ActiveImage
        {
            get => activeImage;
            set { activeImage = value; Invalidate(); }
        }

        /// <summary>
        /// Initialize a new <see cref="ButtonImage"/> object.
        /// </summary>
        public ButtonImage()
        {
            InitializeComponent();
            TextAlign = ContentAlignment.MiddleCenter;
            FlatStyle = FlatStyle.Flat;
            Size = new Size(60, 60);
            BackColor = Color.Transparent;
            ForeColor = Color.WhiteSmoke;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            CurrentImage = BackgroundImage;
            Text = "";
        }

        /// <summary>
        /// Mouse leave callback.
        /// </summary>
        /// <param name="e">Mouse event.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            BackgroundImage = CurrentImage;
            Invalidate();
        }

        /// <summary>
        /// Mouse enter callback
        /// </summary>
        /// <param name="e">Mouse event.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            CurrentImage = BackgroundImage;
            BackgroundImage = ActiveImage;
            Invalidate();
        }
    }
}
