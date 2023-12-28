using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.VampGraphics
{
    public class VampirioGraphics
    {
        //e.g: dir = 'gallery\\currency', startFileName = 'currency', id = 2, ---> gallery\\currency\\currency_2.png
        public static Bitmap GetIcon(string dir, string startFileName, int id, int width, int height)
        {
            Image img;
            List<string> fnames = new List<string>();
            string fname = dir + "\\" + startFileName + "_" + id;

            if (id != -1)
            {
                fnames.Add(fname + ".png");
                fnames.Add(fname + ".PNG");
                fnames.Add(fname + ".jpg");
                fnames.Add(fname + ".JPG");

                for (int a = 0; a < fnames.Count; a++)
                {
                    if (File.Exists(fnames[a]))
                    {
                        try
                        {
                            img = Image.FromFile(fnames[a]);
                            return ResizeBitmap(new Bitmap(img), width, height, true);
                        }
                        catch (Exception e)
                        {
                            return null;
                        }
                    }
                }
            }

            return null;
        }

        public static Bitmap AddFixedBounds(Bitmap src, int width, int height, bool conserveAspect = false)
        {
            src = ResizeBitmap(src, width, height, true);
            Bitmap back = new Bitmap(width, height, src.PixelFormat);
            Rectangle rect = new Rectangle(0, 0, back.Width, back.Height);


            Graphics g = Graphics.FromImage(back);

            //g.FillRectangle(Brushes.Red, rect);
            g.DrawImage(src, new Rectangle((back.Width >> 1) - (src.Width >> 1), (back.Height >> 1) - (src.Height >> 1), src.Width, src.Height));
            g.Flush();

            return back;

        }

        public static Bitmap ResizeBitmap(Bitmap src, int width, int height, bool conserveAspect = false)
        {
            Bitmap dest = null;
            Point aspect;

            if (conserveAspect)
            {
                aspect = CalcAspect(src.Width, src.Height, width, height);
                dest = new Bitmap(src, new Size(aspect.X, aspect.Y));
            }
            else
                dest = new Bitmap(src, new Size(width, height));

            return dest;
        }

        public static Point CalcAspect(int width, int height, int maxWidth, int maxHeight)
        {
            float proportion;

            if (width > maxWidth)
            {
                proportion = maxWidth / (float)width;

                width = maxWidth;
                height = (int)(height * proportion);
            }

            if (height > maxHeight)
            {
                proportion = maxHeight / (float)height;

                height = maxHeight;
                width = (int)(width * proportion);
            }

            return new Point(width, height);
        }

        public static PointF CalcAspect(float width, float height, float maxWidth, float maxHeight)
        {
            float proportion;

            if (width > maxWidth)
            {
                proportion = maxWidth / width;

                width = maxWidth;
                height = height * proportion;
            }

            if (height > maxHeight)
            {
                proportion = maxHeight / height;

                height = maxHeight;
                width = width * proportion;
            }

            return new PointF(width, height);
        }

        public static void FillRoundRect(Graphics g, Color backColor, Color borderColor, int borderSize, int x, int y, int width, int height)
        {
            FillRoundRect(g, backColor, borderColor, borderSize, new Rectangle(x, y, width, height));
        }

        public static void FillRoundRect(Graphics g, Color backColor, Color borderColor, int borderSize, Rectangle rect)
        {
            int roundExt = 5, roundInt = 3;

            if (borderSize <= 1)
            {
                roundExt = 5;
                roundInt = 5;
            }

            if (borderSize > 0)
            {
                g.FillRoundedRectangle(new SolidBrush(borderColor), rect.X, rect.Y, rect.Width - 1, rect.Height - 1, roundExt);
                g.FillRoundedRectangle(new SolidBrush(backColor), new Rectangle(borderSize, borderSize, rect.Width - borderSize * 2 - 1, rect.Height - borderSize * 2 - 1), roundInt);
            }
            else
                g.FillRoundedRectangle(new SolidBrush(backColor), rect.X, rect.Y, rect.Width - 1, rect.Height - 1, roundExt);

        }

        public static void FillRect(Graphics g, Color backColor, Color borderColor, int borderSize, int x, int y, int width, int height)
        {
            FillRect(g, backColor, borderColor, borderSize, new Rectangle(x, y, width, height));
        }

        public static void FillRect(Graphics g, Color backColor, Color borderColor, int borderSize, Rectangle rect)
        {
            g.FillRectangle(new SolidBrush(borderColor), rect);
            g.FillRectangle(new SolidBrush(backColor), new Rectangle(rect.X + borderSize, rect.Y + borderSize, rect.Width - borderSize * 2, rect.Height - borderSize * 2));
        }

        public static void DrawCenterImage(Graphics g, Bitmap img, Rectangle contRect)
        {
            DrawCenterImage(g, img, contRect.X, contRect.Y, contRect.Width, contRect.Height);
        }

        public static void DrawCenterImage(Graphics g, Bitmap img, int contX, int contY, int contWidth, int contHeight)
        {
            DrawCenterImage(g, img, contX + (contWidth >> 1), contY + (contHeight >> 1));
        }

        public static void DrawCenterImage(Graphics g, Bitmap img, int x, int y)
        {
            DrawImage(g, img, x - (img.Width >> 1), y - (img.Height >> 1));
        }

        public static void DrawImage(Graphics g, Bitmap img, int x, int y)
        {
            g.DrawImage(img, x, y, img.Width, img.Height);
        }

        public static void DrawImage(Graphics g, Bitmap img, int x, int y, int width, int height)
        {
            g.DrawImage(img, x, y, width, height);
        }
    }
}
