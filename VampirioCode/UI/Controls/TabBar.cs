#define USE_AUTO_SHIFT_TIMERS

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.Controls.TabManagement;

namespace VampirioCode.UI.Controls
{

    public class TabBar : Control
    {
        public event SelectedTabChangedEvent SelectedTabChanged;
        public event UnselectedTabChangedEvent UnselectedTabChanged;
        public event TabAddedEvent TabAdded;
        public event TabRemovedEvent TabRemoved;
        public event StartDragTabEvent StartDragTab;
        public event StopDragTabEvent StopDragTab;
        public event RightClickContextEvent RightClickContext;
        public event TabDetachedEvent TabDetached;
        public event TabItemTextChangedEvent TabItemTextChanged;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabItemCollection Items { get { return items; } set { items = value; } } [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]

        
        public TabSize SelectedTabSize { get { return controller.SelectedTabSize; } set { controller.SelectedTabSize = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabSize NormalTabSize { get { return controller.NormalTabSize; } set { controller.NormalTabSize = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabSize DraggedTabSize { get { return controller.DraggedTabSize; } set { controller.DraggedTabSize = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int TabBorderSize { get { return controller.TabBorderSize; } set { controller.TabBorderSize = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle SelectedStyle { get { return controller.SelectedStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle NormalStyle { get { return controller.NormalStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabStyle OverStyle { get { return controller.OverStyle; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Color BackColor { get { return controller.BackColor; } set { controller.BackColor = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabTextAlign TextAlign { get { return controller.TextAlign; } set { controller.TextAlign = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabShapeMode ShapeMode { get { return controller.ShapeMode; } set { controller.ShapeMode = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabManagement.TabSizeMode SizeMode { get { return controller.SizeMode; } set { controller.SizeMode = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int MinTabWidth { get { return controller.MinTabWidth; } set { controller.MinTabWidth = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int MaxTabWidth { get { return controller.MaxTabWidth; } set { controller.MaxTabWidth = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int TotalTabs { get { return controller.TotalTabs; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool IsDragging { get { return controller.IsDragging; } set { controller.IsDragging = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool IsAnySelected { get { return controller.IsAnySelected; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool IsOutsideBounds { get { return controller.IsOutsideBounds; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool TabsFitOnScreen { get { return controller.TabsFitOnScreen; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int TabVisibleLimit { get { return controller.TabVisibleLimit; } set { controller.TabVisibleLimit = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int SelectedIndex { get { return controller.SelectedIndex; } set { controller.SelectedIndex = value; Invalidate(); } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public TabItem SelectedTab { get { return controller.SelectedTab.Item; } set { controller.SelectedTab = value.tab; Invalidate(); } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool AllowDragging { get { return controller.AllowDragging; } set { controller.AllowDragging = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool AllowDetach { get { return controller.AllowDetach; } set { controller.AllowDetach = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int MinDetachThreshold { get { return controller.MinDetachThreshold; } set { controller.MinDetachThreshold = value; } }[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]

        private TabItemCollection items = new TabItemCollection();
        private TabController controller;
        private bool _itemEventsEnabled = true;

        public TabBar()
        {
            controller = new TabController();

            // size
            Height = controller.Height;

            // controller events
            controller.SelectedTabChanged +=    OnSelectedTabChanged;
            controller.UnselectedTabChanged +=  OnUnselectedTabChanged;
            controller.TabAdded +=              OnTabAdded;
            controller.TabRemoved +=            OnTabRemoved;
            controller.StartDragTab +=          OnStartDragTab;
            controller.StopDragTab +=           OnStopDragTab;
            controller.TabIndexChanged +=       OnTabIndexChanged;
            controller.TabDetached +=           OnTabDetached;
            controller.TabItemTextChanged +=    OnTabItemTextChanged;
#if USE_AUTO_SHIFT_TIMERS
            controller.TimerRepaintNeeded +=    OnTimerRepaintNeeded;
#endif

            // items events
            items.ItemAdded +=      OnItemAdded;
            items.ItemRemoved +=    OnItemRemoved;
            items.ItemModified +=   OnItemModified;
            items.ItemsCleared +=   OnItemsCleared;

            BackColor = Color.FromArgb(60, 60, 60);

            DoubleBuffered = true;
        }

        

        public TabController GetController()
        {
            return controller;
        }

        public void SetFont(string fontName, int fontSize, FontStyle fontStyle)
        {
            controller.SetFont(fontName, fontSize, fontStyle);
        }

        public void SelectTab(TabItem item)
        {
            controller.SelectTab(item.tab);
        }

        public void BringTabIntoScreen(TabItem item)
        {
            controller.BringTabIntoScreen(item.tab);
        }

        public void Add(TabItem item)
        {
            Items.Add(item);
        }

        public void Insert(int index, TabItem item) 
        {
            Items.Insert(index, item);
        }

        public void RemoveAt(int index)
        { 
            Items.RemoveAt(index);
        }

        public void Remove(TabItem tab)
        {
            Items.Remove(tab);
        }

        public void RemoveAllTabs()
        {
            Items.Clear();
        }

        public TabItem GetTabAt(int index)
        { 
            return controller.GetTabAt(index).Item;
        }

        public void BringTabToScreen(TabItem tab)
        {
            controller.BringTabIntoScreen(tab.tab);
            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            controller.SizeChange(this.Width, this.Height);
            base.OnSizeChanged(e);
            Invalidate();
        }


        // Controller Events
        private void OnSelectedTabChanged(int index, TabItem item)
        {
            if(SelectedTabChanged != null)
                SelectedTabChanged(index, item);
        }

        private void OnUnselectedTabChanged(int index, TabItem item)
        {
            if (UnselectedTabChanged != null)
                UnselectedTabChanged(index, item);
        }

        private void OnTabAdded(int index, TabItem item)
        {
            if(TabAdded != null)
                TabAdded(index, item);
        }

        private void OnTabRemoved(int index, TabItem item)
        {
            if(TabRemoved != null)
                TabRemoved(index, item);
        }

        private void OnStartDragTab(int index, TabItem item)
        {
            if(StartDragTab != null)
                StartDragTab(index, item);
        }

        private void OnStopDragTab(int index, TabItem item)
        {
            if(StopDragTab != null)
                StopDragTab(index, item);
        }

        private void OnTimerRepaintNeeded()
        {
            Invalidate();
        }

        // Item Events
        private void OnItemAdded(int index, TabItem item)
        {
            if (!_itemEventsEnabled) return;

            controller.Insert(index, item);
            Invalidate();
        }

        private void OnItemRemoved(int index, TabItem item)
        {
            if (!_itemEventsEnabled) return;

            controller.RemoveAt(index);
            Invalidate();
        }

        private void OnItemModified(TabItem oldItem, TabItem newItem)
        {
            if (!_itemEventsEnabled) return;

            XConsole.Println("item modified: " + newItem.Text);
            Invalidate();
        }

        private void OnItemsCleared()
        {
            if (!_itemEventsEnabled) return;

            controller.RemoveAllTabs();
            Invalidate();
        }

        private void OnTabIndexChanged(int oldIndex, int newIndex)
        {
            _itemEventsEnabled = false;
            
            TabItem item = Items[oldIndex];
            Items.RemoveAt(oldIndex);
            Items.Insert(newIndex, item);

            _itemEventsEnabled = true;
        }

        private void OnTabDetached(int index, TabItem item, int offsetX)
        {
            if (TabDetached != null)
                TabDetached(index, item, offsetX);
        }

        private void OnTabItemTextChanged(int index, TabItem item)
        {
            if(TabItemTextChanged != null)
                TabItemTextChanged(index, item);

            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        { 
            base.OnMouseEnter(e);
            Invalidate();
        }
        private int mouseSavedX;
        private int mouseSavedY;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            mouseSavedX = e.X;
            mouseSavedY = e.Y;
            controller.MouseDown(e.X, e.Y);
            base.OnMouseDown(e);
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            controller.MouseMove(e.X, e.Y, e.Button == MouseButtons.Left);
            base.OnMouseMove(e);
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            controller.MouseUp(e.X, e.Y);
            base.OnMouseUp(e);
            Invalidate();

            if ((e.Button == MouseButtons.Right) && (RightClickContext != null) && (controller.SelectedTab != null))
                RightClickContext(controller.SelectedTab.Item);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            controller.MouseLeave();
            base.OnMouseLeave(e);
            Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            controller.MouseScroll(e.X, e.Y, e.Delta > 0 ? 1 : -1);
            base.OnMouseWheel(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

#if USE_AUTO_SHIFT_TIMERS
            if(controller.UpdateTimerNeeded)
                controller.UpdateTimer();
            else
                controller.Update();
#else
            controller.Update();
#endif
            controller.Paint(e.Graphics);
        }

    }
}
