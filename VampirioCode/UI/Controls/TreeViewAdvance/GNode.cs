//#define DEBUG_GNODE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.VampGraphics;

namespace VampirioCode.UI.Controls.TreeViewAdvance
{
    public class GNode
    {
        public TIcon CollapseIcon { get { return treeView.CollapseIcon; } }
        public TIcon Icon1 { get { return treeView.Icon1; } }
        public TIcon Icon2 { get { return treeView.Icon2; } }
        public int LocalX { get { return _x - (treeView != null ? treeView.ScrollX : 0); } set { _x = value + (treeView != null ? treeView.ScrollX : 0); } }
        public int LocalY { get { return _y - (treeView != null ? treeView.ScrollY : 0); } set { _y = value + (treeView != null ? treeView.ScrollY : 0); } }
        public int GlobalX { get { return _x; } set { _x = value; } }
        public int GlobalY { get { return _y; } set { _y = value; } }
        //public int TextWidth { get; set; }
        //public int TextHeight { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int collapseIconKey { get; set; } = -1;
        public int icon1Key { get; set; } = -1;
        public int icon2Key { get; set; } = -1;
        public int collapseIconSelectedKey { get; set; } = -1;
        public int icon1SelectedKey { get; set; } = -1;
        public int icon2SelectedKey { get; set; } = -1;

        private string Text { get { return node.Text; } }

        // rectangle for all gnode, from collapse to ttext
        private TRect FullRect { get { return new TRect(LocalX, LocalY, textRect.Right - LocalX, treeView.NodeHeight); } }// textRect.Height); } }
        public Font Font { get { if (treeView == null) { if (node.Font != null) return node.Font; return TGraphics.StaticFont; } return (node.Font != null ? node.Font : treeView.Font); } }

        private TreeViewAdv treeView = null;
        private TreeNode node;
        private TRect textRect;
        private TRect collapseRect;
        private TRect icon1Rect;
        private TRect icon2Rect;
        //private TRect fullRect; // rectangle for all gnode, from collapse to ttext
        private bool _overState = false;
        private bool _prevOverState = false;
        //private bool _repaint = false;
        private int _prevX = -1;
        private int _prevY = -1;
        private int _x = 0;
        private int _y = 0;
        private string _prevText = "";
        private TIcon[] icons;
        private TRect[] iconRects;
        private int _iconsRightPos = 0;
        private TItem _titem;

        public GNode(TreeNode treeNode, TItem titem)
        {
            node =          treeNode;
            _titem =        titem;
            textRect =      new TRect(0, 0, 0, 0);
            collapseRect =  new TRect(0, 0, 0, 0);
            icon1Rect =     new TRect(0, 0, 0, 0);
            icon2Rect =     new TRect(0, 0, 0, 0);
            _iconsRightPos = 0;
        }

        public void SetTreeView(TreeViewAdv treeView)
        {
            this.treeView = treeView;
            this.icons = new TIcon[] { treeView.CollapseIcon, treeView.Icon1, treeView.Icon2 };
            this.iconRects = new TRect[] { collapseRect, icon1Rect, icon2Rect };
        }

        public void SetOverState(bool over)
        {
            /*if (_prevOverState != _overState)
            {
                _prevOverState = _overState;
                _repaint = true;
            }*/

            _overState = over;
        }

        public bool GetOverState()
        {
            return _overState;
        }

        public TRect GetCollapseRect()
        {
            return collapseRect;
        }

        public TRect GetIcon1Rect()
        {
            return icon1Rect;
        }

        public TRect GetIcon2Rect()
        {
            return icon2Rect;
        }

        public TRect GetTextRect()
        { 
            return textRect;
        }

        public TRect GetFullRect()
        {
            return FullRect;
        }

        public bool IsOverCollapse(int mouseX, int mouseY)
        {
            return IsInside(mouseX, mouseY, collapseRect);
        }

        public bool IsOverText(int mouseX, int mouseY)
        {
            return IsInside(mouseX, mouseY, textRect);
        }

        public bool IsOverFullRect(int mouseX, int mouseY)
        {
            return IsInside(mouseX, mouseY, FullRect);
        }

        private bool IsInside(int x, int y, TRect rect)
        {
            return ((x >= rect.Left) && (x <= rect.Right) && (y >= rect.Top) && (y <= rect.Bottom));
        }

        /*private bool IsInside(int x, int y, TIcon icon)
        {
            return ((x >= icon.X) && (x <= (icon.X + icon.Width)) && (y >= icon.Y) && (y <= (icon.Y + icon.Height)));
        }*/

        public void Refresh()
        {
            SetPos(LocalX, LocalY);
        }

        public void SetPos(int x, int y)
        {
            /*if ((_prevX != x) || (_prevY != y))
            {
                _prevX = x; _prevY = y;
                _repaint = true;
            }*/
            
            int _y;

            LocalX = x;
            LocalY = y;

            TRect prevRect = null;
            TIcon icon;

            for (int a = 0; a < icons.Length; a++)
            {
                // The first one i 'CollapseIcon' so it will always be 'Active' because it shoud be always visible
                if (a == 0)
                {
                    TIcon collapseIcon = CollapseIcon;

                    if (collapseIcon.PositionMode == PositionMode.Centered)
                    {
                        collapseRect.Set(x + CollapseIcon.LeftSpace, y + (FullRect.Height >> 1) - (CollapseIcon.Height >> 1), CollapseIcon.Width, CollapseIcon.Height);
                    }
                    else if (collapseIcon.PositionMode == PositionMode.Normal)
                    {
                        collapseRect.Set(x + collapseIcon.LeftSpace + collapseIcon.IconOffsetX, y + collapseIcon.IconOffsetX, CollapseIcon.Width, CollapseIcon.Height);
                    }

                    prevRect = collapseRect;
                }
                else
                {
                    // 'a' is 'a + 1' here for 'icon1', 'icon2'
                    if (icons[a].Active)
                    {
                        icon = icons[a];

                        if (icon.PositionMode == PositionMode.Centered)
                        {
                            iconRects[a].Set(prevRect.Right + icon.LeftSpace + icon.IconOffsetX, y + (FullRect.Height >> 1) - (icon.Height >> 1) + icon.IconOffsetY, icon.Width, icon.Height);
                        }
                        else if (icon.PositionMode == PositionMode.Normal)
                        {
                            iconRects[a].Set(prevRect.Right + icon.LeftSpace + icon.IconOffsetX, y + icon.IconOffsetY, icon.Width, icon.Height);
                        }
                        else if (icon.PositionMode == PositionMode.ScaledCentered)
                        { 
                            iconRects[a].Set(prevRect.Right + icon.LeftSpace + icon.IconOffsetX, y + icon.IconOffsetY, icon.Width, FullRect.Height);
                        }

                        prevRect = iconRects[a];
                    }
                }
            }

            _iconsRightPos = prevRect.Right;

            textRect.X = GetIconsRightPos() + treeView.TextSpace;
            textRect.Y = LocalY + (FullRect.Height >> 1) - (textRect.Height >> 1);

            if (node.TItem.IsEditing)
                node.TItem.SetPos(textRect.Left, textRect.Top);

            RecalcVisibility();
        }

        private int GetIconsRightPos()
        {
            /*int rightPos = 0;

            for(int a = 0; a < icons.Length; a++)
            {
                if (icons[a].Active)
                    rightPos = iconRects[a].Right;
            }

            return rightPos;*/

            return _iconsRightPos;
        }

        private void RecalcVisibility()
        {
            //XConsole.Println("lx: " + LocalX + " ly: " + LocalY);
        }

        // events
        public void OnTextChanged(string text, TItem titem)
        {
            RecalcTextSize();

            RecalcVisibility();
        }

        public void RecalcTextSize(bool forced = false)
        {
            if ((Text != _prevText) || forced)
            {
                _prevText = Text;

                SizeF size =    VampirioGraphics.GetStringSize(Font, Text);

                if (Text.IndexOf("test C0") != -1)
                    XConsole.Println("fname: " + Font.Name + " fsize: " + Font.Size);

                //TextWidth =     (int)size.Width;
                //TextHeight =    (int)size.Height;
                textRect =      new TRect(GetIconsRightPos(), LocalY, (int)size.Width, (int)size.Height);
                //XConsole.Println("Text w: " + TextWidth + ", h: " + TextHeight);
            }
        }

        private void DrawIcon(Graphics g, int iconIndex, int iconKey, PositionMode mode)
        {
            TIcon icon = icons[iconIndex];
            TRect rect = iconRects[iconIndex];

            if (mode == PositionMode.Normal)
            {
                TGraphics.DrawImage(g, treeView.GetIconImage(iconKey), rect.X, rect.Y);
            }
            else if (mode == PositionMode.Centered)
            {
                TGraphics.DrawImage(g, treeView.GetIconImage(iconKey), rect.X, rect.Y);
            }
            else if (mode == PositionMode.ScaledCentered)
            {
                Bitmap bmp = treeView.GetIconImage(iconKey);

                Size size = TGraphics.CalcAspect(bmp.Width, bmp.Height, icon.Width, FullRect.Height);

                //XConsole.Println("bmpW: " + (float)bmp.Width + " bmpH:" + (float)bmp.Height + " iconW: " + (float)icon.Width + " fullRectH: " + (float)FullRect.Height + " aspectX: " + size.Width + " aspectY: " + size.Height);

                int w = (int)(size.Width *  icon.IconOffsetScale);
                int h = (int)(size.Height * icon.IconOffsetScale);

                TGraphics.DrawImage(g, bmp, rect.X + (icon.Width >> 1) - (w >> 1), rect.Y + (FullRect.Height >> 1) - (h >> 1), w, h);
            }
        }

        // paint
        public void Paint(Graphics g)
        {
            TRect fullRect = FullRect;

            if((fullRect.Right >= 0)  && (fullRect.X <= treeView.Width) &&
               (fullRect.Bottom >= 0) && (fullRect.Y <= treeView.Height))
            {
                if(node.Selected)
                    TGraphics.FillRect(g, treeView.SelectedBackColor, treeView.SelectedBorderColor, 1, fullRect.X - 3, fullRect.Y, fullRect.Width + 6, fullRect.Height);

                
                #if DEBUG_GNODE
                TGraphics.FillRect(g, Color.FromArgb(0, 0, 200), fullRect.X, fullRect.Y, fullRect.Width, fullRect.Height);
                //TGraphics.FillRect(g, Color.Yellow, collapseRect);
                if(Icon1.Active)
                    TGraphics.FillRect(g, Color.Orange, icon1Rect);
                if(Icon2.Active)
                    TGraphics.FillRect(g, Color.Magenta, icon2Rect);
                VampirioGraphics.FillRect(g, Color.FromArgb(30, 30, 30), textRect.X, textRect.Y, textRect.Width, textRect.Height);
                #endif

                Font font = Font;



                VampirioGraphics.DrawString(g, font, Text, Color.Silver, textRect.X, textRect.Y);// + (FullRect.Height >> 1) - (textRect.Height >> 1));

                int key = -1;


                if (node.IsExpandible)
                {
                    if ((collapseIconKey != -1) && (collapseIconSelectedKey != -1))
                    {
                        if (node.IsExpanded)
                            DrawIcon(g, 0, collapseIconSelectedKey, CollapseIcon.PositionMode);
                        else
                            DrawIcon(g, 0, collapseIconKey, CollapseIcon.PositionMode);
                    }
                    else if (collapseIconKey != -1)
                    {
                        if (node.IsExpanded)
                            TGraphics.DrawExpandCollapseIcon(g, treeView, node, collapseRect);
                        else
                            DrawIcon(g, 0, collapseIconKey, CollapseIcon.PositionMode);
                    }
                    else if (collapseIconSelectedKey != -1)
                    {
                        if (node.IsExpanded)
                            DrawIcon(g, 0, collapseIconSelectedKey, CollapseIcon.PositionMode);
                        else
                            TGraphics.DrawExpandCollapseIcon(g, treeView, node, collapseRect);
                    }
                    else
                        TGraphics.DrawExpandCollapseIcon(g, treeView, node, collapseRect);

                }

                if ((icon1Key != -1) && treeView.Icon1.Active)
                    DrawIcon(g, 1, icon1Key, Icon1.PositionMode);

                if ((icon2Key != -1) && treeView.Icon2.Active)
                    DrawIcon(g, 2, icon2Key, Icon2.PositionMode);

            }
        }
    }
}
