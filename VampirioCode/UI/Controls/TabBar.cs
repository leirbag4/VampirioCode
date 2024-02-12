using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.Controls.TabManagement;

namespace VampirioCode.UI.Controls
{
    public class TabItemCollection : Collection<TabItem>
    {
        public delegate void ItemAddedEvent(int index, TabItem item);
        public delegate void ItemRemovedEvent(int index, TabItem item);
        public delegate void ItemModifiedEvent(TabItem oldItem, TabItem newItem);
        public delegate void ItemsClearedEvent();
        public event ItemAddedEvent ItemAdded;
        public event ItemRemovedEvent ItemRemoved;
        public event ItemModifiedEvent ItemModified;
        public event ItemsClearedEvent ItemsCleared;

        // Método para sobrescribir la operación de añadir un elemento a la colección
        protected override void InsertItem(int index, TabItem item)
        {
            base.InsertItem(index, item);
            
            if(ItemAdded != null)
                ItemAdded(index, item);
        }

        protected override void RemoveItem(int index)
        {
            TabItem item = this[index];
            base.RemoveItem(index);

            if (ItemRemoved != null)
                ItemRemoved(index, item);
        }

        protected override void SetItem(int index, TabItem item)
        {
            base.SetItem(index, item);

            TabItem oldItem = this[index];
            base.SetItem(index, item);

            if (ItemModified != null)
                ItemModified(oldItem, item);
        }

        protected override void ClearItems()
        {
            base.ClearItems();

            if (ItemsCleared != null)
                ItemsCleared();
        }

    }

    




    public class TabBar : Control
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


        public TabItemCollection Items { get { return items; } set { items = value; } }
        public int SelectedIndex { get { return controller.SelectedIndex; } set { controller.SelectedIndex = value; Invalidate(); } }
        public TabItem SelectedTab { get { return controller.SelectedTab.item; } set { controller.SelectedTab = value.tab; Invalidate(); } }

        private TabItemCollection items = new TabItemCollection();
        private TabController controller;


        public TabBar() 
        {
            controller = new TabController();

            // controller events
            controller.SelectedTabChanged +=    OnSelectedIndexChanged;
            controller.TabAdded +=              OnTabAdded;
            controller.TabRemoved +=            OnTabRemoved;
            controller.StartDragTab +=          OnStartDragTab;
            controller.StopDragTab +=           OnStopDragTab;

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
            controller.Add(item);
            Invalidate();
        }

        public void Insert(int index, TabItem item) 
        {
            controller.Insert(index, item);
            Invalidate();
        }

        public void RemoveAt(int index)
        { 
            controller.RemoveAt(index);
            Invalidate();
        }

        public void Remove(TabItem tab)
        { 
            controller.Remove(tab);
            Invalidate();
        }

        public void RemoveAllTabs()
        { 
            controller.RemoveAllTabs();
            Invalidate();
        }

        public TabItem GetTabAt(int index)
        { 
            return controller.GetTabAt(index).item;
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
        private void OnSelectedIndexChanged(int index, TabItem item)
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

        // Item Events
        private void OnItemAdded(int index, TabItem item)
        {
            Insert(index, item);
        }

        private void OnItemRemoved(int index, TabItem item)
        {
            RemoveAt(index);
        }

        private void OnItemModified(TabItem oldItem, TabItem newItem)
        {
            XConsole.Println("item modified: " + newItem.Text);
            Invalidate();
        }

        private void OnItemsCleared()
        {
            XConsole.Println("items cleared");
            RemoveAllTabs();
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

            controller.Update();
            controller.Paint(e.Graphics);
        }

    }
}
