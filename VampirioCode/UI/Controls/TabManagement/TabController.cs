using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.VampGraphics;

namespace VampirioCode.UI.Controls.TabManagement
{
    public class TabController
    {
        public delegate void SelectedTabChangedEvent(int index, TabItem item);
        public delegate void TabAddedEvent(int index, TabItem item);
        public delegate void TabRemovedEvent(int index, TabItem item);
        public delegate void StartDragTabEvent(int index, TabItem item);
        public delegate void StopDragTabEvent(int index, TabItem item);
        public event SelectedTabChangedEvent SelectedTabChanged;
        public event TabAddedEvent TabAdded;
        public event TabRemovedEvent TabRemoved;
        public event StartDragTabEvent StartDragTab;
        public event StopDragTabEvent StopDragTab;

        // IMPORTANT: A global offset position used to shift all the tabs to the left or right
        //            This variable is used to calculate LocalToGlobal() and GlobalToLocal()
        public int OFFSET_X = -1100; 

        private int width = 400;
        private int height = 30;
        private int mouseX = -1;
        private int mouseY = -1;
        private bool mouseDown = false;

        public List<Tab> tabs = new List<Tab>();                // The complete tabs list including the selected and dragged tab
        private Tab SelectedTab = null;                         // The tab the user is dragging or moving from left to right
        private List<Tab> NonSelectedTabs = new List<Tab>();    // This list include all the other tabs rather than the selected one that is being dragged
        private int selTabPreviousX = 0;                        // Register the start x position of the selected tab on MouseDown or Start Drag to calculate in which direction it is moving. On every Update loop it is reset again.
        private Tab prevSelectedTab = null;                     // Used to trigger events on tab changed
        private Font font;
        private bool freezeMoveLeft = false;
        private bool freezeMoveRight = false;

        public int TotalTabs { get { return tabs.Count; } }                         // Total amount of tabs
        public bool IsDragging { get; set; } = false;                               // SelectedTab is being dragged
        public bool IsAnySelected { get { return SelectedTab != null; } }           // There is a selected tab
        public bool IsOutsideBounds { get { return TotalWidth(tabs) > width; } }    // Any or many tabs are outside screen because they can't fit inside it
        public bool TabsFitOnScreen { get { return !IsOutsideBounds; } }            // All tabs fit inside the screen. No tab is outside 
        public int SelectedIndex { get { if (SelectedTab == null) return -1; else return SelectedTab.Index(); } set { if (TotalTabs > 0) { PushSelTabForEvent(); SimpleSelect(tabs[value]); PopSelTabChangedEvent();  } else throw new Exception("Tab index doesn't exist. Can't be selected."); } }
        public int TabVisibleLimit { get; set; } = 10; // Represents a fixed number of pixels that determines a minimum visible part of the tab when it is out of the screen.

        public TabController()
        {
            font = new Font("Verdana", 14, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        #region BasicActions
        public void Add(TabItem item)
        {
            Insert(TotalTabs, item);
        }

        public void Insert(int index, TabItem item)
        {
            Tab tab = new Tab(item, font, this);
            int totals = TotalTabs;

            // store current selected tab
            PushSelTabForEvent();

            tabs.Insert(index, tab);
            ResetPositionsFrom(index);

            if (!IsAnySelected)
                SimpleSelect(tab);

            // added event
            if (TabAdded != null)
                TabAdded(tab.Index(), item);

            // event trigger
            PopSelTabChangedEvent();
        }

        public void RemoveAt(int index)
        {
            Tab removedTab = null;

            // store current selected tab
            PushSelTabForEvent();

            if (TotalTabs <= 0)
            {
                throw new Exception("Can't remove an item because array is empty");
            }


            removedTab = tabs[index];

            if (TotalTabs == 1)
            {
                
                tabs.RemoveAt(index);
                SimpleSelect(null);// SelectedTab = null;
                OFFSET_X = 0;
            }
            else // TotalTabs > 1
            {
                // current tab to remove is the selected one
                if (SelectedTab == tabs[index])
                {
                    tabs.RemoveAt(index);

                    // SelectedTab was at index 0
                    if (index == 0)
                        SimpleSelect(tabs[0]);
                    else // index > 0
                        SimpleSelect(tabs[index - 1]);
                }
                else
                {
                    tabs.RemoveAt(index);
                }

                ResetPositionsFrom(index);

                // if all tabs fit inside screen
                if (TabsFitOnScreen)
                    OFFSET_X = 0;
            }

            // remove event
            if (TabRemoved != null)
                TabRemoved(index, removedTab.item);

            // event trigger
            PopSelTabChangedEvent();

        }

        private void PushSelTabForEvent()
        {
            prevSelectedTab = SelectedTab;
        }

        private void PopSelTabChangedEvent()
        {
            if (SelectedTab == null)
            {
                SelectedTabChanged(-1, null);
            }
            else if (prevSelectedTab != SelectedTab)
            {
                if (SelectedTabChanged != null)
                    SelectedTabChanged(SelectedTab.Index(), SelectedTab.item);
            }
        }
        #endregion

        #region Events
        // --------------------------------------------------------
        //
        // External Events
        //
        // --------------------------------------------------------

        // Triggered by the parent container when he changes his size
        public void SizeChange(int width, int height)
        {
            int prevWidth = this.width;

            //
            // Rearange Tabs positions when enlarging container to the right
            //
            if (width > prevWidth)
            {
                if (IsOutsideBounds)
                {
                    OFFSET_X += width - prevWidth;
                    if (OFFSET_X > 0)
                        OFFSET_X = 0;
                }
            }

            // Set new size
            this.width =    width;
            this.height =   height;
        }

        // Triggered by the parent container when the mouse is down
        public void MouseDown(int x, int y)
        {
            mouseX = x - OFFSET_X;
            mouseY = y;
            mouseDown = true;

            foreach (Tab tab in tabs)
            {
                tab.OnMouseDown(mouseX, mouseY);
            }
            //XConsole.Println("mouse down");
        }

        // Triggered by the parent container when the mouse moves
        public void MouseMove(int x, int y, bool mouseDown)
        {
            mouseX = x - OFFSET_X;
            mouseY = y;
            this.mouseDown = mouseDown;

            if (IsDragging)
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

        // Triggered by the parent container when the mouse is up
        public void MouseUp(int x, int y)
        {
            mouseX = x - OFFSET_X;
            mouseY = y;
            mouseDown = false;
            foreach (Tab tab in tabs)
                tab.OnMouseUp(mouseX, mouseY);
        }

        // Triggered by the parent container when the mouse leaves
        public void MouseLeave()
        {
            foreach (Tab tab in tabs)
                tab.OnMouseLeave();
        }

        // Triggered by the parent container when the mouse scrolls
        public void MouseScroll(int x, int y, int direction)
        {
            mouseX = x - OFFSET_X;
            mouseY = y;

            if (IsOutsideBounds)
            {
                OFFSET_X += direction * 25;

                // move to the right -->
                if (direction >= 1)
                {
                    if (OFFSET_X > 0)
                        OFFSET_X = 0;
                }
                // move to the left <--
                else
                {
                    int diff = TotalWidth(tabs) + OFFSET_X;

                    if(diff < width)
                        OFFSET_X =  - (TotalWidth(tabs) - width);
                }
            }

            MouseMove(x, y, false);

        }
        // --------------------------------------------------------


        // --------------------------------------------------------
        //
        // Internal Tab Events
        //
        // --------------------------------------------------------
        public void StartDragging(Tab selTab)
        {
            PushSelTabForEvent();

            Select(selTab);
            selTabPreviousX = LocalToGlobal(selTab.x);
            IsDragging = true;

            PopSelTabChangedEvent();

            if (StartDragTab != null)
                StartDragTab(selTab.Index(), selTab.item);

        }

        public void StopDragging()
        {
            IsDragging = false;
            NonSelectedTabs = new List<Tab>();

            ResetPositions();

            if (StopDragTab != null)
                StopDragTab(SelectedTab.Index(), SelectedTab.item);
        }
        // --------------------------------------------------------
        #endregion

        #region Utils
        // A simple version of Select() that do not perform
        // a loop to unselect other tabs.
        // Only use it when you know that other tabs aren't selected
        private void SimpleSelect(Tab selTab)
        {
            NonSelectedTabs = new List<Tab>();
            SelectedTab = selTab;

            if (SelectedTab != null)
                SelectedTab.Select();
        }

        // Select a Tab so it can be highlighted and easy to process.
        // Also the non selected tabs are separated on a different list
        // for the same reason
        private void Select(Tab selTab)
        {
            NonSelectedTabs = new List<Tab>();

            foreach (Tab tab in tabs)
            {
                if (tab == selTab)
                    SelectedTab = tab;
                else
                {
                    tab.Unselect();
                    NonSelectedTabs.Add(tab);
                }
            }

            //selTabPreviousX = LocalToGlobal(SelectedTab.x);

            SelectedTab.Select();
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
            return position + OFFSET_X;
        }

        // Calculate Local position from Local one
        private int GlobalToLocal(int position)
        { 
            return position - OFFSET_X;
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
            if (!selectedAdded)
                newList.Add(SelectedTab);

            tabs = newList;
        }


        //
        // Reset visual positions but do not touch the tabs array
        //
        private void ResetPositions()
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

        private void ResetPositionsFrom(int index)
        {
            // Recalculate x positions
            for (int a = index; a < tabs.Count; a++)
            {
                Tab tab = tabs[a];

                if (a == 0)
                    tab.SetPos(0, 0);
                else
                    tab.SetPos(tabs[a - 1].Right, 0);
            }
        }

        private bool IsInsideScreen(Tab tab)
        {
            int left = LocalToGlobal(tab.Left);
            int right = LocalToGlobal(tab.Right);

            if (left >= 0 && left <= width)
                return true;
            else if (right <= width && right >= 0)
                return true;
            else if (left <= 0 && right >= 0)
                return true;
            else
                return false;
        }
        #endregion

        #region UpdateAndPaint
        //
        // Update switching locations to left or right when dragging
        //

        private void UpdateSwitching()
        {
            bool passesSelected = false;
            int moveDirection;

            if (IsDragging)
            {
                SelectedTab.y = 4;

                #region MovingDirection
                // Calculate moving direction to know if moving to the left or right
                moveDirection =     LocalToGlobal(SelectedTab.x) - selTabPreviousX;
                selTabPreviousX =   LocalToGlobal(SelectedTab.x);
                #endregion


                #region MouseOffsetReset
                #region help
                // 
                // Mouse Offset Reset:
                //        When a tab is dragged and passes the limits of the screen, if the mouse returns, then
                //        the dragged offset change and the tab is moving but the mouse is not inside the tab.
                //        So to fix this issue we must reset and lock these offsets when mouse is outside range
                //        and still not return to the first dragged position of the tab
                //
                //
                // Example:
                //   
                //         
                //              ___________________________________
                //             |    |███████████|██████|██████|    |
                //                       ▲ 
                //
                //             1. user pick up a tab
                //
                //                                
                //             0         ┌ dragOffsetPointX
                //             ↓_________↓_________________________
                //             |    |▓▓▓▓▒▓▓▓▓▓▓|██████|██████|    |
                //                       ▲
                //                     Mouse
                //
                //             2. drag a tab to the left. (check out that the arrow denotes the dragOffsetPointX)
                //
                //             0
                //             ↓___________________________________
                //     |▓▓▓▓▒▓▓|▓▓▓▓|           |██████|██████|    |   freezeMoveLeft = true
                //          ▲     ↑
                //        Mouse   TabVisibleLimit
                //
                //             3. mouse has passed the left screen limit and also reach TabVisibleLimit so tab stay frozen
                //                and we register 'freezeMoveLeft' to TRUE. This is very important. Later 'freezeMoveLeft' will be used
                //                
                //              ___________________________________
                //     |▓▓▓▓▒▓▓|▓▓▓▓|           |██████|██████|    |
                //   ▲            ↑
                // Mouse          TabVisibleLimit
                //   
                //             4. Tab can't be moved further to the left but the mouse has no limits,
                //                so it continues to the left
                //   
                //    [ BAD ]    ___________________________________
                //    [ BAD ]   |    |▓▓▓▓▒▓▓▓▓▓▓|██████|██████|    |   
                //    [ BAD ]      ▲            
                //               Mouse          
                //
                //             5. If we don't fix it, and mouse moves now to the right, then mouse will not be inside tab
                //                and will be dragging an empty space and after this is the tab. So it's not okay
                //
                //          ┌ dragOffsetPointX
                //          ↓   ___________________________________
                //     |▓▓▓▓▒▓▓|▓▓▓▓|           |██████|██████|    |
                //          ▲     ↑
                //        Mouse   TabVisibleLimit
                //
                //             6. To fix the issue we must continue freezing the tab while 'freezeMoveLeft' is TRUE
                //             The mouse continue to the right until it reaches the 'dragOffsetPointX' again and unlock the freeze.
                //             
                //
                //    [ OK ]             ┌ dragOffsetPointX
                //    [ OK ]    _________↓_________________________
                //    [ OK ]   |    |▓▓▓▓▒▓▓▓▓▓▓|██████|██████|    |
                //                       ▲
                //                     Mouse
                //
                //             7. Finally the mouse will drag the tab again using the same start drag position (dragOffsetPointX)
                //
                #endregion
                
                //
                // Frozen Tab with mouse on the left and out of the screen
                //
                if (freezeMoveLeft)
                {
                    // 
                    // dragOffsetPointX  0                              dragOffsetPointX  0                               
                    //                ↓  ↓_________________________                    ↓  ↓_________________________       
                    //           |▓▓▓▓▒▓▓|▓▓▓▓|      |██████|██████|              |▓▓▓▓▒▓▓|▓▓▓▓|      |██████|██████|         
                    //       ▲               IF( FALSE )                               ▲      IF( TRUE )             
                    //    [Mouse]                                                   [Mouse]                                       
                    if (LocalToGlobal(mouseX) > (LocalToGlobal(SelectedTab.x + SelectedTab.dragOffsetPointX)))
                    {
                        // Mouse returns to the 'dragOffsetPointX' so we can release the freeze of the tab
                        SelectedTab.x =     mouseX - SelectedTab.dragOffsetPointX;
                        selTabPreviousX =   LocalToGlobal(SelectedTab.x);
                        freezeMoveLeft =    false;
                    }
                    // 
                    // dragOffsetPointX  0                           
                    //                ↓  ↓_________________________  
                    //           |▓▓▓▓▒▓▓|▓▓▓▓|      |██████|██████| 
                    //             ▲                  
                    //          [Mouse]
                    else if (moveDirection > 0)
                    {
                        // Mouse moving to the right but not reach 'dragOffsetPointX' yet so we must freeze the tab in its position
                        SelectedTab.x -=    moveDirection;
                        selTabPreviousX =   LocalToGlobal(SelectedTab.x);
                    }

                }
                // Tab is outside screen to the left and dragged point of the tab also passed
                //
                // dragOffsetPointX  0
                //                ↓  ↓___________________________________
                //           |▓▓▓▓▒▓▓|▓▓▓▓|           |██████|██████|    |   freezeMoveLeft = true
                //           x    ▲     ↑
                //             [Mouse]  TabVisibleLimit
                //       
                else if (LocalToGlobal(SelectedTab.x + SelectedTab.dragOffsetPointX) < 0)
                {
                    freezeMoveLeft = true;
                }


                //
                // Frozen Tab with mouse on the right and out of the screen
                //
                if (freezeMoveRight)
                {
                    if (LocalToGlobal(mouseX) < (LocalToGlobal(SelectedTab.x + SelectedTab.dragOffsetPointX)))
                    {
                        SelectedTab.x =     mouseX - SelectedTab.dragOffsetPointX;
                        selTabPreviousX =   LocalToGlobal(SelectedTab.x);
                        freezeMoveRight =   false;
                    }
                    else if (moveDirection < 0)
                    {
                        SelectedTab.x -= moveDirection;
                        selTabPreviousX = LocalToGlobal(SelectedTab.x);
                    }

                }
                else if (LocalToGlobal(SelectedTab.x + SelectedTab.dragOffsetPointX) > width)
                {
                    freezeMoveRight = true;
                }
                #endregion


                #region Shifting
                //
                // Shifting:
                //           when a dragged tab goes to the left or right and there are more tabs
                //           outside screen, then we increment or decrement a global variable called
                //           OFFSET_X to reach those tabs, so all tabs are shifted to the left or right
                //

                // Mouse is moving to the left  <--
                if (moveDirection < 0)
                {
                    if (LocalToGlobal(SelectedTab.Left) < 0)
                        OFFSET_X -= moveDirection;

                    // If we reach the end, stop and clamp the offset to 0
                    if (OFFSET_X > 0)
                        OFFSET_X = 0;
                }
                // Mouse is moving to the right  -->
                else if (moveDirection > 0)
                {
                    if (LocalToGlobal(SelectedTab.Right) > width)
                        OFFSET_X -= moveDirection;

                    int lastPos =           LocalToGlobal(NonSelectedTabs[NonSelectedTabs.Count - 1].Right);
                    int totalWidth =        TotalWidth(tabs);
                    int nonSelTotWidth =    totalWidth - SelectedTab.width;

                    // All tabs enter inside the control
                    if (totalWidth < width)
                    {
                        if (lastPos < width - SelectedTab.width)
                            OFFSET_X = 0;
                    }
                    // Not all tabs enter inside the control
                    else
                    {
                        if (lastPos < width - SelectedTab.width)
                            OFFSET_X = -nonSelTotWidth + width - SelectedTab.width;
                    }

                }
                #endregion


                #region TabOutScreenLock
                //
                // Lock a dragged tab to a fixed position in order to maintain 
                // the tab visible on screen when the user drag the tab out the
                // screen to the left or right
                //
                // [out screen]     [inner screen]
                //       ______ _____________________________
                //      |▓▓▓▓▓▓|▓▓▓|    |██████|██████|██████|
                //             | ▲                           |
                //             | TabVisibleLimit             |
                //             |                             |
                //
                if (LocalToGlobal(SelectedTab.Right) < TabVisibleLimit)
                {
                    // 
                    SelectedTab.x =     GlobalToLocal(-SelectedTab.width + TabVisibleLimit);
                    selTabPreviousX =   LocalToGlobal(SelectedTab.x); //selTabPreviousX = -SelectedTab.width + 10; // this line works also here
                }
                else if (LocalToGlobal(SelectedTab.Left) > (width - TabVisibleLimit))
                {
                    SelectedTab.x =     GlobalToLocal(width - TabVisibleLimit);
                    selTabPreviousX =   LocalToGlobal(SelectedTab.x);
                }
                #endregion


                #region SwapTabs
                //
                // Swap tabs:
                //           A tab is swapped when the left or right border of the
                //           dragged tab passes the center of the next tab
                //
                foreach (Tab nonSelTab in NonSelectedTabs)
                {
                    // Mouse is moving to the left <--
                    if (moveDirection < 0)
                    {
                        // Left border of the dragged tab passes the center of the next tab
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
                    // Mouse is moving to the right -->
                    else if (moveDirection > 0)
                    {
                        // Right border of the dragged tab passes the center of the next tab
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
                #endregion


                RecalcIndices();
            }
        }

        //
        // Update method
        //
        public void Update()
        {
            /*if (IsAnySelected)
            {
                if (SelectedTab.IsDragging)
                {
                    if (LocalToGlobal(SelectedTab.Right) < 10)
                    {
                        XConsole.Println("moving");
                        SelectedTab.x = GlobalToLocal(-(SelectedTab.width - 10));
                        OFFSET_X += 2;
                    }
                }
            }*/

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

            foreach (Tab tab in tabs)
            {
                if (tab.Selected)
                    drawAtTopTab = tab;
                else if (IsInsideScreen(tab))
                    tab.Paint(g);
            }

            // leave this to draw at the end to bring 
            // it in front of the others
            if (drawAtTopTab != null && IsInsideScreen(drawAtTopTab))
                drawAtTopTab.Paint(g);

            // Debug painting
            PrintDebug(g);
        }
        #endregion

        #region Debug
        private void PrintDebug(Graphics g)
        {
            VampirioGraphics.DrawString(g, font, "OFFSET_X: " + OFFSET_X, Color.Magenta, 180, 100);

            // -------------------------
            int _startY_ = 100;

            if (IsDragging)
            {
                VampirioGraphics.DrawString(g, font, SelectedTab.item.Text, Color.Orange, 10, _startY_);
                _startY_ += 25;

                for (int a = 0; a < NonSelectedTabs.Count; a++)
                {
                    Tab nonSelTab = NonSelectedTabs[a];
                    Tab prevTab = GetPrevious(nonSelTab, NonSelectedTabs);
                    string prevStr = "  prev: ";
                    if (prevTab != null)
                        prevStr += prevTab.item.Text;

                    VampirioGraphics.DrawString(g, font, nonSelTab.item.Text + prevStr, Color.Red, 10, _startY_);
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

                VampirioGraphics.DrawString(g, font, tab.item.Text + "     x: " + tab.x, color, 180, _startY_);
                _startY_ += 15;
            }
            // --------------------------


        }
        #endregion

    }
}
