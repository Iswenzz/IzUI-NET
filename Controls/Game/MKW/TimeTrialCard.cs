using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace Iswenzz.UI.Controls.Game.MKW
{
    public partial class TimeTrialCard : Control
    {
        private string circuitName = "Luigi Circui";
        /// <summary>
        /// Circuit name.
        /// </summary>
        [DefaultValue("Luigi Circui")]
        [Description("The circuit name.")]
        public string CircuitName
        {
            get => circuitName;
            set { circuitName = value; Invalidate(); }
        }

        private string timeText = "1:08.774";
        /// <summary>
        /// Time string.
        /// </summary>
        [Description("The record time.")]
        public string TimeText
        {
            get => timeText;
            set { timeText = value; Invalidate(); }
        }

        private string playerName = "Cole";
        /// <summary>
        /// Player name.
        /// </summary>
        [Description("The player name.")]
        public string PlayerName
        {
            get => playerName;
            set { playerName = value; Invalidate(); }
        }

        private Bitmap backgroundImage = Resources.bg;
        /// <summary>
        /// Background image.
        /// </summary>
        [Description("The background image.")]
        public new Bitmap BackgroundImage
        {
            get => backgroundImage;
            set { backgroundImage = value; Invalidate(); }
        }

        private Bitmap flagImage;
        /// <summary>
        /// Atlas image.
        /// </summary>
        [Description("The flag image.")]
        public Bitmap FlagImage
        {
            get => flagImage;
            set { flagImage = value; Invalidate(); }
        }

        private Bitmap comboImage = Resources.Spear_FunkyKong;
        /// <summary>
        /// Combo Image
        /// </summary>
        [Description("The character and vehicle used.")]
        public Bitmap ComboImage
        {
            get => comboImage;
            set { comboImage = value; Invalidate(); }
        }

        private Bitmap controllerImage = Resources.gamecube;
        /// <summary>
        /// Controller image.
        /// </summary>
        [Description("The controller image.")]
        public Bitmap ControllerImage
        {
            get => controllerImage;
            set { controllerImage = value; Invalidate(); }
        }

        private Bitmap cardImage = Resources.ttcard;
        /// <summary>
        /// Card image.
        /// </summary>
        [Description("The card image.")]
        public Bitmap CardImage
        {
            get => cardImage;
            set { cardImage = value; Invalidate(); }
        }

        private int countryCode = 18;
        /// <summary>
        /// Country code.
        /// </summary>
        [Description("The country code.")]
        public int CountryCode
        {
            get => countryCode;
            set { countryCode = value; Invalidate(); }
        }

        /// <summary>
        /// Initialize a new <see cref="TimeTrialCard"/> object.
        /// </summary>
        public TimeTrialCard()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        /// <summary>
        /// Render callback.
        /// </summary>
        /// <param name="pe">Render data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            using BitmapAtlas atlas = new BitmapAtlas(16, 16) 
            {
                Bitmap = Resources.flags_32,
                Size = new Size(512, 512)
            };

            using StringFormat sfCenter = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };

            pe.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;

            // BG
            RectangleF bgRect = new RectangleF(PointF.Empty, Size);
            pe.Graphics.DrawImage(BackgroundImage, bgRect);

            // Card
            RectangleF cardRect = new RectangleF(bgRect.Size.Width / 4, bgRect.Size.Height / 4,
                bgRect.Width / 2, bgRect.Height / 2);
            pe.Graphics.DrawImage(CardImage, cardRect);

            // Map name
            PointF pMap = new PointF(cardRect.X + (cardRect.Width / 2f), cardRect.Y + (cardRect.Height / 5.5f));
            pe.Graphics.DrawString(CircuitName, Font, Brushes.Gainsboro, pMap, sfCenter);

            // Time
            PointF pTime = new PointF(cardRect.X + (cardRect.Width / 2f), cardRect.Y + (cardRect.Height / 2.8f));
            pe.Graphics.DrawString(TimeText, Font, Brushes.Gainsboro, pTime, sfCenter);

            // Name
            PointF pName = new PointF(cardRect.X + (cardRect.Width / 1.475f), cardRect.Y + (cardRect.Height / 1.35f));
            pe.Graphics.DrawString(PlayerName, Font, Brushes.Gainsboro, pName, sfCenter);

            // Controller
            RectangleF pController = new RectangleF(cardRect.X + (cardRect.Width / 1.4f),
                cardRect.Y + (cardRect.Height / 3.9f), cardRect.Height / 5, cardRect.Height / 5);
            pe.Graphics.DrawImage(ControllerImage, pController);

            // Combo
            RectangleF comboRect = new RectangleF(cardRect.X + (cardRect.Width / 7.8f),
                cardRect.Y + (cardRect.Height / 2.05f), cardRect.Width / 5, cardRect.Height / 3);
            pe.Graphics.DrawImage(ComboImage, comboRect);

            // Flag
            using Bitmap flag = atlas.GetBitmapFromIndex(CountryCode);
            RectangleF flagRect = new RectangleF(cardRect.X + (cardRect.Width / 1.6f), 
                cardRect.Y + (cardRect.Height / 2f), cardRect.Height / 5, cardRect.Height / 5);
            pe.Graphics.DrawImage(flag, flagRect);

            base.OnPaint(pe);
        }
    }
}
