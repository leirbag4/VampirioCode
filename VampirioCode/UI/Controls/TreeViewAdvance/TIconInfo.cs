using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TreeViewAdvance
{
    public class TIconInfo
    {
        public Bitmap Image { get; set; }
        public PositionMode IconPositionMode { get; set; } = PositionMode.Centered;
        public int IconOffsetX { get; set; } = 0;
        public int IconOffsetY { get; set; } = 0;

        public TIconInfo(Bitmap image)
        { 
            Image = image;
        }
    }
}
