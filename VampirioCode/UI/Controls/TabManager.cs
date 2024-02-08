using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.VampGraphics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VampirioCode.UI.Controls
{

    public class Tab
    {
        enum State
        { 
            Over,
            Up
        }

        public bool IsDragging { get { return dragging; } }
        public bool DrawAtTop { get; set; }
        public bool Selected { get; set; }
        public int CenterX { get { return (x + (width >> 1)); } }
        public int Left { get { return x; } }
        public int Right { get { return (x + width); } }

        public int x, y, width, height;
        private State state = State.Up;
        public TabItem item;
        private Font font;
        private bool dragging;
        private int startDragX;
        private TabManager manager;
        //private Rectangle Rect { get { return new Rectangle(x, y, width, height); } }

        public Tab(TabItem item, Font font, TabManager manager)
        {
            this.x = 0;
            this.y = 0;
            this.width = item.Width;
            this.height = 25;
            this.item = item;
            this.font = font;
            this.dragging = false;
            this.startDragX = 0;
            this.DrawAtTop = false;
            this.Selected = false;
            this.manager = manager;
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

        // set this item at the top for drawing
        public void BringToFront()
        {
            DrawAtTop = true;
            Selected = true;
        }

        public void BringToBack()
        {
            DrawAtTop = false;
        }

        public void OnMouseDown(int mx, int my)
        {
            if (IsInside(mx, my))
            {
                startDragX = mx;
                dragging = true;
                manager.SelectAndBringToFront(this);
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
                manager.StopDragging();
            }

            state = State.Up;
        }

        private bool IsInside(int mx, int my)
        {
            return ((mx >= x) && (mx <= (x + width)) && (my >= y) && (my <= (y + height)));
        }

        public void Update()
        {

        }

        public void Paint(Graphics g)
        {
            Color backColor = Color.White;
            int _x_ = manager.OFFSET_X + x;

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
            VampirioGraphics.DrawString(g, font, item.Name, Color.Black, _x_, y, width, height, ContentAlignment.MiddleCenter);

            VampirioGraphics.FillRect(g, Color.Black, _x_ + (width >> 1) - 1, y, 3, 4);
        }

    }

    public class TabManager
    {
        public int OFFSET_X = -50;

        private int width = 400;
        private int height = 30;
        private int mouseX = -1;
        private int mouseY = -1;
        private bool mouseDown = false;
        // The complete tabs list including the selected and dragged tab
        private List<Tab> tabs = new List<Tab>();
        private Font font;
        // The tab the user is dragging or moving from left to right
        private Tab SelectedTab = null;
        // This list include all the other tabs rather than the selected one that is being dragged
        private List<Tab> NonSelectedTabs = new List<Tab>();
        // Register the start x position of the selected tab on MouseDown or Start Drag to
        // calculate in which direction it is moving. On every Update loop it is reset again.
        private int selTabPreviousX = 0;

        public Tab LastTab { get { if (tabs.Count == 0) return null; else return tabs[tabs.Count - 1]; } }
        private bool IsAnySelected { get { return (SelectedTab != null); } }
        public int TotalTabs { get { return tabs.Count; } }


        public TabManager()
        {
            font = new Font("Verdana", 14, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        public void Add(TabItem item)
        {
            Tab tab = new Tab(item, font, this);
            Tab lastTab = LastTab;
            tabs.Add(tab);

            if (lastTab != null)
                tab.SetPos(lastTab.x + lastTab.width, 0);
            else
                tab.SetPos(0, 0);
        }

        public void RemoveAt(int index)
        {
            tabs.RemoveAt(index);
        }

        public void MouseDown(int x, int y)
        {
            this.mouseX = x - OFFSET_X;
            this.mouseY = y;
            this.mouseDown = true;

            foreach (Tab tab in tabs)
            {
                tab.OnMouseDown(mouseX, mouseY);
            }
            //XConsole.Println("mouse down");
        }

        public void MouseMove(int x, int y, bool mouseDown)
        {
            this.mouseX = x - OFFSET_X;
            this.mouseY = y;
            this.mouseDown = mouseDown;

            if (IsAnySelected)
            {
                SelectedTab.OnMouseMove(mouseX, mouseY, mouseDown);
            }
            else
            {
                foreach (Tab tab in tabs)
                {
                    tab.OnMouseMove(mouseX, mouseY, mouseDown);
                }
            }

        }

        public void MouseUp(int x, int y)
        {
            this.mouseX = x - OFFSET_X;
            this.mouseY = y;
            this.mouseDown = false;
            foreach (Tab tab in tabs) tab.OnMouseUp(mouseX, mouseY);
            //XConsole.Println("mouse up")
        }

        public void SelectAndBringToFront(Tab selTab)
        {
            NonSelectedTabs = new List<Tab>();

            foreach (Tab tab in tabs)
            {
                if (tab == selTab)
                    SelectedTab = tab;
                else
                {
                    tab.BringToBack();
                    tab.Unselect();
                    NonSelectedTabs.Add(tab);
                }
            }

            selTabPreviousX = LocalToGlobal(SelectedTab.x);

            SelectedTab.Select();
            SelectedTab.BringToFront();
        }

        public void StopDragging()
        {
            SelectedTab = null;
            NonSelectedTabs = new List<Tab>();

            RecalculatePositions();
        }

        // Get previous tab. The currTab must be contained inside tabList
        // If there is no previous tab, null will be returned
        private Tab GetPrevious(Tab currTab, List<Tab> tabList)
        { 
            int index = tabList.IndexOf(currTab);

            if (index == 0)
                return null;
            else
                return tabList[index - 1];
        }


        // Calculate Global position from Local one
        private int LocalToGlobal(int position)
        {
            return (position + OFFSET_X);
        }

        // Calculate total width of all input tabs
        private int TotalWidth(List<Tab> tabsList)
        { 
            int totalWidth = 0;

            foreach (Tab tab in tabsList)
                totalWidth += tab.width;

            return totalWidth;
        }

        //
        // Recalculate tabs index positions inside tabs array 
        // 
        private void RecalcIndices()
        {
            List<Tab> newList = new List<Tab>();
            bool selectedAdded = false;

            foreach (Tab nonSelTab in NonSelectedTabs)
            {
                if (!selectedAdded)
                {
                    if (nonSelTab.x < SelectedTab.x)
                        newList.Add(nonSelTab);
                    else
                    {
                        newList.Add(SelectedTab);
                        newList.Add(nonSelTab);
                        selectedAdded = true;
                    }
                }
                else
                    newList.Add(nonSelTab);
            }

            // If selectedTab reach the end, it won't be added to the list
            // so check that and add it to the end
            if(!selectedAdded)
                newList.Add(SelectedTab);

            tabs = newList;
        }


        //
        // Recalculate visual positions but do not touch the tabs array
        //
        private void RecalculatePositions()
        {
            // Recalculate x positions
            for (int a = 0; a < tabs.Count; a++)
            {
                Tab tab = tabs[a];

                if (a == 0)
                    tab.SetPos(0, 0);
                else
                    tab.SetPos(tabs[a - 1].Right, 0);
            }
        }

        //
        // Update switching locations to left or right when dragging
        //
        private void UpdateSwitching()
        {
            bool passesSelected = false;
            int moveDirection;

            if (IsAnySelected)
            {
                SelectedTab.y = 4;


                // Calculate moving direction to know if moving to the left or right
                moveDirection = LocalToGlobal(SelectedTab.x) - selTabPreviousX;
                selTabPreviousX = LocalToGlobal(SelectedTab.x);


                //
                // Out of the screen shift
                //

                // Mouse is moving to the left
                if (moveDirection < 0)
                {
                    if (LocalToGlobal(SelectedTab.Left) < 0)
                        OFFSET_X -= moveDirection;

                    // If we reach the end, stop and clamp the offset to 0
                    if (OFFSET_X > 0)
                        OFFSET_X = 0;
                }
                // Mouse is moving to the right
                else if (moveDirection > 0)
                {
                    if (LocalToGlobal(SelectedTab.Right) > width)
                        OFFSET_X -= moveDirection;

                    int lastPos = LocalToGlobal(NonSelectedTabs[NonSelectedTabs.Count - 1].Right);

                    int totalWidth = TotalWidth(tabs);
                    int nonSelTotWidth = totalWidth - SelectedTab.width;

                    // All tabs enter inside the control
                    if (totalWidth < width)
                    {
                        if (lastPos < (width - SelectedTab.width))
                            OFFSET_X = 0;
                    }
                    // Not all tabs enter inside the control
                    else
                    {
                        if (lastPos < (width - SelectedTab.width))
                            OFFSET_X = -nonSelTotWidth + width - SelectedTab.width;
                    }

                }

                //XConsole.Println("offsetX: "+ OFFSET_X);

                //
                // Main loop to move tabs
                //
                foreach (Tab nonSelTab in NonSelectedTabs)
                {
                    // Mouse is moving to the left
                    if (moveDirection < 0)
                    {
                        if (SelectedTab.Left < nonSelTab.CenterX)
                        {
                            Tab prevTab = GetPrevious(nonSelTab, NonSelectedTabs);

                            if (prevTab == null)
                            {
                                nonSelTab.SetPos(SelectedTab.width, 0);
                                passesSelected = true;
                            }
                            else if (!passesSelected)
                            {
                                nonSelTab.SetPos(prevTab.Right + SelectedTab.width, 0);
                                passesSelected = true;
                            }
                            else
                                nonSelTab.SetPos(prevTab.Right, 0);
                        }
                    }
                    // Mouse is moving to the right
                    else if (moveDirection > 0)
                    {
                        if (SelectedTab.Right > nonSelTab.CenterX)
                        {
                            Tab prevTab = GetPrevious(nonSelTab, NonSelectedTabs);

                            // No previous tab. Start from the beginning
                            if (prevTab == null)
                                nonSelTab.SetPos(0, 0);
                            else
                                nonSelTab.SetPos(prevTab.x + prevTab.width, 0);
                        }
                    }
                }

                RecalcIndices();
            }
        }

        //
        // Update method
        //
        public void Update()
        {

            if (TotalTabs > 1)
                UpdateSwitching();
        }


        //
        // Paint method
        //
        public void Paint(Graphics g)
        {
            VampirioGraphics.FillRect(g, Color.FromArgb(90, 90, 90), 0, 0, width, height);

            Tab drawAtTopTab = null;
            int coun = 0;
            for (int a = 0; a < tabs.Count; a++)
            {
                Tab tab = tabs[a];

                if (tab.DrawAtTop)
                    drawAtTopTab = tab;
                else
                {
                    if (IsInsideScreen(tabs[a]))
                    {
                        coun++;
                        tabs[a].Paint(g);
                    }
                }
            }

            // leave this to draw at the end to bring 
            // it in front of the others
            if (drawAtTopTab != null)
            {
                if(IsInsideScreen(drawAtTopTab))
                    drawAtTopTab.Paint(g);
            }


            // Debug painting
            PrintDebug(g);
        }

        private bool IsInsideScreen(Tab tab)
        {
            int left =  LocalToGlobal(tab.Left);
            int right = LocalToGlobal(tab.Right);

            if ((left >= 0) && (left <= width))
                return true;
            else if((right <= width) && (right >= 0))
                return true;
            else if((left <= 0) && (right >= 0))
                return true;
            else
                return false;
        }

        private void PrintDebug(Graphics g) 
        {
            // -------------------------
            int _startY_ = 100;

            if (IsAnySelected)
            {
                VampirioGraphics.DrawString(g, font, SelectedTab.item.Name, Color.Orange, 10, _startY_);
                _startY_ += 25;

                for (int a = 0; a < NonSelectedTabs.Count; a++)
                {
                    Tab nonSelTab = NonSelectedTabs[a];
                    Tab prevTab = GetPrevious(nonSelTab, NonSelectedTabs);
                    string prevStr = "  prev: ";
                    if (prevTab != null)
                        prevStr += prevTab.item.Name;

                    VampirioGraphics.DrawString(g, font, nonSelTab.item.Name + prevStr, Color.Red, 10, _startY_);
                    _startY_ += 15;
                }
            }


            // -------------------------
            _startY_ = 125;

            for (int a = 0; a < tabs.Count; a++)
            {
                Tab tab = tabs[a];
                Color color = Color.Blue;

                if (tab == SelectedTab)
                    color = Color.Green;

                VampirioGraphics.DrawString(g, font, tab.item.Name + "     x: " + tab.x, color, 180, _startY_);
                _startY_ += 15;
            }
        }

    }
}
