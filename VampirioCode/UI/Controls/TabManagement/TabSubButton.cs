using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.VampGraphics;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace VampirioCode.UI.Controls.TabManagement
{
    public class TabSubButton
    {

        enum State
        { 
            Over,
            Up
        }

        public TabItem Item { get; set; }
        public string Text { get; set; } = "";
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Width { get; set; } = 20;
        public int Height { get; set; } = 20;
        public Bitmap Image { get; set; }

        private State state = State.Up;
        private TabController controller;

        public void Setup(TabController controller, TabItem item)
        { 
            this.controller = controller;
            this.Item = item;
        }

        public bool MouseDown(int mx, int my)
        {
            if (IsInside(mx, my))
            {
                state = State.Over;
                return true;
            }

            return false;
        }

        public void MouseMove(int mx, int my)
        {
            if (IsInside(mx, my))
                state = State.Over;
            else
                state = State.Up;
        }

        public void MouseUp(int mx, int my)
        {
            state = State.Up;
        }

        public void MouseLeave()
        {
            state = State.Up;
        }

        public bool IsOver()
        { 
            return (state == State.Over);
        }

        public bool IsInside(int mx, int my)
        {
            return (mx >= X) && (mx < (X + Width)) && (my >= Y) && (my <= (Y + Height));
        }

        public void Paint(Graphics g, int offsetX, int offsetY)
        {
            TabStyle style = null;
            int borderSize = 0;

            if (Item.Selected)
            {
                if (state == State.Over)
                {
                    if (Item.SubButtonsSelectedStyle != null)
                        style = Item.SubButtonsSelectedOverStyle;
                    else
                        style = controller.SubButtonsSelectedOverStyle;
                }
                else
                {
                    if (Item.SubButtonsSelectedStyle != null)
                        style = Item.SubButtonsSelectedStyle;
                    else
                        style = controller.SubButtonsSelectedStyle;
                }
            }
            else if (state == State.Over)
            {
                if (Item.SubButtonsOverStyle != null)
                    style = Item.SubButtonsOverStyle;
                else
                    style = controller.SubButtonsOverStyle;
            }
            else if (state == State.Up)
            {
                if (Item.tab.TabState == TabState.Over)
                {
                    if (Item.SubButtonsParentOverStyle != null)
                        style = Item.SubButtonsParentOverStyle;
                    else
                        style = controller.SubButtonsParentOverStyle;
                }
                else
                {
                    if (Item.SubButtonsNormalStyle != null)
                        style = Item.SubButtonsNormalStyle;
                    else
                        style = controller.SubButtonsNormalStyle;
                }
            }


            if (Item.BorderSize != -1)
                borderSize = Item.BorderSize;
            else
                borderSize = controller.SubButtonsBorderSize;

            VampirioGraphics.FillRect(g, style.BackColor, style.BorderColor, borderSize, offsetX + X, offsetY + Y, Width, Height);
            if(Image != null)
                VampirioGraphics.DrawImage(g, Image, offsetX + X + (Image.Width >> 1), offsetY + Y + (Image.Height >> 1));

            //Font font = new System.Drawing.Font("Verdana", 9);
            //VampirioGraphics.DrawString(g, font, Text, style.TextColor, offsetX + X + (Width >> 1), offsetY + Y + (Height >> 1), ContentAlignment.MiddleCenter);
        }
    }

}
