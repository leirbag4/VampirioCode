//#define TAB_CONTROLLER_DEBUG

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

        public bool IsNonSelButOver { get { return (!Selected) && (state == State.Over); } }
        public bool IsDragging { get { return dragging; } }
        public bool Selected { get; set; }
        public int CenterX { get { return X + (Width >> 1); } }
        public int Left { get { return X; } }
        public int Right { get { return X + Width; } }
        public int Width { get { int w; if (controller.SizeMode == TabSizeMode.Fixed) w = _width; else /*TabSizeMode.WrapToText*/ w = textWidth + ((LeftPadding + RightPadding) << 1); if (w > controller.MaxTabWidth) return controller.MaxTabWidth; return w; } set { _width = value; } }
        public int Height { get; set; }
        public int InnerWidth { get { return Width - ((LeftPadding + RightPadding) << 1); } }
        public int LeftPadding { get; set; }
        public int RightPadding { get; set; }
        public TabItem Item { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public TabState TabState { get { if (Selected) return TabState.Selected; else if (state == State.Over) return TabState.Over; else return TabState.Up; } }


        private int _width;
        private State state = State.Up;
        private string originalText = "";
        private string text = "";
        private int textWidth = -1;
        private bool pendingAssignments = false;
        private Font font;
        private bool dragging;              // Tell if Tab is being dragged
        private int startDragX;             // Used to calculate on each movement how long the mouse moves
        public int dragOffsetPointX = 0;    // Register the offset position inside a selected tab that is going to be dragged
        private TabController controller;   // Main tabs controller and container


        public Tab(TabItem item)
        {
            this.X =            0;
            this.Y =            0;
            this.Width =        100;
            this.Height =       25;
            this.LeftPadding =  5;
            this.RightPadding = 5;
            this.Item =         item;
            this.dragging =     false;
            this.startDragX =   0;
            this.Selected =     false;
            this.controller =   null;
            this.font =         null;
        }

        public void Setup(TabController controller, Font font, int height, int leftPadding, int rightPadding)
        {
            this.controller =   controller;
            this.font =         font;
            this.Height =       height;
            this.LeftPadding =  leftPadding;
            this.RightPadding = rightPadding;

            if (pendingAssignments)
            {
                if (this.textWidth < controller.MinTabWidth)
                    textWidth = controller.MinTabWidth;
            }
        }

        // set the local position of tab
        public void SetPos(int x, int y)
        {
            this.X = x; this.Y = y;
        }

        public void SetX(int x)
        {
            this.X = x;
        }

        // shift the tab using its global position taking care of the dragging point also
        public void GlobalMoveX(int amount)
        {
            this.X += amount;
            this.startDragX += amount;
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

        public void SetText(string text)
        {
            this.originalText = text;
            this.text =         "";
            this.textWidth =    TextRenderer.MeasureText(originalText, font, new Size(1, Height)).Width;

            // if this Tab was not added to a TabController yet, we must mark with this variable 
            // that we are in a pending state and that we need to finish our code when a TabController is assigned
            if (controller == null)
            { 
                pendingAssignments = true;
            }
            else
            {
                if (this.textWidth < controller.MinTabWidth)
                    textWidth = controller.MinTabWidth;

                controller.AdjustTabsFrom(Index());
                controller.TabTextChanged(this);
            }
        }

        public string GetText()
        {
            return originalText;
        }

        public void SetWidth(int width)
        {
            this.Width = width;
        }

        public int GetWidth()
        {
            return Width;
        }

        public void SetHeight(int height)
        {
            this.Height = height;
        }

        public int GetHeight()
        {
            return Height;
        }

        public void OnMouseDown(int mx, int my)
        {
            if (IsInside(mx, my))
            {
                Item.OnUpdatePosition();
                if (Item.OnMouseDown(mx - X, my))
                    return;

                dragOffsetPointX = mx - X;

                startDragX = mx;
                dragging = true;
                controller.StartDragging(this);

                if (!controller.AllowDragging)
                {
                    controller.StopDragging();
                    dragging = false;
                }
            }
        }

        public void OnMouseMove(int mx, int my, bool mouseDown)
        {
            if (dragging)
            {
                int offset = mx - startDragX;
                startDragX = mx;

                SetX(X + offset);
            }
            else if (IsInside(mx, my))
            {
                Item.OnUpdatePosition();
                Item.OnMouseMove(mx - X, my, true);
                state = State.Over;
            }
            else
            {
                Item.OnUpdatePosition();
                Item.OnMouseMove(mx - X, my, false);
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

            Item.OnMouseUp(mx - X, my);
            state = State.Up;
        }

        public void OnMouseLeave()
        {
            Item.OnMouseLeave();

            if (!Selected)
                state = State.Up;
        }

        private bool IsInside(int mx, int my)
        {
            return (mx >= X) && (mx < (X + Width)) && (my >= Y) && (my <= (Y + Height));
        }

        // Short and reduce text to enter inside width adding '...' at the end
        // e.g: converting [hello tab world] to
        //                 [hello ...]
        private string ReduceText(Graphics g, string str, int width)
        {
            //SizeF textSize = g.MeasureString(str, font);
            SizeF textSize = g.MeasureString(str, font, PointF.Empty, VampirioGraphics.GetFormat(ContentAlignment.MiddleCenter));

            if (textSize.Width > width)
            {
                while ((textSize.Width > width) && str.Length > 0)
                {
                    str = str.Substring(0, str.Length - 1);
                    //textSize = g.MeasureString(str + "...", font);
                    textSize = g.MeasureString(str + "...", font, PointF.Empty, VampirioGraphics.GetFormat(ContentAlignment.MiddleCenter));
                }
                str += "...";
            }
            XConsole.Println("reduce text: " + str);
            return str;
        }

        public void CancelDrag()
        {
            controller.StopDragging();
            dragging = false;
        }

        /*public void Update()
        {
            
        }*/

        public void Paint(Graphics g, bool isFirst, bool isLast)
        {
            Color backColor = Color.White;
            string txt = originalText;
            int _x_ = controller.OFFSET_X + X;
            TabStyle style = null;
            int borderSize = controller.TabBorderSize;

            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Check if text is longer than Width
            // In the case it is, reduce it and add '...' at the end
            // e.g: converting [hello tab world] to
            //                 [hello ...]
            if (textWidth > InnerWidth)
            {
                //XConsole.Println($"textWidth: {textWidth}  Width: {Width} InnerWidth: {InnerWidth}");

                if(text == "")
                    text = ReduceText(g, originalText, InnerWidth); 

                txt = text;
            }

            if (Selected)
            {
                if (Item.SelectedStyle != null)
                    style = Item.SelectedStyle;
                else
                    style = controller.SelectedStyle;
            }
            else if (state == State.Up)
            {
                if (Item.NormalStyle != null)
                    style = Item.NormalStyle;
                else
                    style = controller.NormalStyle;
            }
            else if (state == State.Over)
            {
                if (Item.OverStyle != null)
                    style = Item.OverStyle;
                else
                    style = controller.OverStyle;
            }

            if (controller.PaintMode == TabPaintMode.UserPaintAll)
            {
                Item.OnUpdatePosition();
                Item.Paint(g, _x_, Y, Width, Height, TabState);
                return;
            }


            if (controller.ShapeMode == TabShapeMode.Box)
            {
                int _border = borderSize;

                if(isLast)
                    _border = 0;

                VampirioGraphics.FillRect(g, style.BackColor, style.BorderColor, borderSize, _x_, Y, Width + _border, Height);

#if TAB_CONTROLLER_DEBUG
                PaintDebug(g, txt, _x_);
#endif

                     if (controller.TextAlign == TabTextAlign.Center)   VampirioGraphics.DrawString(g, font, txt, style.TextColor, _x_ + (Width >> 1) + (_border >> 1), Y + (Height >> 1), ContentAlignment.MiddleCenter);
                else if (controller.TextAlign == TabTextAlign.Left)     VampirioGraphics.DrawString(g, font, txt, style.TextColor, _x_ + LeftPadding, Y + (Height >> 1), ContentAlignment.MiddleLeft);
                else if (controller.TextAlign == TabTextAlign.Right)    VampirioGraphics.DrawString(g, font, txt, style.TextColor, _x_ + Width - RightPadding, Y + (Height >> 1), ContentAlignment.MiddleRight);
            }
            else if (controller.ShapeMode == TabShapeMode.BoxExtraBorders)
            {
                VampirioGraphics.FillRect(g, style.BackColor, style.BorderColor, borderSize, _x_, Y, Width, Height);

#if TAB_CONTROLLER_DEBUG
                PaintDebug(g, txt, _x_);
#endif

                     if (controller.TextAlign == TabTextAlign.Center)   VampirioGraphics.DrawString(g, font, txt, style.TextColor, _x_ + (Width >> 1), Y + (Height >> 1), ContentAlignment.MiddleCenter);
                else if (controller.TextAlign == TabTextAlign.Left)     VampirioGraphics.DrawString(g, font, txt, style.TextColor, _x_ + LeftPadding, Y + (Height >> 1), ContentAlignment.MiddleLeft);
                else if (controller.TextAlign == TabTextAlign.Right)    VampirioGraphics.DrawString(g, font, txt, style.TextColor, _x_ + Width - RightPadding, Y + (Height >> 1), ContentAlignment.MiddleRight);
            }
            else if (controller.ShapeMode == TabShapeMode.RoundBox)
            {
                VampirioGraphics.FillRoundRect(g, style.BackColor, style.BorderColor, borderSize, _x_, Y, Width, Height);

#if TAB_CONTROLLER_DEBUG
                PaintDebug(g, txt, _x_);
#endif

                     if (controller.TextAlign == TabTextAlign.Center)   VampirioGraphics.DrawString(g, font, txt, style.TextColor, _x_ + (Width >> 1), Y + (Height >> 1), ContentAlignment.MiddleCenter);
                else if (controller.TextAlign == TabTextAlign.Left)     VampirioGraphics.DrawString(g, font, txt, style.TextColor, _x_ + LeftPadding, Y + (Height >> 1), ContentAlignment.MiddleLeft);
                else if (controller.TextAlign == TabTextAlign.Right)    VampirioGraphics.DrawString(g, font, txt, style.TextColor, _x_ + Width - RightPadding, Y + (Height >> 1), ContentAlignment.MiddleRight);
            }

            if (controller.PaintMode == TabPaintMode.UserPaintOver)
            {
                Item.OnUpdatePosition();
                Item.Paint(g, _x_, Y, Width, Height, TabState);
            }

        }

#if TAB_CONTROLLER_DEBUG
        private void PaintDebug(Graphics g, string txt, int _x_)
        {
            //SizeF fontBounds = g.MeasureString(txt, font, InnerWidth);
            SizeF fontBounds = g.MeasureString(txt, font, PointF.Empty, VampirioGraphics.GetFormat(ContentAlignment.MiddleCenter));
            VampirioGraphics.FillRect(g, Color.Gray, _x_ + (Width >> 1) - ((int)fontBounds.Width >> 1), Y + (Height >> 1) - ((int)fontBounds.Height >> 1), (int)fontBounds.Width, (int)fontBounds.Height);

            VampirioGraphics.FillRect(g, Color.Black, _x_ + (Width >> 1) - 1, Y, 3, 4);

            if (Selected)
                VampirioGraphics.FillRect(g, Color.Red, _x_ + dragOffsetPointX - 1, Y + Height - 3, 3, 3);
        }
#endif

    }
}
