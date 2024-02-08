using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    




    public class TabControlX : Control
    {

        public TabItemCollection Items { get { return items; } set { items = value; } }

        private TabItemCollection items = new TabItemCollection();
        private List<Tab> tabs = new List<Tab>();
        private TabManager manager = new TabManager();


        public TabControlX() 
        {
            items.ItemAdded +=      OnItemAdded;
            items.ItemRemoved +=    OnItemRemoved;
            items.ItemModified +=   OnItemModified;
            items.ItemsCleared +=   OnItemsCleared;

            BackColor = Color.FromArgb(60, 60, 60);

            DoubleBuffered = true;
        }


        private void OnItemAdded(int index, TabItem item)
        {
            XConsole.Println("item added: " + item.Name + " at " + index);
            //manager.Add(item);
            manager.Insert(index, item);
            Invalidate();
        }

        private void OnItemRemoved(int index, TabItem item)
        {
            XConsole.Println("item removed: " + item.Name);
            manager.RemoveAt(index);
            Invalidate();
        }

        private void OnItemModified(TabItem oldItem, TabItem newItem)
        {
            XConsole.Println("item modified: " + newItem.Name);
            Invalidate();
        }

        private void OnItemsCleared()
        {
            XConsole.Println("items cleared");
            Invalidate();
        }


        protected override void OnMouseEnter(EventArgs e)
        { 
            base.OnMouseEnter(e);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            manager.MouseDown(e.X, e.Y);
            base.OnMouseDown(e);
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            manager.MouseMove(e.X, e.Y, e.Button == MouseButtons.Left);
            base.OnMouseMove(e);
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            manager.MouseUp(e.X, e.Y);
            base.OnMouseUp(e);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            manager.MouseLeave();
            base.OnMouseLeave(e);
            Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            manager.MouseScroll(e.Delta > 0 ? 1 : 0);
            base.OnMouseWheel(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

            manager.Update();
            manager.Paint(e.Graphics);
        }

    }
}
