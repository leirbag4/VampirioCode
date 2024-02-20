using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TabManagement
{
    public class TabUtils
    {
        public static Bitmap CreateX(int width, int height, Color color)
        {
            Bitmap bitmap = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                Pen pen = new Pen(color, 2);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //g.FillRectangle(new SolidBrush(Color.Red), 0, 0, width, height);
                g.DrawLine(pen, 0, 0, width, height);
                g.DrawLine(pen, width - 1, 0, 0, height - 1);
            }

            

            return bitmap;
        }

        public static Bitmap CreateLeftArrow(int arrowWidth, int arrowHeight, Color color)
        {
            // Create bitmaps for arrows
            Bitmap arrow =   new Bitmap(arrowWidth, arrowHeight);
            
            SolidBrush brush = new SolidBrush(color);

            using (Graphics g = Graphics.FromImage(arrow))
            {
                // Draw left arrow on the left bitmap
                Point[] bmp =
                {
                    new Point(arrowWidth, 0),
                    new Point(arrowWidth, arrowHeight),
                    new Point(0, arrowHeight / 2)
                };
                g.FillPolygon(brush, bmp);
            }

            return arrow;
        }

        public static Bitmap CreateRightArrow(int arrowWidth, int arrowHeight, Color color)
        {
            // Create bitmaps for arrows
            Bitmap arrow =   new Bitmap(arrowWidth, arrowHeight);
            
            SolidBrush brush = new SolidBrush(color);

            using (Graphics g = Graphics.FromImage(arrow))
            {
                // Draw right arrow on the right bitmap
                Point[] rightArrowPoints =
                {
                    new Point(0, 0),
                    new Point(0, arrowHeight),
                    new Point(arrowWidth, arrowHeight / 2)
                };
                g.FillPolygon(brush, rightArrowPoints);
            }

            return arrow;
        }

    }
}
