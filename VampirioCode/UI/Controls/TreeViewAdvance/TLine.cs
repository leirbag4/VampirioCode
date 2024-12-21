using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TreeViewAdvance
{
    public class TLine
    {
        public int X =  0;
        public int Y =  0;
        public int X2 = 0;
        public int Y2 = 0;

        public TLine()
        { }

        public TLine(int x, int y) 
        { 
            X = x; 
            Y = y; 
        }

        public TLine(int x, int y, int x2, int y2)
        {
            X = x;
            Y = y;
            X2 = x2;
            Y2 = y2;
        }

        public void Paint(Graphics g, Pen penColor)
        {
            TGraphics.DrawLine(g, penColor, X, Y, X2, Y2);
        }

        public override string ToString()
        {
            return "x: " + X + ", Y: " + Y + ", X2: " + X2 + ", Y2: " + Y2;
        }
    }
}
