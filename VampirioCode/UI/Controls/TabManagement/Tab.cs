using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.VampGraphics;

namespace VampirioCode.UI.Controls.TabManagement
{
    public class Tab
    {
        enum State
        {
            Over,
            Up
        }

        public bool IsDragging { get { return dragging; } }
        public bool Selected { get; set; }
        public int CenterX { get { return x + (width >> 1); } }
        public int Left { get { return x; } }
        public int Right { get { return x + width; } }

        public int x, y, width, height;
        private State state = State.Up;
        public TabItem item;
        private Font font;
        private bool dragging;
        private int startDragX;
        private TabController controller;

        public Tab(TabItem item, Font font, TabController manager)
        {
            item.tab = this;
            x = 0;
            y = 0;
            width = item.Width;
            height = 25;
            this.item = item;
            this.font = font;
            dragging = false;
            startDragX = 0;
            Selected = false;
            this.controller = manager;
        }

        public void SetPos(int x, int y)
        {
            this.x = x; this.y = y;
        }

        public void Select()
        {
            Selected = true;
        }

        public void Unselect()
        {
            Selected = false;
        }

        public int Index()
        {
            return controller.tabs.IndexOf(this);
        }

        public Tab Prev()
        {
            int index = Index();

            if (index == 0)
                return null;
            else
                return controller.tabs[index - 1];
        }

        public Tab Next()
        {
            int index = Index();

            if (index >= controller.tabs.Count - 1)
                return null;
            else
                return controller.tabs[index + 1];
        }

        public void OnMouseDown(int mx, int my)
        {
            if (IsInside(mx, my))
            {
                startDragX = mx;
                dragging = true;
                controller.StartDragging(this);
            }
        }

        public void OnMouseMove(int mx, int my, bool mouseDown)
        {
            if (dragging)
            {
                int offset = mx - startDragX;
                startDragX = mx;

                SetPos(x + offset, 0);
            }
            else if (IsInside(mx, my))
            {
                state = State.Over;
            }
            else
            {
                state = State.Up;
            }
        }

        public void OnMouseUp(int mx, int my)
        {
            if (dragging)
            {
                dragging = false;
                controller.StopDragging();
            }

            state = State.Up;
        }

        public void OnMouseLeave()
        {
            if (!Selected)
                state = State.Up;
        }

        private bool IsInside(int mx, int my)
        {
            return mx >= x && mx <= x + width && my >= y && my <= y + height;
        }

        public void Update()
        {

        }

        public void Paint(Graphics g)
        {
            Color backColor = Color.White;
            int _x_ = controller.OFFSET_X + x;

            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (Selected)
                backColor = Color.DimGray;
            else
            {
                if (state == State.Up)
                    backColor = Color.LightGray;
                else if (state == State.Over)
                    backColor = Color.DarkGray;
            }

            VampirioGraphics.FillRect(g, backColor, Color.Gray, 2, _x_, y, width, height);
            VampirioGraphics.DrawString(g, font, item.Text, Color.Black, _x_, y, width, height, ContentAlignment.MiddleCenter);

            VampirioGraphics.FillRect(g, Color.Black, _x_ + (width >> 1) - 1, y, 3, 4);
        }

    }
}
