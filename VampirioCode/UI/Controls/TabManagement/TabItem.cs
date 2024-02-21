using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VampirioCode.UI.VampGraphics;

namespace VampirioCode.UI.Controls.TabManagement
{
    public class TabItem
    {

        public Control Content { get; set; }

        public TabStyle SelectedStyle { get; set; } = null;
        public TabStyle NormalStyle { get; set; } = null;
        public TabStyle OverStyle { get; set; } = null;
        public TabStyle SubButtonsSelectedStyle { get; set; } = null;
        public TabStyle SubButtonsNormalStyle { get; set; } = null;
        public TabStyle SubButtonsOverStyle { get; set; } = null;
        public bool CloseButtonVisible { get { return controller.CloseButtonVisible; } }
        public int BorderSize { get; set; } = -1;
        public bool Selected { get { return tab.Selected; } }
        public int X { get { return tab.X; } }
        public int Y { get { return tab.Y; } }
        public int Width { get { return tab.GetWidth(); } set { tab.SetWidth(value); } }
        public int Height { get { return tab.GetHeight(); } set { tab.SetHeight(value); } }
        public string Text { get { return tab.GetText(); } set { tab.SetText(value); } }
        public Tab tab { get; }

        public int Index { get { return tab.Index(); } }



        private TabController controller = null;
        private TabSubButton closeButton;

        public TabItem(string name) : this()
        {
            Text = name;
        }

        public TabItem()
        {
            tab = new Tab(this);
            Content = new Control();

            closeButton = new TabSubButton();
        }

        public void Setup(TabController controller, Bitmap closeBitmap)
        {
            this.controller = controller;
            closeButton.Setup(controller, this);
            closeButton.Image = closeBitmap;
        }

        public TabItem Prev()
        {
            Tab prev = tab.Prev();

            if (prev != null)
                return prev.Item;
            else
                return null;
        }

        public TabItem Next()
        {
            Tab next = tab.Next();

            if (next != null)
                return next.Item;
            else
                return null;
        }

        

        public virtual bool OnMouseDown(int mx, int my)
        {
            if (CloseButtonVisible)
            {
                if (closeButton.MouseDown(mx, my))
                {
                    controller.CloseTabInvoke(this.tab);
                    return true;
                }
            }

            return false;
        }

        public virtual void OnMouseMove(int mx, int my, bool isInside)
        {
            if (CloseButtonVisible)
                closeButton.MouseMove(mx, my);
        }

        public virtual void OnMouseUp(int mx, int my)
        {
            if (CloseButtonVisible)
                closeButton.MouseUp(mx, my);
        }

        public virtual void OnMouseLeave()
        {
            if (CloseButtonVisible)
                closeButton.MouseLeave();
        }

        public virtual void OnUpdatePosition()
        {
            if (CloseButtonVisible)
            {
                closeButton.X = Width - closeButton.Width - 5;
                closeButton.Y = (Height >> 1) - (closeButton.Height >> 1);
            }
        }

        public virtual void Paint(Graphics g, int x, int y, int width, int height, TabState state)
        {
            /*if(state == TabState.Selected)
                VampirioGraphics.FillRect(g, Color.Green, Color.Red, 1, x, y, width, height);
            else if(state == TabState.Over)
                VampirioGraphics.FillRect(g, Color.Orange, Color.Red, 1, x, y, width, height);
            else if(state == TabState.Up)
                VampirioGraphics.FillRect(g, Color.Blue, Color.Red, 1, x, y, width, height);*/

            if (controller.CloseButtonBehaviour == CloseBtnBehaviour.ActiveAlways)
            {
                if (CloseButtonVisible)
                    closeButton.Paint(g, x, y);
            }
            else if (controller.CloseButtonBehaviour == CloseBtnBehaviour.ActiveOnSelect)
            {
                if (CloseButtonVisible && ((state == TabState.Selected) || (state == TabState.Over)))
                    closeButton.Paint(g, x, y);
            }

        }

    }
}
