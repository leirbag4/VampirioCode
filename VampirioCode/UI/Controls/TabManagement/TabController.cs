//
// PORTING CODE: if you want to port this code to another language like C++, it's best to disable the feature USE_AUTO_SHIFT_TIMERS and maybe remove the code by hand
//               because its implementation is a bit complex and harder to understand. Also, some part of the code was try and catch. So maybe a good idea is to 
//               write it again after porting the basic logic code.
//

#define TAB_CONTROLLER_DEBUG    // This will paint some debug info. IMPORTANT: note that the debugged text could be printed out of screen or canvas, so make this rendering context big
#define USE_AUTO_SHIFT_TIMERS   // USE_AUTO_SHIFT_TIMERS: can be removed because the auto shift features with timers is a little complex and if you want to port the code, maybe a good idea is to write it again.
#define AUTO_SHIFT_VERSION_B    // VERSION_A (ver_b commented): will compute more resources because it will use a numeri counter and a smallest timer. It could be easier to implement in other languages like C++
                                // VERSION_B: will use less resources because it will have a longer initial interval timer and then it will be set to a smaller one. Maybe best for C#, just test it.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing.Imaging;
using System.Linq;
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
        public delegate void TabIndexChangedEvent(int oldIndex, int newIndex);
        public event SelectedTabChangedEvent SelectedTabChanged;
        public event TabAddedEvent TabAdded;
        public event TabRemovedEvent TabRemoved;
        public event StartDragTabEvent StartDragTab;
        public event StopDragTabEvent StopDragTab;
        public event TabIndexChangedEvent TabIndexChanged;

        public int TabBorderSize { get; set; } = 2;
        public TabStyle SelectedStyle { get; } = new TabStyle(Color.FromArgb(49, 49, 49), Color.Silver, Color.FromArgb(31, 31, 31));
        public TabStyle NormalStyle { get; } = new TabStyle(Color.FromArgb(68, 68, 68), Color.Silver, Color.FromArgb(51, 51, 51));
        public TabStyle OverStyle { get; } = new TabStyle(Color.FromArgb(76, 76, 76), Color.Silver, Color.FromArgb(57, 57, 57));
        public TabShapeMode ShapeMode { get; set; } = TabShapeMode.Box;
        public TabSizeMode SizeMode { get; set; } = TabSizeMode.WrapToText;
        public int MinTabWidth { get { int minLimit = TabVisibleLimit << 1; if (minTabWidth < minLimit) return minLimit; else return minTabWidth; } set { minTabWidth = value; } }             // MinTabWidth must be always at least 2 times the visible part of the tab when it is outside screen. Otherwise you could't do an auto shift
        public int MaxTabWidth { get; set; } = 160;                                 // Maximum tabs width
        public int TabHeight { get; set; } = 25;
        public int TabPosY { get; set; } = 0;                                       // default y position of the tabs
        public int DraggedTabPosY { get; set; } = 4;                                // y position for a tab that is being dragged
        public int TotalTabs { get { return tabs.Count; } }                         // Total amount of tabs
        public bool IsDragging { get; set; } = false;                               // SelectedTab is being dragged
        public bool IsAnySelected { get { return selectedTab != null; } }           // There is a selected tab
        public bool IsOutsideBounds { get { return TotalWidth(tabs) > width; } }    // Any or many tabs are outside screen because they can't fit inside it
        public bool TabsFitOnScreen { get { return !IsOutsideBounds; } }            // All tabs fit inside the screen. No tab is outside 
        public int TabVisibleLimit { get; set; } = 10; // Represents a fixed number of pixels that determines a minimum visible part of the tab when it is out of the screen.
        public int SelectedIndex { get { if (selectedTab == null) return -1; else return selectedTab.Index(); } set { if (TotalTabs > 0) { PushSelTabForEvent(); SimpleSelect(tabs[value]); PopSelTabChangedEvent(); } } }
        public Tab SelectedTab { get { return selectedTab; } set { PushSelTabForEvent(); SimpleSelect(value); PopSelTabChangedEvent(); } }
        public bool AllowDragging { get; set; } = true;
        private Tab LastTab { get { if (tabs.Count == 0) return null; else return tabs[tabs.Count - 1]; } }

        #region AutoShiftProperties
        // -----------------------------------------------
        // AUTO SHIFT FEATURE
        // -----------------------------------------------
#if USE_AUTO_SHIFT_TIMERS
        public delegate void TimerRepaintNeededEvent();
        public event TimerRepaintNeededEvent TimerRepaintNeeded;
        public int PixelsShiftsPerStep { get; set; } = 10;  // [VERSION_A and VERSION_B]: the amount of pixels the tabs will move to the left or right on every auto shift movement with the timer
        public bool UpdateTimerNeeded { get { return _updateTimerNeeded; } }
        private bool _updateTimerNeeded = false;
    #if AUTO_SHIFT_VERSION_B
        public int MinTimerWait { get { return (_timerInterval >> 1); } set { _timerInterval = value; } } // [VERSION_B only]: minimum time to activate the auto shift features of tabs when user is dragging a tab to the left or right border of the bar or screen
        public int ShiftStepsMillis { get; set; } = 10; // [VERSION_B only]: once MinTimerWait has passed, this amount of milliseconds will be used on each step when shifting the tabs to the left or right

        private int _timerInterval = 300;
    #else
        public int TimerStepsMillis { get; set; } = 10;     // [VERSION_A only]: each step will be count in a loop and after some amount of steps (TimerMinStepsToShift), the tabs will be shifted to the right of left of the border they are
        public int TimerMinStepsToShift { get; set; } = 35; // [VERSION_A only]: for example if 10, then after (10 * TimerStepsMillis), the auto shifting process starts and then just one step or TimerStepsMillis will be used for each frame and shift
    #endif
        private bool autoShiftTimer = false;
        private int timerPosX = 0;
        private int timerCount = 0;
        private bool timerMoveLeft = false;
        private bool timerMoveRight = false;
        private System.Windows.Forms.Timer timer;
#endif
        // -----------------------------------------------
        #endregion


        // IMPORTANT: A global offset position used to shift all the tabs to the left or right
        //            This variable is used to calculate LocalToGlobal() and GlobalToLocal()
        public int OFFSET_X = 0;

        private int width = 400;
        private int height = 30;
        private int mouseX = -1;
        private int mouseY = -1;
        private bool mouseDown = false;

        public List<Tab> tabs = new List<Tab>();                // The complete tabs list including the selected and dragged tab
        private Tab selectedTab = null;                         // The tab the user is dragging or moving from left to right
        private List<Tab> nonSelectedTabs = new List<Tab>();    // This list include all the other tabs rather than the selected one that is being dragged
        private int selTabPreviousX = 0;                        // Register the start x position of the selected tab on MouseDown or Start Drag to calculate in which direction it is moving. On every Update loop it is reset again.
        private Tab prevSelectedTab = null;                     // Used to trigger events on tab changed
        private int savedTotalWidth = 0;                        // Will be calculated only at StartDrag event in order to reduce compute time
        private int prevSelectedIndexTab = 0;                        // Will be calculated in conjunction with StartDrag and StopDrag event to check if index position changed
        private Font font;
        private bool freezeMoveLeft = false;
        private bool freezeMoveRight = false;
        private int minTabWidth = 60;


        public TabController()
        {
            font = new Font("Verdana", 14, FontStyle.Regular, GraphicsUnit.Pixel);

#if USE_AUTO_SHIFT_TIMERS
            timer = new System.Windows.Forms.Timer();
            timer.Tick += OnTimerTick;
    #if AUTO_SHIFT_VERSION_B
            timer.Interval = MinTimerWait;
    #else
            timer.Interval = TimerStepsMillis;
    #endif
#endif
        }

        #region BasicActions
        public void Add(TabItem item)
        {
            Insert(TotalTabs, item);
        }

        public void Insert(int index, TabItem item)
        {
            //Tab tab = new Tab(item, font, this);
            Tab tab = item.tab;
            tab.Setup(this, font, TabHeight);
            item.Setup(this);
            //tab.Width = TabWidth;
            //item.tab.height = TabHeight;
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

        public void Remove(TabItem tab)
        {
            RemoveAt(tab.Index);
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
                if (selectedTab == tabs[index])
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

                // reposition tabs and also check if they fit on screen to make an adjustment to OFFSET_X
                AdjustTabsFrom(index);
            }

            // remove event
            if (TabRemoved != null)
                TabRemoved(index, removedTab.Item);

            // event trigger
            PopSelTabChangedEvent();

        }

        public void RemoveAllTabs()
        {
            selectedTab = null;
            tabs = new List<Tab>();
            nonSelectedTabs = new List<Tab>();
            selTabPreviousX = 0;
            OFFSET_X = 0;
        }

        public Tab GetTabAt(int index)
        {
            return tabs[index];
        }

        public void BringTabIntoScreen(Tab tab)
        {
            // If released tab is outside the screen, on the left, then scroll OFFSET_X up to its position
            if (LocalToGlobal(tab.X) < 0)
            {
                OFFSET_X -= LocalToGlobal(tab.X);
            }
            // If released tab is outside the screen, on the right, then scroll OFFSET_X up to its position
            else if (LocalToGlobal(tab.Right) > width)
            {
                OFFSET_X -= LocalToGlobal(tab.Right) - width;
            }
        }

        private void PushSelTabForEvent()
        {
            prevSelectedTab = selectedTab;
        }

        private void PopSelTabChangedEvent()
        {
            if (selectedTab == null)
            {
                SelectedTabChanged(-1, null);
            }
            else if (prevSelectedTab != selectedTab)
            {
                if (SelectedTabChanged != null)
                    SelectedTabChanged(selectedTab.Index(), selectedTab.Item);
            }
        }

        // Used in conjunction with 'PopSelTabIndexChangedEvent' to know if a tab change its index
        // position, for example when a user drag a tab, pass another tab and then release it.
        // In that case the index changed
        private void PushSelTabIndexForEvent()
        {
            prevSelectedIndexTab = selectedTab.Index();
        }

        // Used in conjunction with 'PushSelTabIndexForEvent' to know if a tab change its index
        // position, for example when a user drag a tab, pass another tab and then release it.
        // In that case the index changed
        private void PopSelTabIndexChangedEvent()
        {
            if (prevSelectedIndexTab != selectedTab.Index())
            {
                if (TabIndexChanged != null)
                    TabIndexChanged(prevSelectedIndexTab, selectedTab.Index());
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
                if ((LastTab != null) && (LocalToGlobal(LastTab.Right) < width))
                {
                    OFFSET_X += width - prevWidth;
                    if (OFFSET_X > 0)
                        OFFSET_X = 0;
                }
            }

            // Set new size
            this.width = width;
            this.height = height;
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
                if (mouseDown)
                    selectedTab.OnMouseMove(mouseX, mouseY, mouseDown);
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

                    if (diff < width)
                        OFFSET_X = -(TotalWidth(tabs) - width);
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
        private void OnDraggingAnim(Tab tab)
        {
            selectedTab.Y = DraggedTabPosY;
        }


        public void StartDragging(Tab selTab)
        {
            PushSelTabForEvent();

            Select(selTab);
            selTabPreviousX = LocalToGlobal(selTab.X);
            savedTotalWidth = TotalWidth(tabs);
            IsDragging = true;

            PushSelTabIndexForEvent();

            PopSelTabChangedEvent();

            if (StartDragTab != null)
                StartDragTab(selTab.Index(), selTab.Item);

        }

        public void StopDragging()
        {
            IsDragging = false;
            nonSelectedTabs = new List<Tab>();

            //StopTimer();

            // Reset local (relative) tab positions
            ResetPositions();

            BringTabIntoScreen(selectedTab);

#if USE_AUTO_SHIFT_TIMERS
            StopAutoShift();
#endif
            // Events
            PopSelTabIndexChangedEvent();

            if (StopDragTab != null)
                StopDragTab(selectedTab.Index(), selectedTab.Item);
        }
        // --------------------------------------------------------
        #endregion

        #region Utils
        // A simple version of Select() that do not perform
        // a loop to unselect other tabs.
        // Only use it when you know that other tabs aren't selected
        private void SimpleSelect(Tab selTab)
        {
            if (selectedTab != null)
                selectedTab.Unselect();

            nonSelectedTabs = new List<Tab>();
            selectedTab = selTab;

            if (selectedTab != null)
                selectedTab.Select();
        }

        // Select a Tab so it can be highlighted and easy to process.
        // Also the non selected tabs are separated on a different list
        // for the same reason
        private void Select(Tab selTab)
        {
            nonSelectedTabs = new List<Tab>();

            foreach (Tab tab in tabs)
            {
                if (tab == selTab)
                    selectedTab = tab;
                else
                {
                    tab.Unselect();
                    nonSelectedTabs.Add(tab);
                }
            }

            //selTabPreviousX = LocalToGlobal(SelectedTab.x);

            selectedTab.Select();
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
                totalWidth += tab.Width;

            return totalWidth;
        }

        private void SwapTabs(int moveDirection)
        {
            bool passesSelected = false;

            //
            // Swap tabs:
            //           A tab is swapped when the left or right border of the
            //           dragged tab passes the center of the next tab
            //
            foreach (Tab nonSelTab in nonSelectedTabs)
            {
                // Mouse is moving to the left <--
                if (moveDirection < 0)
                {
                    // Left border of the dragged tab passes the center of the next tab
                    if (selectedTab.Left < nonSelTab.CenterX)
                    {
                        Tab prevTab = GetPrevious(nonSelTab, nonSelectedTabs);

                        if (prevTab == null)
                        {
                            nonSelTab.SetPos(selectedTab.Width, TabPosY);
                            passesSelected = true;
                        }
                        else if (!passesSelected)
                        {
                            nonSelTab.SetPos(prevTab.Right + selectedTab.Width, TabPosY);
                            passesSelected = true;
                        }
                        else
                            nonSelTab.SetPos(prevTab.Right, TabPosY);
                    }
                }
                // Mouse is moving to the right -->
                else if (moveDirection > 0)
                {
                    // Right border of the dragged tab passes the center of the next tab
                    if (selectedTab.Right > nonSelTab.CenterX)
                    {
                        Tab prevTab = GetPrevious(nonSelTab, nonSelectedTabs);

                        // No previous tab. Start from the beginning
                        if (prevTab == null)
                            nonSelTab.SetPos(0, TabPosY);
                        else
                            nonSelTab.SetPos(prevTab.X + prevTab.Width, TabPosY);
                    }
                }
            }
        }

        //
        // Recalculate tabs index positions inside tabs array 
        // 
        private void RecalcIndices()
        {
            List<Tab> newList = new List<Tab>();
            bool selectedAdded = false;

            foreach (Tab nonSelTab in nonSelectedTabs)
            {
                if (!selectedAdded)
                {
                    if (nonSelTab.X < selectedTab.X)
                        newList.Add(nonSelTab);
                    else
                    {
                        newList.Add(selectedTab);
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
                newList.Add(selectedTab);

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
                    tab.SetPos(0, TabPosY);
                else
                    tab.SetPos(tabs[a - 1].Right, TabPosY);
            }
        }

        private void ResetPositionsFrom(int index)
        {
            // Recalculate x positions
            for (int a = index; a < tabs.Count; a++)
            {
                Tab tab = tabs[a];

                if (a == 0)
                    tab.SetPos(0, TabPosY);
                else
                    tab.SetPos(tabs[a - 1].Right, TabPosY);
            }
        }

        // Recalculate positions using x and width of each tab and
        // also adjust the OFFSET_X in case that all tabs fits on screen
        public void AdjustTabsFrom(int index)
        {
            ResetPositionsFrom(index);

            // if all tabs fit inside screen
            if (TabsFitOnScreen)
                OFFSET_X = 0;
            else
            {
                if (LocalToGlobal(LastTab.Right) < width)
                    AdjustFromRightToLeft();
            }
        }

        // Adjust tabs from right to left in the global or absolute position
        // system using OFFSET_X
        private void AdjustFromRightToLeft()
        {
            OFFSET_X = width - TotalWidth(tabs);
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

        private void FixPositionToMouse()
        {
            selectedTab.X = mouseX - selectedTab.dragOffsetPointX;
            selTabPreviousX = LocalToGlobal(selectedTab.X);
        }


#if USE_AUTO_SHIFT_TIMERS

    #if AUTO_SHIFT_VERSION_B
        private void StopAutoShift()
        {
    
            timer.Interval = MinTimerWait;
            timer.Stop();
            timerCount = 0;
            timerMoveLeft = false;
            timerMoveRight = false;
            autoShiftTimer = false;
        }
    #else
        private void StopAutoShift()
        {
            timer.Stop();
            timerCount = 0;
            timerMoveLeft = false;
            timerMoveRight = false;
            autoShiftTimer = false;
        }
    #endif
#endif

        #endregion

        #region AutoShiftUpdate
#if USE_AUTO_SHIFT_TIMERS
#if AUTO_SHIFT_VERSION_B
        private void OnTimerTick(object? sender, EventArgs e)
        {
            if (!autoShiftTimer)
            {
                if (timerMoveLeft)
                {
                    if (LocalToGlobal(selectedTab.X) >= 0)
                    {
                        timer.Interval = MinTimerWait;
                        timer.Stop();
                        return;
                    }

                    if (timerPosX != LocalToGlobal(selectedTab.X))
                    {
                        timerPosX = LocalToGlobal(selectedTab.X);
                        return;
                    }

                    autoShiftTimer = true;

                }
                else if (timerMoveRight)
                {
                    if (LocalToGlobal(selectedTab.Right) <= width)
                    {
                        timer.Interval = MinTimerWait;
                        timer.Stop();
                        return;
                    }

                    if (timerPosX != LocalToGlobal(selectedTab.X))
                    {
                        timerPosX = LocalToGlobal(selectedTab.X);
                        return;
                    }

                    autoShiftTimer = true;
                    
                }
            }
            else
            {

                if (TimerRepaintNeeded != null)
                {
                    _updateTimerNeeded = true;
                    TimerRepaintNeeded();
                }
            }
        }
#else
        private void OnTimerTick(object? sender, EventArgs e)
        {
            if (!autoShiftTimer)
            {
                if (timerMoveLeft)
                {
                    if (LocalToGlobal(selectedTab.x) >= 0)
                    {
                        timer.Stop();
                        timerCount = 0;
                        return;
                    }

                    if (timerPosX != LocalToGlobal(selectedTab.x))
                    {
                        timerPosX = LocalToGlobal(selectedTab.x);
                        timerCount = 0;
                        return;
                    }

                    timerCount++;

                    if (timerCount == TimerMinStepsToShift)
                    {
                        timerCount = TimerMinStepsToShift;
                        autoShiftTimer = true;
                    }
                }
                else if (timerMoveRight)
                {
                    if (LocalToGlobal(selectedTab.Right) <= width)
                    {
                        timer.Stop();
                        timerCount = 0;
                        return;
                    }

                    if (timerPosX != LocalToGlobal(selectedTab.x))
                    {
                        timerPosX = LocalToGlobal(selectedTab.x);
                        timerCount = 0;
                        return;
                    }

                    timerCount++;

                    if (timerCount == TimerMinStepsToShift)
                    {
                        timerCount = TimerMinStepsToShift;
                        autoShiftTimer = true;
                    }
                }
            }
            else
            {
                timerCount++;

                if (timerCount > TimerMinStepsToShift)
                    timerCount = TimerMinStepsToShift;

                if (TimerRepaintNeeded != null)
                {
                    _updateTimerNeeded = true;
                    TimerRepaintNeeded();
                }
            }
        }
#endif

        private bool PreComputeTimer()
        { 
            if (autoShiftTimer && selectedTab.IsDragging)
            {
                OnDraggingAnim(selectedTab);


                if (timerMoveLeft)
                {
                    FixPositionToMouse();

                    if (LocalToGlobal(selectedTab.X) >= 0)
                    {
                        StopAutoShift();
                    }
                    // Code will pass down here on mouse events like 'OnMove' at the same time
                    // our timer loop for auto move is running
                    else
                    {

                        //             0
                        //             ↓___________________________________
                        //     |▓▓▓▓▒▓▓|▓▓▓▓|           |██████|██████|    |   freezeMoveLeft = true
                        //          ▲     ↑
                        //        Mouse   TabVisibleLimit
                        if (LocalToGlobal(selectedTab.Right) < TabVisibleLimit)
                        {

                            int newX = GlobalToLocal(-selectedTab.Width + TabVisibleLimit);
                            int diff = selectedTab.X - newX;
                            selectedTab.GlobalMoveX(-diff);
                        }

                        return false;
                    }
                }
                else if (timerMoveRight)
                {
                    //XConsole.Println("RIIIIIIIIIIIIIIIIIIIGHT");

                    FixPositionToMouse();

                    if (LocalToGlobal(selectedTab.Right) <= width)
                    {
                        StopAutoShift();
                    }
                    // Code will pass down here on mouse events like 'OnMove' at the same time
                    // our timer loop for auto move is running
                    else
                    {

                        if (LocalToGlobal(selectedTab.Left) > (width - TabVisibleLimit))
                        {
                            int newX = GlobalToLocal(width - TabVisibleLimit);
                            int diff = selectedTab.X - newX;
                            selectedTab.GlobalMoveX(-diff);
                        }

                        return false;
                    }
                }
            }

            return true;
        }

        public void UpdateTimer()
        {
            _updateTimerNeeded = false;

            if (IsDragging)
            {

                if (!autoShiftTimer)
                {
                    if ((LocalToGlobal(selectedTab.X) < 0) && (savedTotalWidth > width))
                    {
                        timer.Stop();
                        timer.Start();
                        timerMoveLeft = true;
                    }
                    else if ((LocalToGlobal(selectedTab.Right) > width) && (savedTotalWidth > width))
                    {
                        timer.Stop();
                        timer.Start();
                        timerMoveRight = true;
                    }
                    else
                    {
                        timer.Stop();
                        timerCount = 0;
                        timerMoveLeft = false;
                        timerMoveRight = false;
                    }
                }
                else // if (autoShiftTimer)
                {

                    OnDraggingAnim(selectedTab);

#if AUTO_SHIFT_VERSION_B
                    timer.Interval = ShiftStepsMillis;
#endif

                    if (timerMoveLeft)
                    {
                        if (LocalToGlobal(selectedTab.X) >= 0)
                        {
                            StopAutoShift();
                        }
                        else
                        {
                            OFFSET_X += PixelsShiftsPerStep;
                            selectedTab.GlobalMoveX(-PixelsShiftsPerStep);


                            if (OFFSET_X > 0)
                            {
                                selectedTab.GlobalMoveX(OFFSET_X);
                                OFFSET_X = 0;
                            }


                            if (LocalToGlobal(selectedTab.Right) < TabVisibleLimit)
                            {
                                int newX = GlobalToLocal(-selectedTab.Width + TabVisibleLimit);
                                int diff = selectedTab.X - newX;
                                selectedTab.GlobalMoveX(-diff);
                            }


                            SwapTabs(-1);
                            RecalcIndices();
                        }

                    }
                    else if (timerMoveRight)
                    { 
                        if (LocalToGlobal(selectedTab.Right) <= width)
                        {
                            StopAutoShift();
                        }
                        else
                        {
                            OFFSET_X -= PixelsShiftsPerStep;
                            selectedTab.GlobalMoveX(+PixelsShiftsPerStep);


                            int lastPos = LocalToGlobal(nonSelectedTabs[nonSelectedTabs.Count - 1].Right);
                            int totalWidth = TotalWidth(tabs);
                            int nonSelTotWidth = totalWidth - selectedTab.Width;

                            if (lastPos < width - selectedTab.Width)
                            {
                                int diff = totalWidth + OFFSET_X - width;
                                selectedTab.GlobalMoveX(diff);
                                OFFSET_X = -nonSelTotWidth + width - selectedTab.Width;
                            }


                            if (LocalToGlobal(selectedTab.Left) > (width - TabVisibleLimit))
                            {
                                int newX = GlobalToLocal(width - TabVisibleLimit);
                                int diff2 = selectedTab.X - newX;
                                selectedTab.GlobalMoveX(-diff2);
                            }

                            SwapTabs(+1);
                            RecalcIndices();

                        }
                    }
                }

            }


        }
#endif
#endregion

        #region UpdateSwitching
        //
        // Update switching locations to left or right when dragging
        //
        private void UpdateSwitching()
        {
            int moveDirection;

            if (IsDragging)
            {
                OnDraggingAnim(selectedTab);


                #region MovingDirection
                // Calculate moving direction to know if moving to the left or right
                moveDirection = LocalToGlobal(selectedTab.X) - selTabPreviousX;
                selTabPreviousX = LocalToGlobal(selectedTab.X);
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
                    if (LocalToGlobal(mouseX) > (LocalToGlobal(selectedTab.X + selectedTab.dragOffsetPointX)))
                    {
                        // Mouse returns to the 'dragOffsetPointX' so we can release the freeze of the tab
                        selectedTab.X = mouseX - selectedTab.dragOffsetPointX;
                        selTabPreviousX = LocalToGlobal(selectedTab.X);
                        freezeMoveLeft = false;
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
                        selectedTab.X -= moveDirection;
                        selTabPreviousX = LocalToGlobal(selectedTab.X);
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
                else if (LocalToGlobal(selectedTab.X + selectedTab.dragOffsetPointX) < 0)
                {
                    freezeMoveLeft = true;
                }


                //
                // Frozen Tab with mouse on the right and out of the screen
                //
                if (freezeMoveRight)
                {
                    if (LocalToGlobal(mouseX) < (LocalToGlobal(selectedTab.X + selectedTab.dragOffsetPointX)))
                    {
                        selectedTab.X = mouseX - selectedTab.dragOffsetPointX;
                        selTabPreviousX = LocalToGlobal(selectedTab.X);
                        freezeMoveRight = false;
                    }
                    else if (moveDirection < 0)
                    {
                        selectedTab.X -= moveDirection;
                        selTabPreviousX = LocalToGlobal(selectedTab.X);
                    }

                }
                else if (LocalToGlobal(selectedTab.X + selectedTab.dragOffsetPointX) > width)
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
                    if (LocalToGlobal(selectedTab.Left) < 0)
                        OFFSET_X -= moveDirection;

                    // If we reach the end, stop and clamp the offset to 0
                    if (OFFSET_X > 0)
                        OFFSET_X = 0;
                }
                // Mouse is moving to the right  -->
                else if (moveDirection > 0)
                {
                    if (LocalToGlobal(selectedTab.Right) > width)
                        OFFSET_X -= moveDirection;

                    int lastPos = LocalToGlobal(nonSelectedTabs[nonSelectedTabs.Count - 1].Right);
                    int totalWidth = TotalWidth(tabs);
                    int nonSelTotWidth = totalWidth - selectedTab.Width;

                    // All tabs enter inside the control
                    if (totalWidth < width)
                    {
                        if (lastPos < width - selectedTab.Width)
                            OFFSET_X = 0;
                    }
                    // Not all tabs enter inside the control
                    else
                    {
                        if (lastPos < width - selectedTab.Width)
                            OFFSET_X = -nonSelTotWidth + width - selectedTab.Width;
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
                if (LocalToGlobal(selectedTab.Right) < TabVisibleLimit)
                {
                    // 
                    selectedTab.X = GlobalToLocal(-selectedTab.Width + TabVisibleLimit);
                    selTabPreviousX = LocalToGlobal(selectedTab.X); //selTabPreviousX = -SelectedTab.width + 10; // this line works also here
                }
                else if (LocalToGlobal(selectedTab.Left) > (width - TabVisibleLimit))
                {
                    selectedTab.X = GlobalToLocal(width - TabVisibleLimit);
                    selTabPreviousX = LocalToGlobal(selectedTab.X);
                }
                #endregion


                SwapTabs(moveDirection);


                RecalcIndices();
            }
        }
        #endregion

        #region Update
        //
        // Update method
        //
#if USE_AUTO_SHIFT_TIMERS
        public void Update()
        {
            if (TotalTabs <= 1)
                return;

            if (!PreComputeTimer())
                return;

            UpdateSwitching();
            UpdateTimer();
        }
#else
        public void Update()
        {
            if (TotalTabs <= 1)
                return;

            UpdateSwitching();
        }
#endif
        #endregion

        #region Paint
        //
        // Paint method
        //
        public void Paint(Graphics g)
        {
            VampirioGraphics.FillRect(g, Color.FromArgb(90, 90, 90), 0, 0, width, height);

            Tab drawAtMiddleTab = null;
            Tab drawAtTopTab = null;

            foreach (Tab tab in tabs)
            {
                if (tab.Selected)
                    drawAtTopTab = tab;
                else if (tab.IsNonSelButOver)
                    drawAtMiddleTab = tab;
                else if (IsInsideScreen(tab))
                    tab.Paint(g);
            }

            // leave this tabs to draw at the end to bring 
            // them in front of the others
            if (drawAtMiddleTab != null)
                drawAtMiddleTab.Paint(g);

            if (drawAtTopTab != null && IsInsideScreen(drawAtTopTab))
                drawAtTopTab.Paint(g);

            // Debug painting
#if TAB_CONTROLLER_DEBUG
            PrintDebug(g);
#endif
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
                VampirioGraphics.DrawString(g, font, selectedTab.Item.Text, Color.Orange, 10, _startY_);
                _startY_ += 25;

                for (int a = 0; a < nonSelectedTabs.Count; a++)
                {
                    Tab nonSelTab = nonSelectedTabs[a];
                    Tab prevTab = GetPrevious(nonSelTab, nonSelectedTabs);
                    string prevStr = "  prev: ";
                    if (prevTab != null)
                        prevStr += prevTab.Item.Text;

                    VampirioGraphics.DrawString(g, font, nonSelTab.Item.Text + prevStr, Color.Red, 10, _startY_);
                    _startY_ += 15;
                }
            }


            // -------------------------
            _startY_ = 125;

            for (int a = 0; a < tabs.Count; a++)
            {
                Tab tab = tabs[a];
                Color color = Color.Blue;

                if (tab == selectedTab)
                    color = Color.Green;

                VampirioGraphics.DrawString(g, font, tab.Item.Text + "     x: " + tab.X, color, 180, _startY_);
                _startY_ += 15;
            }
            // --------------------------


        }
        #endregion

    }
}
