using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VampirioCode.UI.VampGraphics;

namespace VampirioCode.UI.Controls.TreeViewAdvance
{
    public class TStringBuilder
    {
        private TRect totalRect;
        private int startX;
        private int startY;
        public List<TRect> rects;

        public TStringBuilder(TRect totalRect)
        { 
            this.totalRect = totalRect;
            this.startX = totalRect.X;
            this.startY = totalRect.Y;
            rects = new List<TRect>();
        }

        public TRect Add(Font font, string str)
        {
            SizeF size = VampirioGraphics.GetStringSize(font, str);
            TRect rect = new TRect(startX, startY, (int)size.Width, (int)size.Height);
            startX += rect.Width;
            rects.Add(rect);
            return rect;
        }

        public SizeF GetSpaceSize(Font font)
        {
            return VampirioGraphics.GetStringSize(font, " ");
        }

    }
}
