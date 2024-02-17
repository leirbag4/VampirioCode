#define USE_AUTO_SHIFT_TIMERS

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.Controls.TabManagement;

namespace VampirioCode.UI.Controls
{

    public class TabBar : Control
    {
        public delegate void SelectedTabChangedEvent(int index, TabItem item);
        public delegate void TabAddedEvent(int index, TabItem item);
        public delegate void TabRemovedEvent(int index, TabItem item);
        public delegate void StartDragTabEvent(int index, TabItem item);
        public delegate void StopDragTabEvent(int index, TabItem item);
        public delegate void RightClickContextEvent(TabItem item);
        public event SelectedTabChangedEvent SelectedTabChanged;
        public event TabAddedEvent TabAdded;
        public event TabRemovedEvent TabRemoved;
        public event StartDragTabEvent StartDragTab;
        public event StopDragTabEvent StopDragTab;
        public event RightClickContextEvent RightClickContext;

        public TabItemCollection Items { get { return items; } set { items = value; } }
        public int SelectedIndex { get { return controller.SelectedIndex; } set { controller.SelectedIndex = value; Invalidate(); } }
        public TabItem SelectedTab { get { return controller.SelectedTab.Item; } set { controller.SelectedTab = value.tab; Invalidate(); } }
        public TabStyle SelectedStyle { get { return controller.SelectedStyle; } }
        public TabStyle NormalStyle { get { return controller.NormalStyle; } }
        public TabStyle OverStyle { get { return controller.OverStyle; } }


        private TabItemCollection items = new TabItemCollection();
        private TabController controller;
        private bool _itemEventsEnabled = true;

        public TabBar() 
        {
            controller = new TabController();

            // controller events
            controller.SelectedTabChanged +=    OnSelectedTabChanged;
            controller.TabAdded +=              OnTabAdded;
            controller.TabRemoved +=            OnTabRemoved;
            controller.StartDragTab +=          OnStartDragTab;
            controller.StopDragTab +=           OnStopDragTab;
            controller.TabIndexChanged +=       OnTabIndexChanged;
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

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if(e.KeyChar == 'a')
                controller.MouseMove(mouseSavedX -= 1, mouseSavedY, false);
            else if (e.KeyChar == 's')
                controller.MouseMove(mouseSavedX -= 2, mouseSavedY, false);
            else if (e.KeyChar == 'd')
                controller.MouseMove(mouseSavedX -= 3, mouseSavedY, false);

            else if (e.KeyChar == 'q')
                controller.MouseMove(mouseSavedX, mouseSavedY += 1, false);
            else if (e.KeyChar == 'w')
                controller.MouseMove(mouseSavedX, mouseSavedY += 2, false);

            base.OnKeyPress(e);
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
