using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode;
using VampirioCode.UI;


namespace VampEditor
{
    public class ContextMenu<TEnum> where TEnum : Enum
    {
        public delegate void ItemPressed(TEnum selection);
        public delegate void Opening(System.ComponentModel.CancelEventArgs e);
        public event ItemPressed OnItemPressed;
        public event Opening OnOpening;

        public ContextMenuStrip Context { get { return _contextMenu; } }
        private Dictionary<TEnum, ToolStripMenuItem> _items;

        private ContextMenuStrip _contextMenu;
        private ContextMenuRenderer _renderer;

        public ContextMenu() 
        {
            _contextMenu =          new ContextMenuStrip();
            _renderer =             new ContextMenuRenderer();
            _items=                 new Dictionary<TEnum, ToolStripMenuItem>();
            _contextMenu.Renderer = _renderer;
            _contextMenu.Opening += OnContextOpening;
        }

        

        public void AddItem(TEnum type, string name, Image img = null)
        {
            ToolStripMenuItem item;
            if (img != null)    item = new ToolStripMenuItem(name, img);
            else                item = new ToolStripMenuItem(name);
            item.Click +=       OnMenuItemPressed;
            item.Tag =          type;
            _renderer.SetItem(item);
            _contextMenu.Items.Add(item);
            _items.Add(type, item);
        }

        public ToolStripMenuItem GetItem(TEnum type)
        {
            return _items[type];
        }

        public void SetEnable(TEnum type, bool enable)
        {
            _items[type].Enabled = enable;
        }

        public void SetVisible(TEnum type, bool visible)
        {
            _items[type].Visible = visible;
        }

        private void OnMenuItemPressed(object sender, EventArgs e)
        {
            TEnum selection = (TEnum)((ToolStripMenuItem)sender).Tag;

            if(OnItemPressed != null)
                OnItemPressed(selection);
        }

        private void OnContextOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (OnOpening != null)
                OnOpening(e);
        }

        public void AddSeparator()
        {
            _contextMenu.Items.Add(new ToolStripSeparator());
        }
    }


}
