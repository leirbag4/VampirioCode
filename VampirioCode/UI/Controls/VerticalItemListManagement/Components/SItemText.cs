using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.VerticalItemListManagement.Components
{
    public enum SItemTextStateMode
    { 
        InheritFromParent,
        OwnBehaviour
    }

    public class SItemText
    {
        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Text Align")]
        [Browsable(true)]
        public ContentAlignment TextAlign
        {
            set
            {
                _textAlign = value;
                _stringFormat = new StringFormat();

                Int32 lNum = (Int32)Math.Log((Double)_textAlign, 2);
                _stringFormat.LineAlignment = (StringAlignment)(lNum / 4);
                _stringFormat.Alignment = (StringAlignment)(lNum % 4);
            }
            get { return _textAlign; }
        }

        public StringFormat StringFormat
        {
            get { return _stringFormat; }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        // add '...' at the beginning if thext is too long
        public bool Truncated
        {
            get { return _truncatedText; }
            set { _truncatedText = value; /*if (value) { _stringFormat.FormatFlags |= StringFormatFlags.NoWrap;  }*/ }
        }

        public string Text { get { return _text; } 
            set 
            {
                bool changed = false;

                if(_text != _oldText)
                    changed = true;

                _text = value;

                if (changed && (ValueChanged != null))
                    ValueChanged(this, _text);
            } }

        public RectangleF rect;


        public SItemTextStateMode StateMode { get; set; } = SItemTextStateMode.InheritFromParent;

        private string _text = "";
        private string _oldText = "";
        private StringFormat _stringFormat;
        private ContentAlignment _textAlign = ContentAlignment.MiddleCenter;
        private bool _visible = true;

        // Truncate Info
        private bool _truncatedText = false;
        private float _prevMaxWidth= 0;
        private string _prevText = "";
        private string _prevTruncatedText = "";

        // Events
        public delegate void DoubleClickEvent(SItemText sender);

        public event DoubleClickEvent DoubleClick;
        public event ValueChangedEvent ValueChanged;


        public Point Offsets;//0, 0 by default
        //public String Text = "";
        public Font Font =          new Font("Verdana", 9f);
        public Color UpColor =      Color.FromArgb(172, 172, 172);
        public Color OverColor =    Color.FromArgb(65, 105, 225);
        public Color DownColor =    Color.FromArgb(69, 109, 227);

        public float LeftPercent    { get { return _leftPercent; } set { _leftPercent = value; _percentMode = true; } }
        public float RightPercent   { get { return _rightPercent; } set { _rightPercent = value; _percentMode = true; } }
        public float TopPercent     { get { return _topPercent; } set { _topPercent = value; _percentMode = true; } }
        public float BottomPercent  { get { return _bottomPercent; } set { _bottomPercent = value; _percentMode = true; } }

        public Color BackUpColor    { get { return _backUpColor;} set { _backUpColor = value; _useBackColor = true; } }
        public Color BackOverColor  { get { return _backOverColor;} set { _backOverColor = value; _useBackColor = true; } }
        public Color BackDownColor  { get { return _backDownColor; } set { _backDownColor = value; _useBackColor = true; } }

        public bool PercentMode { get { return _percentMode; } }
        public bool UseBackColor { get { return _useBackColor; } }

        public bool dragging = false;

        private Color _backUpColor =    Color.Transparent;
        private Color _backOverColor =  Color.Transparent;
        private Color _backDownColor =  Color.Transparent;

        private float _leftPercent =    0.0f;
        private float _rightPercent =   0.0f;
        private float _topPercent =     0.0f;
        private float _bottomPercent =  0.0f;
        private bool _percentMode =     false;
        private bool _useBackColor =    false;

        public SItemText()
        {
            TextAlign = ContentAlignment.MiddleCenter;
        }

        public void CalcPercents(int parentWidth, int parentHeight)
        {
            int leftPos =   (int)(LeftPercent *     parentWidth)  + Offsets.X;
            int rightPos =  (int)(RightPercent *    parentWidth)  + Offsets.X;
            int topPos =    (int)(TopPercent *      parentHeight) + Offsets.Y;
            int bottomPos = (int)(BottomPercent *   parentHeight) + Offsets.Y;

            int newWidth =  parentWidth -  leftPos - rightPos;
            int newHeight = parentHeight - topPos -  bottomPos;

            rect = new RectangleF(leftPos, topPos, newWidth, newHeight);
        }

        public void SetColors(Color upColor, Color overColor, Color downColor)
        {
            this.UpColor =   upColor;
            this.OverColor = overColor;
            this.DownColor = downColor;
        }

        public void SetColors(Color upColor, Color downColor)
        {
            this.UpColor = upColor;
            this.DownColor = downColor;
        }

        public void SetBackColors(Color upColor, Color overColor, Color downColor)
        { 
            this.BackUpColor =   upColor;
            this.BackOverColor = overColor;
            this.BackDownColor = downColor;
           _useBackColor =       true;
        }

        public void SetPercents(float left, float right, float top, float bottom)
        {
            _leftPercent =      left;
            _rightPercent =     right;
            _topPercent =       top;
            _bottomPercent =    bottom;
            _percentMode =      true;
        }

        public string Truncate(Graphics graphics, float maxWidth)
        {
            bool textChanged = Text != _prevText;
            bool widthChanged = maxWidth != _prevMaxWidth;

            _prevText =     Text;
            _prevMaxWidth = maxWidth;

            if (textChanged || widthChanged)
            {

                if (graphics.MeasureString(Text, Font).Width <= maxWidth)
                {
                    _prevTruncatedText = Text;
                    return _prevTruncatedText;
                }

                string ellipsis = "... ";
                float ellipsisWidth = graphics.MeasureString(ellipsis, Font).Width;
                int startIndex = 0;

                while (startIndex < Text.Length)
                {
                    string subText = Text.Substring(startIndex);
                    if (graphics.MeasureString(ellipsis + subText, Font).Width <= maxWidth)
                    {
                        _prevTruncatedText = ellipsis + subText;
                        return _prevTruncatedText;
                    }
                    startIndex++;
                }

                _prevTruncatedText = ellipsis;
                return _prevTruncatedText;
            }
            else
                return _prevTruncatedText;
        }

        public void TriggerDoubleClick()
        {
            if (DoubleClick != null)
                DoubleClick(this);
        }
    }
}
