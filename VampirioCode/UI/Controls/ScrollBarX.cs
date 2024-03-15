using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.Controls.ScrollBarMan;

namespace VampirioCode.UI.Controls
{
    public class ScrollBarX : Control
    {

#region VisualProperties
        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Button Size")]
        [Browsable(true)]
        public int ButtonSize { get; set; } = 20;

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Orientation")]
        [Browsable(true)]
        public ScrollBarOrientation Orientation { get; set; } = ScrollBarOrientation.Vertical;

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Arrow Color")]
        [Browsable(true)]
        public Color ArrowColor { get; set; } = CColor(200);

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Thumb Normal Color")]
        [Browsable(true)]
        public Color ThumbNormalColor { get { return thumbColors.NormalColor; } set { thumbColors.NormalColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Thumb Over Color")]
        [Browsable(true)]
        public Color ThumbOverColor { get { return thumbColors.OverColor; } set { thumbColors.OverColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Thumb Down Color")]
        [Browsable(true)]
        public Color ThumbDownColor { get { return thumbColors.DownColor; } set { thumbColors.DownColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Button Normal Color")]
        [Browsable(true)]
        public Color ButtonNormalColor { get { return buttonColors.NormalColor; } set { buttonColors.NormalColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Button Over Color")]
        [Browsable(true)]
        public Color ButtonOverColor { get { return buttonColors.OverColor; } set { buttonColors.OverColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Button Down Color")]
        [Browsable(true)]
        public Color ButtonDownColor { get { return buttonColors.DownColor; } set { buttonColors.DownColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Track Normal Color")]
        [Browsable(true)]
        public Color TrackNormalColor { get { return trackColors.NormalColor; } set { trackColors.NormalColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Track Over Color")]
        [Browsable(true)]
        public Color TrackOverColor { get { return trackColors.OverColor; } set { trackColors.OverColor = value; } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Track Down Color")]
        [Browsable(true)]
        public Color TrackDownColor { get { return trackColors.DownColor; } set { trackColors.DownColor = value; } }


        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Border Color")]
        [Browsable(true)]
        public Color BackgroundColor { get; set; } = CColor(70);

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Border Color")]
        [Browsable(true)]
        public Color BorderColor { get; set; } = Color.Black;

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Border Color")]
        [Browsable(true)]
        public Color BorderColorDisabled { get; set; } = Color.Gray;

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Borders Visible")]
        [Browsable(true)]
        public bool BordersVisible { get; set; } = false;
#endregion


        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Minimum")]
        [Browsable(true)]
        public int Minimum { get { return minimum; } set { minimum = value; RefreshAll(); } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Maximum")]
        [Browsable(true)]
        public int Maximum { get { return maximum; } set { maximum = value; RefreshAll(); } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Small Change")]
        [Browsable(true)]
        public int SmallChange { get { return smallChange; } set { smallChange = value; RefreshAll(); } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Large Change")]
        [Browsable(true)]
        public int LargeChange { get { return largeChange; } set { largeChange = value; RefreshAll(); } }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Value")]
        [Browsable(true)]
        public int Value { get { return _value; } set { int val = value; if (val < minimum) val = minimum; else if (val > (maximum - largeChange + 1)) val = (maximum - largeChange + 1); if(val == _value) return; SetValue((float)val); Invalidate(); } }

        [Localizable(true)]
        [Category("Extra Events")]
        [Description("Scroll Event")]
        [Browsable(true)]
        public event ScrollEvent Scroll;

        //
        // Real maximum value the the user can reach with the thumb
        //
        // E.g: Minimum = 0     SmallChange = 5             Minimum = 20     SmallChange = 5
        //      Maximum = 100   LargeChange = 10            Maximum = 100   LargeChange = 10
        //
        //      Result = 100 - 10 + 1 =   [91]              Result = 100 - 10 + 1 =   [71]
        private int MaximumValue { get { return maximum - largeChange + 1; }  }

        //
        // This range represents the maximum value the the user can reach with the thumb
        // but substracting also the 'minimum'
        //
        // E.g: Minimum = 0     SmallChange = 5             Minimum = 20     SmallChange = 5
        //      Maximum = 100   LargeChange = 10            Maximum = 100   LargeChange = 10
        //
        //      Result = (100 - 0) - 10 + 1 =   [91]        Result = (100 - 20) - 10 + 1 =   [71]
        private int MaxRangeValue { get { return MaximumValue - minimum; } }

        private ColorState buttonColors = new ColorState(CColor(70), CColor(140), CColor(100));
        private ColorState trackColors = new ColorState(CColor(50), CColor(60), CColor(70));
        private ColorState thumbColors = new ColorState(CColor(130), CColor(120), CColor(100));
        private Bitmap arrowUp, arrowDown, arrowLeft, arrowRight;

        private ScrollBarElement upButton;
        private ScrollBarElement downButton;
        private ScrollBarElement thumb;
        private ScrollBarElement track;

        private ScrollBarElement leftButton;    // used as reference only for easy use. Do not include in element array!!!
        private ScrollBarElement rightButton;   // used as reference only for easy use. Do not include in element array!!!
        private ScrollBarElement buttonA;       // used as reference only for easy use. Do not include in element array!!!
        private ScrollBarElement buttonB;       // used as reference only for easy use. Do not include in element array!!!

        private ScrollBarElement[] elements;
        private int minimum =       0;
        private int maximum =       100;
        private int smallChange =   1;
        private int largeChange =   10;
        private int _value =        0;

        private bool _dragging = false; // 'true' if 'thumb' is being dragged
        private int _dragPos = 0;       // The mouse start position stored at the beginning of the 'StartDrag' event
        private int _thumbStartPos = 0; // The 'x' or 'y' position of the thumb stored at the beginning of the 'StartDrag' event

        private float floatPos = 0.0f;  // This variable helps with pixel errors by storing a position with floating precision

        private const int MinThumbSize = 10; // Minimum width or height the thumb can get

        public ScrollBarX()
        {
            DoubleBuffered = true;

            CreateArrows();

            upButton =      new ScrollBarElement(buttonColors);
            downButton =    new ScrollBarElement(buttonColors);
            thumb =         new ScrollBarElement(thumbColors);
            track =         new ScrollBarElement(trackColors);

            elements = new ScrollBarElement[] { upButton, downButton, thumb, track};

            // used as reference only for easy use. Do not include in element array!!!
            leftButton =    upButton;
            rightButton =   downButton;
            buttonA =       upButton;
            buttonB =       downButton;
        }

        private void CreateArrows()
        {
            arrowUp = ScrollBarUtils.CreateUpArrow(11, 6, ArrowColor);

            Bitmap arrow = (Bitmap)arrowUp.Clone();

            arrow.RotateFlip(RotateFlipType.Rotate180FlipNone);
            arrowDown = new Bitmap(arrow);

            arrow.RotateFlip(RotateFlipType.Rotate90FlipNone);
            arrowLeft = new Bitmap(arrow);

            arrow.RotateFlip(RotateFlipType.Rotate180FlipNone);
            arrowRight = new Bitmap(arrow);

        }

        private static Color CColor(int red, int green, int blue)
        { 
            return Color.FromArgb(red, green, blue);
        }

        private static Color CColor(int color)
        {
            return Color.FromArgb(color, color, color);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_dragging)
            {
                OnDragging(Orientation == ScrollBarOrientation.Horizontal ? e.X : e.Y);
                Invalidate();
                return;
            }

            if (IsAnySelected())
                return;

            foreach (var elem in elements)
            {
                elem.MouseMove(e.X, e.Y, e.Button == MouseButtons.Left);
            }
            
            //XConsole.PrintWarning("OnMouseMove");
            Invalidate();
            base.OnMouseMove(e);
        }
        
        protected override void OnMouseLeave(EventArgs e)
        {
            if (IsAnySelected())
                return;

            foreach (var elem in elements)
            {
                elem.MouseLeave();
            }
            
            //XConsole.PrintWarning("OnMouseLeave");
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (IsAnySelected())
                return;

            foreach (var elem in elements)
            {
                elem.MouseDown(e.X, e.Y, e.Button == MouseButtons.Left);

                if (elem.Selected)
                {
                    if (elem == thumb)
                        StartDrag(Orientation == ScrollBarOrientation.Horizontal ? e.X : e.Y);
                    else if (elem == buttonA)
                        OnButtonDown(ScrollBarButton.ButtonA);
                    else if (elem == buttonB)
                        OnButtonDown(ScrollBarButton.ButtonB);
                    else if (elem == track)
                        OnTrackDown(Orientation == ScrollBarOrientation.Horizontal ? e.X : e.Y);

                    break;
                }
            }
            
            //XConsole.PrintWarning("OnMouseDown");
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_dragging)
                StopDrag(Orientation == ScrollBarOrientation.Horizontal ? e.X : e.Y);

            //if (IsAnySelected())
            //{
                foreach (var elem in elements)
                {
                    if(elem.Selected)
                    { 
                        if (elem == buttonA)
                            OnButtonUp(ScrollBarButton.ButtonA);
                        else if (elem == buttonB)
                            OnButtonUp(ScrollBarButton.ButtonB);

                        elem.ResetSelection();
                    }
                }
            //} 

            foreach (var elem in elements)
            {
                elem.MouseUp(e.X, e.Y);
            }

            //XConsole.PrintWarning("OnMouseUp");
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            RefreshAll();
        }

        private void SmallDecrement()
        {
            SetValue(_value - smallChange);
            Invalidate();
        }

        private void SmallIncrement()
        {
            SetValue(_value + smallChange);
            Invalidate();
        }

        private void OnButtonDown(ScrollBarButton button)
        {
            XConsole.PrintWarning("Button Down: " + button);

            if (button == ScrollBarButton.ButtonA)
                SmallDecrement();
            else if(button == ScrollBarButton.ButtonB)
                SmallIncrement();
        }

        private void OnButtonUp(ScrollBarButton button)
        {
            XConsole.PrintError("Button Up: " + button);
        }

        private void OnTrackDown(int pos)
        {
            if (Orientation == ScrollBarOrientation.Vertical)
            {

            }
            else if (Orientation == ScrollBarOrientation.Horizontal)
            { 
            
            }
        }

        private void OnTrackDown(TrackSide trackSide)
        {
            XConsole.PrintWarning("Track Down: " + trackSide);
        }

        private void OnTrackUp(TrackSide trackSide)
        {
            XConsole.PrintError("Track Up: " + trackSide);
        }

        // Internal event that occurs when thumb is being
        // dragged by the user
        private void OnDragging(int pos)
        {

            if (Orientation == ScrollBarOrientation.Horizontal)
            {
                // Calculate new thumb position
                thumb.x = _thumbStartPos + (pos - _dragPos);

                // Clamp values if outside bounds
                if (thumb.x < leftButton.width)
                {
                    thumb.x = leftButton.width;
                }
                else if (thumb.right > rightButton.x)
                { 
                    thumb.right = rightButton.x;
                }


                int freeTrack =     track.width - thumb.width; // The free space that is not used by the 'thumb'
                int maxRangeVal =   MaxRangeValue;
                int currPos =       thumb.x - leftButton.width;

                //int newVal = (int)(((float)maxValue / freeTrack) * currPos);

                floatPos = ((float)maxRangeVal / freeTrack) * currPos;
                floatPos += minimum;
                int newVal = (int)floatPos;

                if (newVal < 0)
                {
                    XConsole.PrintError("warn: " + newVal);
                    floatPos =  minimum;
                    newVal =    minimum;
                }

                SetValueOnly(newVal);

                XConsole.Println("f: " + floatPos + " newVal: " + newVal);
                //XConsole.Println("currPos: " + currPos + " newVal: " + newVal + " freeTrack: " + freeTrack + " maxValue: " + maxValue);
            }

        }

        // Start drag for the thumb
        private void StartDrag(int pos)
        {
            if (Orientation == ScrollBarOrientation.Horizontal)
            {
                _thumbStartPos = thumb.x;
                _dragPos = pos;
                _dragging = true;
                //OnDragging(pos);
            }
        }

        // Stop drag for the thumb
        private void StopDrag(int pos)
        {
            if (Orientation == ScrollBarOrientation.Horizontal)
            {
                _dragPos = pos;
                _dragging = false;
                //SetValue(_value);
            }
        }

        // Check if any element like 'buttons', 'track' or 'thumb'
        // is being pressed by the user
        private bool IsAnySelected()
        {
            foreach (var elem in elements)
            {
                if (elem.Selected)
                    return true;
            }

            return false;
        }

        private void SetValue(float newValue)
        {
            // 'SetValue()' can be called from outside and not only from inside this class so we update
            // 'floatPos' for external calls. For internal calls it makes no difference, just value is re-assigned
            floatPos = newValue;

            // minimum must be substracted from the input because on other parts of the code it is added
            newValue -= minimum;

            XConsole.Println("new floatPos:" + floatPos);

            if (Orientation == ScrollBarOrientation.Vertical)
            {
                int freeTrack =     track.height - thumb.height;
                int maxRangeVal =   MaxRangeValue;
                int currPos =       (int)(newValue / (((float)maxRangeVal / freeTrack)));

                thumb.x = 0;
                thumb.y = currPos + upButton.height;
            }
            else if (Orientation == ScrollBarOrientation.Horizontal)
            {
                int freeTrack =     track.width - thumb.width;
                int maxRangeVal =   MaxRangeValue;
                int currPos =       (int)((float)newValue / (((float)maxRangeVal / freeTrack)));

                thumb.x = currPos + leftButton.width;
                thumb.y = 0;

                if (thumb.width > track.width)
                {
                    XConsole.PrintError("ENTER MAJORs");
                    thumb.width =   track.width;
                    thumb.x =       leftButton.right;
                    //floatPos = minimum;
                    //SetValueOnly((int)floatPos);
                }
                else if (thumb.x < leftButton.right)
                {
                    XConsole.PrintError("MIN: " + minimum);

                    thumb.x =   leftButton.right;
                    floatPos =  minimum;
                    //_value =    minimum;
                    SetValueOnly((int)floatPos);
                }
                else if (thumb.right > rightButton.x)
                {
                    //XConsole.Println("MaximumValue: " + MaximumValue + " Large: " + LargeChange);
                    //XConsole.Println("thumb.width: " + thumb.width + " freeTrack: " + freeTrack);
                    //if(MaximumValue < )
                    XConsole.PrintError("Max: " + MaximumValue);


                    thumb.right = rightButton.x;
                    floatPos = MaximumValue;
                    SetValueOnly((int)floatPos);
                }
                else
                {
                    XConsole.PrintWarning("None -> floatPos: " + floatPos);
                    SetValueOnly((int)floatPos);
                }

            }
        }

        // Used only internally for updating the 'value' and also for triggering
        // 'Scroll' events if the new value is different from the value before
        private void SetValueOnly(int newValue)
        {
            int oldValue = _value;
            _value = newValue;

            if ((Scroll != null) && (oldValue != _value))
                Scroll(oldValue, newValue);
        }

        // Calculate the thumb width or height depending on the 'Orientation'
        // The 'largeChange' represents the visible part (viewport) of what the
        // user wants to show. At the same time it will represents after the
        // projection inside the 'track', the thumb size.
        private int CalcThumbSize()
        {
            int thumbSize = 0;

            if (Orientation == ScrollBarOrientation.Vertical)
            {
                thumbSize =(int)((largeChange / (float)(maximum - minimum + 1)) * track.height);

                if (thumbSize > track.height)
                    thumbSize = track.height;
            }
            else  if (Orientation == ScrollBarOrientation.Horizontal)
            {
                thumbSize = (int)((largeChange / (float)(maximum - minimum + 1)) * track.width);

                if (thumbSize > track.width)
                    thumbSize = track.width;
            }

            // Clamp the thumb size to a minimum because it
            // can't be smaller to what the user can drag
            if (thumbSize < MinThumbSize)
                thumbSize = MinThumbSize;

            return thumbSize;
        }


        // Set basics layout for buttons and for the track.
        private void RefreshButtonsAndTrack()
        {
            if (Orientation == ScrollBarOrientation.Vertical)
            {

                upButton.SetSize(Width, ButtonSize);
                downButton.SetSize(Width, ButtonSize);

                upButton.SetPos(0, 0);
                downButton.SetPos(0, Height - downButton.height);


                track.SetPos(0, upButton.height);
                track.SetSize(Width, Height - (upButton.height + downButton.height));

            }
            else if (Orientation == ScrollBarOrientation.Horizontal)
            {

                leftButton.SetSize(ButtonSize, Height);
                rightButton.SetSize(ButtonSize, Height);

                leftButton.SetPos(0, 0);
                rightButton.SetPos(Width - rightButton.width, 0);


                track.SetPos(leftButton.width, 0);
                track.SetSize(Width - (leftButton.width + rightButton.width), Height);

            }
        }

        // Calculate actual thumb size and set it
        private void RefreshThumbSize()
        {
            if (Orientation == ScrollBarOrientation.Vertical)
            {
                thumb.width = Width;
                thumb.height = CalcThumbSize();
            }
            else if (Orientation == ScrollBarOrientation.Horizontal)
            {
                thumb.height = Height;
                thumb.width = CalcThumbSize();
            }
        }

        // Refresh buttons and tracks sizes and positions
        // Refresh thumb size
        // Refresh thumb position using SetValue() with the previous used 'float position'
        // in order to conserve pixel's position errors
        public void RefreshAll()
        {
            RefreshButtonsAndTrack();
            RefreshThumbSize();
            SetValue(floatPos);

            Invalidate();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.FillRectangle(Brushes.White, 0, 0, Width, Height);

            foreach (var elem in elements)
            {
                if(elem != thumb)
                    elem.Paint(g);
            }

            thumb.Paint(g);

            if (Orientation == ScrollBarOrientation.Vertical)
            {
                upButton.PaintCenteredImage(g, arrowUp);
                downButton.PaintCenteredImage(g, arrowDown);
            }
            else if (Orientation == ScrollBarOrientation.Horizontal)
            {
                upButton.PaintCenteredImage(g, arrowLeft);
                downButton.PaintCenteredImage(g, arrowRight);
            }
            
        }


    }
}
