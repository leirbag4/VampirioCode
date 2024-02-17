using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TabManagement
{
    public class TabItem
    {
        public TabStyle SelectedStyle { get; set; } = null;
        public TabStyle NormalStyle { get; set; } = null;
        public TabStyle OverStyle { get; set; } = null;


        public int Width { get { return tab.GetWidth(); } set { tab.SetWidth(value); } }
        public int Height { get { return tab.GetHeight(); } set { tab.SetHeight(value); } }
        public string Text { get { return tab.GetText(); } set { tab.SetText(value); } }
        public Tab tab { get; }

        public int Index { get { return tab.Index(); } }

        public TabItem Prev { get { return tab.Prev().Item; } }
        public TabItem Next { get { return tab.Next().Item; } }

        private TabStyle selectedStyle =    null;
        private TabStyle normalStyle =      null;
        private TabStyle overStyle =        null;
        private TabController controller =  null;

        public TabItem(string name)
        {
            tab = new Tab(this);
            Text = name;
        }


        public void Setup(TabController controller)
        {
            this.controller = controller;
        }

    }
}
