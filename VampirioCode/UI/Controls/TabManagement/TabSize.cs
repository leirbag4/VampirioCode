using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TabManagement
{
    public class TabSize
    {
        public int posY;        // Default y position of the tab
        public int subHeight;   // Substract this amount from tab height

        public TabSize(int posY, int subHeight)
        {
            this.posY = posY;
            this.subHeight = subHeight;
        }

    }
}
