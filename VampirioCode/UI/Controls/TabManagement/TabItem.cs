using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TabManagement
{
    public class TabItem
    {
        public int Width { get; set; } = 80;
        public int Height { get; set; } = 25;
        public string Text { get; set; } = "";
        public Tab tab { get; set; } = null;

        public int Index { get { return tab.Index(); } }

        public TabItem(string name)
        {
            Text = name;
        }


    }
}
