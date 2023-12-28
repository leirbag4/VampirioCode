using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls
{
    public class GroupBoxAdv : GroupBox
    {

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Custom Visual Style")]
        [Browsable(true)]
        public CustomStyle CStyle
        {
            get { return _customStyle; }
            set { _customStyle = value; Invalidate(); }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Border Color")]
        [Browsable(true)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        [Localizable(true)]
        [Category("Extra Properties")]
        [Description("Border Size")]
        [Browsable(true)]
        public int BorderSize
        {
            get { return _borderSize; }
            set { _borderSize = value; Invalidate(); }
        }

        public enum CustomStyle
        {
            NORMAL,
            SOLID,
            SOLID_NO_BORDERS,
        }

        private CustomStyle _customStyle = CustomStyle.NORMAL;
        private Color _borderColor = Color.DarkGray;
        private int _borderSize = 1;


        protected override void OnPaint(PaintEventArgs e)
        {

            if (_customStyle == CustomStyle.NORMAL)
            {
                base.OnPaint(e);
            }
            else if (_customStyle == CustomStyle.SOLID)
            {
                e.Graphics.FillRectangle(new SolidBrush(_borderColor), ClientRectangle);
                e.Graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(_borderSize, _borderSize, Width - (_borderSize * 2), Height - (_borderSize * 2)));
                //e.Graphics.DrawRectangle(new Pen(new SolidBrush(_borderColor), _borderSize), new Rectangle(_borderSize, _borderSize, Width - _borderSize, Height - _borderSize));
            }
            else if (_customStyle == CustomStyle.SOLID_NO_BORDERS)
            {

                e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

            }

        }

    }
}
