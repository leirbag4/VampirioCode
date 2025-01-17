using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.Utils
{
    public class DefineUtils
    {
        public static void HideIfDebug(Control[] items)
        {
#if RELEASE
            foreach (Control item in items)
            {
                item.Visible = false;
            }
#endif
        }

        public static void HideIfDebug(ToolStripMenuItem[] items)
        {
#if RELEASE
            foreach (ToolStripMenuItem item in items)
            {
                item.Visible = false;
            }
#endif
        }
    }
}
