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
        public int Value { get { return _value; } set { int val = value; if (val < minimum) val = minimum; else if (val > (maximum - largeChange + 1)) val = (maximum - largeChange + 1); SetValue((float)val); } }

        [Localizable(true)]
        [Category("Extra Events")]
        [Description("Scroll Event")]
        [Browsable(true)]
        public event ScrollEvent Scroll;

        private int MaximumValue { get { return maximum - minimum - largeChange + 1; }  }

        private ColorState buttonColors = new ColorState(CColor(70), CColor(140), CColor(100));
        private ColorState trackColors = new ColorState(CColor(50), CColor(60), CColor(70));
        private ColorState thumbColors = new ColorState(CColor(130), CColor(120), CColor(100));
        private Bitmap arrowUp, arrowDown, arrowLeft, arrowRight;

        private ScrollBarElement upButton;
        private ScrollBarElement downButton;
        private ScrollBarElement thumb;
        private ScrollBarElement track;

        private ScrollBarElement leftButton;  // used as reference only for easy use. Do not include in element array!!!
        private ScrollBarElement rightButton; // used as reference only for easy use. Do not include in element array!!!

        private ScrollBarElement[] elements;
        private int minimum =       0;
        private int maximum =       100;
        private int smallChange =   1;
        private int largeChange =   10;
        private int _value =        0;

        private bool _dragging = false;
        private int _dragPos = 0;
        private int _startDragPos = 0;
        private int _thumbPrevPos = 0;

        private float floatPos = 0.0f;

        private const int MinThumbSize = 10;

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
            leftButton =  upButton;
            rightButton = downButton;
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

            if (IsAnySelected())
            {
                foreach (var elem in elements)
                    elem.ResetSelection();
            } 

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

        private void OnDragging(int pos)
        {

            if (Orientation == ScrollBarOrientation.Horizontal)
            {

                int val = pos - _dragPos;
                //_dragPos = pos;

                //thumb.x += val;
                thumb.x = _thumbPrevPos + val;

                if (thumb.x < leftButton.width)
                {
                    thumb.x = leftButton.width;
                }
                else if (thumb.right > rightButton.x)
                { 
                    thumb.right = rightButton.x;
                }


                int freeTrack = track.width - thumb.width;
                int maxValue = MaximumValue;
                int currPos = thumb.x - leftButton.width;

                //int newVal = (int)(((float)maxValue / freeTrack) * currPos);

                floatPos = ((float)maxValue / freeTrack) * currPos;
                floatPos += minimum;
                int newVal = (int)floatPos;

                if (newVal < 0)
                {
                    floatPos =  0;
                    newVal =    0;
                }

                SetValueOnly(newVal);

                XConsole.Println("f: " + floatPos + " newVal: " + newVal);
                //XConsole.Println("currPos: " + currPos + " newVal: " + newVal + " freeTrack: " + freeTrack + " maxValue: " + maxValue);
            }

        }

        private void StartDrag(int pos)
        {
            if (Orientation == ScrollBarOrientation.Horizontal)
            {
                _thumbPrevPos = thumb.x;
                _startDragPos = pos;
                _dragPos = pos;
                _dragging = true;
            }
        }

        private void StopDrag(int pos)
        {
            if (Orientation == ScrollBarOrientation.Horizontal)
            {
                _dragPos = pos;
                _dragging = false;
                //SetValue(_value);
            }
        }

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

            if (Orientation == ScrollBarOrientation.Vertical)
            {
                int freeTrack = track.height - thumb.height;
                int maxValue = MaximumValue;
                int currPos = (int)(newValue / (((float)maxValue / freeTrack)));

                thumb.x = 0;
                thumb.y = currPos + upButton.height;
            }
            else if (Orientation == ScrollBarOrientation.Horizontal)
            {
                int freeTrack = track.width - thumb.width;
                int maxValue = MaximumValue;
                int currPos = (int)((float)newValue / (((float)maxValue / freeTrack)));

                thumb.x = currPos + leftButton.width;
                thumb.y = 0;

                if (thumb.right > rightButton.x)
                    thumb.right = rightButton.x;

                if (thumb.x < leftButton.right)
                {
                    thumb.x =   leftButton.right;
                    //floatPos =  minimum;
                    //_value =    minimum;
                    //SetValueOnly(minimum);
                }

            }
        }


        private void SetValueOnly(int newValue)
        {
            int oldValue = _value;
            _value = newValue;

            if ((Scroll != null) && (oldValue != _value))
                Scroll(oldValue, newValue);
        }

        private int CalcThumbSize()
        {
            int thumbSize = 0;

            if (Orientation == ScrollBarOrientation.Vertical)
            {
                thumbSize =(int)((largeChange / (float)(maximum - minimum)) * track.height);
            }
            else  if (Orientation == ScrollBarOrientation.Horizontal)
            {
                thumbSize = (int)((largeChange / (float)(maximum - minimum)) * track.width);
            }

            if (thumbSize < MinThumbSize)
                thumbSize = MinThumbSize;

            return thumbSize;
        }

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

        private void RefreshThumb()
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

        public void RefreshAll()
        {
            RefreshButtonsAndTrack();
            RefreshThumb();
            SetValue(floatPos);//_value);

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
                //XConsole.Println(" -> " + upButton.ToString());
            
        }


    }
}
