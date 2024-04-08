using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TabManagement
{
    public class TabArrowButtonStyle
    {
        public Color BackColor;
        public Color BorderColor;
        public Color ArrowColor;

        public TabArrowButtonStyle(Color backColor, Color borderColor, Color arrowColor)
        {
            this.BackColor =    backColor;
            this.BorderColor =  borderColor;
            this.ArrowColor =   arrowColor;
        }
    }
}
