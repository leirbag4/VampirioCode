using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TreeViewAdvance
{
    public class TGraphics
    {
        /*public static void DrawExpandCollapseIcon(Graphics g, TreeNode node, int distance, int size)
        {
            int x = node.gnode.LocalX - distance;
            int y = node.gnode.LocalY;
            Rectangle rect = new Rectangle(x, y, size, size);
            
            DrawExpandCollapseIcon(g, node, rect);
        }*/

        public static Font StaticFont { get; set; } = new Font("Verdana", 10);

        private static Color CColor(int red, int green, int blue)
        { 
            return Color.FromArgb(red, green, blue);
        }

        /*public static void DrawExpandCollapseIcon(Graphics g, TreeViewAdv treeView, TreeNode node, TIcon icon)
        {
            DrawExpandCollapseIcon(g, treeView, node, new Rectangle(icon.X, icon.Y, icon.Width, icon.Height));      
        }*/

        public static void DrawLine(Graphics g, Pen penColor, int x, int y, int x2, int y2)
        {
            g.DrawLine(penColor, x, y, x2, y2);
        }

        public static void DrawExpandCollapseIcon(Graphics g, TreeViewAdv treeView, TreeNode node, TRect rect)
        {
            SolidBrush brushRect =  null;
            Pen penBorders =        null;
            Pen penCross =          null;

            CollapseStyle style;

            if (node.gnode.GetOverState())
                style = treeView.OverCollapseStyle;
            else
                style = treeView.NormalCollapseStyle;

            brushRect = new SolidBrush(style.AreaColor);
            penBorders = new Pen(new SolidBrush(style.BorderColor));
            penCross = new Pen(new SolidBrush(style.CrossColor));


            g.FillRectangle(brushRect,  rect.ToRectangle());
            g.DrawRectangle(penBorders, rect.ToRectangle());

            if (node.IsExpanded)
            {
                // Draw the "-" icon to expand
                g.DrawLine(penCross, rect.Left + 2, rect.Top + rect.Height / 2, rect.Right - 2, rect.Top + rect.Height / 2);
            }
            else
            {
                // Draw the "+" icon to collapse
                g.DrawLine(penCross, rect.Left + 2, rect.Top + rect.Height / 2, rect.Right - 2, rect.Top + rect.Height / 2);
                g.DrawLine(penCross, rect.Left + rect.Width / 2, rect.Top + 2, rect.Left + rect.Width / 2, rect.Bottom - 2);
            }
        }

        public static void FillRect(Graphics g, Color backColor, TRect rect)
        {
            FillRect(g, backColor, rect.X, rect.Y, rect.Width, rect.Height);
        }

        public static void FillRect(Graphics g, Color backColor, int x, int y, int width, int height)
        {
            g.FillRectangle(new SolidBrush(backColor), new Rectangle(x, y, width, height));
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

        /// <summary>
        /// Calculates the new size of a bitmap while maintaining its aspect ratio,
        /// scaled to fit within the maximum allowed dimensions.
        /// </summary>
        /// <param name="width">Original width of the bitmap.</param>
        /// <param name="height">Original height of the bitmap.</param>
        /// <param name="maxWidth">Maximum allowed width.</param>
        /// <param name="maxHeight">Maximum allowed height.</param>
        /// <returns>A Size object with the adjusted dimensions.</returns>
        public static Size CalcAspect(int width, int height, int maxWidth, int maxHeight)
        {
            // Validate that all input dimensions are greater than zero
            //if (width <= 0 || height <= 0 || maxWidth <= 0 || maxHeight <= 0)
            //    throw new ArgumentException("All dimensions must be greater than zero.");

            // Calculate the original aspect ratio of the bitmap
            float aspectRatio = (float)width / height;

            // Variables for the adjusted size
            int newWidth = maxWidth;
            int newHeight = maxHeight;

            // If the aspect ratio is greater than 1, the image is wider than it is tall
            if (aspectRatio > 1)
            {
                // Limit by width and calculate the corresponding height to maintain the aspect ratio
                newHeight = (int)(maxWidth / aspectRatio);

                // Ensure the height does not exceed the maximum height
                if (newHeight > maxHeight)
                {
                    // Recalculate the width based on the maximum height
                    newHeight = maxHeight;
                    newWidth = (int)(maxHeight * aspectRatio);
                }
            }
            else
            {
                // If the aspect ratio is less than or equal to 1, the image is taller or square
                // Limit by height and calculate the corresponding width to maintain the aspect ratio
                newWidth = (int)(maxHeight * aspectRatio);

                // Ensure the width does not exceed the maximum width
                if (newWidth > maxWidth)
                {
                    // Recalculate the height based on the maximum width
                    newWidth = maxWidth;
                    newHeight = (int)(maxWidth / aspectRatio);
                }
            }

            // Return the new dimensions as a Size object
            return new Size(newWidth, newHeight);
        }
    }
}
