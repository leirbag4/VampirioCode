using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.ScrollBarAdvance
{
    public class ScrollBarElement
    {
        public bool Selected { get { return selected; } }
        public bool IsOver { get { return state == ElementState.Over; } }
        public bool ExtraState { get; set; } = false;

        public int right { get { return (x + width); } set { x = value - width; } }
        public int bottom { get { return (y + height); } set { y = value - height; } }

        public int x = 0;
        public int y = 0;
        public int width = 10;
        public int height = 10;

        public ElementState state =     ElementState.Normal;
        public bool allowDragging =     false;
        public int paddingX =           0;
        public int paddingY =           0;

        private ColorState colorState;
        private bool selected = false;

        public ScrollBarElement(ColorState colorState)
        { 
            this.colorState = colorState;
        }

        public void SetPos(int x, int y)
        { 
            this.x = x;
            this.y = y;
        }

        public void SetSize(int width, int height)
        {
            this.width  = width;
            this.height = height;
        }

        public void ResetSelection()
        {
            selected = false;
        }

        public void MouseMove(int mx, int my, bool click)
        {
            bool isInside = IsInside(mx, my);

            if (isInside && click)
                state = ElementState.Down;
            else if (isInside)
                state = ElementState.Over;
            else
                state = ElementState.Normal;
        }

        public void MouseLeave()
        {
            state = ElementState.Normal;
        }

        public void MouseDown(int mx, int my, bool click)
        {
            bool isInside = IsInside(mx, my);

            if (isInside && click)
            {
                state = ElementState.Down;
                selected = true;
            }
            else if (isInside)
                state = ElementState.Over;
            else
                state = ElementState.Normal;
        }

        public void MouseUp(int mx, int my)
        {
            bool isInside = IsInside(mx, my);

            if(isInside)
                state = ElementState.Over;
            else
                state = ElementState.Normal;
        }

        public bool IsInside(int mx, int my)
        {
            return (mx >= x) && (mx < (x + width)) && (my >= y) && (my <= (y + height));
        }

        public void PaintCenteredImage(Graphics g, Bitmap img)
        { 
            g.DrawImage(img, x + (width >> 1) - (img.Width >> 1), y + (height >> 1) - (img.Height >> 1), img.Width, img.Height);
        }

        public void Paint(Graphics g)
        {
            SolidBrush brush = null;

            if ((x < 0) || (y < 0))
                return;

                 if (state == ElementState.Normal)  brush = new SolidBrush(colorState.NormalColor);
            else if (state == ElementState.Over)    brush = new SolidBrush(colorState.OverColor);
            else if (state == ElementState.Down)    brush = new SolidBrush(colorState.DownColor);

            if (ExtraState)
                brush = new SolidBrush(colorState.ExtraColor);

            g.FillRectangle(brush, x + paddingX, y + paddingY, width - (paddingX << 1), height - (paddingY << 1));
        }

        public override string ToString()
        {
            return "x: " + x + ", y: " + y + ", width: " + width + ", height: " + height + ", state: " + state;
        }

    }
}
