using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VampirioCode.UI.Controls.TabManagement;

namespace VampirioCode.UI.Controls
{
    public class TabPanel : Control
    {
        public event SelectedTabChangedEvent SelectedTabChanged;
        public event UnselectedTabChangedEvent UnselectedTabChanged;
        public event TabAddedEvent TabAdded;
        public event TabRemovedEvent TabRemoved;
        public event StartDragTabEvent StartDragTab;
        public event StopDragTabEvent StopDragTab;
        public event TabIndexPositionChangedEvent TabIndexPositionChanged;
        public event RightClickContextEvent RightClickContext;
        public event TabDetachedEvent TabDetached;
        public event TabItemTextChangedEvent TabItemTextChanged;
        public event CloseTabInvokedEvent CloseTabInvoked;
        public event OverTabChangedEvent OverTabChanged;
        public event OverTabElapsedTimeEvent OverTabElapsedTime;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabItemCollection Items { get { return tabBar.Items; } set { tabBar.Items = value; } } [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]

        public int TabBarHeight { get { return tabBar.Height; } set { tabBar.Height = value; ResizeLayout(); } }
        public TabPaintMode PaintMode { get { return controller.PaintMode; } set { controller.PaintMode = value; } } [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabSize SelectedTabSize  { get { return controller.SelectedTabSize; }    set { controller.SelectedTabSize = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabSize NormalTabSize    { get { return controller.NormalTabSize; }      set { controller.NormalTabSize = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)] 
        public TabSize DraggedTabSize   { get { return controller.DraggedTabSize; }     set { controller.DraggedTabSize = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int TabBorderSize        { get { return controller.TabBorderSize; }      set { controller.TabBorderSize = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle SelectedStyle   { get { return controller.SelectedStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle NormalStyle     { get { return controller.NormalStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle OverStyle       { get { return controller.OverStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle SubButtonsSelectedStyle { get{ return controller.SubButtonsSelectedStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle SubButtonsSelectedOverStyle { get{ return controller.SubButtonsSelectedOverStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle SubButtonsNormalStyle   { get{ return controller.SubButtonsNormalStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle SubButtonsOverStyle     { get{ return controller.SubButtonsOverStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle SubButtonsParentOverStyle { get { return controller.SubButtonsParentOverStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int SubButtonsBorderSize         { get { return controller.SubButtonsBorderSize; }   set { controller.SubButtonsBorderSize = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool CloseButtonVisible          { get { return controller.CloseButtonVisible; }     set { controller.CloseButtonVisible = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public CloseBtnBehaviour CloseButtonBehaviour { get { return controller.CloseButtonBehaviour; } set { controller.CloseButtonBehaviour = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Color BarColor           { get { return controller.BackColor; }          set { controller.BackColor = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int LeftPadding          { get { return controller.LeftPadding; }        set { controller.LeftPadding = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int RightPadding         { get { return controller.RightPadding; }       set { controller.RightPadding = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]

        public TabTextAlign TextAlign   { get { return controller.TextAlign; }          set { controller.TextAlign = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabShapeMode ShapeMode   { get { return controller.ShapeMode; }          set { controller.ShapeMode = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabManagement.TabSizeMode SizeMode     { get { return controller.SizeMode; }           set { controller.SizeMode = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int MinTabWidth          { get { return controller.MinTabWidth; }        set { controller.MinTabWidth = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int MaxTabWidth          { get { return controller.MaxTabWidth; }        set { controller.MaxTabWidth = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int TotalTabs            { get { return controller.TotalTabs; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool IsDragging          { get { return controller.IsDragging; }         set { controller.IsDragging = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool IsAnySelected       { get { return controller.IsAnySelected; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool IsOutsideBounds     { get { return controller.IsOutsideBounds; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool TabsFitOnScreen     { get { return controller.TabsFitOnScreen; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int TabVisibleLimit      { get { return controller.TabVisibleLimit; }    set { controller.TabVisibleLimit = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int SelectedIndex        { get { return controller.SelectedIndex; }      set { controller.SelectedIndex = value; Invalidate(); } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabItem SelectedTab      { get { return controller.SelectedTab.Item; }   set { controller.SelectedTab = value.tab; Invalidate(); } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool AllowDragging       { get { return controller.AllowDragging; }      set { controller.AllowDragging = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool AllowDetach         { get { return controller.AllowDetach; }        set { controller.AllowDetach = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int MinDetachThreshold   { get { return controller.MinDetachThreshold; } set { controller.MinDetachThreshold = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]


        public int ArrowButtonBorderSize { get { return leftArrowButton.BorderSize; } set { leftArrowButton.BorderSize = value; rightArrowButton.BorderSize = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Color ArrowButtonBackColor { get { return leftArrowButton.BackColor; } set { leftArrowButton.BackColor = value; rightArrowButton.BackColor = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Color ArrowButtonBorderColor { get { return leftArrowButton.BorderColor; } set { leftArrowButton.BorderColor = value; rightArrowButton.BorderColor = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Color ArrowColor { get { return arrowColor; } set { arrowColor = value; CreateArrows(7, 14); } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool SplitBarVisible { get { return splitBar.Visible; } set { splitBar.Visible = value; ResizeLayout(); } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int SplitBarSize { get { return splitBar.Height; } set { splitBar.Height = value; ResizeLayout(); } } [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Color SplitBarColor { get { return splitBar.BackColor; } set { splitBar.BackColor = value; } } [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        private int TotalArrowButtonsWidth { get { return ((arrowButtonWidth << 1) - ArrowButtonBorderSize); } }

        public TabBar TabBar { get { return tabBar; } }


        private TabBar tabBar;
        private TabController controller;
        private Control container;
        
        // arrows
        private ButtonAdv leftArrowButton;
        private ButtonAdv rightArrowButton;
        private int arrowButtonWidth = 20;
        private Bitmap leftArrowBitmap;
        private Bitmap rightArrowBitmap;
        private System.Windows.Forms.Timer arrowTimer;
        private bool arrowTimerDirection = false;
        private Color arrowColor = Color.FromArgb(20, 20, 20);

        // split bar
        private Control splitBar;


        public TabPanel()
        {
            // TabBar
            tabBar = new TabBar();
            tabBar.Location =   new Point(0, 0);
            tabBar.Width =      Width;
            tabBar.Anchor =     AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

            // TabController
            controller =        tabBar.GetController();

            // Arrow Buttons
            leftArrowButton =               new ButtonAdv();
            rightArrowButton =              new ButtonAdv();
            leftArrowButton.CStyle =        ButtonAdv.CustomStyle.SOLID;
            rightArrowButton.CStyle =       ButtonAdv.CustomStyle.SOLID;
            leftArrowButton.BorderSize =    2;
            rightArrowButton.BorderSize =   2;
            leftArrowButton.BackColor =     Color.FromArgb(40, 40, 40);
            rightArrowButton.BackColor =    Color.FromArgb(40, 40, 40);
            leftArrowButton.BorderColor =   Color.FromArgb(25, 25, 25);
            rightArrowButton.BorderColor =  Color.FromArgb(25, 25, 25);
            leftArrowButton.Width =         arrowButtonWidth;
            rightArrowButton.Width =        arrowButtonWidth;
            leftArrowButton.Location =      new Point(Width - TotalArrowButtonsWidth, 0);
            rightArrowButton.Location =     new Point(leftArrowButton.Right - ArrowButtonBorderSize, 0);
            leftArrowButton.Anchor =        AnchorStyles.Right | AnchorStyles.Top;
            rightArrowButton.Anchor =       AnchorStyles.Right | AnchorStyles.Top;
            leftArrowButton.Visible =       false;
            rightArrowButton.Visible =      false;
            CreateArrows(7, 14);

            // Container
            container = new Control();
            container.Size =        new Size(Width, Height - tabBar.Height);
            container.Location =    new Point(0, tabBar.Height);
            container.Anchor =      AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            container.BackColor =   Color.FromArgb(50, 50, 50);

            // Split Bar
            splitBar = new Control();
            splitBar.BackColor =    Color.FromArgb(51, 51, 51);
            splitBar.Size =         new Size(this.Width, SplitBarSize);
            splitBar.Dock =         DockStyle.Left;
            splitBar.Anchor =       AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            splitBar.Location =     new Point(0, tabBar.Height);
            splitBar.Visible =      false;

            // Events
            tabBar.SelectedTabChanged +=        OnSelectedTabChanged;
            tabBar.UnselectedTabChanged +=      OnUnselectedTabChanged;
            tabBar.TabAdded +=                  OnTabAdded;
            tabBar.TabRemoved +=                OnTabRemoved;
            tabBar.StartDragTab +=              OnStartDragTab;
            tabBar.StopDragTab +=               OnStopDragTab;
            tabBar.TabIndexPositionChanged +=   OnTabIndexPositionChanged;
            tabBar.RightClickContext +=         OnRightClickContext;
            tabBar.TabDetached +=               OnTabDetached;
            tabBar.TabItemTextChanged +=        OnTabItemTextChanged;
            tabBar.CloseTabInvoked +=           OnCloseTabInvoked;
            tabBar.OverTabChanged +=            OnOverTabChanged;
            tabBar.OverTabElapsedTime +=        OnOverTabElapsedTime;

            leftArrowButton.MouseDown +=        OnLeftArrowBtnDown;
            rightArrowButton.MouseDown +=       OnRightArrowBtnDown;
            leftArrowButton.MouseUp +=          OnLeftArrowBtnUp;
            rightArrowButton.MouseUp +=         OnRightArrowBtnUp;

            // Timers
            arrowTimer =                    new System.Windows.Forms.Timer();
            arrowTimer.Interval =           15;
            arrowTimer.Tick +=              OnArrowTimerUpdate;


            // Design
            BackColor = Color.FromArgb(30, 30, 30);

            // Properties
            tabBar.TextAlign =  TabTextAlign.Center;
            tabBar.ShapeMode =  TabShapeMode.Box;
            tabBar.SizeMode =   TabManagement.TabSizeMode.WrapToText;

            // Controls 
            this.Controls.Add(tabBar);
            this.Controls.Add(leftArrowButton);
            this.Controls.Add(rightArrowButton);
            this.Controls.Add(splitBar);
            this.Controls.Add(container);
        }

        /*public List<T> GetItems<T>()
        {
            List<T> castedItems = new List<T>();

            foreach (var item in Items)
            {
                if (item is T castedItem)
                {
                    castedItems.Add(castedItem);
                }
            }

            return castedItems;
        }

        public List<T> GetItems<T>()
        {
            return Items.OfType<T>().ToList();
        }*/

        public T[] GetItems<T>()
        {
            return tabBar.GetItems<T>();
        }

        public void AddItem<T>(T item) where T : TabItem
        {
            tabBar.Add(item);
        }

        public void SetFont(string fontName, int fontSize, FontStyle fontStyle)
        {
            tabBar.SetFont(fontName, fontSize, fontStyle);
        }

        public void SelectTab(TabItem item)
        {
            controller.SelectTab(item.tab);
        }

        public void SelectTab(int index)
        {
            controller.SelectTab(index);
        }

        public void SelectTab(TabItem item, bool bringToScreen)
        {
            controller.SelectTab(item.tab, bringToScreen);
        }

        public void SelectTab(int index, bool bringToScreen)
        {
            controller.SelectTab(index, bringToScreen);
        }

        public void BringTabIntoScreen(TabItem item)
        {
            controller.BringTabIntoScreen(item.tab);
        }

        public void Add(TabItem item)
        {
            tabBar.Add(item);
        }

        public void Insert(int index, TabItem item)
        {
            tabBar.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            tabBar.RemoveAt(index);
        }

        public void Remove(TabItem tab)
        {
            tabBar.Remove(tab);
        }

        public void RemoveAllTabs()
        {
            tabBar.RemoveAllTabs();
        }

        //
        // Utils
        //
        public void Repaint()
        {
            tabBar.Repaint();
        }

        public void SetSkin(TabSkin skin)
        {
            tabBar.SetSkin(skin);

            if ((skin == TabSkin.DarkMiddleRound) || (skin == TabSkin.DarkMiddleRoundWClose) || (skin == TabSkin.DarkMiddleRoundWCloseSel))
            {
                // split bar
                SplitBarColor = Color.FromArgb(31, 31, 31);
                SplitBarSize = 2;
                SplitBarVisible = true;
            }
            else
                SplitBarVisible = false;
        }

        private void CheckOutOfBounds()
        {
            BackColor = Color.FromArgb(30, 30, 30);

            if (tabBar.IsOutsideBounds)
            {
                tabBar.Width = Width - TotalArrowButtonsWidth;

                leftArrowButton.Height =    tabBar.Height;
                rightArrowButton.Height =   tabBar.Height;
                leftArrowButton.Visible =   true;
                rightArrowButton.Visible =  true;
            }
            else
            {
                tabBar.Width = Width;

                leftArrowButton.Visible =   false;
                rightArrowButton.Visible =  false;
            }
        }

        private void CreateArrows(int arrowWidth, int arrowHeight)
        {
            // Create bitmaps for arrows
            leftArrowBitmap =           TabUtils.CreateLeftArrow(arrowWidth, arrowHeight, arrowColor);
            rightArrowBitmap =          TabUtils.CreateRightArrow(arrowWidth, arrowHeight, arrowColor);
            leftArrowButton.Image =     leftArrowBitmap;
            rightArrowButton.Image =    rightArrowBitmap;
        }

        private void ResizeLayout()
        {
            if (SplitBarVisible)
            {
                container.Size =        new Size(Width, Height - tabBar.Height - splitBar.Height);
                container.Location =    new Point(0, tabBar.Height + splitBar.Height);
                splitBar.Top =          tabBar.Height;
            }
            else
            { 
                container.Size =        new Size(Width, Height - tabBar.Height);
                container.Location =    new Point(0, tabBar.Height);
            }
        }

        //
        // Internal Events
        //
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            CheckOutOfBounds();
        }

        private void OnLeftArrowBtnDown(object sender, EventArgs e)
        {
            arrowTimerDirection = false;
            controller.Shift(10);
            tabBar.Invalidate();
            arrowTimer.Start();
        }

        private void OnRightArrowBtnDown(object sender, EventArgs e)
        {
            arrowTimerDirection = true;
            controller.Shift(-10);
            tabBar.Invalidate();
            arrowTimer.Start();
        }

        private void OnLeftArrowBtnUp(object sender, EventArgs e)
        {
            arrowTimer.Stop();
        }

        private void OnRightArrowBtnUp(object sender, EventArgs e)
        {
            arrowTimer.Stop();
        }

        //
        // External Events
        //
        private void OnSelectedTabChanged(int index, TabItem item)
        {
            if(item != null)
                item.Content.Visible = true;

            if (SelectedTabChanged != null)
                SelectedTabChanged(index, item);
        }

        private void OnUnselectedTabChanged(int index, TabItem item)
        {
            item.Content.Visible = false;

            if(UnselectedTabChanged != null)
                UnselectedTabChanged(index, item);
        }

        private void OnArrowTimerUpdate(object sender, EventArgs e)
        {
            if(!arrowTimerDirection)
                controller.Shift(+10);
            else    
                controller.Shift(-10);
            tabBar.Invalidate();
        }

        private void OnTabAdded(int index, TabItem item)
        {
            if (!Controls.Contains(item.Content))
            {
                item.Content.Dock = DockStyle.Fill;
                item.Content.Visible = false;
                container.Controls.Add(item.Content);
            }

            CheckOutOfBounds();

            if (TabAdded != null)
                TabAdded(index, item);
        }

        private void OnTabRemoved(int index, TabItem item)
        {
            container.Controls.Remove(item.Content);

            CheckOutOfBounds();

            if (TabRemoved != null)
                TabRemoved(index, item);
        }

        private void OnStartDragTab(int index, TabItem item)
        {
            if (StartDragTab != null)
                StartDragTab(index, item);
        }
        private void OnStopDragTab(int index, TabItem item)
        {
            if(StopDragTab != null)
                StopDragTab(index, item);
        }

        private void OnTabIndexPositionChanged(int oldIndex, int newIndex)
        {
            if(TabIndexPositionChanged != null)
                TabIndexPositionChanged(oldIndex, newIndex);
        }

        private void OnRightClickContext(TabItem item)
        {
            if(RightClickContext != null)
                RightClickContext(item);
        }
        private void OnTabDetached(int index, TabItem item, int offsetX)
        {
            CheckOutOfBounds();

            if (TabDetached != null)
                TabDetached(index, item, offsetX);
        }

        private void OnTabItemTextChanged(int index, TabItem item)
        {
            CheckOutOfBounds();

            if (TabItemTextChanged != null)
                TabItemTextChanged(index, item);
        }

        private void OnCloseTabInvoked(int index, TabItem item)
        {
            if (CloseTabInvoked != null)
                CloseTabInvoked(index, item);
        }

        private void OnOverTabChanged(int index, TabItem item)
        {
            if (OverTabChanged != null)
                OverTabChanged(index, item);
        }

        private void OnOverTabElapsedTime(int index, TabItem item, int positionX)
        {
            if (OverTabElapsedTime != null)
                OverTabElapsedTime(index, item, positionX);
        }

    }
}
