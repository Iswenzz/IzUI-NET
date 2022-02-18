using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using IzUI.WinForms.UI.Data;
using IzUI.WinForms.UI.Controls.Game.MKW.Resources;

namespace IzUI.WinForms.UI.Controls.Game.MKW
{
    /// <summary>
    /// MK Time trial card control.
    /// </summary>
    public class TimeTrialCard : AbstractControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Circuit name.
        /// </summary>
        [DefaultValue("Luigi Circui")]
        [Category("Game"), Description("The circuit name.")]
        public virtual string CircuitName { get; set; } = "Luigi Circui";

        /// <summary>
        /// Time string.
        /// </summary>
        [DefaultValue("1:08.774")]
        [Category("Game"), Description("The record time.")]
        public virtual string TimeText { get; set; } = "1:08.774";

        /// <summary>
        /// Player name.
        /// </summary>
        [DefaultValue("Cole")]
        [Category("Game"), Description("The player name.")]
        public virtual string PlayerName { get; set; } = "Cole";

        /// <summary>
        /// Background image.
        /// </summary>
        [Category("Game"), Description("The background image.")]
        public virtual new Bitmap BackgroundImage { get; set; } = MKWResources.MKW_BG;

        /// <summary>
        /// Atlas image.
        /// </summary>
        [Category("Game"), Description("The flag image.")]
        public virtual Bitmap FlagImage { get; set; } = MKWResources.MKW_Flags;

        /// <summary>
        /// Combo Image.
        /// </summary>
        [Category("Game"), Description("The character and vehicle used.")]
        public virtual Bitmap ComboImage { get; set; } = MKWResources.MKW_FunkyKong_Spear;

        /// <summary>
        /// Controller image.
        /// </summary>
        [Category("Game"), Description("The controller image.")]
        public virtual Bitmap ControllerImage { get; set; } = MKWResources.MKW_Gamecube;

        /// <summary>
        /// Card image.
        /// </summary>
        [Category("Game"), Description("The card image.")]
        public virtual Bitmap CardImage { get; set; } = MKWResources.MKW_TTCard;

        /// <summary>
        /// Country code.
        /// </summary>
        [DefaultValue(18)]
        [Category("Game"), Description("The country code.")]
        public virtual int CountryCode { get; set; } = 18;

        /// <summary>
        /// Initialize a new <see cref="TimeTrialCard"/> object.
        /// </summary>
        public TimeTrialCard() : base()
        {
            DoubleBuffered = true;
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Render data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            using BitmapAtlas atlas = new(16, 16)
            {
                Bitmap = MKWResources.MKW_Flags,
                Size = new Size(512, 512)
            };
            using StringFormat sfCenter = Alignment.GetStringFormat(ContentAlignment.MiddleCenter);

            // BG
            RectangleF bgRect = new(PointF.Empty, Size);
            pe.Graphics.DrawImage(BackgroundImage, bgRect);

            // Card
            RectangleF cardRect = new(
                bgRect.Size.Width / 4, bgRect.Size.Height / 4,
                bgRect.Width / 2, bgRect.Height / 2);
            pe.Graphics.DrawImage(CardImage, cardRect);

            // Map
            PointF pMap = new(cardRect.X + (cardRect.Width / 2f), cardRect.Y + (cardRect.Height / 5.5f));
            pe.Graphics.DrawString(CircuitName, Font, Brushes.Gainsboro, pMap, sfCenter);

            // Time
            PointF pTime = new(cardRect.X + (cardRect.Width / 2f), cardRect.Y + (cardRect.Height / 2.8f));
            pe.Graphics.DrawString(TimeText, Font, Brushes.Gainsboro, pTime, sfCenter);

            // Name
            PointF pName = new(cardRect.X + (cardRect.Width / 1.475f), cardRect.Y + (cardRect.Height / 1.35f));
            pe.Graphics.DrawString(PlayerName, Font, Brushes.Gainsboro, pName, sfCenter);

            // Controller
            RectangleF pController = new(cardRect.X + (cardRect.Width / 1.4f),
                cardRect.Y + (cardRect.Height / 3.9f), cardRect.Height / 5, cardRect.Height / 5);
            pe.Graphics.DrawImage(ControllerImage, pController);

            // Combo
            RectangleF comboRect = new(cardRect.X + (cardRect.Width / 7.8f),
                cardRect.Y + (cardRect.Height / 2.05f), cardRect.Width / 5, cardRect.Height / 3);
            pe.Graphics.DrawImage(ComboImage, comboRect);

            // Flag
            using Bitmap flag = atlas.GetBitmapFromIndex(CountryCode);
            RectangleF flagRect = new(cardRect.X + (cardRect.Width / 1.6f),
                cardRect.Y + (cardRect.Height / 2f), cardRect.Height / 5, cardRect.Height / 5);
            pe.Graphics.DrawImage(flag, flagRect);

            base.OnPaint(pe);
        }
    }
}
