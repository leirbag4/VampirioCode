using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TabManagement
{
    public class TabItem
    {

        //public TabContent Content { get; set; }
        public Control Content { get; set; }

        public TabStyle SelectedStyle { get; set; } = null;
        public TabStyle NormalStyle { get; set; } = null;
        public TabStyle OverStyle { get; set; } = null;


        public int Width { get { return tab.GetWidth(); } set { tab.SetWidth(value); } }
        public int Height { get { return tab.GetHeight(); } set { tab.SetHeight(value); } }
        public string Text { get { return tab.GetText(); } set { tab.SetText(value); } }
        public Tab tab { get; }

        public int Index { get { return tab.Index(); } }


        private TabStyle selectedStyle =    null;
        private TabStyle normalStyle =      null;
        private TabStyle overStyle =        null;
        private TabController controller =  null;

        public TabItem(string name)
        {
            tab =       new Tab(this);
            Text =      name;
            Content =   new TabContent();
        }


        public void Setup(TabController controller)
        {
            this.controller = controller;
        }

        public TabItem Prev()
        {
            Tab prev = tab.Prev();

            if (prev != null)
                return prev.Item;
            else
                return null;
        }

        public TabItem Next()
        {
            Tab next = tab.Next();

            if (next != null)
                return next.Item;
            else
                return null;
        }
    }
}
