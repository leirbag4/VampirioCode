using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.IO
{
    public class Display
    {
        public static float DpiX { get; private set; }
        public static float DpiY { get; private set; }
        public static float Scale { get; private set; }

        public static void Initialize()
        {
            using (Bitmap bitmap = new Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Obtain horizontal and vertical DPI
                float dpiX = g.DpiX; // DPI horizontal
                float dpiY = g.DpiY; // DPI vertical

                DpiX = dpiX;
                DpiY = dpiY;
                Scale = (int)(dpiX / 96.0 * 100);
            }
        }
    }
}
