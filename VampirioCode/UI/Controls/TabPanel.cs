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
        public TabItemCollection Items { get { return tabBar.Items; } set { tabBar.Items = value; } }
        public TabBar TabBar { get { return tabBar; } }

        private TabBar tabBar;
        private Control container;

        public TabPanel()
        {
            // TabBar
            tabBar = new TabBar();
            tabBar.Location =   new Point(0, 0);
            tabBar.Width =      Width;
            tabBar.Anchor =     AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

            // Container
            container = new Control();
            container.Size =        new Size(Width, Height - tabBar.Height);
            container.Location =    new Point(0, tabBar.Height);
            container.Anchor =      AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            container.BackColor =   Color.FromArgb(200, 60, 60);

            // Events
            tabBar.TabAdded +=              OnTabAdded;
            tabBar.TabRemoved +=            OnTabRemoved;
            tabBar.SelectedTabChanged +=    OnSelectedTabChanged;
            tabBar.UnselectedTabChanged +=  OnUnselectedTabChanged;

            // Design
            BackColor = Color.FromArgb(30, 30, 30);

            this.Controls.Add(tabBar);
            this.Controls.Add(container);
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
        // Events
        //
        private void OnTabAdded(int index, TabItem item)
        {
            if (!Controls.Contains(item.Content))
            {
                item.Content.Dock = DockStyle.Fill;
                item.Content.Visible = false;
                container.Controls.Add(item.Content);
            }

            XConsole.PrintError("event: OnTabAdded");
        }

        private void OnTabRemoved(int index, TabItem item)
        {
            XConsole.PrintError("event: OnTabRemoved");
            container.Controls.Remove(item.Content);
        }

        private void OnSelectedTabChanged(int index, TabItem item)
        {
            XConsole.PrintError("event: OnSelectedTabChanged");
            item.Content.Visible = true;
        }

        private void OnUnselectedTabChanged(int index, TabItem item)
        {
            item.Content.Visible = false;
        }
    }
}
