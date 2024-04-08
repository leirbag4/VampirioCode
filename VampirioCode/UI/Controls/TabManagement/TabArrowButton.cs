using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.VampGraphics;
using static ScintillaNET.NativeMethods;

namespace VampirioCode.UI.Controls.TabManagement
{
    public class TabArrowButton : Button
    {
        enum State
        { 
            Over,
            Up,
            Down
        }

        public enum ArrowDirection
        { 
            Left,
            Right
        }

        class Arrow
        {
            public Bitmap UpBmp;
            public Bitmap DownBmp;
            public Bitmap OverBmp;
        }

        public TabArrowButtonStyle UpStyle      { get{ return upStyle; }    set { upStyle = value;      arrow.UpBmp =   CreateArrow(value.ArrowColor); } }
        public TabArrowButtonStyle OverStyle    { get{ return overStyle; }  set { overStyle = value;    arrow.OverBmp = CreateArrow(value.ArrowColor); } }
        public TabArrowButtonStyle DownStyle    { get{ return downStyle; }  set { downStyle = value;    arrow.DownBmp = CreateArrow(value.ArrowColor); } }

        public int BorderSize { get; set; } = 2;


        private TabArrowButtonStyle upStyle;
        private TabArrowButtonStyle overStyle;
        private TabArrowButtonStyle downStyle;
        private Arrow arrow;
        private State state = State.Up;
        private ArrowDirection arrowDirection;

        private const int arrowWidth =  7;
        private const int arrowHeight = 14;

        public TabArrowButton(ArrowDirection direction)
        {
            this.arrowDirection = direction;
            this.arrow = new Arrow();
            UpStyle =   new TabArrowButtonStyle(CColor(40), CColor(30), CColor(60));
            OverStyle = new TabArrowButtonStyle(CColor(45), CColor(35), CColor(65));
            DownStyle = new TabArrowButtonStyle(CColor(50), CColor(40), CColor(70));
        }

        private Color CColor(int red, int green, int blue)
        {
            return Color.FromArgb(red, green, blue);
        }

        private Color CColor(int rgb)
        {
            return Color.FromArgb(rgb, rgb, rgb);
        }

        private Bitmap CreateArrow(Color color)
        {
            if (arrowDirection == ArrowDirection.Left)
                return TabUtils.CreateLeftArrow(arrowWidth, arrowHeight, color);
            else if (arrowDirection == ArrowDirection.Right)
                return TabUtils.CreateRightArrow(arrowWidth, arrowHeight, color);

            return null;
        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            if (state == State.Down)
                return;
            
            BringToFront();

            state = State.Over;

            base.OnMouseMove(mevent);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            state = State.Down;

            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            state = State.Up;

            base.OnMouseUp(mevent);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (state == State.Down)
                return;

            state = State.Up;

            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            TabArrowButtonStyle style = null;
            Bitmap arrowBmp = null;
            int arrowBmpOffsetX = 0;

            if (state == State.Up)
            {
                style =     upStyle;
                arrowBmp =  arrow.UpBmp;
            }
            else if (state == State.Down)
            { 
                style =     downStyle;
                arrowBmp =  arrow.DownBmp;
            }
            else if (state == State.Over)
            { 
                style =     overStyle;
                arrowBmp =  arrow.OverBmp;
            }

            if (arrowDirection == ArrowDirection.Left)
                arrowBmpOffsetX = -1;

            VampirioGraphics.FillRect(g, style.BackColor, style.BorderColor, BorderSize, 0, 0, Width, Height);
            if (arrowBmp != null)
                VampirioGraphics.DrawImage(g, arrowBmp, (Width >> 1) - (arrowBmp.Width >> 1) + arrowBmpOffsetX, (Height >> 1) - (arrowBmp.Height >> 1));

        }
    }
}
