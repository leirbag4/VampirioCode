using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampirioCode.UI.Controls.TabManagement
{
    public enum TabPaintMode
    {
        UserPaintAll,   /* Tab will not be painted and user must paint it on Paint() inside TabItem */
        UserPaintOver   /* Tab will be painted normally and user can paint over the tab on Paint() inside TabItem */
    }
}
