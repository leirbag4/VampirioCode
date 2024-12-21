using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TreeViewAdvance
{
    public class TRect
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Left { get { return X; } }
        public int Right { get { return X + Width; } }
        public int Top { get { return Y; } }
        public int Bottom { get { return Y + Height; } }
        public TPoint Center { get { return new TPoint(X + (Width >> 1), Y + (Height >> 1)); } }
        public int CenterX { get { return X + (Width >> 1); } }
        public int CenterY { get { return Y + (Height >> 1); } }

        public TRect(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public void Set(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public Rectangle ToRectangle()
        { 
            return new Rectangle(X, Y, Width, Height);
        }
    }
}
