using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.ScrollBarAdvance
{
    public class ScrollBarUtils
    {
        public static Bitmap CreateUpArrow(int arrowWidth, int arrowHeight, Color color)
        {
            Bitmap arrow = new Bitmap(arrowWidth, arrowHeight);
            SolidBrush brush = new SolidBrush(color);

            using (Graphics g = Graphics.FromImage(arrow))
            {
                Point[] bmp =
                {
                    new Point(0, arrowHeight),
                    new Point(arrowWidth / 2, 0),
                    new Point(arrowWidth, arrowHeight)
                };
                g.FillPolygon(brush, bmp);
            }

            return arrow;
        }

        public static Bitmap CreateDownArrow(int arrowWidth, int arrowHeight, Color color)
        {
            Bitmap arrow = new Bitmap(arrowWidth, arrowHeight);
            SolidBrush brush = new SolidBrush(color);

            using (Graphics g = Graphics.FromImage(arrow))
            {
                Point[] bmp =
                {
                    new Point(0, 0),
                    new Point(arrowWidth / 2, arrowHeight),
                    new Point(arrowWidth, 0)
                };
                g.FillPolygon(brush, bmp);
            }

            return arrow;
        }
    }
}
