using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iswenzz.UI.Controls.Buttons
{
    public partial class ImageButton : FlatButton
    {
        private Image currentImage;
        [Browsable(false)]
        private Image CurrentImage
        {
            get => currentImage;
            set { currentImage = value; Invalidate(); }
        }

        private Image activeImage;
        [Description("Change the BackgroundImage when MouseHover")]
        public Image ActiveImage
        {
            get => activeImage;
            set { activeImage = value; Invalidate(); }
        }

        public ImageButton()
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

        protected override void OnMouseLeave(EventArgs e)
        {
            BackgroundImage = CurrentImage;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            CurrentImage = BackgroundImage;
            BackgroundImage = ActiveImage;
            Invalidate();
        }
    }
}
