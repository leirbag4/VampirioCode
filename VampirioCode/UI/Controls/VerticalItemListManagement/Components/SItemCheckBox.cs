using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VampirioCode.UI.Controls.VerticalItemListManagement.Components
{
    public class SItemCheckBox : SItemImage
    {
        public bool Checked
        {
            set { _checked = value; }
            get { return _checked; }
        }

        public override Image Image
        {
            get { if (_checked) return _checkedImg; else return _uncheckedImg; }
        }

        private bool _checked = false;
        private Bitmap _checkedImg;
        private Bitmap _uncheckedImg;
        protected Control _parent;

        public SItemCheckBox(Bitmap checkedImg, Bitmap uncheckedImg, Control parent)
        {
            _checkedImg = checkedImg;
            _uncheckedImg = uncheckedImg;
            _parent = parent;
        }

        public int X
        {
            get
            {
                int _w = Image.Width;
                int _x = 0;

                int lNum = (int)Math.Log((double)ImageAlign, 2);
                float xAlign = lNum % 4;
                xAlign--;
                //FROM -1 to 1


                if (xAlign == -1)
                    _x = 0 + _parent.Margin.Left;
                else if (xAlign == 0)
                    _x = (_parent.Width >> 1) - (_w >> 1);
                else //if(xAlign == 1)
                    _x = _parent.Width - _w - _parent.Margin.Right;

                return _x + Offsets.X;
            }
        }

        public int Y
        {
            get
            {
                int _h = Image.Height;
                int _y = 0;


                int lNum = (int)Math.Log((double)ImageAlign, 2);
                float yAlign = lNum / 4;
                yAlign--;
                //FROM -1 to 1


                if (yAlign == -1)
                    _y = 0 + _parent.Margin.Top;
                else if (yAlign == 0)
                    _y = (_parent.Height >> 1) - (_h >> 1);
                else //if(yAlign == 1)
                    _y = _parent.Height - _h - _parent.Margin.Right;

                return _y + Offsets.Y;
            }
        }

        public bool IsOver(int x, int y)
        {
            int _x = X;
            int _y = Y;
            int _w = Image.Width;
            int _h = Image.Height;

            return x >= _x && x <= _x + _w && y >= _y && y <= _y + _h;
        }
    }
}
