using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.ScrollBarMan
{
    public class ColorState
    {
        public Color NormalColor;
        public Color OverColor;
        public Color DownColor;

        public ColorState(Color normalColor, Color overColor, Color downColor)
        {
            NormalColor =   normalColor;
            OverColor =     overColor;
            DownColor =     downColor;
        }
    }
}
