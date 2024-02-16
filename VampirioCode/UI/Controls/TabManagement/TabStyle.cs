using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TabManagement
{
    public class TabStyle
    {
        public TabStyle(Color backColor,  Color textColor, Color borderColor, int borderSize)
        { 
            this.BackColor =    backColor;
            this.TextColor =    textColor;
            this.BorderColor =  borderColor;
            this.BorderSize =   borderSize;
        }

        public Color BackColor;
        public Color TextColor;
        public Color BorderColor;
        public int BorderSize;
    }
}
