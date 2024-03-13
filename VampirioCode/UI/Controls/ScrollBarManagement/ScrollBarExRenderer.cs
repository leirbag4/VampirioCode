namespace VampirioCode.UI.Controls.ScrollBarManagement
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;

    public class ScrollBarExRenderer
    {
        private Bitmap resArrowUp;
        private Bitmap resArrowDown;
        private Bitmap resArrowLeft;
        private Bitmap resArrowRight;

        private ScrollBarAdv scrollBar;

        public ScrollBarExRenderer(ScrollBarAdv scrollBar)
        {
            //leirbag
            this.scrollBar = scrollBar;
            CreateResources();
        }

        private void CreateResources()
        {
            resArrowUp =    ScrollBarUtils.CreateUpArrow(11, 6, scrollBar.ArrowColor);

            Bitmap arrow = (Bitmap)resArrowUp.Clone();

            arrow.RotateFlip(RotateFlipType.Rotate180FlipNone);
            resArrowDown = new Bitmap(arrow);

            arrow.RotateFlip(RotateFlipType.Rotate90FlipNone);
            resArrowLeft = new Bitmap(arrow);

            arrow.RotateFlip(RotateFlipType.Rotate180FlipNone);
            resArrowRight = new Bitmap(arrow);

        }


        public void DrawBackground(Graphics g, Rectangle rect, ScrollBarOrientation orientation)
        {
            if (g == null)
                throw new ArgumentNullException("g");

            if (rect.IsEmpty || g.IsVisibleClipEmpty || !g.VisibleClipBounds.IntersectsWith(rect))
                return;

            if (orientation == ScrollBarOrientation.Vertical)
                DrawBackgroundVertical(g, rect);
            else
                DrawBackgroundHorizontal(g, rect);
        }

        public void DrawTrack(Graphics g, Rectangle rect, ScrollBarState state, ScrollBarOrientation orientation)
        {
            if (g == null)
                throw new ArgumentNullException("g");

            if ((rect.Width <= 0 || rect.Height <= 0) || (state != ScrollBarState.Pressed) || (g.IsVisibleClipEmpty) || (!g.VisibleClipBounds.IntersectsWith(rect)))
                return;

            if (orientation == ScrollBarOrientation.Vertical)
                DrawTrackVertical(g, rect);
            else
                DrawTrackHorizontal(g, rect);
        }

        private void DrawTrackVertical(Graphics g, Rectangle rect)
        {
            Rectangle innerRect = new Rectangle(rect.Left + 1, rect.Top, 15, rect.Height);

            g.FillRectangle(new SolidBrush(scrollBar.TrackColor), innerRect);
        }

        private void DrawTrackHorizontal(Graphics g, Rectangle rect)
        {
            Rectangle innerRect = new Rectangle(rect.Left, rect.Top + 1, rect.Width, 15);

            g.FillRectangle(new SolidBrush(scrollBar.TrackColor), innerRect);
        }

        public void DrawThumb(Graphics g, Rectangle rect, ScrollBarState state, ScrollBarOrientation orientation)
        {
            if (g == null)
                throw new ArgumentNullException("g");

            if (rect.IsEmpty || g.IsVisibleClipEmpty || !g.VisibleClipBounds.IntersectsWith(rect) || state == ScrollBarState.Disabled)
                return;

            if (orientation == ScrollBarOrientation.Vertical)
                DrawThumbVertical(g, rect, state);
            else
                DrawThumbHorizontal(g, rect, state);
        }

        private void DrawThumbVertical(Graphics g, Rectangle rect, ScrollBarState state)
        {
            Color color;

                 if (state == ScrollBarState.Hot)       color = scrollBar.ThumbOverColor;
            else if (state == ScrollBarState.Pressed)   color = scrollBar.ThumbDownColor;
            else                                        color = scrollBar.ThumbNormalColor;

            g.FillRectangle(new SolidBrush(color), rect.X, rect.Y, rect.Width + 1, rect.Height + 1);
        }

        private void DrawThumbHorizontal(Graphics g, Rectangle rect, ScrollBarState state)
        {
            Color color;

                 if (state == ScrollBarState.Hot)       color = scrollBar.ThumbOverColor;
            else if (state == ScrollBarState.Pressed)   color = scrollBar.ThumbDownColor;
            else                                        color = scrollBar.ThumbNormalColor;

            g.FillRectangle(new SolidBrush(color), rect.X, rect.Y, rect.Width + 1, rect.Height + 1);
        }

        public void DrawArrowButton(Graphics g, Rectangle rect, ScrollBarArrowButtonState state, bool arrowUp, ScrollBarOrientation orientation)
        {
            if (g == null)
                throw new ArgumentNullException("g");

            if (rect.IsEmpty || g.IsVisibleClipEmpty || !g.VisibleClipBounds.IntersectsWith(rect))
                return;

            if (orientation == ScrollBarOrientation.Vertical)
                DrawArrowButtonVertical(g, rect, state, arrowUp);
            else
                DrawArrowButtonHorizontal(g, rect, state, arrowUp);
        }

        private void DrawArrowButtonVertical(Graphics g, Rectangle rect, ScrollBarArrowButtonState state, bool arrowUp)
        {
            Bitmap arrow;
            Color color;
            int x = rect.X - 2;
            int y = rect.Y;
            int w = rect.Width + 4;
            int h = rect.Height;

            if (arrowUp)    arrow = resArrowUp;
            else            arrow = resArrowDown;

            color = scrollBar.ButtonNormalColor;

            if ((state == ScrollBarArrowButtonState.UpHot) || (state == ScrollBarArrowButtonState.DownHot))       
                color = scrollBar.ButtonOverColor;
            else if ((state == ScrollBarArrowButtonState.UpActive) || (state == ScrollBarArrowButtonState.DownActive)) 
                color = scrollBar.ButtonDownColor;
            else if ((state == ScrollBarArrowButtonState.UpPressed) || (state == ScrollBarArrowButtonState.DownPressed))
                color = scrollBar.ButtonNormalColor;

            g.FillRectangle(new SolidBrush(color), x, y, w, h);
            g.DrawImage(arrow, x + (w >> 1) - (arrow.Width >> 1), y + (h >> 1) - (arrow.Height >> 1), arrow.Width, arrow.Height);

        }

        private void DrawArrowButtonHorizontal(Graphics g, Rectangle rect, ScrollBarArrowButtonState state, bool arrowLeft)
        {
            Bitmap arrow;
            Color color;
            int x = rect.X;
            int y = rect.Y - 2;
            int w = rect.Width;
            int h = rect.Height + 4;
            int offsetX = 0;

            if (arrowLeft)  arrow = resArrowLeft;
            else            { arrow = resArrowRight; offsetX++; }

            color = scrollBar.ButtonNormalColor;

            if ((state == ScrollBarArrowButtonState.UpHot) || (state == ScrollBarArrowButtonState.DownHot))       
                color = scrollBar.ButtonOverColor;
            else if ((state == ScrollBarArrowButtonState.UpActive) || (state == ScrollBarArrowButtonState.DownActive)) 
                color = scrollBar.ButtonDownColor;
            else if ((state == ScrollBarArrowButtonState.UpPressed) || (state == ScrollBarArrowButtonState.DownPressed))
                color = scrollBar.ButtonNormalColor;

            g.FillRectangle(new SolidBrush(color), x, y, w, h);
            g.DrawImage(arrow, x + (w >> 1) - (arrow.Width >> 1) + offsetX, y + (h >> 1) - (arrow.Height >> 1), arrow.Width, arrow.Height);

        }

        private void DrawBackgroundVertical(Graphics g, Rectangle rect)
        {
            g.FillRectangle(new SolidBrush(scrollBar.BackgroundColor), rect);
        }

        private void DrawBackgroundHorizontal(Graphics g, Rectangle rect)
        {
            g.FillRectangle(new SolidBrush(scrollBar.BackgroundColor), rect);
        }

    }
}
