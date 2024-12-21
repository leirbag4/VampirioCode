using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TreeViewAdvance
{
    public class CollapseStyle
    {
        public Color AreaColor { get; set; }
        public Color BorderColor { get; set; }
        public Color CrossColor { get; set; }

        public CollapseStyle(Color areaColor, Color borderColor, Color crossColor)
        {
            this.AreaColor =    areaColor;
            this.BorderColor =  borderColor;
            this.CrossColor =   crossColor;
        }
    }
}
