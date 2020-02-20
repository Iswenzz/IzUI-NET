using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Iswenzz.UI.Controls.Game.MKW
{
    public partial class TimeTrialCard : Control
    {
        private string circuitName = "Luigi Circui";
        [DefaultValue("Luigi Circui")]
        [Description("The circuit name.")]
        public string CircuitName
        {
            get => circuitName;
            set { circuitName = value; Invalidate(); }
        }

        private string timeText = "1:08.774";
        [Description("The record time.")]
        public string TimeText
        {
            get => timeText;
            set { timeText = value; Invalidate(); }
        }

        private string playerName = "Player";
        [Description("The player name.")]
        public string PlayerName
        {
            get => playerName;
            set { playerName = value; Invalidate(); }
        }

        private Bitmap backgroundImage = Resources.bg;
        [Description("The background image.")]
        public new Bitmap BackgroundImage
        {
            get => backgroundImage;
            set { backgroundImage = value; Invalidate(); }
        }

        private Bitmap comboImage = Resources.funky_flame;
        [Description("The record time.")]
        public Bitmap ComboImage
        {
            get => comboImage;
            set { comboImage = value; Invalidate(); }
        }

        private Bitmap controllerImage = Resources.gamecube;
        [Description("The controller image.")]
        public Bitmap ControllerImage
        {
            get => controllerImage;
            set { controllerImage = value; Invalidate(); }
        }

        private Bitmap cardImage = Resources.ttcard;
        [Description("The card image.")]
        public Bitmap CardImage
        {
            get => cardImage;
            set { cardImage = value; Invalidate(); }
        }

        public TimeTrialCard()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            using StringFormat sfCenter = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
            };

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
            PointF pName = new PointF(cardRect.X + (cardRect.Width / 1.48f), cardRect.Y + (cardRect.Height / 1.55f));
            pe.Graphics.DrawString(PlayerName, Font, Brushes.Gainsboro, pName, sfCenter);

            // Controller
            RectangleF pController = new RectangleF(cardRect.X + (cardRect.Width / 1.4f),
                cardRect.Y + (cardRect.Height / 3.9f), cardRect.Height / 5, cardRect.Height / 5);
            pe.Graphics.DrawImage(ControllerImage, pController);

            // Combo
            RectangleF comboRect = new RectangleF(cardRect.X + (cardRect.Width / 7.8f),
                cardRect.Y + (cardRect.Height / 2.05f), cardRect.Width / 5, cardRect.Height / 3);
            pe.Graphics.DrawImage(ComboImage, comboRect);

            base.OnPaint(pe);
        }
    }
}
