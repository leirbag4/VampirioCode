using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TabManagement
{
    public class TabSize
    {
        public int paddingTop;      // Default y position of the tab
        public int paddingBottom;   // Substract this amount from tab height

        public TabSize(int paddingTop, int paddingBottom)
        {
            this.paddingTop =       paddingTop;
            this.paddingBottom =    paddingBottom;
        }

    }
}
