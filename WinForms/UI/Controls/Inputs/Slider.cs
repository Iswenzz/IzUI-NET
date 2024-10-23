using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using IzUI.WinForms.UI.Maths;
using IzUI.WinForms.UI.Utils;

namespace IzUI.WinForms.UI.Controls.Inputs
{
    /// <summary>
    /// Slider control.
    /// Credits: Michal Brylka
    /// </summary>
    [ToolboxBitmap(typeof(TrackBar))]
    [DefaultEvent("Scroll"), DefaultProperty("BarInnerColor")]
    public class Slider : AbstractControl
    {
        private bool MouseInRegion { get; set; }
        private bool MouseInThumbRegion { get; set; }

        /// <summary>
        /// Fires when Slider position has changed.
        /// </summary>
        [Category("Action"), Description("Event fires when the Value property changes.")]
        public event EventHandler ValueChanged;

        /// <summary>
        /// Fires when user scrolls the Slider.
        /// </summary>
        [Category("Behavior"), Description("Event fires when the Slider position is changed.")]
        public event ScrollEventHandler Scroll;

        /// <summary>
        /// Gets the thumb rect. Usefull to determine bounding rectangle when creating custom thumb shape.
        /// </summary>
        /// <value>The thumb rect.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Rectangle ThumbRect { get; set; }

        private int thumbSize = 20;
        /// <summary>
        /// Gets or sets the size of the thumb.
        /// </summary>
        /// <value>The size of the thumb.</value>
        [DefaultValue(20)]
        [Category("Slider"), Description("Set Slider thumb size.")]
        public int ThumbSize
        {
            get => thumbSize;
            set
            {
                if (value > 0 & value < (orientation == Orientation.Horizontal
                    ? ClientRectangle.Width : ClientRectangle.Height))
                    thumbSize = value;
                else
                {
                    throw new ArgumentOutOfRangeException(
                        "TrackSize has to be greather than zero and lower than half of Slider width.");
                }
                Invalidate();
            }
        }

        private Orientation orientation = Orientation.Horizontal;
        /// <summary>
        /// Gets or sets the orientation of Slider.
        /// </summary>
        /// <value>The orientation.</value>
        [DefaultValue(Orientation.Horizontal)]
        [Category("Slider"), Description("Set Slider orientation.")]
        public Orientation Orientation
        {
            get => orientation;
            set
            {
                if (orientation != value)
                {
                    orientation = value;
                    (Height, Width) = (Width, Height);
                    Invalidate();
                }
            }
        }

        private int trackerValue = 50;
        /// <summary>
        /// Gets or sets the value of Slider.
        /// </summary>
        /// <value>The value.</value>
        [DefaultValue(50)]
        [Category("Slider"), Description("Set Slider value.")]
        public int Value
        {
            get => trackerValue;
            set
            {
                if (value >= minimum && value <= barMaximum)
                {
                    trackerValue = value;
                    ValueChanged?.Invoke(this, new EventArgs());
                    Invalidate();
                }
                else throw new ArgumentOutOfRangeException("Value is outside appropriate range (min, max).");
            }
        }

        private int minimum = 0;
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        [DefaultValue(0)]
        [Category("Slider"), Description("Set Slider minimal point.")]
        public int Minimum
        {
            get => minimum;
            set
            {
                if (value < barMaximum)
                {
                    minimum = value;
                    if (trackerValue < minimum)
                    {
                        trackerValue = minimum;
                        ValueChanged?.Invoke(this, new EventArgs());
                    }
                    Invalidate();
                }
                else throw new ArgumentOutOfRangeException("Minimal value is greather than maximal one.");
            }
        }

        private int barMaximum = 100;
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        [DefaultValue(100)]
        [Category("Slider"), Description("Set Slider maximal point.")]
        public int Maximum
        {
            get => barMaximum;
            set
            {
                if (value > minimum)
                {
                    barMaximum = value;
                    if (trackerValue > barMaximum)
                    {
                        trackerValue = barMaximum;
                        ValueChanged?.Invoke(this, new EventArgs());
                    }
                    Invalidate();
                }
                else throw new ArgumentOutOfRangeException("Maximal value is lower than minimal one.");
            }
        }

        /// <summary>
        /// Gets or sets trackbar's small change. It affects how to behave when directional keys are pressed.
        /// </summary>
        /// <value>The small change value.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Slider"), Description("Set trackbar's small change.")]
        public uint SmallChange { get; set; } = 1;

        /// <summary>
        /// Gets or sets trackbar's large change. It affects how to behave when PageUp/PageDown keys are pressed.
        /// </summary>
        /// <value>The large change value.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Slider"), Description("Set trackbar's large change.")]
        public uint LargeChange { get; set; } = 5;

        /// <summary>
        /// Gets or sets a value indicating whether to draw focus rectangle.
        /// </summary>
        /// <value>true if focus rectangle should be drawn.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Slider"), Description("Set whether to draw focus rectangle.")]
        public bool DrawFocusRectangle { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether to draw semitransparent thumb.
        /// </summary>
        /// <value>true if semitransparent thumb should be drawn.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Slider"), Description("Set whether to draw semitransparent thumb.")]
        public bool DrawSemiTransparentThumb { get; set; } = true;

        /// <summary>
        /// Gets or sets whether mouse entry and exit actions have impact on how control look.
        /// </summary>
        /// <value>true if mouse entry and exit actions have impact on how control look.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Slider"), Description("Set whether mouse entry and exit actions have impact.")]
        public bool MouseEffects { get; set; } = true;

        private int mouseWheelBarPartitions = 10;
        /// <summary>
        /// Gets or sets the mouse wheel bar partitions.
        /// </summary>
        /// <value>The mouse wheel bar partitions.</value>
        [DefaultValue(10)]
        [Category("Slider"), Description("Set to how many parts is bar divided when using mouse wheel.")]
        public int MouseWheelBarPartitions
        {
            get => mouseWheelBarPartitions;
            set
            {
                if (value > 0)
                    mouseWheelBarPartitions = value;
                else
                    throw new ArgumentOutOfRangeException("MouseWheelBarPartitions has to be greather than zero.");
            }
        }

        /// <summary>
        /// Gets or sets the thumb outer color.
        /// </summary>
        /// <value>The thumb outer color.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Slider"), Description("Set Slider thumb outer color.")]
        public Color ThumbOuterColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets the inner color of the thumb.
        /// </summary>
        /// <value>The inner color of the thumb.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Slider"), Description("Set Slider thumb inner color.")]
        public Color ThumbInnerColor { get; set; } = Color.Gainsboro;

        /// <summary>
        /// Gets or sets the color of the thumb pen.
        /// </summary>
        /// <value>The color of the thumb pen.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Slider"), Description("Set Slider thumb pen color.")]
        public Color ThumbPenColor { get; set; } = Color.Silver;

        /// <summary>
        /// Gets or sets the outer color of the bar.
        /// </summary>
        /// <value>The outer color of the bar.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Slider"), Description("Set Slider bar outer color.")]
        public Color BarOuterColor { get; set; } = Color.SkyBlue;

        /// <summary>
        /// Gets or sets the inner color of the bar.
        /// </summary>
        /// <value>The inner color of the bar.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Slider"), Description("Set Slider bar inner color.")]
        public Color BarInnerColor { get; set; } = Color.DarkSlateBlue;

        /// <summary>
        /// Gets or sets the color of the bar pen.
        /// </summary>
        /// <value>The color of the bar pen.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Slider"), Description("Set Slider bar pen color.")]
        public Color BarPenColor { get; set; } = Color.Gainsboro;

        /// <summary>
        /// Gets or sets the outer color of the elapsed.
        /// </summary>
        /// <value>The outer color of the elapsed.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Slider"), Description("Set Slider's elapsed part outer color.")]
        public Color ElapsedOuterColor { get; set; } = Color.DarkGreen;

        /// <summary>
        /// Gets or sets the inner color of the elapsed.
        /// </summary>
        /// <value>The inner color of the elapsed.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Slider"), Description("Set Slider's elapsed part inner color.")]
        public Color ElapsedInnerColor { get; set; } = Color.Chartreuse;

        /// <summary>
        /// Initialize a new <see cref="Slider"/> object.
        /// </summary>
        public Slider() : this(0, 100, 50) { }

        /// <summary>
        /// Initialize a new <see cref="Slider"/> object.
        /// </summary>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="value">The current value.</param>
        public Slider(int min, int max, int value) : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw | ControlStyles.Selectable |
                ControlStyles.SupportsTransparentBackColor | ControlStyles.UserMouse |
                ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Opaque, false);

            Animations.Enable();

            Minimum = min;
            Maximum = max;
            Value = value;

            Size = new Size(180, 18);
            ThumbSize = 20;

            BackColor = Color.Transparent;
            BarPenColor = Color.Transparent;
            BarInnerColor = Color.DimGray;
            BarOuterColor = Color.DimGray;
            ElapsedInnerColor = Color.DodgerBlue;
            ElapsedOuterColor = Color.DodgerBlue;
            ThumbInnerColor = Color.Gainsboro;
            ThumbOuterColor = Color.Gainsboro;
            ThumbPenColor = Color.Gainsboro;

            DrawFocusRectangle = false;
            DrawSemiTransparentThumb = false;
            MouseEffects = false;
        }

        /// <summary>
        /// Raises the <see cref="Control.Paint"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="PaintEventArgs"></see> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!Enabled)
            {
                Color[] desaturatedColors = ColorUtils.DesaturateColors(ThumbOuterColor,
                    ThumbInnerColor, ThumbPenColor, BarOuterColor, BarInnerColor, BarPenColor,
                    ElapsedOuterColor, ElapsedInnerColor);
                DrawSlider(e, desaturatedColors[0], desaturatedColors[1], desaturatedColors[2],
                    desaturatedColors[3], desaturatedColors[4], desaturatedColors[5], desaturatedColors[6],
                    desaturatedColors[7]);
            }
            else
            {
                if (MouseEffects && MouseInRegion)
                {
                    Color[] lightenedColors = ColorUtils.LightenColors(ThumbOuterColor,
                        ThumbInnerColor, ThumbPenColor, BarOuterColor, BarInnerColor, BarPenColor,
                        ElapsedOuterColor, ElapsedInnerColor);
                    DrawSlider(e, lightenedColors[0], lightenedColors[1], lightenedColors[2], lightenedColors[3],
                        lightenedColors[4], lightenedColors[5], lightenedColors[6], lightenedColors[7]);
                }
                else
                {
                    DrawSlider(e, ThumbOuterColor, ThumbInnerColor, ThumbPenColor,
                        BarOuterColor, BarInnerColor, BarPenColor,
                        ElapsedOuterColor, ElapsedInnerColor);
                }
            }
        }

        /// <summary>
        /// Draws the Slider control using passed colors.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="thumbOuterColor">The thumb outer color.</param>
        /// <param name="thumbInnerColor">The thumb inner color.</param>
        /// <param name="thumbPenColor">The thumb pen color.</param>
        /// <param name="barOuterColor">The bar outer color.</param>
        /// <param name="barInnerColor">The bar inner color.</param>
        /// <param name="barPenColor">The bar pen color.</param>
        /// <param name="elapsedOuterColor">The elapsed outer color.</param>
        /// <param name="elapsedInnerColor">The elapsed inner color.</param>
        private void DrawSlider(PaintEventArgs e, Color thumbOuterColor, Color thumbInnerColor, Color thumbPenColor, 
            Color barOuterColor, Color barInnerColor, Color barPenColor, Color elapsedOuterColor, Color elapsedInnerColor)
        {
            // Set up thumbRect aproprietly
            if (orientation == Orientation.Horizontal)
            {
                int TrackX = (trackerValue - minimum) * (ClientRectangle.Width - thumbSize) / (barMaximum - minimum);
                ThumbRect = new Rectangle(TrackX, 1, thumbSize - 1, ClientRectangle.Height - 3);
            }
            else
            {
                int TrackY = (trackerValue - minimum) * (ClientRectangle.Height - thumbSize) / (barMaximum - minimum);
                ThumbRect = new Rectangle(1, TrackY, ClientRectangle.Width - 3, thumbSize - 1);
            }
            LinearGradientMode gradientOrientation;
            Rectangle barRect = ClientRectangle;
            Rectangle barHalfRect, elapsedRect;

            if (orientation == Orientation.Horizontal)
            {
                barRect.Inflate(-1, -barRect.Height / 3);
                barHalfRect = barRect;
                barHalfRect.Height /= 2;
                gradientOrientation = LinearGradientMode.Vertical;
                elapsedRect = barRect;
                elapsedRect.Width = ThumbRect.Left + thumbSize / 2;
            }
            else
            {
                barRect.Inflate(-barRect.Width / 3, -1);
                barHalfRect = barRect;
                barHalfRect.Width /= 2;
                gradientOrientation = LinearGradientMode.Horizontal;
                elapsedRect = barRect;
                elapsedRect.Height = ClientRectangle.Bottom - ThumbRect.Top;
                elapsedRect.Y = ThumbRect.Bottom;
            }
            // Thumb placement
            GraphicsPath thumbPath = ThumbRect.CreateRoundRectPath(ThumbRect.Size);

            // Draw bar
            using LinearGradientBrush lgbBar = new(barHalfRect, barOuterColor, barInnerColor, gradientOrientation);
            lgbBar.WrapMode = WrapMode.TileFlipXY;
            e.Graphics.FillRectangle(lgbBar, barRect);

            // Draw elapsed bar
            using LinearGradientBrush lgbElapsed = new(barHalfRect, elapsedOuterColor, elapsedInnerColor, gradientOrientation);
            lgbElapsed.WrapMode = WrapMode.TileFlipXY;
            if (Capture && DrawSemiTransparentThumb)
            {
                Region region = new(elapsedRect);
                region.Exclude(thumbPath);
                e.Graphics.FillRegion(lgbElapsed, region);
            }
            else
                e.Graphics.FillRectangle(lgbElapsed, elapsedRect);

            // Draw thumb
            Color newthumbOuterColorPaint = thumbOuterColor, newthumbInnerColorPaint = thumbInnerColor;
            if (Capture && DrawSemiTransparentThumb)
            {
                newthumbOuterColorPaint = Color.FromArgb(175, thumbOuterColor);
                newthumbInnerColorPaint = Color.FromArgb(175, thumbInnerColor);
            }
            using LinearGradientBrush lgbThumb = new(ThumbRect, newthumbOuterColorPaint,
                newthumbInnerColorPaint, gradientOrientation);

            lgbThumb.WrapMode = WrapMode.TileFlipXY;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(lgbThumb, thumbPath);

            // Draw focusing rectangle
            if (Focused & DrawFocusRectangle)
            {
                using Pen p = new(Color.FromArgb(200, barPenColor));
                Rectangle r = ClientRectangle;

                p.DashStyle = DashStyle.Dot;
                r.Width -= 2;
                r.Height--;
                r.X++;

                using GraphicsPath gpBorder = r.CreateRoundRectPath(ThumbRect.Size);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(p, gpBorder);
            }
        }

        /// <summary>
        /// Raises the <see cref="Control.EnabledChanged"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"></see> that contains the event data.</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="Control.MouseEnter"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"></see> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseInRegion = true;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="Control.MouseLeave"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"></see> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseInRegion = false;
            MouseInThumbRegion = false;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="Control.MouseDown"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="MouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                Capture = true;
                Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.ThumbTrack, trackerValue));
                ValueChanged?.Invoke(this, new EventArgs());
                OnMouseMove(e);
            }
        }

        /// <summary>
        /// Raises the <see cref="Control.MouseMove"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="MouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            MouseInThumbRegion = e.Location.ContainsRect(ThumbRect);
            if (Capture & e.Button == MouseButtons.Left)
            {
                ScrollEventType set = ScrollEventType.ThumbPosition;
                Point pt = e.Location;

                int p = orientation == Orientation.Horizontal ? pt.X : pt.Y;
                int margin = thumbSize >> 1;
                p -= margin;
                float coef = (barMaximum - minimum) /
                    (float)((orientation == Orientation.Horizontal
                    ? ClientSize.Width : ClientSize.Height) - 2 * margin);

                trackerValue = (int)(p * coef + minimum);
                if (trackerValue <= minimum)
                {
                    trackerValue = minimum;
                    set = ScrollEventType.First;
                }
                else if (trackerValue >= barMaximum)
                {
                    trackerValue = barMaximum;
                    set = ScrollEventType.Last;
                }

                Scroll?.Invoke(this, new ScrollEventArgs(set, trackerValue));
                ValueChanged?.Invoke(this, new EventArgs());
            }
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="Control.MouseUp"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="MouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Capture = false;
            MouseInThumbRegion = e.Location.ContainsRect(ThumbRect);
            Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.EndScroll, trackerValue));
            ValueChanged?.Invoke(this, new EventArgs());
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="Control.MouseWheel"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="MouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            int v = e.Delta / 120 * (barMaximum - minimum) / mouseWheelBarPartitions;
            SetProperValue(Value + v);
        }

        /// <summary>
        /// Raises the <see cref="Control.GotFocus"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"></see> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="Control.LostFocus"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"></see> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="Control.KeyUp"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="KeyEventArgs"></see> that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Left:
                    SetProperValue(Value - (int)SmallChange);
                    Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.SmallDecrement, Value));
                    break;
                case Keys.Up:
                case Keys.Right:
                    SetProperValue(Value + (int)SmallChange);
                    Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.SmallIncrement, Value));
                    break;
                case Keys.Home:
                    Value = minimum;
                    break;
                case Keys.End:
                    Value = barMaximum;
                    break;
                case Keys.PageDown:
                    SetProperValue(Value - (int)LargeChange);
                    Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.LargeDecrement, Value));
                    break;
                case Keys.PageUp:
                    SetProperValue(Value + (int)LargeChange);
                    Scroll?.Invoke(this, new ScrollEventArgs(ScrollEventType.LargeIncrement, Value));
                    break;
            }
            if (Scroll != null && Value == minimum)
                Scroll(this, new ScrollEventArgs(ScrollEventType.First, Value));
            if (Scroll != null && Value == barMaximum)
                Scroll(this, new ScrollEventArgs(ScrollEventType.Last, Value));

            Point pt = PointToClient(Cursor.Position);
            OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, pt.X, pt.Y, 0));
        }

        /// <summary>
        /// Processes a dialog key.
        /// </summary>
        /// <param name="keyData">One of the <see cref="Keys"></see> 
        /// values that represents the key to process.</param>
        /// <returns>
        /// true if the key was processed by the control.
        /// </returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Tab | ModifierKeys == Keys.Shift)
                return base.ProcessDialogKey(keyData);
            else
            {
                OnKeyDown(new KeyEventArgs(keyData));
                return true;
            }
        }

        /// <summary>
        /// Sets the trackbar value so that it wont exceed allowed range.
        /// </summary>
        /// <param name="val">The value.</param>
        private void SetProperValue(int val)
        {
            if (val < minimum)
                Value = minimum;
            else if (val > barMaximum)
                Value = barMaximum;
            else
                Value = val;
        }
    }
}
