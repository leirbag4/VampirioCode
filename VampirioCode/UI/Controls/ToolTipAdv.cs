using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls
{
    public class ToolTipAdv : ToolTip
    {

        public ToolTipAdv()
        {
            BackColor = Color.FromArgb(30, 30, 30);
            ForeColor = Color.FromArgb(160, 160, 160);
            OwnerDraw = true;
            Draw += OnDraw;
        }

        private void OnDraw(object? sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
    }
}
