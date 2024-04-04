using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.VerticalItemListManagement
{
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


        private StringFormat _stringFormat;
        private ContentAlignment _textAlign = ContentAlignment.MiddleCenter;
        private bool _visible = true;

        public Point Offsets;//0, 0 by default
        public String Text = "";
        public Font Font =          new Font("Verdana", 9f);
        public Color UpColor =      Color.FromArgb(172, 172, 172);
        public Color OverColor =    Color.FromArgb(65, 105, 225);
        public Color DownColor =    Color.FromArgb(69, 109, 227);

        public SItemText()
        {
            TextAlign = ContentAlignment.MiddleCenter;
        }

        public void SetColors(Color upColor, Color overColor, Color downColor)
        {
            this.UpColor = upColor;
            this.OverColor = overColor;
            this.DownColor = downColor;
        }

        public void SetColors(Color upColor, Color downColor)
        {
            this.UpColor = upColor;
            this.DownColor = downColor;
        }

    }
}
