using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TabManagement
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

            if (ItemAdded != null)
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
}
